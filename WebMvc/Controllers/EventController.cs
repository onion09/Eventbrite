using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMvc.Models;
using WebMvc.Services;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class EventController : Controller
    {

        private readonly EventService _service;

        public EventController(EventService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(int? page, int? categoryfilterapplied, int? locationfilterapplied, DateTime eventDate)
        {
            var itemsonPage = 10;
            var item = await _service.GetEventItemsAsync(page ?? 0, itemsonPage, categoryfilterapplied, locationfilterapplied, eventDate);


            var vm = new EventIndexViewModel
            {
                Categories = await _service.GetCategoriesAsync(),
                Locations = await _service.GetLocationsAsync(),

                EventItems = item.Data,
                PaginationInfo = new PaginationInfo
                {
                    ActualPage = item.pageIndex,
                    TotalItems = item.Count,
                    ItemsPerPage = item.pageSize,
                    TotalPages = (int)Math.Ceiling((decimal)item.Count / itemsonPage)
                },
                CategoryFilterApplied = categoryfilterapplied,
                LocationFilterApplied = locationfilterapplied
            };

            return View(vm);
        }
    }
}
