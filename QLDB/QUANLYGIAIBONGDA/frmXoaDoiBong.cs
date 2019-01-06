﻿using System;
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
    public partial class frmXoaDoiBong : Form
    {
        string idDoi;
        public frmXoaDoiBong(string str)
        {
            idDoi = str;
            InitializeComponent();
        }

        private void frmXoaDoiBong_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT IDSAN,IDLICH,TENDOI,SANNHA FROM DOIBONG WHERE IDDOIBONG='" + idDoi + "'";
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            this.txtidDoi.Text = idDoi;
            this.txtidSan.Text = td.Rows[0][0].ToString();
            this.txtidLich.Text = td.Rows[0][1].ToString();
            this.txtDoi.Text = td.Rows[0][2].ToString();
            this.txtSan.Text = td.Rows[0][3].ToString();

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "DELETE FROM DOIBONG Where IDDOIBONG='" + idDoi + "'";
            DialogResult result;
            result = MessageBox.Show("BẠN CÓ MUỐN XÓA THÔNG TIN KHÔNG?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("XÓA THÀNH CÔNG", "THÔNG BÁO");
                this.Close();
                DKHoSoDB frm = new DKHoSoDB();
                frm.Show();
            }
        }
    }
}
