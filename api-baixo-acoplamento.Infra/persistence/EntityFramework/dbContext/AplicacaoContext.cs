using api_baixo_acoplamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_baixo_acoplamento.Infra.persistence.EntityFramework.dbContext
{
    public class AplicacaoContext : DbContext
    {
        public AplicacaoContext() : base()
        {

        }

        public DbSet<LogMessage> LogMessage { get; set; }


        private void FixEfProviderServicesProblem()
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}
