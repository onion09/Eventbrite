namespace EventCatalogAPI.Domain
{
    public class EventItem
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public int EventTagId { get; set; }
        public int EventLocationId { get; set; }
        public int EventTypeId { get; set; }
        public int EventOrganizerId { get; set; }
        public int EventCategoryId { get; set; }
        public int EventTimeId { get; set; }

        public virtual EventCategory EventCategory { get; set; }
        public virtual EventType EventType { get; set; }
        public virtual EventTag EventTag { get; set; }
        public virtual EventOrganizer EventOrganizer { get; set; }
        public virtual EventLocation EventLocation { get; set; }
        public virtual EventTime EventTime { get; set; }
        
    }
}
