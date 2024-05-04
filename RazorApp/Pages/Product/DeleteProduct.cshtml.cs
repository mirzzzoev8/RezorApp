namespace RazorApp.Pages.Product;
using Infrastructure.Services.ProductService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

    public class DeleteProductModel : PageModel
    {

            private readonly IProductService _productService;

            public DeleteProductModel(IProductService productService)
            {
                _productService = productService;
            }

            [BindProperty(SupportsGet = true)]
            public int Id { get; set; }

            public async Task<IActionResult> OnPostAsync()
            {
                await _productService.RemoveProductAsync(Id);
                return RedirectToPage("/Product/GetProducts");
            }
        }




