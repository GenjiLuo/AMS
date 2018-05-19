using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace 汽车维修管理系统.Areas.CustomerRelation.Controllers
{
    public class UploadController : Controller
    {
        [DataContract]
        public class ChunkMetaData
        {
            [DataMember(Name = "uploadUid")]
            public string UploadUid { get; set; }
            [DataMember(Name = "fileName")]
            public string FileName { get; set; }
            [DataMember(Name = "contentType")]
            public string ContentType { get; set; }
            [DataMember(Name = "chunkIndex")]
            public long ChunkIndex { get; set; }
            [DataMember(Name = "totalChunks")]
            public long TotalChunks { get; set; }
            [DataMember(Name = "totalFileSize")]
            public long TotalFileSize { get; set; }
        }

        public class FileResult
        {
            public bool uploaded { get; set; }
            public string fileUid { get; set; }
        }

        [HttpPost]
        public ActionResult Submit(IEnumerable<HttpPostedFileBase> files)
        {
            if (files != null)
            {
                TempData["UploadedFiles"] = GetFileInfo(files);
            }

            return RedirectToRoute("Demo", new { section = "upload", example = "result" });
        }

        public ActionResult Save(IEnumerable<HttpPostedFileBase> files,string uid)
        {
            // The Name of the Upload component is "files"
            if (files != null)
            {
                foreach (var file in files)
                {
                    // Some browsers send file names with full path. This needs to be stripped.
                    var fileName = Path.GetFileName(file.FileName);
                    var physicalPath = Path.Combine(Server.MapPath("~/CustomerData/CarImgs"), uid + fileName);

                    // The files are not actually saved in this demo
                    file.SaveAs(physicalPath);
                }
            }

            // Return an empty string to signify success
            return Content("");
        }

        public ActionResult Remove(string[] fileNames,string uid)
        {
            // The parameter of the Remove action must be called "fileNames"

            if (fileNames != null)
            {
                foreach (var fullName in fileNames)
                {
                    var fileName = Path.GetFileName(fullName);
                    var physicalPath = Path.Combine(Server.MapPath("~/CustomerData"), uid + fileName);

                    // TODO: Verify user permissions

                    if (System.IO.File.Exists(physicalPath))
                    {
                        // The files are not actually removed in this demo
                        System.IO.File.Delete(physicalPath);
                    }
                }
            }

            // Return an empty string to signify success
            return Content("");
        }

        public void AppendToFile(string fullPath, Stream content)
        {
            try
            {
                using (FileStream stream = new FileStream(fullPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {
                    using (content)
                    {
                        content.CopyTo(stream);
                    }
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }
        }

        public ActionResult ChunkSave(IEnumerable<HttpPostedFileBase> files, string metaData)
        {
            if (metaData == null)
            {
                return Save(files,"");
            }

            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(metaData));
            var serializer = new DataContractJsonSerializer(typeof(ChunkMetaData));
            ChunkMetaData somemetaData = serializer.ReadObject(ms) as ChunkMetaData;
            string path = String.Empty;
            // The Name of the Upload component is "files"
            if (files != null)
            {
                foreach (var file in files)
                {
                    //path = Path.Combine(Server.MapPath("~/App_Data"), somemetaData.FileName);

                    //AppendToFile(path, file.InputStream);
                }
            }

            FileResult fileBlob = new FileResult();
            fileBlob.uploaded = somemetaData.TotalChunks - 1 <= somemetaData.ChunkIndex;
            fileBlob.fileUid = somemetaData.UploadUid;

            return Json(fileBlob);
        }

        private IEnumerable<string> GetFileInfo(IEnumerable<HttpPostedFileBase> files)
        {
            return
                from a in files
                where a != null
                select string.Format("{0} ({1} bytes)", Path.GetFileName(a.FileName), a.ContentLength);
        }
    }
}