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
        private string backColor = "Pink";
        public string BackColor
        {
            get
            {
                return backColor;
            }
            private set
            {
                if (backColor != value)
                {
                    backColor = value;
                    NotifyPropertyChanged("BackColor");
                }
            }
        }
        private static string YOUR_TURN = "Your turn";
        private static string OTHERS_TURN = "Computer's turn";
        private static string YOU_WON = "You won";
        private static string OTHER_WON = "Computer won!";
        public BoardVM BoardVM { get; private set; }
        public DiceVM DiceVM { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private string textolor = "White";
        public string Textcolor
        {
            get
            {
                return textolor;
            }
            set
            {
                if (!textolor.Equals(value))
                {
                    textolor = value;
                    NotifyPropertyChanged("Textcolor");
                }
            }
        }
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
        public void setColors(string backColor)
        {
            BackColor = backColor;
        }
        public GameVM(Game g)
        {
            model = g;
            BoardVM = new BoardVM(model.Board, model.Player.Pieces, model.Computer.Pieces);
            DiceVM = new DiceVM(model.Dice, model);
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
            model.PropertyChanged += (sender, e) =>
            {
                if (!e.PropertyName.Equals("GameWon"))
                    return;
                if (!model.GameWon)
                    return;
                if (model.WhoWon == Whose.computers)
                    WhoseTurnText = OTHER_WON;
                else
                    WhoseTurnText = YOU_WON;
                Textcolor = "Red";
            };
        }
    }
}
