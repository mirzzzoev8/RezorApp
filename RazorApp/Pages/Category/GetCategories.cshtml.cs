using System.Net;
using Domain.DTOs.CategoryDTOs;
using Domain.Filters;
using Infrastructure.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Category
{
    public class GetCategoriesModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public GetCategoriesModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [BindProperty(SupportsGet = true)]
        public CategoryFilter Filter { get; set; }

        public List<GetCategoryDto> Categories { get; set; }
        public int TotalPages { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                var response = await _categoryService.GetCategoriesAsync(Filter);
                Categories = response.Data;
                TotalPages = response.TotalPages;
                return Page();
            }
            catch (Exception)
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}