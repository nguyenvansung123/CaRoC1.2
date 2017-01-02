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
        //trạng thái hòa cờ
        HoaCo,
        //trạng thái người chơi thắng
        NguoiChoi,
        //trạng thái máy thằng 
        MayAI,
        NguoiChoi_1,
        NguoiChoi_2,
    }
    //Them code duyet doc

    class CaroChess
    {
        //gọi hàm vẻ ra
        public static Pen pen;
        // gán hình cho ô cờ 0
        public static Image CoO;
        //gán hình cho ô cờ X
        public static Image CoX;
        //load list danh sách các nước đi
        public List<OCo> DS_CacNuocDaDi;
        //hàm gán lượt đi cho
        public int _LuotDi;
        //hàm sẵn sàng
        public bool _SanSang;
        //Khai báo mảng ô cờ, mảng 2 chiều 
        public OCo[,] _MangOCo;
        //Hàm bàn cờ
        public BanCo _BanCo;
        //Hàm kết thúc
        public KETTHUC _ketthuc;
        public int _CheDoChoi;

        public bool SanSang
        {
            get
            {
                return _SanSang;
            }

        }
        public int CheDoChoi
        {
            get { return _CheDoChoi; }
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
        //Khởi tạo mảng ô cờ
        public void KhoiTaoMangOCo()
        {
            //Tạo vòng lặp chạy đối tượng 
            for (int i = 0; i < _BanCo.SoDong; i++)
            {
                for (int j = 0; j < _BanCo.SoCot; j++)
                {
                    _MangOCo[i, j] = new OCo(i, j, new Point(j * OCo.ChieuRong, i * OCo.ChieuCao), 0);
                }
            }
        }



        //hàm đánh cờ bị lỗi 
        // đánh vài lượt thì người chơi từ quân O sang quân X
        
        public bool DanhCo(int MouseX, int MouseY, Graphics g)
        {
            if (MouseX % OCo.ChieuRong == 0 || MouseY % OCo.ChieuCao == 0)
            {
                return false;
            }
            int cot = MouseX / OCo.ChieuRong;
            int dong = MouseY / OCo.ChieuCao;
            if (_MangOCo[dong, cot].SoHuu != 0)
            {
                return false;
            }
            switch (_LuotDi)
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
            foreach (OCo oco in DS_CacNuocDaDi)
            {
                if (oco.SoHuu == 1)
                {
                    _BanCo.VeQuanCo(g, oco.ViTri, CoX);
                }
                else
                {
                    if (oco.SoHuu == 2)
                    {
                        _BanCo.VeQuanCo(g, oco.ViTri, CoO);
                    }
                }
            }
        }
        // hàm test thử
        public void VeLaiQuanCotest(Graphics g)
        {
            foreach (OCo oco in DS_CacNuocDaDi)
            {
                if (oco.SoHuu == 1)
                {
                    _BanCo.VeQuanCo(g, oco.ViTri, CoX);
                }
                else
                {
                    if (oco.SoHuu == 2)
                    {
                        _BanCo.VeQuanCo(g, oco.ViTri, CoO);
                    }
                }
            }
        }

        //hàm xử lý bắt đầu cũng như tạo mới bàn cờ


        public void BatDau(Graphics g)
        {
            _SanSang = true;
            DS_CacNuocDaDi = new List<OCo>();
            KhoiTaoMangOCo();
            _LuotDi = 1;
            _CheDoChoi = 1;
            VeBanCo(g);
            KhoiDongComputer(g);
        }
        //hàm xử lý thằng thua và hòa
        public void KetThucTroChoi()
        {
            switch (_ketthuc)
            {
                case KETTHUC.HoaCo:
                    MessageBox.Show("Hòa cờ rồi!");
                    break;
                case KETTHUC.NguoiChoi:
                    // MessageBox.Show("Máy thắng rồi!");
                    // hiện form người chơi thắng
                    Form tb = new frmThatBai_Vdesign();
                    tb.ShowDialog();
                    break;
                case KETTHUC.MayAI:
                    //MessageBox.Show("Bạn đã thắng");
                    //hiện form máy thắng
                    Form ct = new frmChienThang_Vdesign();
                    ct.ShowDialog();
                    break;
                case KETTHUC.NguoiChoi_1:
                    Form ct1 = new NguoiChoiChienThang1();
                    ct1.ShowDialog();
                    break;
                case KETTHUC.NguoiChoi_2:
                    Form ct2 = new NguoiChoiChienThang2();
                    ct2.ShowDialog();
                    break;
            }
            _SanSang = false;
        }

        //hàm kiểm tra xem bên nào có 5 quân cờ đi được liên tục trước
        public bool KiemTraChienThang()
        {

            if (DS_CacNuocDaDi.Count == _BanCo.SoCot * _BanCo.SoDong)
            {
                _ketthuc = KETTHUC.HoaCo;
                return true;
            }

            foreach (OCo oco in DS_CacNuocDaDi)
            {
                //Nếu duyệt dọc, duyệt ngang chạy đúng 
                if (DuyetDoc(oco.Dong, oco.Cot, oco.SoHuu) || DuyetNgang(oco.Dong, oco.Cot, oco.SoHuu) || DuyetCheoXuoi(oco.Dong, oco.Cot, oco.SoHuu) || DuyetCheoNguoc(oco.Dong, oco.Cot, oco.SoHuu))
                {
                    //Kéo biến kết thúc, xét xem sở hữu là bao nhiêu, nếu đúng Người Chơi, nếu sai MayAI
                    if (CheDoChoi == 1)
                    {
                        _ketthuc = oco.SoHuu == 1 ? KETTHUC.NguoiChoi : KETTHUC.MayAI;
                        return true;
                    }
                    else
                    {
                        _ketthuc = oco.SoHuu == 1 ? KETTHUC.NguoiChoi_1 : KETTHUC.NguoiChoi_2;
                        return true;
                    }
                }
            }
            return false;

        }
        //Duyệt dọc (dòng hiện tại, cột, và sở hữu)
        private bool DuyetDoc(int currDong, int currCot, int currSoHuu)
        {
            //Nếu số dòng hiện tại > 15(kiểu chủ động)
            if (currDong > _BanCo.SoDong - 5)
            {
                return false;
            }
            //Biến đếm
            int dem;
            //Vòng lặp For chạy 4 lần, cùng với quân cờ đang xét
            for (dem = 1; dem < 5; dem++)
            {
                //Nếu mảng ô cờ dòng hiện tại + biến đếm, cột không đổi, sở hữu khác hay bằng sở hữu
                if (_MangOCo[currDong + dem, currCot].SoHuu != currSoHuu)
                {
                    return false;
                }
            }
            //Nếu dòng hiện tại = 0 hoặc dòng hiện tại + biến đếm = bàn cờ(dòng hiện tại)
            if (currDong == 0 || currDong + dem == _BanCo.SoDong)
            {
                return true;
            }
            //Nếu mảng ô cờ dòng hiện tại trừ 1, cột không đổi, sở hữu == 0 , trống hoặc k có quân trắng chặn => Chiến thắng
            //hoặc mảng ô cở dòng hiện tại + đếm , cột không đổi, sở hữu == 0, k bị chặn độ trên độ dưới thì sẽ return true, ngược lại thì false 
            if (_MangOCo[currDong - 1, currCot].SoHuu == 0 || _MangOCo[currDong + dem, currCot].SoHuu == 0)
            {
                return true;
            }
            return false;

        }
        private bool DuyetNgang(int currDong, int currCot, int currSoHuu)
        {
            if (currCot > _BanCo.SoCot - 5)
            {
                return false;
            }
            int dem;
            for (dem = 1; dem < 5; dem++)
            {
                if (_MangOCo[currDong, currCot + dem].SoHuu != currSoHuu)
                    return false;
            }
            if (currCot == 0 || currCot + dem == _BanCo.SoCot)
            {
                return true;
            }
            if (_MangOCo[currDong, currCot - 1].SoHuu == 0 || _MangOCo[currDong, currCot + dem].SoHuu == 0)
            {
                return true;
            }
            return false;
        }
        private bool DuyetCheoXuoi(int currDong, int currCot, int currSoHuu)
        {
            if (currDong > _BanCo.SoDong - 5 || currCot > _BanCo.SoCot - 5)
            {
                return false;
            }
            int dem;
            for (dem = 1; dem < 5; dem++)
            {
                if (_MangOCo[currDong + dem, currCot + dem].SoHuu != currSoHuu)
                    return false;
            }
            if (currDong == 0 || currDong + dem == _BanCo.SoDong || currCot == 0 || currCot + dem == _BanCo.SoCot)
            {
                return true;
            }
            if (_MangOCo[currDong - 1, currCot - 1].SoHuu == 0 || _MangOCo[currDong + dem, currCot + dem].SoHuu == 0)
            {
                return true;
            }
            return false;
        }
        private bool DuyetCheoNguoc(int currDong, int currCot, int currSoHuu)
        {
            if (currDong < 4 || currCot > _BanCo.SoCot - 5)
            {
                return false;
            }
            int dem;
            for (dem = 1; dem < 5; dem++)
            {
                if (_MangOCo[currDong - dem, currCot + dem].SoHuu != currSoHuu)
                    return false;
            }
            if (currDong == 4 || currDong == _BanCo.SoDong - 1 || currCot == 0 || currCot + dem == _BanCo.SoCot)
            {
                return true;
            }
            if (_MangOCo[currDong + 1, currCot - 1].SoHuu == 0 || _MangOCo[currDong - dem, currCot + dem].SoHuu == 0)
            {
                return true;
            }
            return false;
        }


        //tri thong minh nhan tao
        //đây là bản điểm sét bàn cờ tấn công phòng thủ
        // các hàm mang tính quyết định khi đánh cờ
        // điểm nào càng cao thì bàn cờ tự động đánh theo nước đó


        //private long[] MangDiemTanCong = new long[7] {0, 3, 24, 192, 1536, 12288, 98304 }; //đặt giá trị cho từng tầng của cây
        //private long[] MangDiemPhongNgu = new long[7] {0, 1, 9, 81, 729, 6561, 59849 };
        private long[] MangDiemTanCong = new long[7] { 0, 9, 54, 162, 1458, 13112, 118008 }; //đặt giá trị cho từng tầng của cây
        private long[] MangDiemPhongNgu = new long[7] { 0, 3, 27, 99, 729, 6561, 59049 };

        public void KhoiDongComputer(Graphics graphics)
        {
            //hàm gọi computer chạy
            if (DS_CacNuocDaDi.Count == 0)//kiểm tra các nước đi
            {
                //gọi hàm đánh cờ vô để khở tạo các nước đi
                DanhCo(_BanCo.SoCot / 2 * OCo.ChieuRong + 1, _BanCo.SoDong / 2 * OCo.ChieuCao + 1, graphics);
            }

            else
            {
                //nếu không phải đánh đầu tiên thì phải tìm kiếm nước đi hợp lý
                OCo oco = TimKiemNuocDi();
                //gọi hàm đánh cờ vô theo nước đi hợp lý nhất
                DanhCo(oco.ViTri.X + 1, oco.ViTri.Y + 1, graphics);
            }

        }
        private OCo TimKiemNuocDi()
        {
            OCo ocoResult = new OCo();
            long DiemMax = 0;
            //thuật toán vét cạn
            //thuật toán này sét duyệt các phần tử
            for (int i = 0; i < _BanCo.SoDong; i++)
            {
                for (int j = 0; j < _BanCo.SoCot; j++)
                {
                    if (_MangOCo[i, j].SoHuu == 0)
                    {
                        long DiemTanCong = DiemTC_DuyetDoc(i, j) + DiemTC_DuyetNgang(i, j) + DiemTC_DuyetCheoNguoc(i, j) + DiemTC_DuyetCheoXuoi(i, j);
                        long DiemPhongNgu = DiemPN_DuyetDoc(i, j) + DiemPN_DuyetNgang(i, j) + DiemPN_DuyetCheoNguoc(i, j) + DiemPN_DuyetCheoXuoi(i, j);
                        long DiemTam = DiemTanCong > DiemPhongNgu ? DiemTanCong : DiemPhongNgu;
                        if (DiemMax < DiemTam)
                        {
                            DiemMax = DiemTam;
                            ocoResult = new OCo(_MangOCo[i, j].Dong, _MangOCo[i, j].Cot, _MangOCo[i, j].ViTri, _MangOCo[i, j].SoHuu);
                        }
                    }
                }
            }
            return ocoResult;
        }

        //Tấn Công
        private long DiemTC_DuyetDoc(int currDong, int currCot)
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int dem = 1; dem < 6 && currDong + dem < _BanCo.SoDong; dem++)
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
            for (int dem = 1; dem < 6 && currDong - dem >= 0; dem++)
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
            DiemTong -= MangDiemPhongNgu[SoQuanDich + 1];
            DiemTong += MangDiemTanCong[SoQuanTa];
            return DiemTong;

        }
        private long DiemTC_DuyetNgang(int currDong, int currCot)
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int dem = 1; dem < 6 && currCot + dem < _BanCo.SoCot; dem++)
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
            for (int dem = 1; dem < 6 && currCot - dem >= 0; dem++)
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
            DiemTong -= MangDiemPhongNgu[SoQuanDich + 1];
            DiemTong += MangDiemTanCong[SoQuanTa];
            return DiemTong;
        }
        private long DiemTC_DuyetCheoNguoc(int currDong, int currCot)
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int dem = 1; dem < 6 && currCot + dem < _BanCo.SoCot && currDong - dem >= 0; dem++)
            {
                if (_MangOCo[currDong - dem, currCot + dem].SoHuu == 1)
                    SoQuanTa++;
                else if (_MangOCo[currDong - dem, currCot + dem].SoHuu == 2)
                {
                    SoQuanDich++;

                    break;
                }
                else
                    break;
            }
            for (int dem = 1; dem < 6 && currCot - dem >= 0 && currDong + dem < _BanCo.SoDong; dem++)
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
            DiemTong -= MangDiemPhongNgu[SoQuanDich + 1];
            DiemTong += MangDiemTanCong[SoQuanTa];
            return DiemTong;
        }
        private long DiemTC_DuyetCheoXuoi(int currDong, int currCot)
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int dem = 1; dem < 6 && currCot + dem < _BanCo.SoCot && currDong + dem < _BanCo.SoDong; dem++)
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
            for (int dem = 1; dem < 6 && currCot - dem >= 0 && currDong - dem >= 0; dem++)
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
            DiemTong -= MangDiemPhongNgu[SoQuanDich] * 2;
            DiemTong += MangDiemTanCong[SoQuanTa];
            return DiemTong;
        }

        // phòng ngự
        private long DiemPN_DuyetDoc(int currDong, int currCot)
        {

            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int dem = 1; dem < 6 && currDong + dem < _BanCo.SoDong; dem++)
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
            for (int dem = 1; dem < 6 && currDong - dem >= 0; dem++)
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
            for (int dem = 1; dem < 6 && currCot + dem < _BanCo.SoCot; dem++)
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
            for (int dem = 1; dem < 6 && currCot - dem >= 0; dem++)
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
            DiemTong += MangDiemPhongNgu[SoQuanDich];
            return DiemTong;
        }
        private long DiemPN_DuyetCheoNguoc(int currDong, int currCot)
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int dem = 1; dem < 6 && currCot + dem < _BanCo.SoCot && currDong - dem >= 0; dem++)
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
            for (int dem = 1; dem < 6 && currCot - dem >= 0 && currDong + dem < _BanCo.SoDong; dem++)
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
            for (int dem = 1; dem < 6 && currCot + dem < _BanCo.SoCot && currDong + dem < _BanCo.SoDong; dem++)
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
            for (int dem = 1; dem < 6 && currCot - dem >= 0 && currDong - dem >= 0; dem++)
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
        //xây dựng hàm 2 người chơi
        public void Nguoi_va_Nguoi(Graphics g)
        {
            _SanSang = true;
            DS_CacNuocDaDi = new List<OCo>();
            _LuotDi = 1;
            _CheDoChoi = 2;
            KhoiTaoMangOCo();
            VeBanCo(g);
        }
    }
}
