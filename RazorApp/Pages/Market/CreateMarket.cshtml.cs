using Domain.DTOs.MarketDTOs;
using Infrastructure.Services.MarketService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Market
{
    [IgnoreAntiforgeryToken]
    public class CreateMarketModel : PageModel
    {
        private readonly IMarketService _marketService;

        public CreateMarketModel(IMarketService marketService)
        {
            _marketService = marketService;
        }

        [BindProperty] public CreateMarketDto MarketDto { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _marketService.CreateMarketAsync(MarketDto);

            return RedirectToPage("/Market/GetMarkets");
        }
    }
}

