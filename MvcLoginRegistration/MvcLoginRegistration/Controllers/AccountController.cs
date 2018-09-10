using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcLoginRegistration.Models;

namespace MvcLoginRegistration.Controllers
{
    public class AccountController : Controller
    {
        OurDbContext db = new OurDbContext();
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
            if (ModelState.IsValid)
            {
                using (OurDbContext db = new OurDbContext())
                {
                    db.UserAccount.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.FirstName + " " + account.LastName + " " + account.Email + "" + account.Username + "" + account.Password + "" + account.ConfirmPassword + "" + account.Role + "" + account.UserID + "" + "successfully registered.";

            }
            return View("Login");

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
                var user = db.UserAccount.Where(u => u.Username == account.Username && u.Password == account.Password).FirstOrDefault();

                if (user != null)
                {

                    if (user.Role == "Admin")
                        return RedirectToAction("Index", "Admin");
                    else if (user.Role == "Student")
                        return RedirectToAction("Profile","Student");
                    else if (user.Role == "Teacher")
                        return RedirectToAction("Teacher");

                    //Session["UserID"] = account.UserID.ToString();
                    //Session["Username"] = account.Username.ToString();

                    //return RedirectToAction("LoggedIn");

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
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        //public ActionResult Student()
        //{

        //    return View();

        //}
        public ActionResult Teacher()
        {
            using (OurDbContext db = new OurDbContext())
            {
                var returnedResult = db.UserAccount.Where(x => x.Role == "Student").ToList();
                return View(returnedResult);
            }

        }


    }
}