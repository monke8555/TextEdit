using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using TextEdit;

namespace TextEdit {
    public partial class Form1 : Form {

        public string AppLocation = Directory.GetCurrentDirectory() + @"\TextEdit.exe";
        bool clicked = false;
        public Form1() {
            InitializeComponent();
            File.MouseEnter += OnMouseEnterFile;
            File.MouseLeave += OnMouseLeaveFile;
            File.MouseClick += File_Click;
            About.MouseEnter += OnMouseEnterFile;
            About.MouseLeave += OnMouseLeaveFile;
            textBox2.MouseClick += OnClickTextEditor;
            panel2.MouseClick += OnClickPanel2;
            FindForm().KeyDown += MyForm_KeyDown;
        }

        private void Open_Click(object sender, EventArgs e) {
            if (OpenFile.ShowDialog() == DialogResult.OK) {
                textBox1.Text = OpenFile.FileName;
            }
        }

        private void File_Click(object sender, EventArgs e) {
            clicked = !clicked;
            panel1.Visible = clicked;
            panel1.Enabled = clicked;
            panel1.BringToFront();
        }

        protected override void OnPaint(PaintEventArgs e) {
            int y = File.Bottom + 1;
            Color color = new Color();
            color = Color.FromArgb(220, 220, 220);
            using (var pen = new Pen(color)) {
                e.Graphics.DrawLine(pen, 0, y, ClientSize.Width, y);
            }
        }

        protected override void OnResize(EventArgs e) {
            Graphics g = FindForm().CreateGraphics();
            int y = File.Bottom + 1;
            Color color = new Color();
            color = Color.FromArgb(220, 220, 220);
            using (var pen = new Pen(color)) {
                g.DrawLine(pen, 0, y, ClientSize.Width, y);
            }
            textBox2.Width = FindForm().Size.Width - 20;
            textBox2.Height = FindForm().Size.Height - 70;

        }

        private void OnMouseEnterFile(object sender, EventArgs e) {
            Button abc = sender as Button;
            abc.BackColor = Color.FromArgb(229, 243, 255);
            abc.FlatAppearance.BorderColor = Color.FromArgb(204, 232, 255);
            abc.FlatAppearance.BorderSize = 1;
        }

        private void OnMouseLeaveFile(object sender, EventArgs e) {
            Button abc = sender as Button;
            abc.BackColor = Color.White;
            abc.FlatAppearance.BorderColor = Color.White;
            abc.FlatAppearance.BorderSize = 0;
        }

        private void OnClickTextEditor(object sender, EventArgs e) {
            if (clicked == true) {
                clicked = !clicked;
                panel1.Visible = clicked;
                panel1.Enabled = clicked;
                panel1.BringToFront();
            }
        }

        private void OnClickPanel2(object sender, EventArgs e) {
            if (clicked == true)
            {
                clicked = !clicked;
                panel1.Visible = clicked;
                panel1.Enabled = clicked;
                panel1.BringToFront();
            }
        }

        private void Aboutc(object sender, EventArgs e)
        {
            OnClickPanel2(sender, e);
            AboutBox1 a = new AboutBox1();
            a.ShowDialog();
        }

        private void MyForm_KeyDown(object sender, KeyEventArgs e)
        {
            Keys a = e.Modifiers;
            Keys b = e.KeyCode;
            if (a == Keys.Control && b == Keys.N) {
                System.Diagnostics.Process.Start(AppLocation);
            } else if (a == Keys.Control && b == Keys.S) {
                if (Editor.Local.Save(textBox1.Text, textBox2.Lines) == false) {
                    MessageBox.Show("TextEdit encountered an error while saving. \r\n Please try again or restart TextEdit.");
                } else {}
            }
        }
    }
}
