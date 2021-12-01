using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikasiCalculator
{
    public partial class HasilPerhitungan : Form
    {
        public HasilPerhitungan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Calculator calculator = new Calculator();

            calculator.OnUpdate += lstBox_OnUpdate;

            calculator.ShowDialog();
        }

        private void lstBox_OnUpdate(String hasil)
        {
            lstOutput.Items.Add(hasil);
        }
    }
}
