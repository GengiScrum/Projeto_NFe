using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Invoices.Commands
{
    [ExcludeFromCodeCoverage]
    public class InvoiceRemoveProductsCommand
    {
        public virtual int Id { get; set; }
        public int[] SoldProductsIds { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<InvoiceRemoveProductsCommand>
        {
            public Validator()
            {
                RuleFor(i => i.Id).NotNull().GreaterThan(0);
                RuleFor(i => i.SoldProductsIds.Count()).GreaterThan(0);
            }
        }

    }
}
