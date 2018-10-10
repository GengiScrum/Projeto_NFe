﻿using Effort;
using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests;
using Projeto_NFe.Domain.Features.ShippingCompanies;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Infra.ORM.Features.ShippingCompanies;
using Projeto_NFe.Infra.ORM.Tests.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.ORM.Tests.Features.ShippingCompanies
{
    [TestFixture]
    public class ShippingCompanyRepositoryTests
    {
        private FakeDbContext _ctx;
        private ShippingCompanyRepository _repository;
        private ShippingCompany _shippingCompany;
        private ShippingCompany _shippingCompanyBase;

        [SetUp]
        public void Setup()
        {
            var conexao = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            _ctx = new FakeDbContext(conexao);
            _repository = new ShippingCompanyRepository(_ctx);
            _shippingCompany = ObjectMother.ShippingCompanyValidWithIdWithAddress();
            //Seed
            _shippingCompanyBase = ObjectMother.ShippingCompanyValidWithIdWithAddress();
            _ctx.ShippingCompanies.Add(_shippingCompanyBase);
            _ctx.SaveChanges();
        }

        #region ADD
        [Test]
        public void ShippingCompanies_Repository_Add_Sucessfully()
        {
            //Ação
            var shippingCompany = _repository.Add(_shippingCompany);
            //Verificação
            shippingCompany.Should().NotBeNull();
            shippingCompany.Id.Should().NotBe(0);
            var expectedOrder = _ctx.ShippingCompanies.Find(shippingCompany.Id);
            expectedOrder.Should().NotBeNull();
            expectedOrder.Should().Be(shippingCompany);
        }

        #endregion

        #region GET

        [Test]
        public void ShippingCompanies_Repository_GetAll_Sucessfully()
        {
            //Ação
            var shippingCompanyes = _repository.GetAll().ToList();

            //Assert
            shippingCompanyes.Should().NotBeNull();
            shippingCompanyes.Should().HaveCount(_ctx.ShippingCompanies.Count());
            shippingCompanyes.First().Should().Be(_shippingCompanyBase);
        }

        [Test]
        public void ShippingCompanies_Repository_GetById_Sucessfully()
        {
            //Ação
            var shippingCompany = _repository.GetById(_shippingCompanyBase.Id);

            //Assert
            shippingCompany.Should().NotBeNull();
            shippingCompany.Should().Be(_shippingCompanyBase);
        }

        #endregion

        #region DELETE
        [Test]
        public void ShippingCompanies_Repository_Remove_Sucessfully()
        {
            // Ação
            var removed = _repository.Remove(_shippingCompanyBase.Id);
            // Assert
            removed.Should().BeTrue();
            _ctx.ShippingCompanies.Where(p => p.Id == _shippingCompanyBase.Id).FirstOrDefault().Should().BeNull();
        }

        [Test]
        public void ShippingCompanies_Repository_Remove_DeveTratarNotFoundException()
        {
            // Cenário
            var idInvalid = 10;
            // Ação
            Action Remove = () => _repository.Remove(idInvalid);
            // Verificação
            Remove.Should().Throw<NotFoundException>();
        }
        #endregion

        #region UPDATE

        [Test]
        public void ShippingCompanies_Repository_Alterar_Sucessfully()
        {
            // Cenário
            var alterado = false;
            var newName = "alterado";
            _shippingCompanyBase.Name = newName;
            //Ação
            var atualizado = new Action(() => { alterado = _repository.Update(_shippingCompanyBase); });
            // Verificação
            atualizado.Should().NotThrow<Exception>();
            alterado.Should().BeTrue();
        }
        #endregion
    }
}