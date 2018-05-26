using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame
{
    public class Square 
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Size { get; private set;  }
        public string ImgSrc { get; private set; }

        public event Action<Whose, Square> CommandLeave;

        public void tryAndOccupy()
        {

        }

        public Square(int tx, int ty, String img, int size=1)
        {
            X = tx;
            Y = ty;
            ImgSrc = img;
            Size = size;
        }
    }
}
