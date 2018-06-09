﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static WpfGame.Square;

namespace WpfGame
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(Game game)
        {
            InitializeComponent();
            this.DataContext = new GameVM(game);
            BoardVM boardVM = new BoardVM(game.Board, game.Player.Pieces, game.Computer.Pieces);
            DiceVM diceVM = new DiceVM(game.Dice, game);
            board.ItemsSource = boardVM.compositeCollection;
            dice.ItemsSource = diceVM.dice;
            diceButton.DataContext = diceVM;
        }

        public void _Open(object sender, RoutedEventArgs e)
        {
            string messageBoxText = "----";
            string caption = "Settings";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBox.Show(messageBoxText, caption, button, icon);
        }
    }
}
