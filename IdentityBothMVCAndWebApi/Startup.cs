using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(IdentityBothMVCAndWebApi.Startup))]

namespace IdentityBothMVCAndWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            GlobalFilters.Filters.Add(new AuthorizeAttribute());
            CookieAuthenticationOptions options = new CookieAuthenticationOptions()
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Authentication/Login"),
                Provider=new CookieAuthenticationProvider
                {
                    OnApplyRedirect= ctx => {
                        if (!IsAjaxRequest(ctx.Request)) {
                            ctx.Response.Redirect(ctx.RedirectUri);
                        }
                    }
                }
            };
            app.UseCookieAuthentication(options);
        }

        private static bool IsAjaxRequest(IOwinRequest request)
        {
            IReadableStringCollection query= request.Query;
            if ((query != null) && (query["X-Requested-With"] == "XMLHttpRequest"))
            {
                return true;
            }
            IHeaderDictionary headers = request.Headers;
            return ((headers != null) && (headers["X-Requested-With"] == "XMLHttpRequest"));
        }
    }
}
