using IdentityBothMVCAndWebApi.Models;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web;

namespace IdentityBothMVCAndWebApi.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginVM());
        }
        [HttpPost]
        public ActionResult Login(LoginVM login,string ReturnUrl="")
        {
            if (ModelState.IsValid)
            {
                if (login.UserName == "Shahid" && login.Password == "Shahid1")
                {
                    IOwinContext context = Request.GetOwinContext();
                    IAuthenticationManager manager = context.Authentication;
                    List<Claim> claims = new List<Claim>();

                    claims.Add(new Claim(ClaimTypes.Name, login.UserName));
                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));

                    ClaimsIdentity identities = new ClaimsIdentity(claims, "ApplicationCookie");
                    manager.SignIn(identities: identities);
                }
                return RedirectToAction("Index", "Home"); //ReturnUrl == "" ? RedirectToAction("Index", "Home") : RedirectToRoute(ReturnUrl);
            }
            return View(login);
        }
        public ActionResult Logout()
        {
            IOwinContext context = Request.GetOwinContext();
            IAuthenticationManager manager = context.Authentication;
            manager.SignOut( "ApplicationCookie");
            return Redirect("/");
        }
    }
}