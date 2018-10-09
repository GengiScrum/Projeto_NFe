using FluentValidation;
using FluentValidation.Results;
using Projeto_NFe.Domain.Features.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Products.Commands
{
    public class ProductRemoveCommand
    {
        public int [] ProductsId { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<ProductRemoveCommand>
        {
            public Validator()
            {
                RuleFor(p => p.ProductsId).NotNull();
                RuleFor(p => p.ProductsId.Length).GreaterThan(0);
            }
        }
    }
}
