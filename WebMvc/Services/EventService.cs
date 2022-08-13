using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebMvc.Models;
using WebMvc.Services;
using WebMvc.Infrastructure;

namespace WebMvc.Services
{
    public class EventService : IEventService
    {
        private readonly string _baseUrl;
        private readonly IHttpClient _client;
        public EventService(IConfiguration config, IHttpClient client)
        {
            _baseUrl = $"{config["EventUrl"]}/api/event";
            _client = client;
        }

        public async Task<IEnumerable<SelectListItem>> GetCategoriesAsync()
        {
            var catagoriesUri = APIPaths.GetUrl.GetAllCatagories(_baseUrl);
            var dataString = await _client.GetStringAsync(catagoriesUri);
            var items = new List<SelectListItem>();
            items.Add(new SelectListItem
            {
                Value = null,
                Text = "All",
                Selected = true
            });
            var catagories = JArray.Parse(dataString);
            foreach (var item in catagories)
            {
                items.Add(new SelectListItem
                {
                    Value = item.Value<string>("id"),
                    Text = item.Value<string>("category"),
                });
            }
            return items;
        }

        public async Task<Event> GetEventItemsAsync(int page, int size, int? catagory, int? location)
        {
            var eventItemsUri = APIPaths.GetUrl.GetAllEventItems(_baseUrl, page, size, catagory, location);
            var dataString = await _client.GetStringAsync(eventItemsUri);
            return JsonConvert.DeserializeObject<Event>(dataString);
        }

        public async Task<IEnumerable<SelectListItem>> GetLocationsAsync()
        {
            var locationUri = APIPaths.GetUrl.GetAllLocations(_baseUrl);
            var dataString = await _client.GetStringAsync(locationUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = null, Text = "All", Selected=true
                }
            };
            var locations = JArray.Parse(dataString);
            foreach (var item in locations)
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