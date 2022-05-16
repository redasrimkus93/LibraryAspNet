using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFirstWebApp.Model;
using MyFirstWebApp.Service;

namespace MyFirstWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ProductService _productService;
        public Product[] Products { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public void OnGet()
        {
            Products = _productService.GetProducts();
        }
    }
}