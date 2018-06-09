using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfGame
{
    public class DiceVM
    {
        Dice model;
        public List<DieVM> dice = new List<DieVM>();
        public DiceVM(Dice d)
        {
            model = d;
            for (int i = 0; i < d.dice.Count; ++i)
                dice.Add(new DieVM(d.dice[i], i));
            Action<object> messageTarget = delegate (object s) {
                model.Roll();
            };
            RollOnClick = new ExecuteAction(messageTarget);
        }

        public ExecuteAction RollOnClick { get; set; }
    }
}
