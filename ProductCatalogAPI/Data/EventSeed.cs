using EventCatalogAPI.Domain;
using System.Collections.Generic;

namespace EventCatalogAPI.Data
{
    public class EventSeed
    {

        private static IEnumerable<EventLocation> GetEventLocations()
        {
            return new List<EventLocation>
            {
                new EventLocation{City="Woodinville"},
                new EventLocation{City="Bellingham"},
                new EventLocation{City="Seattle"},
                new EventLocation{City="Renton"},
                new EventLocation{City="Issaquah"},
                new EventLocation{City="Bellevue"},
            };
        }
    }
}
