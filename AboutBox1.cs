using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace TextEdit
{
    partial class AboutBox1 : Form
    {
        public AboutBox1()
        {
            InitializeComponent();
            this.Text = String.Format("About");
            this.linkLabel1.Text += Environment.NewLine + Environment.NewLine + "GitHub";
            this.linkLabel1.LinkArea = new LinkArea(40, 44);
            this.linkLabel2.LinkClicked += LinkLabel1_LinkClicked;
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel2.LinkVisited = true;
            Process.Start("cmd", "/c start https://www.github.com/omerhijazi404/TextEdit/blob/master/LICENSE");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            Process.Start("cmd", "/c start https://www.github.com/omerhijazi404/TextEdit/");
        }

        private void AboutBox1_Load(object sender, EventArgs e)
        {

        }
    }
}
