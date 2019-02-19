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
    public partial class Form_bank : Form
    {
        private NpgsqlConnection m_conn = new NpgsqlConnection(rk_seikyu.Properties.Settings.Default.PostgresConnect);

        private NpgsqlDataAdapter da = new NpgsqlDataAdapter();
        private DataSet ds = new DataSet();
        private DataSet bank_ds = new DataSet();

        public Form_bank()
        {
            InitializeComponent();
        }

        private void Form_bank_Load(object sender, EventArgs e)
        {
            dataGridViewBank.Columns[0].HeaderText = "ID";
            dataGridViewBank.Columns[1].HeaderText = "種別番号";
            dataGridViewBank.Columns[2].HeaderText = "金融機関番号";
            dataGridViewBank.Columns[3].HeaderText = "金融機関名";
            dataGridViewBank.Columns[4].HeaderText = "省略名";
            dataGridViewBank.Columns[5].HeaderText = "支店番号";
            dataGridViewBank.Columns[6].HeaderText = "支店名";
            dataGridViewBank.Columns[7].HeaderText = "引落年";
            dataGridViewBank.Columns[8].HeaderText = "引落月";
            dataGridViewBank.Columns[9].HeaderText = "引落日";

            da.SelectCommand = new NpgsqlCommand
            (
                   "select"
                + " bid"
                + ", b_id"
                + ", b_code"
                + ", b_name"
                + ", sb_name"
                + ", br_code"
                + ", br_name"
                + ", sd"
                + ", sm"
                + ", sy"
                + " from"
                + " t_bank"
                + " order by b_id;",
                m_conn
                );

            // insert
            da.InsertCommand = new NpgsqlCommand
            (
                    "insert into t_bank ("
                + "b_id"
                + ", b_code"
                + ", b_name"
                + ", sb_name"
                + ", br_code"
                + ", br_name"
                + ", sd"
                + ", sm"
                + ", sy"
                + " ) values ("
                + ":b_id"
                + ", :b_code"
                + ", :b_name"
                + ", :sb_name"
                + ", :br_code"
                + ", :br_name"
                + ", :sd"
                + ", :sm"
                + ", :sy"
                + ")",
                m_conn
            );
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("b_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "b_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("b_code", NpgsqlTypes.NpgsqlDbType.Text, 0, "b_code", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("b_name", NpgsqlTypes.NpgsqlDbType.Text, 0, "b_name", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("sb_name", NpgsqlTypes.NpgsqlDbType.Text, 0, "sb_name", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("br_code", NpgsqlTypes.NpgsqlDbType.Text, 0, "br_code", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("br_name", NpgsqlTypes.NpgsqlDbType.Text, 0, "br_name", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("sd", NpgsqlTypes.NpgsqlDbType.Text, 0, "sd", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("sm", NpgsqlTypes.NpgsqlDbType.Text, 0, "sm", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("sy", NpgsqlTypes.NpgsqlDbType.Text, 0, "sy", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            m_conn.Close();


            // update
            da.UpdateCommand = new NpgsqlCommand(
                "update t_bank set"
                + " b_id = :b_id"
                + ", b_code = :b_code"
                + ", b_name = :b_name"
                + ", sb_name = :sb_name"
                + ", br_code = :br_code"
                + ", br_name = :br_name"
                + ", sd = :sd"
                + ", sm = :sm"
                + ", sy = :sy"
                + " where"
                + " bid = :bid"
                , m_conn
                );
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("b_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "b_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("b_code", NpgsqlTypes.NpgsqlDbType.Text, 0, "b_code", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("b_name", NpgsqlTypes.NpgsqlDbType.Text, 0, "b_name", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("sb_name", NpgsqlTypes.NpgsqlDbType.Text, 0, "sb_name", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("br_code", NpgsqlTypes.NpgsqlDbType.Text, 0, "br_code", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("br_name", NpgsqlTypes.NpgsqlDbType.Text, 0, "br_name", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("sd", NpgsqlTypes.NpgsqlDbType.Text, 0, "sd", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("sm", NpgsqlTypes.NpgsqlDbType.Text, 0, "sm", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("sy", NpgsqlTypes.NpgsqlDbType.Text, 0, "sy", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("bid", NpgsqlTypes.NpgsqlDbType.Integer, 0, "bid", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

            // delete
            da.DeleteCommand = new NpgsqlCommand
            (
                   "delete from t_bank"
                + " where"
                + " bid=:bid"
                , m_conn
            );
            da.DeleteCommand.Parameters.Add(new NpgsqlParameter("bid", NpgsqlTypes.NpgsqlDbType.Integer, 0, "bid", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

            // RowUpdate
            da.RowUpdated += new NpgsqlRowUpdatedEventHandler(bankRowUpdated);

            da.Fill(ds, "bank");

            bindingSourceBank.DataSource = ds;
            bindingSourceBank.DataMember = "bank";

            bindingNavigatorBank.BindingSource = bindingSourceBank;

            //dataGridViewHoliday.AutoGenerateColumns = false;

            dataGridViewBank.DataSource = bindingSourceBank;

            dataGridViewBank.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            bindingNavigatorBank.Visible = true;

        }
        private void cmdBankSave_Click(object sender, EventArgs e)
        {
            int update_count = 0;
            try
            {
                update_count += da.Update(ds.Tables["bank"].Select(null, null, DataViewRowState.Deleted));
                update_count += da.Update(ds.Tables["bank"].Select(null, null, DataViewRowState.ModifiedCurrent));
                update_count += da.Update(ds.Tables["bank"].Select(null, null, DataViewRowState.Added));
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存に失敗しました。\n\n[内容]\n" + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(update_count.ToString() + "件、保存しました。", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bankRowUpdated(Object sender, NpgsqlRowUpdatedEventArgs e)
        {
            if (e.Status == UpdateStatus.Continue)
            {
                if (e.StatementType == System.Data.StatementType.Insert)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand
                (
                "select"
				+ " bid"
                + ", b_id"
                + ", b_code"
                + ", b_name"
                + ", sb_name"
                + ", br_code"
                + ", br_name"
                + ", sd"
                + ", sm"
                + ", sy"
                + " from"
                + " t_bank"
                + " where bid=currval('t_bank_bid_seq')"
                + " order by bid;"
                , m_conn
                 );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        e.Row["bid"] = reader["bid"];
                        e.Row["b_id"] = reader["b_id"];
                        e.Row["b_code"] = reader["b_code"];
                        e.Row["b_name"] = reader["b_name"];
                        e.Row["sb_name"] = reader["sb_name"];
                        e.Row["br_code"] = reader["br_code"];
                        e.Row["br_name"] = reader["br_name"];
						e.Row["sd"] = reader["sd"];
                        e.Row["sm"] = reader["sm"];
                        e.Row["sy"] = reader["sy"];
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
				+ " bid"
                + ", b_id"
                + ", b_code"
                + ", b_name"
                + ", sb_name"
                + ", br_code"
                + ", br_name"
                + ", sd"
                + ", sm"
                + ", sy"
                + " from"
                + " t_bank"
                + " where bid=" + e.Row["bid"].ToString()
                + " order by bid"
                , m_conn
                    );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
						e.Row["bid"] = reader["bid"];
                        e.Row["b_id"] = reader["b_id"];
                        e.Row["b_code"] = reader["b_code"];
                        e.Row["b_name"] = reader["b_name"];
                        e.Row["sb_name"] = reader["sb_name"];
                        e.Row["br_code"] = reader["br_code"];
                        e.Row["br_name"] = reader["br_name"];
						e.Row["sd"] = reader["sd"];
                        e.Row["sm"] = reader["sm"];
                        e.Row["sy"] = reader["sy"];
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Form_bank_FormClosing(object sender, FormClosingEventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
