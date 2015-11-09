using System;
using System.Web.Mvc;
using System.Collections.Generic;

namespace restBing.Controllers
{

    public class HomeController : Controller
    {
        regVersion registryV = new regVersion();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Versions from Registry:";
            ViewData["vers"] = registryV.GetVersionFromRegistry();
            var verList = ViewData["vers"];
            Console.WriteLine(verList.ToString());
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult startPing(string ipAddr)
        {
            pingObj po = new pingObj();
            ViewData["hostType"] = Uri.CheckHostName(ipAddr);
            po.send(ipAddr);
            ViewData["pingDest"] = ipAddr; 
            ViewData["ping"] = po.reply;
            return View();
        }

        public ActionResult stockQuote(string ticker)
        {
            yahooQuote yq = new yahooQuote(ticker);
            string resp = yq.sendGet();
            ViewData["ticker"] = yq.ticker;
            ViewData["Price"] = resp;
            return View();
        }
    }
}