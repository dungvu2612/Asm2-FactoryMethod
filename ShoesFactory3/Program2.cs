using System;
using System.Collections.Generic;

namespace ShoesFactory3.Product
{
    public class Program
    {
        private static ProductFactory productFactory = new ProductFactory();

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("======== Product Management ========");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Remove Product");
                Console.WriteLine("4. Search Product");
                Console.WriteLine("5. View All Products");
                Console.WriteLine("6. Exit");

                Console.Write("Please enter your choice: ");
                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddProduct();
                            break;
                        case 2:
                            UpdateProduct();
                            break;
                        case 3:
                            RemoveProduct();
                            break;
                        case 4:
                            SearchProduct();
                            break;
                        case 5:
                            ViewAllProducts();
                            break;
                        case 6:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }

                Console.WriteLine();
            }
        }

  private static void AddProduct()
{
    Console.WriteLine("======== Add Product ========");

    Console.Write("Enter Product ID: ");
    string productId = Console.ReadLine();

    Console.Write("Enter Product Name: ");
    string productName = Console.ReadLine();

    Console.Write("Enter Price: ");
    decimal price;
    if (!decimal.TryParse(Console.ReadLine(), out price))
    {
        Console.WriteLine("Invalid price. Product not added.");
        return;
    }

    Console.Write("Enter Description: ");
    string description = Console.ReadLine();

    Console.Write("Enter Size: ");
    int size;
    if (!int.TryParse(Console.ReadLine(), out size))
    {
        Console.WriteLine("Invalid size. Product not added.");
        return;
    }

    Console.Write("Enter Material: ");
    string material = Console.ReadLine();

    Console.Write("Enter Product Type (1. ShoeInsole, 2. Shoes, 3. Socks): ");
    int productType;
    if (!int.TryParse(Console.ReadLine(), out productType) || productType < 1 || productType > 3)
    {
        Console.WriteLine("Invalid product type. Product not added.");
        return;
    }

    Product newProduct;
    switch (productType)
    {
        case 1:
            newProduct = new ShoeInsoles(productId, productName, price, description, size, material);
            break;
        case 2:
            Console.Write("Enter Sole Type: ");
            string soleType = Console.ReadLine();
            newProduct = new Shoes(productId, productName, price, description, size, material, soleType);
            break;
        case 3:
            newProduct = new Socks(productId, productName, price, description, size, material);
            break;
        default:
            Console.WriteLine("Invalid product type. Product not added.");
            return;
    }

    productFactory.AddProduct(newProduct);
}

        private static void UpdateProduct()
        {
            Console.WriteLine("======== Update Product ========");

            Console.Write("Enter Product ID: ");
            string productId = Console.ReadLine();

            Product existingProduct = productFactory.GetProductById(productId);
            if (existingProduct == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.Write("Enter New Product Name: ");
            string newProductName = Console.ReadLine();

            Console.Write("Enter New Price: ");
            decimal newPrice;
            if (!decimal.TryParse(Console.ReadLine(), out newPrice))
            {
                Console.WriteLine("Invalid price. Product not updated.");
                return;
            }

            Console.Write("Enter New Description: ");
            string newDescription = Console.ReadLine();

            Console.Write("Enter New Size: ");
            int newSize;
            if (!int.TryParse(Console.ReadLine(), out newSize))
            {
                Console.WriteLine("Invalid size. Product not updated.");
                return;
            }

            Console.Write("Enter New Material: ");
            string newMaterial = Console.ReadLine();

            if (existingProduct is Shoes existingShoes)
            {
                Console.Write("Enter New Sole Type: ");
                string newSoleType = Console.ReadLine();
                existingShoes.SoleType = newSoleType;
            }

            existingProduct.ProductName = newProductName;
            existingProduct.Price = newPrice;
            existingProduct.Description = newDescription;
            existingProduct.Size = newSize;
            existingProduct.Material = newMaterial;

            Console.WriteLine("Product updated successfully.");
        }

        private static void RemoveProduct()
        {
            Console.WriteLine("======== Remove Product ========");

            Console.Write("Enter Product ID: ");
            string productId = Console.ReadLine();

            bool removed = productFactory.RemoveProduct(productId);
            if (removed)
            {
                Console.WriteLine("Product removed successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        private static void SearchProduct()
        {
            Console.WriteLine("======== Search Product ========");

            Console.Write("Enter Product ID: ");
            string productId = Console.ReadLine();

            Product product = productFactory.GetProductById(productId);
            if (product != null)
            {
                Console.WriteLine("Product Found:");
                Console.WriteLine("Product ID: " + product.ProductID);
                Console.WriteLine("Product Name: " + product.ProductName);
                Console.WriteLine("Price: " + product.Price);
                Console.WriteLine("Description: " + product.Description);
                Console.WriteLine("Size: " + product.Size);
                Console.WriteLine("Material: " + product.Material);
                Console.WriteLine("Type: " + product.GetDescription());

                if (product is Shoes shoes)
                {
                    Console.WriteLine("Sole Type: " + shoes.SoleType);
                }
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        private static void ViewAllProducts()
        {
            Console.WriteLine("======== View All Products ========");

            List<Product> products = productFactory.GetAllProducts();

            if (products.Count == 0)
            {
                Console.WriteLine("No products found.");
            }
            else
            {
                Console.WriteLine("Product List:");
                foreach (Product product in products)
                {
                    Console.WriteLine("-------------------------");
                    Console.WriteLine("Product ID: " + product.ProductID);
                    Console.WriteLine("Product Name: " + product.ProductName);
                    Console.WriteLine("Price: " + product.Price);
                    Console.WriteLine("Description: " + product.Description);
                    Console.WriteLine("Size: " + product.Size);
                    Console.WriteLine("Material: " + product.Material);
                    Console.WriteLine("Type: " + product.GetDescription());

                    if (product is Shoes shoes)
                    {
                        Console.WriteLine("Sole Type: " + shoes.SoleType);
                    }
                }
                Console.WriteLine("-------------------------");
            }
        }
    }
}