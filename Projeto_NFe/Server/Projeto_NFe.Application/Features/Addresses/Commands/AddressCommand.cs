using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Addresses.Commands
{
    [ExcludeFromCodeCoverage]
    public class AddressCommand
    {
        public string StreetName { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<AddressCommand>
        {
            public Validator()
            {
                RuleFor(e => e.StreetName).NotNull().MaximumLength(40);
                RuleFor(e => e.Number).NotNull();
                RuleFor(e => e.Neighborhood).NotNull().MaximumLength(40);
                RuleFor(e => e.City).NotNull().MaximumLength(40);
                RuleFor(e => e.State).NotNull().MaximumLength(40);
                RuleFor(e => e.Country).NotNull().MaximumLength(40);
            }
        }
    }
}
