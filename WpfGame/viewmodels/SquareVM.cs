using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfGame.models;

namespace WpfGame.viewmodels
{
    public class SquareVM
    {
        private Square model;
        public int X { get; }
        public int Y { get; }
        public int Size { get; }
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
