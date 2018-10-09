using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Products.Commands
{
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

        class Validator : AbstractValidator<ProductUpdateCommand>
        {
            public Validator()
            {
                RuleFor(p => p.Code).NotNull().MaximumLength(40);
                RuleFor(p => p.Description).NotNull().MaximumLength(40);
                RuleFor(p => p.UnitaryValue).NotNull().GreaterThan(0);
            }
        }
    }
}
