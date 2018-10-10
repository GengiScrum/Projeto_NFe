using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Addressees.Commands
{
    [ExcludeFromCodeCoverage]
    public class AddresseeRemoveCommand
    {
        public virtual int[] AddresseesId { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<AddresseeRemoveCommand>
        {
            public Validator()
            {
                RuleFor(a => a.AddresseesId).NotNull();
                RuleFor(a => a.AddresseesId.Length).GreaterThan(0);
            }
        }
    }
}
