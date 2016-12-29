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
        private CaroChess caroChess = new CaroChess();//Khai báo + Khởi tạo đối tượng bàn cờ caro
        private Graphics grs;//Khai báo đồ họa dùng để vẽ bàn cờ
        System.Media.SoundPlayer nhac = new SoundPlayer(Application.StartupPath + "\\Music\\nhacnen.WAV");//Khai báo âm thanh nhạc nền
        System.Media.SoundPlayer nhacclick = new SoundPlayer(Application.StartupPath + "\\Music\\Sung2.WAV");
        
        bool Nhacplay = true; //Khởi tạo trạng thái phát nhạc - mặc định phát khi khởi động      

        public frmCaro()
        {
            InitializeComponent();

            grs = pnBanCo.CreateGraphics();//Khởi tạo đối tượng bàn cờ
            caroChess.KhoiTaoMangOCo();//Khởi tạo mảng ô cờ
        }

        private void tmThongTin_Tick(object sender, EventArgs e)
        {   //lấy tọa độ label chuỗi chữ
            lblChuoiChu.Location = new Point(lblChuoiChu.Location.X, lblChuoiChu.Location.Y - 1);

            if (lblChuoiChu.Location.Y + lblChuoiChu.Height < 0)
            {
                lblChuoiChu.Location = new Point(lblChuoiChu.Location.X, pnThongTin.Height);
            }
        }

        private void frmCaro_Load(object sender, EventArgs e)
        {   //set chuỗi cho label
            lblChuoiChu.Text = "Đây là sản phầm của đồ án \nmôn công cụ và môi trường\nphát triển phần mềm.\nĐồ án  được  thực  hiện với\nmục đích demo tạo ra vùng\nlàm việc  nhóm trên github";
            //set font chữ label
            lblChuoiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tmThongTin.Enabled = true; // gọi timertick
            XuLyNhac();// gọi hàm xử lý nhạc
        }

        public void XuLyNhac()
        {
            if (Nhacplay == true)
            {
                nhac.PlayLooping();
            }
            else
            {
                nhac.Stop();
            }
        }


        private void pnBanCo_Paint(object sender, PaintEventArgs e)
        {
            caroChess.VeBanCo(grs);
            caroChess.VeLaiQuanCo(grs);
        }

        private void pnBanCo_MouseClick(object sender, MouseEventArgs e)
        {
            nhacclick.Play();
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

        private void ThongtinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongTin a = new ThongTin();//Khai báo form Thongtin
            a.Show();//Hiển thị form Thongtin
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();//Thoát ứng dụng
        }

        private void HuongdanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form hd = new Huongdan();//Khai báo form Huongdan
            hd.ShowDialog();//Hiển thị form Huongdan
        }

        private void ptchoigame_Click(object sender, EventArgs e)
        {
            grs.Clear(pnBanCo.BackColor);//Xóa trống bàn cờ - trước khi bắt đầu chơi
            caroChess.BatDau(grs);//Bắt đầu chơi
        }

        private void pcthoat_Click(object sender, EventArgs e)
        {
            frmThongBao_Vdesign tb = new frmThongBao_Vdesign();//Khái báo form Thongbao
            tb.Show();//Hiển thị form Thongbao
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grs.Clear(pnBanCo.BackColor);//Xóa trống bàn cờ - trước khi bắt đầu chơi
            caroChess.BatDau(grs);//Bắt đầu chơi
        }

        private void pcNhac_Click(object sender, EventArgs e)
        {
            //pcNhac.Image = Properties.Resources.OnMusic;//Khởi

            if (Nhacplay == true)//Kiểm tra trạng thái âm nhạc hiện tại
            {
                pcNhac.Image = Properties.Resources.OffMusic;//set hình button trạng thái nhạc tắt
                Nhacplay = false;//set trạng thái nhạc tắt
                XuLyNhac();//cập nhật trạng thái nhạc
            }
            else
            {
                pcNhac.Image = Properties.Resources.OnMusic;// set hình button trạng thái nhạc mở
                Nhacplay = true;//set trạng thái nhạc tắt
                XuLyNhac();//cập nhật trạng thái nhạc
            }
        }

        private void pcChoi_Click(object sender, EventArgs e)
        {
            // form này sẽ hiện lên bàn cờ caro 2 người chơi
        }
    }
}
