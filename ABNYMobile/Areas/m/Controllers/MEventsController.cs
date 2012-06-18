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

        public ActionResult Checkoff(int id)
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

        [HttpPost]
        public ActionResult Checkoff(int id, FormCollection collection)
        {
            var repo = this.GetRepoFromSession();
            foreach (var key in collection.AllKeys)
            {
                var value = collection[key];
                if (value == "on")
                    repo.GetEvent(id).Attendees.Find(q => q.Id.ToString() == key).IsHere = true;
                else
                    repo.GetEvent(id).Attendees.Find(q => q.Id.ToString() == key).IsHere = false;
            }
            return RedirectToAction("Index");
        }
    }
}
