using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUserManager
{
    public class UIElement
    {
        public string Key { get;}
        public string Name { get;}
        public Action Event { get; }

        public UIElement(string key, string name, Action Event = null)
        {
            this.Key = key;
            this.Name = name;
            this.Event = Event;
        }
    }
}
