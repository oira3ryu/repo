using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace rk_seikyu
{
    public partial class Form_gengou : Form
    {
        private NpgsqlConnection m_conn = new NpgsqlConnection(rk_seikyu.Properties.Settings.Default.PostgresConnect);

        private NpgsqlDataAdapter da = new NpgsqlDataAdapter();
        private DataSet ds = new DataSet();

        public Form_gengou()
        {
            InitializeComponent();
        }

        private void Form_Gengou_Load(object sender, EventArgs e)
        {
            dataGridViewGengou.Columns[0].HeaderText = "ID";
            dataGridViewGengou.Columns[1].HeaderText = "元号";
            dataGridViewGengou.Columns[2].HeaderText = "略号";
            dataGridViewGengou.Columns[3].HeaderText = "開始日";
            dataGridViewGengou.Columns[4].HeaderText = "終了日";
            dataGridViewGengou.Columns[5].HeaderText = "西暦との年差";

            //    // TODO: このコード行はデータを 'rk_seikyuDataSet.t_gengou' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
                //this.t_gengouTableAdapter.Fill(this.rk_seikyuDataSet.t_gengou);

            da.SelectCommand = new NpgsqlCommand
            (
                   "select"
                + " gg_id"
                + ", gengou"
                + ", g_name"
                + ", start_date"
                + ", end_date"
                + ", diff"
                + " from"
                + " t_gengou"
                + " order by start_date;",
                m_conn
                );

            // insert
            da.InsertCommand = new NpgsqlCommand
            (
                    "insert into t_gengou ("
                + " gengou"
                + ", g_name"
                + ", start_date"
                + ", end_date"
                + ", diff"
                + " ) values ("
                + ", :gengou"
                + ", :g_name"
                + ", :start_date"
                + ", :end_date"
                + ", :diff"
                + ");",
                m_conn
            );
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("gengou", NpgsqlTypes.NpgsqlDbType.Text, 0, "gengou", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("g_name", NpgsqlTypes.NpgsqlDbType.Text, 0, "g_name", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("start_date", NpgsqlTypes.NpgsqlDbType.TimestampTz, 0, "start_date", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("end_date", NpgsqlTypes.NpgsqlDbType.TimestampTz, 0, "end_date", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("diff", NpgsqlTypes.NpgsqlDbType.Integer, 0, "diff", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            m_conn.Close();


            // update
            da.UpdateCommand = new NpgsqlCommand(
                "update t_gengou set"
                + " gengou = :gengou"
                + ", g_name = :g_name"
                + ", start_date = :start_date"
                + ", end_date = :end_date"
                + ", diff = :diff"
                + " where"
                + " gg_id = :gg_id"
                , m_conn
                );
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("gengou", NpgsqlTypes.NpgsqlDbType.Text, 0, "gengou", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("g_name", NpgsqlTypes.NpgsqlDbType.Text, 0, "g_name", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("start_date", NpgsqlTypes.NpgsqlDbType.TimestampTz, 0, "start_date", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("end_date", NpgsqlTypes.NpgsqlDbType.TimestampTz, 0, "end_date", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("diff", NpgsqlTypes.NpgsqlDbType.Integer, 0, "diff", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("gg_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "gg_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));
            // delete
            da.DeleteCommand = new NpgsqlCommand
            (
                   "delete from t_gengou"
                + " where"
                + " gg_id=:gg_id"
                , m_conn
            );
            da.DeleteCommand.Parameters.Add(new NpgsqlParameter("gg_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "gg_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

            // RowUpdate
            da.RowUpdated += new NpgsqlRowUpdatedEventHandler(GengouRowUpdated);

            da.Fill(ds, "gengou_ds");

            bindingSourceGengou.DataSource = ds;
            bindingSourceGengou.DataMember = "gengou_ds";
            bindingNavigatorGengou.BindingSource = bindingSourceGengou;
            dataGridViewGengou.DataSource = bindingSourceGengou;
            dataGridViewGengou.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            bindingNavigatorGengou.Visible = true;

            // カラムを関連付け
            gg_id.DataPropertyName = "gg_id";
            gengou.DataPropertyName = "gengou";
            start_date.DataPropertyName = "start_date";
            end_date.DataPropertyName = "end_date";
            diff.DataPropertyName = "diff";

            DataGridViewEvent();
        }

        private void DataGridViewEvent()
        {
            dataGridViewGengou.CellMouseMove += new DataGridViewCellMouseEventHandler(DataGridViewGengou_CellMouseMove);
            dataGridViewGengou.CellPainting += new DataGridViewCellPaintingEventHandler(DataGridViewGengou_CellPainting);
        }

        private void CmdGengouSave_Click(object sender, EventArgs e)
        {
            int update_count = 0;
            try
            {
                update_count += da.Update(ds.Tables["gengou_ds"].Select(null, null, DataViewRowState.Deleted));
                update_count += da.Update(ds.Tables["gengou_ds"].Select(null, null, DataViewRowState.ModifiedCurrent));
                update_count += da.Update(ds.Tables["gengou_ds"].Select(null, null, DataViewRowState.Added));
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存に失敗しました。\n\n[内容]\n" + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(update_count.ToString() + "件、保存しました。", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GengouRowUpdated(Object sender, NpgsqlRowUpdatedEventArgs e)
        {
            if (e.Status == UpdateStatus.Continue)
            {
                if (e.StatementType == System.Data.StatementType.Insert)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand
                (
                "select"
                + " gg_id"
                + ", g_name"
                + ", start_date"
                + ", end_date"
                + ", diff"
                + " from"
                + " t_gengou"
                + " where gg_id=currval('t_gengou_gg_id_seq')"
                + " order by start_date;"
                , m_conn
                 );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        e.Row["gg_id"] = reader["gg_id"];
                        e.Row["g_name"] = reader["g_name"];
                        e.Row["start_date"] = reader["start_date"];
                        e.Row["end_date"] = reader["end_date"];
                        e.Row["diff"] = reader["diff"];
                        reader.Close();
                        cmd.Dispose();
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
                + " gg_id"
                + ", g_name"
                + ", start_date"
                + ", end_date"
                + ", diff"
                + " from"
                + " t_gengou"
                + " where gg_id=" + e.Row["gg_id"].ToString()
                + " order by start_date;"
                , m_conn
                    );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        e.Row["gg_id"] = reader["gg_id"];
                        e.Row["g_name"] = reader["g_name"];
                        e.Row["start_date"] = reader["start_date"];
                        e.Row["end_date"] = reader["end_date"];
                        e.Row["diff"] = reader["diff"];
                        reader.Close();
                        cmd.Dispose();
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

        private void Form_Gengou_FormClosing(object sender, FormClosingEventArgs e)
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

        private void DataGridViewGengou_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
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

        private void DataGridViewGengou_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

    }
}
