using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aforge2_deneme
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void x3LedProjesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LedForm ledformu = new LedForm();
            ledformu.ShowDialog();
        }

        private void stepMotorKontrolToolStripMenuItem_Click(object sender, EventArgs e)
        {
          

        }

        private void servoMotorKontrolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StepMotorForm servo = new StepMotorForm();
            servo.ShowDialog();
        }
    }
}
