﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using Nethereum.eShop.Web.Services;
using Nethereum.eShop.Web.ViewModels;
using System.Threading.Tasks;

namespace Nethereum.eShop.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICatalogViewModelService _catalogViewModelService;

        public IndexModel(ICatalogViewModelService catalogViewModelService)
        {
            _catalogViewModelService = catalogViewModelService;
        }

        public CatalogIndexViewModel CatalogModel { get; set; } = new CatalogIndexViewModel();

        public async Task OnGet(CatalogIndexViewModel catalogModel, int? pageId)
        {
            CatalogModel = await _catalogViewModelService.GetCatalogItems(pageId ?? 0, Constants.ITEMS_PER_PAGE, catalogModel.BrandFilterApplied, catalogModel.TypesFilterApplied);
        }
    }
}
