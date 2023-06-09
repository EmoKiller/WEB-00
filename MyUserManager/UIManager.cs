using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUserManager
{
    class UIManager
    {
        private static UIManager instance = null;
        private UIManager() { }
        public static UIManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new UIManager();
                }
                return instance;
            }
        }

        public void PrintMenu(string title, UIElement[] elements, bool clscr = true)
        {
            if(clscr) Console.Clear();
            Support.Instace.Line(30);
            Console.WriteLine(title);
            Support.Instace.Line(30);
            foreach (UIElement element in elements)
            {
                Console.WriteLine($"{element.Key}.{element.Name}");
            }
            Support.Instace.Line(30);
            Action _event = SelectEvent(elements);
            if(_event != null) _event.Invoke(); 

        }

        Action SelectEvent(UIElement[] elements)
        {
            while(true)
            {
                Console.WriteLine("Nhập lựa chọn của bạn: ");
                string select = Console.ReadLine();
                foreach(UIElement element in elements)
                {
                    if (element.Key.Equals(select))
                    {
                        return element.Event;
                    }
                }
                Console.WriteLine("Không có lựa chọn này, nhấn phím bất kì để nhập lại!");
                Console.ReadKey();
            }
        }


        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
