using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace HW3_U21470121.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index()
        {
           // string[] filePaths = Directory.GetFiles(Server.MapPath("~/App_Data/Documents"));
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Media/Documents")); //gets all files 
            List<Models.FileModel> files = new List<Models.FileModel>();
            foreach (string filePath in filePaths)
            {
                files.Add(new Models.FileModel { FileName = Path.GetFileName(filePath) });

            }


                return View(files);
        }

        public FileResult DownloadFile(string filename)
        {
            
            string path = Server.MapPath("~/Media/Documents/")  + filename;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", filename);
        }

        public ActionResult DeleteFile(string filename) 
        {
            string path = Server.MapPath("~/Media/Documents/") + filename;
           
            System.IO.File.Delete(path);

            return RedirectToAction("Index", "Image");

        }
    }
}