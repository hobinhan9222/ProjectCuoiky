﻿using ProjectCuoiky.Services;
using ProjectCuoiky.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace ProjectCuoiky.Controllers
{
    public class ThaoTacController: Controller
    {
        private ThaoTacDichVu1 _service = null;
        public ThaoTacController(ThaoTacDichVu1 service)
        {
            _service = service;
        }
        // GET: Security
        public ActionResult Logon()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Logon(LogonViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_service.IsValidUser(model))
                {
                    this.Session.Add("Username", model.Username);
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    return RedirectToAction("HomePage", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // _service.SaveUserToDB(model);
                model.Message = "User registerd sucessfully.";
                return View(model);
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            this.Session.Clear();
            return RedirectToAction("Logon");
        }
    }
}