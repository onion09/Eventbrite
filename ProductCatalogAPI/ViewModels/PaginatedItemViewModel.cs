using EventCatalogAPI.Domain;
using System.Collections.Generic;

namespace EventCatalogAPI.ViewModels
{
    public class PaginatedItemViewModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public long Count { get; set; }
        public IEnumerable<EventItem> Data { get; set; }
    }
}
