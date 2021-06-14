using System;
using Eplayers_AspNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eplayers_AspNetCore.Controllers
{
    [Route("Equipe")]
    public class EquipeController : Controller
    {
        Equipe equipeModel = new Equipe();

        [Route("Listar")]
        public IActionResult Index(){

            ViewBag.Equipes = equipeModel.LerTodos();
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form){

            Equipe novaEquipe = new Equipe();
            novaEquipe.IdEquipe = Int32.Parse(form["idEquipe"]);
            novaEquipe.Nome = form["Nome"];
            novaEquipe.Imagem = form["Imagem"];

            equipeModel.Cadastrar(novaEquipe);
            ViewBag.Equipes = equipeModel.LerTodos();

            return LocalRedirect("~/Equipe/Listar");
        }
    }
}