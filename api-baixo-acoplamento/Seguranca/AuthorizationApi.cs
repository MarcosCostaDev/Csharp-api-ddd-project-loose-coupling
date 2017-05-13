using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using SimpleInjector;
using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace api_baixo_acoplamento.Seguranca
{
    public class AuthorizationApi : OAuthAuthorizationServerProvider
    {

        private readonly Container _container;

        public AuthorizationApi(Container container)
        {
            this._container = container;
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return base.ValidateClientAuthentication(context);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            try
            {
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

                
                if(context.UserName == "Marcos" && context.Password == "123")
                {
                    var usuarioLogado = new { Id = 1, Nome = "Marcos", Funcao = "Desenvolvedor" };

                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                    identity.AddClaim(new Claim(usuarioLogado.Funcao, JsonConvert.SerializeObject(usuarioLogado)));

                    var principal = new GenericPrincipal(identity, new string[] { });

                    Thread.CurrentPrincipal = principal;
                    context.Validated(identity);
                }
                else
                {
                    throw new Exception("Dados invalidos");
                }

                
            }
            catch (Exception ex)
            {
                context.SetError("Invalid_grant", ex.Message);
                //  return;
            }

            return base.GrantResourceOwnerCredentials(context);
        }

    }
}