using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        int oper = 0;
        double act;
        public Form1()
        {
            InitializeComponent();
        }

        private void nums(object sender, EventArgs e)
        {
            if (this.num.Text == "0") this.num.Text = "";
            this.num.Text += ((Button)sender).Text;
        }

        private void add()
        {
            if (oper != 0) { act += Convert.ToDouble(num.Text); num.Text = act.ToString(); }
            else { act = Convert.ToDouble(num.Text); Clipboard.SetText(act.ToString()); num.Text = "0"; }
            oper = 1;
        }

        private void min()
        {
            if (oper != 0) { act -= Convert.ToDouble(num.Text); num.Text = act.ToString(); }
            else { act = Convert.ToDouble(num.Text); Clipboard.SetText(act.ToString()); num.Text = "0"; }
            oper = 2;
        }

        private void mul()
        {
            if (oper != 0) { act *= Convert.ToDouble(num.Text); num.Text = act.ToString(); }
            else { act = Convert.ToDouble(num.Text); Clipboard.SetText(act.ToString()); num.Text = "0"; }
            oper = 3;
        }

        private void div()
        {
            if (oper != 0) { act /= Convert.ToDouble(num.Text); num.Text = act.ToString(); }
            else { act = Convert.ToDouble(num.Text); Clipboard.SetText(act.ToString()); num.Text = "0"; }
            oper = 4;
        }

        private void res()
        {
            switch (oper)
            {
                case 1: act += Convert.ToDouble(num.Text); oper = 0; break;
                case 2: act -= Convert.ToDouble(num.Text); oper = 0; break;
                case 3: act *= Convert.ToDouble(num.Text); oper = 0; break;
                case 4: act /= Convert.ToDouble(num.Text); oper = 0; break;
                case 0: return;
            }
            num.Text = act.ToString(); Clipboard.SetText(act.ToString()); act = 0; oper = 0;
        }

        private void oprBtn(object sender, EventArgs e)
        {
            switch (((Button)sender).Text.ToString())
            {
                case "+": add(); break;
                case "-": min(); break;
                case "*": mul(); break;
                case "/": div(); break;
                case "=": res(); break;
                case "CE": num.Text = ""; act = 0; oper = 0; break;
            }
        }
        
        private void keyboard(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                if (this.num.Text == "0") this.num.Text = "";
                this.num.Text += e.KeyChar.ToString();
            }
            else if (e.KeyChar == '+')
                add();
            else if (e.KeyChar == '-')
                min();
            else if (e.KeyChar == '*')
                mul();
            else if (e.KeyChar == '/')
                div();
            else if (e.KeyChar == (char)13)
                res();
        }

        private void keyboard(object sender, KeyEventArgs e)
        {

        }
    }
}