using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;


namespace rk_seikyu
{
    public partial class Form_prn1 : Form
    {
        private NpgsqlConnection m_conn = new NpgsqlConnection(rk_seikyu.Properties.Settings.Default.PostgresConnect);

        private NpgsqlDataAdapter da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter c19_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter c9_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter c11_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter c14_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter c16_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter o_name_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter hyoujimei_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter nen_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter tsuki_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter b_code_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter s_id_da = new NpgsqlDataAdapter();

        //private NpgsqlDataAdapter cmb_o_id_da = new NpgsqlDataAdapter();
        //private NpgsqlDataAdapter o_id_da = new NpgsqlDataAdapter();

        private DataSet ds = new DataSet();
        private DataSet c19_ds = new DataSet();
        private DataSet c9_ds = new DataSet();
        //private DataSet c11_ds = new DataSet();
        private DataSet c14_ds = new DataSet();
        private DataSet c16_ds = new DataSet();
        private DataSet o_name_ds = new DataSet();
        private DataSet hyoujimei_ds = new DataSet();
        private DataSet nen_ds = new DataSet();
        private DataSet tsuki_ds = new DataSet();
        private DataSet withdrawalds = new DataSet();
        private DataSet b_codeds = new DataSet();
        private DataSet s_id_ds = new DataSet();
        //private DataSet cmb_s_id_ds = new DataSet();

        //public int cmb_s_id_int;

        //public string cmb_s_id_item;
        //public string cmb_s_id_str;
        public string Form_Seikyu_TextBoxS_id;
        public string Form_Seikyu_TextBoxO_id;
        public string Form_Prn_TextBoxS_id;
        public string Form_Prn_TextBoxO_id;

        private Form_seikyu form_seikyu_Instance;
        private Form_prn form_prn_Instance;



        public Form_prn1()
        {
            InitializeComponent();

            //Form_seikyuのインスタンスを取得
            form_seikyu_Instance = Form_seikyu.Form_seikyu_Instance;
            form_prn_Instance = Form_prn.Form_prn_Instance;
            //Form_seikyuのテキストボックス文字列を
            //Form_prnの文字列変数Form_Seikyu_TextBoxO_idへ設定
            Form_Seikyu_TextBoxO_id = form_seikyu_Instance.TextBoxO_id;
            Form_Prn_TextBoxS_id = form_prn_Instance.TextBoxS_id;

            //cmb_o_id_item = form_seikyu_Instance.TextBoxO_name;
            //Console.WriteLine("cmb_o_idからのメンバーは、" + cmb_o_id_item);

        }

        private void CmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Form_prn1_Load(object sender, EventArgs e)
        {
            nen_da.SelectCommand = new NpgsqlCommand
            (
                   "SELECT"
                + " n_id"
                + ", nen"
                + " FROM"
                + " t_nen"
                + " ORDER BY n_id;",
                m_conn
            );
            if (nen_ds.Tables["nen_ds"] != null)
                nen_ds.Tables["nen_ds"].Clear();
            nen_da.Fill(nen_ds, "nen_ds");

            cmb_nen.DataSource = nen_ds.Tables[0];
            cmb_nen.DisplayMember = "nen";
            cmb_nen.ValueMember = "nen";

            tsuki_da.SelectCommand = new NpgsqlCommand
            (
                   "SELECT"
                + " t_id"
                + ", tsuki"
                + " FROM"
                + " t_tsuki"
                + " ORDER BY t_id;",
                m_conn
            );
            if (tsuki_ds.Tables["tsuki_ds"] != null)
                tsuki_ds.Tables["tsuki_ds"].Clear();
            tsuki_da.Fill(tsuki_ds, "tsuki_ds");

            cmb_tsuki.DataSource = tsuki_ds.Tables[0];
            cmb_tsuki.DisplayMember = "tsuki";
            cmb_tsuki.ValueMember = "tsuki";

            s_id_da.SelectCommand = new NpgsqlCommand
            (
                   "SELECT"
                + " s_id"
                + ", syubetsu"
                + ", shisetsumei"
                + ", o_id"
                + " FROM"
                + " t_syubetsu"
                + " WHERE o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                + " ORDER BY s_id;",
                m_conn
            );
            if (s_id_ds.Tables["s_id_ds"] != null)
                s_id_ds.Tables["s_id_ds"].Clear();
            s_id_da.Fill(s_id_ds, "s_id_ds");

            cmb_s_id.DataSource = s_id_ds.Tables[0];
            cmb_s_id.DisplayMember = "syubetsu";
            cmb_s_id.ValueMember = "s_id";

            // コンボボックスで支払者を表示
            c19_da.SelectCommand = new NpgsqlCommand
            (
                   "SELECT"
                   + " b.c1,CASE WHEN a.c19 = '' THEN a.c6 ELSE a.c19 END c19"
                   + " FROM t_shiharai_houhou a INNER JOIN t_seikyu b"
                   + " ON a.c5 = b.c1"
                   + " WHERE b.c4_y = 'R 2'"
                   + " AND b.c4_m = ' 8'"
                   + " AND b.s_id = '1'"
                   + " AND b.o_id = '4'"
                   + " AND a.time_stamp = (SELECT max(time_stamp) FROM t_shiharai_houhou WHERE c4_y = 'R 2' AND c4_m = ' 8' AND s_id = '1' AND o_id = '" + Form_Seikyu_TextBoxO_id + "')"
                   + " ORDER BY r_id;",
                m_conn
                );
            c19_da.Fill(c19_ds, "c19_ds");
            c1.DataSource = c19_ds.Tables[0];
            c1.DisplayMember = "c19";
            c1.ValueMember = "c1";

            // コンボボックスで銀行ｺｰﾄﾞを表示
            c9_da.SelectCommand = new NpgsqlCommand
            (
                   "SELECT"
                   + " b.c1 c1_bc,CASE WHEN a.c9 = '' THEN '' ELSE a.c9 END c9"
                   + " FROM t_shiharai_houhou a INNER JOIN t_seikyu b"
                   + " ON a.c5 = b.c1"
                   + " WHERE b.c4_y = 'R 2'"
                   + " AND b.c4_m = ' 8'"
                   + " AND b.s_id = '1'"
                   + " AND b.o_id = '4'"
                   + " AND a.time_stamp = (SELECT max(time_stamp) FROM t_shiharai_houhou WHERE c4_y = 'R 2' AND c4_m = ' 8' AND s_id = '1' AND o_id = '" + Form_Seikyu_TextBoxO_id + "')"
                   + " ORDER BY r_id;",
                m_conn
                );
            c9_da.Fill(c9_ds, "c9_ds");
            c1_bc.DataSource = c9_ds.Tables[0];
            c1_bc.DisplayMember = "c9";
            c1_bc.ValueMember = "c1_bc";

            // コンボボックスで銀行名を表示
            c11_da.SelectCommand = new NpgsqlCommand
            (
                   "SELECT"
                   + " b.c1 c1_bn,CASE WHEN a.c11 = '' THEN '' ELSE a.c11 END c11"
                   + " FROM t_shiharai_houhou a INNER JOIN t_seikyu b"
                   + " ON a.c5 = b.c1"
                   + " WHERE b.c4_y = 'R 2'"
                   + " AND b.c4_m = ' 8'"
                   + " AND b.s_id = '1'"
                   + " AND b.o_id = '4'"
                   + " AND a.time_stamp = (SELECT max(time_stamp) FROM t_shiharai_houhou WHERE c4_y = 'R 2' AND c4_m = ' 8' AND s_id = '1' AND o_id = '" + Form_Seikyu_TextBoxO_id + "')"
                   + " ORDER BY r_id;",
                m_conn
                );
            c11_da.Fill(c11_ds, "c11_ds");
            c1_bn.DataSource = c11_ds.Tables[0];
            c1_bn.DisplayMember = "c11";
            c1_bn.ValueMember = "c1_bn";

            // コンボボックスで銀行支店名を表示
            c14_da.SelectCommand = new NpgsqlCommand
            (
                   "SELECT"
                   + " b.c1 c1_brn,CASE WHEN a.c14 = '' THEN '' ELSE a.c14 END c14"
                   + " FROM t_shiharai_houhou a INNER JOIN t_seikyu b"
                   + " ON a.c5 = b.c1"
                   + " WHERE b.c4_y = 'R 2'"
                   + " AND b.c4_m = ' 8'"
                   + " AND b.s_id = '1'"
                   + " AND b.o_id = '4'"
                   + " AND a.time_stamp = (SELECT max(time_stamp) FROM t_shiharai_houhou WHERE c4_y = 'R 2' AND c4_m = ' 8' AND s_id = '1' AND o_id = '" + Form_Seikyu_TextBoxO_id + "')"
                   + " ORDER BY r_id;",
                m_conn
                );
            c14_da.Fill(c14_ds, "c14_ds");
            c1_brn.DataSource = c14_ds.Tables[0];
            c1_brn.DisplayMember = "c14";
            c1_brn.ValueMember = "c1_brn";

            // コンボボックスで口座番号を表示
            c16_da.SelectCommand = new NpgsqlCommand
            (
                   "SELECT"
                   + " b.c1 c1_acn,CASE WHEN a.c16 = '' THEN '' ELSE a.c16 END c16"
                   + " FROM t_shiharai_houhou a INNER JOIN t_seikyu b"
                   + " ON a.c5 = b.c1"
                   + " WHERE b.c4_y = 'R 2'"
                   + " AND b.c4_m = ' 8'"
                   + " AND b.s_id = '1'"
                   + " AND b.o_id = '4'"
                   + " AND a.time_stamp = (SELECT max(time_stamp) FROM t_shiharai_houhou WHERE c4_y = 'R 2' AND c4_m = ' 8' AND s_id = '1' AND o_id = '" + Form_Seikyu_TextBoxO_id + "')"
                   + " ORDER BY r_id;",
                m_conn
                );
            c16_da.Fill(c16_ds, "c16_ds");
            c1_acn.DataSource = c16_ds.Tables[0];
            c1_acn.DisplayMember = "c16";
            c1_acn.ValueMember = "c1_acn";

            // コンボボックスで種別を表示
            hyoujimei_da.SelectCommand = new NpgsqlCommand
            (
                   "SELECT hyoujimei, b.s_id FROM t_seikyu b INNER JOIN t_syubetsu a"
                    + " ON b.o_id = a.o_id AND b.s_id = a.s_id"
                    + " WHERE NOT EXISTS("
                    + " SELECT 1"
                    + " FROM t_seikyu AS s"
                    + " WHERE b.o_id = s.o_id"
                    + " AND b.time_stamp < s.time_stamp);",
                m_conn
                );
            hyoujimei_da.Fill(hyoujimei_ds, "hyoujimei_ds");
            s_id.DataSource = hyoujimei_ds.Tables[0];
            s_id.DisplayMember = "hyoujimei";
            s_id.ValueMember = "s_id";


            // コンボボックスで事業所名を表示
            o_name_da.SelectCommand = new NpgsqlCommand
            (
                   "SELECT"
                   + " o_name, b.o_id"
                   + " FROM t_office a INNER JOIN t_seikyu b"
                   + " ON a.o_id::Text = b.o_id"
                   + " WHERE NOT EXISTS ("
                   + " SELECT 1"
                   + " FROM t_seikyu AS s"
                   + " WHERE b.o_id = s.o_id"
                   + " AND b.time_stamp < s.time_stamp)"
                   + " ORDER BY r_id;",
                m_conn
                );
            o_name_da.Fill(o_name_ds, "o_name_ds");
            o_id.DataSource = o_name_ds.Tables[0];
            o_id.DisplayMember = "o_name";
            o_id.ValueMember = "o_id";


            //cmb_o_id_da.SelectCommand = new NpgsqlCommand
            //(
            //       "SELECT"
            //    + " o_id"
            //    + ", o_number"
            //    + ", o_name"
            //    + ", o_p_code"
            //    + ", o_address"
            //    + ", o_phone_number"
            //    + ", flg"
            //    + " FROM"
            //    + " t_office"
            //    + " ORDER BY o_id;",
            //    m_conn
            //    );

            //if (office_ds.Tables["office_ds"] != null)
            //    office_ds.Tables["office_ds"].Clear();
            //cmb_o_id_da.Fill(office_ds, "office_ds");

            //cmb_o_id.DataSource = office_ds.Tables["office_ds"];
            //cmb_o_id.DisplayMember = "o_name";
            //cmb_o_id.ValueMember = "o_id";
            //cmb_o_id.SelectedIndexChanged += new EventHandler(cmb_o_id_SelectedIndexChanged);

            dataGridViewAbd.Columns[0].HeaderText = "□";
            dataGridViewAbd.Columns[1].HeaderText = "氏名";
            dataGridViewAbd.Columns[2].HeaderText = "支払者";
            dataGridViewAbd.Columns[3].HeaderText = "年月";
            dataGridViewAbd.Columns[4].HeaderText = "銀行ｺｰﾄﾞ";
            dataGridViewAbd.Columns[5].HeaderText = "金融機関名";
            dataGridViewAbd.Columns[6].HeaderText = "支店名";
            dataGridViewAbd.Columns[7].HeaderText = "口座番号";
            dataGridViewAbd.Columns[8].HeaderText = "請求額";
            dataGridViewAbd.Columns[9].HeaderText = "種別";
            dataGridViewAbd.Columns[10].HeaderText = "番号";
            //dataGridViewAbd.Columns[11].HeaderText = "引落日ﾞ";

            da.SelectCommand = new NpgsqlCommand
            (
                   "SELECT"
                + " w_flg"
                + ", c3"
                + ", c1"
                + ", concat_ws('/',c4_y,c4_m) c4_ym"
                + ", c9"
                + ", c1 c1_bc"
                + ", c11"
                + ", c1 c1_bn"
                + ", c14"
                + ", c1 c1_brn"
                + ", c16"
                + ", c1 c1_acn"
                + ", c22"
                + ", s_id"
                + ", o_id"
                + ", r_id"
                //+ ", last_day"
                + " FROM"
                + " t_seikyu"
                + " WHERE c4_y = 'R 2' AND c4_m = ' 8' AND s_id = '1' AND o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                + " ORDER BY r_id;",
                m_conn
                );

            // insert
            //da.InsertCommand = new NpgsqlCommand
            //(
            //        "INSERT INTO t_manager ("
            //    + " manager"
            //    + ", start_date"
            //    + ", end_date"
            //    + ", o_id"
            //    + " ) VALUES ("
            //    + " :manager"
            //    + ", :start_date"
            //    + ", :end_date"
            //    + ", :o_id"
            //    + ");",
            //    m_conn
            //);
            //da.InsertCommand.Parameters.Add(new NpgsqlParameter("manager", NpgsqlTypes.NpgsqlDbType.Text, 0, "manager", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            //da.InsertCommand.Parameters.Add(new NpgsqlParameter("start_date", NpgsqlTypes.NpgsqlDbType.TimestampTz, 0, "start_date", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            //da.InsertCommand.Parameters.Add(new NpgsqlParameter("end_date", NpgsqlTypes.NpgsqlDbType.TimestampTz, 0, "end_date", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            //da.InsertCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            //m_conn.Close();


            // update
            da.UpdateCommand = new NpgsqlCommand(
                "UPDATE t_seikyu SET"
                + " w_flg = :w_flg"
                + " WHERE"
                + " r_id = :r_id"
                , m_conn
                );

            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("w_flg", NpgsqlTypes.NpgsqlDbType.Integer, 0, "w_flg", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("r_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "r_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));
            // delete
            //da.DeleteCommand = new NpgsqlCommand
            //(
            //       "DELETE FROM t_manager"
            //    + " WHERE"
            //    + " m_id=:m_id"
            //    , m_conn
            //);
            //da.DeleteCommand.Parameters.Add(new NpgsqlParameter("m_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "m_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

            // RowUpdate
            da.RowUpdated += new NpgsqlRowUpdatedEventHandler(AbdRowUpdated);

            if (ds.Tables["abd_ds"] != null)
                ds.Tables["abd_ds"].Clear();
            da.Fill(ds, "abd_ds");

            bindingSourceAbd.DataSource = ds;
            bindingSourceAbd.DataMember = "abd_ds";
            bindingNavigatorAbd.BindingSource = bindingSourceAbd;
            dataGridViewAbd.DataSource = bindingSourceAbd;
            dataGridViewAbd.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            bindingNavigatorAbd.Visible = true;

            // カラムを関連付け
            w_flg.DataPropertyName = "w_flg";
            c3.DataPropertyName = "c3";
            c1.DataPropertyName = "c1";
            c4_ym.DataPropertyName = "c4_ym";
            //c9.DataPropertyName = "c9";
            c1_bc.DataPropertyName = "c1_bc";
            //c11.DataPropertyName = "c11";
            c1_bn.DataPropertyName = "c1_bn";
            //c14.DataPropertyName = "c14";
            c1_brn.DataPropertyName = "c1_brn";
            //c16.DataPropertyName = "c16";
            c1_acn.DataPropertyName = "c1_acn";
            c22.DataPropertyName = "c22";
            s_id.DataPropertyName = "s_id";
            r_id.DataPropertyName = "r_id";
            //last_day.DataPropertyName = "last_day";

            DataGridViewEvent();
        }

        private void DataGridViewEvent()
        {
            dataGridViewAbd.CellMouseMove += new DataGridViewCellMouseEventHandler(DataGridViewAbd_CellMouseMove);
            dataGridViewAbd.CellPainting += new DataGridViewCellPaintingEventHandler(DataGridViewAbd_CellPainting);
        }

        private void AbdRowUpdated(Object sender, NpgsqlRowUpdatedEventArgs e)
        {
            if (e.Status == UpdateStatus.Continue)
            {
                if (e.StatementType == System.Data.StatementType.Insert)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand
                (
                "SELECT"
                + " w_flg"
                + ", c3"
                + ", c1"
                + ", concat_ws('/',c4_y,c4_m) c4_ym"
                + ", c9"
                + ", c11"
                + ", c14"
                + ", c16"
                + ", c22"
                + ", s_id"
                + ", o_id"
                + ", r_id"
                //+ ", last_day"
                + " FROM"
                + " t_seikyu"
                + " WHERE r_id=currval('t_seikyu_r_id_seq')"
                + " ORDER BY r_id;"
                , m_conn
                 );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        e.Row["w_flg"] = reader["w_flg"];
                        e.Row["c3"] = reader["c3"];
                        e.Row["c1"] = reader["c1"];
                        e.Row["c4_ym"] = reader["c4_ym"];
                        e.Row["c9"] = reader["c9"];
                        e.Row["c11"] = reader["c11"];
                        e.Row["c14"] = reader["c14"];
                        e.Row["c16"] = reader["c16"];
                        e.Row["c22"] = reader["c22"];
                        e.Row["s_id"] = reader["s_id"];
                        e.Row["o_id"] = reader["o_id"];
                        e.Row["r_id"] = reader["r_id"];
                        //e.Row["last_day"] = reader["last_day"];
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
                + " w_flg"
                + ", c3"
                + ", c1"
                + ", concat_ws('/',c4_y,c4_m) c4_ym"
                + ", c9"
                + ", c11"
                + ", c14"
                + ", c16"
                + ", c22"
                + ", s_id"
                + ", o_id"
                + ", r_id"
                //+ ", last_day"
                + " FROM"
                + " t_seikyu"
                + " WHERE r_id=" + e.Row["r_id"].ToString()
                + " ORDER BY r_id;"
                , m_conn
                    );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        e.Row["w_flg"] = reader["w_flg"];
                        e.Row["c3"] = reader["c3"];
                        e.Row["c1"] = reader["c1"];
                        e.Row["c4_ym"] = reader["c4_ym"];
                        e.Row["c9"] = reader["c9"];
                        e.Row["c11"] = reader["c11"];
                        e.Row["c14"] = reader["c14"];
                        e.Row["c16"] = reader["c16"];
                        e.Row["c22"] = reader["c22"];
                        e.Row["s_id"] = reader["s_id"];
                        e.Row["o_id"] = reader["o_id"];
                        e.Row["r_id"] = reader["r_id"];
                        //e.Row["last_day"] = reader["last_day"];
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

        private void Form_prn1_FormClosing(object sender, FormClosingEventArgs e)
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

        private void DataGridViewAbd_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
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

        private void DataGridViewAbd_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void abdBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void CmdClose_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
                int update_count = 0;
                try
                {
                    update_count += da.Update(ds.Tables["abd_ds"].Select(null, null, DataViewRowState.Deleted));
                    update_count += da.Update(ds.Tables["abd_ds"].Select(null, null, DataViewRowState.ModifiedCurrent));
                    update_count += da.Update(ds.Tables["abd_ds"].Select(null, null, DataViewRowState.Added));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("レコードの保存に失敗しました。\n\n[内容]\n" + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show(update_count.ToString() + "件、保存しました。", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
    }
}
