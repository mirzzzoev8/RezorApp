using Domain.DTOs.MarketDTOs;
using Infrastructure.Services.MarketService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Market;

public class UpdateMarketModel : PageModel
{
        private readonly IMarketService _marketService;

        public UpdateMarketModel(IMarketService marketService)
        {
            _marketService = marketService;
        }

        [BindProperty]
        public UpdateMarketDto Market { get; set; }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            
            Market.Id = id; 
            await _marketService.UpdateMarketAsync(Market);

            return RedirectToPage("/Market/GetMarkets");
        }
    }

