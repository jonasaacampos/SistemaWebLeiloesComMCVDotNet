using MvcAuction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MvcAuction.Controllers
{
    public class LeilaoController : Controller
    {
        //
        // GET: /Leilao/



        //lista com todos os leiões ativos
        [AllowAnonymous]
        [OutputCache(Duration = 1)]
        public ActionResult Index()
        {
            var dataBase = new LeiloesDataContext();
            var leiloes = dataBase.Leiloes.ToArray();

            return View(leiloes);
        }


        public ActionResult TempDataDemo()
        {
            TempData["SuccessMessage"] = "Yeah! Tudo certo por aqui...";

            return RedirectToAction("Index");
        }


        
        public ActionResult Leilao(long id)
        {
            var dataBase = new LeiloesDataContext();
            var leilao = dataBase.Leiloes.Find(id);

            return View(leilao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(Duration = 5)]
        public ActionResult Lance(Lance lance)
        {
            var dataBase = new LeiloesDataContext();
            var leilao = dataBase.Leiloes.Find(lance.LeilaoId);

            if (leilao == null)
            {
                ModelState.AddModelError("LeilaoId", "Leilão não disponível ou inexistente");
            }
            else if (leilao.PrecoAtual >= lance.Valor)
            {
                ModelState.AddModelError("Valor", "Valor da oferta deve ser maior que valor atual");
            }
            else
            {
                lance.UsuarioNome = User.Identity.Name;
                leilao.Lances.Add(lance);
                leilao.PrecoAtual = lance.Valor;
                dataBase.SaveChanges();
            }

            if (!Request.IsAjaxRequest())
                return RedirectToAction("Leilao", new { id = lance.LeilaoId });

            return Json(new {
                PrecoAtual = lance.Valor.ToString("C"), 
                LanceContador = leilao.LanceContador
            });



        }


        [HttpGet]
        public ActionResult NovoLeilao()
        {
            var categoriasLista =
                new SelectList(
                    new[] { "Eletrônicos diversos", "Vestuário", "Celulares" });
            ViewBag.CategoriasLista = categoriasLista;
            return View();

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult NovoLeilao([Bind(Exclude = "PrecoAtual")]Models.Leilao leilao)
        {



            if (ModelState.IsValid)
            {
                var dataBase = new LeiloesDataContext();
                dataBase.Leiloes.Add(leilao);
                dataBase.SaveChanges();

                return RedirectToAction("Index");
            }

            return NovoLeilao();

        }


    }
}
