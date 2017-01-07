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
        private HinhGif gifImage = null;
        //private string filePath = @"C:\Users\LUONGYANG\CaRoC1.2\CaRoC\Resources\banana.gif";

        public frmCaro()
        {
            InitializeComponent();

            grs = pnBanCo.CreateGraphics();//Khởi tạo đối tượng bàn cờ
            caroChess.KhoiTaoMangOCo();//Khởi tạo mảng ô cờ
            // Xử lý thời gian người chơi
            //prcbCoolDown.Step = BanCo.COOL_DOWN_STEP;
            //prcbCoolDown.Maximum = BanCo.COOL_DOWN_TIME;
            //prcbCoolDown.Value = 0;
            //tmCoolDown.Interval = BanCo.COOL_DOWN_INTERVAL;
            //tmCoolDown.Start();

         
        }

        public void ChayTimer()
        {
            // Xử lý thời gian người chơi
            prcbCoolDown.Step = BanCo.COOL_DOWN_STEP;
            prcbCoolDown.Maximum = BanCo.COOL_DOWN_TIME;
            prcbCoolDown.Value = 0;
            tmCoolDown.Interval = BanCo.COOL_DOWN_INTERVAL;
            tmCoolDown.Start();
        }

        public void KTThoiGian()
        {

         
            
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

           /* gifImage = new HinhGif(filePath);
            gifImage.ReverseAtEnd = false;*/
            timerImages.Enabled = true;

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
            ChayTimer();
            if (!caroChess.SanSang)
                return;
            if (caroChess.DanhCo(e.X, e.Y, grs))
            {
                if (caroChess.KiemTraChienThang())
                    caroChess.KetThucTroChoi();
                else
                {
                    if (caroChess.CheDoChoi == 1)
                    {
                        caroChess.KhoiDongComputer(grs);
                        if (caroChess.KiemTraChienThang())
                            caroChess.KetThucTroChoi();
                    }
                }
            }

        }

        private void ThongtinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongTin a = new ThongTin();//Khai báo form Thongtin
            a.Show();//Hiển thị form Thongtin
        }

        private void HuongdanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form hd = new Huongdan();//Khai báo form Huongdan
            hd.ShowDialog();//Hiển thị form Huongdan
        }

        private void ptchoigame_Click(object sender, EventArgs e)
        {
            label_HienThiTen.Text = "NGƯỜI VỚI MÁY";
            grs.Clear(pnBanCo.BackColor);//Xóa trống bàn cờ - trước khi bắt đầu chơi
            caroChess.BatDau(grs);//Bắt đầu chơi
            ChayTimer();
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
            label_HienThiTen.Text = "NGƯỜI VỚI NGƯỜI";
            grs.Clear(pnBanCo.BackColor);
            caroChess.Nguoi_va_Nguoi(grs);           
        }

        private void tmCoolDown_Tick(object sender, EventArgs e)
        {                    
            prcbCoolDown.PerformStep();
            if(prcbCoolDown.Value >= prcbCoolDown.Maximum)
            {
                prcbCoolDown.Value = 0;
                tmCoolDown.Stop();
                MessageBox.Show("Kết thúc game");
                Form ktgame = new frmKetThuc();
                ktgame.ShowDialog();
             }                    
        }

        private void timerImages_Tick(object sender, EventArgs e)
        {
          /*  imageGif.Image = gifImage.GetNextFrame();*/
        }

        private void prcbCoolDown_Click(object sender, EventArgs e)
        {

        }

        private void ThoatGameToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();//Thoát ứng dụng
        }

        private void NguoivsMayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grs.Clear(pnBanCo.BackColor);//Xóa trống bàn cờ - trước khi bắt đầu chơi
            caroChess.BatDau(grs);//Bắt đầu chơi
        }

        private void NguoivsNguoiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // form này sẽ hiện lên bàn cờ caro 2 người chơi
            grs.Clear(pnBanCo.BackColor);
            caroChess.Nguoi_va_Nguoi(grs);
        }

        private void NvsM_ReChuotRa(object sender, EventArgs e)// khi không đưa rê chuột vào button Người-Máy
        {
            ptchoigame.Image = Properties.Resources.btn_NvsM;//set ảnh button trạng thái k rê chuột ban đầu
            ptchoigame.Size = new Size(160, 72);// set kích thước button trạng thái k rê chuột ban đầu
        }

        private void NvsM_ReChuotVao(object sender, MouseEventArgs e)//khi rê chuột vào button Người-Máy
        {
            ptchoigame.Image = Properties.Resources.btn_NvsM2;//set ảnh button N_M ở trạng thái rê chuột vào (ảnh khác) 
            ptchoigame.Size = new Size(180, 80);//set kích thước button N_M ở trạng thái rê chuột vào (kích thước khác)
        }

        private void NvsN_ReChuotRa(object sender, EventArgs e)
        {
            pcChoi.Image = Properties.Resources.btn_NvsN;//set ảnh button trạng thái k rê chuột ban đầu
            pcChoi.Size = new Size(160, 72);// set kích thước button trạng thái k rê chuột ban đầu
        }

        private void NvsN_ReChuotVao(object sender, MouseEventArgs e)
        {
            pcChoi.Image = Properties.Resources.btn_NvsN2;//set ảnh button N_M ở trạng thái rê chuột vào (ảnh khác) 
            pcChoi.Size = new Size(180, 80);//set kích thước button N_M ở trạng thái rê chuột vào (kích thước khác)
        }

        private void ThoatGame_ReChuotRa(object sender, EventArgs e)
        {
            pcthoat.Image = Properties.Resources.btn_ThoatGame;//set ảnh button trạng thái k rê chuột ban đầu
            pcthoat.Size = new Size(160, 72);// set kích thước button trạng thái k rê chuột ban đầu
        }

        private void ThoatGame_ReChuotVao(object sender, MouseEventArgs e)
        {
            pcthoat.Image = Properties.Resources.btn_ThoatGame2;//set ảnh button N_M ở trạng thái rê chuột vào (ảnh khác) 
            pcthoat.Size = new Size(180, 80);//set kích thước button N_M ở trạng thái rê chuột vào (kích thước khác)v
        }

        private void imageGif_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Form tbt = new frmThongBao_Vdesign();
            tbt.Show();         
        }
    }
}
