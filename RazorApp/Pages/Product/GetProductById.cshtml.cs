namespace RazorApp.Pages.Product;
using Domain.DTOs.ProductDTOs;
using Infrastructure.Services.ProductService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class GetProductByIdModel : PageModel
{
        private readonly IProductService _productService;

        public GetProductByIdModel(IProductService productService)
        {
            _productService = productService;
        }

        public GetProductDto Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            Product = product.Data;
            if (Product == null)
            {
                return NotFound(); 
            }

            return Page();
        }
    }

