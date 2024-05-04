using Domain.DTOs.CategoryDTOs;
using Infrastructure.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Category
{
    [IgnoreAntiforgeryToken]
    public class CreateCategoryModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public CreateCategoryModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [BindProperty] public CreateCategoryDto CategoryDto { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _categoryService.CreateCategoryAsync(CategoryDto);

            return RedirectToPage("/Category/GetCategories");
        }
    }
}