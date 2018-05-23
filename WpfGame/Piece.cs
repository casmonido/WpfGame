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
        computers, players
    }

    public class Piece
    {
        private int pathCrossed = 0;
        private bool wholePathCrossed = false;
        public Whose Owner { get; private set; }
        public Square Location { get; private set; }

        public Piece(Whose o, Square l)
        {
            Owner = o;
            Location = l;
        }
    }
}
