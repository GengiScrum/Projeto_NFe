using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Issuers.Commands
{
    [ExcludeFromCodeCoverage]
    public class IssuerRemoveCommand
    {
        public int[] IssuersId { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<IssuerRemoveCommand>
        {
            public Validator()
            {
                RuleFor(e => e.IssuersId).NotNull();
                RuleFor(e => e.IssuersId.Length).GreaterThan(0);
            }
        }
    }
}
