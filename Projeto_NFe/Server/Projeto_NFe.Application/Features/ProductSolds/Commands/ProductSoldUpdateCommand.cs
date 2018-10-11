using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.ProductSolds.Commands
{
    public class ProductSoldUpdateCommand
    {
        public int IdProductSold { get; set; }
        public int Quantity { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int UnitaryValue { get; set; }
        public int InvoiceId { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<ProductSoldUpdateCommand>
        {
            public Validator()
            {
                RuleFor(ps => ps.IdProductSold).NotNull();
                RuleFor(ps => ps.Quantity).NotNull();
                RuleFor(ps => ps.UnitaryValue).NotNull();
                RuleFor(ps => ps.Code).NotNull();
                RuleFor(ps => ps.Description).NotNull();
                RuleFor(ps => ps.InvoiceId).NotNull();
            }
        }
    }
}
