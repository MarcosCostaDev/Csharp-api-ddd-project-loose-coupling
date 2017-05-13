using api_baixo_acoplamento.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_baixo_acoplamento.Domain.Entities;
using api_baixo_acoplamento.Infra.persistence.EntityFramework.dbContext;

namespace api_baixo_acoplamento.Infra.persistence.EntityFramework
{
    public class LogMessageRepository : ILogMessageRepository
    {
        public IEnumerable<LogMessage> ObterLogs()
        {
            using (var ctx = new AplicacaoContext())
            {
                return ctx.LogMessage.ToList();
            }
        }
    }
}
