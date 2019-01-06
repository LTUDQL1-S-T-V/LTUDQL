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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9LI3A0D;Initial Catalog=QLDB;Integrated Security=True");
            con.Open();
            string tk = txtTaiKhoan.Text;
            string mk = txtMatKhau.Text;
            string sql = "SELECT * FROM QuanLyNguoiDung WHERE TaiDangNhap='" + tk + "' AND MatKhau='" + mk + "' ";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dta = cmd.ExecuteReader();
            if (dta.Read() == true)
            {
                MessageBox.Show("Đăng nhập thành công");
                frmMenu frm = new frmMenu();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại");
            }
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
