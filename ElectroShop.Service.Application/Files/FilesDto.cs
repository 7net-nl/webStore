using ElectroShop.Service.Application.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectroShop.Service.Application.Files
{
      public class FilesDto
    {
        public long ID { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string Path { get; set; }

        public int Product_ID { get; set; }
        public ProductDto Product { get; set; }
    }
}
