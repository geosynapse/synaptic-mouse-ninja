using System.Drawing;
using System.Windows;
using System.Windows.Forms;

namespace GeoSynapse.WpfApp
{
    public partial class MainWindow : Window
    {
        private NotifyIcon? _notifyIcon;

        public MainWindow()
        {
            InitializeComponent();
            InitializeTrayIcon();
        }

        private void InitializeTrayIcon()
        {
            _notifyIcon = new NotifyIcon();
            _notifyIcon.Icon = new Icon("Images\\synaptic_tickle_64x64.ico"); // Make sure to add a valid icon file
            _notifyIcon.Visible = true;
            _notifyIcon.Text = "Synaptic Tickle";

            // Create a context menu for the tray icon
            var contextMenu = new ContextMenuStrip();
            var menuItem = new ToolStripMenuItem("Exit");
            menuItem.Click += MenuItem_Click;
            contextMenu.Items.Add(menuItem);

            _notifyIcon.ContextMenuStrip = contextMenu;

            _notifyIcon.DoubleClick += NotifyIcon_DoubleClick;
        }

        private void NotifyIcon_DoubleClick(object? sender, EventArgs e)
        {
            this.Show();
            this.WindowState = WindowState.Normal;
        }

        private void MenuItem_Click(object? sender, EventArgs e)
        {
            _notifyIcon?.Dispose();
            System.Windows.Application.Current.Shutdown();
        }

        protected override void OnStateChanged(EventArgs e)
        {
            base.OnStateChanged(e);
            if (WindowState == WindowState.Minimized)
            {
                this.Hide();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            _notifyIcon?.Dispose();
            base.OnClosed(e);
        }

        private void MoveMousePointer(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Cursor.Position = new System.Drawing.Point(5, 5);
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnHide_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}