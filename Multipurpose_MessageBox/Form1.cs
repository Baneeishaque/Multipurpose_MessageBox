using MyApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Multipurpose_MessageBox
{
    public partial class Form1 : Form
    {
        private List<Button> _buttons = new List<Button>(); // Buttons list
        private string _btnResult; // Button clicked
        private List<string> _lResults = new List<string>(); // Return list

        public const char escDef = '\xd'; // Default button
        public const char escChk = '\xc'; // Default check

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string res = new CMsgDlg().ShowDialog("Warning - the chosen filter is non-standard.", "Filter Warning", new string[] { "Filter", "Skip", "Cancel" });

            if (res == "Cancel")
                Console.WriteLine("Cancel");
            else if (res == "Skip")
                Console.WriteLine("Skip");
            else if (res == "Filter")
                Console.WriteLine("Filter");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> astr = new CMsgDlg().ShowDialogTextBox("Units", new string[] { "Enter units:", "                  " });

            if (astr[0] == "Cancel")
                return;
            else
            {
                string unit = astr[1].Trim(); // Entered string
                Console.WriteLine("Units " + unit);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool _bDistr = true, _bSign = false, _bShow = false;

            string chk_distr = (_bDistr ? CMsgDlg.escChk.ToString() : "") + "Distribution statement";
            string chk_Sign = (_bSign ? CMsgDlg.escChk.ToString() : "") + "Sign document";
            string chk_Show = (_bShow ? CMsgDlg.escChk.ToString() : "") + "Show report updates";

            List<string> astr = new CMsgDlg().ShowDialogCheckBox("Check all that apply.", "Report Options",
                new string[] { chk_distr, chk_Sign, chk_Show }, new string[] { "\xdOK", "Cancel" });

            if (astr[0] == "Cancel")
                return;
            else
            {
                _bDistr = (astr[1][0] == CMsgDlg.escChk);  // Distr. statement
                _bSign = (astr[2][0] == CMsgDlg.escChk);   // Sign
                _bShow = (astr[3][0] == CMsgDlg.escChk);   // Show updates
                Console.WriteLine(_bDistr + "," + _bSign + "," + _bShow);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*CMsgDlg dlg = new CMsgDlg().ShowProgress(this, "Running the Full Report script...", "Script");

            int i = 0;
            foreach (TreeNode node in chkNodes)
            { // For each checked node
                if (dlg.Result((double)++i / chkNodes.Count) == "Cancel") goto Exit;
            }

            If(dlg != null) dlg.Close();*/
        }

        //--------------------------------------------------------------------------
        // Returns button result (for non-modal use) and updates progress by perc %
        //--------------------------------------------------------------------------
        /*public string Result(double perc, string text = "")
        {
            try
            {
                if (_prgBar != null)
                {
                    if (perc <= 1.0) perc *= 100; // Convert to percentage
                    _prgBar.Value = (int)(perc + 0.5);
                }
                if (text != "") _lbl.Text = text;
            }
            catch (Exception)
            { // Keep from crashing if passed invalid value
            }

            return _btnResult;
        }

        //--------------------------------------------------------------------------
        // Cancel handler for non-modal
        //--------------------------------------------------------------------------
        public void Cancel(bool bAsk = false)
        {
            if (bAsk)
            { // Ask 1st
                this.Visible = false;   // Disables non-modal dlg
                string lbl = _lbl.Text; // Save in case continue

                if (ShowDialog("Cancel the current operation?", this.Text, "Continue")
                == "Continue")
                { // Already has Cancel btn
                    _lbl.Text = lbl; // Restore
                    _buttons.Last().Dispose(); // Continue btn
                    _buttons.Remove(_buttons.Last());
                    this.Visible = true; // Enable non-modal again
                    Form1.TheForm().MsgDlg = this; // Restore for form - Close() nulls

                    return;
                }
            }

            _lbl.Text = "Closing...";
            _btnResult = "Cancel"; // Set to close on next Result() check
        }*/
    }
}
