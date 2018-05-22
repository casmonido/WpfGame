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
        public static int NUM_PIECES = 7;
        public static int BOARD_LEN = 8;
        private ObservableCollection<Piece> _pieces = new ObservableCollection<Piece>();
        private ObservableCollection<Square> _board = new ObservableCollection<Square>();

        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < BOARD_LEN; i++)
                _board.Add(new Square(new TempData(i, 0, i % 2 == 0 ? "Black" : "White")));
            for (int i = 0; i < BOARD_LEN; i++)
                _board.Add(new Square(new TempData(i, 1, i % 2 == 0 ? "White" : "Black")));
            board.ItemsSource = _board;

            for (int i=0; i < NUM_PIECES; i++)
                _pieces.Add(new Piece(25 + 100*i, 25, "Blue"));
            ViewModel vm = new ViewModel();
            vm.items = _pieces;
            pieces.ItemsSource = vm.items;
        }



        public void _Open(object sender, RoutedEventArgs e)
        {
            string messageBoxText = "Do you want to save changes?";
            string caption = "Word Processor";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBox.Show(messageBoxText, caption, button, icon);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
