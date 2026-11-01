using MinorProject5.Api.Data;
using MinorProject5.Api.Models;

namespace MinorProject5.Api.Business
{
    public class BusinessLayer
    {
        private DataLayer db = new DataLayer();

        // ==========================================
        // 1. CLUB BUSINESS METHODS
        // ==========================================
        public List<ClubServiceModel> GetClubs()
        {
            List<ClubData> dataList = db.GetAllClubs();
            List<ClubServiceModel> result = new List<ClubServiceModel>();

            foreach (ClubData c in dataList)
            {
                ClubServiceModel model = new ClubServiceModel();
                model.ClubID = c.ClubID;
                model.ClubName = c.ClubName;
                model.City = c.City;
                model.Stadium = c.Stadium;
                result.Add(model);
            }
            return result;
        }

        public ClubServiceModel? GetClub(int id)
        {
            ClubData? c = db.GetClubById(id);
            if (c == null) return null;

            ClubServiceModel model = new ClubServiceModel();
            model.ClubID = c.ClubID;
            model.ClubName = c.ClubName;
            model.City = c.City;
            model.Stadium = c.Stadium;
            return model;
        }

        // Combines Insert and Update into one Save method (Requirement 3c)
        public void SaveClub(ClubServiceModel model)
        {
            ClubData data = new ClubData();
            data.ClubID = model.ClubID;
            data.ClubName = model.ClubName;
            data.City = model.City;
            data.Stadium = model.Stadium;

            if (model.ClubID == 0)
            {
                db.InsertClub(data);
            }
            else
            {
                db.UpdateClub(data);
            }
        }

        public void DeleteClub(int id)
        {
            db.DeleteClub(id);
        }

        // ==========================================
        // 2. MANAGER BUSINESS METHODS
        // ==========================================
        public List<ManagerServiceModel> GetManagers()
        {
            List<ManagerData> dataList = db.GetAllManagers();
            List<ManagerServiceModel> result = new List<ManagerServiceModel>();

            foreach (ManagerData m in dataList)
            {
                ManagerServiceModel model = new ManagerServiceModel();
                model.ManagerID = m.ManagerID;
                model.FirstName = m.FirstName;
                model.LastName = m.LastName;
                model.FullName = m.FirstName + " " + m.LastName;
                model.TacticalStyle = m.TacticalStyle;
                model.ClubID = m.ClubID;
                result.Add(model);
            }
            return result;
        }

        public ManagerServiceModel? GetManager(int id)
        {
            ManagerData? m = db.GetManagerById(id);
            if (m == null) return null;

            ManagerServiceModel model = new ManagerServiceModel();
            model.ManagerID = m.ManagerID;
            model.FirstName = m.FirstName;
            model.LastName = m.LastName;
            model.FullName = m.FirstName + " " + m.LastName;
            model.TacticalStyle = m.TacticalStyle;
            model.ClubID = m.ClubID;
            return model;
        }

        public void SaveManager(ManagerServiceModel model)
        {
            ManagerData data = new ManagerData();
            data.ManagerID = model.ManagerID;
            data.FirstName = model.FirstName;
            data.LastName = model.LastName;
            data.TacticalStyle = model.TacticalStyle;
            data.ClubID = model.ClubID;

            if (model.ManagerID == 0)
            {
                db.InsertManager(data);
            }
            else
            {
                db.UpdateManager(data);
            }
        }

        public void DeleteManager(int id)
        {
            db.DeleteManager(id);
        }

        // ==========================================
        // 3. PLAYER BUSINESS METHODS
        // ==========================================
        public List<PlayerServiceModel> GetPlayers()
        {
            List<PlayerData> dataList = db.GetAllPlayers();
            List<PlayerServiceModel> result = new List<PlayerServiceModel>();

            foreach (PlayerData p in dataList)
            {
                PlayerServiceModel model = new PlayerServiceModel();
                model.PlayerID = p.PlayerID;
                model.FirstName = p.FirstName;
                model.LastName = p.LastName;
                model.FullName = p.FirstName + " " + p.LastName;
                model.Position = p.Position;
                model.ClubID = p.ClubID;
                result.Add(model);
            }
            return result;
        }

        public PlayerServiceModel? GetPlayer(int id)
        {
            PlayerData? p = db.GetPlayerById(id);
            if (p == null) return null;

            PlayerServiceModel model = new PlayerServiceModel();
            model.PlayerID = p.PlayerID;
            model.FirstName = p.FirstName;
            model.LastName = p.LastName;
            model.FullName = p.FirstName + " " + p.LastName;
            model.Position = p.Position;
            model.ClubID = p.ClubID;
            return model;
        }

        public void SavePlayer(PlayerServiceModel model)
        {
            PlayerData data = new PlayerData();
            data.PlayerID = model.PlayerID;
            data.FirstName = model.FirstName;
            data.LastName = model.LastName;
            data.Position = model.Position;
            data.ClubID = model.ClubID;

            if (model.PlayerID == 0)
            {
                db.InsertPlayer(data);
            }
            else
            {
                db.UpdatePlayer(data);
            }
        }

        public void DeletePlayer(int id)
        {
            db.DeletePlayer(id);
        }
    }
}