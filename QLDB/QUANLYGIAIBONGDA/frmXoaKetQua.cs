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
    public partial class frmXoaKetQua : Form
    {
        public frmXoaKetQua()
        {
            InitializeComponent();
        }

        private void frmXoaKetQua_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT VONG,IDDOI1,IDDOI2,TYSO FROM LICH_DAU ";
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            this.txtVong.Text = td.Rows[0][0].ToString();
            this.txtDoi1.Text = td.Rows[0][1].ToString();
            this.txtDoi2.Text = td.Rows[0][2].ToString();
            this.txtTySo.Text = td.Rows[0][3].ToString();

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "DELETE VONG,IDDOI1,IDDOI2,TYSO FROM LICH_DAU"; 
            DialogResult result;
            result = MessageBox.Show("BẠN CÓ MUỐN THAY ĐỔI THÔNG TIN KHÔNG?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("CẬP NHẬT DỮ LIỆU THÀNH CÔNG", "THÔNG BÁO");
                this.Close();
                KetQua frm = new KetQua();
                frm.Show();
            }
        }
    }
}
