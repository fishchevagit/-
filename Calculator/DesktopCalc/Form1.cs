using CalcDB.Models;
using CalcDB.Repositories;
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

            #region Сохранение в БД

            var or = new OperationResult()
            {
                OperationId = lbOperations.SelectedIndex,
                Result = result,
                ExecutionTime = new Random().Next(100, 4000),
                Error = "",
                Args = tbInput.Text.Trim()
            };

            var operResultRepository = new OperResultRepository();
            operResultRepository.Save(or);

            #endregion
        }

        private void lbOperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbInput.Enabled = lbOperations.SelectedItem != null;
        }

        private void tbInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || e.KeyChar == ' '))
                e.Handled = true;
            if (!timer1.Enabled)
            {
                tbInput.Text = "";
                timer1.Start();
            }
            btnCalc.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            interval++;
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
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
