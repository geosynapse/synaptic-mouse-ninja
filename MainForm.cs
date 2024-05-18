using System;
using System.Windows.Forms;
using GeoSynapse.Poc.Properties;

namespace GeoSynapse.Poc
{
    public partial class MainForm : Form
    {
        public MainForm()
            : this(geoOnStartup: false, minimizeOnStartup: false, zenTickleEnabled: false, ticklePeriod: 1)
        { }

        public MainForm(bool geoOnStartup, bool minimizeOnStartup, bool zenTickleEnabled, int ticklePeriod)
        {
            this.InitializeComponent();

            this.GeoOnStartup = geoOnStartup;
            this.cbMinimize.Checked = minimizeOnStartup;
            this.cbZen.Checked = zenTickleEnabled;
            this.tbPeriod.Value = ticklePeriod;
        }

        public bool GeoOnStartup { get; }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (this.GeoOnStartup)
                this.cbTickling.Checked = true;
        }

        private void UpdateNotificationAreaText()
        {
            if (!this.cbTickling.Checked)
            {
                this.niTray.Text = "Not tickle.";
            }
            else
            {
                string? ww = this.ZenTickleEnabled ? "with" : "without";
                this.niTray.Text = $"Tickle every {this.TicklePeriod} s, {ww} Zen.";
            }
        }

        private void cbSettings_CheckedChanged(object sender, EventArgs e)
        {
            this.panelSettings.Visible = this.cbSettings.Checked;
        }

        private void cbMinimize_CheckedChanged(object sender, EventArgs e)
        {
            this.MinimizeOnStartup = this.cbMinimize.Checked;
        }

        private void cbZen_CheckedChanged(object sender, EventArgs e)
        {
            this.ZenTickleEnabled = this.cbZen.Checked;
        }

        private void tbPeriod_ValueChanged(object sender, EventArgs e)
        {
            this.TicklePeriod = this.tbPeriod.Value;
        }

        protected bool Zig = true;

        private void cbTickling_CheckedChanged(object sender, EventArgs e)
        {
            this.tickleTimer.Enabled = this.cbTickling.Checked;
        }

        private void tickleTimer_Tick(object sender, EventArgs e)
        {
            if (this.ZenTickleEnabled)
                Helpers.GeoTickle(delta: 0);
            else if (this.Zig)
                Helpers.GeoTickle(delta: 4);
            else //zag
                Helpers.GeoTickle(delta: -4);

            this.Zig = !this.Zig;
        }


        private void cmdTrayify_Click(object sender, EventArgs e)
        {
            this.MinimizeToTray();
        }

        private void niTray_DoubleClick(object sender, EventArgs e)
        {
            this.RestoreFromTray();
        }

        private void MinimizeToTray()
        {
            this.Visible = false;
            this.ShowInTaskbar = false;
            this.niTray.Visible = true;

            this.UpdateNotificationAreaText();
        }

        private void RestoreFromTray()
        {
            this.Visible = true;
            this.ShowInTaskbar = true;
            this.niTray.Visible = false;
        }


        private int ticklePeriod;

        private bool minimizeOnStartup;

        private bool zenTickleEnabled;

        public bool MinimizeOnStartup
        {
            get => this.minimizeOnStartup;
            set
            {
                this.minimizeOnStartup = value;
                Settings.Default.MinimizeOnStartup = value;
                Settings.Default.Save();
            }
        }

        public bool ZenTickleEnabled
        {
            get => this.zenTickleEnabled;
            set
            {
                this.zenTickleEnabled = value;
                Settings.Default.ZenTickle = value;
                Settings.Default.Save();
            }
        }

        public int TicklePeriod
        {
            get => this.ticklePeriod;
            set
            {
                this.ticklePeriod = value;
                Settings.Default.TicklePeriod = value;
                Settings.Default.Save();

                this.tickleTimer.Interval = value * 1000;
                this.lbPeriod.Text = $"{value} s";
            }
        }

        private bool firstShown = true;

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (this.firstShown && this.MinimizeOnStartup)
                this.MinimizeToTray();

            this.firstShown = false;
        }
    }
}
