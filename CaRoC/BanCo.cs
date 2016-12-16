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

        public BanCo(int sd,int sc)
        {
            _SoDong = sd;
            _SoCot = sc;
        }

        public void VeBanCo(Graphics g)
        {
            for(int i=0; i<= SoCot;i++)
            {
                g.DrawLine(CaroChess.pen, i * OCo.ChieuRong, 0, i * OCo.ChieuRong, SoDong * OCo.ChieuCao);
            }
            for (int j = 0; j <= SoDong; j++)
            {
                g.DrawLine(CaroChess.pen, 0,j*OCo.ChieuCao, SoCot*OCo.ChieuRong, j*OCo.ChieuCao);
            }
        }

        public void VeQuanCo(Graphics g, Point point, Image sb)
        {
           
            g.DrawImage(sb, point.X, point.Y, OCo.ChieuRong, OCo.ChieuCao);
            
        }
    }
}
