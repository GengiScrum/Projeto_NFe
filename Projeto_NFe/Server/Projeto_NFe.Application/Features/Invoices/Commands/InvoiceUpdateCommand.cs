
using FluentValidation;
using FluentValidation.Results;
using Projeto_NFe.Application.Features.ProductSolds;
using Projeto_NFe.Application.Features.ProductSolds.Commands;
using Projeto_NFe.Domain.Features.ProductsSold;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Invoices.Commands
{
    public class InvoiceUpdateCommand
    {
        public virtual int Id { get; set; }
        public int? IssuerId { get; set; }
        public int? AddresseeId { get; set; }
        public int? ShippingCompanyId { get; set; }
        public DateTime EntryDate { get; set; }
        public string OperationNature { get; set; }
        public List <ProductSoldUpdateCommand> ProductSolds { get; set; }

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
