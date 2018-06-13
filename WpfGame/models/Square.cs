using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame.models
{
    public class Square 
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int ImgNr { get; private set; }
        public event Action<Whose, Square> CommandLeave;
        public Whose Whose { get; private set; } = Whose.nobodys;

        public OccupyResponses tryAndOccupy(Piece p)
        {
            if (Whose != Whose.nobodys && Whose == p.Owner)
                return OccupyResponses.NOT_OK;
            if (CommandLeave != null)
                CommandLeave(Whose, this);
            CommandLeave += p.HandleCommandLeave;
            Whose = p.Owner;
            return OccupyResponses.OK;
        }

        public void leave(Piece p)
        {
            CommandLeave -= p.HandleCommandLeave;
            Whose = Whose.nobodys;
        }

        public Square(int tx, int ty, int imgNr)
        {
            X = tx;
            Y = ty;
            ImgNr = imgNr;
        }
    }
}
