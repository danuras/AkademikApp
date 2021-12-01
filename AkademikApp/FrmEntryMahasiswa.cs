using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkademikApp
{
    public partial class FrmEntryMahasiswa : Form
    {
        //deklarasi tipe data untuk event OnCreate dan OnUpdate
        public delegate void CreateUpdateEventHandler(Mahasiswa mhs);

        //deklarasi event ketika terjadi proses input data baru
        public event CreateUpdateEventHandler OnCreate;

        //deklarasi event ketika terjadi proses update data
        public event CreateUpdateEventHandler onUpdate;

        //deklarasi field untuk menyimpan status entry data (input baru atau update)
        private bool isNewData = true;

        //deklarasi field untuk menyimpan objek mahasiswa 
        Mahasiswa mhs;
        // Constructor untuk inisialisasi data ketika entri data baru
        public FrmEntryMahasiswa()
        {
            //ganti text/judul form
            InitializeComponent();
        }

        //Constructor untuk inisialisasi entri data baru
        public FrmEntryMahasiswa(string title):this()
        {
            //ganti text/judul form
            this.Text = title;
        }

        //Constructor untuk inisialisasi data ketika mengedit data
        public FrmEntryMahasiswa(string title, Mahasiswa obj):this()
        {
            //ganti text/judul form
            this.Text = title;

            isNewData = false;// set status edit data
            mhs = obj;// set object mhs yang akan diedit

            //untuk edit data, tampilankan data lama
            txtNpm.Text = mhs.Npm;
            txtNama.Text = mhs.Nama;
            txtAngkatan.Text = mhs.Angkatan;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            //jika data baru, inisialisasi objek mahasiswa
            if (isNewData) mhs = new Mahasiswa();

            //set nilai property objek mahasiswa yang diambil dari textBox
            mhs.Npm = txtNpm.Text;
            mhs.Nama = txtNama.Text;
            mhs.Angkatan = txtAngkatan.Text;

            if (isNewData)//data baru
            {
                OnCreate(mhs); //panggil event OnCreate

                // reset form input, utk persiapan input data berikutnya
                txtNpm.Clear();
                txtNama.Clear();
                txtAngkatan.Clear();

                txtNpm.Focus();
            }
            else
            {
                onUpdate(mhs);//panggil event OnUpdate
                this.Close();
            }
        }

        private void btnSelesai_Click(object sender, EventArgs e)
        {
            //tutup form entry data mahasiswa
            this.Close();
        }

    }
    
}
