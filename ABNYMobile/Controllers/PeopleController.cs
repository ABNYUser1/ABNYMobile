using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABNYMobile.Models;

namespace ABNYMobile.Controllers
{
    public class PeopleController : Controller
    {
        //
        // GET: /People/

        public ActionResult Index()
        {
            var repo = Session["repo"] as MockRepository;
            Debug.Assert(repo != null);
            var people = repo.GetPeople();

            return View(people);
        }

        public ActionResult Edit(int id)
        {
            var repo = Session["repo"] as MockRepository;
            Debug.Assert(repo != null);
            var item = repo.GetPeople().Single(q => q.Id == id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            var repo = Session["repo"] as MockRepository;
            // TODO: Save Data
            return RedirectToAction("Index");
        }
    }
}
