using System;
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
            GameVM gameVM = new GameVM(game);
            this.DataContext = gameVM;
            board.ItemsSource = gameVM.BoardVM.compositeCollection;
            dice.ItemsSource = gameVM.DiceVM.dice;
            diceButton.DataContext = gameVM.DiceVM;
        }

        public void _Settings(object sender, RoutedEventArgs e)
        {
            string messageBoxText = "----";
            string caption = "Settings";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBox.Show(messageBoxText, caption, button, icon);
        }

        public void _New(object sender, RoutedEventArgs e)
        {
            string messageBoxText = "Are you sure you want to close this game and open another?";
            string caption = "New";
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption,
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                GameVM gameVM = new GameVM(new Game()); // app powinien to stworzyć 
                this.DataContext = gameVM;
                board.ItemsSource = gameVM.BoardVM.compositeCollection;
                dice.ItemsSource = gameVM.DiceVM.dice;
                diceButton.DataContext = gameVM.DiceVM;
            }
        }

        public void _Exit(object sender, RoutedEventArgs e)
        {
            string messageBoxText = "Are you sure you want to quit this game?";
            string caption = "Exit";
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, 
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
                System.Environment.Exit(1);
        }
    }
}
