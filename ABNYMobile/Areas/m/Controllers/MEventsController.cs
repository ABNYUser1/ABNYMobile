﻿using System;
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

        public ActionResult Signin(int id)
        {
            var repo = this.GetRepoFromSession();
            var item = repo.GetEvents().Single(q => q.Id == id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var repo = this.GetRepoFromSession();
            var e = repo.GetEvent(id);

            e.Description = collection["Description"];
            //e.EventDate = collection["EventDate"];
            e.MaxCapacity = Convert.ToInt32(collection["MaxCapacity"]);
            e.Title = collection["Title"];

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Signin(int id, FormCollection collection)
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
