using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace WpfGame
{
    public class Dice: Die
    {
        private static int DIE_NUM = 4;
        private Game game;
        public List<Die> dice = new List<Die>();

        private DispatcherTimer timer = new DispatcherTimer();

        public Dice(Game g)
        {
            game = g;
            for (int i = 0; i < DIE_NUM; ++i)
                dice.Add(new Die());
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
