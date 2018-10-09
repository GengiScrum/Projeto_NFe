using Projeto_NFe.Infra.ORM.Contexts;
using Projeto_NFe.Infra.ORM.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.ORM.Initializer
{
    public class DbInitializer : MigrateDatabaseToLatestVersion<NFeContext, Configuration>
    {
    }
}
