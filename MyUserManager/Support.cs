using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUserManager
{
    internal class Support
    {
        static Support _instace = null;
        private Support() { }
        public static Support Instace
        {
            get
            {
                if(_instace == null)
                {
                    _instace = new Support();
                }
                return _instace;
            }
        }
        public event Action eventTopTen;
        public void InvokeEvent()
        {
            UserManager.Instance.SubEvent();
            eventTopTen?.Invoke();
        }
        public void Line(int number)
        {
            while (number > 0)
            {
                Console.Write("=");
                number--;
            }
            Console.WriteLine();
        }
        public string InputString(string txt)
        {
            Console.Write(txt);
            return StringHandler(Console.ReadLine());
        }
        public int InputInt(string txt)
        {
            
            while (true)
            {
                Console.Write(txt);
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    return number;
                }
                Console.WriteLine("nhập sai định dạng, nhấn phím bất kì để nhập lại!");
                Console.ReadKey();
            }
        }
        public User FindUserById(int id)
        {
           return UserManager.Instance.users.SingleOrDefault(user => user.Id == id);
        }
        string StringHandler(string txt)
        {
            txt = txt.Trim();
            while(txt.IndexOf("  ") != -1)
            {
                txt = txt.Replace("  ", " ");
            }
            return txt;
        }
        public void PrintUsers(List<User> users)
        {
            if(users.Count != 0)
            {
                users.ForEach(user =>
                {
                    Line(30);
                    Console.WriteLine(user.ToString());
                    Line(30);
                });
            }
            else
            {
                Console.WriteLine("Danh sách trống!");
            }
            PressKeyToContinue();
        }
        public void PressKeyToContinue()
        {
            Console.WriteLine("Nhấn phím bất kì để tiếp tục!");
            Console.ReadKey();
        }

        // thằng này dùng để kiểm tra server hoặc rank nhập vào có đúng ko
        public void InputAndDo(Action<int> callback,string txt,int min,int max)
        {
            while (true)
            {
                int number = InputInt($"Nhập {txt}: ");
                if (number >= min && number <= max)
                {
                    callback(number);
                    break;
                }
                Console.WriteLine($"không có số {txt} này!");
                PressKeyToContinue();
            }
        }

        //thằng này dùng để kiểm tra level hoặc vàng nhập vào có đúng không
        public void InputAndDo2(Action<int> callback,string txt,int min)
        {
            while (true)
            {
                int number = Support.Instace.InputInt($"Nhập {txt}: ");
                if (number > min)
                {
                    callback(number);
                    break;
                }
                Console.WriteLine($"Nhập sai! {txt} phải lớn hơn {min}");
                Support.Instace.PressKeyToContinue();
            }
        }
        
    }
}
