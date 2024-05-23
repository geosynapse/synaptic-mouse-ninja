using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using Brushes = System.Windows.Media.Brushes;
using Color = System.Windows.Media.Color;
using ColorConverter = System.Windows.Media.ColorConverter;
using Timer = System.Windows.Forms.Timer;

namespace GeoSynapse.MouseNinja
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private const int DefaultInterval = 3000;
        private const int OneSecondInterval = 1000;
        private const string DefaultTimePeriod = "3:00";
        private const string DefaultStringProperty = "3000";
        private const int maxDistance = 5;
        private const int waitMilliseconds = 10;
        private Random random = new Random();

        private Timer? _timer;
        private NotifyIcon? _notifyIcon;

        public MainWindow(string[]? args = null)
        {
            InitializeComponent();
            DataContext = this;
            InitializeTrayIcon();
            InitializeTimer();

            bool enabled = false;
            bool minimized = false;
            bool zen = false;
            int period = 3000;
            bool calledFromCommandLine = false;
            if (args != null && args.Length == 4
                && (bool.TryParse(args[0], out enabled) &&
                    bool.TryParse(args[1], out minimized) &&
                    bool.TryParse(args[2], out zen) &&
                    int.TryParse(args[3], out period)))
            {
                AppEnabled = enabled;
                ZenModeEnabled = zen;
                Period = period;
                if (minimized) WindowState = WindowState.Minimized;
                calledFromCommandLine = true;
            }

            if (!calledFromCommandLine)
            {
                LoadSettings();
            }
        }

        private void LoadSettings()
        {
            Period = Ninja.Default.Period;
            valueSlider.Value = FromTimerIntervalToSliderValue(Period);
            AppEnabled = Ninja.Default.MouseNinjaEnabled;
            ZenModeEnabled = Ninja.Default.NinjaModeEnabled;
            Debug.WriteLine($"Loaded setting: {Period}");
        }

        public string TimePeriod => _timer == null ? DefaultTimePeriod : _timer.Interval == OneSecondInterval ? string.Empty : TimeIntervalToString(_timer.Interval);

        public int Period
        {
            get => _timer?.Interval ?? DefaultInterval;
            set
            {
                if (_timer != null && _timer.Interval != value)
                {
                    _timer.Interval = value;
                    OnPropertyChanged(nameof(Period));
                    OnPropertyChanged(nameof(TimePeriod));
                }
            }
        }

        private bool AppEnabled
        {
            get
            {
                return appEnabled.IsChecked.HasValue && appEnabled.IsChecked.Value;
            }
            set
            {
                appEnabled.IsChecked = value;
                tickIcon.Foreground = value ? Brushes.White : new SolidColorBrush((Color)ColorConverter.ConvertFromString("#444"));
            }
        }

        private bool ZenModeEnabled
        {
            get
            {
                return zenEnabled.IsChecked.HasValue && zenEnabled.IsChecked.Value;
            }
            set
            {
                zenEnabled.IsChecked = value;
                zzzIcon.Foreground = value ? Brushes.White : new SolidColorBrush((Color)ColorConverter.ConvertFromString("#444"));
            }
        }

        public string MyStringProperty => _timer?.Interval.ToString() ?? DefaultStringProperty;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void InitializeTimer()
        {
            _timer = new Timer { Interval = DefaultInterval, Enabled = true };
            _timer.Tick += OnTimerTick;
        }

        private async void OnTimerTick(object? sender, EventArgs e)
        {
            System.Drawing.Point position = System.Windows.Forms.Cursor.Position;
            Debug.WriteLine("X: " + position.X + " Y: " + position.Y);
            int distance = random.Next(maxDistance) + 1;
            System.Windows.Forms.Cursor.Position = new System.Drawing.Point(position.X + random.Next(-distance, distance), position.Y + random.Next(-distance, distance));

            await Task.Delay(waitMilliseconds);

            // Repeat random movement two more times to emulate the zig-zag movement of a ninja's original version
            for (int i = 0; i < 2; i++)
            {
                distance = random.Next(maxDistance) + 1;

                System.Windows.Forms.Cursor.Position = new System.Drawing.Point(position.X + random.Next(-distance, distance), position.Y + random.Next(-distance, distance));

                await Task.Delay(waitMilliseconds);
            }

            if (ZenModeEnabled)
            {
                System.Windows.Forms.Cursor.Position = new System.Drawing.Point(position.X, position.Y);
            }
            else
            {
                System.Windows.Forms.Cursor.Position = new System.Drawing.Point(position.X + random.Next(-1, 2), position.Y + random.Next(-1, 2));
            }
        }

        private void NinjaCheckedChanged(object sender, EventArgs e)
        {
            if (_timer == null)
            {
                InitializeTimer();
            }

            if (appEnabled.IsChecked == true && _timer != null)
            {
                _timer.Enabled = true;
            }
        }

        private void InitializeTrayIcon()
        {
            _notifyIcon = new NotifyIcon
            {
                Icon = new System.Drawing.Icon("Images\\synaptic_ninja_64x64.ico"),
                Visible = true,
                Text = "Synaptic Ninja",
                ContextMenuStrip = CreateContextMenu()
            };

            _notifyIcon.DoubleClick += OnNotifyIconDoubleClick;
        }

        private ContextMenuStrip CreateContextMenu()
        {
            var contextMenu = new ContextMenuStrip();
            var exitMenuItem = new ToolStripMenuItem("Exit");
            var zenMenuItem = new ToolStripMenuItem("Zen");

            exitMenuItem.Click += OnExitMenuItemClick;
            zenMenuItem.Click += OnTrayZenModeClicked;

            contextMenu.Items.Add(exitMenuItem);
            contextMenu.Items.Add(zenMenuItem);

            return contextMenu;
        }

        private void OnTrayZenModeClicked(object? sender, EventArgs e)
        {
            zenEnabled.IsChecked = !zenEnabled.IsChecked;
            ZenModeEnabled = zenEnabled.IsChecked.HasValue && zenEnabled.IsChecked.Value;
        }

        private void OnZenModeChanged(object? sender, EventArgs e)
        {
            ZenModeEnabled = zenEnabled.IsChecked.HasValue && zenEnabled.IsChecked.Value;
        }

        private void OnAppEnableChanged(object? sender, RoutedEventArgs e)
        {
            AppEnabled = zenEnabled.IsChecked.HasValue && appEnabled.IsChecked.Value;
        }

        private void OnNotifyIconDoubleClick(object? sender, EventArgs e)
        {
            Show();
            WindowState = WindowState.Normal;
        }

        private void OnExitMenuItemClick(object? sender, EventArgs e)
        {
            _notifyIcon?.Dispose();
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
            _notifyIcon?.Dispose();
            base.OnClosed(e);
        }

        private void OnWindowMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void OnHideClick(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void OnExitClick(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void OnPeriodSliderChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sender is Slider slider)
            {
                var output = 5970 * slider.Value + DefaultInterval;

                if (_timer != null)
                {
                    Period = (int)output;

                    Ninja.Default.Period = Period;
                    Ninja.Default.Save();
                    Debug.WriteLine($"Updated setting: {Ninja.Default.Period}");
                }
            }
        }

        private int FromTimerIntervalToSliderValue(int value)
        {
            if (value < DefaultInterval || value > 600000)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Value must be between 3,000 and 600,000.");
            }

            int result = (100 * (value - 3000)) / 597000;

            return result;
        }

        private void SavePeriodToSettings()
        {
            if (_timer != null) Ninja.Default.Period = _timer.Interval;
            Ninja.Default.MouseNinjaEnabled = appEnabled.IsChecked.HasValue && appEnabled.IsChecked.Value;
            Ninja.Default.NinjaModeEnabled = zenEnabled.IsChecked.HasValue && zenEnabled.IsChecked.Value;
            Ninja.Default.Save();
        }

        protected void OnWindowClosed(object def, EventArgs e)
        {
            SavePeriodToSettings();
            _notifyIcon?.Dispose();
            base.OnClosed(e);
        }

        public static string TimeIntervalToString(int input)
        {
            const int inputMin = DefaultInterval;
            const int inputMax = 600000;
            const int outputMin = 3;
            const int outputMax = 10 * 60;

            if (input < inputMin || input > inputMax)
            {
                throw new ArgumentOutOfRangeException(nameof(input), $"Input must be between {inputMin} and {inputMax}");
            }

            double proportion = (double)(input - inputMin) / (inputMax - inputMin);
            int output = outputMin + (int)(proportion * (outputMax - outputMin));

            TimeSpan time = TimeSpan.FromSeconds(output);
            return time.ToString(@"mm\:ss");
        }
    }
}