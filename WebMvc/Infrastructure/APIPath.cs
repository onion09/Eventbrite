using System;

namespace WebMvc.Infrastructure
{
    public static class APIPaths
    {
        public static class GetUrl
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
                int page, int take, int? catagory, int? location, string? eventDate)
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
                        $"{filterQs}&eventLocationId={location.Value}";
                }
                if (eventDate != null)
                {
                    filterQs = (filterQs == string.Empty) ? $"eventDate={eventDate}" :
                        $"{filterQs}&eventDate={eventDate}";
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

        public static class Basket
        {
            public static string GetBasket(string baseUrl, string basketId)
            {
                return $"{baseUrl}/{basketId}";
            }

            public static string UpdateBasket(string baseUrl)
            {
                return baseUrl;
            }

            public static string CleanBasket(string baseUrl, string basketId)
            {
                return $"{baseUrl}/{basketId}";
            }
        }
    }
}