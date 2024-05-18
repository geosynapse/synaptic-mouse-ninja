
using System.Windows.Forms;

namespace GeoSynapse.Poc
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tickleTimer = new Timer(components);
            flpLayout = new FlowLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panelBase = new Panel();
            cmdTrayify = new Button();
            cbSettings = new CheckBox();
            cbTickling = new CheckBox();
            panelSettings = new Panel();
            lbPeriod = new Label();
            tbPeriod = new TrackBar();
            cbMinimize = new CheckBox();
            cbZen = new CheckBox();
            niTray = new NotifyIcon(components);
            flpLayout.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panelBase.SuspendLayout();
            panelSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbPeriod).BeginInit();
            SuspendLayout();
            tickleTimer.Interval = 1000;
            tickleTimer.Tick += tickleTimer_Tick;
            // 
            // flpLayout
            // 
            flpLayout.AutoSize = true;
            flpLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpLayout.Controls.Add(tableLayoutPanel1);
            flpLayout.Dock = DockStyle.Fill;
            flpLayout.FlowDirection = FlowDirection.TopDown;
            flpLayout.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            flpLayout.Location = new System.Drawing.Point(0, 0);
            flpLayout.Margin = new Padding(3, 4, 3, 4);
            flpLayout.Name = "flpLayout";
            flpLayout.Padding = new Padding(6, 7, 6, 7);
            flpLayout.Size = new System.Drawing.Size(577, 257);
            flpLayout.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panelBase, 0, 0);
            tableLayoutPanel1.Controls.Add(panelSettings, 0, 1);
            tableLayoutPanel1.Location = new System.Drawing.Point(9, 10);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 26.953125F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 73.046875F));
            tableLayoutPanel1.Size = new System.Drawing.Size(556, 229);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // panelBase
            // 
            panelBase.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelBase.AutoSize = true;
            panelBase.BorderStyle = BorderStyle.Fixed3D;
            panelBase.Controls.Add(cmdTrayify);
            panelBase.Controls.Add(cbSettings);
            panelBase.Controls.Add(cbTickling);
            panelBase.Location = new System.Drawing.Point(3, 4);
            panelBase.Margin = new Padding(3, 4, 3, 4);
            panelBase.Name = "panelBase";
            panelBase.Size = new System.Drawing.Size(550, 53);
            panelBase.TabIndex = 3;
            // 
            // cmdTrayify
            // 
            cmdTrayify.Location = new System.Drawing.Point(297, 3);
            cmdTrayify.Margin = new Padding(3, 4, 3, 4);
            cmdTrayify.Name = "cmdTrayify";
            cmdTrayify.Size = new System.Drawing.Size(46, 31);
            cmdTrayify.TabIndex = 3;
            cmdTrayify.Text = "🔽";
            cmdTrayify.UseVisualStyleBackColor = true;
            cmdTrayify.Click += cmdTrayify_Click;
            // 
            // cbSettings
            // 
            cbSettings.Checked = true;
            cbSettings.CheckState = CheckState.Checked;
            cbSettings.Location = new System.Drawing.Point(101, 7);
            cbSettings.Margin = new Padding(3, 4, 3, 4);
            cbSettings.Name = "cbSettings";
            cbSettings.Size = new System.Drawing.Size(88, 25);
            cbSettings.TabIndex = 1;
            cbSettings.Text = "settings";
            cbSettings.UseVisualStyleBackColor = true;
            cbSettings.CheckedChanged += cbSettings_CheckedChanged;
            cbTickling.AutoSize = true;
            cbTickling.Location = new System.Drawing.Point(11, 7);
            cbTickling.Margin = new Padding(3, 4, 3, 4);
            cbTickling.Name = "cbTickling";
            cbTickling.Size = new System.Drawing.Size(92, 25);
            cbTickling.TabIndex = 0;
            cbTickling.Text = "synapse";
            cbTickling.UseVisualStyleBackColor = true;
            cbTickling.CheckedChanged += cbTickling_CheckedChanged;
            // 
            // panelSettings
            // 
            panelSettings.AutoSize = true;
            panelSettings.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelSettings.Controls.Add(lbPeriod);
            panelSettings.Controls.Add(tbPeriod);
            panelSettings.Controls.Add(cbMinimize);
            panelSettings.Controls.Add(cbZen);
            panelSettings.Dock = DockStyle.Fill;
            panelSettings.Location = new System.Drawing.Point(3, 65);
            panelSettings.Margin = new Padding(3, 4, 3, 4);
            panelSettings.Name = "panelSettings";
            panelSettings.Size = new System.Drawing.Size(550, 160);
            panelSettings.TabIndex = 2;
            panelSettings.Visible = false;
            // 
            // lbPeriod
            // 
            lbPeriod.AutoSize = true;
            lbPeriod.Location = new System.Drawing.Point(279, 55);
            lbPeriod.Name = "lbPeriod";
            lbPeriod.Size = new System.Drawing.Size(26, 21);
            lbPeriod.TabIndex = 3;
            lbPeriod.Text = "1 s";
            // 
            // tbPeriod
            // 
            tbPeriod.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbPeriod.Location = new System.Drawing.Point(5, 83);
            tbPeriod.Margin = new Padding(3, 4, 3, 4);
            tbPeriod.Maximum = 60;
            tbPeriod.Minimum = 1;
            tbPeriod.Name = "tbPeriod";
            tbPeriod.Size = new System.Drawing.Size(541, 56);
            tbPeriod.TabIndex = 6;
            tbPeriod.TickFrequency = 2;
            tbPeriod.Value = 1;
            tbPeriod.ValueChanged += tbPeriod_ValueChanged;
            // 
            // cbMinimize
            // 
            cbMinimize.AutoSize = true;
            cbMinimize.Location = new System.Drawing.Point(11, 49);
            cbMinimize.Margin = new Padding(3, 4, 3, 4);
            cbMinimize.Name = "cbMinimize";
            cbMinimize.Size = new System.Drawing.Size(103, 25);
            cbMinimize.TabIndex = 5;
            cbMinimize.Text = "minimize";
            cbMinimize.UseVisualStyleBackColor = true;
            cbMinimize.CheckedChanged += cbMinimize_CheckedChanged;
            // 
            // cbZen
            // 
            cbZen.AutoSize = true;
            cbZen.Location = new System.Drawing.Point(11, 15);
            cbZen.Margin = new Padding(3, 4, 3, 4);
            cbZen.Name = "cbZen";
            cbZen.Size = new System.Drawing.Size(59, 25);
            cbZen.TabIndex = 4;
            cbZen.Text = "zen";
            cbZen.UseVisualStyleBackColor = true;
            cbZen.CheckedChanged += cbZen_CheckedChanged;
            // 
            // niTray
            // 
            niTray.Icon = (System.Drawing.Icon)resources.GetObject("niTray.Icon");
            niTray.Text = "Geo Synaptic Stream";
            niTray.DoubleClick += niTray_DoubleClick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = System.Drawing.SystemColors.ControlDarkDark;
            ClientSize = new System.Drawing.Size(577, 257);
            Controls.Add(flpLayout);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MinimizeBox = false;
            Name = "MainForm";
            Opacity = 0.8D;
            Text = "Geo Synaptic Stream (poc)";
            Load += MainForm_Load;
            Shown += MainForm_Shown;
            flpLayout.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panelBase.ResumeLayout(false);
            panelBase.PerformLayout();
            panelSettings.ResumeLayout(false);
            panelSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbPeriod).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer tickleTimer;
        private System.Windows.Forms.FlowLayoutPanel flpLayout;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.TrackBar tbPeriod;
        private System.Windows.Forms.CheckBox cbMinimize;
        private System.Windows.Forms.CheckBox cbZen;
        private System.Windows.Forms.Panel panelBase;
        private System.Windows.Forms.CheckBox cbSettings;
        private System.Windows.Forms.CheckBox cbTickling;
        private System.Windows.Forms.Label lbPeriod;
        private System.Windows.Forms.NotifyIcon niTray;
        private System.Windows.Forms.Button cmdTrayify;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

