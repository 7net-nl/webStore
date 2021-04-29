using System;
using System.Collections.Generic;
using System.Text;

namespace ElectroShop.Service.Application
{
     public static class StringFarsiNumberExtension
    {
        public static string ToFarsiNumber(this string Number)
        {
            var DictionaryNumberFarsi = new Dictionary<char, char>
            {
                ['0'] = '٠',
                ['1'] = '۱',
                ['2'] = '۲',
                ['3'] = '۳',
                ['4'] = '۴',
                ['5'] = '۵',
                ['6'] = '۶',
                ['7'] = '۷',
                ['8'] = '۸',
                ['9'] = '۹',
              
            };

            foreach (var item in DictionaryNumberFarsi)
            {
                Number = Number.Replace(item.Key,item.Value);
            }

            return Number;
          
           
        }
    }
}
