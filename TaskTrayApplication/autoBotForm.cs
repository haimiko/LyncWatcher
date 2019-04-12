using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskTrayApplication
{
    public partial class autoBotForm : Form
    {
        public autoBotForm()
        {
            InitializeComponent();
            LoadSettings(null, null);
            ToolTip tip = new ToolTip();
            tip.SetToolTip(tipRandom, "Randomize the selected response phrase from the above list.  Otheriwise select in order and start again from the beginning when exhausted list.");
            tip.SetToolTip(tipPrompt, "If selected will prompt you before the autoresponse and will timeout to autoaanswer in seconds provided below.");
            tip.SetToolTip(tipTechnoBabble, "Randomly select some IT technical jargon to make you seem busy.");
            tip.SetToolTip(tipPhrases, "Newline separated list of words/phrases you want as responses.  Using the <PATTERN>/<RESPONSE> construct will use that RESPONSE for messages matching PATTERN.  For example  ^can.*/Sorry, No.  Will send 'Sorry No' when someone starts a sentence with 'can'.");
            tip.SetToolTip(tipPrefixMsg, "Prefix the message top let people know the message is coming from a 'BOT'.  Leaving the text below empty will use your firstname.");
            txtResponsePrefix.Text = TaskTrayApplication.Properties.Settings.Default.reponsePrefix;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            TaskTrayApplication.Properties.Settings.Default.enableRandomBabble = chkEnableTechno.Checked;
            TaskTrayApplication.Properties.Settings.Default.phrases = txtPhrases.Text;
           // TaskTrayApplication.Properties.Settings.Default.askToAutoBot = chkAskToAutoBot.Checked;
            TaskTrayApplication.Properties.Settings.Default.autoBotTimeOut = (int) txtAutoBotTimeOut.Value;
            TaskTrayApplication.Properties.Settings.Default.autoBotNoPrompt = chkAutoBotNoPrompt.Checked;
            TaskTrayApplication.Properties.Settings.Default.autoBotRandomizer = chkRandomPhrases.Checked;
            TaskTrayApplication.Properties.Settings.Default.respondIfBusyOnly = chkRespOnlyBusy.Checked;
            TaskTrayApplication.Properties.Settings.Default.prefixMessage = chkBoxPrefixResponse.Checked;
            TaskTrayApplication.Properties.Settings.Default.reponsePrefix = txtResponsePrefix.Text;
            TaskTrayApplication.Properties.Settings.Default.enableAI = chkEnableAI.Checked;
          TaskTrayApplication.Properties.Settings.Default.Save();

            this.Close();
        }

        private void LoadSettings(object sender, EventArgs e)
        {
            chkEnableTechno.Checked = TaskTrayApplication.Properties.Settings.Default.enableRandomBabble;
            txtPhrases.Text = TaskTrayApplication.Properties.Settings.Default.phrases;
          //  chkAskToAutoBot.Checked = TaskTrayApplication.Properties.Settings.Default.askToAutoBot;
            txtAutoBotTimeOut.Value = TaskTrayApplication.Properties.Settings.Default.autoBotTimeOut;
            chkAutoBotNoPrompt.Checked = TaskTrayApplication.Properties.Settings.Default.autoBotNoPrompt;
            chkRandomPhrases.Checked = TaskTrayApplication.Properties.Settings.Default.autoBotRandomizer;
            chkRespOnlyBusy.Checked = TaskTrayApplication.Properties.Settings.Default.respondIfBusyOnly;
            chkBoxPrefixResponse.Checked = TaskTrayApplication.Properties.Settings.Default.prefixMessage;
            txtResponsePrefix.Text = TaskTrayApplication.Properties.Settings.Default.reponsePrefix;
            chkEnableAI.Checked = TaskTrayApplication.Properties.Settings.Default.enableAI;
        }

        private void chkAutoBotNoPrompt_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoBotNoPrompt.Checked)
                txtAutoBotTimeOut.Enabled = true;
            else
                txtAutoBotTimeOut.Enabled = false;
        }

        private void chkBoxPrefixResponse_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxPrefixResponse.Checked)
                txtResponsePrefix.Enabled = true;
            else
                txtResponsePrefix.Enabled = false;
        }

        private void chkEnableAI_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableAI.Checked)
            {
                txtPhrases.Enabled = false;
                chkRandomPhrases.Enabled = false;
               // txtAutoBotTimeOut.Enabled = false;
               // chkAutoBotNoPrompt.Enabled = false;
            }
            else
            {
                txtPhrases.Enabled = true;
                chkRandomPhrases.Enabled = true;
                chkAutoBotNoPrompt.Enabled = true;
            /*    if (chkAutoBotNoPrompt.Checked)
                {
                    txtAutoBotTimeOut.Enabled = true;
                }
                */
            }
        }
    }
}
