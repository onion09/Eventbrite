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

             new EventItem{EventCatagoryId = 3, EventLocationId =4, Description = "LIVE 80's New Wave at 10th annual Summerfest", Name = "Nite Wave Concert", Price = 70, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/9",EventDate = new System.DateTime(2022, 09, 11), Address = "Marina Park 25 Lakeshore Plaza", Organizer = "RentonEvents"},


             new EventItem{EventCatagoryId = 7, EventLocationId =7, Description = "Eric Solberg IS BACK! Not even a van can stop this man!",
                Name = "Raku Firing Workshop", Price = 50, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/19",
                EventDate = new System.DateTime(2022, 08, 06), Address = "35 South Hanford Street", Organizer = "SPS"},

             new EventItem{EventCatagoryId = 7, EventLocationId =1, Description = "Visit the world's first NFT museum!",
                Name = "Seattle NFT Museum Admission: Crossing Over #NFTs", Price = 50, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/20",
                EventDate = new System.DateTime(2022, 07, 30), Address = "2125 1st Avenue", Organizer = "Seattle NFT Museum"},

             new EventItem{EventCatagoryId = 7, EventLocationId =5, Description = "Lola by Can Can , Seattle's World-Class Cabaret",
                Name = "Can Can's Lola", Price = 49, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/21",
                EventDate = new System.DateTime(2022, 07, 31), Address = "95 Pine Street", Organizer = "Can Can Culinary Cabaret"},

             new EventItem{EventCatagoryId = 8, EventLocationId =5, Description = "Best Telecom event in the country!",
                Name = "Broadband Consultants Summer Jam 2022", Price = 0, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/22",
                EventDate = new System.DateTime(2022, 08, 20), Address = "1124 250th Avenue Northeast", Organizer = "Broadband Consultants"},

             new EventItem{EventCatagoryId = 8, EventLocationId =3, Description = "In this workshop, discover a sustainable approach to directing and manage your recruiting operations and programs.",
                Name = "Directing and Growing Your Global Recruiting Operations and Programs", Price = 499, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/23",
                EventDate = new System.DateTime(2022, 08, 01), Address = "1420 5th Avenue", Organizer = "Samex"},

             new EventItem{EventCatagoryId = 8, EventLocationId =3, Description = "Every week a group of business owners, founders and creators meet to have a coffee chat about their work, their projects and their passions.",
                Name = "Seattle Small Business - Coffee Meetup", Price = 0, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/24",
                EventDate = new System.DateTime(2022, 07, 28), Address = "333 Westlake Avenue North", Organizer = "BizBaby"},

             new EventItem{EventCatagoryId = 9, EventLocationId =3, Description = "The event focuses on engaging and uplifting thecommunity through music and culture",
                Name = "Seattle Summer Love Fest 2022: ANGIE STONE LIVE", Price = 149, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/25",
                EventDate = new System.DateTime(2022, 08, 13), Address = "2150 S Norman St.", Organizer = "Davis One Ent"},

             new EventItem{EventCatagoryId = 9, EventLocationId =1, Description = "We are talking about 20 years of adventure and great music.",
                Name = "Summer Meltdown Festival", Price = 0, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/26",
                EventDate = new System.DateTime(2022, 07, 31), Address = "18601 Sky Meadows Lane", Organizer = "Summer Meltdown Festival"},

             new EventItem{EventCatagoryId = 9, EventLocationId =5, Description = "The JBF Issaquah Pop-up consignment shop is BACK! Come check out our great selection and deals on our PRESALE DAY!",
                Name = "PRESALE | Huge Kids Consignment Pop-Up Shop!", Price = 30, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/27",
                EventDate = new System.DateTime(2022, 10, 05), Address = "1730 10th Ave NW", Organizer = "JBF Seattle East/Issaquah"},

            new EventItem{EventCatagoryId = 6, EventLocationId =1, Description = "Paint on a hanging wood plaque!", Name = "Dahlias on Wood", Price = 45, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/10",EventDate = new System.DateTime(2022, 08, 23), Address = "13590 NE Village Square Dr #1035, Woodinville, WA 98072", Organizer = "Corks and Canvas Events"},
            new EventItem{EventCatagoryId = 6, EventLocationId =2, Description = "Monthly meeting for Amateur Radio (HAM) enthusiasts ", Name = "Amateur Radio Group Meetup", Price = 0, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/11",EventDate = new System.DateTime(2022, 07, 30), Address = "1 Bellis Fair Parkway, Bellingham, WA 98226", Organizer = "Bellingham Makerspace"},
            new EventItem{EventCatagoryId = 6, EventLocationId =3, Description = "This is a two part class for all those who love pizza. ", Name = "Pizza Cutter & Pizza Peel Class", Price = 225, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/12",EventDate = new System.DateTime(2022, 08, 26), Address = "832 NE Northgate Way, Seattle, WA 98103", Organizer = "Rockler Woodworking and Hardware"},
            new EventItem{EventCatagoryId = 5, EventLocationId =4, Description = "Drop-in, sweat a little, and see how you like FitLot Method circuit training!", Name = "FitLot Method DROP-IN CLASSES", Price = 0, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/13",EventDate = new System.DateTime(2022, 08, 02), Address = "3000 NE 16th St, Renton, WA 98056", Organizer = "RentonEvents"},
            new EventItem{EventCatagoryId = 5, EventLocationId =5, Description = "The Pacific North Best! Sharpen your skills with current pros and former national champs!", Name = "Pacific North Best Elite Camp", Price = 325, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/14",EventDate = new System.DateTime(2022, 08, 20), Address = "1907 NE Park Dr, Issaquah, WA 98029", Organizer = "IM Training LLC"},
            new EventItem{EventCatagoryId = 5, EventLocationId =3, Description = "The best IA skate instructors to your doorstep. Don't miss it !!!", Name = "True Skater Summer Skate Clinic", Price = 25, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/15",EventDate = new System.DateTime(2022, 08, 20), Address = "3801 Beacon Ave s. Seattle, WA 98108", Organizer = "Critical Medicine"},
            new EventItem{EventCatagoryId = 4, EventLocationId =6, Description = "traditional scavenger hunt with a modern twist!", Name = "It's a Scavenger Hunt!", Price = 25, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/16",EventDate = new System.DateTime(2022, 08, 09), Address = "575 Bellevue Square, Bellevue, WA 98004", Organizer = " CyberActivities"},
            new EventItem{EventCatagoryId = 4, EventLocationId =3, Description = "Your insider’s guide to the Emerald City.", Name = "Seattle 101", Price = 0, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/17",EventDate = new System.DateTime(2022, 08, 30), Address = "2001 Western Avenue, Seattle, WA 98121", Organizer = "Seattle Free Walking Tours"},
            new EventItem{EventCatagoryId = 4, EventLocationId =3, Description = "Sit back and relax or participate as much as you like as one of our skippers takes you for an evening sail", Name = "TGIF Sunset Cruises", Price = 225, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/18",EventDate = new System.DateTime(2022, 08, 28), Address = "7001 Seaview Ave NW, Seattle,WA", Organizer = "Windworks Sailing & Pownerboating Club"}
            };
        }
    }
}
