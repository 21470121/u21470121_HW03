using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace HW3_U21470121.Controllers
{
    public class HomeController : Controller

    {


        string Selected;
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        //Single File Upload
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files) //INSIDE HOME
        {
            List<Models.FileModel> file = new List<Models.FileModel>();
            
            if (files != null && files.ContentLength > 0)
            {
                

                var fileName = Path.GetFileName(files.FileName);
                var path="";
                Selected = Request["FileType"].ToString(); //get the name of radio button
                if (Selected != "") //ensure doesn't run while empty
                {
                    if (Selected == "Document")
                    {
                        path = Path.Combine(Server.MapPath("~/Media/Documents"), fileName); //saves in relevant folder.
                    } else if(Selected == "Image")
                    {
                        path = Path.Combine(Server.MapPath("~/Media/Images"), fileName);
                    } else
                    {
                        path = Path.Combine(Server.MapPath("~/Media/Videos"), fileName);
                    }
                    file.Add(new Models.FileModel { FileName = fileName, FileType = Selected});
                }
               

                files.SaveAs(path);
            }

            return RedirectToAction("Index");
         
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}


        //public string IndexForm(FormCollection frm) [DIDN"T WORK]
        //  {
        //      Selected = frm["FileTYpe"].ToString();
        //      return 
        //  }
    }
}