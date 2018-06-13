using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame.models
{
    public abstract class IDie: INotifyPropertyChanged
    {
        public virtual event PropertyChangedEventHandler PropertyChanged;
        public virtual int RolledNum
        {
            get;
            protected set;
        }
        abstract public int Roll();
    }
}
