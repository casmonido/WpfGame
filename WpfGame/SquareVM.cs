using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame
{
    public class SquareVM
    {
        private Square model;
        public double X { get; }
        public double Y { get; }
        public static double Width { get; } = MainWindow.UNIT;
        public static double Height { get; } = MainWindow.UNIT;
        public String ImgSrc { get; }

        public SquareVM(Square s)
        {
            model = s;
            X = s.X * MainWindow.UNIT;
            Y = s.Y * MainWindow.UNIT;
            ImgSrc = s.ImgSrc;
        }
    }
}
