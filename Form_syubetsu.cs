using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace rk_seikyu
{
    public partial class Form_syubetsu : Form
    {
        private NpgsqlConnection m_conn = new NpgsqlConnection(rk_seikyu.Properties.Settings.Default.PostgresConnect);

        private NpgsqlDataAdapter da = new NpgsqlDataAdapter();
        private DataSet ds = new DataSet();
        private DataSet syubetsu_ds = new DataSet();

        private Form_seikyu form_seikyu_Instance;

        public String cmb_o_id_str;
        public int cmb_o_id_int { get; set; }
        public string Form_Seikyu_TextBoxO_id;

        public Form_syubetsu()
        {
            InitializeComponent();

            //Form_seikyuのインスタンスを取得
            form_seikyu_Instance = Form_seikyu.Form_seikyu_Instance;
            //Form_seikyuのテキストボックス文字列を
            //Form_syubetsuの文字列変数cmb_o_id_strへ設定
            //cmb_o_id_str = form_seikyu_Instance.TextBoxO_id;
            Form_Seikyu_TextBoxO_id = form_seikyu_Instance.TextBoxO_id;
        }

        private void Form_syubetsu_Load(object sender, EventArgs e)
        {

            Console.WriteLine("Form_syubetsu_cmb_o_id_str = " + Form_Seikyu_TextBoxO_id);

            dataGridViewSyubetsu.Columns[0].HeaderText = "ID";
            dataGridViewSyubetsu.Columns[1].HeaderText = "種別";
            dataGridViewSyubetsu.Columns[2].HeaderText = "施設名";

            da.SelectCommand = new NpgsqlCommand
            (
                   "SELECT"
                + " ps_id"
                + ", s_id"
                + ", syubetsu"
                + ", shisetsumei"
                + " FROM"
                + " t_syubetsu"
                + " WHERE o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                + " ORDER BY s_id;",
                m_conn
            );

            // insert
            da.InsertCommand = new NpgsqlCommand
            (
                    "INSERT INTO t_syubetsu ("
                + " syubetsu"
                + ", shisetsumei"
                + ", s_id"
                + ", o_id"
                + " ) VALUES ("
                + " :syubetsu"
                + ", :shisetsumei"
                + ", :s_id"
                + ", :o_id"
                + ");",
                m_conn
            );
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("syubetsu", NpgsqlTypes.NpgsqlDbType.Text, 0, "syubetsu", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("shisetsumei", NpgsqlTypes.NpgsqlDbType.Text, 0, "shisetsumei", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));

            // update
            da.UpdateCommand = new NpgsqlCommand(
                "UPDATE t_syubetsu SET"
                + " ps_id = :ps_id"
                + ", syubetsu = :syubetsu"
                + ", shisetsumei = :shisetsumei"
                + ", s_id = :s_id"
                + ", o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                + " WHERE"
                + " ps_id = :ps_id"
                , m_conn
                );
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("ps_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "ps_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("syubetsu", NpgsqlTypes.NpgsqlDbType.Text, 0, "syubetsu", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("shisetsumei", NpgsqlTypes.NpgsqlDbType.Text, 0, "shisetsumei", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            //da.UpdateCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

            // delete
            da.DeleteCommand = new NpgsqlCommand
            (
                   "DELETE FROM t_syubetsu"
                + " WHERE"
                + " ps_id = :ps_id"
                , m_conn
            );
            da.DeleteCommand.Parameters.Add(new NpgsqlParameter("ps_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "ps_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

            // RowUpdate
            da.RowUpdated += new NpgsqlRowUpdatedEventHandler(SyubetsuRowUpdated);

            da.Fill(ds, "syubetsu");

            bindingSourceSyubetsu.DataSource = ds;
            bindingSourceSyubetsu.DataMember = "syubetsu";

            bindingNavigatorSyubetsu.BindingSource = bindingSourceSyubetsu;

            //dataGridViewHoliday.AutoGenerateColumns = false;

            dataGridViewSyubetsu.DataSource = bindingSourceSyubetsu;

            dataGridViewSyubetsu.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            bindingNavigatorSyubetsu.Visible = true;

            DataGridViewEvent();
        }

        private void DataGridViewEvent()
        {
            dataGridViewSyubetsu.CellMouseMove += new DataGridViewCellMouseEventHandler(DataGridViewSyubetsu_CellMouseMove);
            dataGridViewSyubetsu.CellPainting += new DataGridViewCellPaintingEventHandler(DataGridViewSyubetsu_CellPainting);
        }

        private void CmdSyubetsuSave_Click(object sender, EventArgs e)
        {
            int update_count = 0;
            try
            {
                update_count += da.Update(ds.Tables["syubetsu"].Select(null, null, DataViewRowState.Deleted));
                update_count += da.Update(ds.Tables["syubetsu"].Select(null, null, DataViewRowState.ModifiedCurrent));
                update_count += da.Update(ds.Tables["syubetsu"].Select(null, null, DataViewRowState.Added));
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存に失敗しました。\n\n[内容]\n" + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(update_count.ToString() + "件、保存しました。", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SyubetsuRowUpdated(Object sender, NpgsqlRowUpdatedEventArgs e)
        {
            if (e.Status == UpdateStatus.Continue)
            {
                if (e.StatementType == System.Data.StatementType.Insert)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand
                (
                "SELECT"
                + " ps_id"
                + ", s_id"
                + ", syubetsu"
                + ", shisetsumei"
                + " FROM"
                + " t_syubetsu"
                + " WHERE ps_id = currval('prn_syubetsu_ps_id_seq')"
                + " ORDER BY s_id;"
                , m_conn
                 );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        e.Row["ps_id"] = reader["ps_id"];
                        e.Row["s_id"] = reader["s_id"];
                        e.Row["syubetsu"] = reader["syubetsu"];
                        e.Row["shisetsumei"] = reader["shisetsumei"];
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
                 "SELECT"
                + " ps_id"
                + ", s_id"
                + ", syubetsu"
                + ", shisetsumei"
                + " FROM"
                + " t_syubetsu"
                + " WHERE ps_id = " + e.Row["ps_id"].ToString()
                + " ORDER BY s_id"
                , m_conn
                    );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        e.Row["ps_id"] = reader["ps_id"];
                        e.Row["s_id"] = reader["s_id"];
                        e.Row["syubetsu"] = reader["syubetsu"];
                        e.Row["shisetsumei"] = reader["shisetsumei"];
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

        private void CmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Form_syubetsu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ds.HasChanges())
            {
                DialogResult ret = MessageBox.Show("保存していないデータがあります。終了してよろしいですか？", "終了", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (ret)
                {
                    case DialogResult.Yes:
                        da.Dispose();
                        break;
                    case DialogResult.No:
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void DataGridViewSyubetsu_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
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

        private void DataGridViewSyubetsu_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }
}
