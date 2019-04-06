using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace rk_seikyu
{
    public partial class Form_stuff : Form
    {
        private NpgsqlConnection m_conn = new NpgsqlConnection(rk_seikyu.Properties.Settings.Default.PostgresConnect);

        private NpgsqlDataAdapter da = new NpgsqlDataAdapter();
        private DataSet ds = new DataSet();

        public Form_stuff()
        {
            InitializeComponent();
        }

        private void CmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Form_stuff_Load(object sender, EventArgs e)
        {
            dataGridViewStuff.Columns[0].HeaderText = "ID";
            dataGridViewStuff.Columns[1].HeaderText = "担当者";
            dataGridViewStuff.Columns[2].HeaderText = "開始日";
            dataGridViewStuff.Columns[3].HeaderText = "終了日";
            dataGridViewStuff.Columns[4].HeaderText = "事業所ID";

            da.SelectCommand = new NpgsqlCommand
            (
                   "SELECT"
                + " stf_id"
                + ", stuff"
                + ", start_date"
                + ", end_date"
                + ", o_id"
                + " FROM"
                + " t_stuff"
                + " ORDER BY start_date;",
                m_conn
                );

            // insert
            da.InsertCommand = new NpgsqlCommand
            (
                    "INSERT INTO t_stuff ("
                + " stuff"
                + ", start_date"
                + ", end_date"
                + ", o_id"
                + " ) VALUES ("
                + ", :stuff"
                + ", :start_date"
                + ", :end_date"
                + ", :o_id"
                + ");",
                m_conn
            );
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("stuff", NpgsqlTypes.NpgsqlDbType.Text, 0, "stuff", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("start_date", NpgsqlTypes.NpgsqlDbType.TimestampTz, 0, "start_date", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("end_date", NpgsqlTypes.NpgsqlDbType.TimestampTz, 0, "end_date", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            m_conn.Close();


            // update
            da.UpdateCommand = new NpgsqlCommand(
                "UPDATE t_stuff SET"
                + " stuff = :stuff"
                + ", start_date = :start_date"
                + ", end_date = :end_date"
                + ", o_id = :o_id"
                + " WHERE"
                + " stf_id = :stf_id"
                , m_conn
                );
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("stuff", NpgsqlTypes.NpgsqlDbType.Text, 0, "stuff", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("start_date", NpgsqlTypes.NpgsqlDbType.TimestampTz, 0, "start_date", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("end_date", NpgsqlTypes.NpgsqlDbType.TimestampTz, 0, "end_date", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("stf_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "stf_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));
            // delete
            da.DeleteCommand = new NpgsqlCommand
            (
                   "DELETE FROM t_stuff"
                + " WHERE"
                + " stf_id=:stf_id"
                , m_conn
            );
            da.DeleteCommand.Parameters.Add(new NpgsqlParameter("stf_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "stf_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

            // RowUpdate
            da.RowUpdated += new NpgsqlRowUpdatedEventHandler(stuffRowUpdated);

            da.Fill(ds, "stuff_ds");

            bindingSourceStuff.DataSource = ds;
            bindingSourceStuff.DataMember = "stuff_ds";
            bindingNavigatorStuff.BindingSource = bindingSourceStuff;
            dataGridViewStuff.DataSource = bindingSourceStuff;
            dataGridViewStuff.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            bindingNavigatorStuff.Visible = true;

            // カラムを関連付け
            stf_id.DataPropertyName = "stf_id";
            stuff.DataPropertyName = "stuff";
            start_date.DataPropertyName = "start_date";
            end_date.DataPropertyName = "end_date";
            o_id.DataPropertyName = "o_id";

            DataGridViewEvent();
        }

        private void DataGridViewEvent()
        {
            dataGridViewStuff.CellMouseMove += new DataGridViewCellMouseEventHandler(DataGridViewStuff_CellMouseMove);
            dataGridViewStuff.CellPainting += new DataGridViewCellPaintingEventHandler(DataGridViewStuff_CellPainting);
        }

        private void CmdStuffSave_Click(object sender, EventArgs e)
        {
            int update_count = 0;
            try
            {
                update_count += da.Update(ds.Tables["stuff_ds"].Select(null, null, DataViewRowState.Deleted));
                update_count += da.Update(ds.Tables["stuff_ds"].Select(null, null, DataViewRowState.ModifiedCurrent));
                update_count += da.Update(ds.Tables["stuff_ds"].Select(null, null, DataViewRowState.Added));
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存に失敗しました。\n\n[内容]\n" + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(update_count.ToString() + "件、保存しました。", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void stuffRowUpdated(Object sender, NpgsqlRowUpdatedEventArgs e)
        {
            if (e.Status == UpdateStatus.Continue)
            {
                if (e.StatementType == System.Data.StatementType.Insert)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand
                (
                "SELECT"
                + " stf_id"
                + ", start_date"
                + ", end_date"
                + ", o_id"
                + " FROM"
                + " t_stuff"
                + " WHERE stf_id=currval('t_stuff_stf_id_seq')"
                + " ORDER BY start_date;"
                , m_conn
                 );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        e.Row["stf_id"] = reader["stf_id"];
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
                + " stf_id"
                + ", start_date"
                + ", end_date"
                + ", o_id"
                + " FROM"
                + " t_stuff"
                + " WHERE stf_id=" + e.Row["stf_id"].ToString()
                + " ORDER BY start_date;"
                , m_conn
                    );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        e.Row["stf_id"] = reader["stf_id"];
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

        private void Form_stuff_FormClosing(object sender, FormClosingEventArgs e)
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

        private void DataGridViewStuff_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
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

        private void DataGridViewStuff_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
