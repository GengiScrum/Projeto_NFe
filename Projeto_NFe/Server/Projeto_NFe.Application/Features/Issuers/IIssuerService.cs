using Projeto_NFe.Application.Features.Issuers.Commands;
using Projeto_NFe.Application.Features.Issuers.Queries;
using Projeto_NFe.Domain.Features.Issuers;
using System.Linq;

namespace Projeto_NFe.Application.Features.Issuers
{
    public interface IIssuerService
    {
        int Add(IssuerRegisterCommand command);
        bool Update(IssuerUpdateCommand command);
        bool Remove(IssuerRemoveCommand command);
        Issuer GetById(int id);
        IQueryable<Issuer> GetAll();
        IQueryable<Issuer> GetAll(IssuerQuery query);
    }
}
