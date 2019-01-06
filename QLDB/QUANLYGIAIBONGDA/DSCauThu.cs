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
    public partial class DSCauThu : Form
    {
        public DSCauThu()
        {
            InitializeComponent();
        }

        private void đăngKíHồSơĐộiBóngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DKHoSoDB frmDKHoSoDB = new DKHoSoDB();
            //frmDKHoSoDB.MdiParent = this;
            this.Close();
            frmDKHoSoDB.Show();
        }

        private void lịchThiĐấuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LichThiDau frmLichThiDau = new LichThiDau();
            //frmDKHoSoDB.MdiParent = this;
            this.Close();
            frmLichThiDau.Show();
        }

        private void kếtQuảThiĐấuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KetQua frmKQ = new KetQua();
            this.Close();
            frmKQ.Show();
        }

        private void danhSáchCầuThủToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void danhSáchCầuThủGhiBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DSCauThuGhiBan frmDSGhiBan = new DSCauThuGhiBan();
            this.Close();
            frmDSGhiBan.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DSCauThu_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT *FROM CAU_THU ";
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

                listView1.Items.Add(item);
            }
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO CAU_THU VALUES('" + txtidCauThu.Text + "','" + txtidDoiBong.Text + "','" + txtTen.Text + "','" + txtNgaySinh.Text + "','" + txtLoaiCauThu.Text + "','" + txtGhiChu.Text + "','" + txtidDoi.Text + "')";
            cmd.ExecuteNonQuery();
            DialogResult result;
            result = MessageBox.Show("THÊM DỮ LIỆU THÀNH CÔNG", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                this.Close();
                DSCauThu frm = new DSCauThu();
                frm.Show();
            }
        }
    }
}
