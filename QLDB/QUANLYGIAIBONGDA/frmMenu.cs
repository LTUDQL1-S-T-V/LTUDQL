using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoltud
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }
        private bool CheckExistForm(string name)
        {
            bool check = false;
            foreach(Form frm in this.MdiChildren)
            {
                if(frm.Name==name)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("frmDKHoSoDB"))
            {
                DKHoSoDB frmDKHoSoDB = new DKHoSoDB();
                frmDKHoSoDB.Show();
            }
            else
                ActiveChildForm("frmDKHoSoDB");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("frmLichThiDau"))
            {
                LichThiDau frmLichThiDau = new LichThiDau();
                frmLichThiDau.Show();
            }
            else
                ActiveChildForm("frmLichThiDau");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KetQua frmKQ = new KetQua();
            frmKQ.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            DSCauThu frmDS = new DSCauThu();

            frmDS.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            BangXepHang frmBXH = new BangXepHang();
            frmBXH.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DSCauThuGhiBan frmDSGhiBan = new DSCauThuGhiBan();
            frmDSGhiBan.Show();
        }
       
    }
}
