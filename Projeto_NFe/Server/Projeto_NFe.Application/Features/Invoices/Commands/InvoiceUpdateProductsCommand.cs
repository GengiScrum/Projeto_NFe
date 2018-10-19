using FluentValidation;
using FluentValidation.Results;
using Projeto_NFe.Application.Features.ProductSolds.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Invoices.Commands
{
    public class InvoiceUpdateProductsCommand
    {
        public virtual int Id { get; set; }
        public IEnumerable<ProductSoldUpdateCommand> ProductSolds { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<InvoiceUpdateProductsCommand>
        {
            public Validator()
            {
                RuleFor(i => i.Id).NotNull().GreaterThan(0);
            }
        }
    }
}
