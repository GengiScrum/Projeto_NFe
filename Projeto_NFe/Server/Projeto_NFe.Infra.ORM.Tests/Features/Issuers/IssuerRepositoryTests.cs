﻿using Effort;
using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests;
using Projeto_NFe.Domain.Features.Issuers;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Infra.ORM.Features.Issuers;
using Projeto_NFe.Infra.ORM.Tests.Context;
using System;
using System.Linq;

namespace Projeto_NFe.Infra.ORM.Tests.Features.Issuers
{
    [TestFixture]
    public class IssuerRepositoryTests
    {
        private FakeDbContext _ctx;
        private IssuerRepository _repository;
        private Issuer _issuer;
        private Issuer _issuerBase;

        [SetUp]
        public void Setup()
        {
            var conexao = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            _ctx = new FakeDbContext(conexao);
            _repository = new IssuerRepository(_ctx);
            _issuer = ObjectMother.IssuerValidWithIdAndWithAddress();
            //Seed
            _issuerBase = ObjectMother.IssuerValidWithIdAndWithAddress();
            _ctx.Issuers.Add(_issuerBase);
            _ctx.SaveChanges();
        }

        #region ADD
        [Test]
        public void Issuers_Repository_Add_Sucessfully()
        {
            //Action
            var issuer = _repository.Add(_issuer);
            //Assert
            issuer.Should().NotBeNull();
            issuer.Id.Should().NotBe(0);
            var expectedOrder = _ctx.Issuers.Find(issuer.Id);
            expectedOrder.Should().NotBeNull();
            expectedOrder.Should().Be(issuer);
        }

        #endregion

        #region GET

        [Test]
        public void Issuers_Repository_GetAll_Sucessfully()
        {
            //Action
            var issuers = _repository.GetAll().ToList();

            //Assert
            issuers.Should().NotBeNull();
            issuers.Should().HaveCount(_ctx.Issuers.Count());
            issuers.First().Should().Be(_issuerBase);
        }

        [Test]
        public void Issuers_Repository_GetById_Sucessfully()
        {
            //Action
            var issuer = _repository.GetById(_issuerBase.Id);

            //Assert
            issuer.Should().NotBeNull();
            issuer.Should().Be(_issuerBase);
        }

        #endregion

        #region DELETE
        [Test]
        public void Issuers_Repository_Remove_Sucessfully()
        {
            // Action
            var removed = _repository.Remove(_issuerBase.Id);
            // Assert
            removed.Should().BeTrue();
            _ctx.Issuers.Where(i => i.Id == _issuerBase.Id).FirstOrDefault().Should().BeNull();
        }

        [Test]
        public void Issuers_Repository_Remove_ShouldThrowNotFoundException()
        {
            // Arrange
            var idInvalid = 10;
            // Action
            Action act = () => _repository.Remove(idInvalid);
            // Assert
            act.Should().Throw<NotFoundException>();
        }
        #endregion

        #region UPDATE

        [Test]
        public void Issuers_Repository_Update_Sucessfully()
        {
            // Arrange
            var modified = false;
            var newName = "alterado";
            _issuerBase.BusinessName = newName;
            //Action
            var updated = new Action(() => { modified = _repository.Update(_issuerBase); });
            // Assert
            updated.Should().NotThrow<Exception>();
            modified.Should().BeTrue();
        }
        #endregion
    }
}
