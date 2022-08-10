﻿namespace WebMVC.Infrastructure
{
    public static class APIPaths
    {
        public static class Catalog
        {
            public static string GetAllCatagories(string baseUri)
            {
                return $"{baseUri}/eventCategories";
            }
            public static string GetAllLocations(string baseUri)
            {
                return $"{baseUri}/eventLocations";
            }
            public static string GetAllEventItems(string baseUri, 
                int page, int take,int? catagory, int? location)
            {
                var preUri = string.Empty;
                var filterQs = string.Empty;
                if (catagory.HasValue)
                {
                    filterQs = $"eventCatagoryId={catagory.Value}";
                }
                if (location.HasValue)
                {
                    filterQs = (filterQs == string.Empty) ? $"eventLocationId={location.Value}" :
                        $"&eventLocationId={location.Value}";
                }
                if (string.IsNullOrEmpty(filterQs))
                {
                    preUri = $"{baseUri}/items?pageIndex={page}&pageSize={take}";
                }
                else
                {
                    preUri = $"{baseUri}/items/filter?pageIndex={page}&pageSize={take}&{filterQs}";
                }
                return preUri;
            }
        }
    }
}
