using Domain.DTOs.MarketDTOs;
using Infrastructure.Services.MarketService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Market;

public class GetMarketByIdModel : PageModel
{
        private readonly IMarketService _marketService;

        public GetMarketByIdModel(IMarketService marketService)
        {
            _marketService = marketService;
        }

        public GetMarketDto Market { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var category = await _marketService.GetMarketByIdAsync(id);
            Market = category.Data;
            if (Market == null)
            {
                return NotFound(); 
            }

            return Page();
        }
    }
