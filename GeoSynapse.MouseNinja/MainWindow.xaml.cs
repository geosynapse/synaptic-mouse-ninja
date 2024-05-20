using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;

namespace GeoSynapse.MouseNinja
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public string TimePeriod
        {
            get
            {
                if (timer == null)
                    return "3:00";
                // if time.Interval is 1000 return empty string
                if (timer.Interval == 1000)
                    return string.Empty;
                return TimeIntervalToString(timer.Interval);
            }
        }

        public int Period
        {
            get
            {
                if (timer == null)
                    return 3000;
                return timer.Interval;
            }
            set
            {
                if (timer != null && timer.Interval != value)
                {
                    timer.Interval = value;
                    OnPropertyChanged("Period");
                    OnPropertyChanged("TimePeriod");                    
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected NotifyIcon? notifyIcon;
        protected System.Windows.Forms.Timer? timer;


        public string MyStringProperty
        {
            get
            {
                if (timer == null)
                    return "3000";
                return timer.Interval.ToString();
            }
        }

        public MainWindow() : this(ninjaOnStartup: false, minimizeOnStartup: false, ninja: false, period: 3) { }

        public MainWindow(bool ninjaOnStartup, bool minimizeOnStartup, bool ninja, int period)
        {
            InitializeComponent();

            DataContext = this;

            InitializeTrayIcon();
            InitializeTimer();


            // Loading data from the settings
            Period = Ninja.Default.Period;
            Console.WriteLine($"Loaded setting: {Period}");

            if (timer != null) timer.Interval = Ninja.Default.Period;
        }

        private void InitializeTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 3000;
            timer.Tick += GeoTimerTick;
            timer.Enabled = true;
        }

        private void GeoTimerTick(object? sender, EventArgs e)
        {
            // LEAVE THIS CODE HERE AS A REMINDER OF THE ORIGINAL FUNCTIONALITY FROM THE ORIGINAL PROJECT arkane-systems/mousejiggler
            //if (this.ZenJiggleEnabled)
            //    Helpers.Jiggle(delta: 0);
            //else if (this.Zig)
            //    Helpers.Jiggle(delta: 4);
            //else //zag
            //    Helpers.Jiggle(delta: -4);
            //this.Zig = !this.Zig;

            System.Drawing.Point position = System.Windows.Forms.Cursor.Position;
            Debug.WriteLine("X: " + position.X + " Y: " + position.Y);
            System.Windows.Forms.Cursor.Position = new System.Drawing.Point(position.X + 2, position.Y + 2);

            if (zenEnabled.IsChecked.HasValue && zenEnabled.IsChecked.Value)
            {
                System.Windows.Forms.Cursor.Position = new System.Drawing.Point(position.X, position.Y);
            }
            //else if (zigEnabled.IsChecked.HasValue && zigEnabled.IsChecked.Value)
            //{
            //    System.Windows.Forms.Cursor.Position = new System.Drawing.Point(position.X + 4, position.Y + 4);
            //}
            //else if (zagEnabled.IsChecked.HasValue && zagEnabled.IsChecked.Value)
            //{
            //    System.Windows.Forms.Cursor.Position = new System.Drawing.Point(position.X - 4, position.Y - 4);
            //}
            else
            {
                System.Windows.Forms.Cursor.Position = new System.Drawing.Point(position.X + 1, position.Y + 1);
            }
        }

        private void NinjaCheckedChanged(object sender, EventArgs e)
        {
            if (timer == null)
                InitializeTimer();

            if (timer != null && ninjaEnabled.IsChecked.HasValue)
                timer.Enabled = ninjaEnabled.IsChecked.Value;
        }

        private void InitializeTrayIcon()
        {
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = new System.Drawing.Icon("Images\\synaptic_ninja_64x64.ico"); // Make sure to add a valid icon file
            notifyIcon.Visible = true;
            notifyIcon.Text = "Synaptic Ninja";

            // Create a context menu for the tray icon
            var contextMenu = new ContextMenuStrip();
            var exitMenuItem = new ToolStripMenuItem("Exit");
            var zenMenuItem = new ToolStripMenuItem("Zen");
            exitMenuItem.Click += ExitMenuItemClick;
            exitMenuItem.Click += ZenMenuItemClick;
            contextMenu.Items.Add(exitMenuItem);
            contextMenu.Items.Add(zenMenuItem);
            notifyIcon.ContextMenuStrip = contextMenu;
            notifyIcon.DoubleClick += NotifyIconDoubleClick;
        }

        private void ZenMenuItemClick(object? sender, EventArgs e)
        {
            zenEnabled.IsChecked = !zenEnabled.IsChecked;
            if (zenEnabled.IsChecked.HasValue && zenEnabled.IsChecked.Value)
            {
                zzzIcon.Foreground = System.Windows.Media.Brushes.White;
            }
            else
            {
                zzzIcon.Foreground = new SolidColorBrush((System.Windows.Media.Color)ColorConverter.ConvertFromString("#444"));
            }
        }

        private void NotifyIconDoubleClick(object? sender, EventArgs e)
        {
            Show();
            WindowState = WindowState.Normal;
        }

        private void ExitMenuItemClick(object? sender, EventArgs e)
        {
            notifyIcon?.Dispose();
            System.Windows.Application.Current.Shutdown();
        }

        protected override void OnStateChanged(EventArgs e)
        {
            base.OnStateChanged(e);
            if (WindowState == WindowState.Minimized)
            {
                Hide();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            notifyIcon?.Dispose();
            base.OnClosed(e);
        }

        private void BorderMouseDown(object? sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void HideClick(object? sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void ExitClick(object? sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void ZenCheckChanged(object? sender, RoutedEventArgs e)
        {

        }
        private void NinjaCheckChanged(object? sender, RoutedEventArgs e)
        {
            if (ninjaEnabled.IsChecked.HasValue && ninjaEnabled.IsChecked.Value && timer != null)
            {
                tickIcon.Foreground = System.Windows.Media.Brushes.White;
            }
            else
            {
                tickIcon.Foreground = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#444"));
            }
        }

        private void PeriodValueChanged(object? sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sender is Slider slider)
            {
                var output = 5970 * slider.Value + 3000;


                if (timer != null)
                {
                    Period = (int)output;

                    // Persisting data to the settings
                    Ninja.Default.Period = Period;
                    Ninja.Default.Save(); // Don't forget to save the changes
                    Console.WriteLine($"Updated setting: {Ninja.Default.Period}");
                }
            }
        }

        public static string TimeIntervalToString(int input)
        {
            // Define the input and output ranges
            const int inputMin = 3000;
            const int inputMax = 600000;
            const int outputMin = 3; // in seconds
            const int outputMax = 10 * 60; // in seconds

            // Ensure the input is within the expected range
            if (input < inputMin || input > inputMax)
            {
                throw new ArgumentOutOfRangeException(nameof(input), $"Input must be between {inputMin} and {inputMax}");
            }

            // Perform the linear transformation
            double proportion = (double)(input - inputMin) / (inputMax - inputMin);
            int output = outputMin + (int)(proportion * (outputMax - outputMin));

            // Convert the output to a time string
            TimeSpan time = TimeSpan.FromSeconds(output);
            string timeString = time.ToString(@"mm\:ss");

            return timeString;
        }

    }
}