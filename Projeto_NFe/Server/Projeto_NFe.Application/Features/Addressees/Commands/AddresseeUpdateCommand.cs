using FluentValidation;
using FluentValidation.Results;
using Projeto_NFe.Application.Features.Addresses.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Addressees.Commands
{
    [ExcludeFromCodeCoverage]
    public class AddresseeUpdateCommand
    {
        public virtual int Id { get; set; }
        public string BusinessName { get; set; }
        public string CorporateName { get; set; }
        public string Cnpj { get; set; }
        public string Cpf { get; set; }
        public string StateRegistration { get; set; }
        public AddressCommand Address { get; set; }
        public int PersonType { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<AddresseeUpdateCommand>
        {
            public Validator()
            {
                RuleFor(a => a.Id).NotEmpty().NotEmpty().GreaterThan(0);
                RuleFor(a => a.BusinessName).NotNull().MaximumLength(40);
                RuleFor(a => a.CorporateName).MaximumLength(40);
                RuleFor(a => a.Cnpj).MaximumLength(40);
                RuleFor(a => a.Cpf).MaximumLength(40);
                RuleFor(a => a.StateRegistration).MaximumLength(40);
                RuleFor(a => a.Address).NotNull();
                RuleFor(a => a.PersonType).NotNull().NotEmpty();

            }
        }
    }
}
