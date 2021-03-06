﻿using System;
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
using WpfGame.models;

namespace WpfGame.viewmodels
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
        private string color = "";
        public string Color
        {
            get
            {
                return color;
            }
            private set
            {
                if (!color.Equals(value))
                {
                    color = value;
                    NotifyPropertyChanged("Color");
                }
            }
        }
        private Piece model;

        public PieceVM(Piece p, int pos)
        {
            model = p;
            p.PropertyChanged += (sender, e) =>
            {
                if (!e.PropertyName.Equals("Location"))
                    return;
                X = p.Location.X;
                Y = p.Location.Y;
            };
            p.PropertyChanged += (sender, e) =>
            {
                if (!e.PropertyName.Equals("WholePathCrossed") || !model.WholePathCrossed)
                    return;
                Color = "Red";
            };
            X = p.Location.X;
            Y = p.Location.Y;
            Color = model.Owner==Whose.computers ? "Black":"White";
            Action<object> messageTarget = delegate (object s) {
                model.tryMove();
            };
            MoveOnClick = new ExecuteAction(messageTarget);
        }

        public ExecuteAction MoveOnClick { get; set; }
    }
}
