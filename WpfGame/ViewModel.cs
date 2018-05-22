using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
