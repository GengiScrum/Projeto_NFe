using FluentValidation;
using FluentValidation.Results;
using Projeto_NFe.Application.Features.SoldProducts.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Invoices.Commands
{
    [ExcludeFromCodeCoverage]
    public class InvoiceAddProductCommand
    {
        public virtual int Id { get; set; }
        public SoldProductRegisterCommand SoldProduct { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<InvoiceAddProductCommand>
        {
            public Validator()
            {
                RuleFor(i => i.Id).NotNull().GreaterThan(0);
            }
        }
    }
}
