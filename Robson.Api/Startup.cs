using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Robson.Api.Filters;
using Robson.Api.Mappings;
using Robson.Api.Services;
using Robson.Common;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Domain.Entities;
using Robson.Services.Common.Models;
using Robson.Services.Common.Validators;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Robson.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<DatabaseContext>(options =>
            {
                options.UseInMemoryDatabase("Robson");
            });

            services.AddScoped<IPessoaRepository<Pessoa>, PessoaRepository>();

            services.AddCors(options =>
            {
                options.AddPolicy(ConstantVars.POLICY_NAME,
                builder => builder
                    .AllowAnyOrigin()
                    .WithMethods("GET", "POST", "PUT", "DELETE")
                    //.AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(BadRequestFilter));
                options.Filters.Add(typeof(InternalServerErrorFilter));
            })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                    options.JsonSerializerOptions.WriteIndented = false;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                })
                .AddFluentValidation(options =>
                {
                    options.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                    options.ImplicitlyValidateChildProperties = true;
                });

            services.AddTransient<IValidator<PessoaViewModel>, PessoaValidator>();

            var mapperConfiguration = new MapperConfiguration(configure =>
            {
                configure.AddProfile<DomainToViewModelMappingProfile>();
                configure.AddProfile<ViewModelToDomainMappingProfile>();
            });

            services.AddSingleton(mapperConfiguration.CreateMapper());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Robson.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Robson.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            await app.PessoaSeedingServiceStart();
            await app.CarreiraSeedingServiceStart();

            app.UseCors(ConstantVars.POLICY_NAME);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapControllerRoute(
                    name: "DefaultApi",
                    pattern: "api/{controller}/{id?}"
                );
            });
        }
    }
}
