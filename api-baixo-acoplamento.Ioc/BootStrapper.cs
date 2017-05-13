using api_baixo_acoplamento.Application.Interfaces;
using api_baixo_acoplamento.Application.Services;
using api_baixo_acoplamento.Domain.Interface.Services;
using api_baixo_acoplamento.Domain.Services;
using api_baixo_acoplamento.Domain.Interface.Repository;
using api_baixo_acoplamento.Infra.persistence.EntityFramework;
using SimpleInjector;

namespace api_baixo_acoplamento.Ioc
{
    public class BootStrapper
    {
        public static void RegisterWebApi(Container container)
        {
            //Serviços de Application
            container.Register<ILogMessageApplication, LogMessageApplication>(Lifestyle.Scoped);

            //Serviços de Domain
            container.Register<ILogMessageService, LogMessageService>(Lifestyle.Scoped);

            //Serviços de Infra
            container.Register<ILogMessageRepository, LogMessageRepository>(Lifestyle.Scoped);

        }
    }
}
