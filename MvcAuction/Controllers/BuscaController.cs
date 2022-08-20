using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MvcAuction.Controllers
{
    public class BuscaController : AsyncController
    {
        public async Task<ActionResult> Leilao(string keyword)
        {
            var leilao = await Task.Run<IEnumerable<Models.Leilao>>(
                () =>
                {
                    var database = new Models.LeiloesDataContext();
                    return database.Leiloes.Where(x => x.NomeLeilao.Contains(keyword)).ToArray();
                });

            return Json(leilao, JsonRequestBehavior.AllowGet);
        }

    }
}
