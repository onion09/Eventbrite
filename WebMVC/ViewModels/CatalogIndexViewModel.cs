using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WebMVC.Models;

namespace WebMVC.ViewModels
{
    public class CatalogIndexViewModel
    {
        public IEnumerable<SelectListItem> Catagories { get; set; }
        public IEnumerable<SelectListItem> Locations { get; set; }
        public IEnumerable<Item> EventItems { get; set; }
        public PaginationInfo PaginationInfo { get; set; }

        public int? LocationFilterApplied { get; set; }
        public int? CatagoryFilterApplied { get; set; }
    }
}
