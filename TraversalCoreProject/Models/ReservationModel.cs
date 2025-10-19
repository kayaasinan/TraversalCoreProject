namespace TraversalCoreProject.Models
{
    public class ReservationModel
    {
        public string? Name { get; set; }       
        public string? Destination { get; set; } 
        public int PeopleCount { get; set; }    
        public DateTime ReservationDate { get; set; }
    }
}
