using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfGame
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int NUM_PIECES = 7;
        private ObservableCollection<Piece> items;

        public MainWindow()
        {
            InitializeComponent();

            Square square = new Square();
            //square.CircleList = new List<Piece>() { new Piece() };
            
            _shapes.Add(square);
            
            items = new ObservableCollection<Piece>();
            for (int i=0; i < NUM_PIECES; i++)
                items.Add(new Piece(100*i, 50, i%2==0?"Black":"White"));
            ViewModel vm = new ViewModel();
            vm.items = items;
            pieces.ItemsSource = vm.items;
        }

        private List<Square> _shapes = new List<Square>();

        public List<Square> Shapes
        {
            get { return _shapes; }
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
