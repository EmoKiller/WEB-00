using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUserManager
{
    public enum Server
    {
        Server1 = 1,
        Server2 = 2,
        Server3 = 3,
        Server4 = 4
    }
    public enum Rank
    {
        Bronze = 1,
        Silver = 2,
        Gold = 3,
        Plantium = 4,
        Diamond = 5
    }
    class User
    {

        public int Id { get;}
        public string Name { get; set; }
        public Server Server { get; set; }
        public int Gold { get; set; }
        public int Level { get; set; }
        public Rank Rank { get; set;}
        public User()
        {
            Id = GetHashCode();
        }

        public override string ToString()
        {
            string info = $"Id: {this.Id} \n" +
                          $"Name: {this.Name}\n" +
                          $"Server: {this.Server}\n" +
                          $"Gold: {this.Gold}\n" +
                          $"Rank: {this.Rank.ToString()}\n" +
                          $"Level: {this.Level}\n";
            return info;
        }
    }
}
