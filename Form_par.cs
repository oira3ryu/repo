using System;
using System.Data;
using System.Drawing;
using Npgsql;
using System.Windows.Forms;

namespace rk_seikyu
{
    public partial class Form_par : Form
    {
        private NpgsqlConnection m_conn = new NpgsqlConnection(rk_seikyu.Properties.Settings.Default.PostgresConnect);

        private NpgsqlDataAdapter par_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter t_id_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter n_id_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter s_id_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter cmb_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter dup_da = new NpgsqlDataAdapter();

        private DataSet par_ds = new DataSet();
        private DataSet n_id_ds = new DataSet();
        private DataSet t_id_ds = new DataSet();
        private DataSet s_id_ds = new DataSet();
        private DataSet Cntds = new DataSet();
        private DataSet CntWomends = new DataSet();
        private DataSet Cmbds = new DataSet();
        private DataSet dupds = new DataSet();

        public string Ofdstr { get; set; }
        public int Cmb_n_id_int { get; set; }
        public int Cmb_t_id_int { get; set; }
        public int Cmb_s_id_int { get; set; }

        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }

        public int VarHour { get; set; }
        public int VarMinute { get; set; }
        public int VarSecond { get; set; }

        public Form_par()
        {
            InitializeComponent();
        }

        private void Form_par_Load(object sender, EventArgs e)
        {
            dataGridViewPar.Columns[0].HeaderText = "ID";
            dataGridViewPar.Columns[1].HeaderText = "項目１";
            dataGridViewPar.Columns[2].HeaderText = "項目２";
            dataGridViewPar.Columns[3].HeaderText = "項目３";
            dataGridViewPar.Columns[4].HeaderText = "項目４";
            dataGridViewPar.Columns[5].HeaderText = "項目５";

            par_da.SelectCommand = new NpgsqlCommand
            (
                "select"
                + " p_id"
                + ", title"
                + ", sub_title"
                + ", content1"
                + ", content2"
                + ", content3"
                + " from"
                + " t_par"
                + " order by p_id"
                , m_conn
            );

            // insert
            par_da.InsertCommand = new NpgsqlCommand
            (
                    "insert into t_par ("
                + "title"
                + ", sub_title"
                + ", content1"
                + ", content2"
                + ", content3"
                + " ) values ("
                + " :title"
                + ", :sub_title"
                + ", :content1"
                + ", :content2"
                + ", :content3"
                + ")",
                m_conn
            );
            par_da.InsertCommand.Parameters.Add(new NpgsqlParameter("title", NpgsqlTypes.NpgsqlDbType.Text, 0, "title", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            par_da.InsertCommand.Parameters.Add(new NpgsqlParameter("sub_title", NpgsqlTypes.NpgsqlDbType.Text, 0, "sub_title", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            par_da.InsertCommand.Parameters.Add(new NpgsqlParameter("content1", NpgsqlTypes.NpgsqlDbType.Text, 0, "content1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            par_da.InsertCommand.Parameters.Add(new NpgsqlParameter("content2", NpgsqlTypes.NpgsqlDbType.Text, 0, "content2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            par_da.InsertCommand.Parameters.Add(new NpgsqlParameter("content3", NpgsqlTypes.NpgsqlDbType.Text, 0, "content3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));

            // update
            par_da.UpdateCommand = new NpgsqlCommand(
                "update t_par set"
                + " title = :title"
                + ", sub_title = :sub_title"
                + ", content1 = :content1"
                + ", content2 = :content2"
                + ", content3 = :content3"
                + " where"
                + " p_id=:p_id"
                , m_conn
                );
            par_da.UpdateCommand.Parameters.Add(new NpgsqlParameter("title", NpgsqlTypes.NpgsqlDbType.Text, 0, "title", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            par_da.UpdateCommand.Parameters.Add(new NpgsqlParameter("sub_title", NpgsqlTypes.NpgsqlDbType.Text, 0, "sub_title", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            par_da.UpdateCommand.Parameters.Add(new NpgsqlParameter("content1", NpgsqlTypes.NpgsqlDbType.Text, 0, "content1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            par_da.UpdateCommand.Parameters.Add(new NpgsqlParameter("content2", NpgsqlTypes.NpgsqlDbType.Text, 0, "content2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            par_da.UpdateCommand.Parameters.Add(new NpgsqlParameter("content3", NpgsqlTypes.NpgsqlDbType.Text, 0, "content3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            par_da.UpdateCommand.Parameters.Add(new NpgsqlParameter("p_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "p_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

            // delete
            par_da.DeleteCommand = new NpgsqlCommand
            (
                   "delete from t_par"
                + " where"
                + " p_id=:p_id"
                , m_conn
            );
            par_da.DeleteCommand.Parameters.Add(new NpgsqlParameter("p_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "p_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

            // RowUpdate
            par_da.RowUpdated += new NpgsqlRowUpdatedEventHandler(ParRowUpdated);

            n_id_da.SelectCommand = new NpgsqlCommand
            (
                   "select"
                + " n_id"
                + ", nen"
                + " from t_nen"
                + " order by n_id"
                  , m_conn
            );

            t_id_da.SelectCommand = new NpgsqlCommand
            (
                   "select"
                  + " t_id"
                  + ", tsuki"
                  + " from t_tsuki"
                  + " order by t_id"
                    , m_conn
            );

            s_id_da.SelectCommand = new NpgsqlCommand
            (
                   "select"
                  + " s_id"
                  + ", syubetsu"
                  + " from t_syubetsu"
                  + " order by s_id",
                    m_conn
            );

            par_da.Fill(par_ds, "par");
            t_id_da.Fill(t_id_ds, "t_tsuki");
            n_id_da.Fill(n_id_ds, "t_nen");
            s_id_da.Fill(s_id_ds, "t_syubetsu");

            cmb_n_id.DataSource = n_id_ds.Tables[0]; ;
            cmb_n_id.DisplayMember = "nen";
            cmb_n_id.ValueMember = "n_id";

            cmb_t_id.DataSource = t_id_ds.Tables[0]; ;
            cmb_t_id.DisplayMember = "tsuki";
            cmb_t_id.ValueMember = "t_id";

            cmb_s_id.DataSource = s_id_ds.Tables[0]; ;
            cmb_s_id.DisplayMember = "syubetsu";
            cmb_s_id.ValueMember = "s_id";

            bindingSourcePar.DataSource = par_ds;
            bindingSourcePar.DataMember = "par";

            bindingNavigatorPar.BindingSource = bindingSourcePar;
            dataGridViewPar.AutoGenerateColumns = false;
            dataGridViewPar.DataSource = bindingSourcePar;

            dataGridViewPar.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            DataGridViewEvent();

        }

        private void DataGridViewEvent()
        {
            dataGridViewPar.CellMouseMove += new DataGridViewCellMouseEventHandler(DataGridViewPar_CellMouseMove);
            dataGridViewPar.CellPainting += new DataGridViewCellPaintingEventHandler(DataGridViewPar_CellPainting);
        }

        private void cmdParSave_Click(object sender, EventArgs e)
        {
            int update_count = 0;
            try
            {
                update_count += par_da.Update(par_ds.Tables["par"].Select(null, null, DataViewRowState.Deleted));
                update_count += par_da.Update(par_ds.Tables["par"].Select(null, null, DataViewRowState.ModifiedCurrent));
                update_count += par_da.Update(par_ds.Tables["par"].Select(null, null, DataViewRowState.Added));
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存に失敗しました。\n\n[内容]\n" + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(update_count.ToString() + "件、保存しました。", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

         private void ParRowUpdated(Object sender, NpgsqlRowUpdatedEventArgs e)
        {
            if (e.Status == UpdateStatus.Continue)
            {
                if (e.StatementType == System.Data.StatementType.Insert)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand
                (
                "select"
                + " p_id"
                + ", title"
                + ", sub_title"
                + ", content1"
                + ", content2"
                + ", content3"
                + " from"
                + " t_par"
                + " where p_id=currval('t_par_p_id_seq')"
                + " order by p_id"
                , m_conn
                 );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        e.Row["p_id"] = reader["p_id"];
                        e.Row["title"] = reader["title"];
                        e.Row["sub_title"] = reader["sub_title"];
                        e.Row["content1"] = reader["content1"];
                        e.Row["content2"] = reader["content2"];
                        e.Row["content3"] = reader["content3"];
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                        throw;
                    }
                }
                else if (e.StatementType == System.Data.StatementType.Update)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand
                (
                "select"
                + " p_id"
                + ", title"
                + ", sub_title"
                + ", content1"
                + ", content2"
                + ", content3"
                + " from"
                + " t_par"
                + " where p_id=" + e.Row["p_id"].ToString()
                + " order by p_id"
                , m_conn
                    );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        e.Row["p_id"] = reader["p_id"];
                        e.Row["title"] = reader["title"];
                        e.Row["sub_title"] = reader["sub_title"];
                        e.Row["content1"] = reader["content1"];
                        e.Row["content2"] = reader["content2"];
                        e.Row["content3"] = reader["content3"];
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                        throw;
                    }
                }
            }
        }

        private void DataGridViewPar_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e == null) return;

            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;

            if (e.Value == null || e.Value.ToString() == "") return;

            switch (this.dataGridViewPar.Columns[e.ColumnIndex].Name)
            {
                case "results":
                    //string input = e.Value.ToString();
                    string input = (string)dataGridViewPar[2, e.RowIndex].Value.ToString();
                    Console.WriteLine("input = " + input);

                    DateTime value;
                    if (DateTime.TryParseExact(
                        input, "mm:ss.f",
                        null, System.Globalization.DateTimeStyles.None, out value))
                    {
                        e.Value = value;
                        e.ParsingApplied = true;
                    }
                    break;
            }
        }

        private void DataGridViewPar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;

            if (e.Value == null || e.Value == DBNull.Value) return;

            switch (this.dataGridViewPar.Columns[e.ColumnIndex].Name)
            {
                case "results":

                    e.Value = string.Format("{0:HH:mm:ss}", e.Value);
                    e.FormattingApplied = true;
                    break;
            }
        }

        private void DataGridViewPar_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCellStyle dcs = new DataGridViewCellStyle();
            dcs.BackColor = Color.Yellow;

            DataGridView dgv = (DataGridView)sender;

            for (int rowIndex = 0; rowIndex < dgv.Rows.Count; rowIndex++)
            {
                dgv.Rows[rowIndex].DefaultCellStyle = null;
            }

            if (e.RowIndex >= 0)
            {
                dgv.Rows[e.RowIndex].DefaultCellStyle = dcs;
            }
        }

        private void DataGridViewPar_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex < 0 && e.RowIndex >= 0)
            {
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);

                Rectangle indexRect = e.CellBounds;
                indexRect.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics,
                    (e.RowIndex + 1).ToString(),
                    e.CellStyle.Font,
                    indexRect,
                    e.CellStyle.ForeColor,
                    TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
                e.Handled = true;
            }
        }

        private void CmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Cmb_n_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmb_n_id_int = cmb_n_id.SelectedIndex + 1;
            Console.WriteLine("cmb_n_id_int = " + Cmb_n_id_int);
        }

        private void Cmb_t_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmb_t_id_int = cmb_t_id.SelectedIndex + 1;
            Console.WriteLine("cmb_t_id_int = " + Cmb_t_id_int);
        }

        private void Cmb_s_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmb_s_id_int = cmb_s_id.SelectedIndex + 1;
            Console.WriteLine("cmb_s_id_int = " + Cmb_s_id_int);
        }

        private void cmdPrn_Click(object sender, EventArgs e)
        {
            Form_prn Form = new Form_prn();
            Form.ShowDialog();
        }

        private void Form_par_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (par_ds.HasChanges())
            {
                DialogResult ret = MessageBox.Show("保存していないデータがあります。終了してよろしいですか？", "終了", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (ret)
                {
                    case DialogResult.Yes:
                        par_da.Dispose();
                        break;
                    case DialogResult.No:
                        e.Cancel = true;
                        break;
                }
            }
        }
    }
}