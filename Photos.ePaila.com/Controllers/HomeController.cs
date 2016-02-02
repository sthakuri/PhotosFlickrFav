using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Photos.ePaila.com.Models;
using Photos.ePaila.com.Models.Channel;

namespace Photos.ePaila.com.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewModel model = new ViewModel();
            model.AddChannel(new Flickr());
            return View(model);
        }

    }
}
