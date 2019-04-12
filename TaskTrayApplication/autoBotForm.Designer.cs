namespace TaskTrayApplication
{
    partial class autoBotForm
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
            this.txtPhrases = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkEnableTechno = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtAutoBotTimeOut = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.chkAutoBotNoPrompt = new System.Windows.Forms.CheckBox();
            this.chkRandomPhrases = new System.Windows.Forms.CheckBox();
            this.tipRandom = new System.Windows.Forms.Label();
            this.tipPrompt = new System.Windows.Forms.Label();
            this.tipTechnoBabble = new System.Windows.Forms.Label();
            this.tipPhrases = new System.Windows.Forms.Label();
            this.chkRespOnlyBusy = new System.Windows.Forms.CheckBox();
            this.chkBoxPrefixResponse = new System.Windows.Forms.CheckBox();
            this.txtResponsePrefix = new System.Windows.Forms.TextBox();
            this.tipPrefixMsg = new System.Windows.Forms.Label();
            this.chkEnableAI = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoBotTimeOut)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPhrases
            // 
            this.txtPhrases.AcceptsReturn = true;
            this.txtPhrases.Location = new System.Drawing.Point(75, 7);
            this.txtPhrases.Multiline = true;
            this.txtPhrases.Name = "txtPhrases";
            this.txtPhrases.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPhrases.Size = new System.Drawing.Size(180, 70);
            this.txtPhrases.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Phrases";
            // 
            // chkEnableTechno
            // 
            this.chkEnableTechno.AutoSize = true;
            this.chkEnableTechno.Location = new System.Drawing.Point(75, 256);
            this.chkEnableTechno.Name = "chkEnableTechno";
            this.chkEnableTechno.Size = new System.Drawing.Size(135, 17);
            this.chkEnableTechno.TabIndex = 2;
            this.chkEnableTechno.Text = "Enable Techno Babble";
            this.chkEnableTechno.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOk.Location = new System.Drawing.Point(180, 279);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(75, 279);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtAutoBotTimeOut
            // 
            this.txtAutoBotTimeOut.Enabled = false;
            this.txtAutoBotTimeOut.Location = new System.Drawing.Point(88, 179);
            this.txtAutoBotTimeOut.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtAutoBotTimeOut.Name = "txtAutoBotTimeOut";
            this.txtAutoBotTimeOut.Size = new System.Drawing.Size(46, 20);
            this.txtAutoBotTimeOut.TabIndex = 6;
            this.txtAutoBotTimeOut.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Auto Answer Timeout (Sec)";
            // 
            // chkAutoBotNoPrompt
            // 
            this.chkAutoBotNoPrompt.AutoSize = true;
            this.chkAutoBotNoPrompt.Location = new System.Drawing.Point(75, 161);
            this.chkAutoBotNoPrompt.Name = "chkAutoBotNoPrompt";
            this.chkAutoBotNoPrompt.Size = new System.Drawing.Size(137, 17);
            this.chkAutoBotNoPrompt.TabIndex = 8;
            this.chkAutoBotNoPrompt.Text = "Enable LyncBot Prompt";
            this.chkAutoBotNoPrompt.UseVisualStyleBackColor = true;
            this.chkAutoBotNoPrompt.CheckedChanged += new System.EventHandler(this.chkAutoBotNoPrompt_CheckedChanged);
            // 
            // chkRandomPhrases
            // 
            this.chkRandomPhrases.AutoSize = true;
            this.chkRandomPhrases.Location = new System.Drawing.Point(75, 82);
            this.chkRandomPhrases.Name = "chkRandomPhrases";
            this.chkRandomPhrases.Size = new System.Drawing.Size(120, 17);
            this.chkRandomPhrases.TabIndex = 9;
            this.chkRandomPhrases.Text = "Randomize Phrases";
            this.chkRandomPhrases.UseVisualStyleBackColor = true;
            // 
            // tipRandom
            // 
            this.tipRandom.AutoSize = true;
            this.tipRandom.Location = new System.Drawing.Point(197, 83);
            this.tipRandom.Name = "tipRandom";
            this.tipRandom.Size = new System.Drawing.Size(13, 13);
            this.tipRandom.TabIndex = 10;
            this.tipRandom.Text = "?";
            // 
            // tipPrompt
            // 
            this.tipPrompt.AutoSize = true;
            this.tipPrompt.Location = new System.Drawing.Point(218, 161);
            this.tipPrompt.Name = "tipPrompt";
            this.tipPrompt.Size = new System.Drawing.Size(13, 13);
            this.tipPrompt.TabIndex = 10;
            this.tipPrompt.Text = "?";
            // 
            // tipTechnoBabble
            // 
            this.tipTechnoBabble.AutoSize = true;
            this.tipTechnoBabble.Location = new System.Drawing.Point(216, 256);
            this.tipTechnoBabble.Name = "tipTechnoBabble";
            this.tipTechnoBabble.Size = new System.Drawing.Size(13, 13);
            this.tipTechnoBabble.TabIndex = 10;
            this.tipTechnoBabble.Text = "?";
            // 
            // tipPhrases
            // 
            this.tipPhrases.AutoSize = true;
            this.tipPhrases.Location = new System.Drawing.Point(56, 7);
            this.tipPhrases.Name = "tipPhrases";
            this.tipPhrases.Size = new System.Drawing.Size(13, 13);
            this.tipPhrases.TabIndex = 10;
            this.tipPhrases.Text = "?";
            // 
            // chkRespOnlyBusy
            // 
            this.chkRespOnlyBusy.AutoSize = true;
            this.chkRespOnlyBusy.Location = new System.Drawing.Point(75, 206);
            this.chkRespOnlyBusy.Name = "chkRespOnlyBusy";
            this.chkRespOnlyBusy.Size = new System.Drawing.Size(121, 17);
            this.chkRespOnlyBusy.TabIndex = 11;
            this.chkRespOnlyBusy.Text = "Only respond if busy";
            this.chkRespOnlyBusy.UseVisualStyleBackColor = true;
            // 
            // chkBoxPrefixResponse
            // 
            this.chkBoxPrefixResponse.AutoSize = true;
            this.chkBoxPrefixResponse.Location = new System.Drawing.Point(75, 105);
            this.chkBoxPrefixResponse.Name = "chkBoxPrefixResponse";
            this.chkBoxPrefixResponse.Size = new System.Drawing.Size(103, 17);
            this.chkBoxPrefixResponse.TabIndex = 12;
            this.chkBoxPrefixResponse.Text = "Prefix Messages";
            this.chkBoxPrefixResponse.UseVisualStyleBackColor = true;
            this.chkBoxPrefixResponse.CheckedChanged += new System.EventHandler(this.chkBoxPrefixResponse_CheckedChanged);
            // 
            // txtResponsePrefix
            // 
            this.txtResponsePrefix.Location = new System.Drawing.Point(88, 129);
            this.txtResponsePrefix.Name = "txtResponsePrefix";
            this.txtResponsePrefix.Size = new System.Drawing.Size(100, 20);
            this.txtResponsePrefix.TabIndex = 13;
            // 
            // tipPrefixMsg
            // 
            this.tipPrefixMsg.AutoSize = true;
            this.tipPrefixMsg.Location = new System.Drawing.Point(184, 106);
            this.tipPrefixMsg.Name = "tipPrefixMsg";
            this.tipPrefixMsg.Size = new System.Drawing.Size(13, 13);
            this.tipPrefixMsg.TabIndex = 10;
            this.tipPrefixMsg.Text = "?";
            // 
            // chkEnableAI
            // 
            this.chkEnableAI.AutoSize = true;
            this.chkEnableAI.Location = new System.Drawing.Point(75, 229);
            this.chkEnableAI.Name = "chkEnableAI";
            this.chkEnableAI.Size = new System.Drawing.Size(72, 17);
            this.chkEnableAI.TabIndex = 15;
            this.chkEnableAI.Text = "Enable AI";
            this.chkEnableAI.UseVisualStyleBackColor = true;
            this.chkEnableAI.CheckedChanged += new System.EventHandler(this.chkEnableAI_CheckedChanged);
            // 
            // autoBotForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(297, 314);
            this.ControlBox = false;
            this.Controls.Add(this.chkEnableAI);
            this.Controls.Add(this.txtResponsePrefix);
            this.Controls.Add(this.chkBoxPrefixResponse);
            this.Controls.Add(this.chkRespOnlyBusy);
            this.Controls.Add(this.tipTechnoBabble);
            this.Controls.Add(this.tipPrompt);
            this.Controls.Add(this.tipPhrases);
            this.Controls.Add(this.tipPrefixMsg);
            this.Controls.Add(this.tipRandom);
            this.Controls.Add(this.chkRandomPhrases);
            this.Controls.Add(this.chkAutoBotNoPrompt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAutoBotTimeOut);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.chkEnableTechno);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPhrases);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "autoBotForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "AutoBot Config";
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoBotTimeOut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPhrases;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkEnableTechno;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown txtAutoBotTimeOut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkAutoBotNoPrompt;
        private System.Windows.Forms.CheckBox chkRandomPhrases;
        private System.Windows.Forms.Label tipRandom;
        private System.Windows.Forms.Label tipPrompt;
        private System.Windows.Forms.Label tipTechnoBabble;
        private System.Windows.Forms.Label tipPhrases;
        private System.Windows.Forms.CheckBox chkRespOnlyBusy;
        private System.Windows.Forms.CheckBox chkBoxPrefixResponse;
        private System.Windows.Forms.TextBox txtResponsePrefix;
        private System.Windows.Forms.Label tipPrefixMsg;
        private System.Windows.Forms.CheckBox chkEnableAI;
    }
}