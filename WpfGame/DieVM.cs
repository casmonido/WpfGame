using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame
{
    public class DieVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private static string IMG_UP = "/img/diceup.gif";
        private static string IMG_DOWN = "/img/dicedown.gif";
        public String ImgSrc { get; private set; }
        public int Lp { get; private set; }
        private Die model;
        public DieVM(Die d, int lp)
        {
            model = d;
            d.PropertyChanged += (sender, e) =>
            {
                ImgSrc = model.getRolledNum() == 0 ? IMG_DOWN : IMG_UP;
                NotifyPropertyChanged("ImgSrc");
            };
            ImgSrc = d.getRolledNum() == 0 ? IMG_DOWN : IMG_UP;
            Lp = lp;
        }

        void changeItemOnClick(object sender, EventArgs e)
        {
            ImgSrc = model.getRolledNum() == 0 ? IMG_DOWN : IMG_UP;
            NotifyPropertyChanged("ImgSrc");
        }
    }
}
