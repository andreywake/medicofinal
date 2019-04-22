using System;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(medicofinal.Startup))]

namespace medicofinal
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Autenticacao/Login")

            });
            AntiForgeryConfig.UniqueClaimTypeIdentifier = "Login";
            // Para obter mais informações sobre como configurar seu aplicativo, visite https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
