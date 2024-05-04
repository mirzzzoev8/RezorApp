using Domain.DTOs.CategoryDTOs;
using Infrastructure.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Category
{
    public class UpdateCategoryModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public UpdateCategoryModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [BindProperty]
        public UpdateCategoryDto Category { get; set; }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            
            Category.Id = id; 
            await _categoryService.UpdateCategoryAsync(Category);

            return RedirectToPage("/Category/GetCategories");
        }
    }
}