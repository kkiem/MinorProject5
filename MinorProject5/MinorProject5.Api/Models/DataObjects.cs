namespace MinorProject5.Api.Models
{
    // Matches the database tables directly (Requirement 2d)
    public class ClubData
    {
        public int ClubID { get; set; }
        public string ClubName { get; set; } = "";
        public string City { get; set; } = "";
        public string Stadium { get; set; } = "";
    }

    public class ManagerData
    {
        public int ManagerID { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string TacticalStyle { get; set; } = "";
        public int ClubID { get; set; }
    }

    public class PlayerData
    {
        public int PlayerID { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Position { get; set; } = "";
        public int ClubID { get; set; }
    }
}