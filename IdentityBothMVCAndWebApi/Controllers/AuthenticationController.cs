using IdentityBothMVCAndWebApi.Models;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Mvc;

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
        public ActionResult Login(LoginVM login)
        {
            if (ModelState.IsValid)
            {
                if (login.UserName == "Shahid" && login.Password == "Shahid1")
                {
                    IOwinContext context = Request.GetOwinContext();
                    IAuthenticationManager manager = context.Authentication;
                    List<Claim> claims = new List<Claim>();
                    //manager.SignIn()
                }
                return RedirectToAction("Index", "Home");
            }
            return View(login);
        }
    }
}