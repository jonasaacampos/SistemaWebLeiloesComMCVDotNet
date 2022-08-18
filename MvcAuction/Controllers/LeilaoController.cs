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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Leilao()
        {

            var leilao = new MvcAuction.Models.Leilao()
            {
                NomeLeilao = "Leilão Beneficente RFB",
                Descricao = "Leilão com produtos apreendidos",
                TimeStarts = DateTime.Now,
                TimeEnds = DateTime.Now.AddDays(7),
                PrecoInicial = 1.00m,
                PrecoAtual = null
            };

            ViewData["Leilao"] = leilao;

            return View();
        }


    }
}
