using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace WpfGame
{
    public class Player
    {
        public static int NUM_PIECES = 6;
        public ObservableCollection<Piece> Pieces { get; private set; }
        private Game game;
        private Whose who;
        private int score = 0;
        private Random rand = new Random();

        private DispatcherTimer timer = new DispatcherTimer();


        private void rollOnTick(object sender, EventArgs e)
        {
            game.Dice.Roll();
            timer.Tick -= rollOnTick;
            timer.Tick += moveOnTick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void moveOnTick(object sender, EventArgs e)
        {
            timer.Tick -= moveOnTick;
            int i;
            do
            {
                i = rand.Next(0, NUM_PIECES);
            } while (Pieces[i].WholePathCrossed);
            move(Pieces[i]);
        }

        public Player(Whose w, Board boardModel, Game g)
        {
            game = g;
            who = w;
            Pieces = new ObservableCollection<Piece>();
            int tmp = who == Whose.computers ? 4 : 0;
            for (int i = 0; i < NUM_PIECES; i++)
                Pieces.Add(new Piece(who, boardModel, new StartingSquare(i+1, tmp, "Transparent"), this));
            if (who == Whose.computers)
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

        public void move(Piece p)
        {
            if (game.Turn != who || !game.Rolled)
                return;
            p.move(game.Dice.RolledNum);
            if (p.PathCrossed > Board.PATH_LEN)
            {
                p.WholePathCrossed = true;
                score++;
                if (score == NUM_PIECES)
                    game.setGameWon(this.who);
            }
            game.changeTurn();
        }
    }
}
