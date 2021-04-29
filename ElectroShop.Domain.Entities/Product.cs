using System;
using System.Collections.Generic;
using System.Text;

namespace ElectroShop.Domain.Entities
{
      public class Product : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<FFiles> Images { get; set; }
        public int? Rate { get; set; }
        public EnumType Type { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public byte Category_ID { get; set; }
        public  Category Category { get; set; }

        

    }
}
