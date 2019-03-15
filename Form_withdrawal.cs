using System.Data;
using System.Windows.Forms;
using Npgsql;

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
