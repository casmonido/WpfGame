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
        public static double Width { get; } = 50;
        public static double Height { get; } = 50;
        public String Color { get; set; }

        public Piece(double x, double y, String color)
        {
            X = x;
            Y = y;
            Color = color;
        }
    }
}
