using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoesFactory3.Product;

namespace ShoesFactory3.Product
{
   public class ProductFactory
    {
        private List<Product> products;

        public ProductFactory()
        {
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
            Console.WriteLine("Product added successfully.");
        }

        public void UpdateProduct(Product product)
        {
            Product existingProduct = products.Find(p => p.ProductID == product.ProductID);
            if (existingProduct != null)
            {
                existingProduct.ProductName = product.ProductName;
                existingProduct.Price = product.Price;
                existingProduct.Description = product.Description;

                if (existingProduct is Shoes shoes)
                {
                    shoes.SoleType = ((Shoes)product).SoleType;
                }

                Console.WriteLine("Product updated successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public bool RemoveProduct(string productId)
        {
            Product product = GetProductById(productId);
            if (product != null)
            {
                products.Remove(product);
                return true;
            }
            return false;
        }

        public Product GetProductById(string productId)
        {
            return products.Find(p => p.ProductID == productId);
        }

        public List<Product> GetAllProducts()
        {
            return products;
        }
    }
    }

