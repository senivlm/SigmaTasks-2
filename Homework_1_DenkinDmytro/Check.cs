using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1_DenkinDmytro
{
    // static -- class does not have any data, prints information
    public static class Check
    {
        public static void ProductInfo(Product product)
        {
            Console.WriteLine(product);
        }

        public static void BuyInfo(Buy buy)
        {
            Console.WriteLine(buy);
        }
    }
}
