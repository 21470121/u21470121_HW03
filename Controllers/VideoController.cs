using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace HW3_U21470121.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult Index()
        {

            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Media/Videos")); //gets all images
            List<Models.FileModel> videos = new List<Models.FileModel>();
            foreach (string filePath in filePaths)
            {
                videos.Add(new Models.FileModel { FileName = Path.GetFileName(filePath) });

            }

            return View(videos);

        }

        public FileResult DownloadFile(string filename)
        {

            string path = Server.MapPath("~/Media/Videos/") + filename;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", filename);
        }

        public ActionResult DeleteFile(string filename)
        {
            string path = Server.MapPath("~/Media/Videos/") + filename;

            System.IO.File.Delete(path);

            return RedirectToAction("Index", "Video");

        }
    }
}