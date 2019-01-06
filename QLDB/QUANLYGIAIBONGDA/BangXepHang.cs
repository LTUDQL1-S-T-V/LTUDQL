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
    public partial class BangXepHang : Form
    {
        public BangXepHang()
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

        private void lịchThiĐấuToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LichThiDau frmLichThiDau = new LichThiDau();
            //frmDKHoSoDB.MdiParent = this;
            this.Close();
            frmLichThiDau.Show();
        }

        private void kếtQuảThiĐấuToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            KetQua frmKQ = new KetQua();
            this.Close();
            frmKQ.Show();
        }

        private void danhSáchCầuThủToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DSCauThu frmDS = new DSCauThu();
            this.Close();
            frmDS.Show();
        }

        private void bảngXếpHạngToolStripMenuItem_Click_1(object sender, EventArgs e)
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

        private void thoátToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            this.Close();
        }

        private void BangXepHang_Load(object sender, EventArgs e)
        {
           
        }
    }
}
