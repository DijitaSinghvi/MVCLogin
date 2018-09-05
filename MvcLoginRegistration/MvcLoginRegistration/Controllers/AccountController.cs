﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLoginRegistration.Models;

namespace MvcLoginRegistration.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (OurDbContext db = new OurDbContext())
            {
                return View(db.UserAccount.ToList());
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if(ModelState.IsValid)
            {
                using (OurDbContext db = new OurDbContext())
                {
                    db.UserAccount.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.FirstName + " " + account.LastName + "successfully registered.";
            }
            return View();

        }
        //Login
        public ActionResult Login()
        {
            return View();
        
        }
        [HttpPost]
        public ActionResult Login(UserAccount account)
        {
            using (OurDbContext db = new OurDbContext())
            {
                var usr = db.UserAccount.Where(u => u.Username == account.Username && u.Password == account.Password);
                if (usr != null)
                {
                    Session["UserID"] = account.UserID.ToString();
                    Session["Username"] =account.Username.ToString();
                    return RedirectToAction("LoggedIn");

                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong.");
                }
            }
            return View();
        }
        public ActionResult LoggedIn()
        {
            if (Session["UserID"]!=null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Student()
        {
            return View();
        }
    }
}