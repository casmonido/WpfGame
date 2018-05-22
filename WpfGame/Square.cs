using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame
{
    public class Square 
    {
        public List<Piece> PiecesList { get; set; }

        public double X { get; set; }
        public double Y { get; set; }
        public static double Width { get; } = 100;
        public static double Height { get; } = 100;
        public String Color { get; set; }

        public class TempData
        {
            private static int WIDTH = 100;
            public double x;
            public double y;
            public String image;
            public TempData(double tx, double ty, String img)
            {
                x = tx* WIDTH;
                y = ty* WIDTH;
                image = img;
            }
        }

        public Square(TempData d)
        {
            X = d.x;
            Y = d.y;
            Color = d.image;
        }
    }
}
