using Domain.DTOs.ProductDTOs;
using Infrastructure.Services.ProductService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Product
{
    [IgnoreAntiforgeryToken]
    public class CreateProductModel : PageModel
    {
        private readonly IProductService _productService;

        public CreateProductModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty] public CreateProductDto ProductDto { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _productService.CreateProductAsync(ProductDto);

            return RedirectToPage("/Product/GetProducts");
        }
    }
}
