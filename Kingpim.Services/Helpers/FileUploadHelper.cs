using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Kingpim.Services.Helpers
{
    public class FileUploadHelper
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public FileUploadHelper(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public void SaveFileInFolder(IFormFile file)
        {

            string folderPath = "/FileUploads/";
            string savePath = _hostingEnvironment.WebRootPath + "/" + folderPath;
            string fullpath = Path.Combine(savePath, file.FileName);

            try
            {
                using (var fileStream = new FileStream(fullpath, FileMode.Create))
                {
                    file.CopyToAsync(fileStream);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
