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
    public class Piece: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private double x;
        public double X
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
        private double y;
        public double Y
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
        public static double Width { get; } = 50;
        public static double Height { get; } = 50;
        public String Color { get; set; }

        public Piece(double x, double y, String color)
        {
            X = x;
            Y = y;
            Color = color;
            Action<object> messageTarget = delegate (object s) {
                this.X = 50;
                this.Y = 150;
                //MessageBox.Show(X.ToString());
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
