using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace demoltud
{
    public partial class LichThiDau : Form
    {

        public LichThiDau()
        {
            InitializeComponent();
        }
        private bool CheckExistForm(string name)
        {
            bool check = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
        private void ActiveChildForm(string name)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    frm.Activate();
                    break;
                }
            }
        }


        private void đăngKíHồSơBóngĐáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("frmDKHoSoDB"))
            {
                DKHoSoDB frmDKHoSoDB = new DKHoSoDB();
                //frmDKHoSoDB.MdiParent = this;
                this.Close();
                frmDKHoSoDB.Show();
            }
            else
                ActiveChildForm("frmDKHoSoDB");
        }

        private void lịchThiĐấuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LichThiDau frmLichThiDau = new LichThiDau();
            this.Close();
            frmLichThiDau.Show();
        }

        private void kếtQuảThiĐấuToolStripMenuItem_Click(object sender, EventArgs e)
        {

            KetQua frmKQ = new KetQua();
            this.Close();
            frmKQ.Show();
        }

        private void cầuThủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DSCauThu frmDS = new DSCauThu();
            this.Close();
            frmDS.Show();
        }

        private void bảngXếpHạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BangXepHang frmBXH = new BangXepHang();
            this.Close();
            frmBXH.Show();
        }

        private void danhSáchCácCầuThủGhiBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DSCauThuGhiBan frmDSGhiBan = new DSCauThuGhiBan();
            this.Close();
            frmDSGhiBan.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO LICH_DAU VALUES('" + txtidLich.Text + "','" + txtidSan.Text + "','" + txtVong.Text + "','" + txtDoi1.Text + "','" + txtDoi2.Text + "','" + txtNgay.Text + "','" + txtSan.Text + "','" + txtTySo.Text + "')";
            cmd.ExecuteNonQuery();
            DialogResult result;
            result = MessageBox.Show("THÊM DỮ LIỆU THÀNH CÔNG", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                this.Close();
                LichThiDau frm = new LichThiDau();
                frm.Show();
            }
        }

        private void LichThiDau_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM LICH_DAU ";
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            for (int i = 0; i < td.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(td.Rows[i][0].ToString());
                item.SubItems.Add(td.Rows[i][1].ToString());
                item.SubItems.Add(td.Rows[i][2].ToString());
                item.SubItems.Add(td.Rows[i][3].ToString());
                item.SubItems.Add(td.Rows[i][4].ToString());
                item.SubItems.Add(td.Rows[i][5].ToString());
                item.SubItems.Add(td.Rows[i][6].ToString());
                item.SubItems.Add(td.Rows[i][7].ToString());

                listView1.Items.Add(item);

            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str;
            int row = this.listView1.SelectedItems[0].Index;
            str = this.listView1.Items[row].SubItems[0].Text;
            frmSuaLichThiDau frm = new frmSuaLichThiDau(str);
            frm.Show();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string str;
            int row = this.listView1.SelectedItems[0].Index;
            str = this.listView1.Items[row].SubItems[0].Text;
            frmXoaLichDau frm = new frmXoaLichDau(str);
            frm.Show();

        }
    }
}

