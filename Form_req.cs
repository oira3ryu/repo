using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace rk_seikyu
{
    public partial class Form_req : Form
    {
        private NpgsqlConnection m_conn = new NpgsqlConnection(rk_seikyu.Properties.Settings.Default.PostgresConnect);

        private NpgsqlDataAdapter da = new NpgsqlDataAdapter();
        private DataSet ds = new DataSet();

        public int Cmb_o_id_int { get; set; }

        public string cmb_o_id_str;
        public string cmb_o_id_item;
        public string Form_Seikyu_TextBoxO_id;

        private Form_seikyu form_seikyu_Instance;

        public Form_req()
        {
            InitializeComponent();

            //Form_seikyuのインスタンスを取得
            form_seikyu_Instance = Form_seikyu.Form_seikyu_Instance;
            //Form_seikyuのテキストボックス文字列を
            //Form_prnの文字列変数cmb_o_id_strへ設定
            Form_Seikyu_TextBoxO_id = form_seikyu_Instance.TextBoxO_id;
            cmb_o_id_item = form_seikyu_Instance.TextBoxO_name;
            Console.WriteLine("cmb_o_idからのメンバーは、" + cmb_o_id_item);
        }

        private void Form_req_Load(object sender, EventArgs e)
        {
            dataGridViewReq.Columns[0].HeaderText = "ID";
            dataGridViewReq.Columns[1].HeaderText = "予備";
            dataGridViewReq.Columns[2].HeaderText = "職名";
            dataGridViewReq.Columns[3].HeaderText = "住所";
            dataGridViewReq.Columns[4].HeaderText = "会計管理者";
            dataGridViewReq.Columns[5].HeaderText = "会計管理者カナ";
            dataGridViewReq.Columns[6].HeaderText = "口座種別";
            dataGridViewReq.Columns[7].HeaderText = "口座番号";
            dataGridViewReq.Columns[8].HeaderText = "予備";
            dataGridViewReq.Columns[9].HeaderText = "予備";
            dataGridViewReq.Columns[10].HeaderText = "OID";

            da.SelectCommand = new NpgsqlCommand
            (
                   "SELECT"
                + " req_id"
                + ", title1"
                + ", title2"
                + ", title3"
                + ", title4"
                + ", title4_kana"
                + ", data7"
                + ", data8"
                + ", data9"
                + ", data10"
                + ", o_id"
                + " FROM"
                + " t_req"
                //+ " WHERE o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                + " ORDER BY req_id;",
                m_conn
            );

            // insert
            da.InsertCommand = new NpgsqlCommand
            (
                "INSERT INTO t_req ("
                + " title1"
                + ", title2"
                + ", title3"
                + ", title4"
                + ", title4_kana"
                + ", data7"
                + ", data8"
                + ", data9"
                + ", data10"
                + ", o_id"
                + " ) VALUES ("
                + " :title1"
                + ", :title2"
                + ", :title3"
                + ", :title4"
                + ", :title4_kana"
                + ", :data7"
                + ", :data8"
                + ", :data9"
                + ", :data10"
                + ", :o_id"
                + ");",
                m_conn
            );
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("title1", NpgsqlTypes.NpgsqlDbType.Text, 0, "title1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("title2", NpgsqlTypes.NpgsqlDbType.Text, 0, "title2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("title3", NpgsqlTypes.NpgsqlDbType.Text, 0, "title3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("title4", NpgsqlTypes.NpgsqlDbType.Text, 0, "title4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("title4_kana", NpgsqlTypes.NpgsqlDbType.Text, 0, "title4_kana", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("data7", NpgsqlTypes.NpgsqlDbType.Text, 0, "data7", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("data8", NpgsqlTypes.NpgsqlDbType.Text, 0, "data8", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("data9", NpgsqlTypes.NpgsqlDbType.Text, 0, "data9", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("data10", NpgsqlTypes.NpgsqlDbType.Text, 0, "data10", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("req_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "req_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

            // update
            da.UpdateCommand = new NpgsqlCommand(
                "UPDATE t_req SET"
                + " title1 = :title1"
                + ", title2 = :title2"
                + ", title3 = :title3"
                + ", title4 = :title4"
                + ", title4_kana = :title4_kana"
                + ", data7 = :data7"
                + ", data8 = :data8"
                + ", data9 = :data9"
                + ", data10 = :data10"
                + ", o_id = :o_id"
                + " WHERE"
                + " req_id = :req_id"
                , m_conn
                );
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("title1", NpgsqlTypes.NpgsqlDbType.Text, 0, "title1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("title2", NpgsqlTypes.NpgsqlDbType.Text, 0, "title2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("title3", NpgsqlTypes.NpgsqlDbType.Text, 0, "title3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("title4", NpgsqlTypes.NpgsqlDbType.Text, 0, "title4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("title4_kana", NpgsqlTypes.NpgsqlDbType.Text, 0, "title4_kana", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("data7", NpgsqlTypes.NpgsqlDbType.Text, 0, "data7", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("data8", NpgsqlTypes.NpgsqlDbType.Text, 0, "data8", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("data9", NpgsqlTypes.NpgsqlDbType.Text, 0, "data9", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("data10", NpgsqlTypes.NpgsqlDbType.Text, 0, "data10", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("req_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "req_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

            // delete
            da.DeleteCommand = new NpgsqlCommand
            (
                   "DELETE FROM t_req"
                + " WHERE"
                + " req_id = :req_id"
                , m_conn
            );
            da.DeleteCommand.Parameters.Add(new NpgsqlParameter("req_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "req_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

            // RowUpdate
            da.RowUpdated += new NpgsqlRowUpdatedEventHandler(ReqRowUpdated);

            da.Fill(ds, "req_ds");

            bindingSourceReq.DataSource = ds;
            bindingSourceReq.DataMember = "req_ds";

            bindingNavigatorReq.BindingSource = bindingSourceReq;

            //dataGridViewHoliday.AutoGenerateColumns = false;

            dataGridViewReq.DataSource = bindingSourceReq;

            dataGridViewReq.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            bindingNavigatorReq.Visible = true;

        }
        private void CmdReqSave_Click(object sender, EventArgs e)
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

        private void ReqRowUpdated(Object sender, NpgsqlRowUpdatedEventArgs e)
        {
            if (e.Status == UpdateStatus.Continue)
            {
                if (e.StatementType == System.Data.StatementType.Insert)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand
                (
                   "SELECT"
                + " title1"
                + ", title2"
                + ", title3"
                + ", title4"
                + ", title4_kana"
                + ", data7"
                + ", data8"
                + ", data9"
                + ", data10"
                + ", o_id"
                + " FROM"
                + " t_req"
                + " WHERE req_id = currval('t_req_req_id_seq')"
                + " OEDER BY req_id;"
                , m_conn
                 );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        e.Row["title1"] = reader["title1"];
                        e.Row["title2"] = reader["title2"];
                        e.Row["title3"] = reader["title3"];
                        e.Row["title4"] = reader["title4"];
                        e.Row["title4_kana"] = reader["title4_kana"];
                        e.Row["data7"] = reader["data7"];
                        e.Row["data8"] = reader["data8"];
                        e.Row["data9"] = reader["data9"];
                        e.Row["data10"] = reader["data10"];
                        e.Row["o_id"] = reader["o_id"];
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
                + " title1"
                + ", title2"
                + ", title3"
                + ", title4"
                + ", title4_kana"
                + ", data7"
                + ", data8"
                + ", data9"
                + ", data10"
                + ", o_id"
                + " FROM"
                + " t_req"
                + " WHERE req_id =" + e.Row["req_id"].ToString()
                + " ORDER BY req_id"
                , m_conn
                    );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        e.Row["title1"] = reader["title1"];
                        e.Row["title2"] = reader["title2"];
                        e.Row["title3"] = reader["title3"];
                        e.Row["title4"] = reader["title4"];
                        e.Row["title4_kana"] = reader["title4_kana"];
                        e.Row["data7"] = reader["data7"];
                        e.Row["data8"] = reader["data8"];
                        e.Row["data9"] = reader["data9"];
                        e.Row["data10"] = reader["data10"];
                        e.Row["o_id"] = reader["o_id"];
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
