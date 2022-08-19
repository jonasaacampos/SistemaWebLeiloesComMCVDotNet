using MvcAuction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAuction.Controllers
{
    public class LeilaoController : Controller
    {
        //
        // GET: /Leilao/

        //lista com todos os leiões ativos
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
