using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.ProductTaxes.Commands
{
    [ExcludeFromCodeCoverage]
    public class ProductTaxRegisterCommand
    {
        public double IpiAliquot { get; set; }
        public double IcmsAliquot { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<ProductTaxRegisterCommand>
        {
            public Validator()
            {
                RuleFor(p => p.IpiAliquot).NotNull();
                RuleFor(p => p.IcmsAliquot).NotNull();
            }
        }
    }
}
