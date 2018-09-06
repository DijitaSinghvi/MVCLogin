
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MvcLoginRegistration.Models;
using Image = MvcLoginRegistration.Models.Image;

namespace MvcLoginRegistration.Controllers
{
    public class ImageController : Controller
    {
        [HttpGet]
        // GET: Image
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Image obj)
        {
            string fileName = Path.GetFileNameWithoutExtension(obj.ImageFile.FileName);
            string extension = Path.GetExtension(obj.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            obj.ImagePath = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            obj.ImageFile.SaveAs(fileName);
            using (DbRegisterEntities db = new DbRegisterEntities())
            {
                db.Images.Add(obj);
                db.SaveChanges();
            }
            ModelState.Clear();
            return RedirectToAction("View");
            //return View();
        }

        [HttpGet]
        public ActionResult View(int id)
        {
            Image obj = new Image();
            using (DbRegisterEntities db = new DbRegisterEntities())
            {
                obj = db.Images.Where(x => x.ImageId == id).FirstOrDefault();
            }
            return View(obj);
        }
    }
}