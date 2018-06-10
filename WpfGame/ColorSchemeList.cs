using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame
{
    class ColorSchemeList
    {
        ObservableCollection<ColorScheme> list = new ObservableCollection<ColorScheme>();
        ColorSchemeList()
        {
            list.Add(new ColorScheme("Coral", "Aliceblue"));
        }
    }
}
