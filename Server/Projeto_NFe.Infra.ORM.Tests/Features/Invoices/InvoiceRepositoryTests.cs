using Effort;
using NUnit.Framework;
using Projeto_NFe.Common.Tests;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.Issuers;
using Projeto_NFe.Domain.Features.ShippingCompanies;
using Projeto_NFe.Infra.ORM.Features.Invoices;
using Projeto_NFe.Infra.ORM.Tests.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.ORM.Testes.Features.Invoices
{
    [TestFixture]
    public class InvoiceRepositoryTests
    {
        private FakeDbContext _context;
        private InvoiceRepository _invoiceRepository;
        private Invoice _invoice;
        private Invoice _invoiceBase;
        private Issuer _issuerBase;
        private ShippingCompany _shippingCompanyBase;
        [SetUp]
        public void Setup()
        {
            var conexao = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            _context = new FakeDbContext(conexao);
            _invoiceRepository = new InvoiceRepository(_context);
            _invoice = ObjectMother.InvoiceWithoutIdNeedMock();
            //Seed

            //Adicionando o Issuer
            _issuerBase = _context.Issuers.Add(ObjectMother.IssuerValidWithoutIdAndWithAddress());
            _shippingCompanyBase = _context.ShippingCompanies.Add(ObjectMother.ShippingCompanyValidWithoutIdWithAddress());
            //faltando addressee
            _invoiceBase = ObjectMother.InvoiceValidWithoutIdWithIssuerAddresseeShippingCompanyId(_issuerBase.Id, _shippingCompanyBase.Id);
            _context.Issuers.Add(_issuerBase);
            _context.SaveChanges();
        }

    }
}
