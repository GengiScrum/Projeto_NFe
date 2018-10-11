using FluentValidation;
using FluentValidation.Results;
using Projeto_NFe.Domain.Features.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.ProductSolds.Commands
{
    public class ProductSoldRegisterCommand
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public int InvoiceId { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<ProductSoldRegisterCommand>
        {
            public Validator()
            {
                RuleFor(ps => ps.Quantity).NotNull();
                RuleFor(ps => ps.InvoiceId).NotNull();
                RuleFor(ps => ps.Product).NotNull();
            }
        }
    }
}
