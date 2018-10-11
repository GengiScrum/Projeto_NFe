using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Products.Commands
{
    [ExcludeFromCodeCoverage]
    public class ProductUpdateCommand
    {
        public virtual int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public double UnitaryValue { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator: AbstractValidator<ProductUpdateCommand>
        {
            public Validator()
            {
                RuleFor(p => p.Id).NotNull().GreaterThan(0);
                RuleFor(p => p.Code).NotNull();
                RuleFor(p => p.Description).NotNull();
                RuleFor(p => p.UnitaryValue).NotNull().GreaterThan(0);
            }
        }
    }
}
