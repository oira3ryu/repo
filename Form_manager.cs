using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace rk_seikyu
{
    public partial class Form_manager : Form
    {
        private NpgsqlConnection m_conn = new NpgsqlConnection(rk_seikyu.Properties.Settings.Default.PostgresConnect);

        private NpgsqlDataAdapter da = new NpgsqlDataAdapter();
        private DataSet ds = new DataSet();

        public Form_manager()
        {
            InitializeComponent();
        }

        private void CmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Form_manager_Load(object sender, EventArgs e)
        {
            dataGridViewManager.Columns[0].HeaderText = "ID";
            dataGridViewManager.Columns[1].HeaderText = "管理者";
            dataGridViewManager.Columns[2].HeaderText = "開始日";
            dataGridViewManager.Columns[3].HeaderText = "終了日";
            dataGridViewManager.Columns[4].HeaderText = "事業所ID";

            da.SelectCommand = new NpgsqlCommand
            (
                   "SELECT"
                + " m_id"
                + ", manager"
                + ", start_date"
                + ", end_date"
                + ", o_id"
                + " FROM"
                + " t_manager"
                + " ORDER BY start_date;",
                m_conn
                );

            // insert
            da.InsertCommand = new NpgsqlCommand
            (
                    "INSERT INTO t_manager ("
                + " manager"
                + ", start_date"
                + ", end_date"
                + ", o_id"
                + " ) VALUES ("
                + ", :manager"
                + ", :start_date"
                + ", :end_date"
                + ", :o_id"
                + ");",
                m_conn
            );
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("manager", NpgsqlTypes.NpgsqlDbType.Text, 0, "manager", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("start_date", NpgsqlTypes.NpgsqlDbType.TimestampTz, 0, "start_date", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("end_date", NpgsqlTypes.NpgsqlDbType.TimestampTz, 0, "end_date", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            m_conn.Close();


            // update
            da.UpdateCommand = new NpgsqlCommand(
                "UPDATE t_manager SET"
                + " manager = :manager"
                + ", start_date = :start_date"
                + ", end_date = :end_date"
                + ", o_id = :o_id"
                + " WHERE"
                + " m_id = :m_id"
                , m_conn
                );
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("manager", NpgsqlTypes.NpgsqlDbType.Text, 0, "manager", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("start_date", NpgsqlTypes.NpgsqlDbType.TimestampTz, 0, "start_date", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("end_date", NpgsqlTypes.NpgsqlDbType.TimestampTz, 0, "end_date", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("m_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "m_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));
            // delete
            da.DeleteCommand = new NpgsqlCommand
            (
                   "DELETE FROM t_manager"
                + " WHERE"
                + " m_id=:m_id"
                , m_conn
            );
            da.DeleteCommand.Parameters.Add(new NpgsqlParameter("m_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "m_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

            // RowUpdate
            da.RowUpdated += new NpgsqlRowUpdatedEventHandler(ManagerRowUpdated);

            da.Fill(ds, "manager_ds");

            bindingSourceManager.DataSource = ds;
            bindingSourceManager.DataMember = "manager_ds";
            bindingNavigatorManager.BindingSource = bindingSourceManager;
            dataGridViewManager.DataSource = bindingSourceManager;
            dataGridViewManager.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            bindingNavigatorManager.Visible = true;

            // カラムを関連付け
            m_id.DataPropertyName = "m_id";
            manager.DataPropertyName = "manager";
            start_date.DataPropertyName = "start_date";
            end_date.DataPropertyName = "end_date";

            DataGridViewEvent();
        }

        private void DataGridViewEvent()
        {
            dataGridViewManager.CellMouseMove += new DataGridViewCellMouseEventHandler(DataGridViewManager_CellMouseMove);
            dataGridViewManager.CellPainting += new DataGridViewCellPaintingEventHandler(DataGridViewManager_CellPainting);
        }

        private void CmdManagerSave_Click(object sender, EventArgs e)
        {
            int update_count = 0;
            try
            {
                update_count += da.Update(ds.Tables["manager_ds"].Select(null, null, DataViewRowState.Deleted));
                update_count += da.Update(ds.Tables["manager_ds"].Select(null, null, DataViewRowState.ModifiedCurrent));
                update_count += da.Update(ds.Tables["manager_ds"].Select(null, null, DataViewRowState.Added));
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存に失敗しました。\n\n[内容]\n" + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(update_count.ToString() + "件、保存しました。", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ManagerRowUpdated(Object sender, NpgsqlRowUpdatedEventArgs e)
        {
            if (e.Status == UpdateStatus.Continue)
            {
                if (e.StatementType == System.Data.StatementType.Insert)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand
                (
                "SELECT"
                + " m_id"
                + ", start_date"
                + ", end_date"
                + ", o_id"
                + " FROM"
                + " t_manager"
                + " WHERE m_id=currval('t_manager_m_id_seq')"
                + " ORDER BY start_date;"
                , m_conn
                 );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        e.Row["m_id"] = reader["m_id"];
                        e.Row["start_date"] = reader["start_date"];
                        e.Row["end_date"] = reader["end_date"];
                        e.Row["o_id"] = reader["o_id"];
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
                "SELECT"
                + " m_id"
                + ", start_date"
                + ", end_date"
                + ", o_id"
                + " FROM"
                + " t_manager"
                + " WHERE m_id=" + e.Row["m_id"].ToString()
                + " ORDER BY start_date;"
                , m_conn
                    );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        e.Row["m_id"] = reader["m_id"];
                        e.Row["start_date"] = reader["start_date"];
                        e.Row["end_date"] = reader["end_date"];
                        e.Row["o_id"] = reader["o_id"];
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

        private void Form_manager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ds.HasChanges())
            {
                DialogResult ret = MessageBox.Show("保存していないデータがあります。終了してよろしいですか？"
                    , "終了", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void DataGridViewManager_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
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

        private void DataGridViewManager_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
