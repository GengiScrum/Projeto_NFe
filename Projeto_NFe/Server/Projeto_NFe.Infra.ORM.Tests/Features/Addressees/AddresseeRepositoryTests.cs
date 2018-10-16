using Effort;
using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Addressees;
using Projeto_NFe.Infra.ORM.Features.Addressees;
using Projeto_NFe.Infra.ORM.Tests.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.ORM.Tests.Features.Addressees
{
    [TestFixture]
    public class AddresseeRepositoryTests
    {
        private FakeDbContext _ctx;
        private AddresseReposiotory _repository;
        private Addressee _addressee;
        private Addressee _addresseeBase;

        [SetUp]
        public void Setup()
        {
            var conexao = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            _ctx = new FakeDbContext(conexao);
            _repository = new AddresseReposiotory(_ctx);
            _addressee = ObjectMother.AddresseeValidWithIdWithAddress();
            //Seed
            _addresseeBase = ObjectMother.AddresseeValidWithIdWithAddress();
            _ctx.Addressees.Add(_addresseeBase);
            _ctx.SaveChanges();
        }

        #region ADD
        [Test]
        public void Addressees_Repository_Add_Sucessfully()
        {
            //Action
            var addressee = _repository.Add(_addressee);
            //Assert
            addressee.Should().NotBeNull();
            addressee.Id.Should().NotBe(0);
            var expectedOrder = _ctx.Addressees.Find(addressee.Id);
            expectedOrder.Should().NotBeNull();
            expectedOrder.Should().Be(addressee);
        }

        #endregion

        #region GET

        [Test]
        public void Addressees_Repository_GetAll_Sucessfully()
        {
            //Action
            var addressee = _repository.GetAll().ToList();

            //Assert
            addressee.Should().NotBeNull();
            addressee.Should().HaveCount(_ctx.Addressees.Count());
            addressee.First().Should().Be(_addresseeBase);
        }

        [Test]
        public void Addressees_Repository_GetById_Sucessfully()
        {
            //Action
            var addressee = _repository.GetById(_addresseeBase.Id);

            //Assert
            addressee.Should().NotBeNull();
            addressee.Should().Be(_addresseeBase);
        }

        #endregion

        #region DELETE
        [Test]
        public void Addressees_Repository_Remove_Sucessfully()
        {
            // Action
            var removed = _repository.Remove(_addresseeBase.Id);
            // Assert
            removed.Should().BeTrue();
            _ctx.Addressees.Where(p => p.Id == _addresseeBase.Id).FirstOrDefault().Should().BeNull();
        }

        [Test]
        public void Addressees_Repository_Remove_ShouldThrowNotFoundException()
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
        public void Addressees_Repository_Update_Sucessfully()
        {
            // Arrange
            var modified = false;
            var newName = "alterado";
            _addresseeBase.BusinessName = newName;
            //Action
            var updated = new Action(() => { modified = _repository.Update(_addresseeBase); });
            // Assert
            updated.Should().NotThrow<Exception>();
            modified.Should().BeTrue();
        }
        #endregion
    }
}
