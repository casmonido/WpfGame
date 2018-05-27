using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame
{
    public class Board
    {
        public List<Square> squares = new List<Square>();
        public List<Square> extraSquares = new List<Square>();
        public Board()
        {
            extraSquares.Add(new Square(0, 0, "Pink", 8));
            extraSquares.Add(new Square(0, 4, "Pink", 8));
            int [] srcs = {4, 5, 1, 5,
                           3, 1, 6, 4,
                           4, 5, 1, 5};
            for (int j = 0; j < 3; j++)
                for (int i = 0; i < 4; i++)
                    squares.Add(new Square(i, j+1, "/img/square" + srcs[i+j*4] + ".png"));
            int[] srcs1 = {4, 2,
                           5, 1,
                           4, 2};
            for (int j = 0; j < 3; j++)
                for (int i = 0; i < 2; i++)
                    squares.Add(new Square(i + 6, j + 1, "/img/square" + srcs1[i + j * 2] + ".png"));
            squares.Add(new Square(4, 2, "/img/square1.png"));
            squares.Add(new Square(5, 2, "/img/square6.png"));
        }

        public Square getNextLocation(Whose whosePath, int i)
        {
            if (i == 0)
                return extraSquares[0];
            if (i > squares.Count)
                return extraSquares[1];
            return squares[i-1];
        }
    }
}
