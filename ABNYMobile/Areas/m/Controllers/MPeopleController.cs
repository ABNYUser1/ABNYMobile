using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABNYMobile.Controllers;

namespace ABNYMobile.Areas.m.Controllers
{
    public class MPeopleController : Controller
    {
        //
        // GET: /m/MPeople/

        public ActionResult Index()
        {
            var repo = this.GetRepoFromSession();
            var people = repo.GetPeople();

            return View(people);
        }

        public ActionResult Edit(int id)
        {
            var repo = this.GetRepoFromSession();
            var item = repo.GetPeople().Single(q => q.Id == id);
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
