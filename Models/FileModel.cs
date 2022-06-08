using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

using System.ComponentModel.DataAnnotations; //

namespace HW3_U21470121.Models
{
    public class FileModel
    {
        [Display(Name = "File Name")]
        public string FileName { get; set; }

        //[Required(ErrorMessage = "Please select file.")]
        //[Display(Name = "Browse File")]
        public HttpPostedFileBase[] Files { get; set; }

        public string FileType { get; set; }
    }
}