using api_baixo_acoplamento.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_baixo_acoplamento.Domain.Entities;
using api_baixo_acoplamento.Domain.Interface.Services;

namespace api_baixo_acoplamento.Application.Services
{
    public class LogMessageApplication : ILogMessageApplication
    {
        private readonly ILogMessageService _logMessageService;

        public LogMessageApplication(ILogMessageService logMessageService)
        {
            this._logMessageService = logMessageService;
        }

        public IEnumerable<LogMessage> ObterLogs()
        {
            return _logMessageService.ObterLogs();
        }
    }
}
