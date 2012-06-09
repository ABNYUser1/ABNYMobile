using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABNYMobile.Controllers
{
    public class MembersController : Controller
    {
        //
        // GET: /Members/

        public ActionResult Index()
        {
            var repo = this.GetRepoFromSession();
            var members = repo.GetMembers();
            return View(members);
        }

        public ActionResult Edit(int id)
        {
            var repo = this.GetRepoFromSession();
            var item = repo.GetMembers().Single(q => q.Id == id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            return RedirectToAction("Index");
        }
    }
}
