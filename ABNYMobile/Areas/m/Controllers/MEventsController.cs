using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABNYMobile.Controllers;

namespace ABNYMobile.Areas.m.Controllers
{
    public class MEventsController : Controller
    {
        //
        // GET: /m/MEvents/

        public ActionResult Index()
        {
            var repo = this.GetRepoFromSession();
            var events = repo.GetEvents();

            return View(events);
        }

        public ActionResult Edit(int id)
        {
            var repo = this.GetRepoFromSession();
            var item = repo.GetEvents().Single(q => q.Id == id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            var repo = this.GetRepoFromSession();
            // TODO: Save Data
            return RedirectToAction("Index");
        }

    }
}
