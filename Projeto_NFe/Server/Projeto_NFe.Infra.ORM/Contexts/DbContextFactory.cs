using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.ORM.Contexts
{
    public class DbContextFactory : IDbContextFactory<NFeContext>
    {
        public NFeContext Create()
        {
            return new NFeContext();
        }
    }
}
