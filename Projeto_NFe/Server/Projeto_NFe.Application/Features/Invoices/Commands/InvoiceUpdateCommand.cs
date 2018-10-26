
using FluentValidation;
using FluentValidation.Results;
using Projeto_NFe.Application.Features.SoldProducts;
using Projeto_NFe.Application.Features.SoldProducts.Commands;
using Projeto_NFe.Domain.Features.SoldProducts;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Invoices.Commands
{
    [ExcludeFromCodeCoverage]
    public class InvoiceUpdateCommand
    {
        public virtual int Id { get; set; }
        public int? IssuerId { get; set; }
        public int? AddresseeId { get; set; }
        public int? ShippingCompanyId { get; set; }
        public DateTime EntryDate { get; set; }
        public string OperationNature { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<InvoiceUpdateCommand>
        {
            public Validator()
            {
                RuleFor(i => i.Id).NotNull().GreaterThan(0);
            }
        }
    }
}
