using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElectroShop.Service.Application
{
      public class PagedAndSorted
    {
        [Required]
        public short TotalPage { get; set; }
        [Required]
        public short PageItemCount { get; set; }
        [Required]
        public short SelectPage { get; set; }
        public int Count { get; set; }

    }
}
