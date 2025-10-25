namespace SignalRApiForMSSQL.DAL
{

    public enum ECity
    {
        Manisa = 1,
        İstanbul = 2,
        Çankırı = 3,
        Gaziantep = 4,
        Antalya = 5
    }
    public class Visitor
    {
        public int VisitorId { get; set; }
        public ECity City { get; set; }
        public int DailyVisitorCount { get; set; }
        public DateTime VisitDate { get; set; }
    }
}

