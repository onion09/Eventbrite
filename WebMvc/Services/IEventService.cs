using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebMvc.Models;

namespace WebMvc.Services
{
    public interface IEventService
    {

        Task<Event> GetEventItemsAsync(int page, int size, int? catagory, int? location);
        Task<IEnumerable<SelectListItem>> GetLocationsAsync();
        Task<IEnumerable<SelectListItem>> GetCategoriesAsync();
    }
}
