using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfGame.models;

namespace WpfGame.viewmodels
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
        private string infoWhatToDo = "Roll!";
        public string InfoWhatToDo
        {
            get
            {
                return infoWhatToDo;
            }
            private set
            {
                if (!infoWhatToDo.Equals(value))
                {
                    infoWhatToDo = value;
                    NotifyPropertyChanged("InfoWhatToDo");
                }
            }
        }
        private Dice model;
        public List<DieVM> Dice { get; set; } = new List<DieVM>();
        //public CompositeCollection Dice { get; set; } = new CompositeCollection();
        public DiceVM(Dice d, Game game)
        {
            model = d;
            for (int i = 0; i < d.dice.Count; ++i)
                Dice.Add(new DieVM(d.dice[i], i));
            Action<object> messageTarget = delegate (object s) {
                model.Roll();
            };
            game.PropertyChanged += (sender, e) =>
            {
                if (!e.PropertyName.Equals("Rolled"))
                    return;
                if (game.Turn == Whose.computers)
                    InfoWhatToDo = COMPUERS_MOVE;
                else
                {
                    if (game.Rolled)
                    {
                        if (game.Dice.RolledNum == 0)
                            InfoWhatToDo = ROLLED_ZERO;
                        else
                            InfoWhatToDo = MOVE_PIECE;
                    }
                    else
                        InfoWhatToDo = ROLL;
                }
            };
            RollOnClick = new ExecuteAction(messageTarget);
        }
        private string frontColor = "White";
        public string FrontColor
        {
            get
            {
                return frontColor;
            }
            set
            {
                if (frontColor != value)
                {
                    frontColor = value;
                    NotifyPropertyChanged("FrontColor");
                }
            }
        }
        public void setColors(string frontColor)
        {
            FrontColor = frontColor;
        }
        public ExecuteAction RollOnClick { get; set; }
        public static string COMPUERS_MOVE = "Computer's move ....";
        public static string MOVE_PIECE = "Click on one of your pieces to move";
        public static string ROLL = "Roll";
        public static string ROLLED_ZERO = "You rolled zero. Too bad!";
    }
}
