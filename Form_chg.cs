using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rk_seikyu
{
    public partial class Form_chg : Form
    {
        public Form_chg()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            // ラジオボタン１がチェックされているか？
            if (rb_par.Checked)
            {
                Form_par Form = new Form_par();
                Form.ShowDialog();
            }
            // ラジオボタン２がチェックされているか？
            if (rb_rep.Checked)
            {
                Form_rep Form = new Form_rep();
                Form.ShowDialog();
            }
            if (rb_req.Checked)
            {
                Form_req Form = new Form_req();
                Form.ShowDialog();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
