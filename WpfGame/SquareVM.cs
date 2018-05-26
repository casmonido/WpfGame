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
        public int X { get; }
        public int Y { get; }
        public static double Width { get; } = App.UNIT;
        public static double Height { get; } = App.UNIT;
        public String ImgSrc { get; }

        public SquareVM(Square s)
        {
            model = s;
            X = s.X;
            Y = s.Y;
            ImgSrc = s.ImgSrc;
        }
    }
}
