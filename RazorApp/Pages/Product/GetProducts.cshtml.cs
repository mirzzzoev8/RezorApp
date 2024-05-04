using Domain.DTOs.ProductDTOs;
using Domain.Filters;
using Infrastructure.Services.ProductService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace RazorApp.Pages.Product;
[IgnoreAntiforgeryToken]
public class GetProductsModel : PageModel
{
    private readonly IProductService _productService;

    public GetProductsModel(IProductService productService)
    {
        _productService = productService;
    }
    [BindProperty(SupportsGet = true)]
    public ProductFilter Filter { get; set; }
    public List<GetProductDto> Products { get; set; }
    public int TotalPages { get; set; }
    public async Task<IActionResult> OnGetAsync()
    {
        var response = await _productService.GetProductsAsync(Filter);
        Products = response.Data;
        TotalPages = response.TotalPages;


        return Page();
    }
}


