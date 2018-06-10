using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame
{
    public class ColorScheme
    {
        public string Background { get; private set; } = "Blue";
        public string Forecolor { get; private set; } = "White";
        public ColorScheme(string b, string f)
        {
            Background = b;
            Forecolor = f;
        }
    }
}
