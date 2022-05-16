using MyFirstWebApp.Model;
using System.Text.Json;

namespace MyFirstWebApp.Service
{
    public class ProductService
    {
        public Product[] GetProducts()
        {
            using (var fileReader = File.OpenText("wwwroot/data/products.json"))
            {
                var products = JsonSerializer.Deserialize<Product[]>(fileReader.ReadToEnd(), new JsonSerializerOptions()
                { 
                    PropertyNameCaseInsensitive = true,
                });

                return products;
            }
        }
    }
}
