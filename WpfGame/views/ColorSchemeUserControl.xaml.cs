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
using WpfGame.viewmodels;

namespace WpfGame.views
{
    /// <summary>
    /// Logika interakcji dla klasy ColorSchemeUserControl.xaml
    /// </summary>
    public partial class ColorSchemeUserControl : UserControl
    {
        public ObservableCollection<ColorScheme> ColorSchemes { get; set; }
            = new ObservableCollection<ColorScheme>();
        private ColorScheme selected;
        public ColorScheme Selected
        {
            get
            {
                return selected;
            }
            set
            {
                if (!value.Equals(selected))
                {
                    selected = value;
                    BackColor = selected.BackColor;
                    FrontColor = selected.FrontColor;
                }
            }
        }
        private string backColor;
        public string BackColor
        {
            get
            {
                return backColor;
            }
            set
            {
                if (value != backColor)
                    backColor = value;
            }
        }
        public string FrontColor { get; set; }

        public ColorSchemeUserControl()
        {
            InitializeComponent();
            ColorSchemes.Add(new ColorScheme("Aquamarine", "CornflowerBlue"));
            ColorScheme cs = new ColorScheme("Coral", "BlanchedAlmond");
            ColorSchemes.Add(cs);
            Selected = cs;
            colorList.ItemsSource = ColorSchemes;
            DataContext = this;
        }

        public void setSelected(string bcolor, string fcolor)
        {
            ColorScheme cs = new ColorScheme(bcolor, fcolor);
            if (!ColorSchemes.Contains(cs))
                ColorSchemes.Add(cs);
            Selected = cs;
        }

    }
}
