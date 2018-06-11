using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace WpfGame
{
    public enum Whose
    {
        computers, players, nobodys
    }

    public class Piece : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public void HandleCommandLeave(Whose w, Square s)
        {
            if (w != Owner || Location != s)
                return;
            PathCrossed = 0;
            Location = board.getNextLocation(this, PathCrossed);
        }
        public int PathCrossed { get; private set; } = 0;
        private bool wholePathCrossed = false;
        public bool WholePathCrossed
        {
            get
            {
                return wholePathCrossed;
            }
            set
            {
                if (value != wholePathCrossed)
                {
                    wholePathCrossed = value;
                    NotifyPropertyChanged("WholePathCrossed");
                }
            }
        }
        public Whose Owner { get; private set; }
        private Player player;
        private Square location;
        public Square Location {
            get
            {
                return location;
            }
            private set
            {
                if (!location.Equals(value))
                {
                    location = value;
                    NotifyPropertyChanged("Location");
                }
            }    
        }
        public StartingSquare startingSquare;
        private Board board;

        public Piece(Whose o, Board b, StartingSquare initialLoc, Player p)
        {
            player = p;
            Owner = o;
            startingSquare = initialLoc;
            location = initialLoc;
            board = b;
        }

        public void tryMove()
        {
            player.move(this);
        }

        public OccupyResponses move(int howMuch)
        {
            if (howMuch == 0)
                return OccupyResponses.OK;
            Square scr = board.getNextLocation(this, PathCrossed + howMuch);
            OccupyResponses response = scr.tryAndOccupy(this);
            if (response == OccupyResponses.OK)
            {
                Location.leave(this);
                Location = scr;
                PathCrossed += howMuch;
            }
            return response;
        }
    }
    public enum OccupyResponses
    {
        OK, NOT_OK
    }
}
