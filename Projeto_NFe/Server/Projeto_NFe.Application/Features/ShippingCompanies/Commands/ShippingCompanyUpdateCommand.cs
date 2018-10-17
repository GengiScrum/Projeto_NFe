using FluentValidation;
using FluentValidation.Results;
using Projeto_NFe.Application.Features.Addresses.Commands;
using System.Diagnostics.CodeAnalysis;

namespace Projeto_NFe.Application.Features.ShippingCompanies.Commands
{
    [ExcludeFromCodeCoverage]
    public class ShippingCompanyUpdateCommand
    {
        public virtual int Id { get; set; }
        public virtual string BusinessName { get; set; }
        public virtual string CorporateName { get; set; }
        public virtual string Cnpj { get; set; }
        public virtual string Cpf { get; set; }
        public virtual string StateRegistration { get; set; }
        public virtual int PersonType { get; set; }
        public AddressCommand Address { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<ShippingCompanyUpdateCommand>
        {
            public Validator()
            {
                RuleFor(t => t.Id).NotNull().GreaterThan(0);
                RuleFor(t => t.BusinessName).NotNull().NotEmpty().MaximumLength(40);
                RuleFor(t => t.CorporateName).MaximumLength(40);
                RuleFor(t => t.Cpf).Length(14);
                RuleFor(t => t.Cnpj).Length(18);
                RuleFor(t => t.StateRegistration).MaximumLength(40);
                RuleFor(t => t.PersonType).NotNull().NotEmpty();
                RuleFor(t => t.Address).NotNull();
            }
        }
    }
}
