using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABNYMobile.Controllers;

namespace ABNYMobile.Areas.m.Controllers
{
    public class MMembersController : Controller
    {
        //
        // GET: /m/MMembers/

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
        public ActionResult Edit(int id, FormCollection collection)
        {
            var repo = this.GetRepoFromSession();
            var member = repo.GetMember(id);

            member.AnnualDuesAmount = Convert.ToDouble(collection["AnnualDuesAmount"]);
            member.CompanyName = collection["CompanyName"];
            member.IsGovernmentAgency = Convert.ToBoolean(collection["IsGovernmentAgency"].Replace("true,false", "true"));
            member.IsIndividual = Convert.ToBoolean(collection["IsIndividual"].Replace("true,false", "true"));
            //member.LastPaid = collection["LastPaid"];
            //member.MemberSince = collection["MemberSince"];
            member.OutstandingBalance = Convert.ToDouble(collection["OutstandingBalance"]);
            member.PrimaryContact = collection["PrimaryContact"];
            member.PrimaryPhone = collection["PrimaryPhone"];
            member.Tags = collection["Tags"];

            return RedirectToAction("Index");
        }

    }
}
