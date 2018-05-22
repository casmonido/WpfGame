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

        public Piece()
        {
            X = 45;
            Y = 100;
            Width = 50;
            Height = 50;
        }
        /*
        public Ellipse ellipse;



       public static readonly DependencyProperty XProperty =
            DependencyProperty.Register("X", typeof(int), typeof(Piece),
            new FrameworkPropertyMetadata(0));

        public int X
        {
            get { return (int) ellipse.GetValue(XProperty); }
            set { ellipse.SetValue(XProperty, value); }
        }
        */
    }
}
