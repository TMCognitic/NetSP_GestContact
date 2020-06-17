using GestContact.Infrastructure;
using GestContact.Models.Client.Data;
using GestContact.Models.Client.Services;
using GestContact.Models.Forms;
using GestContact.Repositories;
using System;
using System.Linq;
using System.Web.Mvc;

namespace GestContact.Controllers
{
    public class AuthController : Controller
    {
        IAuthService<Utilisateur> _service;

        public AuthController()
        {
            _service = new AuthService();
        }

        // GET: Auth
        [AnonymousRequired]
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [AnonymousRequired]
        public ActionResult Login()
        {
            //Test
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [AnonymousRequired]
        public ActionResult Login(LoginForm loginForm)
        {
            string uri = "~/";

            if(!(HttpContext.Request.QueryString["url"] is null))
            {
                uri = HttpContext.Request.QueryString["url"];
            }


            if (ModelState.IsValid)
            {
                try
                {
                    Utilisateur utilisateur = _service.Login(loginForm.Email, loginForm.Passwd);

                    if (!(utilisateur is null))
                    {
                        SessionManager.User = utilisateur;
                        return Redirect(uri);
                    }

                    ViewBag.Error = "Email ou le mot de passe sont invalide!!";
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                }
            }

            return View(loginForm);
        }
        
        [AnonymousRequired]
        public ActionResult Register()
        {
            //Test

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AnonymousRequired]
        public ActionResult Register(RegisterForm registerForm)
        {
            //Test

            if(ModelState.IsValid)
            {                
                try
                {
                    Utilisateur u = new Utilisateur(registerForm.Nom, registerForm.Prenom, registerForm.Email, registerForm.Passwd);
                    _service.Register(u);
                    return RedirectToAction("Login");
                }
                catch (Exception ex)
                {
                    if(ex.Message.StartsWith("Violation of UNIQUE KEY constraint"))
                        ViewBag.Error = "L'email est déjà utilisée";
                }
            }

            return View(registerForm);
        }

        [AuthRequired]
        public ActionResult Logout()
        {
            SessionManager.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}