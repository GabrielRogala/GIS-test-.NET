using GIS_test1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GIS_test1.Controllers
{
    public class PhotosController : Controller
    {
        const string dataPath = "~/App_Data/";

        public ActionResult Index() {
            return View();
        }

        public ActionResult GetDir()
        {
            ViewBag.Dirs = Finder.FindDirs(Server.MapPath(dataPath));
            return View();
            //return Json(Finder.Find(Server.MapPath(dataPath)), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetFiles(string id)
        {
            ViewBag.Files = Finder.FindFiles(Server.MapPath(dataPath + id));
            ViewBag.Dir = id;
            return View();
            //return Json(Finder.Find(Server.MapPath(dataPath + id)), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(string id,string file)
        {
            ViewBag.Mess = Deleter.Delete(Server.MapPath(dataPath + id), file);
            return View();
            //return Json(Deleter.Delete(Server.MapPath(dataPath + id), file), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file, string name, string dir)
        {
            string mess = "";

            if (!Directory.Exists(Server.MapPath(dataPath + dir))){
                Directory.CreateDirectory(Server.MapPath(dataPath + dir));
            }

            var path = Path.Combine(Server.MapPath(dataPath + dir), name + Path.GetExtension(file.FileName));

            if (!System.IO.File.Exists(path)){
                if (file != null && file.ContentLength > 0){
                    file.SaveAs(path);
                }
                mess = "Plik dodano do katalogu";
            }else{
                mess = "Plik o takiej nazwie już istnieje";
            }

            ViewBag.Mess = mess;
            return View();
        }
	}
}