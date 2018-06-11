using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WpfGame
{
    /// <summary>
    /// Logika interakcji dla klasy SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public string BackColor { get; private set; } = "Blue";
        public string FrontColor { get; private set; } = "White";
        public MessageBoxResult Result { get; private set; } = MessageBoxResult.Cancel;

        public SettingsWindow()
        {
            InitializeComponent();
            colorPicker.setSelected(BackColor, FrontColor);
        }

        public void _Accept(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.Yes;
            ColorScheme cs = (ColorScheme) colorPicker.colorList.SelectedItem;
            BackColor = cs.BackColor;
            FrontColor = cs.FrontColor;
            this.Hide();
        }

        public void _Cancel(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.Cancel;
            this.Hide();
        }
    }
}
