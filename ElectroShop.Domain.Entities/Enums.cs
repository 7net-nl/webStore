using System;
using System.Collections.Generic;
using System.Text;

namespace ElectroShop.Domain.Entities
{
     public enum EnumType
    {
        New =  0 ,
        Discount = 1 ,
        NewAndDiscount =2,
        OldAndDiscount =3,
        Old = 4,
    }

    public enum EnumInfoPay
    { 
        Bank = 0 ,
        Cash = 1 ,
        Online = 2
    }
}
