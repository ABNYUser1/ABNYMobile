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
        public ActionResult Edit(int id, FormCollection collection)
        {
            var repo = this.GetRepoFromSession();
            var person = repo.GetMember(id);

            person.AnnualDuesAmount = Convert.ToDouble(collection["AnnualDuesAmount"]);
            person.CompanyName = collection["CompanyName"];
            person.IsGovernmentAgency = Convert.ToBoolean(collection["IsGovernmentAgency"].Replace("true,false", "true"));
            person.IsIndividual = Convert.ToBoolean(collection["IsIndividual"].Replace("true,false", "true"));
            //person.LastPaid = collection["LastPaid"];
            //person.MemberSince = collection["MemberSince"];
            person.OutstandingBalance = Convert.ToDouble(collection["OutstandingBalance"]);
            person.PrimaryContact = collection["PrimaryContact"];
            person.PrimaryPhone = collection["PrimaryPhone"];
            person.Tags = collection["Tags"];

            return RedirectToAction("Index");
        }
    }
}
