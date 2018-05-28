using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace WpfGame
{
    public class PieceVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        /*
        public static readonly RoutedEvent MovedEvent =
        EventManager.RegisterRoutedEvent("Moved", RoutingStrategy.Tunnel,
            typeof(RoutedEventHandler), typeof(PieceVM));
        */

    private int x;
        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                if (value != this.x)
                {
                    this.x = value;
                    NotifyPropertyChanged("X");
                }
            }
        }
        private int y;
        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                if (value != this.y)
                {
                    this.y = value;
                    NotifyPropertyChanged("Y");
                }
            }
        }
        public String Color { get; private set; }
        private Piece model;

        public PieceVM(Piece p, int pos)
        {
            model = p;
            p.PropertyChanged += (sender, e) =>
            {
                X = p.Location.X;
                Y = p.Location.Y;
            };
            X = p.Location.X;
            Y = p.Location.Y;
            Color = model.Owner==Whose.computers ? "Black":"White";
            Action<object> messageTarget = delegate (object s) {
                model.move(1);
            };
            MoveOnClick = new MovePieceCommand(messageTarget);

        }

        public MovePieceCommand MoveOnClick { get; set; }

        public class MovePieceCommand : ICommand
        {
            private Action<object> execute;
            public MovePieceCommand(Action<object> execute)
            {
                this.execute = execute;
            }
            public void Execute(object parameter)
            {
                this.execute(parameter);
            }
            public bool CanExecute(object parameter)
            {
                return true;
            }
            public event EventHandler CanExecuteChanged;
        }
    }
}
