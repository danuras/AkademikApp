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
    public partial class FrmMahasiswa : Form
    {
        private IList<Mahasiswa> listOfMahasiswa = new List<Mahasiswa>();

        // constructor
        public FrmMahasiswa()
        {
            InitializeComponent();
            InisialisasiListView();
        }

        //atur kolom listview
        private void InisialisasiListView()
        {
            lvwMahasiswa.View = View.Details;
            lvwMahasiswa.FullRowSelect = true;
            lvwMahasiswa.GridLines = true;

            lvwMahasiswa.Columns.Add("No.", 30, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Npm", 91, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nama", 300, HorizontalAlignment.Left);
            lvwMahasiswa.Columns.Add("Angkatan", 80, HorizontalAlignment.Center);
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            FrmEntryMahasiswa frmEntry = new FrmEntryMahasiswa("Tambah Data Mahasiswa");

            //mendaftarkan method event handler utk merespon event OnCreate (subscribe)
            frmEntry.OnCreate += FrmEntry_OnCreate;

            frmEntry.ShowDialog();
        }

        private void btnPerbaiki_Click(object sender, EventArgs e)
        {
            if (lvwMahasiswa.SelectedItems.Count > 0)
            {
                //ambil object mhs yang mau diedit dari collection
                Mahasiswa mhs = listOfMahasiswa[lvwMahasiswa.SelectedIndices[0]];

                //buat object form entry entry data mahasiswa
                FrmEntryMahasiswa frmEntry = new FrmEntryMahasiswa("Edit Data Mahasiswa", mhs);

                //mendaftarkan method event handler utk merespon event OnUpdate (subscribe)
                frmEntry.onUpdate += FrmEntry_OnUpdate;

                //tampilkan form entry mahasiswa
                frmEntry.ShowDialog();
            }
            else
            {
                MessageBox.Show("Data belum dipilih", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //method event handler untuk merespon event OnCreate
        //ketika di panggil dari form entry mahasiswa
        private void FrmEntry_OnCreate(Mahasiswa mhs)
        {
            //tambahkan objek mhs yang baru ke dalam collection
            listOfMahasiswa.Add(mhs);

            int noUrut = lvwMahasiswa.Items.Count + 1;

            //tampilkan data mhs yg baru ke list view
            ListViewItem item = new ListViewItem(noUrut.ToString());
            item.SubItems.Add(mhs.Npm);
            item.SubItems.Add(mhs.Nama);
            item.SubItems.Add(mhs.Angkatan);

            lvwMahasiswa.Items.Add(item);
        }

        //method event handler untuk merespon event OnUpdate,
        //ketika di panggil dari form entry mahasiswa
        private void FrmEntry_OnUpdate(Mahasiswa mhs)
        {
            //ambil baris data mhs yang edit
            int row = lvwMahasiswa.SelectedIndices[0];

            //update informasi mhs di listview
            ListViewItem itemRow = lvwMahasiswa.Items[row];
            itemRow.SubItems[1].Text = mhs.Npm;
            itemRow.SubItems[2].Text = mhs.Nama;
            itemRow.SubItems[3].Text = mhs.Angkatan;
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (lvwMahasiswa.SelectedItems.Count > 0)
            {
                //ambil objek mhs yang mau dihapus dari collection
                Mahasiswa obj = listOfMahasiswa[lvwMahasiswa.SelectedIndices[0]];

                string msg = string.Format("Apakahh data mahasiswa '{0}' ingin dihapus ?", obj.Nama);

                if(MessageBox.Show(msg, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    //hapus objek mahasiswa dari collection
                    listOfMahasiswa.Remove(obj);

                    lvwMahasiswa.Items.Clear();

                    //refresh data mhs yang ditampilkan ke listview
                    foreach (Mahasiswa mhs in listOfMahasiswa)
                    {
                        int noUrut = lvwMahasiswa.Items.Count + 1;

                        ListViewItem item = new ListViewItem(noUrut.ToString());
                        item.SubItems.Add(mhs.Npm);
                        item.SubItems.Add(mhs.Nama);
                        item.SubItems.Add(mhs.Angkatan);

                        lvwMahasiswa.Items.Add(item);
                    }
                }
            }
            else
            {
                MessageBox.Show("Data Belum dipilih", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSelesai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
