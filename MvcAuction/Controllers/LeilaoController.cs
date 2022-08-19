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

            var leilao = new[] {
                new Models.Leilao()

            {
                NomeLeilao = "Leilão Beneficente RFB #001",
                Descricao = "Leilão com produtos apreendidos",
                TimeStarts = DateTime.Now,
                TimeEnds = DateTime.Now.AddDays(7),
                PrecoInicial = 1.00m,
                PrecoAtual = null,
            },

            new Models.Leilao()
            {
                NomeLeilao = "Leilão Beneficente RFB #002",
                Descricao = "Leilão com produtos apreendidos",
                TimeStarts = DateTime.Now,
                TimeEnds = DateTime.Now.AddDays(7),
                PrecoInicial = 1.00m,
                PrecoAtual = 33m,
            },
          };


            return View(leilao);

        }

        public ActionResult TempDataDemo()
        {
            TempData["SuccessMessage"] = "Yeah! Tudo certo por aqui...";

            return RedirectToAction("Index");
        }


        public ActionResult Leilao(long id)
        {

            var leilao = new MvcAuction.Models.Leilao()
            {
                NomeLeilao = "Leilão Beneficente RFB #001",
                Descricao = "Leilão com produtos apreendidos",
                TimeStarts = DateTime.Now,
                TimeEnds = DateTime.Now.AddDays(7),
                PrecoInicial = 1.00m,
                PrecoAtual = null
            };


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
                //save
                return RedirectToAction("Index");
            }

            return NovoLeilao();

        }


    }
}
