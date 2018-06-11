using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame.models
{
    public class Board
    {
        public static int PATH_LEN = 14;
        public List<Square> squares = new List<Square>();
        private Square[] playersPath = new Square[PATH_LEN], computersPath = new Square[PATH_LEN];
        public Board()
        {
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
            playersPath[0] = squares[3];
            playersPath[1] = squares[2];
            playersPath[2] = squares[1];
            playersPath[3] = squares[0];
            playersPath[4] = squares[4];
            playersPath[5] = squares[5];
            playersPath[6] = squares[6];
            playersPath[7] = squares[7];
            playersPath[8] = squares[18];
            playersPath[9] = squares[19];
            playersPath[10] = squares[14];
            playersPath[11] = squares[15];
            playersPath[12] = squares[13];
            playersPath[13] = squares[12];

            computersPath[0] = squares[11];
            computersPath[1] = squares[10];
            computersPath[2] = squares[9];
            computersPath[3] = squares[8];
            computersPath[4] = squares[4];
            computersPath[5] = squares[5];
            computersPath[6] = squares[6];
            computersPath[7] = squares[7];
            computersPath[8] = squares[18];
            computersPath[9] = squares[19];
            computersPath[10] = squares[14];
            computersPath[11] = squares[15];
            computersPath[12] = squares[17];
            computersPath[13] = squares[16];
        }

        public Square getNextLocation(Piece p, int i)
        {
            if (i <= 0 || i > PATH_LEN)
                return p.startingSquare;
            if (p.Owner == Whose.players)
                return playersPath[i-1];
            return computersPath[i-1];
        }
    }
}
