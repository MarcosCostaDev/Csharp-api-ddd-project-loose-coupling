using api_baixo_acoplamento.Domain.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_baixo_acoplamento.Domain.Entities;
using api_baixo_acoplamento.Domain.Interface.Repository;

namespace api_baixo_acoplamento.Domain.Services
{
    public class LogMessageService : ILogMessageService
    {
        public readonly ILogMessageRepository _logMessageRepository;

        public LogMessageService(ILogMessageRepository logMessageRepository)
        {
            this._logMessageRepository = logMessageRepository;
        }

        public IEnumerable<LogMessage> ObterLogs()
        {
            return _logMessageRepository.ObterLogs();
        }
    }
}
