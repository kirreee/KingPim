﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kingpim.DAL.Models
{
   public class File
    {
        public int Id { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsPublish { get; set; }
        public bool IsMainFile { get; set; }
    }
}
