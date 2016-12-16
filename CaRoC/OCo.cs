using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaRoC
{
    class OCo
    {
        public const int ChieuRong = 25;
        public const int ChieuCao = 25;

        private int _Dong;

        public int Dong
        {
            get
            {
                return _Dong;
            }

            set
            {
                _Dong = value;
            }
        }

        private int _Cot;

        public int Cot
        {
            get
            {
                return _Cot;
            }

            set
            {
                _Cot = value;
            }
        }

        private Point _ViTri;

        public Point ViTri
        {
            get
            {
                return _ViTri;
            }

            set
            {
                _ViTri = value;
            }
        }

        private int _SoHuu;
        public int SoHuu
        {
            get
            {
                return _SoHuu;
            }

            set
            {
                _SoHuu = value;
            }
        }

        public OCo()
        {

        }
        public OCo(int dong,int cot,Point vitri,int sohuu)
        {
            _Dong = dong;
            _Cot = cot;
            _ViTri = vitri;
            _SoHuu = sohuu;
        }
        

        
        
    }
}
