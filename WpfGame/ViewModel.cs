using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfGame
{
    class ViewModel
    {
        public ObservableCollection<Piece> items { get; set; }

        public ViewModel()
        {
            
        }
    }
}
