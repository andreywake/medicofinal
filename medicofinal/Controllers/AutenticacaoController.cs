using medicofinal.DAO;
using medicofinal.Models;
using medicofinal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using medicofinal.Utils;

namespace medicofinal.Controllers
{
    public class AutenticacaoController : Controller
    {

        private EFContext db = new EFContext();
        // GET: Autenticacao
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(CadastroUsuarioViewModels viewmodel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewmodel);
            }
            if (db.Usuarios.Count(u => u.Login == viewmodel.Login) > 0)
            {
                ModelState.AddModelError("Login", "Este usuário já está em uso");
                return View(viewmodel);
            }
            Usuario novoUsuario = new Usuario
            {
                Nome = viewmodel.Nome,
                Login = viewmodel.Login,
                Senha = Hash.gerarHash(viewmodel.Senha)

            };
            db.Usuarios.Add(novoUsuario);
            db.SaveChanges();
            TempData["Message"] = "Cadastro Realizado com Sucesso!";
            return View();
        }

        public ActionResult Login(String ReturnUrl)
        {
            var viewmodel = new LoginViewModels
            {
                UrlRetorno = ReturnUrl
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModels viewmodel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewmodel);
            }

            var usuario = db.Usuarios.FirstOrDefault(u => u.Login == viewmodel.Login);

            if (usuario == null)
            {
                ModelState.AddModelError("Login", "Login ou senha esta digitada corretamente!");
                return View(viewmodel);
            }

            if (usuario.Senha != Hash.gerarHash(viewmodel.Senha))
            {
                ModelState.AddModelError("Senha", "Login ou Senha Incorreta");
                return View(viewmodel);
            }

            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim("Login", usuario.Login)
            }, "ApplicationCookie");

            Request.GetOwinContext().Authentication.SignIn(identity);

            if (!String.IsNullOrWhiteSpace(viewmodel.UrlRetorno) || Url.IsLocalUrl(viewmodel.UrlRetorno))
            {
                return Redirect(viewmodel.UrlRetorno);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Home");
        }

    }
}