using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebMvc.Models;

namespace WebMvc.ViewModels
{
    public class EventIndexViewModel
    {
        public IEnumerable<SelectListItem> Locations { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> Dates { get; set; }
        public IEnumerable<EventItem> EvenetItems { get; set; }

        public PaginationInfo PaginationInfo { get; set; }

        public int? CategoryFilterApplied { get; set; }

        public int? LocationFilterApplied { get; set; }

        public string? DateFilterApplied { get; set; }
        public IEnumerable<EventItem> EventItems { get; internal set; }
    }
}
