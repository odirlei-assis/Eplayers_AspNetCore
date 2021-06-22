using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Eplayers_AspNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Players_AspNETCore.Controllers
{
    [Route("Jogador")]
    public class JogadorController : Controller
    {

        Jogador jogadorModel = new Jogador();
        Equipe equipeModel = new Equipe();

        public IActionResult Index()
        {
            ViewBag.Jogadores = jogadorModel.LerTodos();
            ViewBag.Equipes = equipeModel.LerTodos();
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Jogador novoJogador     = new Jogador();
            novoJogador.IdJogador   = Int32.Parse(form["IdJogador"]);
            novoJogador.IdEquipe    = Int32.Parse(form["IdEquipe"]);
            novoJogador.Nome        = form["Nome"];
            novoJogador.Email       = form["Email"];
            novoJogador.Senha       = form["Senha"];

            jogadorModel.Criar(novoJogador);            
            ViewBag.Jogadores = jogadorModel.LerTodos();

            return LocalRedirect("~/Jogador");
        }

    }
}