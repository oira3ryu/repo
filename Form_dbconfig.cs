using System;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Windows.Forms;
using Npgsql;

namespace rk_seikyu
{
    public partial class Form_dbconfig : Form
    {
        private NpgsqlConnection m_conn = new NpgsqlConnection(rk_seikyu.Properties.Settings.Default.PostgresConnect);

        private NpgsqlDataAdapter da = new NpgsqlDataAdapter();
        private DataSet ds = new DataSet();
        private DataSet Newds = new DataSet();
        private NpgsqlDataAdapter s_id_da = new NpgsqlDataAdapter();

        private DataSet s_id_ds = new DataSet();
        public int Cmb_o_id_int { get; set; }
        private NpgsqlDataAdapter o_id_da = new NpgsqlDataAdapter();
        private Form_seikyu form_seikyu_Instance;
        private string val_d_id;
        private string val_d_name;
        private string val_d_oct1;
        private string val_d_oct2;
        private string val_d_oct3;
        private string val_d_oct4;
        private string val_d_port;
        private string val_d_user;
        private string val_d_pass;
        private string val_d_database_name;
        private string val_d_flg;



        public int I { get; set; }

        public Form_dbconfig()
        {
            InitializeComponent();

            //Form_dbconfigのインスタンスを取得
            form_seikyu_Instance = Form_seikyu.Form_seikyu_Instance;

            this.textBox1.Text = Properties.Settings.Default.TestConnect;
        }

        private void Form_dbconfig_Load(object sender, EventArgs e)
        {
            DataGridViewDbconfig.Columns[0].HeaderText = "ID";
            DataGridViewDbconfig.Columns[1].HeaderText = "接続文字列";
            DataGridViewDbconfig.Columns[2].HeaderText = "第１オクテット";
            DataGridViewDbconfig.Columns[3].HeaderText = "第２オクテット";
            DataGridViewDbconfig.Columns[4].HeaderText = "第３オクテット";
            DataGridViewDbconfig.Columns[5].HeaderText = "第４オクテット";
            DataGridViewDbconfig.Columns[6].HeaderText = "ポート";
            DataGridViewDbconfig.Columns[7].HeaderText = "ユーザー名";
            DataGridViewDbconfig.Columns[8].HeaderText = "パスワード";
            DataGridViewDbconfig.Columns[9].HeaderText = "データベース名";
            DataGridViewDbconfig.Columns[10].HeaderText = "選択";

            da.SelectCommand = new NpgsqlCommand
            (
                   "SELECT"
                + " d_id"
                + ", d_name"
                + ", d_oct1"
                + ", d_oct2"
                + ", d_oct3"
                + ", d_oct4"
                + ", d_port"
                + ", d_user"
                + ", d_pass"
                + ", d_database_name"
                + ", d_flg"
                + " FROM"
                + " t_dbconfig"
                + " ORDER BY d_id;",
                m_conn
                );

            // insert
            da.InsertCommand = new NpgsqlCommand
            (
                    "INSERT INTO t_dbconfig ("
                + " d_id"
                + ", d_name"
                + ", d_oct1"
                + ", d_oct2"
                + ", d_oct3"
                + ", d_oct4"
                + ", d_port"
                + ", d_user"
                + ", d_pass"
                + ", d_database_name"
                + ", d_flg"
                + " ) VALUES ("
                + " :d_id"
                + ", :d_name"
                + ", :d_oct1"
                + ", :d_oct2"
                + ", :d_oct3"
                + ", :d_oct4"
                + ", :d_port"
                + ", :d_user"
                + ", :d_pass"
                + ", :d_database_name"
                + ", :d_flg"
                + ");",
                m_conn
            );
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("d_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "d_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("d_name", NpgsqlTypes.NpgsqlDbType.Text, 0, "d_name", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("d_oct1", NpgsqlTypes.NpgsqlDbType.Text, 0, "d_oct1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("d_oct2", NpgsqlTypes.NpgsqlDbType.Text, 0, "d_oct2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("d_oct3", NpgsqlTypes.NpgsqlDbType.Text, 0, "d_oct3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("d_oct4", NpgsqlTypes.NpgsqlDbType.Text, 0, "d_oct4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("d_port", NpgsqlTypes.NpgsqlDbType.Text, 0, "d_port", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("d_user", NpgsqlTypes.NpgsqlDbType.Text, 0, "d_user", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("d_pass", NpgsqlTypes.NpgsqlDbType.Text, 0, "d_pass", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("d_database_name", NpgsqlTypes.NpgsqlDbType.Text, 0, "d_database_name", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("d_flg", NpgsqlTypes.NpgsqlDbType.Boolean, 0, "d_flg", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            m_conn.Close();


            // update
            da.UpdateCommand = new NpgsqlCommand(
                "UPDATE t_dbconfig SET"
                + " d_id = :d_id"
                + ", d_name = :d_name"
                + ", d_oct1 = :d_oct1"
                + ", d_oct2 = :d_oct2"
                + ", d_oct3 = :d_oct3"
                + ", d_oct4 = :d_oct4"                
                + ", d_port = :d_port"
                + ", d_user = :d_user"
                + ", d_pass = :d_pass"
                + ", d_database_name = :d_database_name"
                + ", d_flg = :d_flg"
                + " WHERE"
                + " d_id = :d_id"
                , m_conn
                );
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("d_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "d_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("d_name", NpgsqlTypes.NpgsqlDbType.Text, 0, "d_name", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("d_oct1", NpgsqlTypes.NpgsqlDbType.Text, 0, "d_oct1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("d_oct2", NpgsqlTypes.NpgsqlDbType.Text, 0, "d_oct2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("d_oct3", NpgsqlTypes.NpgsqlDbType.Text, 0, "d_oct3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("d_oct4", NpgsqlTypes.NpgsqlDbType.Text, 0, "d_oct4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("d_port", NpgsqlTypes.NpgsqlDbType.Text, 0, "d_port", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("d_user", NpgsqlTypes.NpgsqlDbType.Text, 0, "d_user", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("d_pass", NpgsqlTypes.NpgsqlDbType.Text, 0, "d_pass", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("d_database_name", NpgsqlTypes.NpgsqlDbType.Text, 0, "d_database_name", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("d_flg", NpgsqlTypes.NpgsqlDbType.Boolean, 0, "d_flg", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));

            // delete
            da.DeleteCommand = new NpgsqlCommand
            (
                   "DELETE FROM t_dbconfig"
                + " WHERE"
                + " d_id = :d_id"
                , m_conn
            );
            da.DeleteCommand.Parameters.Add(new NpgsqlParameter("d_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "d_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

            // RowUpdate
            da.RowUpdated += new NpgsqlRowUpdatedEventHandler(DbconfigRowUpdated);

            da.Fill(ds, "dbconfig_ds");

            bindingSourceDbconfig.DataSource = ds;
            bindingSourceDbconfig.DataMember = "dbconfig_ds";
            bindingNavigatorDbconfig.BindingSource = bindingSourceDbconfig;
            DataGridViewDbconfig.DataSource = bindingSourceDbconfig;
            DataGridViewDbconfig.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            bindingNavigatorDbconfig.Visible = true;

            // カラムを関連付け
            d_id.DataPropertyName = "d_id";
            d_name.DataPropertyName = "d_name";
            d_oct1.DataPropertyName = "d_oct1";
            d_oct2.DataPropertyName = "d_oct2";
            d_oct3.DataPropertyName = "d_oct3";
            d_oct4.DataPropertyName = "d_oct4";
            d_port.DataPropertyName = "d_port";
            d_user.DataPropertyName = "d_user";
            d_pass.DataPropertyName = "d_pass";
            d_database_name.DataPropertyName = "d_database_name";
            d_flg.DataPropertyName = "d_flg";

            DataGridViewEvent();
        }

        private void DataGridViewEvent()
        {
            DataGridViewDbconfig.CellMouseMove += new DataGridViewCellMouseEventHandler(DataGridViewDbconfig_CellMouseMove);
            DataGridViewDbconfig.CellPainting += new DataGridViewCellPaintingEventHandler(DataGridViewDbconfig_CellPainting);
        }

        private void CmdDbconfigSave_Click(object sender, EventArgs e)
        {
            int update_count = 0;
            try
            {
                update_count += da.Update(ds.Tables["dbconfig_ds"].Select(null, null, DataViewRowState.Deleted));
                update_count += da.Update(ds.Tables["dbconfig_ds"].Select(null, null, DataViewRowState.ModifiedCurrent));
                update_count += da.Update(ds.Tables["dbconfig_ds"].Select(null, null, DataViewRowState.Added));
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存に失敗しました。\n\n[内容]\n" + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(update_count.ToString() + "件、保存しました。", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DbconfigRowUpdated(Object sender, NpgsqlRowUpdatedEventArgs e)
        {
            if (e.Status == UpdateStatus.Continue)
            {
                if (e.StatementType == System.Data.StatementType.Insert)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand
                (
                "SELECT"
                + " d_id"
                + ", d_name"
                + ", d_oct1"
                + ", d_oct2"
                + ", d_oct3"
                + ", d_oct4"
                + ", d_port"
                + ", d_user"
                + ", d_pass"
                + ", d_database_name"
                + ", d_flg"
                + " FROM"
                + " t_dbconfig"
                + " WHERE d_id=currval('t_dbconfig_d_id_seq')"
                + " ORDER BY d_id;"
                , m_conn
                 );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        e.Row["d_id"] = reader["d_id"];
                        e.Row["d_name"] = reader["d_name"];
                        e.Row["d_oct1"] = reader["d_oct1"];
                        e.Row["d_oct2"] = reader["d_oct2"];
                        e.Row["d_oct3"] = reader["d_oct3"];
                        e.Row["d_oct4"] = reader["d_oct4"];
                        e.Row["d_port"] = reader["d_port"];
                        e.Row["d_user"]= reader["d_user"];
                        e.Row["d_pass"] = reader["d_pass"];
                        e.Row["d_database_name"] = reader["d_database_name"];
                        e.Row["d_flg"] = reader["d_flg"];
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
                + " d_id"
                + ", d_name"
                + ", d_oct1"
                + ", d_oct2"
                + ", d_oct3"
                + ", d_oct4"
                + ", d_port"
                + ", d_user"
                + ", d_pass"
                + ", d_database_name"
                + ", d_flg"
                + " FROM"
                + " t_dbconfig"
                + " WHERE d_id=" + e.Row["d_id"].ToString()
                + " ORDER BY d_id;"
                , m_conn
                    );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        e.Row["d_id"] = reader["d_id"];
                        e.Row["d_name"] = reader["d_name"];
                        e.Row["d_oct1"] = reader["d_oct1"];
                        e.Row["d_oct2"] = reader["d_oct2"];
                        e.Row["d_oct3"] = reader["d_oct3"];
                        e.Row["d_oct4"] = reader["d_oct4"];
                        e.Row["d_port"] = reader["d_port"];
                        e.Row["d_user"] = reader["d_user"];
                        e.Row["d_pass"] = reader["d_pass"];
                        e.Row["d_database_name"] = reader["d_database_name"];
                        e.Row["d_flg"] = reader["d_flg"];
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

        private void Form_dbconfig_FormClosing(object sender, FormClosingEventArgs e)
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

        private void DataGridViewDbconfig_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCellStyle dcs = new DataGridViewCellStyle
            {
                BackColor = Color.Yellow
            };

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

        private void DataGridViewDbconfig_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void DataGridViewDbconfig_CurrentCellDirtyStateChanged(
          object sender, EventArgs e)
        {
            if (DataGridViewDbconfig.IsCurrentCellDirty)
            {
                //コミットする
                DataGridViewDbconfig.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        //CellValueChangedイベントハンドラ
        private void DataGridViewDbconfig_CellValueChanged(
          object sender, DataGridViewCellEventArgs e)
        {
            //チェックボックスの列かどうか調べる
            if (DataGridViewDbconfig.Columns[e.ColumnIndex].ValueType == typeof(bool))
            {
                Console.WriteLine("{0}列目、{1}行目のチェックボックスが{2}に変わりました。",
                  e.ColumnIndex, e.RowIndex + 1,
                  DataGridViewDbconfig[e.ColumnIndex, e.RowIndex].Value);
                // 選択列の場合
                if (bool.Equals(DataGridViewDbconfig[e.ColumnIndex, e.RowIndex].Value, true))
                    {
                    // 他にチェックされている項目がある場合はそのチェックを解除
                    for (int rowIndex = 0; rowIndex < DataGridViewDbconfig.Rows.Count; rowIndex++)
                    {
                        // チェックした行以外
                        if (rowIndex != e.RowIndex)
                            {
                            // チェックを解除
                            DataGridViewDbconfig[e.ColumnIndex, rowIndex].Value = false;
                            // ReadOnlyを解除
                            DataGridViewDbconfig[e.ColumnIndex, rowIndex].ReadOnly = false;
                        }
                        // 今回チェックした場所をReadOnlyに設定
                        DataGridViewDbconfig[e.ColumnIndex, e.RowIndex].ReadOnly = true;

                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                m_conn.Open();

                NpgsqlCommand command = new NpgsqlCommand(
                "SELECT"
                + " d_id"
                + ", d_name"
                + ", d_oct1"
                + ", d_oct2"
                + ", d_oct3"
                + ", d_oct4"
                + ", d_port"
                + ", d_user"
                + ", d_pass"
                + ", d_database_name"
                + ", d_flg"
                + " FROM"
                + " t_dbconfig"
                + " WHERE d_flg = 'TRUE'"
                + " ORDER BY d_id;"
                , m_conn);

                try
                {

                    NpgsqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        for (I = 0; I < dr.FieldCount; I++)
                        {
                            val_d_id = dr[0].ToString();
                            val_d_name = dr[1].ToString();
                            val_d_oct1 = dr[2].ToString();
                            val_d_oct2 = dr[3].ToString();
                            val_d_oct3 = dr[4].ToString();
                            val_d_oct4 = dr[5].ToString();
                            val_d_port = dr[6].ToString();
                            val_d_user = dr[7].ToString();
                            val_d_pass = dr[8].ToString();
                            val_d_database_name = dr[9].ToString();
                            val_d_flg = dr[10].ToString();
                        }
                        Console.WriteLine("val_d_id = " + val_d_id);
                        Console.WriteLine("val_d_name = " + val_d_name);
                        Console.WriteLine("val_d_oct1 = " + val_d_oct1);
                        Console.WriteLine("val_d_oct2 = " + val_d_oct2);
                        Console.WriteLine("val_d_oct3 = " + val_d_oct3);
                        Console.WriteLine("val_d_oct4 = " + val_d_oct4);
                        Console.WriteLine("val_d_port = " + val_d_port);
                        Console.WriteLine("val_d_user = " + val_d_user);
                        Console.WriteLine("val_d_pass = " + val_d_pass);
                        Console.WriteLine("val_d_database_name = " + val_d_database_name);
                        Console.WriteLine("val_d_flg = " + val_d_flg);
                    }
                    dr.Close();
                }
                finally
                {
                    m_conn.Close();
                }

                //書き込み処理
                //var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                //if (connectionStringsSection != null)
                //{
                //    connectionStringsSection.ConnectionStrings[val_d_name].ConnectionString
                //        = "Server = " + val_d_oct1 + "." + val_d_oct2 + "." + val_d_oct3 + "." + val_d_oct4 + "; "
                //        + "Port = " + val_d_port + "; "
                //        + "User Id = " + val_d_user + "; "
                //        + "Password = " + val_d_pass + "; "
                //        + "Database = " + val_d_database_name + ";";
                //    config.Save(ConfigurationSaveMode.Modified, true);
                //}

                Properties.Settings.Default.PostgresConnect =
                    "Server = " + val_d_oct1 + "." + val_d_oct2 + "." + val_d_oct3 + "." + val_d_oct4 + "; "
                    + "Port = " + val_d_port + "; "
                    + "User Id = " + val_d_user + "; "
                    + "Password = " + val_d_pass + "; "
                    + "Database = " + val_d_database_name + ";";
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存に失敗しました。\n\n[内容]\n" + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                MessageBox.Show("保存しました。\n\n[内容]\n", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_conn.Close();
                m_conn.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Properties.Settings.Default.TestConnect = this.textBox1.Text;
            //Properties.Settings.Default.Save();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = Properties.Settings.Default.PostgresConnect;
        }
    }
}