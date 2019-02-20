using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace rk_seikyu
{
    public partial class Form_nen : Form
    {
        private NpgsqlConnection m_conn = new NpgsqlConnection(rk_seikyu.Properties.Settings.Default.PostgresConnect);

        private NpgsqlDataAdapter da = new NpgsqlDataAdapter();
        private DataSet ds = new DataSet();
        private DataSet nen_ds = new DataSet();

        public Form_nen()
        {
            InitializeComponent();
        }

        private void Form_nen_Load(object sender, EventArgs e)
        {
            dataGridViewNen.Columns[0].HeaderText = "ID";
            dataGridViewNen.Columns[1].HeaderText = "年";

            da.SelectCommand = new NpgsqlCommand
            (
                   "select"
                + " n_id"
                + ", nen"
                + " from"
                + " t_nen"
                + " order by n_id;",
                m_conn
            );

            // insert
            da.InsertCommand = new NpgsqlCommand
            (
                    "insert into t_nen ("
                + " nen"
                + " ) values ("
                + " :nen"
                + ")",
                m_conn
            );
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("nen", NpgsqlTypes.NpgsqlDbType.Text, 0, "nen", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));

            // update
            da.UpdateCommand = new NpgsqlCommand(
                "update t_nen set"
                + " nen = :nen"
                + " where"
                + " n_id = :n_id"
                , m_conn
                );
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("nen", NpgsqlTypes.NpgsqlDbType.Text, 0, "nen", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("n_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "n_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

            // delete
            da.DeleteCommand = new NpgsqlCommand
            (
                   "delete from t_nen"
                + " where"
                + " n_id=:n_id"
                , m_conn
            );
            da.DeleteCommand.Parameters.Add(new NpgsqlParameter("n_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "n_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

            // RowUpdate
            da.RowUpdated += new NpgsqlRowUpdatedEventHandler(NenRowUpdated);

            da.Fill(ds, "nen");

            bindingSourceNen.DataSource = ds;
            bindingSourceNen.DataMember = "nen";

            bindingNavigatorNen.BindingSource = bindingSourceNen;

            //dataGridViewHoliday.AutoGenerateColumns = false;

            dataGridViewNen.DataSource = bindingSourceNen;

            dataGridViewNen.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            bindingNavigatorNen.Visible = true;

        }
        private void CmdNenSave_Click(object sender, EventArgs e)
        {
            int update_count = 0;
            try
            {
                update_count += da.Update(ds.Tables["nen"].Select(null, null, DataViewRowState.Deleted));
                update_count += da.Update(ds.Tables["nen"].Select(null, null, DataViewRowState.ModifiedCurrent));
                update_count += da.Update(ds.Tables["nen"].Select(null, null, DataViewRowState.Added));
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存に失敗しました。\n\n[内容]\n" + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(update_count.ToString() + "件、保存しました。", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void NenRowUpdated(Object sender, NpgsqlRowUpdatedEventArgs e)
        {
            if (e.Status == UpdateStatus.Continue)
            {
                if (e.StatementType == System.Data.StatementType.Insert)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand
                (
                "select"
                + " n_id"
                + ", nen"
                + " from"
                + " t_nen"
                + " where n_id=currval('t_nen_n_id_seq')"
                + " order by n_id;"
                , m_conn
                 );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        e.Row["n_id"] = reader["n_id"];
                        e.Row["nen"] = reader["nen"];
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
                + " n_id"
                + ", nen"
                + " from"
                + " t_nen"
                + " where n_id=" + e.Row["n_id"].ToString()
                + " order by n_id"
                , m_conn
                    );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        e.Row["n_id"] = reader["n_id"];
                        e.Row["nen"] = reader["nen"];
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

        private void Form_nen_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }
}
