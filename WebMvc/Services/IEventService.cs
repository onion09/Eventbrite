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
        Task<Event> GetEventItemsAsync(int page, int size, int? brand, int? type);
        Task<IEnumerable<SelectListItem>> GetLocationsAsync();
        Task<IEnumerable<SelectListItem>> GetCategoriesAsync();
    }
}
