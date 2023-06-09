using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MyUserManager
{
    internal class UI
    {
        private static UI instance = null;
        private UI() { }
        public static UI Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new UI();
                }
                return instance;
            }
        }
        public void MainMenu()
        {
            UIElement[] elements = new UIElement[]
            {
                new UIElement("1","Tạo tài khoản",UserManager.Instance.AddUser),
                new UIElement("2","Thay đổi thông tin tài khoản",UserManager.Instance.ChangedInfoUser),
                new UIElement("3","Xóa tài khoản",UserManager.Instance.DeleteUser),
                new UIElement("4","Hiểm thị danh sách tài khoản",UserManager.Instance.ShowListInfoUser),
                new UIElement("5","Sắp xếp ",UserManager.Instance.SortListUser),
                new UIElement("6","Hiểm thị danh sách top 10",TopTenListMenu),
                new UIElement("7","Hiểm thị danh sách theo thuộc tính",ShowUserByAttributeMenu),
                new UIElement("0","Thoát chương trình",UIManager.Instance.Exit)
            };
            UIManager.Instance.PrintMenu("Menu chính", elements);
            MainMenu();
        }
        public void ChangeUserInfoMenu(User user)
        {
            UIElement[] Elements = new UIElement[]
            {
                new UIElement("1","Thay đổi tên user",() => UserManager.Instance.Name(user)),
                new UIElement("2","Thay đổi server",() => UserManager.Instance.Server(user)),
                new UIElement("3","Thay đổi level user",() => UserManager.Instance.Level(user)),
                new UIElement("4","Thay đổi số tiền user có",() => UserManager.Instance.Gold(user)),
                new UIElement("5","Thay đổi rank",() => UserManager.Instance.Rank(user)),
                new UIElement("0","Quay lại")
            };
            UIManager.Instance.PrintMenu("Thay đổi thông tin tài khoản", Elements);
            Support.Instace.InvokeEvent();
            MainMenu();
        }
        public void TopTenListMenu()
        {
            UIElement[] elements = new UIElement[]
            {
                new UIElement("1","Top 10 player có rank cao nhất",UserManager.Instance.TopTenRank),
                new UIElement("2","Top 10 player có số vàng cao nhất",UserManager.Instance.TopTenGold),
                new UIElement("3","Top 10 player có level cao nhất",UserManager.Instance.TopTenLevel),
                new UIElement("0","Quay lại")
            };
            UIManager.Instance.PrintMenu("Top 10", elements);
            MainMenu();
        }
        public void ShowUserByAttributeMenu()
        {
            UIElement[] elements = new UIElement[]
            {
                new UIElement("1","Hiểm thị danh sách theo khu vực",UserManager.Instance.ShowUserByServer),
                new UIElement("2","Hiểm thị danh sách theo cấp độ",UserManager.Instance.ShowUserByLevel),
                new UIElement("3","Hiểm thị danh sách theo rank",UserManager.Instance.ShowUserByRank),
                new UIElement("0","Quay lại")
            };
            UIManager.Instance.PrintMenu("Hiểm thị danh sách theo thuộc tính", elements);
            MainMenu();
        }
    }
}
