using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace rk_seikyu
{
    public partial class Form_office : Form
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

        public int I { get; set; }

        public Form_office()
        {
            InitializeComponent();

            //Form_seikyuのインスタンスを取得
            form_seikyu_Instance = Form_seikyu.Form_seikyu_Instance;
        }

        private void Form_office_Load(object sender, EventArgs e)
        {
            DataGridViewOffice.Columns[0].HeaderText = "ID";
            DataGridViewOffice.Columns[1].HeaderText = "既定";
            DataGridViewOffice.Columns[2].HeaderText = "事業所番号";
            DataGridViewOffice.Columns[3].HeaderText = "事業所名";
            DataGridViewOffice.Columns[4].HeaderText = "郵便番号";
            DataGridViewOffice.Columns[5].HeaderText = "住所";
            DataGridViewOffice.Columns[6].HeaderText = "電話番号";
            DataGridViewOffice.Columns[7].HeaderText = "管理者";
            DataGridViewOffice.Columns[8].HeaderText = "担当者";

            da.SelectCommand = new NpgsqlCommand
            (
                   "SELECT"
                + " o_id"
                + ", flg"
                + ", o_number"
                + ", o_name"
                + ", o_p_code"
                + ", o_address"
                + ", o_phone_number"
                + ", o_manager"
                + ", o_stuff"
                + " FROM"
                + " t_office"
                + " ORDER BY o_id;",
                m_conn
                );

            // insert
            da.InsertCommand = new NpgsqlCommand
            (
                    "INSERT INTO t_office ("
                + " o_id"
                + ", flg"
                + ", o_number"
                + ", o_name"
                + ", o_p_code"
                + ", o_address"
                + ", o_phone_number"
                + ", o_manager"
                + ", o_stuff"
                + " ) VALUES ("
                + " :o_id"
                + ", :flg"
                + ", :o_number"
                + ", :o_name"
                + ", :o_p_code"
                + ", :o_address"
                + ", :o_phone_number"
                + ", :o_manager"
                + ", :o_stuff"
                + ");",
                m_conn
            );
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("flg", NpgsqlTypes.NpgsqlDbType.Boolean, 0, "flg", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("o_number", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_number", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("o_name", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_name", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("o_p_code", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_p_code", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("o_address", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_address", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("o_phone_number", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_phone_number", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("o_manager", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_manager", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("o_stuff", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_stuff", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            m_conn.Close();


            // update
            da.UpdateCommand = new NpgsqlCommand(
                "UPDATE t_office SET"
                + " o_id = :o_id"
                + ", flg = :flg"
                + ", o_number = :o_number"
                + ", o_name = :o_name"
                + ", o_p_code = :o_p_code"
                + ", o_address = :o_address"
                + ", o_phone_number = :o_phone_number"
                + ", o_manager = :o_manager"
                + ", o_stuff = :o_stuff"
                + " WHERE"
                + " o_id = :o_id"
                , m_conn
                );
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("flg", NpgsqlTypes.NpgsqlDbType.Boolean, 0, "flg", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("o_number", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_number", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("o_name", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_name", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("o_p_code", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_p_code", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("o_address", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_address", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("o_phone_number", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_phone_number", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("o_manager", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_manager", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("o_stuff", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_stuff", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));
            // delete
            da.DeleteCommand = new NpgsqlCommand
            (
                   "DELETE FROM t_office"
                + " WHERE"
                + " o_id = :o_id"
                , m_conn
            );
            da.DeleteCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

            // RowUpdate
            da.RowUpdated += new NpgsqlRowUpdatedEventHandler(OfficeRowUpdated);

            da.Fill(ds, "o_id_ds");

            bindingSourceOffice.DataSource = ds;
            bindingSourceOffice.DataMember = "o_id_ds";
            bindingNavigatorOffice.BindingSource = bindingSourceOffice;
            DataGridViewOffice.DataSource = bindingSourceOffice;
            DataGridViewOffice.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            bindingNavigatorOffice.Visible = true;

            // カラムを関連付け
            o_id.DataPropertyName = "o_id";
            flg.DataPropertyName = "flg";
            o_number.DataPropertyName = "o_number";
            o_name.DataPropertyName = "o_name";
            o_p_code.DataPropertyName = "o_p_code";
            o_address.DataPropertyName = "o_address";
            o_phone_number.DataPropertyName = "o_phone_number";
            o_manager.DataPropertyName = "o_manager";
            o_stuff.DataPropertyName = "o_stuff";

            DataGridViewEvent();
        }

        private void DataGridViewEvent()
        {
            DataGridViewOffice.CellMouseMove += new DataGridViewCellMouseEventHandler(DataGridViewOffice_CellMouseMove);
            DataGridViewOffice.CellPainting += new DataGridViewCellPaintingEventHandler(DataGridViewOffice_CellPainting);
        }

        private void CmdOfficeSave_Click(object sender, EventArgs e)
        {
            int update_count = 0;
            try
            {
                update_count += da.Update(ds.Tables["o_id_ds"].Select(null, null, DataViewRowState.Deleted));
                update_count += da.Update(ds.Tables["o_id_ds"].Select(null, null, DataViewRowState.ModifiedCurrent));
                update_count += da.Update(ds.Tables["o_id_ds"].Select(null, null, DataViewRowState.Added));

                m_conn.Open();
                using (var tran = m_conn.BeginTransaction())
                {
                    //データ登録
                    //var cmd = new NpgsqlCommand(@"insert into t_settings (id, o_id_val) values (:id, '" + Cmb_o_id_int.ToString() + "')", m_conn);
                    var cmd = new NpgsqlCommand(@"UPDATE t_settings SET o_id_val = '" + Cmb_o_id_int.ToString() + "' WHERE sid = 1;", m_conn);
                    //cmd.Parameters.Add(new NpgsqlParameter("id", DbType.Int32) { Value = 1 });
                    //cmd.Parameters.Add(new NpgsqlParameter("o_id_val", DbType.String) { Value = "1" });
                    cmd.ExecuteNonQuery();
                    //データ検索
                    var dataAdapter = new NpgsqlDataAdapter(@"SELECT * FROM t_settings", m_conn);
                    var dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);

                    DataTable dt = dataSet.Tables[0];
                    Console.WriteLine("コミット前データ件数：{0}", dt.Rows.Count);

                    // コミットして、再検索
                    tran.Commit();

                    dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);

                    dt = dataSet.Tables[0];
                    Console.WriteLine("コミット後データ件数：{0}", dt.Rows.Count);
                }
                m_conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存に失敗しました。\n\n[内容]\n" + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(update_count.ToString() + "件、保存しました。", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OfficeRowUpdated(Object sender, NpgsqlRowUpdatedEventArgs e)
        {
            if (e.Status == UpdateStatus.Continue)
            {
                if (e.StatementType == System.Data.StatementType.Insert)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand
                (
                "SELECT"
                + " o_id"
                + ", flg"
                + ", o_number"
                + ", o_name"
                + ", o_p_code"
                + ", o_address"
                + ", o_phone_number"
                + ", o_manager"
                + ", o_stuff"
                + " FROM"
                + " t_Office"
                + " WHERE o_id=currval('t_office_o_id_seq')"
                + " ORDER BY o_id;"
                , m_conn
                 );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        e.Row["o_id"] = reader["o_id"];
                        e.Row["flg"] = reader["flg"];
                        e.Row["o_name"] = reader["o_name"];
                        e.Row["o_number"] = reader["o_number"];
                        e.Row["o_p_code"] = reader["o_p_code"];
                        e.Row["o_address"] = reader["o_address"];
                        e.Row["o_phone_number"] = reader["o_phone_number"];
                        e.Row["o_manager"] = reader["o_manager"];
                        e.Row["o_stuff"] = reader["o_stuff"];
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
                + " o_id"
                + ", flg"
                + ", o_number"
                + ", o_name"
                + ", o_p_code"
                + ", o_address"
                + ", o_phone_number"
                + ", o_manager"
                + ", o_stuff"
                + " FROM"
                + " t_Office"
                + " WHERE o_id=" + e.Row["o_id"].ToString()
                + " ORDER BY o_id;"
                , m_conn
                    );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        e.Row["o_id"] = reader["o_id"];
                        e.Row["flg"] = reader["flg"];
                        e.Row["o_name"] = reader["o_name"];
                        e.Row["o_number"] = reader["o_number"];
                        e.Row["o_p_code"] = reader["o_p_code"];
                        e.Row["o_address"] = reader["o_address"];
                        e.Row["o_phone_number"] = reader["o_phone_number"];
                        e.Row["o_manager"] = reader["o_manager"];
                        e.Row["o_stuff"] = reader["o_stuff"];
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

            m_conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT o_id, o_name FROM t_office WHERE flg = '1';", m_conn);

            try
            {
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    for (I = 0; I < dr.FieldCount; I++)
                    {
                        form_seikyu_Instance.TextBoxO_id = dr[0].ToString();
                        form_seikyu_Instance.TextBoxO_name = dr[1].ToString();
                    }
                    Console.WriteLine();
                }

            }

            finally
            {
                m_conn.Close();
            }
        }

        private void Form_office_FormClosing(object sender, FormClosingEventArgs e)
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

        private void DataGridViewOffice_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
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

        private void DataGridViewOffice_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void DataGridViewOffice_CurrentCellDirtyStateChanged(
          object sender, EventArgs e)
        {
            if (DataGridViewOffice.IsCurrentCellDirty)
            {
                //コミットする
                DataGridViewOffice.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        //CellValueChangedイベントハンドラ
        private void DataGridViewOffice_CellValueChanged(
          object sender, DataGridViewCellEventArgs e)
        {
            //チェックボックスの列かどうか調べる
            if (DataGridViewOffice.Columns[e.ColumnIndex].ValueType == typeof(bool))
            {
                Console.WriteLine("{0}列目、{1}行目のチェックボックスが{2}に変わりました。",
                  e.ColumnIndex, e.RowIndex + 1,
                  DataGridViewOffice[e.ColumnIndex, e.RowIndex].Value);
                // 選択列の場合
                if (bool.Equals(DataGridViewOffice[e.ColumnIndex, e.RowIndex].Value, true))
                    {
                    // 他にチェックされている項目がある場合はそのチェックを解除
                    for (int rowIndex = 0; rowIndex < DataGridViewOffice.Rows.Count; rowIndex++)
                    {
                        // チェックした行以外
                        if (rowIndex != e.RowIndex)
                            {
                            // チェックを解除
                            DataGridViewOffice[e.ColumnIndex, rowIndex].Value = false;
                            // ReadOnlyを解除
                            DataGridViewOffice[e.ColumnIndex, rowIndex].ReadOnly = false;
                        }
                        // 今回チェックした場所をReadOnlyに設定
                        DataGridViewOffice[e.ColumnIndex, e.RowIndex].ReadOnly = true;

                    }
                }
            }
        }
    }
}
