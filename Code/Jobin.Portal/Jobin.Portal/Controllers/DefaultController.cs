using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jobin.Model;

namespace Jobin.Portal.Controllers
{
    public class DefaultController : Controller
    {
        //
        // GET: /Default/

        public ActionResult Index()
        {
            //OportunidadesCollection op = Oportunidades.FactoryInstance.GetByCategorias(1);
            return View();
        }

        //
        // GET: /Default/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
