using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame
{
    public class Piece
    {
        public double Diameter { get; private set; }

        public Piece(double diameter)
        {
            Diameter = diameter;
        }
    }
}
