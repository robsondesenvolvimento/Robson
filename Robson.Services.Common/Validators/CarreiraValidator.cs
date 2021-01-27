using FluentValidation;
using Robson.Services.Common.Models;
using System;

namespace Robson.Services.Common.Validators
{
    public class CarreiraValidator : AbstractValidator<CarreiraViewModel>
    {
        public CarreiraValidator()
        {
            RuleFor(r => r.Empresa)
                .NotEmpty()
                .Length(3, 50);

            RuleFor(r => r.Funcao)
                .NotEmpty()
                .Length(3, 50);

            RuleFor(r => r.DataInicio)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now);
        }
    }
}
