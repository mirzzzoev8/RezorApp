using Infrastructure.Services.MarketService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Market;

public class DeleteMarketModel : PageModel
{

        private readonly IMarketService _marketService;

        public DeleteMarketModel(IMarketService categoryService)
        {
            _marketService = categoryService;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            await _marketService.RemoveMarketAsync(Id);
            return RedirectToPage("/Market/GetMarkets");
        }
    }

