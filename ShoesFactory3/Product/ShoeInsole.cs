using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesFactory3.Product
{
   public class ShoeInsoles : Product
    {
        public ShoeInsoles(string productId, string productName, decimal price, string description, int size, string material )
            : base(productId, productName, price, description, size, material)
        {
            Size = size;
            Material = material;
        }

        public int Size { get; set; }
        public string Material { get; set; }
        public override string GetDescription()
        {
            return "Shoe Insoles";
        }
    }

}