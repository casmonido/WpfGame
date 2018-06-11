using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame
{
    public class Die : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private int rolledNum = 0;
        public int RolledNum
        {
            get
            {
                return rolledNum;
            }
            protected set
            {
                if (rolledNum != value)
                {
                    rolledNum = value;
                    NotifyPropertyChanged("RolledNum");
                }
            }
        }
        private Random random = new Random(Guid.NewGuid().GetHashCode());

        public int Roll()
        {
            RolledNum = random.Next(0, 2);
            return RolledNum;
        }
    }
}
