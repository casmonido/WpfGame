using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace WpfGame.models
{
    public class Player
    {
        public static int NUM_PIECES = 6;
        public ObservableCollection<Piece> Pieces { get; private set; }
        private Game game;
        public Whose Who { get; private set; }
        private int score = 0;
        private Random rand = new Random();

        private DispatcherTimer timer = new DispatcherTimer();


        private void rollOnTick(object sender, EventArgs e)
        {
            timer.Tick -= rollOnTick;
            if (game.Dice.Roll() == 0)
                return;
            timer.Tick += moveOnTick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void moveOnTick(object sender, EventArgs e)
        {
            timer.Tick -= moveOnTick;
            OccupyResponses res;
            do
            {
                int i;
                do
                {
                    i = rand.Next(0, NUM_PIECES);
                } while (Pieces[i].WholePathCrossed);
                res = move(Pieces[i]);
            } while (res != OccupyResponses.OK);
        }

        public Player(Whose w, Board boardModel, Game g)
        {
            game = g;
            Who = w;
            Pieces = new ObservableCollection<Piece>();
            int tmp = Who == Whose.computers ? 4 : 0;
            for (int i = 0; i < NUM_PIECES; i++)
                Pieces.Add(new Piece(Who, boardModel, new Square(i+1, tmp, -1), this));
            if (Who == Whose.computers)
                game.PropertyChanged += (sender, e) =>
                {
                    if (!e.PropertyName.Equals("Turn") ||
                        game.Turn != Whose.computers)
                        return;
                    timer.Tick += rollOnTick;
                    timer.Interval = new TimeSpan(0, 0, 1);
                    timer.Start();
                };
        }

        public OccupyResponses move(Piece p)
        {
            if (game.Turn != Who || !game.Rolled || game.Dice.RolledNum == 0)
                return OccupyResponses.NOT_OK;
            OccupyResponses response = p.move(game.Dice.RolledNum);
            if (response != OccupyResponses.OK)
                return response;
            if (p.PathCrossed > Board.PATH_LEN)
            {
                p.WholePathCrossed = true;
                score++;
                if (score == NUM_PIECES)
                    game.setGameWon(this.Who);
            }
            game.changeTurn();
            return response;
        }
    }
}
