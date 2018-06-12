using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame.viewmodels
{
    class SettingsVM : INotifyPropertyChanged
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

    }
}
