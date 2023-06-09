using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace MyUserManager
{
    internal class UserManager
    {
        private static UserManager _instance = null;
        private UserManager() 
        {
            users = new List<User>();
            Top10ByRank = new List<User>(10);
            Top10ByLevel = new List<User>(10);
            Top10ByGold = new List<User>(10);
        }
        public static UserManager Instance 
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserManager();
                }
                return _instance;
            }
        }
        public List<User> users;
        public List<User> Top10ByRank;
        public List<User> Top10ByGold;
        public List<User> Top10ByLevel;
        
        
        public void AddUser()
        {
            User user = new User();
            Name(user);
            Server(user);
            Level(user);
            Gold(user);
            Rank(user);
            users.Add(user);
            Support.Instace.InvokeEvent();
        }
        public void ChangedInfoUser()
        {
            int idUser = Support.Instace.InputInt("Nhập Id user: ");
            User user = Support.Instace.FindUserById(idUser);
            if (user != null)
            {
                UI.Instance.ChangeUserInfoMenu(user);
            }
            else
            {
                Console.WriteLine("Không có user này! Nhấn phím bất kỳ để quay lại menu chính!");
                Console.ReadKey();
            }
            // chú ý nếu bug thì gọi thêm thằng main menu vào đây!

        }
        public void Name(User user)
        {
            if(user != null)
            user.Name = Support.Instace.InputString("Nhập tên: ");
        }
        public void Server(User user)
        {
            Action<int> action = (server) => { if (user != null) user.Server = (Server)server; };
            Support.Instace.InputAndDo(action, "server", 1, 4);
        }
        public void Level(User user)
        {
            Action<int> action = (level) => 
            {
                if (user != null) user.Level = level;
            };
            Support.Instace.InputAndDo2(action, "level", 0);

        }
        public void Gold(User user)
        {
            Action<int> action = (gold) =>
            {
                if (user != null) user.Gold = gold;
            };
            Support.Instace.InputAndDo2(action, "gold", 0);
        }
        public void Rank(User user)
        { 
            Action<int> action = (rank) => { if (user != null) user.Rank = (Rank)rank; };
            Support.Instace.InputAndDo(action, "rank", 1, 5);
        }
        public void DeleteUser()
        {
            int id = Support.Instace.InputInt("Nhập id: ");
            User user = Support.Instace.FindUserById(id);
            if (user != null)
            {
                Console.WriteLine("Đã xóa user này");
                Console.WriteLine(user.ToString());
                users.Remove(user);
                Support.Instace.InvokeEvent();
            }
            else
            {
                Console.WriteLine("Không có user này!");
            }
            Support.Instace.PressKeyToContinue();
        }
        public void ShowListInfoUser()
        {
            Support.Instace.PrintUsers(users);
        }
        public void SortListUser()
        {
            users = users.OrderBy(user => user.Server)
                 .ThenByDescending(user => user.Rank)
                 .ThenByDescending(user => user.Gold)
                 .ThenByDescending(user => user.Level)
                 .ToList();
            Console.WriteLine("Đã sắp xếp theo thứ tự ưu tiên server => rank => gold => level");
            Support.Instace.PressKeyToContinue();
        }
        public void ShowUserByServer()
        {

            Action<int> action = (server) =>
            {
                List<User> usersByServer = users.Where(user => user.Server == (Server)server).ToList();
                Support.Instace.PrintUsers(usersByServer);     
            };
            Support.Instace.InputAndDo(action, "server", 1, 4);
        }
        public void ShowUserByLevel()
        {
            Action<int> action = (level) =>
            {
                List<User> usersByLevel = users.Where(user => user.Level == level).ToList();
                Support.Instace.PrintUsers(usersByLevel);     
            };
            Support.Instace.InputAndDo2(action, "level", 0);
        }
        public void ShowUserByRank()
        {
            Action<int> action = (rank) =>
            {
                List<User> usersByRank = users.Where(user => user.Rank == (Rank)rank).ToList();
                Support.Instace.PrintUsers(usersByRank);
            };
            Support.Instace.InputAndDo(action, "rank",1,5);
        }
        public void TopTenRank()
        {
            Support.Instace.PrintUsers(Top10ByRank);
        }
        public void TopTenGold()
        {
            Support.Instace.PrintUsers(Top10ByGold);
        }
        public void TopTenLevel()
        {
            Support.Instace.PrintUsers(Top10ByLevel);
        }
        public void SubEvent()
        {
            Support.Instace.eventTopTen += SortByRank;
            Support.Instace.eventTopTen += SortByGold;
            Support.Instace.eventTopTen += SortByLevel;

        }
        public void SortByRank()
        {
            Top10ByRank = users.OrderByDescending(user => user.Rank).Take(10).ToList();
        }
        public void SortByGold()
        {
            Top10ByGold = users.OrderByDescending(user => user.Gold).Take(10).ToList();
        }
        public void SortByLevel()
        {
            Top10ByLevel = users.OrderByDescending(user => user.Level).Take(10).ToList();
            
        }
    }
}
