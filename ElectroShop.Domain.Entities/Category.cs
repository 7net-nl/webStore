using System;
using System.Collections.Generic;
using System.Text;

namespace ElectroShop.Domain.Entities
{
      public class Category : BaseEntity<byte>
    {
        public string Name { get; set; }
    }
}
