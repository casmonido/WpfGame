using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfGame
{
    public class DiceVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public String InfoWhatToDo { get; private set; }  = "Roll!";
        Dice model;
        public List<DieVM> dice = new List<DieVM>();

        public DiceVM(Dice d, Game game)
        {
            model = d;
            for (int i = 0; i < d.dice.Count; ++i)
                dice.Add(new DieVM(d.dice[i], i));
            Action<object> messageTarget = delegate (object s) {
                model.Roll();
            };
            game.PropertyChanged += (sender, e) =>
            {
                if (!e.PropertyName.Equals("Rolled"))
                    return;
                if (game.Turn == Whose.computers)
                {
                    InfoWhatToDo = "Computer's move ....";
                    NotifyPropertyChanged("InfoWhatToDo");
                    return;
                }
                if (game.Rolled)
                    InfoWhatToDo = "Click on one of your pieces to move";
                else
                    InfoWhatToDo = "Roll";
                NotifyPropertyChanged("InfoWhatToDo");
            };
            RollOnClick = new ExecuteAction(messageTarget);
        }

        public ExecuteAction RollOnClick { get; set; }
    }
}
