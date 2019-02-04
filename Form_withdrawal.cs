using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Npgsql;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;

namespace rk_seikyu
{
    public partial class Form_withdrawal : Form
    {
        private NpgsqlConnection m_conn = new NpgsqlConnection(rk_seikyu.Properties.Settings.Default.PostgresConnect);
        private NpgsqlDataAdapter da = new NpgsqlDataAdapter();
        private DataSet ds = new DataSet();

        
        public Form_withdrawal()
        {
            InitializeComponent();
        }
    }
}
