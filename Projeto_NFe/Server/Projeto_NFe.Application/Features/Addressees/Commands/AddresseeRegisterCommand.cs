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
    public class AddresseeRegisterCommand
    {
        public string BusinessName { get; set; }
        public string CorporateName { get; set; }
        public string Cnpj { get; set; }
        public string Cpf { get; set; }
        public string StateRegistration { get; set; }
        public AddressCommand Address { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<AddresseeRegisterCommand>
        {
            public Validator()
            {
                RuleFor(a => a.BusinessName).NotNull().MaximumLength(40);
                RuleFor(a => a.CorporateName).NotNull().MaximumLength(40);
                RuleFor(a => a.Cnpj).NotNull().MaximumLength(40);
                RuleFor(a => a.Cpf).NotNull().MaximumLength(40);
                RuleFor(a => a.StateRegistration).NotNull().MaximumLength(40);
                RuleFor(a => a.Address).NotNull();

            }
        }
    }
}
