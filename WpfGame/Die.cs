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
        public int rolledNum = 0; 
        protected Random random = new Random(Guid.NewGuid().GetHashCode());
        public int Roll()
        {
            rolledNum = random.Next(0, 2);
            NotifyPropertyChanged("rolledNum");
            return rolledNum;
        }

        public int getRolledNum()
        {
            return rolledNum;
        }
    }
}
