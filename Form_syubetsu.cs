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
    public partial class Form_syubetsu : Form
    {
        private NpgsqlConnection m_conn = new NpgsqlConnection(rk_seikyu.Properties.Settings.Default.PostgresConnect);

        private NpgsqlDataAdapter da = new NpgsqlDataAdapter();
        private DataSet ds = new DataSet();
        private DataSet syubetsu_ds = new DataSet();

        private Form_seikyu form_seikyu_Instance;

        public String cmb_o_id_str;
        public int cmb_o_id_int { get; set; }

        public Form_syubetsu()
        {
            InitializeComponent();

            //Form_seikyuのインスタンスを取得
            form_seikyu_Instance = Form_seikyu.Form_seikyu_Instance;
            //Form_seikyuのテキストボックス文字列を
            //Form_syubetsuの文字列変数cmb_o_id_strへ設定
            cmb_o_id_str = form_seikyu_Instance.cmb_o_id_Text;

            //Form_seikyuのコンボボックスcmb_o_idからの変数cmb_o_id_strをint型に変換して1加算
            int i;
            if (int.TryParse(cmb_o_id_str, out i))
            {
                cmb_o_id_int = i + 1;
                cmb_o_id_str = cmb_o_id_int.ToString();
                Console.WriteLine("cmb_o_idからの値は、" + cmb_o_id_str);
            }
            else
            {
                Console.WriteLine("cmb_o_idからの値を数値に変換できません");
            }
        }

        private void Form_syubetsu_Load(object sender, EventArgs e)
        {

            Console.WriteLine("Form_syubetsu_cmb_o_id_str = " + cmb_o_id_str);

            dataGridViewSyubetsu.Columns[0].HeaderText = "ID";
            dataGridViewSyubetsu.Columns[1].HeaderText = "種別";
            dataGridViewSyubetsu.Columns[2].HeaderText = "施設名";

            da.SelectCommand = new NpgsqlCommand
            (
                   "select"
                + " s_id"
                + ", syubetsu"
                + ", shisetsumei"
                + " from"
                + " t_syubetsu"
                + " where o_id = " + cmb_o_id_str
                + " order by s_id;",
                m_conn
            );

            // insert
            da.InsertCommand = new NpgsqlCommand
            (
                    "insert into t_syubetsu ("
                + " syubetsu"
                + ", shisetsumei"
                + ", s_id"
                + ", o_id"
                + " ) values ("
                + " :syubetsu"
                + ", :shisetsumei"
                + ", :s_id"
                + ", :o_id"
                + ")",
                m_conn
            );
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("syubetsu", NpgsqlTypes.NpgsqlDbType.Text, 0, "syubetsu", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("shisetsumei", NpgsqlTypes.NpgsqlDbType.Text, 0, "shisetsumei", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));

            // update
            da.UpdateCommand = new NpgsqlCommand(
                "update t_syubetsu set"
                + " syubetsu = :syubetsu"
                + ", shisetsumei = :shisetsumei"
                + ", s_id"
                + " where"
                + " o_id = " + cmb_o_id_str
                + " and s_id = :s_id"
                , m_conn
                );
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("syubetsu", NpgsqlTypes.NpgsqlDbType.Text, 0, "syubetsu", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("shisetsumei", NpgsqlTypes.NpgsqlDbType.Text, 0, "shisetsumei", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("ps_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "ps_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

            // delete
            da.DeleteCommand = new NpgsqlCommand
            (
                   "delete from t_syubetsu"
                + " where"
                + " ps_id=:ps_id"
                , m_conn
            );
            da.DeleteCommand.Parameters.Add(new NpgsqlParameter("ps_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "ps_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

            // RowUpdate
            da.RowUpdated += new NpgsqlRowUpdatedEventHandler(syubetsuRowUpdated);

            da.Fill(ds, "syubetsu");

            bindingSourceSyubetsu.DataSource = ds;
            bindingSourceSyubetsu.DataMember = "syubetsu";

            bindingNavigatorSyubetsu.BindingSource = bindingSourceSyubetsu;

            //dataGridViewHoliday.AutoGenerateColumns = false;

            dataGridViewSyubetsu.DataSource = bindingSourceSyubetsu;

            dataGridViewSyubetsu.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            bindingNavigatorSyubetsu.Visible = true;

        }
        private void cmdSyubetsuSave_Click(object sender, EventArgs e)
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

        private void syubetsuRowUpdated(Object sender, NpgsqlRowUpdatedEventArgs e)
        {
            if (e.Status == UpdateStatus.Continue)
            {
                if (e.StatementType == System.Data.StatementType.Insert)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand
                (
                "select"
                + " s_id"
                + ", syubetsu"
                + ", shisetsumei"
                + " from"
                + " t_syubetsu"
                + " where s_id=currval('t_syubetsu_s_id_seq')"
                + " order by s_id;"
                , m_conn
                 );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        e.Row["s_id"] = reader["s_id"];
                        e.Row["syubetsu"] = reader["syubetsu"];
                        e.Row["shisetsumei"] = reader["shisetsumei"];
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
                + " s_id"
                + ", syubetsu"
                + ", shisetsumei"
                + " from"
                + " t_syubetsu"
                + " where s_id=" + e.Row["s_id"].ToString()
                + " order by s_id"
                , m_conn
                    );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        e.Row["s_id"] = reader["s_id"];
                        e.Row["syubetsu"] = reader["syubetsu"];
                        e.Row["shisetsumei"] = reader["shisetsumei"];
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
