using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EventCatalogAPI.Data
{
    public class EventSeed
    {
        public static void Seed(EventContext context)
        {
            context.Database.Migrate();
            if (!context.EventLocations.Any())
            {
                context.EventLocations.AddRange(GetEventLocations());
                context.SaveChanges();
            }
            if(!context.EventCatagories.Any())
            {
                context.EventCatagories.AddRange(GetEventCatagories());
                context.SaveChanges();
            }
            if (!context.EventItems.Any())
            {
                context.EventItems.AddRange(GetEventItems());
                context.SaveChanges();
            }
        }

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
                new EventLocation{City="Redmond"},
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

        private static IEnumerable<EventItem> GetEventItems()
        {
            return new List<EventItem>
            {
             new EventItem{EventCatagoryId = 1, EventLocationId =7, Description = "All-You-Can-Eat Ice Cream Festival", Name = "IceCream Feast", Price = 50, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/1", EventDate = new System.DateTime(2022, 08 , 27), Address = "Onyx, 156th Ave", Organizer = "RemondEvents"},

             new EventItem{EventCatagoryId = 1, EventLocationId =3, Description = "Explore the evolution of coffee culture", Name = "Coffee Culture Tour", Price = 150, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/2", EventDate = new System.DateTime(2022, 08 , 28), Address = "Space Needele Near", Organizer = "SeattleEvents"},

             new EventItem{EventCatagoryId = 1, EventLocationId =6, Description = "", Name = " Classic Handmade Ravioli ", Price = 100, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/3", EventDate = new System.DateTime(2022, 08 , 30), Address = "The Bistro @ SpringHill Suites Seattle Downtown", Organizer = "RemondEvents"},

             new EventItem{EventCatagoryId = 2, EventLocationId =3, Description = "A gentle yoga practice open to everyone in the soaring sacred space of the cathedral nave", Name = "Cathedral Yoga at Saint Marks", Price = 150, PictureURL = "http://exter/api/pic/4", EventDate = new System.DateTime(2022, 08 , 27), Address = "Saint Mark's Episcopal Cathedral", Organizer = "SeattleEvents"},

             new EventItem{EventCatagoryId = 2, EventLocationId =7, Description = "Joy Of Breathing Free Class", Name = "Pranayama ", Price = 0, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/5", EventDate = new System.DateTime(2022, 08 , 31), Address = "MaryMoor Park", Organizer = "RemondEvents"},

             new EventItem{EventCatagoryId = 2, EventLocationId =5, Description = "Meditate, meet and get motivated.", Name = "Guided Meditation", Price = 25, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/6", EventDate = new System.DateTime(2022, 09, 01), Address = "Issaquah Heights", Organizer = "IssaquahEvents"},

             new EventItem{EventCatagoryId = 3, EventLocationId =6, Description = "Exploring the world of Torch and Twang - featuring great singers and players", Name = "Wintergrass", Price = 120, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/7", EventDate = new System.DateTime(2022, 09, 02), Address = "Hyatt Regency", Organizer = "BellevueEvents"},

             new EventItem{EventCatagoryId = 3, EventLocationId =3, Description = "Massive Fridays at Trinity -by Trinity Nightclub", Name = "Massive Fridays", Price = 150, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/8", EventDate = new System.DateTime(2022, 09, 10), Address = "Trinity Occidental Avenue South", Organizer = "SeattleEvents"},

             new EventItem{EventCatagoryId = 3, EventLocationId =4, Description = "LIVE 80's New Wave at 10th annual Summerfest", Name = "Nite Wave Concert", Price = 70, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/9",EventDate = new System.DateTime(2022, 09, 11), Address = "Marina Park 25 Lakeshore Plaza", Organizer = "RentonEvents"}




             


            };
        }
    }
}
