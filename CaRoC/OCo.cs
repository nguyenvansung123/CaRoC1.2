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
        //gán giá trị số ô cho chiều rộng
        public const int ChieuRong = 25;
        //gán giá trị số ô cho chiều cao
        public const int ChieuCao = 25;
        //biến này dùng để gọi số dòng
        private int _Dong;
        //hàm lấy giá trị và gán cho dòng
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
        //hàm lấy giá trị và gán cho cột
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
        // hàm gán giá trị và lấy cho vị trí
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
        //gán giá trị và lấy cho sở hữu
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
        // khởi tạo bàn cờ
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
