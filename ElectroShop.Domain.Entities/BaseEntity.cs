using System;

namespace ElectroShop.Domain.Entities
{
    public class BaseEntity<TPrimaryKey>
    {
        public TPrimaryKey ID { get; set; }
    }
}
