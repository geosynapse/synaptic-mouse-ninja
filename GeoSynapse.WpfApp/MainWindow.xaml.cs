using System.Windows;
using System.Drawing;

namespace GeoSynapse.WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MoveMousePointer(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Cursor.Position = new System.Drawing.Point(5, 5);
        }
    }
}
