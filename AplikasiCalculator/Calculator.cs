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
    public partial class Calculator : Form
    {
        //deklarasi tipe data untuk event OnCreate dan OnUpdate
        public delegate void CreateUpdateEventHandler(String hasil);

        //deklarasi event ketika terjadi proses update data
        public event CreateUpdateEventHandler OnUpdate;
        public Calculator()
        {
            InitializeComponent();
        }
        private void btnProses_Click(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(txtNilaiA.Text);
                int b = int.Parse(txtNilaiB.Text);
                string hasil = "";
                int idx = cmbBoxOperation.SelectedIndex;
                Operasi operasi = new Operasi();
                if (idx == 0) hasil = "Hasil Penambahan " + txtNilaiA.Text + " + " + txtNilaiB.Text + " = " + operasi.Penambahan(a, b);
                else if (idx == 1) hasil = "Hasil Pengurangan " + txtNilaiA.Text + " - " + txtNilaiB.Text + " = " + operasi.Pengurangan(a, b);
                else if (idx == 2) hasil = "Hasil Perkalian " + txtNilaiA.Text + " * " + txtNilaiB.Text + " = " + operasi.Perkalian(a, b);
                else if (idx == 3) hasil = "Hasil Pembagian " + txtNilaiA.Text + " / " + txtNilaiB.Text + " = " + operasi.Pembagian(a, b);
                else if (idx == 4) hasil = "Hasil Pangkat " + txtNilaiA.Text + " ^ " + txtNilaiB.Text + " = " + operasi.Pangkat(a, b);
                else if (idx == 5) hasil = "Hasil Modulo " + txtNilaiA.Text + " % " + txtNilaiB.Text + " = " + operasi.Modulo(a, b);
                OnUpdate(hasil);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: "+ ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
