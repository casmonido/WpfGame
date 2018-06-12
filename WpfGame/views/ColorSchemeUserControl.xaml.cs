using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class ColorSchemeUserControl : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
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
                {
                    backColor = value;
                    NotifyPropertyChanged("BackColor");
                }
            }
        }
        private string frontColor;
        public string FrontColor
        {
            get
            {
                return frontColor;
            }
            set
            {
                if (value != frontColor)
                {
                    frontColor = value;
                    NotifyPropertyChanged("FrontColor");
                }
            }
        }

        public ColorSchemeUserControl()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
