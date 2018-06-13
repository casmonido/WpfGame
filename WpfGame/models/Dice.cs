using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace WpfGame.models
{
    public class Dice: Die
    {
        public static int DIE_NUM = 4;
        private Game game;
        public List<IDie> dice;

        private DispatcherTimer timer = new DispatcherTimer();

        public Dice(Game g, List<IDie> d)
        {
            game = g;
            dice = d;
        }

        new public int Roll()
        {
            if (game.Rolled)
                return RolledNum;
            RolledNum = 0;
            for (int i = 0; i < dice.Count; ++i)
                RolledNum += dice[i].Roll();
            if (RolledNum == 0)
            {
                timer.Tick += changeRoundOnTick;
                timer.Interval = new TimeSpan(0, 0, 1);
                timer.Start();
            }
            game.Rolled = true;
            return RolledNum;
        }

        private void changeRoundOnTick(object sender, EventArgs e)
        {
            timer.Tick -= changeRoundOnTick;
            game.changeTurn();
        }
    }
}
