using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebMVC.Services;
using WebMVC.ViewModels;

namespace WebMVC.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _service;
        public EventController(IEventService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(int? page, int? catagoryFilterApplied, int? locationFilterApplied)
        {
            var itemsOnPage = 10;
            //make call to service and when result comes save it as events
            var events = await _service.GetEventItemsAsync(page ?? 0, itemsOnPage, catagoryFilterApplied, locationFilterApplied);
            var viewmodel = new CatalogIndexViewModel
            {
                Catagories = await _service.GetCatagoriesAsync(),
                Locations = await _service.GetLocationsAsync(),
                EventItems = events.Data,
                PaginationInfo = new PaginationInfo
                {
                    ActualPage = events.PageIndex,
                    TotalItems = events.Count,
                    ItemsPerPage = events.PageSize,
                    TotalPages = (int)Math.Ceiling ((decimal)events.Count / itemsOnPage)
                },
                LocationFilterApplied = locationFilterApplied,
                CatagoryFilterApplied = catagoryFilterApplied
                
            };
            return View(viewmodel);
        }
    }
}
