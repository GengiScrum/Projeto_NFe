using FluentValidation;
using FluentValidation.Results;
using System.Diagnostics.CodeAnalysis;

namespace Projeto_NFe.Application.Features.ShippingCompanies.Commands
{
    [ExcludeFromCodeCoverage]
    public class ShippingCompanyRemoveCommand
    {
        public virtual int[] Ids { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<ShippingCompanyRemoveCommand>
        {
            public Validator()
            {
                RuleFor(t => t.Ids).NotNull();
                RuleFor(t => t.Ids.Length).GreaterThan(0);
            }
        }
    }
}
