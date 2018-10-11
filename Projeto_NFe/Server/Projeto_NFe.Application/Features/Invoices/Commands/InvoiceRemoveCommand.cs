using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Invoices.Commands
{
    public class InvoiceRemoveCommand
    {
        public int[] InvoicesId { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<InvoiceRemoveCommand>
        {
            public Validator()
            {
                RuleFor(i => i.InvoicesId).NotNull();
            }
        }
    }
}
