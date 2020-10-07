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
        private NpgsqlDataAdapter cmb_o_id_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter o_id_da = new NpgsqlDataAdapter();

        private DataSet ds = new DataSet();
        private DataSet c19_ds = new DataSet();
        private DataSet c9_ds = new DataSet();
        private DataSet cmb_s_id_ds = new DataSet();

        public int cmb_s_id_int;

        public string cmb_s_id_item;
        public string cmb_s_id_str;
        public string Form_Seikyu_TextBoxS_id;

        private Form_seikyu form_seikyu_Instance;



        public Form_prn1()
        {
            InitializeComponent();

            //Form_seikyuのインスタンスを取得
            //form_seikyu_Instance = Form_seikyu.Form_seikyu_Instance;
            //Form_seikyuのテキストボックス文字列を
            //Form_prnの文字列変数Form_Seikyu_TextBoxO_idへ設定
            //Form_Seikyu_TextBoxO_id = form_seikyu_Instance.TextBoxO_id;
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
                   + " AND a.time_stamp = (SELECT max(time_stamp) FROM t_shiharai_houhou WHERE c4_y = 'R 2' AND c4_m = ' 8' AND s_id = '1' AND o_id = '4')"
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
                   + " AND a.time_stamp = (SELECT max(time_stamp) FROM t_shiharai_houhou WHERE c4_y = 'R 2' AND c4_m = ' 8' AND s_id = '1' AND o_id = '4')"
                   + " ORDER BY r_id;",
                m_conn
                );
            c9_da.Fill(c9_ds, "c9_ds");
            c1_bc.DataSource = c9_ds.Tables[0];
            c1_bc.DisplayMember = "c9";
            c1_bc.ValueMember = "c1_bc";


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
                + ", c1 c1_bc"
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
                + " WHERE c4_y = 'R 2' AND c4_m = ' 8' AND s_id = '1' AND o_id = '4'"
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
            //da.UpdateCommand = new NpgsqlCommand(
            //    "UPDATE t_manager SET"
            //    + " manager = :manager"
            //    + ", start_date = :start_date"
            //    + ", end_date = :end_date"
            //    + ", o_id = :o_id"
            //    + " WHERE"
            //    + " m_id = :m_id"
            //    , m_conn
            //    );
            //da.UpdateCommand.Parameters.Add(new NpgsqlParameter("manager", NpgsqlTypes.NpgsqlDbType.Text, 0, "manager", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            //da.UpdateCommand.Parameters.Add(new NpgsqlParameter("start_date", NpgsqlTypes.NpgsqlDbType.TimestampTz, 0, "start_date", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            //da.UpdateCommand.Parameters.Add(new NpgsqlParameter("end_date", NpgsqlTypes.NpgsqlDbType.TimestampTz, 0, "end_date", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            //da.UpdateCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            //da.UpdateCommand.Parameters.Add(new NpgsqlParameter("m_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "m_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));
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
            c1_bc.DataPropertyName = "c1_bc";
            c11.DataPropertyName = "c11";
            c14.DataPropertyName = "c14";
            c16.DataPropertyName = "c16";
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
    }
}
