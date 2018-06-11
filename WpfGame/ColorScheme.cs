using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame
{
    public class ColorScheme
    {
        public string BackColor { get; private set; } = "Blue";
        public string FrontColor { get; private set; } = "White";
        public ColorScheme(string b, string f)
        {
            BackColor = b;
            FrontColor = f;
        }
    }
}
