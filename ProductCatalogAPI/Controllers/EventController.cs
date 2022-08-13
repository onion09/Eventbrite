using EventCatalogAPI.Data;
using EventCatalogAPI.Domain;
using EventCatalogAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly EventContext _context;
        public EventController(EventContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> EventCategories()
        {
            var categories = await _context.EventCatagories.ToListAsync();
            return Ok(categories);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> EventLocations()
        {
            var locations = await _context.EventLocations.ToListAsync();
            return Ok(locations);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Items(
            [FromQuery]int pageIndex = 0,
            [FromQuery]int pageSize = 6)
        {
            var itemsCount = await _context.EventItems.LongCountAsync();
            var items = await _context.EventItems
                .OrderBy(c => c.Name)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();
            items = ChangePictureUrl(items);

            var model = new PaginatedItemViewModel()
            {
                PageIndex = pageIndex,
                PageSize = items.Count,
                Count = itemsCount,
                Data = items
            };
            return Ok(model);
        }

        [HttpGet("[action]/filter")]
        public async Task<IActionResult> Items(
            [FromQuery] int? eventCatagoryId,
            [FromQuery] int? eventLocationId,
            [FromQuery] DateTime? eventDate,
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 6)
        {
            var query = (IQueryable<EventItem>)_context.EventItems;
            if (eventCatagoryId.HasValue)
            {
                query = query.Where(c => c.EventCatagoryId == eventCatagoryId.Value);
            }
            if (eventLocationId.HasValue)
            {
                query = query.Where(c => c.EventLocationId == eventLocationId.Value);
            }

            if (eventDate.HasValue)
            {
                query = query.Where(c => c.EventDate == eventDate.Value);
            }
            var itemsCount = await query.LongCountAsync();
            var items = await query.OrderBy(c => c.Name).Skip(pageSize * pageIndex)
                .Take(pageSize).ToListAsync();

            items = ChangePictureUrl(items);
            var model = new PaginatedItemViewModel
            {
                PageIndex = pageIndex,
                PageSize = items.Count,
                Count = itemsCount,
                Data = items
            };
            return Ok(model);
        }

        private List<EventItem> ChangePictureUrl(List<EventItem> items)
        {
            items.ForEach(item =>
            item.PictureURL = item.PictureURL.Replace("http://externalcatalogbaseurltobereplaced",
            _config["ExternalBaseUrl"]));
            return items;
        }
    }
}
