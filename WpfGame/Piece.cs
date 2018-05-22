using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace WpfGame
{
    public class Piece
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public String Color { get; set; }

        public Piece(double x, double y, String color)
        {
            X = x;
            Y = y;
            Width = 100;
            Height = 100;
            Color = color;
        }
    }
}
