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
        public int RolledNum { get; protected set; } = 0;
        private Random random = new Random(Guid.NewGuid().GetHashCode());

        public int Roll()
        {
            RolledNum = random.Next(0, 2);
            NotifyPropertyChanged("rolledNum");
            return RolledNum;
        }
    }
}
