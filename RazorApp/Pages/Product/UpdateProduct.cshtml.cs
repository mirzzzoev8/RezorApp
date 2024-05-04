namespace RazorApp.Pages.Product;
using Domain.DTOs.ProductDTOs;
using Infrastructure.Services.ProductService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class UpdateProductModel : PageModel
{
        private readonly IProductService _productService;

        public UpdateProductModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public UpdateProductDto Product { get; set; }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            
            Product.Id = id; 
            await _productService.UpdateProductAsync(Product);

            return RedirectToPage("/Product/GetProducts");
        }
    }


