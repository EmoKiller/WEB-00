using System.Text;

namespace MyUserManager
{
    class Program
    {
        static void Main(string[] args)
        { 
            Console.OutputEncoding = Encoding.UTF8;
            UI.Instance.MainMenu();
        }
    }
}
