using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeetingOrganizer.Models;
using MeetingOrganizer.ViewModel;

namespace MeetingOrganizer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ToplantiClient tc = new ToplantiClient();
            ViewBag.listToplanti = tc.findAll();

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(ToplantiViewModel tvm)
        {
            ToplantiClient tc = new ToplantiClient();
            tc.Create(tvm.toplanti);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ToplantiClient tc = new ToplantiClient();
            ToplantiViewModel tvm = new ToplantiViewModel();
            tvm.toplanti = tc.find(id);
            return View("Edit", tvm);
        }

        [HttpPost]
        public ActionResult Edit(ToplantiViewModel tvm)
        {
            ToplantiClient tc = new ToplantiClient();
            tc.Edit(tvm.toplanti);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            ToplantiClient tc = new ToplantiClient();
            tc.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
