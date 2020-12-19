using FluentValidation;
using Robson.Services.Common.Models;
using System;

namespace Robson.Services.Common.Validators
{
    public class PessoaValidator : AbstractValidator<PessoaViewModel>
    {
        public PessoaValidator()
        {
            RuleFor(r => r.Nome)
                .NotEmpty()
                .Length(3, 50);

            RuleFor(r => r.Nascimento)
                .NotEmpty()
                .LessThan(DateTime.Now);

            RuleFor(r => r.Celular)
                .NotEmpty();

            RuleFor(r => r.Email)
                .NotEmpty()
                .EmailAddress()
                .Length(3, 50);

            RuleFor(r => r.Pais)
                .NotEmpty()
                .Length(3, 20);
        }
    }
}
