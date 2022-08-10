using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebMVC.Models;

namespace WebMVC.Services
{
    public interface IEventService
    {
        Task<Catalog> GetEventItemsAsync(int page, int size, int? brand, int? type);

        Task<IEnumerable<SelectListItem>> GetCatagoriesAsync();
        Task<IEnumerable<SelectListItem>> GetLocationsAsync();
        
    }
}
