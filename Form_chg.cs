using System;
using System.Windows.Forms;

namespace rk_seikyu
{
    public partial class Form_chg : Form
    {
        public Form_chg()
        {
            InitializeComponent();
        }

        private void CmdOK_Click(object sender, EventArgs e)
        {
            // Form_par
            if (rb_par.Checked)
            {
                Form_par Form = new Form_par();
                Form.ShowDialog();
            }
            // Form_rep
            if (rb_rep.Checked)
            {
                Form_rep Form = new Form_rep();
                Form.ShowDialog();
            }
            // Form_req
            if (rb_req.Checked)
            {
                Form_req Form = new Form_req();
                Form.ShowDialog();
            }
            // Form_gengou
            if (rb_gengou.Checked)
            {
                Form_gengou Form = new Form_gengou();
                Form.ShowDialog();
            }
            // Form_chief
            if (rb_chief.Checked)
            {
                Form_chief Form = new Form_chief();
                Form.ShowDialog();
            }
            // Form_accounting_manager
            if (rb_accounting_manager.Checked)
            {
                Form_accounting_manager Form = new Form_accounting_manager();
                Form.ShowDialog();
            }
            // Form_manager
            if (rb_manager.Checked)
            {
                Form_manager Form = new Form_manager();
                Form.ShowDialog();
            }
            // Form_stuff
            if (rb_stuff.Checked)
            {
                Form_stuff Form = new Form_stuff();
                Form.ShowDialog();
            }

        }

        private void CmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
