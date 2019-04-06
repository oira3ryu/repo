using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace rk_seikyu
{
    public partial class Form_accounting_manager : Form
    {
        private NpgsqlConnection m_conn = new NpgsqlConnection(rk_seikyu.Properties.Settings.Default.PostgresConnect);

        private NpgsqlDataAdapter da = new NpgsqlDataAdapter();
        private DataSet ds = new DataSet();

        public Form_accounting_manager()
        {
            InitializeComponent();
        }

        private void CmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Form_accounting_manager_Load(object sender, EventArgs e)
        {
            dataGridViewAccounting_manager.Columns[0].HeaderText = "ID";
            dataGridViewAccounting_manager.Columns[1].HeaderText = "会計管理者";
            dataGridViewAccounting_manager.Columns[2].HeaderText = "開始日";
            dataGridViewAccounting_manager.Columns[3].HeaderText = "終了日";

            da.SelectCommand = new NpgsqlCommand
            (
                   "SELECT"
                + " acc_id"
                + ", accounting_manager"
                + ", start_date"
                + ", end_date"
                + " FROM"
                + " t_accounting_manager"
                + " order by start_date;",
                m_conn
                );

            // insert
            da.InsertCommand = new NpgsqlCommand
            (
                    "INSERT INTO t_accounting_manager ("
                + " accounting_manager"
                + ", start_date"
                + ", end_date"
                + " ) VALUES ("
                + ", :accounting_manager"
                + ", :start_date"
                + ", :end_date"
                + ");",
                m_conn
            );
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("accounting_manager", NpgsqlTypes.NpgsqlDbType.Text, 0, "accounting_manager", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("start_date", NpgsqlTypes.NpgsqlDbType.TimestampTz, 0, "start_date", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("end_date", NpgsqlTypes.NpgsqlDbType.TimestampTz, 0, "end_date", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            m_conn.Close();


            // update
            da.UpdateCommand = new NpgsqlCommand(
                "update t_accounting_manager set"
                + " accounting_manager = :accounting_manager"
                + ", start_date = :start_date"
                + ", end_date = :end_date"
                + " where"
                + " acc_id = :acc_id"
                , m_conn
                );
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("accounting_manager", NpgsqlTypes.NpgsqlDbType.Text, 0, "accounting_manager", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("start_date", NpgsqlTypes.NpgsqlDbType.TimestampTz, 0, "start_date", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("end_date", NpgsqlTypes.NpgsqlDbType.TimestampTz, 0, "end_date", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("acc_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "acc_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));
            // delete
            da.DeleteCommand = new NpgsqlCommand
            (
                   "DELETE FROM t_accounting_manager"
                + " WHERE"
                + " acc_id=:acc_id"
                , m_conn
            );
            da.DeleteCommand.Parameters.Add(new NpgsqlParameter("acc_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "acc_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

            // RowUpdate
            da.RowUpdated += new NpgsqlRowUpdatedEventHandler(Accounting_managerRowUpdated);

            da.Fill(ds, "accounting_manager_ds");

            bindingSourceAccounting_manager.DataSource = ds;
            bindingSourceAccounting_manager.DataMember = "accounting_manager_ds";
            bindingNavigatorAccounting_manager.BindingSource = bindingSourceAccounting_manager;
            dataGridViewAccounting_manager.DataSource = bindingSourceAccounting_manager;
            dataGridViewAccounting_manager.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            bindingNavigatorAccounting_manager.Visible = true;

            // カラムを関連付け
            acc_id.DataPropertyName = "acc_id";
            accounting_manager.DataPropertyName = "accounting_manager";
            start_date.DataPropertyName = "start_date";
            end_date.DataPropertyName = "end_date";

            DataGridViewEvent();
        }

        private void DataGridViewEvent()
        {
            dataGridViewAccounting_manager.CellMouseMove += new DataGridViewCellMouseEventHandler(DataGridViewAccounting_manager_CellMouseMove);
            dataGridViewAccounting_manager.CellPainting += new DataGridViewCellPaintingEventHandler(DataGridViewAccounting_manager_CellPainting);
        }

        private void CmdAccounting_managerSave_Click(object sender, EventArgs e)
        {
            int update_count = 0;
            try
            {
                update_count += da.Update(ds.Tables["accounting_manager_ds"].Select(null, null, DataViewRowState.Deleted));
                update_count += da.Update(ds.Tables["accounting_manager_ds"].Select(null, null, DataViewRowState.ModifiedCurrent));
                update_count += da.Update(ds.Tables["accounting_manager_ds"].Select(null, null, DataViewRowState.Added));
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存に失敗しました。\n\n[内容]\n" + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(update_count.ToString() + "件、保存しました。", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Accounting_managerRowUpdated(Object sender, NpgsqlRowUpdatedEventArgs e)
        {
            if (e.Status == UpdateStatus.Continue)
            {
                if (e.StatementType == System.Data.StatementType.Insert)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand
                (
                "SELECT"
                + " acc_id"
                + ", start_date"
                + ", end_date"
                + " FROM"
                + " t_accounting_manager"
                + " WHERE acc_id=currval('t_accounting_manager_acc_id_seq')"
                + " ORDER BY start_date;"
                , m_conn
                 );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        e.Row["acc_id"] = reader["acc_id"];
                        e.Row["start_date"] = reader["start_date"];
                        e.Row["end_date"] = reader["end_date"];
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
                + " acc_id"
                + ", start_date"
                + ", end_date"
                + " FROM"
                + " t_accounting_manager"
                + " WHERE acc_id=" + e.Row["acc_id"].ToString()
                + " ORDER BY start_date;"
                , m_conn
                    );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        e.Row["acc_id"] = reader["acc_id"];
                        e.Row["start_date"] = reader["start_date"];
                        e.Row["end_date"] = reader["end_date"];
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

        private void Form_Accounting_manager_FormClosing(object sender, FormClosingEventArgs e)
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

        private void DataGridViewAccounting_manager_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
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

        private void DataGridViewAccounting_manager_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
