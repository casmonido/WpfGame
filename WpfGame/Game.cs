using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame
{
    public class Game : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool gameWon = false;
        public bool GameWon
        {
            get
            {
                return gameWon;
            }
            set
            {
                if (gameWon != value)
                {
                    gameWon = value;
                    NotifyPropertyChanged("GameWon");
                }
            }
        }
        public Whose WhoWon = Whose.nobodys;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public Board Board { get; private set; }
        public Player Player { get; private set; }
        public Player Computer { get; private set; }
        public Dice Dice { get; private set; }
        private Whose turn = Whose.players;
        public Whose Turn
        {
            get
            {
                return turn;
            }
            set
            {
                if (turn != value && !gameWon)
                {
                    turn = value;
                    NotifyPropertyChanged("Turn");
                }
            }
        }
        private bool rolled = false;
        public bool Rolled {
            get
            {
                return rolled;
            }
            set
            {
                if (rolled != value && !gameWon)
                {
                    rolled = value;
                    NotifyPropertyChanged("Rolled");
                }
            }
        }

    
        public Game()
        {
            Board = new Board();
            Player = new Player(Whose.players, Board, this);
            Computer = new Player(Whose.computers, Board, this);
            Dice = new Dice(this);
        }

        public void changeTurn()
        {
            if (GameWon)
                return;
            Turn = Turn == Whose.players ? Whose.computers : Whose.players;
            Rolled = false;
        }

        public void setGameWon(Whose whoWon)
        {
            WhoWon = whoWon;
            GameWon = true;
        }
    }
}
