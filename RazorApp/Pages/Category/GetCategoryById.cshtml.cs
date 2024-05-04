using System.Threading.Tasks;
using Domain.DTOs.CategoryDTOs;
using Infrastructure.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Category
{
    public class GetCategoryByIdModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public GetCategoryByIdModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public GetCategoryDto Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            Category = category.Data;
            if (Category == null)
            {
                return NotFound(); 
            }

            return Page();
        }
    }
}