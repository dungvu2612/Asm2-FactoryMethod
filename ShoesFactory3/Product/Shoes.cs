using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesFactory3.Product
{
  public class Shoes : Product
    {
        public Shoes(string productId, string productName, decimal price, string description, int size, string material, string soleType)
            : base(productId, productName, price, description, size, material)
        {
            Size = size;
            Material = material;
            SoleType = soleType;
        }

        public int Size { get; set; }
        public string Material { get; set; }
public string SoleType { get; set; }
        public override string GetDescription()
        {
            return "Shoes";
        }
    }


}