using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(IdentityBothMVCAndWebApi.Startup))]

namespace IdentityBothMVCAndWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            GlobalFilters.Filters.Add(new System.Web.Http.AuthorizeAttribute());
            GlobalFilters.Filters.Add(new System.Web.Mvc.AuthorizeAttribute());
            CookieAuthenticationOptions options = new CookieAuthenticationOptions();
            options.AuthenticationType = "ApplicationCookie";
            options.LoginPath = new PathString("/Authentication/Login");
            app.UseCookieAuthentication(options);
        }
    }
}
