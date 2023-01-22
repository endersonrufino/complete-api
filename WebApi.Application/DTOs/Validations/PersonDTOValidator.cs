using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Application.DTOs.Validations
{
    public class PersonDTOValidator : AbstractValidator<PersonDTO>
    {
        public PersonDTOValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("O nome da pessoa deve ser informado");
            RuleFor(p => p.Document).NotEmpty().NotNull().WithMessage("O documento da pessoa deve ser informado");
            RuleFor(p => p.Phone).NotEmpty().NotNull().WithMessage("O telefone da pessoa deve ser informado");
        }
    }
}
