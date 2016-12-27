using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaRoC
{
    public partial class frmThatBai_Vdesign : Form
    {
        public frmThatBai_Vdesign()
        {
            InitializeComponent();
        }

        private void Thatbbai_Load(object sender, EventArgs e)
        {

        }
        //click vào hình thất bại thoát khỏi form và tiếp tục chơi game mới
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
