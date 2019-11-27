using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace RateYourIdea.Core.FileBusiness
{
    public class FileBusiness
    {
        public List<string> UploadBulkFile(HttpFileCollectionBase files)
        {
            if (files.Count <= 0)
            {
                return null;
            }
            try
            {
                List<string> pathList = new List<string>();
                for (int i = 0; i < files.Count; i++)
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory + "Image/";
                    //string filename = Path.GetFileName(Request.Files[i].FileName);  

                    HttpPostedFileBase file = files[i];

                    string documentSuffix = file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                    string guidname = Guid.NewGuid().ToString() + "." + documentSuffix;

                    // Get the complete folder path and store the file inside it.  
                    string fname = Path.Combine(path, guidname);
                    file.SaveAs(fname);
                    pathList.Add("/Image/" + guidname);
                }
                // Returns message that successfully uploaded  
                return pathList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string UploadSingleFile(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return null;
            }
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "Image/";
                //string filename = Path.GetFileName(Request.Files[i].FileName);

                string documentSuffix = file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                string guidname = Guid.NewGuid().ToString() + "." + documentSuffix;

                // Get the complete folder path and store the file inside it.  
                string fname = Path.Combine(path, guidname);
                file.SaveAs(fname);

                return "/Image/" + guidname;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool DeleteFile(string imagePath)
        {
            try
            {
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + imagePath);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
