using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace CaRoC
{
    public partial class frmCaro : Form
    {
        private CaroChess caroChess;
        private Graphics grs;
        System.Media.SoundPlayer nhac = new SoundPlayer("C://Users//nguyenvansung//CaRoC1.2//CaRoC//Resources//nhacnen.WAV");
        bool Nhacplay=true;

        public frmCaro()
        {
            InitializeComponent();

            //SoundPlayer Sound = new SoundPlayer("C://Users//LUONG YANG//CaRoC1.2//CaRoC//Resources//nhacnen.wav");
            //Sound.Play();

            caroChess = new CaroChess();
            grs = pnBanCo.CreateGraphics();
            caroChess.KhoiTaoMangOCo();
        }

       

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    DialogResult h = MessageBox.Show("Bạn thực sự muốn thoát", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
        //    if (h == DialogResult.Yes)
        //    {
        //        Application.Exit();
        //    }

        //}

        private void tmThongTin_Tick(object sender, EventArgs e)
        {
            lblChuoiChu.Location = new Point(lblChuoiChu.Location.X, lblChuoiChu.Location.Y - 1);
            if (lblChuoiChu.Location.Y + lblChuoiChu.Height < 0)
            {
                lblChuoiChu.Location = new Point(lblChuoiChu.Location.X, pnThongTin.Height);
            }
        }

        private void frmCaro_Load(object sender, EventArgs e)
        {
            lblChuoiChu.Text = "Đây là sản phầm của đồ án \nmôn công cụ và môi trường\nphát triển phần mềm.\nĐồ án  được  thực  hiện với\nmục đích demo tạo ra vùng\nlàm việc  nhóm trên github";
            lblChuoiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tmThongTin.Enabled = true;
            XuLyNhac();
          

        }
        

        private void pnBanCo_Paint(object sender, PaintEventArgs e)
        {
            caroChess.VeBanCo(grs);
            caroChess.VeLaiQuanCo(grs);
        }

        private void pnBanCo_MouseClick(object sender, MouseEventArgs e)
        {
            if (!caroChess.SanSang)
                return;
            caroChess.DanhCo(e.X, e.Y, grs);

            if (caroChess.KiemTraChienThang())
            {
                caroChess.KetThucTroChoi();
            }
            caroChess.KhoiDongComputer(grs);
            if (caroChess.KiemTraChienThang())
            {
                caroChess.KetThucTroChoi();
            }

        }

        //private void btnBatDau_Click(object sender, EventArgs e)
        //{
        //    grs.Clear(pnBanCo.BackColor);
        //    caroChess.BatDau(grs);

        //}

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    ThongTin a = new ThongTin();
        //    a.Show();
        //}

        private void ThongtinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongTin a = new ThongTin();
            a.Show();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Application.Exit();

        }

        private void HuongdanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //phím tắt qua form hướng dẫn 
            Form hd = new Huongdan();
            hd.ShowDialog();
        }

        private void ptchoigame_Click(object sender, EventArgs e)
        {
            grs.Clear(pnBanCo.BackColor);
            caroChess.BatDau(grs);
        }

        private void pcthoat_Click(object sender, EventArgs e)
        {
            frmThongBao_Vdesign tb = new frmThongBao_Vdesign();
            tb.Show();

            //DialogResult h = MessageBox.Show("Bạn thực sự muốn thoát", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            //if (h == DialogResult.Yes)
            //{
            //    Application.Exit();
            //}
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grs.Clear(pnBanCo.BackColor);
            caroChess.BatDau(grs);
        }

        private void pnThongTin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pcNhac_Click(object sender, EventArgs e)
        {
            pcNhac.Image = Properties.Resources.OnMusic;
            if (Nhacplay==true)
            {//set hình button trạng thái nhạc mở
                pcNhac.Image = Properties.Resources.OffMusic;
                Nhacplay = false;
                XuLyNhac();
            }
            else
            {// set hình button trạng thái nhạc tắt
                pcNhac.Image = Properties.Resources.OnMusic;
                Nhacplay = true;
                XuLyNhac();
            }
        }

        public void XuLyNhac()
        {
            if (Nhacplay == true)
            {
                nhac.Play();
            }
            else
            {
                nhac.Stop();
            }
        }

       
    }
}
