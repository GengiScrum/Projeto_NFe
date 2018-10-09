using FluentValidation;
using FluentValidation.Results;
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
        public int Id { get; set; }
        public string BusinessName { get; set; }
        public string CorporateName { get; set; }
        public string Cnpj { get; set; }
        public string Cpf { get; set; }
        public string StateRegistration { get; set; }
        public string StreetName { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
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
                RuleFor(a => a.CorporateName).NotNull().MaximumLength(40);
                RuleFor(a => a.Cnpj).NotNull().MaximumLength(40);
                RuleFor(a => a.Cpf).NotNull().MaximumLength(40);
                RuleFor(a => a.StateRegistration).NotNull().MaximumLength(40);
                RuleFor(a => a.StreetName).NotNull().MaximumLength(40);
                RuleFor(a => a.Number).NotNull();
                RuleFor(a => a.Neighborhood).NotNull().MaximumLength(40);
                RuleFor(a => a.City).NotNull().MaximumLength(40);
                RuleFor(a => a.State).NotNull().MaximumLength(40);
                RuleFor(a => a.Country).NotNull().MaximumLength(40);
                RuleFor(a => a.PersonType).NotNull().NotEmpty();

            }
        }
    }
}
