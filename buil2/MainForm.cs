using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace buil2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "부일전자디자인 회원관리 시스템";

            Bitmap bmp = (Bitmap)Properties.Resources._2;
            this.Icon = Icon.FromHandle(bmp.GetHicon());
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            SelectForm subFrom = new SelectForm();
            subFrom.ShowDialog(); //다른창이떠잇을때기존창사용못함
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            insertform subFrom = new insertform();
            subFrom.ShowDialog();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (tb_updel_id.Text == "")
            {
                MessageBox.Show("수정할 아이디를 먼저 입력하세요.");
                return;
            }

            UpdateForm subFrom = new UpdateForm(tb_updel_id.Text);
            subFrom.ShowDialog();
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (tb_updel_id.Text == "")
            {
                MessageBox.Show("삭제할 아이디를 먼저 입려하세요.");
                return;
            }

            DeleteForm subFrom = new DeleteForm(tb_updel_id.Text);
            subFrom.ShowDialog();
        }
    }
}
