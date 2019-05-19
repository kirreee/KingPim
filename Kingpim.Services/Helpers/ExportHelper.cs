using Kingpim.DAL.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Kingpim.Services.Helpers
{
    public class ExportHelper
    {
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ExportHelper(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        public string ExportDataJson(Catalog catalog, Category category, Subcategory subcategory)
        {

            var filePath = _configuration.GetSection("FilesFolderPath")["Folder"];
            string folderPath = "/FileUploads/";
            string savePath = _hostingEnvironment.WebRootPath + "/" + folderPath;
            string fileName = "KingpimData-" + Guid.NewGuid() + ".json";
            string fullpath = Path.Combine(savePath, fileName);

            var result = "";

            if (catalog != null)
            {
                try
                {
                    result = JsonConvert.SerializeObject(catalog, Formatting.None,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                }
                catch (Exception ex)
                {

                }

            }
            else if (category != null)
            {
                try
                {
                    result = JsonConvert.SerializeObject(category, Formatting.None,
                   new JsonSerializerSettings()
                   {
                       ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                   });
                }
                catch (Exception ex)
                {

                }

            }
            else if (subcategory != null)
            {
                try
                {
                    result = JsonConvert.SerializeObject(subcategory, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
                }
                catch (Exception ex)
                {

                }
            }

            try
            {
                System.IO.File.WriteAllText(fullpath, result);
            }
            catch (Exception ex)
            {

            }

            return fileName;
        }
    }
}
