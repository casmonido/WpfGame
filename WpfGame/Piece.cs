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
            pathCrossed = 0;
            Location = board.getNextLocation(this, pathCrossed);
        }
        private int pathCrossed = 0;
        private bool wholePathCrossed = false;
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
                if (location != value)
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
            Location = initialLoc;
            board = b;
        }

        public void tryMove()
        {
            player.move(this);
        }

        public void move(int howMuch)
        {
            Location.leave(this);
            Square scr = board.getNextLocation(this, pathCrossed + howMuch);
            if (scr.tryAndOccupy(this) == OccupyResponses.OK)
            {
                Location = scr;
                pathCrossed += howMuch;
            }
        }
    }
    public enum OccupyResponses
    {
        OK, ONE_MORE_HOP
    }
}
