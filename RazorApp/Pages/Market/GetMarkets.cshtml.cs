using Domain.DTOs.MarketDTOs;
using Domain.Filters;
using Infrastructure.Services.MarketService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Market;
[IgnoreAntiforgeryToken]
public class GetMarketsModel : PageModel
{
    private readonly IMarketService _marketService;

    public GetMarketsModel(IMarketService marketService)
    {
        _marketService = marketService;
    }
    [BindProperty(SupportsGet = true)]
    public MarketFilter Filter { get; set; }
    public List<GetMarketDto> Markets { get; set; }
    public int TotalPages { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var response = await _marketService.GetMarketsAsync(Filter);
        Markets = response.Data;
        TotalPages = response.TotalPages;
        return Page();
    }
}

