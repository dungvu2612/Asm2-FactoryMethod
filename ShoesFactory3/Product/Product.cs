using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesFactory3.Product
{
public abstract class Product
{
    public string ProductID { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public int Size { get; set; }
    public string Material { get; set; }
    public string SoleType { get; set; }
    public Product(string productId, string productName, decimal price, string description, int size, string material)
    {
        ProductID = productId;
        ProductName = productName;
        Price = price;
        Description = description;
        Size = size;
        Material = material;
    }
    public Product(string productId, string productName, decimal price, string description, int size, string material, string soleType)
    {
        ProductID = productId;
        ProductName = productName;
        Price = price;
        Description = description;
        Size = size;
        Material = material;
        SoleType   = soleType;
    }
    public virtual string GetDescription()
    {
        return Description;
    }
}

}