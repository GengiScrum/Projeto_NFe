using FluentValidation;
using FluentValidation.Results;
using System.Diagnostics.CodeAnalysis;

namespace Projeto_NFe.Application.Features.Products.Commands
{
    [ExcludeFromCodeCoverage]
    public class ProductRemoveCommand
    {
        public int [] ProductsId { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator: AbstractValidator<ProductRemoveCommand>
        {
            public Validator()
            {
                RuleFor(p => p.ProductsId).NotNull();
                RuleFor(p => p.ProductsId.Length).GreaterThan(0);
            }
        }
    }
}
