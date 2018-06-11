using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfGame.views
{
    /// <summary>
    /// Logika interakcji dla klasy ColorSchemeUserControl.xaml
    /// </summary>
    public partial class ColorSchemeUserControl : UserControl
    {
        ObservableCollection<ColorScheme> colorSchemes = new ObservableCollection<ColorScheme>();
        public ColorScheme Selected { get; set; }

        public ColorSchemeUserControl()
        {
            InitializeComponent();
            colorSchemes.Add(new ColorScheme("Aquamarine", "CornflowerBlue"));
            ColorScheme cs = new ColorScheme("Coral", "BlanchedAlmond");
            colorSchemes.Add(cs);
            Selected = cs;
            colorList.ItemsSource = colorSchemes;
        }

        public void setSelected(string bcolor, string fcolor)
        {
            ColorScheme cs = new ColorScheme(bcolor, fcolor);
            if (!colorSchemes.Contains(cs))
                colorSchemes.Add(cs);
            Selected = cs;
        }

    }
}
