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
    public class InvoiceIssueCommand
    {
        public int Id;

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<InvoiceIssueCommand>
        {
            public Validator()
            {
                RuleFor(i => i.Id).GreaterThan(0);
            }
        }
    }    
}
