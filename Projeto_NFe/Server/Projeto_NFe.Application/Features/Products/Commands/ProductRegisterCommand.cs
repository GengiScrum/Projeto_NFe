using FluentValidation;
using FluentValidation.Results;
using Projeto_NFe.Application.Features.ProductTaxes.Commands;
using System.Diagnostics.CodeAnalysis;

namespace Projeto_NFe.Application.Features.Products.Commands
{
    [ExcludeFromCodeCoverage]
    public class ProductRegisterCommand
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public double UnitaryValue { get; set; }
        public ProductTaxRegisterCommand Tax { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<ProductRegisterCommand>
        {
            public Validator()
            {
                RuleFor(p => p.Code).NotNull();
                RuleFor(p => p.Description).NotNull();
                RuleFor(p => p.UnitaryValue).NotNull();
                RuleFor(p => p.Tax).NotNull();
            }
        }
    }
}
