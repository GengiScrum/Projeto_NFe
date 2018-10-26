using FluentValidation;
using FluentValidation.Results;
using Projeto_NFe.Domain.Features.Products;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.SoldProducts.Commands
{
    [ExcludeFromCodeCoverage]
    public class SoldProductRegisterCommand
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<SoldProductRegisterCommand>
        {
            public Validator()
            {
                RuleFor(ps => ps.Quantity).NotNull().GreaterThan(0);
                RuleFor(ps => ps.ProductId).NotNull().GreaterThan(0);
            }
        }
    }
}
