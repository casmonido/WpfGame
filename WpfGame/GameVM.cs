using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

namespace WpfGame
{
    public class GameVM : INotifyPropertyChanged
    {
        private static string YOUR_TURN = "Your turn";
        private static string OTHERS_TURN = "Computer's turn";
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private Game model;
        private string whoseTurnText = YOUR_TURN;
        public string WhoseTurnText
        {
            get
            {
                return whoseTurnText;
            }
            set
            {
                if (whoseTurnText.Equals(value))
                {
                    whoseTurnText = value;
                    NotifyPropertyChanged("WhoseTurnText");
                }
            }
        }
        public GameVM(Game g)
        {
            model = g;
            model.PropertyChanged += (sender, e) =>
            {
                if (!e.PropertyName.Equals("Turn"))
                    return;
                if (model.Turn == Whose.computers)
                    WhoseTurnText = OTHERS_TURN;
                else
                    WhoseTurnText = YOUR_TURN;
                return;
            };
        }
    }
}
