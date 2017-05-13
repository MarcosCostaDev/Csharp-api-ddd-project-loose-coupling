using Owin;
using SimpleInjector;
using System.Web.Http;
using System;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SimpleInjector.Integration.WebApi;
using api_baixo_acoplamento.Seguranca;
using api_baixo_acoplamento.Ioc;

[assembly: OwinStartup(typeof(api_baixo_acoplamento.Startup))]

namespace api_baixo_acoplamento
{
    public class Startup
    {
        
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            //Container de inversão de controller
            var container = new Container();

            //Configura a inversão de controller;
            ConfigureDependencyInjetion(config, container);
            ConfigureWebApi(config);
            ConfigureOAuth(app, container);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
            
        }

        private void ConfigureOAuth(IAppBuilder app, Container container)
        {
            var oAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(30),
                Provider = new AuthorizationApi(container)           
            };

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        private void ConfigureWebApi(HttpConfiguration config)
        {
            //config.MessageHandlers.Add(new LogApiHandler());

            //Remover suporte ao XML
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            var jsonSettings = config.Formatters.JsonFormatter.SerializerSettings;

            jsonSettings.Formatting = Formatting.Indented;
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;

            //ignora possivel loop de objetos (quando um objeto interno aponta para o objeto origem)
            jsonSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            config.MapHttpAttributeRoutes();
        }

        private void ConfigureDependencyInjetion(HttpConfiguration config, Container container)
        {
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            BootStrapper.RegisterWebApi(container);
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);       

        }
    }
}