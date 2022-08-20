using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;


namespace MvcAuction.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {

        [OutputCache(Duration=3)] //TESTE - Alterar tempo para 3600 em produção
        public ActionResult Index()
        {
            ViewBag.Message = "Última atualização da página: " + DateTime.Now;

            return View();
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SwitchView(string returnUrl, bool mobile = false)
        {
            HttpContext.ClearOverriddenBrowser();
            HttpContext.SetOverriddenBrowser(
                mobile ? BrowserOverride.Mobile : BrowserOverride.Desktop);

            return Redirect(returnUrl);
        }



    }
}
