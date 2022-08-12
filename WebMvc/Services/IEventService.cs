using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebMvc.Models;

namespace WebMvc.Services
{
    interface IEventService
    {
        Task<Event> GetEventItemsAsync(int page, int size, int? catagory, int? location, DateTime? eventDate);
        Task<IEnumerable<SelectListItem>> GetLocationsAsync();
        Task<IEnumerable<SelectListItem>> GetCategoriesAsync();
    }
}
