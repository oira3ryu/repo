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
    public partial class Form_req : Form
    {
        private NpgsqlConnection m_conn = new NpgsqlConnection(rk_seikyu.Properties.Settings.Default.PostgresConnect);

        private NpgsqlDataAdapter da = new NpgsqlDataAdapter();
        private DataSet ds = new DataSet();

        public Form_req()
        {
            InitializeComponent();
        }

        private void Form_req_Load(object sender, EventArgs e)
        {
            dataGridViewReq.Columns[0].HeaderText = "ID";
            dataGridViewReq.Columns[1].HeaderText = "予備";
            dataGridViewReq.Columns[2].HeaderText = "職名１";
            dataGridViewReq.Columns[3].HeaderText = "町長名";
            dataGridViewReq.Columns[4].HeaderText = "住所１";
            dataGridViewReq.Columns[5].HeaderText = "職名２";
            dataGridViewReq.Columns[6].HeaderText = "会計管理者";
            dataGridViewReq.Columns[7].HeaderText = "会計管理者職名カナ";
            dataGridViewReq.Columns[8].HeaderText = "管理者氏名";
            dataGridViewReq.Columns[9].HeaderText = "担当者";
            dataGridViewReq.Columns[10].HeaderText = "電話番号";
            dataGridViewReq.Columns[11].HeaderText = "会計管理者氏名カナ";
            dataGridViewReq.Columns[12].HeaderText = "事業所名称";
            dataGridViewReq.Columns[13].HeaderText = "口座種別";
            dataGridViewReq.Columns[14].HeaderText = "口座番号";
            dataGridViewReq.Columns[15].HeaderText = "予備";
            dataGridViewReq.Columns[16].HeaderText = "予備";
            da.SelectCommand = new NpgsqlCommand
            (
                   "select"
                   + " req_id"
                + ", title1"
                + ", title2"
                + ", name1"
                + ", title3"
                + ", title4"
                + ", name2"
                + ", title4_kana"
                + ", name3"
                + ", name4"
                + ", name5"
                + ", name2_kana"
                + ", data6"
                + ", data7"
                + ", data8"
                + ", data9"
                + ", data10"
                + " from"
                + " t_req"
                + " order by req_id;",
                m_conn
            );

            // insert
            da.InsertCommand = new NpgsqlCommand
            (
                    "insert into t_req ("
                + " title1"
                + ", title2"
                + ", name1"
                + ", title3"
                + ", title4"
                + ", name2"
                + ", title4_kana"
                + ", name3"
                + ", name4"
                + ", name5"
                + ", name2_kana"
                + ", data6"
                + ", data7"
                + ", data8"
                + ", data9"
                + ", data10"
                + " ) values ("
                + " :title1"
                + ", :title2"
                + ", :name1"
                + ", :title3"
                + ", :title4"
                + ", :name2"
                + ", :title4_kana"
                + ", :name3"
                + ", :name4"
                + ", :name5"
                + ", :name2_kana"
                + ", :data6"
                + ", :data7"
                + ", :data8"
                + ", :data9"
                + ", :data10"
                + ");",
                m_conn
            );
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("title1", NpgsqlTypes.NpgsqlDbType.Text, 0, "title1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("title2", NpgsqlTypes.NpgsqlDbType.Text, 0, "title2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("name1", NpgsqlTypes.NpgsqlDbType.Text, 0, "name1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("title3", NpgsqlTypes.NpgsqlDbType.Text, 0, "title3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("title4", NpgsqlTypes.NpgsqlDbType.Text, 0, "title4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("name2", NpgsqlTypes.NpgsqlDbType.Text, 0, "name2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("title4_kana", NpgsqlTypes.NpgsqlDbType.Text, 0, "title4_kana", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("name3", NpgsqlTypes.NpgsqlDbType.Text, 0, "name3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("name4", NpgsqlTypes.NpgsqlDbType.Text, 0, "name4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("name5", NpgsqlTypes.NpgsqlDbType.Text, 0, "name5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("name2_kana", NpgsqlTypes.NpgsqlDbType.Text, 0, "name2_kana", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("data6", NpgsqlTypes.NpgsqlDbType.Text, 0, "data6", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("data7", NpgsqlTypes.NpgsqlDbType.Text, 0, "data7", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("data8", NpgsqlTypes.NpgsqlDbType.Text, 0, "data8", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("data9", NpgsqlTypes.NpgsqlDbType.Text, 0, "data9", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("data10", NpgsqlTypes.NpgsqlDbType.Text, 0, "data10", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("req_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "req_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

            // update
            da.UpdateCommand = new NpgsqlCommand(
                "update t_req set"
                + " title1 = :title1"
                + ", title2 = :title2"
                + ", name1 = :name1"
                + ", title3 = :title3"
                + ", title4 = :title4"
                + ", name2 = :name2"
                + ", title4_kana = :title4_kana"
                + ", name3 = :name3"
                + ", name4 = :name4"
                + ", name5 = :name5"
                + ", name2_kana = :name2_kana"
                + ", data6 = :data6"
                + ", data7 = :data7"
                + ", data8 = :data8"
                + ", data9 = :data9"
                + ", data10 = :data10"
                + " where"
                + " req_id = :req_id"
                , m_conn
                );
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("title1", NpgsqlTypes.NpgsqlDbType.Text, 0, "title1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("title2", NpgsqlTypes.NpgsqlDbType.Text, 0, "title2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("name1", NpgsqlTypes.NpgsqlDbType.Text, 0, "name1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("title3", NpgsqlTypes.NpgsqlDbType.Text, 0, "title3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("title4", NpgsqlTypes.NpgsqlDbType.Text, 0, "title4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("name2", NpgsqlTypes.NpgsqlDbType.Text, 0, "name2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("title4_kana", NpgsqlTypes.NpgsqlDbType.Text, 0, "title4_kana", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("name3", NpgsqlTypes.NpgsqlDbType.Text, 0, "name3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("name4", NpgsqlTypes.NpgsqlDbType.Text, 0, "name4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("name5", NpgsqlTypes.NpgsqlDbType.Text, 0, "name5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("name2_kana", NpgsqlTypes.NpgsqlDbType.Text, 0, "name2_kana", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("data6", NpgsqlTypes.NpgsqlDbType.Text, 0, "data6", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("data7", NpgsqlTypes.NpgsqlDbType.Text, 0, "data7", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("data8", NpgsqlTypes.NpgsqlDbType.Text, 0, "data8", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("data9", NpgsqlTypes.NpgsqlDbType.Text, 0, "data9", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("data10", NpgsqlTypes.NpgsqlDbType.Text, 0, "data10", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("req_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "req_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

            // delete
            da.DeleteCommand = new NpgsqlCommand
            (
                   "delete from t_req"
                + " where"
                + " req_id=:req_id"
                , m_conn
            );
            da.DeleteCommand.Parameters.Add(new NpgsqlParameter("req_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "req_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

            // RowUpdate
            da.RowUpdated += new NpgsqlRowUpdatedEventHandler(reqRowUpdated);

            da.Fill(ds, "req_ds");

            bindingSourceReq.DataSource = ds;
            bindingSourceReq.DataMember = "req_ds";

            bindingNavigatorReq.BindingSource = bindingSourceReq;

            //dataGridViewHoliday.AutoGenerateColumns = false;

            dataGridViewReq.DataSource = bindingSourceReq;

            dataGridViewReq.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            bindingNavigatorReq.Visible = true;

        }
        private void cmdReqSave_Click(object sender, EventArgs e)
        {
            int update_count = 0;
            try
            {
                update_count += da.Update(ds.Tables["req_ds"].Select(null, null, DataViewRowState.Deleted));
                update_count += da.Update(ds.Tables["req_ds"].Select(null, null, DataViewRowState.ModifiedCurrent));
                update_count += da.Update(ds.Tables["req_ds"].Select(null, null, DataViewRowState.Added));
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存に失敗しました。\n\n[内容]\n" + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(update_count.ToString() + "件、保存しました。", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void reqRowUpdated(Object sender, NpgsqlRowUpdatedEventArgs e)
        {
            if (e.Status == UpdateStatus.Continue)
            {
                if (e.StatementType == System.Data.StatementType.Insert)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand
                (
                   "select"
                + " title1"
                + ", title2"
                + ", name1"
                + ", title3"
                + ", title4"
                + ", name2"
                + ", title4_kana"
                + ", name3"
                + ", name4"
                + ", name5"
                + ", name2_kana"
                + ", data6"
                + ", data7"
                + ", data8"
                + ", data9"
                + ", data10"
                + " from"
                + " t_req"
                + " where req_id=currval('t_req_req_id_seq')"
                + " order by req_id;"
                , m_conn
                 );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        e.Row["title1"] = reader["title1"];
                        e.Row["title2"] = reader["title2"];
                        e.Row["name1"] = reader["name1"];
                        e.Row["title3"] = reader["title3"];
                        e.Row["title4"] = reader["title4"];
                        e.Row["name2"] = reader["name2"];
                        e.Row["title4_kana"] = reader["title4_kana"];
                        e.Row["name3"] = reader["name3"];
                        e.Row["name4"] = reader["name4"];
                        e.Row["name5"] = reader["name5"];
                        e.Row["name2_kana"] = reader["name2_kana"];
                        e.Row["data6"] = reader["data6"];
                        e.Row["data7"] = reader["data7"];
                        e.Row["data8"] = reader["data8"];
                        e.Row["data9"] = reader["data9"];
                        e.Row["data10"] = reader["data10"];
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
                + " title1"
                + ", title2"
                + ", name1"
                + ", title3"
                + ", title4"
                + ", name2"
                + ", title4_kana"
                + ", name3"
                + ", name4"
                + ", name5"
                + ", name2_kana"
                + ", data6"
                + ", data7"
                + ", data8"
                + ", data9"
                + ", data10"
                + " from"
                + " t_req"
                + " where req_id=" + e.Row["req_id"].ToString()
                + " order by req_id"
                , m_conn
                    );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        e.Row["title1"] = reader["title1"];
                        e.Row["title2"] = reader["title2"];
                        e.Row["name1"] = reader["name1"];
                        e.Row["title3"] = reader["title3"];
                        e.Row["title4"] = reader["title4"];
                        e.Row["name2"] = reader["name2"];
                        e.Row["title4_kana"] = reader["title4_kana"];
                        e.Row["name3"] = reader["name3"];
                        e.Row["name4"] = reader["name4"];
                        e.Row["name5"] = reader["name5"];
                        e.Row["name2_kana"] = reader["name2_kana"];
                        e.Row["data6"] = reader["data6"];
                        e.Row["data7"] = reader["data7"];
                        e.Row["data8"] = reader["data8"];
                        e.Row["data9"] = reader["data9"];
                        e.Row["data10"] = reader["data10"];
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
    }
}
