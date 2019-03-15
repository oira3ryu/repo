using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace rk_seikyu
{
    public partial class Form_gyoumu : Form
    {
        private NpgsqlConnection m_conn = new NpgsqlConnection(rk_seikyu.Properties.Settings.Default.PostgresConnect);

        private NpgsqlDataAdapter da = new NpgsqlDataAdapter();
        private DataSet ds = new DataSet();

        public Form_gyoumu()
        {
            InitializeComponent();
        }

        private void Form_gyoumu_Load(object sender, EventArgs e)
        {
            dataGridViewGyoumu.Columns[0].HeaderText = "ID";
            dataGridViewGyoumu.Columns[1].HeaderText = "業務名";

            da.SelectCommand = new NpgsqlCommand
            (
                   "select"
                + " g_id"
                + ", gyoumu"
                + " from"
                + " t_gyoumu"
                + " order by g_id;",
                m_conn
            );

            // insert
            da.InsertCommand = new NpgsqlCommand
            (
                    "insert into t_gyoumu ("
                + " gyoumu"
                + " ) values ("
                + " :gyoumu"
                + ")",
                m_conn
            );
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("gyoumu", NpgsqlTypes.NpgsqlDbType.Text, 0, "gyoumu", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));

            // update
            da.UpdateCommand = new NpgsqlCommand(
                "update t_gyoumu set"
                + " gyoumu = :gyoumu"
                + " where"
                + " g_id = :g_id"
                , m_conn
                );
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("gyoumu", NpgsqlTypes.NpgsqlDbType.Text, 0, "gyoumu", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("g_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "g_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

            // delete
            da.DeleteCommand = new NpgsqlCommand
            (
                   "delete from t_gyoumu"
                + " where"
                + " g_id=:g_id"
                , m_conn
            );
            da.DeleteCommand.Parameters.Add(new NpgsqlParameter("g_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "g_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

            // RowUpdate
            da.RowUpdated += new NpgsqlRowUpdatedEventHandler(GyoumuRowUpdated);

            da.Fill(ds, "gyoumu_ds");

            bindingSourceGyoumu.DataSource = ds;
            bindingSourceGyoumu.DataMember = "gyoumu_ds";

            bindingNavigatorGyoumu.BindingSource = bindingSourceGyoumu;

            //dataGridViewHoliday.AutoGenerateColumns = false;

            dataGridViewGyoumu.DataSource = bindingSourceGyoumu;

            dataGridViewGyoumu.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            bindingNavigatorGyoumu.Visible = true;

            DataGridViewEvent();
        }

        private void DataGridViewEvent()
        {
            dataGridViewGyoumu.CellMouseMove += new DataGridViewCellMouseEventHandler(DataGridViewGyoumu_CellMouseMove);
            dataGridViewGyoumu.CellPainting += new DataGridViewCellPaintingEventHandler(DataGridViewGyoumu_CellPainting);
        }

        private void CmdGyoumuSave_Click(object sender, EventArgs e)
        {
            int update_count = 0;
            try
            {
                update_count += da.Update(ds.Tables["gyoumu_ds"].Select(null, null, DataViewRowState.Deleted));
                update_count += da.Update(ds.Tables["gyoumu_ds"].Select(null, null, DataViewRowState.ModifiedCurrent));
                update_count += da.Update(ds.Tables["gyoumu_ds"].Select(null, null, DataViewRowState.Added));
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存に失敗しました。\n\n[内容]\n" + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(update_count.ToString() + "件、保存しました。", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GyoumuRowUpdated(Object sender, NpgsqlRowUpdatedEventArgs e)
        {
            if (e.Status == UpdateStatus.Continue)
            {
                if (e.StatementType == System.Data.StatementType.Insert)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand
                (
                "select"
                + " g_id"
                + ", gyoumu"
                + " from"
                + " t_gyoumu"
                + " where g_id=currval('t_gyoumu_g_id_seq')"
                + " order by g_id;"
                , m_conn
                 );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        e.Row["g_id"] = reader["g_id"];
                        e.Row["gyoumu"] = reader["gyoumu"];
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
                + " g_id"
                + ", gyoumu"
                + " from"
                + " t_gyoumu"
                + " where g_id=" + e.Row["g_id"].ToString()
                + " order by g_id"
                , m_conn
                    );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        e.Row["g_id"] = reader["g_id"];
                        e.Row["gyoumu"] = reader["gyoumu"];
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

        private void Form_gyoumu_FormClosing(object sender, FormClosingEventArgs e)
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

        private void DataGridViewGyoumu_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
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

        private void DataGridViewGyoumu_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
