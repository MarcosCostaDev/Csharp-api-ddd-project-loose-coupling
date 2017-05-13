using api_baixo_acoplamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_baixo_acoplamento.Domain.Interface.Repository
{
    public interface ILogMessageRepository
    {
        IEnumerable<LogMessage> ObterLogs();
    }
}
