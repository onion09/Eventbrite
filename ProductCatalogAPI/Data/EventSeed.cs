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
                new EventLocation{City="Woodinville", ZipCode=98072},
                new EventLocation{City="Bellingham", ZipCode=98226},
                new EventLocation{City="Seattle", ZipCode=98103},
                new EventLocation{City="Renton", ZipCode=98056},
                new EventLocation{City="Issaquah", ZipCode=98029},
                new EventLocation{City="Seattle", ZipCode=98108},
                new EventLocation{City="Bellevue", ZipCode=98004},
                new EventLocation{City="Seattle", ZipCode=98121},
                new EventLocation{City="Seattle", ZipCode=98117}

            };
        }
    }
}
