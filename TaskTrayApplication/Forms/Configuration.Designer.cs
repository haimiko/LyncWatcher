namespace TaskTrayApplication
{
    partial class Configuration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.chkEnableStartup = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.chkFade = new System.Windows.Forms.CheckBox();
            this.chkAway = new System.Windows.Forms.CheckBox();
            this.mnuAutoBot = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.enableAutoBotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureAutoBotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkDisableLyncLED = new System.Windows.Forms.CheckBox();
            this.chkFWAutoUpdate = new System.Windows.Forms.CheckBox();
            this.lblFirmware = new System.Windows.Forms.Label();
            this.chkDisableAutoConnect = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkEnableStartup
            // 
            this.chkEnableStartup.AutoSize = true;
            this.chkEnableStartup.Checked = true;
            this.chkEnableStartup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnableStartup.Location = new System.Drawing.Point(12, 12);
            this.chkEnableStartup.Name = "chkEnableStartup";
            this.chkEnableStartup.Size = new System.Drawing.Size(109, 17);
            this.chkEnableStartup.TabIndex = 0;
            this.chkEnableStartup.Text = "Enable on startup";
            this.chkEnableStartup.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(98, 168);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(17, 168);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // chkFade
            // 
            this.chkFade.AutoSize = true;
            this.chkFade.Checked = true;
            this.chkFade.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFade.Location = new System.Drawing.Point(12, 35);
            this.chkFade.Name = "chkFade";
            this.chkFade.Size = new System.Drawing.Size(86, 17);
            this.chkFade.TabIndex = 3;
            this.chkFade.Text = "Enable Fade";
            this.chkFade.UseVisualStyleBackColor = true;
            this.chkFade.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chkAway
            // 
            this.chkAway.AutoSize = true;
            this.chkAway.Checked = true;
            this.chkAway.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAway.Location = new System.Drawing.Point(12, 58);
            this.chkAway.Name = "chkAway";
            this.chkAway.Size = new System.Drawing.Size(116, 17);
            this.chkAway.TabIndex = 4;
            this.chkAway.Text = "Enable Away Flash";
            this.chkAway.UseVisualStyleBackColor = true;
            // 
            // mnuAutoBot
            // 
            this.mnuAutoBot.Name = "mnuAutoBot";
            this.mnuAutoBot.Size = new System.Drawing.Size(61, 4);
            // 
            // enableAutoBotToolStripMenuItem
            // 
            this.enableAutoBotToolStripMenuItem.Name = "enableAutoBotToolStripMenuItem";
            this.enableAutoBotToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // configureAutoBotToolStripMenuItem
            // 
            this.configureAutoBotToolStripMenuItem.Name = "configureAutoBotToolStripMenuItem";
            this.configureAutoBotToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // chkDisableLyncLED
            // 
            this.chkDisableLyncLED.AutoSize = true;
            this.chkDisableLyncLED.Location = new System.Drawing.Point(13, 82);
            this.chkDisableLyncLED.Name = "chkDisableLyncLED";
            this.chkDisableLyncLED.Size = new System.Drawing.Size(123, 17);
            this.chkDisableLyncLED.TabIndex = 5;
            this.chkDisableLyncLED.Text = "Don\'t Use Lync LED";
            this.chkDisableLyncLED.UseVisualStyleBackColor = true;
            this.chkDisableLyncLED.CheckedChanged += new System.EventHandler(this.chkDisableLyncLED_CheckedChanged);
            // 
            // chkFWAutoUpdate
            // 
            this.chkFWAutoUpdate.AutoSize = true;
            this.chkFWAutoUpdate.Location = new System.Drawing.Point(13, 105);
            this.chkFWAutoUpdate.Name = "chkFWAutoUpdate";
            this.chkFWAutoUpdate.Size = new System.Drawing.Size(131, 17);
            this.chkFWAutoUpdate.TabIndex = 5;
            this.chkFWAutoUpdate.Text = "Auto Update Firmware";
            this.chkFWAutoUpdate.UseVisualStyleBackColor = true;
            this.chkFWAutoUpdate.CheckedChanged += new System.EventHandler(this.chkDisableLyncLED_CheckedChanged);
            // 
            // lblFirmware
            // 
            this.lblFirmware.AutoSize = true;
            this.lblFirmware.Location = new System.Drawing.Point(142, 106);
            this.lblFirmware.Name = "lblFirmware";
            this.lblFirmware.Size = new System.Drawing.Size(0, 13);
            this.lblFirmware.TabIndex = 6;
            // 
            // chkDisableAutoConnect
            // 
            this.chkDisableAutoConnect.AutoSize = true;
            this.chkDisableAutoConnect.Location = new System.Drawing.Point(12, 128);
            this.chkDisableAutoConnect.Name = "chkDisableAutoConnect";
            this.chkDisableAutoConnect.Size = new System.Drawing.Size(142, 17);
            this.chkDisableAutoConnect.TabIndex = 7;
            this.chkDisableAutoConnect.Text = "Disable Auto Reconnect";
            this.chkDisableAutoConnect.UseVisualStyleBackColor = true;
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(182, 197);
            this.ControlBox = false;
            this.Controls.Add(this.chkDisableAutoConnect);
            this.Controls.Add(this.lblFirmware);
            this.Controls.Add(this.chkFWAutoUpdate);
            this.Controls.Add(this.chkDisableLyncLED);
            this.Controls.Add(this.chkAway);
            this.Controls.Add(this.chkFade);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.chkEnableStartup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Configuration";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "LyncWatcher Config";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SaveSettings);
            this.Load += new System.EventHandler(this.Configuration_Load);
            this.Shown += new System.EventHandler(this.LoadSettings);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkEnableStartup;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox chkFade;
        private System.Windows.Forms.CheckBox chkAway;
        private System.Windows.Forms.ContextMenuStrip mnuAutoBot;
        private System.Windows.Forms.ToolStripMenuItem enableAutoBotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureAutoBotToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkDisableLyncLED;
        private System.Windows.Forms.CheckBox chkFWAutoUpdate;
        private System.Windows.Forms.Label lblFirmware;
        private System.Windows.Forms.CheckBox chkDisableAutoConnect;
    }
}

