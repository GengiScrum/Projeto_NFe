using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Issuers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Application.Features.Issuers.Commands;
using AutoMapper;
using Projeto_NFe.Application.Features.ShippingCompanies.Queries;
using Projeto_NFe.Application.Features.Issuers.Queries;

namespace Projeto_NFe.Application.Features.Issuers
{
    public class IssuerService : IIssuerService
    {
        IIssuerRepository _issuerRepository;

        public IssuerService(IIssuerRepository issuerRepository)
        {
            _issuerRepository = issuerRepository;
        }

        public int Add(IssuerRegisterCommand command)
        {
            var issuer = Mapper.Map<IssuerRegisterCommand, Issuer>(command);

            var newIssuer = _issuerRepository.Add(issuer);

            return newIssuer.Id;
        }

        public bool Update(IssuerUpdateCommand command)
        {
            var issuer = _issuerRepository.GetById(command.Id);
            if (issuer == null)
                throw new NotFoundException();
            Mapper.Map(command, issuer);
            return _issuerRepository.Update(issuer);
        }

        public bool Remove(IssuerRemoveCommand command)
        {
            var isRemovedAll = true;
            foreach (var issuerId in command.IssuersId)
            {
                var isRemoved = _issuerRepository.Remove(issuerId);
                isRemovedAll = isRemoved ? isRemovedAll : false;
            }
            return isRemovedAll;
        }

        public Issuer GetById(int id)
        {
            var issuer = _issuerRepository.GetById(id);
            return issuer;

        }

        public IQueryable<Issuer> GetAll()
        {
            return _issuerRepository.GetAll();
        }

        public IQueryable<Issuer> GetAll(IssuerQuery query)
        {
            return _issuerRepository.GetAll(query.Quantity);
        }
    }
}
