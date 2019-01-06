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
    public partial class frmSuaLichThiDau : Form
    {
        string idLich;
        public frmSuaLichThiDau(string str)
        {
            idLich = str;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE LICH_DAU SET IDSAN='" + txtidSan.Text + "',VONG='" + txtVong.Text + "',IDDOI1='" + txtDoi1.Text + "',IDDOI2='" + txtDoi2.Text + "',THOIGIAN='" + txtNgay.Text + "',SAN='" + txtSan.Text + "',TYSO='" + txtTySo.Text + "'WHERE IDLICH'" + idLich + "'";
            DialogResult result;
            result = MessageBox.Show("BẠN CÓ MUỐN THAY ĐỔI THÔNG TIN KHÔNG?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("CẬP NHẬT DỮ LIỆU THÀNH CÔNG", "THÔNG BÁO");
                this.Close();
                LichThiDau frm = new LichThiDau();
                frm.Show();
            }
        }

        private void frmSuaLichThiDau_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT IDSAN,VONG,IDDOI1,IDDOI2,THOIGIAN,SAN,TYSO FROM LICH_DAU WHERE IDLICH='" + idLich + "'";
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            this.txtidLich.Text = idLich;
            this.txtidSan.Text = td.Rows[0][0].ToString();
            this.txtVong.Text = td.Rows[0][1].ToString();
            this.txtDoi1.Text = td.Rows[0][2].ToString();
            this.txtDoi2.Text = td.Rows[0][3].ToString();
            this.txtNgay.Text = td.Rows[0][4].ToString();
            this.txtSan.Text = td.Rows[0][5].ToString();
            this.txtTySo.Text = td.Rows[0][6].ToString();

            con.Close();
        }
    }
}
