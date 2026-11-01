namespace MinorProject5.Api.Models
{
    // Models that the service layer sends to the client (Requirement 4d)
    public class ClubServiceModel
    {
        public int ClubID { get; set; }
        public string ClubName { get; set; } = "";
        public string City { get; set; } = "";
        public string Stadium { get; set; } = "";
    }

    public class ManagerServiceModel
    {
        public int ManagerID { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string FullName { get; set; } = "";
        public string TacticalStyle { get; set; } = "";
        public int ClubID { get; set; }
    }

    public class PlayerServiceModel
    {
        public int PlayerID { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string FullName { get; set; } = "";
        public string Position { get; set; } = "";
        public int ClubID { get; set; }
    }
}