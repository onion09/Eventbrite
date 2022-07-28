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

        private static IEnumerable<EventCatagory> GetEventCatagories()
        {
            return new List<EventCatagory>
            {
                new EventCatagory{ Category = "Food"},
                new EventCatagory{ Category = "Health"},
                new EventCatagory{ Category = "Music"},
                new EventCatagory{ Category = "Travel"},
                new EventCatagory{ Category = "Sports"},
                new EventCatagory{ Category = "Hobbies"},
                new EventCatagory{ Category = "Arts"},
                new EventCatagory{ Category = "Business"},
                new EventCatagory{ Category = "Family"}
            };
        }
    }
}
