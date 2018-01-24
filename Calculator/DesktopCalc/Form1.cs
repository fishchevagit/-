using CalcLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopCalc
{
    public partial class Form1 : Form
    {

        private int interval;
        private Calc Calc { get; set; }

        public Form1()
        {
            InitializeComponent();
            Calc = new Calc();
            interval = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbOperations.Items.Clear();
            lbOperations.Items.AddRange(Calc.GetOperationName());

        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            if (lbOperations.SelectedItem == null)
                return;
            var oper = lbOperations.SelectedItem.ToString();

            var result = Calc.Exec(oper, tbInput.Text.Trim().Split(' '));

            label1.Text = result.ToString();
        }

        private void lbOperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbInput.Enabled = lbOperations.SelectedItem != null;
        }

        private void tbInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)|| e.KeyChar==' '))
                e.Handled = true;
            //timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           /* interval++;
            if (interval == 10)
            {
                if (lbOperations.SelectedItem == null)
                    return;
                var oper = lbOperations.SelectedItem.ToString();

                var result = Calc.Exec(oper, tbInput.Text.Trim().Split(' '));

                label1.Text = result.ToString();

                interval = 0;
                timer1.Stop();
            }
            */
        }
    }
}
