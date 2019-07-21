using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TxtCurrency
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textBox1.Text = string.Format("{0:#,##0.00}", 0d);
            textBox2.Text = string.Format("{0:#,##0.00}", 0d);
            textBox3.Text = string.Format("{0:#,##0.00}", 0d);
        }



        private void TxtKeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar.Equals((char)Keys.Back))
            {
                TextBox t = (TextBox)sender;
                string w = Regex.Replace(t.Text, "[^0-9]", string.Empty);
                if (w == string.Empty) w = "00";

                if (e.KeyChar.Equals((char)Keys.Back))      //  If backspace
                    w = w.Substring(0, w.Length - 1);      //      takes out the rightmost digit
                else
                    w += e.KeyChar;
                lblEdit.Text = t.SelectionStart.ToString();

                t.Text = string.Format("{0:#,##0.00}", Double.Parse(w) / 100);
                t.Select(t.Text.Length, 0);
            }
            e.Handled = true;
        }

        private void TxtDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                //  Cast control
                TextBox t = (TextBox)sender;
                t.Text = string.Format("{0:#,##0.00}", 0d);
                t.Select(t.Text.Length, 0);
                e.Handled = true;
            }
        }

        private void TxtDownEdit(object sender, KeyEventArgs e)
        {
            TextBox t = (TextBox)sender;
            lblDown.Text = t.SelectionStart.ToString();
            string x = t.CompanyName.ToString();
        }

        private void TxtKeyPressEdit(object sender, KeyPressEventArgs e)
        {
            return;
            TextBox t = (TextBox)sender;
            StringBuilder b = new StringBuilder(t.Text);

            b.Insert(t.SelectionStart, e.KeyChar);
            lblEdit.Text = t.SelectionStart.ToString();
            t.Select(t.SelectionStart, 0);
            t.Text = b.ToString();
            
            e.Handled = true;
        }

        private void TxtUpEdit(object sender, KeyEventArgs e)
        {
            TextBox t = (TextBox)sender;
            lblUp.Text = t.SelectionStart.ToString();
        }


            ///for System.Windows.Forms.TextBox
            public static System.Drawing.Point GetCaretPoint(System.Windows.Forms.TextBox textBox)
            {
                int start = textBox.SelectionStart;
                if (start == textBox.TextLength)
                    start--;

                return textBox.GetPositionFromCharIndex(start);
            }
       
    }
}
