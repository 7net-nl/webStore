using System;
using System.Collections.Generic;
using System.Text;

namespace ElectroShop.Domain.Entities
{
      public class FFiles : BaseEntity<long>
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string Path { get; set; }

        public int Product_ID { get; set; }
        public  Product Product { get; set; }
    }
}
