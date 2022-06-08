using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace HW3_U21470121.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult Index()
        {

            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Media/Images")); //gets all images
            List<Models.FileModel> images = new List<Models.FileModel>();
            foreach (string filePath in filePaths)
            {
                images.Add(new Models.FileModel { FileName = Path.GetFileName(filePath) });

            }

            return View(images);
          
        }

        public FileResult DownloadFile(string filename)
        {

            string path = Server.MapPath("~/Media/Images/") + filename;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", filename);
        }

        public ActionResult DeleteFile(string filename)
        {
            string path = Server.MapPath("~/Media/Images/") + filename;

            System.IO.File.Delete(path);

            return RedirectToAction("Index", "Image");

        }

    }
}