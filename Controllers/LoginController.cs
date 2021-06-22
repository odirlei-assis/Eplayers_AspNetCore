using System.Collections.Generic;
using Eplayers_AspNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eplayers_AspNetCore.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        [TempData]
        public string Mensagem { get; set; }

        Jogador jogadorModel = new Jogador();
        public IActionResult Index()
        {
            return View();
        }

        [Route("Logar")]
        public IActionResult Logar(IFormCollection form)
        {

            List<string> jogadores = jogadorModel.LerTodasLinhasCSV("Database/jogador.csv");
            var logado = jogadores.Find(
                                    x =>
                                    x.Split(";")[2] == form["Email"] &&
                                    x.Split(";")[3] == form["Senha"]);

            // Redirecionamos o usuário logado caso encontrado
            if (logado != null)
            {
                //Salvar a informação do nome na sessão
                HttpContext.Session.SetString("_UserName", logado.Split(";")[1]);

                return LocalRedirect("~/");
            }

            Mensagem = "Dados incorretos, tente novamente...";
            return LocalRedirect("~/Login");
        }

        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("_UserName");
            return LocalRedirect("~/");
        }
    }
}