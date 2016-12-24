using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaRoC
{
    class BanCo
    {
        //chinh sua lai gia dien
        private int _SoDong;
        private int _SoCot;
        Image imageO = new Bitmap(Properties.Resources.o);
        Image imageX = new Bitmap(Properties.Resources.x);
        Color bgColor = Color.YellowGreen;

        public int SoDong
        {
            get
            {
                return _SoDong;
            }

        }

        public int SoCot
        {
            get
            {
                return _SoCot;
            }

        }

        public BanCo()
        {
            _SoDong = 0;
            _SoCot = 0;
        }
        // khởi tạo số dòng số code của ban cờ
        public BanCo(int sd,int sc)
        {
            _SoDong = sd;
            _SoCot = sc;
        }
        //hàm vẽ bàn cờ
        public void VeBanCo(Graphics g)
        {
            // vẽ hàng ngang
            for (int i = 0; i <= SoCot; i++)
            {
                g.DrawLine(CaroChess.pen, i * OCo.ChieuRong, 0, i * OCo.ChieuRong, SoDong * OCo.ChieuCao);
            }
            // vẽ theo chiều cao
            for (int j = 0; j <= SoDong; j++)
            {
                g.DrawLine(CaroChess.pen, 0, j * OCo.ChieuCao, SoCot * OCo.ChieuRong, j * OCo.ChieuCao);
            }
        }

        public void VeQuanCo(Graphics g, Point point, Image sb)
        {
           
            g.DrawImage(sb, point.X, point.Y, OCo.ChieuRong, OCo.ChieuCao);
            
        }
    }
}
