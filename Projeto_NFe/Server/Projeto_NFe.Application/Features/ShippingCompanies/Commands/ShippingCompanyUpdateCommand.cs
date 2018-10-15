﻿using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.ShippingCompanies.Commands
{
    [ExcludeFromCodeCoverage]
    public class ShippingCompanyUpdateCommand
    {
        public virtual int Id { get; set; }
        public virtual string BusinessName { get; set; }
        public virtual string CorporateName { get; set; }
        public virtual string Cnpj { get; set; }
        public virtual string Cpf { get; set; }
        public virtual string StateRegistration { get; set; }
        public virtual int PersonType { get; set; }
        public virtual string StreetName { get; set; }
        public virtual int Number { get; set; }
        public virtual string Neighborhood { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string Country { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<ShippingCompanyUpdateCommand>
        {
            public Validator()
            {
                RuleFor(t => t.Id).NotNull().GreaterThan(0);
                RuleFor(t => t.BusinessName).NotNull().NotEmpty().MaximumLength(40);
                RuleFor(t => t.CorporateName).MaximumLength(40);
                RuleFor(t => t.Cpf).Length(14);
                RuleFor(t => t.Cnpj).Length(18);
                RuleFor(t => t.StateRegistration).MaximumLength(40);
                RuleFor(t => t.PersonType).NotNull().NotEmpty();
                RuleFor(t => t.StreetName).NotNull().NotEmpty().MaximumLength(40);
                RuleFor(t => t.Number).NotNull().NotEmpty();
                RuleFor(t => t.Neighborhood).NotNull().NotEmpty().MaximumLength(40);
                RuleFor(t => t.City).NotNull().NotEmpty().MaximumLength(40);
                RuleFor(t => t.State).NotNull().NotEmpty().MaximumLength(40);
                RuleFor(t => t.Country).NotNull().NotEmpty().MaximumLength(40);
            }
        }
    }
}
