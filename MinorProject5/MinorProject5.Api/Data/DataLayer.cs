using Microsoft.Data.SqlClient;
using MinorProject5.Api.Models;

namespace MinorProject5.Api.Data
{
    public class DataLayer
    {
        private string connString = "Server=.;Database=PremierLeagueWeb;Trusted_Connection=True;TrustServerCertificate=True;";

        // ==========================================
        // 1. CLUB CRUD
        // ==========================================
        public List<ClubData> GetAllClubs()
        {
            List<ClubData> list = new List<ClubData>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string sql = "SELECT ClubID, ClubName, City, Stadium FROM Club";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ClubData c = new ClubData();
                    c.ClubID = Convert.ToInt32(reader["ClubID"]);
                    c.ClubName = reader["ClubName"].ToString() ?? "";
                    c.City = reader["City"].ToString() ?? "";
                    c.Stadium = reader["Stadium"].ToString() ?? "";
                    list.Add(c);
                }
            }
            return list;
        }

        public ClubData? GetClubById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string sql = "SELECT ClubID, ClubName, City, Stadium FROM Club WHERE ClubID = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    ClubData c = new ClubData();
                    c.ClubID = Convert.ToInt32(reader["ClubID"]);
                    c.ClubName = reader["ClubName"].ToString() ?? "";
                    c.City = reader["City"].ToString() ?? "";
                    c.Stadium = reader["Stadium"].ToString() ?? "";
                    return c;
                }
            }
            return null;
        }

        public void InsertClub(ClubData club)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string sql = "INSERT INTO Club (ClubName, City, Stadium) VALUES (@name, @city, @stadium)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", club.ClubName);
                cmd.Parameters.AddWithValue("@city", club.City);
                cmd.Parameters.AddWithValue("@stadium", club.Stadium);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateClub(ClubData club)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string sql = "UPDATE Club SET ClubName = @name, City = @city, Stadium = @stadium WHERE ClubID = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", club.ClubID);
                cmd.Parameters.AddWithValue("@name", club.ClubName);
                cmd.Parameters.AddWithValue("@city", club.City);
                cmd.Parameters.AddWithValue("@stadium", club.Stadium);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteClub(int id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string sql = "DELETE FROM Club WHERE ClubID = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ==========================================
        // 2. MANAGER CRUD
        // ==========================================
        public List<ManagerData> GetAllManagers()
        {
            List<ManagerData> list = new List<ManagerData>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string sql = "SELECT ManagerID, FirstName, LastName, TacticalStyle, ClubID FROM Manager";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ManagerData m = new ManagerData();
                    m.ManagerID = Convert.ToInt32(reader["ManagerID"]);
                    m.FirstName = reader["FirstName"].ToString() ?? "";
                    m.LastName = reader["LastName"].ToString() ?? "";
                    m.TacticalStyle = reader["TacticalStyle"].ToString() ?? "";
                    m.ClubID = reader["ClubID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ClubID"]);
                    list.Add(m);
                }
            }
            return list;
        }

        public ManagerData? GetManagerById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string sql = "SELECT ManagerID, FirstName, LastName, TacticalStyle, ClubID FROM Manager WHERE ManagerID = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    ManagerData m = new ManagerData();
                    m.ManagerID = Convert.ToInt32(reader["ManagerID"]);
                    m.FirstName = reader["FirstName"].ToString() ?? "";
                    m.LastName = reader["LastName"].ToString() ?? "";
                    m.TacticalStyle = reader["TacticalStyle"].ToString() ?? "";
                    m.ClubID = reader["ClubID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ClubID"]);
                    return m;
                }
            }
            return null;
        }

        public void InsertManager(ManagerData manager)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string sql = "INSERT INTO Manager (FirstName, LastName, TacticalStyle, ClubID) VALUES (@first, @last, @style, @clubId)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@first", manager.FirstName);
                cmd.Parameters.AddWithValue("@last", manager.LastName);
                cmd.Parameters.AddWithValue("@style", manager.TacticalStyle);
                cmd.Parameters.AddWithValue("@clubId", manager.ClubID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateManager(ManagerData manager)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string sql = "UPDATE Manager SET FirstName = @first, LastName = @last, TacticalStyle = @style, ClubID = @clubId WHERE ManagerID = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", manager.ManagerID);
                cmd.Parameters.AddWithValue("@first", manager.FirstName);
                cmd.Parameters.AddWithValue("@last", manager.LastName);
                cmd.Parameters.AddWithValue("@style", manager.TacticalStyle);
                cmd.Parameters.AddWithValue("@clubId", manager.ClubID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteManager(int id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string sql = "DELETE FROM Manager WHERE ManagerID = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ==========================================
        // 3. PLAYER CRUD
        // ==========================================
        public List<PlayerData> GetAllPlayers()
        {
            List<PlayerData> list = new List<PlayerData>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string sql = "SELECT PlayerID, FirstName, LastName, Position, ClubID FROM Player";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PlayerData p = new PlayerData();
                    p.PlayerID = Convert.ToInt32(reader["PlayerID"]);
                    p.FirstName = reader["FirstName"].ToString() ?? "";
                    p.LastName = reader["LastName"].ToString() ?? "";
                    p.Position = reader["Position"].ToString() ?? "";
                    p.ClubID = reader["ClubID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ClubID"]);
                    list.Add(p);
                }
            }
            return list;
        }

        public PlayerData? GetPlayerById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string sql = "SELECT PlayerID, FirstName, LastName, Position, ClubID FROM Player WHERE PlayerID = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    PlayerData p = new PlayerData();
                    p.PlayerID = Convert.ToInt32(reader["PlayerID"]);
                    p.FirstName = reader["FirstName"].ToString() ?? "";
                    p.LastName = reader["LastName"].ToString() ?? "";
                    p.Position = reader["Position"].ToString() ?? "";
                    p.ClubID = reader["ClubID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ClubID"]);
                    return p;
                }
            }
            return null;
        }

        public void InsertPlayer(PlayerData player)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string sql = "INSERT INTO Player (FirstName, LastName, Position, ClubID) VALUES (@first, @last, @pos, @clubId)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@first", player.FirstName);
                cmd.Parameters.AddWithValue("@last", player.LastName);
                cmd.Parameters.AddWithValue("@pos", player.Position);
                cmd.Parameters.AddWithValue("@clubId", player.ClubID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdatePlayer(PlayerData player)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string sql = "UPDATE Player SET FirstName = @first, LastName = @last, Position = @pos, ClubID = @clubId WHERE PlayerID = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", player.PlayerID);
                cmd.Parameters.AddWithValue("@first", player.FirstName);
                cmd.Parameters.AddWithValue("@last", player.LastName);
                cmd.Parameters.AddWithValue("@pos", player.Position);
                cmd.Parameters.AddWithValue("@clubId", player.ClubID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeletePlayer(int id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string sql = "DELETE FROM Player WHERE PlayerID = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}