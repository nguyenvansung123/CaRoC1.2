using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaRoC
{
    public enum KETTHUC
    {
        HoaCo,
        NguoiChoi,
        MayAI
    }
    class CaroChess
    {
        public static Pen pen;
        public static Image CoO;
        public static Image CoX;
        private List<OCo> DS_CacNuocDaDi;
        private int _LuotDi;
        private bool _SanSang;
        
        private OCo[,] _MangOCo;
        private BanCo _BanCo;
        private KETTHUC _ketthuc;

        public bool SanSang
        {
            get
            {
                return _SanSang;
            }

        }

        public CaroChess()
        {
            pen = new Pen(Color.Red);
            CoO = new Bitmap(Properties.Resources.o);

            CoX = new Bitmap(Properties.Resources.x);
            _BanCo = new BanCo(20, 20);
            _MangOCo = new OCo[_BanCo.SoDong, _BanCo.SoCot];
            DS_CacNuocDaDi = new List<OCo>();
            _LuotDi = 1;
        }
        public void VeBanCo(Graphics g)
        {
            _BanCo.VeBanCo(g);
        }

        public void KhoiTaoMangOCo()
        {
            for(int i=0;i< _BanCo.SoDong;i++)
            {
                for(int j=0;j<_BanCo.SoCot;j++)
                {
                    _MangOCo[i, j] = new OCo(i,j,new Point(j*OCo.ChieuRong,i*OCo.ChieuCao),0);
                }
            }
        }
        public bool DanhCo(int MouseX,int MouseY,Graphics g)
        {
            if (MouseX % OCo.ChieuRong == 0|| MouseY % OCo.ChieuCao==0)
                return false;
            int cot = MouseX / OCo.ChieuRong;
            int dong = MouseY / OCo.ChieuCao;
            if(_MangOCo[dong,cot].SoHuu!=0)
            {
                return false;
            }
            switch(_LuotDi)
            {
                case 1:
                    _MangOCo[dong, cot].SoHuu = 1;
                    _BanCo.VeQuanCo(g, _MangOCo[dong, cot].ViTri, CoX);
                    _LuotDi = 2;
                    break;
                case 2:
                    _MangOCo[dong, cot].SoHuu = 2;
                    _BanCo.VeQuanCo(g, _MangOCo[dong, cot].ViTri, CoO);
                    _LuotDi = 1;
                    break;
                default:
                    MessageBox.Show("Loi!!!");
                    break;
            }

           
            
            DS_CacNuocDaDi.Add(_MangOCo[dong, cot]);
            return true;
        }
        public void VeLaiQuanCo(Graphics g)
        {
            foreach(OCo oco in DS_CacNuocDaDi)
            {
                if (oco.SoHuu == 1)
                    _BanCo.VeQuanCo(g, oco.ViTri, CoX);
                else
                    if (oco.SoHuu == 2)
                    _BanCo.VeQuanCo(g, oco.ViTri, CoO);
            }
        }

        public void BatDau(Graphics g)
        {
            _SanSang = true;
            DS_CacNuocDaDi = new List<OCo>();
            KhoiTaoMangOCo();
            _LuotDi =1;
            VeBanCo(g);
            KhoiDongComputer(g);
        }

        public void KetThucTroChoi()
        {
            switch (_ketthuc)
            {
                case KETTHUC.HoaCo:
                    MessageBox.Show("hòa cờ rồi!");
                    break;
                case KETTHUC.NguoiChoi:
                    // MessageBox.Show("Máy thắng rồi!");
                    Form tb = new Thatbbai();
                    tb.ShowDialog();
                    break;
                case KETTHUC.MayAI:
                    //MessageBox.Show("Bạn đã thắng");
                    Form ct = new Chienthang();
                    ct.ShowDialog();
                    break;
            }
            _SanSang = false;
        }
        public bool KiemTraChienThang()
        {
            if(DS_CacNuocDaDi.Count==_BanCo.SoCot*_BanCo.SoDong)
            {
                _ketthuc = KETTHUC.HoaCo;
                return true;
            }

            foreach(OCo oco in DS_CacNuocDaDi)
            {
                if(DuyetDoc(oco.Dong,oco.Cot,oco.SoHuu)||DuyetNgang(oco.Dong, oco.Cot, oco.SoHuu)||DuyetCheoXuoi(oco.Dong, oco.Cot, oco.SoHuu)||DuyetCheoNguoc(oco.Dong, oco.Cot, oco.SoHuu))
                {
                    _ketthuc = oco.SoHuu == 1 ? KETTHUC.NguoiChoi : KETTHUC.MayAI;
                    return true;
                }
            }
            return false;
        }
        private bool DuyetDoc(int currDong,int currCot, int currSoHuu)
        {
            if (currDong > _BanCo.SoDong - 5)
                return false;
            int dem;
            for(dem=1;dem<5;dem++)
            {
                if (_MangOCo[currDong + dem, currCot].SoHuu != currSoHuu)
                    return false;
            }
            if (currDong == 0|| currDong+dem==_BanCo.SoDong)
                return true;
            if (_MangOCo[currDong - 1, currCot].SoHuu == 0||_MangOCo[currDong+dem,currCot].SoHuu==0)
                return true;
            return false;
        }
        private bool DuyetNgang(int currDong, int currCot, int currSoHuu)
        {
            if (currCot > _BanCo.SoCot - 5)
                return false;
            int dem;
            for (dem = 1; dem < 5; dem++)
            {
                if (_MangOCo[currDong , currCot + dem].SoHuu != currSoHuu)
                    return false;
            }
            if (currCot == 0 || currCot + dem == _BanCo.SoCot)
                return true;
            if (_MangOCo[currDong, currCot - 1].SoHuu == 0 || _MangOCo[currDong, currCot + dem].SoHuu == 0)
                return true;
            return false;
        }
        private bool DuyetCheoXuoi(int currDong, int currCot, int currSoHuu)
        {
            if (currDong > _BanCo.SoDong -5 || currCot > _BanCo.SoCot - 5)
                return false;
            int dem;
            for (dem = 1; dem < 5; dem++)
            {
                if (_MangOCo[currDong+dem, currCot + dem].SoHuu != currSoHuu)
                    return false;
            }
            if (currDong==0 || currDong+dem == _BanCo.SoDong || currCot == 0 || currCot + dem == _BanCo.SoCot)
                return true;
            if (_MangOCo[currDong-1, currCot - 1].SoHuu == 0 || _MangOCo[currDong+dem, currCot + dem].SoHuu == 0)
                return true;
            return false;
        }
        //private bool DuyetCheoNguoc(int currDong, int currCot, int currSoHuu)
        //{
        //    if (currDong <4 || currCot > _BanCo.SoCot - 5)
        //        return false;
        //    int dem;
        //    for (dem = 1; dem < 5; dem++)
        //    {
        //        if (_MangOCo[currDong-dem, currCot + dem].SoHuu != currSoHuu)
        //            return false;
        //    }
        //    if (currDong==4 || currDong==_BanCo.SoDong-1||currCot==0||currCot+dem==_BanCo.SoCot)
        //        return true;
        //    if (_MangOCo[currDong+1, currCot - 1].SoHuu == 0 || _MangOCo[currDong-dem, currCot + dem].SoHuu == 0)
        //        return true;
        //    return false;
        //}


        //tri thong minh nhan tao


        //private long[] MangDiemTanCong = new long[7] {0, 3, 24, 192, 1536, 12288, 98304 }; //đặt giá trị cho từng tầng của cây
        //private long[] MangDiemPhongNgu = new long[7] {0, 1, 9, 81, 729, 6561, 59849 };
        private long[] MangDiemTanCong = new long[7]  { 0, 9, 54, 162, 1458, 13112,118008 }; //đặt giá trị cho từng tầng của cây
        private long[] MangDiemPhongNgu = new long[7] { 0, 3, 27, 99, 729, 6561, 59049 };

        public void KhoiDongComputer(Graphics g)
        {
            
                if (DS_CacNuocDaDi.Count == 0)
                {
                    DanhCo(_BanCo.SoCot / 2 * OCo.ChieuRong + 1, _BanCo.SoDong / 2 * OCo.ChieuCao + 1, g);
                }

                else
                {
                    OCo oco = TimKiemNuocDi();
                    DanhCo(oco.ViTri.X + 1, oco.ViTri.Y + 1, g);
                }
            
        }
        private OCo TimKiemNuocDi()
        {
            OCo ocoResult = new OCo();
            long DiemMax = 0;
            //thuật toán vét cạn
            for(int i=0;i<_BanCo.SoDong;i++)
            {
                for(int j=0;j<_BanCo.SoCot;j++)
                {
                    if(_MangOCo[i,j].SoHuu==0)
                    {
                        //khỏi tạo các biến
                        long DiemTanCong  = DiemTC_DuyetDoc(i,j) + DiemTC_DuyetNgang(i,j) + DiemTC_DuyetCheoNguoc(i,j) + DiemTC_DuyetCheoXuoi(i,j);
                        long DiemPhongNgu = DiemPN_DuyetDoc(i, j) + DiemPN_DuyetNgang(i, j) + DiemPN_DuyetCheoNguoc(i, j) + DiemPN_DuyetCheoXuoi(i, j);
                        long DiemTam = DiemTanCong > DiemPhongNgu ? DiemTanCong : DiemPhongNgu;
                        if(DiemMax < DiemTam)
                        {
                            DiemMax = DiemTam;
                            ocoResult = new OCo(_MangOCo[i, j].Dong, _MangOCo[i, j].Cot, _MangOCo[i, j].ViTri, _MangOCo[i,j].SoHuu);
                        }
                    }
                }
            }
            return ocoResult;
        }

        //Tấn Công
        private long DiemTC_DuyetDoc(int currDong,int currCot)
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int dem=1; dem < 6 && currDong + dem < _BanCo.SoDong; dem++)
            {
                if (_MangOCo[currDong + dem, currCot].SoHuu == 1)
                    SoQuanTa++;
                else if (_MangOCo[currDong + dem, currCot].SoHuu == 2)
                {
                    SoQuanDich++;

                    break;
                }
                else
                    break;
            }
            for (int dem=1; dem < 6 && currDong - dem >= 0; dem++)
            {
                if (_MangOCo[currDong - dem, currCot].SoHuu == 1)
                    SoQuanTa++;
                else if (_MangOCo[currDong - dem, currCot].SoHuu == 2)
                {
                    SoQuanDich++;

                    break;
                }
                else
                    break;
            }

            if (SoQuanDich == 2)
                return 0;
            DiemTong -= MangDiemPhongNgu[SoQuanDich + 1]*2;
            DiemTong += MangDiemTanCong[SoQuanTa];
            return DiemTong;

        }
        private long DiemTC_DuyetNgang(int currDong, int currCot)
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int dem=1; dem < 6 && currCot + dem < _BanCo.SoCot; dem++)
            {
                if (_MangOCo[currDong, currCot + dem].SoHuu == 1)
                    SoQuanTa++;
                else if (_MangOCo[currDong, currCot + dem].SoHuu == 2)
                {
                    SoQuanDich++;

                    break;
                }
                else
                    break;
            }
            for (int dem=1; dem < 6 && currCot - dem >= 0; dem++)
            {
                if (_MangOCo[currDong, currCot - dem].SoHuu == 1)
                    SoQuanTa++;
                else if (_MangOCo[currDong, currCot - dem].SoHuu == 2)
                {
                    SoQuanDich++;

                    break;
                }
                else
                    break;
            }

            if (SoQuanDich == 2)
                return 0;
            DiemTong -= MangDiemPhongNgu[SoQuanDich + 1]*2;
            DiemTong += MangDiemTanCong[SoQuanTa];
            return DiemTong;
        }
        private long DiemTC_DuyetCheoNguoc(int currDong, int currCot)
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int dem=1; dem < 6 && currCot + dem < _BanCo.SoCot && currDong-dem>=0; dem++)
            {
                if (_MangOCo[currDong-dem, currCot + dem].SoHuu == 1)
                    SoQuanTa++;
                else if (_MangOCo[currDong-dem, currCot + dem].SoHuu == 2)
                {
                    SoQuanDich++;

                    break;
                }
                else
                    break;
            }
            for (int dem=1; dem < 6 && currCot - dem >= 0 &&  currDong + dem <_BanCo.SoDong; dem++)
            {
                if (_MangOCo[currDong + dem, currCot - dem].SoHuu == 1)
                    SoQuanTa++;
                else if (_MangOCo[currDong + dem, currCot - dem].SoHuu == 2)
                {
                    SoQuanDich++;

                    break;
                }
                else
                    break;
            }

            if (SoQuanDich == 2)
                return 0;
            DiemTong -= MangDiemPhongNgu[SoQuanDich + 1]*2;
            DiemTong += MangDiemTanCong[SoQuanTa];
            return DiemTong;
        }
        private long DiemTC_DuyetCheoXuoi(int currDong, int currCot)
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int dem=1; dem < 6 && currCot + dem < _BanCo.SoCot && currDong + dem < _BanCo.SoDong; dem++)
            {
                if (_MangOCo[currDong + dem, currCot + dem].SoHuu == 1)
                    SoQuanTa++;
                else if (_MangOCo[currDong + dem, currCot + dem].SoHuu == 2)
                {
                    SoQuanDich++;

                    break;
                }
                else
                    break;
            }
            for (int dem=1; dem < 6 && currCot - dem >= 0 && currDong - dem  >= 0; dem++)
            {
                if (_MangOCo[currDong - dem, currCot - dem].SoHuu == 1)
                    SoQuanTa++;
                else if (_MangOCo[currDong - dem, currCot - dem].SoHuu == 2)
                {
                    SoQuanDich++;

                    break;
                }
                else
                    break;
            }

            if (SoQuanDich == 2)
                return 0;
            DiemTong -= MangDiemPhongNgu[SoQuanDich + 1]*2;
            DiemTong += MangDiemTanCong[SoQuanTa];
            return DiemTong;
        }

        // phòng ngự
        private long DiemPN_DuyetDoc(int currDong, int currCot)
        {
            
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int dem=1; dem < 6 && currDong + dem < _BanCo.SoDong; dem++)
            {
                if (_MangOCo[currDong + dem, currCot].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[currDong + dem, currCot].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else
                    break;
            }
            for (int dem=1; dem < 6 && currDong - dem >= 0; dem++)
            {
                if (_MangOCo[currDong - dem, currCot].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[currDong - dem, currCot].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else
                    break;
            }

            if (SoQuanTa == 2)
                return 0;
            DiemTong += MangDiemPhongNgu[SoQuanDich];
            return DiemTong;
        }
        private long DiemPN_DuyetNgang(int currDong, int currCot)
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int dem=1; dem < 6 && currCot + dem < _BanCo.SoCot; dem++)
            {
                if (_MangOCo[currDong, currCot + dem].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[currDong, currCot + dem].SoHuu == 2)
                {
                    SoQuanDich++;


                }
                else
                    break;
            }
            for (int dem=1; dem < 6 && currCot - dem >= 0; dem++)
            {
                if (_MangOCo[currDong, currCot - dem].SoHuu == 1)
                {
                    SoQuanTa++; break;
                }
                else if (_MangOCo[currDong, currCot - dem].SoHuu == 2)
                {
                    SoQuanDich++;


                }
                else
                    break;
            }

            if (SoQuanTa == 2)
                return 0;
            DiemTong += MangDiemPhongNgu[SoQuanDich ];
            return DiemTong;
        }
        private long DiemPN_DuyetCheoNguoc(int currDong, int currCot)
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int dem=1; dem < 6 && currCot + dem < _BanCo.SoCot && currDong - dem >= 0; dem++)
            {
                if (_MangOCo[currDong - dem, currCot + dem].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[currDong - dem, currCot + dem].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else
                    break;
            }
            for (int dem=1; dem < 6 && currCot - dem >= 0 && currDong + dem < _BanCo.SoDong; dem++)
            {
                if (_MangOCo[currDong + dem, currCot - dem].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[currDong + dem, currCot - dem].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else
                    break;
            }

            if (SoQuanTa == 2)
                return 0;
            DiemTong += MangDiemPhongNgu[SoQuanDich];
            return DiemTong;
        }
        private long DiemPN_DuyetCheoXuoi(int currDong, int currCot)
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int dem=1; dem < 6 && currCot + dem < _BanCo.SoCot && currDong + dem < _BanCo.SoDong; dem++)
            {
                if (_MangOCo[currDong + dem, currCot + dem].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[currDong + dem, currCot + dem].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else
                    break;
            }
            for (int dem=1; dem < 6 && currCot - dem >= 0 && currDong - dem >= 0; dem++)
            {
                if (_MangOCo[currDong - dem, currCot - dem].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[currDong - dem, currCot - dem].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else
                    break;
            }

            if (SoQuanTa == 2)
                return 0;
           
            DiemTong += MangDiemPhongNgu[SoQuanDich];
            return DiemTong;
        }
    }
}
