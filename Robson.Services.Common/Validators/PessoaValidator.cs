using FluentValidation;
using Robson.Services.Common.Models;

namespace Robson.Services.Common.Validators
{
    public class PessoaValidator : AbstractValidator<PessoaViewModel>
    {
        public PessoaValidator()
        {
            RuleFor(r => r.Nome).NotEmpty();
            RuleFor(r => r.Nascimento).NotEmpty();
            RuleFor(r => r.Celular).NotEmpty();
            RuleFor(r => r.Email).NotEmpty();
            RuleFor(r => r.Pais).NotEmpty();
        }
    }
}
