using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Uppgift4.Models.ChannelOperations;

namespace Uppgift4.Controllers
{
    public class ChannelController : Controller
    {
        private ChannelOperations co = new ChannelOperations();

        // GET: Channel
        public ActionResult Index()
        {
            return View(co.GetChannels());
        }
    }
}