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
        public MainWindow(Board b, Player ap, Player bp, Dice dice)
        {
            InitializeComponent();
            BoardVM boardVM = new BoardVM(b, ap, bp);
            DiceVM diceVM = new DiceVM(dice);
            board.ItemsSource = boardVM.compositeCollection;
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
