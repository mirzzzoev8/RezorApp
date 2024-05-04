using Infrastructure.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Category
{
    public class DeleteCategoryModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public DeleteCategoryModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            await _categoryService.RemoveCategoryAsync(Id);
            return RedirectToPage("/Category/GetCategories");
        }
    }
}