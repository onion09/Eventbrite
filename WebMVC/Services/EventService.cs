using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebMVC.Infrastructure;
using WebMVC.Models;

namespace WebMVC.Services
{
    public class EventService : IEventService
    {
        private readonly string _baseUrl;  
        private readonly IHttpClient _client;
        public EventService(IConfiguration config, IHttpClient client)
        {
            _baseUrl = $"{config["CatalogUrl"]}/api/catalog";
            _client = client;
        }

        public async Task<IEnumerable<SelectListItem>> GetCatagoriesAsync()
        {
            var catagoriesUri = APIPaths.Catalog.GetAllCatagories(_baseUrl);
            var dataString = await _client.GetStringAsync(catagoriesUri);
            var items = new List<SelectListItem>();
            items.Add(new SelectListItem{
                Value = null, Text = "All", Selected = true});
            var catagories = JArray.Parse(dataString);
            foreach(var item in catagories)
            {
                items.Add(new SelectListItem
                {
                    Value = item.Value<string>("id"),
                    Text = item.Value<string>("category"),
                });
            }
            return items;
        }

        public async Task<Catalog> GetEventItemsAsync(int page, int size, int? brand, int? type)
        {
            var eventItemsUri = APIPaths.Catalog.GetAllEventItems(_baseUrl, page, size, brand, type);
            var dataString = await _client.GetStringAsync(eventItemsUri);
            return JsonConvert.DeserializeObject<Catalog>(dataString);
        }

        public async Task<IEnumerable<SelectListItem>> GetLocationsAsync()
        {
            var locationUri = APIPaths.Catalog.GetAllLocations(_baseUrl);
            var dataString = await _client.GetStringAsync(locationUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = null, Text = "All", Selected=true
                }
            };
            var locations = JArray.Parse(dataString);
            foreach(var item in locations)
            {
                items.Add(new SelectListItem
                {
                    Value = item.Value<string>("id"),
                    Text = item.Value<string>("city")
                });
            }
            return items;
        }
    }
}
