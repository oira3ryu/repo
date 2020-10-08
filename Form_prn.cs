using Npgsql;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace rk_seikyu
{
    public partial class Form_prn : Form
    {
        private NpgsqlConnection m_conn = new NpgsqlConnection(rk_seikyu.Properties.Settings.Default.PostgresConnect);

        private NpgsqlDataAdapter da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter n_id_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter t_id_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter s_id_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter p_id_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter prn_id_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter req_id_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter c4_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter nen_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter tsuki_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter b_code_da = new NpgsqlDataAdapter();

        private DataSet ds = new DataSet();
        private DataSet Newds = new DataSet();
        private DataSet n_id_ds = new DataSet();
        private DataSet t_id_ds = new DataSet();
        private DataSet s_id_ds = new DataSet();
        private DataSet p_id_ds = new DataSet();
        private DataSet prn_id_ds = new DataSet();
        private DataSet req_id_ds = new DataSet();
        private DataSet Cntds = new DataSet();
        private DataSet c4_ds = new DataSet();
        private DataSet nends = new DataSet();
        private DataSet tsukids = new DataSet();
        private DataSet withdrawalds = new DataSet();
        private DataSet b_codeds = new DataSet();

        public int Cmb_n_id_int { get; set; }
        public int Cmb_t_id_int { get; set; }
        public int Cmb_p_id_int { get; set; }
        public int Cmb_prn_id_int { get; set; }
        public int Cmb_req_id_int { get; set; }
        public int Cmb_s_id_int { get; set; }
        public int _year { get; set; }
        public int _month { get; set; }
        public int _day { get; set; }
        public int rec { get; set; }

        public object Cmb_n_id_str { get; set; }
        public object Cmb_t_id_str { get; set; }
        public string Cmb_s_id_str { get; set; }
        public string Cmb_req_id_str { get; set; }
        public string Cmb_c4_str { get; set; }
        public string Cmb_nen_str { get; set; }
        public string Cmb_tsuki_str { get; set; }
        public string Cmb_b_code_str { get; set; }
        public int Cmb_o_id_int { get; set; }
        public string StrDateTime { get; set; }

        public string cmb_o_id_str;
        public string cmb_o_id_item;
        public string Form_Seikyu_TextBoxO_id;

        private Form_seikyu form_seikyu_Instance;

        public Form_prn()
        {
            InitializeComponent();

            //Form_seikyuのインスタンスを取得
            form_seikyu_Instance = Form_seikyu.Form_seikyu_Instance;
            //Form_seikyuのテキストボックス文字列を
            //Form_prnの文字列変数Form_Seikyu_TextBoxO_idへ設定
            Form_Seikyu_TextBoxO_id = form_seikyu_Instance.TextBoxO_id;
            cmb_o_id_item = form_seikyu_Instance.TextBoxO_name;
            Console.WriteLine("cmb_o_idからのメンバーは、" + cmb_o_id_item);
        }

        private void CmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormPrn_Load(object sender, EventArgs e)
        {
            Chk_title_str = '0';
            this.Width = Screen.GetBounds(this).Width;
            this.Height = Screen.GetBounds(this).Height - 30;
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;

            Console.WriteLine("Form_Seikyu_TextBoxO_id = " + Form_Seikyu_TextBoxO_id);

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

            da.SelectCommand = new NpgsqlCommand
            (
                "SELECT"
                + " r_id"
                + ", c1"
                + ", c2"
                + ", c3"
                + ", c4"
                + ", c5"
                + ", c6"
                + ", c7"
                + ", c8"
                + ", c9"
                + ", c10"
                + ", c11"
                + ", c12"
                + ", c13"
                + ", c14"
                + ", c15"
                + ", c16"
                + ", c17"
                + ", c18"
                + ", c19"
                + ", c20"
                + ", c21"
                + ", c22"
                + ", c4_y"
                + ", c4_m"
                + " FROM t_seikyu"
                + " ORDER BY r_id;"
                , m_conn
            );

            prn_id_da.SelectCommand = new NpgsqlCommand
            (
                   "SELECT"
                + " ps_id"
                + ", syubetsu"
                + " FROM"
                + " t_prn_syubetsu"
                + " ORDER BY ps_id;",
                m_conn
            );

            c4_da.SelectCommand = new NpgsqlCommand
            (
                   "SELECT"
                + " distinct"
                + " c4"
                + " FROM"
                + " t_seikyu"
                + " ORDER BY c4;",
                m_conn
            );

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

            req_id_da.SelectCommand = new NpgsqlCommand
            (
                   "SELECT"
                + " req_id"
                + ", title1"
                + ", title2"
                + ", title3"
                + ", title4"
                + " FROM"
                + " t_req"
                + " ORDER BY req_id;",
                m_conn
            );

            b_code_da.SelectCommand = new NpgsqlCommand
            (
                "SELECT"
                + " b_code"
                + ", b_name"
                + ", b_id"
                + " FROM"
                + " t_bank"
                + " ORDER BY b_id;",
                m_conn
            );

            if (nends.Tables["t_nen"] != null)
                nends.Tables["t_nen"].Clear();
            nen_da.Fill(nends, "t_nen");

            if (tsukids.Tables["t_tsuki"] != null)
                tsukids.Tables["t_tsuki"].Clear();
            tsuki_da.Fill(tsukids, "t_tsuki");

            if (prn_id_ds.Tables["t_prn_syubetsu"] != null)
                prn_id_ds.Tables["t_prn_syubetsu"].Clear();
            prn_id_da.Fill(prn_id_ds, "t_prn_syubetsu");

            if (c4_ds.Tables["c4"] != null)
                c4_ds.Tables["c4"].Clear();
            c4_da.Fill(c4_ds, "c4");

            if (s_id_ds.Tables["t_syubetsu"] != null)
                s_id_ds.Tables["t_syubetsu"].Clear();
            s_id_da.Fill(s_id_ds, "t_syubetsu");

            if (req_id_ds.Tables["t_req"] != null)
                req_id_ds.Tables["t_req"].Clear();
            req_id_da.Fill(req_id_ds, "t_req");

            if (b_codeds.Tables["t_bank"] != null)
                b_codeds.Tables["t_bank"].Clear();
            b_code_da.Fill(b_codeds, "t_bank");

            cmb_nen.DataSource = nends.Tables[0];
            cmb_nen.DisplayMember = "nen";
            cmb_nen.ValueMember = "nen";

            cmb_tsuki.DataSource = tsukids.Tables[0];
            cmb_tsuki.DisplayMember = "tsuki";
            cmb_tsuki.ValueMember = "tsuki";

            cmb_prn_id.DataSource = prn_id_ds.Tables["t_prn_syubetsu"];
            cmb_prn_id.DisplayMember = "syubetsu";
            cmb_prn_id.ValueMember = "ps_id";
            this.cmb_prn_id.SelectedIndex = 0;
            cmb_prn_id.SelectedIndexChanged += new EventHandler(Cmb_prn_id_SelectedIndexChanged);

            cmb_c4.DataSource = c4_ds.Tables["c4"];
            cmb_c4.DisplayMember = "c4";
            cmb_c4.ValueMember = "c4";
            this.cmb_c4.SelectedIndex = 0;
            cmb_c4.SelectedIndexChanged += new EventHandler(Cmb_c4_SelectedIndexChanged);

            cmb_s_id.DataSource = s_id_ds.Tables["t_syubetsu"];
            cmb_s_id.DisplayMember = "syubetsu";
            cmb_s_id.ValueMember = "s_id";
            this.cmb_s_id.SelectedIndex = 0;
            cmb_s_id.SelectedIndexChanged += new EventHandler(Cmb_s_id_SelectedIndexChanged);

            cmb_req_id.DataSource = req_id_ds.Tables["t_req"];
            cmb_req_id.DisplayMember = "name1";
            cmb_req_id.ValueMember = "req_id";
            cmb_req_id.SelectedIndexChanged += new EventHandler(Cmb_req_id_SelectedIndexChanged);

            cmb_b_code.DataSource = b_codeds.Tables["t_bank"];
            cmb_b_code.DisplayMember = "b_name";
            cmb_b_code.ValueMember = "b_code";
            cmb_b_code.SelectedIndexChanged += new EventHandler(Cmb_b_code_SelectedIndexChanged);

            double val = 1.5;
            double ret1 = Math.Floor(val);
            double ret2 = Math.Truncate(val);

            if (ds.Tables["seikyu"] != null)
                ds.Tables["seikyu"].Clear();
            da.Fill(ds, "seikyu");

            bindingNavigatorWithdrawal.Visible = false;
            dataGridViewWithdrawal.Visible = false;

            DataGridViewEvent();

        }

        private void DataGridViewEvent()
        {
            dataGridViewWithdrawal.CellMouseMove += new DataGridViewCellMouseEventHandler(DataGridViewWithdrawal_CellMouseMove);
            dataGridViewWithdrawal.CellPainting += new DataGridViewCellPaintingEventHandler(DataGridViewWithdrawal_CellPainting);
            dataGridViewWithdrawal.CellValueChanged += new DataGridViewCellEventHandler(DataGridViewWithdrawal_CellValueChanged);
        }

        private void Cmb_req_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmb_req_id_int = cmb_req_id.SelectedIndex + 1;
            Console.WriteLine("cmb_req_id_int1 = " + Cmb_req_id_int);
            Cmb_req_id_str = cmb_req_id.Text;
            Console.WriteLine("cmb_req_id_str1 = " + Cmb_req_id_str);
        }

        private void Cmb_p_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmb_p_id_int = cmb_p_id.SelectedIndex + 1;
            Console.WriteLine("cmb_p_id_int1 = " + Cmb_p_id_int);
        }

        private void Cmb_s_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmb_s_id_int = cmb_s_id.SelectedIndex + 1;
            Console.WriteLine("cmb_s_id_int1 = " + Cmb_s_id_int);
            Cmb_s_id_str = cmb_s_id.Text;
            Console.WriteLine("cmb_s_id_str1 = " + Cmb_s_id_str);
        }

        private void Cmb_c4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmb_c4_str = cmb_c4.Text;
            Console.WriteLine("cmb_c4_str1 = " + Cmb_c4_str);
        }

        private void CmdPrv_Click(object sender, EventArgs e)
        {
            StrDateTime = dateTimePicker1.Value.ToShortDateString();
            Console.WriteLine("StrDateTime = " + StrDateTime);
            DateTime dt = DateTime.Parse(StrDateTime);
            _year = dt.Year;
            Console.WriteLine("year = " + _year);
            _month = dt.Month;
            Console.WriteLine("month = " + _month);
            _day = dt.Day;
            Console.WriteLine("day = " + _day);
            try
            {
                m_conn.Open();

                DataSet ds = new DataSet();
                DataSet Newds = new DataSet();

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(
                    "SELECT * FROM t_syutsuryokubi"
                    + " WHERE s_id::Integer = " + Cmb_s_id_int.ToString(), m_conn);

                NpgsqlCommand command = new NpgsqlCommand(
                    "SELECT"
                    + " count(*)"
                    + " FROM"
                    + " t_syutsuryokubi"
                    + " WHERE s_id::Integer = " + Cmb_s_id_int.ToString()
                    , m_conn);

                object o = command.ExecuteScalar();
                int rcnt;
                if (o is IConvertible)
                {
                    rcnt = ((IConvertible)o).ToInt32(null);
                    Console.WriteLine("rcnt = " + rcnt);
                    if (rcnt > 0)
                    {
                        command = new NpgsqlCommand(
                        "DELETE"
                        + " FROM t_syutsuryokubi"
                        + " WHERE s_id::Integer = " + Cmb_s_id_int.ToString()
                        , m_conn);
                        command.ExecuteNonQuery();
                    }
                }

                da.InsertCommand = new NpgsqlCommand(
                       "INSERT INTO t_syutsuryokubi ("
                    + "syutsuryokubi"
                    + ", s_nen"
                    + ", s_tsuki"
                    + ", s_hi"
                    + ", s_id"
                    + " ) VALUES ("
                    + " :syutsuryokubi"
                    + ", :s_nen"
                    + ", :s_tsuki"
                    + ", :s_hi"
                    + ", :s_id"
                    + ");"
                    , m_conn);

                da.InsertCommand.Parameters.Add(new NpgsqlParameter("syutsuryokubi", NpgsqlTypes.NpgsqlDbType.Text, 0, "syutsuryokubi", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                da.InsertCommand.Parameters.Add(new NpgsqlParameter("s_nen", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_nen", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                da.InsertCommand.Parameters.Add(new NpgsqlParameter("s_tsuki", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_tsuki", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                da.InsertCommand.Parameters.Add(new NpgsqlParameter("s_hi", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_hi", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                da.InsertCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));

                da.Fill(ds);

                DataTable dt1 = ds.Tables[0];
                DataRow dr = dt1.NewRow();
                dr["syutsuryokubi"] = StrDateTime;
                dr["s_nen"] = _year;
                dr["s_tsuki"] = _month;
                dr["s_hi"] = _day;
                dr["s_id"] = Cmb_s_id_int;

                dt1.Rows.Add(dr);

                DataSet ds2 = ds.GetChanges();

                da.Update(ds2);

                //ds.Merge(ds2);
                ds.AcceptChanges();
            }
            catch
            {
                MessageBox.Show("エラーで終了しました");
            }
            finally
            {
                //MessageBox.Show("更新されました");
                m_conn.Close();
            }

            this.Width = Screen.GetBounds(this).Width;
            this.Height = Screen.GetBounds(this).Height - 30;
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;

            switch (Cmb_prn_id_int)
            {
                case 1: // 納額通知書
                    {
                        da.SelectCommand = new NpgsqlCommand
                        (
                       "WITH RECURSIVE h AS ("
                       + "WITH RECURSIVE r AS ("
                        + "SELECT"
                        + " c1"
                        + ", c2"
                        + ", c3"
                        + ", rtrim(replace(c3,substr(c3,strpos(c3, '('), strpos(c3, ')')),'')) c3_mod"
                        + ", c4"
                        + ", c5"
                        + ", c6"
                        + ", c7"
                        + ", c8"
                        + ", c9"
                        + ", c10"
                        + ", c11"
                        + ", c12"
                        + ", c13"
                        + ", c14"
                        + ", c15"
                        + ", c16"
                        + ", c17"
                        + ", c18"
                        + ", c19"
                        + ", c20"
                        + ", c21"
                        + ", c22"
                        + ", a.s_id"
                        + ", a.o_id"
                        + ", a.p_id"
                        + ", syubetsu"
                        + ", shisetsumei"
                        + ", title"
                        + ", sub_title"
                        + ", content1"
                        + ", content2"
                        + ", content3"
                        + ", a.req_id"
                        + ", title1"
                        + ", title2"
                        + ", chief"
                        + ", accounting_manager"
                        + ", title3"
                        + ", title4"
                        + ", syutsuryokubi"
                        + ", s_nen"
                        + ", s_tsuki"
                        + ", s_hi"
                        + ", srb_id"
                        + ", time_stamp"
                        + ", a.id"
                        + ", a.c4_y"
                        + ", a.c4_m"
                        + ", gengou"
                        + ", g_name"
                        + ", f.start_date"
                        + ", f.end_date"
                        + ", diff"
                        + " FROM"
                                + " ("
                                    + "("
                                        + "("
                                            + "("
                                                + "(t_seikyu a LEFT JOIN t_syubetsu b"
                                                    + " ON a.s_id = b.s_id"
                                                    + " AND a.o_id = b.o_id"
                                                + ")"
                                            + " LEFT JOIN t_par c ON a.p_id::Integer = c.p_id"
                                            + ")"
                                        + " LEFT JOIN t_req d ON a.req_id::Integer = d.req_id"
                                        + ")"
                                    + " LEFT JOIN t_syutsuryokubi e ON a.s_id = e.s_id"
                                    + ")"
                                + " LEFT JOIN t_gengou f ON substr(a.c4_y,1,1) = f.g_name"
                                + ")"
                            + " LEFT JOIN t_chief g ON "
                                        + " g.start_date <= (SELECT to_date((to_number(c4_y,'999')+f.diff || '/' || to_number(c4_m,'99')+1 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                        + " AND (g.end_date Is Null Or g.end_date >= (SELECT to_date((to_number(c4_y,'999')+f.diff || '/' || to_number(c4_m,'99')+1 || '/' || to_number('01','99')),'yyyy/mm/dd')-1) "
                            + ")"
                        + " LEFT JOIN t_accounting_manager h ON "
                                    + " h.start_date <= (SELECT to_date((to_number(c4_y,'999')+f.diff || '/' || to_number(c4_m,'99')+1 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                    + " AND (h.end_date Is Null Or h.end_date >= (SELECT to_date((to_number(c4_y,'999')+f.diff || '/' || to_number(c4_m,'99')+1 || '/' || to_number('01','99')),'yyyy/mm/dd')-1) "
                        + ")"
                        + " ORDER BY id"
                        + ")"
                        + "SELECT"
                        + " r.c1"
                        + ", r.c2"
                        + ", r.c3"
                        + ", r.c3_mod"
                        + ", r.c4"
                        + ", r.c4_y"
                        + ", r.c4_m"
                        + ", first_day(r.c4_y, r.c4_m, r.g_name, r.diff) first_date"
                        + ", cast(CASE WHEN date_part('month', to_date((to_number(r.c4_y,'999')+diff || '/' || r.c4_m || '/' || 1),'yyyy/mm/dd')::timestamp) < 4 THEN"
                        + " to_number(r.c4_y,'999')-1 else to_number(r.c4_y,'999') END AS text) as nendo"
                        + ", to_number(r.c4_y,'999')::Text AS nen"
                        + ", to_number(r.c4_m,'99')::Text AS tsuki"
                        + ", RANK() OVER (PARTITION BY r.c4, r.s_id ORDER BY r.c1)::Text AS noufusyo_bangou"
                        + ", r.c5"
                        + ", r.c6"
                        + ", r.c7"
                        + ", s.c7 s_c7"
                        + ", r.c8"
                        + ", r.c9"
                        + ", s.c9 as s_c9"
                        + ", r.c10"
                        + ", r.c11"
                        + ", r.c12"
                        + ", r.c13"
                        + ", r.c14"
                        + ", r.c15"
                        + ", r.c16"
                        + ", r.c17"
                        + ", s.c17 as s_c17"
                        + ", r.c18"
                        + ", r.c19"
                        + ", s.c19 as s_c19"
                        + ", r.c20"
                        + ", r.c21"
                        + ", r.c22"
                        + ", r.s_id"
                        + ", r.o_id"
                        + ", r.p_id"
                        + ", r.syubetsu"
                        + ", r.shisetsumei"
                        + ", r.title"
                        + ", r.sub_title"
                        + ", r.content1"
                        + ", r.content2"
                        + ", r.content3"
                        + ", r.req_id"
                        + ", r.title1"
                        + ", r.title2"
                        + ", r.chief"
                        + ", r.accounting_manager"
                        + ", r.title3"
                        + ", r.title4"
                        + ", r.syutsuryokubi"
                        + ", r.s_nen"
                        + ", r.s_tsuki"
                        + ", r.s_hi"
                        + ", r.srb_id"
                        + ", r.time_stamp"
                        + ", r.gengou"
                        + ", r.g_name"
                        + ", r.start_date"
                        + ", r.end_date"
                        + ", r.diff"
                        + " FROM r"
                        + " LEFT JOIN (SELECT c4, c5, c6, c7, c9, c11, c14, c15, c16, c17, c19, s_id, o_id"
                            + ", CASE WHEN c7 = '現金' THEN '1'"
                            + " WHEN c7 = '引落' THEN '2'"
                            + " WHEN c7 = '振込' THEN '2'"
                            + " ELSE '' END 支払方法"
                            + ", time_stamp FROM t_shiharai_houhou"
                        + " WHERE time_stamp = (SELECT max(time_stamp) FROM t_shiharai_houhou WHERE"
                            + " c4_y::Text = CASE WHEN length('" + Cmb_nen_str + "')=2 THEN"
                                                    + " substr('" + Cmb_nen_str + "',1,1) || ' ' || substr('" + Cmb_nen_str + "', length('" + Cmb_nen_str + "')-1+1, length('" + Cmb_nen_str + "'))"
                                                + " ELSE"
                                                    + "'" + Cmb_nen_str + "'"
                                                + " END"
                            + " AND c4_m::Text = CASE WHEN length('" + Cmb_tsuki_str + "')=1 THEN"
                                                + " ' ' || '" + Cmb_tsuki_str + "'"
                                                + " WHEN length('" + Cmb_tsuki_str + "')=2 THEN"
                                                + " '' || '" + Cmb_tsuki_str + "'"
                                                + " END"
                            + " AND s_id::Integer = " + Cmb_s_id_int
                            + " AND o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                                            + ")"
                                    + ") s ON r.c1 = s.c5"
                                    + " AND rtrim(replace(r.c3,substr(r.c3,strpos(r.c3, '('), strpos(r.c3, ')')),''))"
                                        + "= rtrim(replace(s.c6,substr(s.c6,strpos(s.c6, '('), strpos(s.c6, ')')),''))"
                                    + " AND r.s_id = s.s_id"
                                    + " AND r.o_id = s.o_id"
                                    + " AND s.s_id::Integer = " + Cmb_s_id_int
                                    + " WHERE"
                                    + " r.s_id::Integer = " + Cmb_s_id_int
                                    + " AND r.o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                                    + " AND r.time_stamp = (SELECT max(time_stamp) FROM t_seikyu WHERE"
                                                            + " s_id::Integer = " + Cmb_s_id_int
                                                            + " AND o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                                                            + " AND c4_y::Text = CASE WHEN length('" + Cmb_nen_str + "')=2 THEN"
                                                                                    + " substr('" + Cmb_nen_str + "',1,1) || ' ' || substr('" + Cmb_nen_str + "', length('" + Cmb_nen_str + "')-1+1, length('" + Cmb_nen_str + "'))"
                                                                                + " ELSE"
                                                                                    + "'" + Cmb_nen_str + "'"
                                                                                + " END"
                                                            + " AND c4_m::Text = CASE WHEN length('" + Cmb_tsuki_str + "')=1 THEN"
                                                                                + " ' ' || '" + Cmb_tsuki_str + "'"
                                                                                + " WHEN length('" + Cmb_tsuki_str + "')=2 THEN"
                                                                                + " '' || '" + Cmb_tsuki_str + "'"
                                                                                + " END"
                                                        + ")"
                            + " AND c4_y::Text = CASE WHEN length('" + Cmb_nen_str + "')=2 THEN"
                                                    + " substr('" + Cmb_nen_str + "',1,1) || ' ' || substr('" + Cmb_nen_str + "', length('" + Cmb_nen_str + "')-1+1, length('" + Cmb_nen_str + "'))"
                                                + " ELSE"
                                                    + "'" + Cmb_nen_str + "'"
                                                + " END"
                            + " AND c4_m::Text = CASE WHEN length('" + Cmb_tsuki_str + "')=1 THEN"
                                                + " ' ' || '" + Cmb_tsuki_str + "'"
                                                + " WHEN length('" + Cmb_tsuki_str + "')=2 THEN"
                                                + " '' || '" + Cmb_tsuki_str + "'"
                                                + " END"
                        + " ORDER BY r.id"
                        + ")"
                        + "SELECT"
                        + " h.c1"
                        + ", h.c2"
                        + ", h.c3"
                        + ", h.c3_mod"
                        + ", h.c4"
                        + ", h.c4_y"
                        + ", h.c4_m"
                        + ", h.first_date"
                        + ", h.nendo"
                        + ", h.nen"
                        + ", h.tsuki"
                        + ", h.noufusyo_bangou"
                        + ", h.c5"
                        + ", h.c6"
                        + ", h.c7"
                        + ", h.s_c7"
                        + ", h.c8"
                        + ", h.c9"
                        + ", h.s_c9"
                        + ", h.c10"
                        + ", h.c11"
                        + ", h.c12"
                        + ", h.c13"
                        + ", h.c14"
                        + ", h.c15"
                        + ", h.c16"
                        + ", h.c17"
                        + ", h.s_c17"
                        + ", h.c18"
                        + ", h.c19"
                        + ", h.s_c19"
                        + ", h.c20"
                        + ", h.c21"
                        + ", h.c22"
                        + ", h.s_id"
                        + ", h.o_id"
                        + ", h.p_id"
                        + ", h.syubetsu"
                        + ", h.shisetsumei"
                        + ", h.title"
                        + ", h.sub_title"
                        + ", h.content1"
                        + ", h.content2"
                        + ", h.content3"
                        + ", h.req_id"
                        + ", h.title1"
                        + ", h.title2"
                        + ", h.chief"
                        + ", h.title3"
                        + ", h.title4"
                        + ", h.accounting_manager"
                        + ", h.syutsuryokubi"
                        + ", h.s_nen"
                        + ", h.s_tsuki"
                        + ", h.s_hi"
                        + ", h.srb_id"
                        + ", h.time_stamp"
                        + ", h.gengou"
                        + ", h.g_name"
                        + ", h.start_date"
                        + ", h.end_date"
                        + ", h.diff"
                        + " FROM h;"
                        , m_conn
                        );

                        if (cmb_c4.SelectedItem == null)
                        {
                            da.SelectCommand.Parameters.Add(new NpgsqlParameter("c4",
                            NpgsqlTypes.NpgsqlDbType.Integer, 0, "c4",
                            ParameterDirection.Input, false, 0, 0, DataRowVersion.Current,
                            DBNull.Value));
                        }
                        else
                        {
                            DataRowView row = (DataRowView)cmb_c4.SelectedItem;
                            da.SelectCommand.Parameters.AddWithValue("c4", row["c4"]);
                        }


                        if (cmb_s_id.SelectedItem == null)
                        {
                            da.SelectCommand.Parameters.Add(new NpgsqlParameter("s_id",
                            NpgsqlTypes.NpgsqlDbType.Integer, 0, "s_id",
                            ParameterDirection.Input, false, 0, 0, DataRowVersion.Current,
                            DBNull.Value));
                        }
                        else
                        {
                            DataRowView row = (DataRowView)cmb_s_id.SelectedItem;
                            da.SelectCommand.Parameters.AddWithValue("s_id", row["s_id"]);
                        }

                        if (ds.Tables["seikyu"] != null)
                            ds.Tables["seikyu"].Clear();
                        da.Fill(ds, "seikyu");

                        crNoufusyo myReport = new crNoufusyo();
                        myReport.SetDataSource(ds);

                        myReport.SetParameterValue("s_id", Cmb_s_id_int.ToString());
                        myReport.SetParameterValue("req_id", Form_Seikyu_TextBoxO_id);

                        crvSeikyu.ReportSource = myReport;

                        bindingNavigatorWithdrawal.Visible = false;
                        dataGridViewWithdrawal.Visible = false;
                        crvSeikyu.Visible = true;
                    }
                    break;

                case 2: // 収入原簿
                    {
                        da.SelectCommand = new NpgsqlCommand
                        (
                        "WITH RECURSIVE h AS ("
                        + "WITH RECURSIVE r AS ("
                        + "SELECT"
                        + " c1"
                        + ", c2"
                        + ", c3"
                        + ", rtrim(replace(c3,substr(c3,strpos(c3, '('), strpos(c3, ')')),'')) c3_mod"
                        + ", rtrim(substr(c3,strpos(c3, '('), strpos(c3, ')'))) c3_flg"
                        + ", c4"
                        + ", c5"
                        + ", c6"
                        + ", c7"
                        + ", c8"
                        + ", c9"
                        + ", c10"
                        + ", c11"
                        + ", c12"
                        + ", c13"
                        + ", c14"
                        + ", c15"
                        + ", c16"
                        + ", c17"
                        + ", c18"
                        + ", c19"
                        + ", c20"
                        + ", c21"
                        + ", c22"
                        + ", t_seikyu.s_id"
                        + ", t_seikyu.o_id"
                        + ", t_seikyu.p_id"
                        + ", syubetsu"
                        + ", shisetsumei"
                        + ", title"
                        + ", sub_title"
                        + ", content1"
                        + ", content2"
                        + ", content3"
                        + ", t_seikyu.req_id"
                        + ", title1"
                        + ", title2"
                        + ", title3"
                        + ", title4"
                        + ", syutsuryokubi"
                        + ", s_nen"
                        + ", s_tsuki"
                        + ", s_hi"
                        + ", srb_id"
                        + ", time_stamp"
                        + ", t_seikyu.id"
                        + ", t_seikyu.c4_y"
                        + ", t_seikyu.c4_m"
                        + ", gengou"
                        + ", g_name"
                        + ", start_date"
                        + ", end_date"
                        + ", diff"
                        + " FROM"
                        + " ((((t_seikyu INNER JOIN t_syubetsu"
                        + " ON t_seikyu.s_id = t_syubetsu.s_id AND t_seikyu.o_id = t_syubetsu.o_id)"
                        + " INNER JOIN t_par ON t_seikyu.p_id::Integer = t_par.p_id)"
                        + " INNER JOIN t_req ON t_seikyu.req_id::Integer = t_req.req_id)"
                        + " INNER JOIN t_syutsuryokubi ON t_seikyu.s_id = t_syutsuryokubi.s_id)"
                        + " INNER JOIN t_gengou ON substr(t_seikyu.c4_y,1,1) = t_gengou.g_name"
                        + " ORDER BY id"
                        + ")"
                        + "SELECT"
                        + " r.c1"
                        + ", r.c2"
                        + ", r.c3"
                        + ", r.c3_mod"
                        + ", r.c3_flg"
                        + ", r.c4"
                        + ", first_day(r.c4_y, r.c4_m, r.g_name, r.diff) first_date"
                        + ", cast(CASE WHEN date_part('month', to_date((to_number(r.c4_y,'999')+r.diff || '/' || r.c4_m || '/' || 1),'yyyy/mm/dd')::timestamp) < 4 THEN"
                        + " to_number(r.c4_y,'999')-1 else to_number(r.c4_y,'999') end AS text) AS nendo"
                        + ", to_number(r.c4_y,'999')::Text AS nen"
                        + ", to_number(r.c4_m,'99')::Text AS tsuki"
                        + ", RANK() OVER (PARTITION BY r.c4, r.s_id ORDER BY r.id)::Text AS noufusyo_bangou"
                        + ", r.c5"
                        + ", r.c6"
                        + ", r.c7"
                        + ", s.c7 AS s_c7"
                        + ", r.c8"
                        + ", r.c9"
                        + ", s.c9 AS s_c9"
                        + ", r.c10"
                        + ", r.c11"
                        + ", r.c12"
                        + ", r.c13"
                        + ", r.c14"
                        + ", r.c15"
                        + ", r.c16"
                        + ", r.c17"
                        + ", s.c17 AS s_c17"
                        + ", r.c18"
                        + ", r.c19"
                        + ", s.c19 AS s_c19"
                        + ", r.c20"
                        + ", r.c21"
                        + ", r.c22"
                        + ", r.s_id"
                        + ", r.o_id"
                        + ", r.p_id"
                        + ", r.syubetsu"
                        + ", r.shisetsumei"
                        + ", r.title"
                        + ", r.sub_title"
                        + ", r.content1"
                        + ", r.content2"
                        + ", r.content3"
                        + ", r.req_id"
                        + ", r.title1"
                        + ", r.title2"
                        + ", r.title3"
                        + ", r.title4"
                        + ", r.syutsuryokubi"
                        + ", r.s_nen"
                        + ", r.s_tsuki"
                        + ", r.s_hi"
                        + ", r.srb_id"
                        + ", r.time_stamp"
                        + ", r.id"
                        + ", r.c4_y"
                        + ", r.c4_m"
                        + ", r.gengou"
                        + ", r.g_name"
                        + ", r.start_date"
                        + ", r.end_date"
                        + ", r.diff"
                        + " FROM r"
                        + " LEFT JOIN (SELECT c4, c5, c6, c7, c9, c11, c14, c15, c16, c17, c19, s_id, o_id, CASE WHEN c7 = '現金' THEN '1' WHEN c7 = '引落' THEN '2' WHEN c7 = '振込' THEN '2' else '' END 支払方法, time_stamp FROM t_shiharai_houhou"
                        + " WHERE time_stamp = (SELECT max(time_stamp) FROM t_shiharai_houhou WHERE"
                            + " c4_y::Text = CASE WHEN length('" + Cmb_nen_str + "')=2 THEN"
                                                    + " substr('" + Cmb_nen_str + "',1,1) || ' ' || substr('" + Cmb_nen_str + "', length('" + Cmb_nen_str + "')-1+1, length('" + Cmb_nen_str + "'))"
                                                + " ELSE"
                                                    + "'" + Cmb_nen_str + "'"
                                                + " END"
                            + " AND c4_m::Text = CASE WHEN length('" + Cmb_tsuki_str + "')=1 THEN"
                                                + " ' ' || '" + Cmb_tsuki_str + "'"
                                                + " WHEN length('" + Cmb_tsuki_str + "')=2 THEN"
                                                + " '' || '" + Cmb_tsuki_str + "'"
                                                + " END"
                            + " AND s_id::Integer = " + Cmb_s_id_int
                            + " AND o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                        + ")) s ON r.c1 = s.c5 AND rtrim(replace(r.c3,substr(r.c3,strpos(r.c3, '('), strpos(r.c3, ')')),'')) = rtrim(replace(s.c6,substr(s.c6,strpos(s.c6, '('), strpos(s.c6, ')')),'')) AND r.s_id = s.s_id AND r.o_id = s.o_id AND s.s_id ::Integer = " + Cmb_s_id_int
                        + " WHERE"
                        + " r.s_id::Integer = " + Cmb_s_id_int
                        + " AND r.o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                        + " AND r.time_stamp = (SELECT max(time_stamp) FROM t_seikyu WHERE"
                        + " s_id::Integer = " + Cmb_s_id_int
                        + " AND o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                        + " AND c4_y::Text = CASE WHEN length('" + Cmb_nen_str + "')=2 THEN"
                                                + " substr('" + Cmb_nen_str + "',1,1) || ' ' || substr('" + Cmb_nen_str + "', length('" + Cmb_nen_str + "')-1+1, length('" + Cmb_nen_str + "'))"
                                            + " ELSE"
                                                + "'" + Cmb_nen_str + "'"
                                            + " END"
                        + " AND c4_m::Text = CASE WHEN length('" + Cmb_tsuki_str + "')=1 THEN"
                                            + " ' ' || '" + Cmb_tsuki_str + "'"
                                            + " WHEN length('" + Cmb_tsuki_str + "')=2 THEN"
                                            + " '' || '" + Cmb_tsuki_str + "'"
                                            + " END"
                        + " )"
                        + " AND c4_y::Text = CASE WHEN length('" + Cmb_nen_str + "')=2 THEN"
                                                + " substr('" + Cmb_nen_str + "',1,1) || ' ' || substr('" + Cmb_nen_str + "', length('" + Cmb_nen_str + "')-1+1, length('" + Cmb_nen_str + "'))"
                                            + " ELSE"
                                                + "'" + Cmb_nen_str + "'"
                                            + " END"
                        + " AND c4_m::Text = CASE WHEN length('" + Cmb_tsuki_str + "')=1 THEN"
                                            + " ' ' || '" + Cmb_tsuki_str + "'"
                                            + " WHEN length('" + Cmb_tsuki_str + "')=2 THEN"
                                            + " '' || '" + Cmb_tsuki_str + "'"
                                            + " END"
                        + " ORDER BY r.id"
                        + ")"
                        + " SELECT"
                        + " h.c1"
                        + ", h.c2"
                        + ", h.c3"
                        + ", h.c3_mod"
                        + ", h.c3_flg"
                        + ", h.c4"
                        + ", h.first_date"
                        + ", h.nendo"
                        + ", h.nen"
                        + ", h.tsuki"
                        + ", h.noufusyo_bangou"
                        + ", h.c5"
                        + ", h.c6"
                        + ", h.c7"
                        + ", h.s_c7"
                        + ", h.c8"
                        + ", h.c9"
                        + ", h.s_c9"
                        + ", h.c10"
                        + ", h.c11"
                        + ", h.c12"
                        + ", h.c13"
                        + ", h.c14"
                        + ", h.c15"
                        + ", h.c16"
                        + ", h.c17"
                        + ", h.s_c17"
                        + ", h.c18"
                        + ", h.c19"
                        + ", h.s_c19"
                        + ", h.c20"
                        + ", h.c21"
                        + ", h.c22"
                        + ", h.s_id"
                        + ", h.o_id"
                        + ", h.p_id"
                        + ", h.syubetsu"
                        + ", h.shisetsumei"
                        + ", h.title"
                        + ", h.sub_title"
                        + ", h.content1"
                        + ", h.content2"
                        + ", h.content3"
                        + ", h.req_id"
                        + ", h.title1"
                        + ", h.title2"
                        + ", h.title3"
                        + ", h.title4"
                        + ", h.syutsuryokubi"
                        + ", h.s_nen"
                        + ", h.s_tsuki"
                        + ", h.s_hi"
                        + ", h.srb_id"
                        + ", h.time_stamp"
                        + ", h.id"
                        + ", h.c4_y"
                        + ", h.c4_m"
                        + ", h.gengou"
                        + ", h.g_name"
                        + ", h.start_date"
                        + ", h.end_date"
                        + ", h.diff"
                        + " FROM h;"
                        , m_conn
                        );

                        if (cmb_c4.SelectedItem == null)
                        {
                            da.SelectCommand.Parameters.Add(new NpgsqlParameter("c4",
                            NpgsqlTypes.NpgsqlDbType.Integer, 0, "c4",
                            ParameterDirection.Input, false, 0, 0, DataRowVersion.Current,
                            DBNull.Value));
                        }
                        else
                        {
                            DataRowView row = (DataRowView)cmb_c4.SelectedItem;
                            da.SelectCommand.Parameters.AddWithValue("c4", row["c4"]);
                        }


                        if (cmb_s_id.SelectedItem == null)
                        {
                            da.SelectCommand.Parameters.Add(new NpgsqlParameter("s_id",
                            NpgsqlTypes.NpgsqlDbType.Integer, 0, "s_id",
                            ParameterDirection.Input, false, 0, 0, DataRowVersion.Current,
                            DBNull.Value));
                        }
                        else
                        {
                            DataRowView row = (DataRowView)cmb_s_id.SelectedItem;
                            da.SelectCommand.Parameters.AddWithValue("s_id", row["s_id"]);
                        }

                        if (ds.Tables["seikyu"] != null)
                            ds.Tables["seikyu"].Clear();
                        da.Fill(ds, "seikyu");

                        crGenbo myReport = new crGenbo();
                        myReport.SetDataSource(ds);

                        myReport.SetParameterValue("s_id", Cmb_s_id_int.ToString());
                        myReport.SetParameterValue("req_id", Form_Seikyu_TextBoxO_id);

                        crvSeikyu.ReportSource = myReport;

                        bindingNavigatorWithdrawal.Visible = false;
                        dataGridViewWithdrawal.Visible = false;
                        crvSeikyu.Visible = true;
                    }
                    break;

                case 3: // 収入内訳
                    {
                        da.SelectCommand = new NpgsqlCommand
                        (
                            "WITH RECURSIVE h AS ("
                                + "WITH RECURSIVE r AS ("
                                + "SELECT"
                                + " c1"
                                + ", c2"
                                + ", c3"
                                + ", rtrim(replace(c3,substr(c3,strpos(c3, '('), strpos(c3, ')')),'')) c3_mod"
                                + ", c4"
                                + ", c4_y"
                                + ", c4_m"
                                + ", c5"
                                + ", c6"
                                + ", c7"
                                + ", c8"
                                + ", c9"
                                + ", c10"
                                + ", c11"
                                + ", c12"
                                + ", c13"
                                + ", c14"
                                + ", c15"
                                + ", c16"
                                + ", c17"
                                + ", c18"
                                + ", c19"
                                + ", c20"
                                + ", c21"
                                + ", c22"
                                + ", a.s_id"
                                + ", a.o_id"
                                + ", a.p_id"
                                + ", syubetsu"
                                + ", shisetsumei"
                                + ", title"
                                + ", sub_title"
                                + ", content1"
                                + ", content2"
                                + ", content3"
                                + ", a.req_id"
                                + ", title1"
                                + ", title2"
                                + ", title3"
                                + ", title4"
                                + ", syutsuryokubi"
                                + ", s_nen"
                                + ", s_tsuki"
                                + ", s_hi"
                                + ", srb_id"
                                + ", time_stamp"
                                + ", to_number(c4_y,'999')::Text AS nen"
                                + ", to_number(c4_m,'99')::Text AS tsuki"
                                + ", gengou"
                                + ", g_name"
                                + ", start_date"
                                + ", end_date"
                                + ", diff"
                                + " FROM"
                                + " ("
                                    + "("
                                        + "("
                                            + "("
                                            + "t_seikyu a INNER JOIN t_syubetsu b"
                                            + " ON a.s_id = b.s_id AND a.o_id = b.o_id)"
                                                + " INNER JOIN t_par c ON a.p_id::Integer = c.p_id)"
                                                    + " INNER JOIN t_req d ON a.req_id::Integer = d.req_id)"
                                        + " INNER JOIN t_syutsuryokubi e ON a.s_id::Text = e.s_id)"
                                    + " INNER JOIN t_gengou f ON substr(a.c4_y,1,1) = f.g_name"
                                    + " ORDER BY c1"
                                + ")"// r
                            + " SELECT"
                            + " r.c4"
                            + ", r.c4_y"
                            + ", r.c4_m"
                            + ", r.syubetsu"
                            + ", count(cast(r.c22 AS integer)) AS rec_count"
                            + ", sum(cast(r.c5 AS integer)) AS g_c5"
                            + ", sum(cast(r.c6 AS integer)) AS g_c6"
                            + ", sum(cast(r.c7 AS integer)) AS g_c7"
                            + ", sum(cast(r.c8 AS integer)) AS g_c8"
                            + ", sum(cast(r.c9 AS integer)) AS g_c9"
                            + ", sum(cast(r.c10 AS integer)) AS g_c10"
                            + ", sum(cast(r.c11 AS integer)) AS g_c11"
                            + ", sum(cast(r.c12 AS integer)) AS g_c12"
                            + ", sum(cast(r.c13 AS integer)) AS g_c13"
                            + ", sum(cast(r.c14 AS integer)) AS g_c14"
                            + ", sum(cast(r.c15 AS integer)) AS g_c15"
                            + ", sum(cast(r.c16 AS integer)) AS g_c16"
                            + ", sum(cast(r.c17 AS integer)) AS g_c17"
                            + ", sum(cast(r.c18 AS integer)) AS g_c18"
                            + ", sum(cast(r.c19 AS integer)) AS g_c19"
                            + ", sum(cast(r.c20 AS integer)) AS g_c20"
                            + ", sum(cast(r.c21 AS integer)) AS g_c21"
                            + ", sum(cast(r.c22 AS integer)) AS goukei"
                            + ", cast(CASE WHEN date_part('month', to_date((to_number(r.c4_y,'999')+r.diff || '/' || r.c4_m || '/' || 1),'yyyy/mm/dd')::timestamp) < 4 THEN"
                            + " to_number(r.c4_y,'999')-1 ELSE to_number(r.c4_y,'999') END AS text) AS nendo"
                            + ", to_number(r.c4_y,'999')::Text AS nen"
                            + ", to_number(r.c4_m,'99')::Text AS tsuki"
                            + ", r.gengou"
                            + ", r.g_name"
                            + ", r.start_date"
                            + ", r.end_date"
                            + ", r.diff"
                            + " FROM r"
                            + " GROUP BY r.c4, r.s_id, r.o_id, r.c4_y, r.c4_m, r.req_id, r.syubetsu, r.tsuki, r.time_stamp, r.gengou, r.g_name, r.start_date, r.end_date, r.diff"
                            + " HAVING r.c4_y::Text = CASE WHEN length('" + Cmb_nen_str + "') = 2 THEN"
                                                    + " substr('" + Cmb_nen_str + "',1,1) || ' ' || substr('" + Cmb_nen_str + "', length('" + Cmb_nen_str + "')-1+1, length('" + Cmb_nen_str + "'))"
                                                + " ELSE"
                                                    + "'" + Cmb_nen_str + "'"
                                                + " END"
                            + " AND r.c4_m::Text = CASE WHEN length('" + Cmb_tsuki_str + "')=1 THEN"
                                            + " ' ' || '" + Cmb_tsuki_str + "'"
                                            + "       WHEN length('" + Cmb_tsuki_str + "')=2 THEN"
                                            + " '' || '" + Cmb_tsuki_str + "'"
                                            + " END"
                            + " AND r.s_id::Integer = " + Cmb_s_id_int
                            + " AND r.o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                            + " AND r.time_stamp = (SELECT max(time_stamp) FROM t_seikyu WHERE"
                                                    + " s_id::Integer = " + Cmb_s_id_int
                                                    + " AND o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                                                    + " AND c4_y::Text = CASE WHEN length('" + Cmb_nen_str + "')=2 THEN"
                                                                            + " substr('" + Cmb_nen_str + "',1,1) || ' ' || substr('" + Cmb_nen_str + "', length('" + Cmb_nen_str + "')-1+1, length('" + Cmb_nen_str + "'))"
                                                                        + " ELSE"
                                                                            + "'" + Cmb_nen_str + "'"
                                                                        + " END"
                                                    + " AND c4_m::Text = CASE WHEN length('" + Cmb_tsuki_str + "')=1 THEN"
                                                                    + " ' ' || '" + Cmb_tsuki_str + "'"
                                                                    + "       WHEN length('" + Cmb_tsuki_str + "')=2 THEN"
                                                                    + " '' || '" + Cmb_tsuki_str + "'"
                                                                    + " END"
                                                    + ")"
                            + ")" // h
                        + " SELECT"
                        + " h.c4"
                        + ", h.c4_y"
                        + ", h.c4_m"
                        + ", h.syubetsu"
                        + ", h.rec_count"
                        + ", h.g_c5"
                        + ", h.g_c6"
                        + ", h.g_c7"
                        + ", h.g_c8"
                        + ", h.g_c9"
                        + ", h.g_c10"
                        + ", h.g_c11"
                        + ", h.g_c12"
                        + ", h.g_c13"
                        + ", h.g_c14"
                        + ", h.g_c15"
                        + ", h.g_c16"
                        + ", h.g_c17"
                        + ", h.g_c18"
                        + ", h.g_c19"
                        + ", h.g_c20"
                        + ", h.g_c21"
                        + ", h.goukei"
                        + ", h.nendo"
                        + ", h.nen"
                        + ", h.tsuki"
                        + ", h.gengou"
                        + ", h.g_name"
                        + ", h.start_date"
                        + ", h.end_date"
                        + ", h.diff"
                        + " FROM h;"
                        , m_conn
                        );

                        if (cmb_c4.SelectedItem == null)
                        {
                            da.SelectCommand.Parameters.Add(new NpgsqlParameter("c4",
                            NpgsqlTypes.NpgsqlDbType.Integer, 0, "c4",
                            ParameterDirection.Input, false, 0, 0, DataRowVersion.Current,
                            DBNull.Value));
                        }
                        else
                        {
                            DataRowView row = (DataRowView)cmb_c4.SelectedItem;
                            da.SelectCommand.Parameters.AddWithValue("c4", row["c4"]);
                        }


                        if (cmb_s_id.SelectedItem == null)
                        {
                            da.SelectCommand.Parameters.Add(new NpgsqlParameter("s_id",
                            NpgsqlTypes.NpgsqlDbType.Integer, 0, "s_id",
                            ParameterDirection.Input, false, 0, 0, DataRowVersion.Current,
                            DBNull.Value));
                        }
                        else
                        {
                            DataRowView row = (DataRowView)cmb_s_id.SelectedItem;
                            da.SelectCommand.Parameters.AddWithValue("s_id", row["s_id"]);
                        }

                        if (ds.Tables["seikyu"] != null)
                            ds.Tables["seikyu"].Clear();
                        da.Fill(ds, "seikyu");

                        crUchiwake myReport = new crUchiwake();
                        myReport.SetDataSource(ds);
                        myReport.SetParameterValue("s_id", Cmb_s_id_int.ToString());
                        crvSeikyu.ReportSource = myReport;

                        bindingNavigatorWithdrawal.Visible = false;
                        dataGridViewWithdrawal.Visible = false;
                        crvSeikyu.Visible = true;
                    }
                    break;

                case 4: // 納入案内
                    {
                        da.SelectCommand = new NpgsqlCommand
                        (
                        "WITH RECURSIVE r as ("
                        + " SELECT"
                        + " b.c5 利用者番号"
                        + ", a.id"
                        + ", a.c1"
                        + ", a.c4"
                        + ", a.c4_y"
                        + ", a.c4_m"
                        + ", a.c22"
                        + ", a.s_id"
                        + ", a.o_id"
                        + ", a.req_id"
                        + ", c.syubetsu"
                        + ", a.c3"
                        + ", rtrim(replace(a.c3,substr(a.c3,strpos(a.c3, '('), strpos(a.c3, ')')),'')) 利用者名"
                        + ", b.c7 支払方法"
                        + ", b.c14 引落金融機関支店名"
                        + ", b.c15 引落口座種別"
                        + ", CASE WHEN strpos(b.c4, '[')>=1 THEN" 
                        + " substr(b.c4, strpos(b.c4, '[') + 1, strpos(b.c4, ']') - strpos(b.c4, '[') - 1)"
                        + " ELSE"
                        + " b.c4"
                        + " END 事業所名"
                        + ", d.col0"
                        + ", d.col1"
                        + ", d.col2"
                        + ", d.col3"
                        + ", d.col4"
                        + ", d.col5"
                        + ", d.ac0"
                        + ", d.ac1"
                        + ", d.ac2"
                        + ", d.ac3"
                        + ", CASE WHEN length(b.c16)=7 THEN left(b.c16,4) || replace(right(b.c16,3),right(b.c16,3),'***')"
                        + " WHEN length(b.c16)=14 THEN left(b.c16,4) || replace(right(b.c16,10),right(b.c16,10),'**-*******')"
                        + " END 引落口座番号"
                        + ", CASE WHEN ((b.c19 is null) OR (b.c19 = '')) AND b.c7 = '1' THEN b.c6"
                        + " ELSE b.c19 END 引落口座名義人"
                        + ", CASE WHEN ((b.c7 = '現金') OR (b.c11 is null)or(b.c11 = '')) THEN '稚内信用金庫'"
                        + " ELSE b.c11 END 引落金融機関銀行名"
                        + ", e.b_code"
                        + ", e.br_code"
                        + ", e.sb_name"
                        + ", e.sd"
                        + ", f.title1"
                        + ", f.title2"
                        + ", f.title3"
                        + ", f.title4"
                        + ", f1.o_phone_number"
                        + ", f1.o_name"
                        + ", f.data7"
                        + ", f.data8"
                        + ", f.title4_kana"
                        + ", L.acc_kana"
                        + ", L.accounting_manager"
                        + ", g.syutsuryokubi"
                        + ", CASE WHEN ((b.c7 = '現金') or (b.c11 = '')) THEN '1021' ELSE h.b_code END _b_code"
                        + ", CASE WHEN ((b.c7 = '現金') or (b.c11 = '')) THEN '稚内信用金庫' ELSE h.b_name END _b_name"
                        + ", CASE WHEN ((b.c7 = '現金') or (b.c11 = '')) THEN '014' ELSE h.br_code END _br_code"
                        + ", CASE WHEN ((b.c7 = '現金') or (b.c11 = '')) THEN '利尻富士支店' ELSE h.br_name END _br_name"
                        + ", CASE WHEN e.sy IS NULL or e.sm IS NULL THEN" /* 引落年月日自動入力の場合*/
                            + " CASE WHEN e.b_id = '0' THEN null"
                                + " WHEN e.b_id = '1' THEN" /* 稚内信金の場合の処理*/
                                    + " CASE WHEN e.sd = '99' THEN" /* 翌月末引落の場合の処理 */
                                            + " target_date(to_date((to_number(c4_y,'999')+diff || '/' || to_number(c4_m,'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                    + " ELSE" /* 翌月末引落以外の場合の処理 */
                                            + " target_date(to_date((to_number(c4_y,'999')+diff || '/' || to_number(c4_m,'99')+1 || '/' || to_number(e.sd,'99')),'yyyy/mm/dd'))"
                                    + " END"
                                + " WHEN e.b_id = '2' THEN" /* ゆうちょ銀行の場合の処理*/
                                    + " CASE WHEN e.sd = '99' THEN" /* 翌月末引落の場合の処理 */
                                            + " target_date(to_date((to_number(c4_y,'999')+diff || '/' || to_number(c4_m,'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                    + " ELSE" /* 翌月末引落以外の場合の処理 */
                                            + " target_date(to_date((to_number(c4_y,'999')+diff || '/' || to_number(c4_m,'99')+1 || '/' || to_number(e.sd,'99')),'yyyy/mm/dd'))"
                                    + " END"
                                + " WHEN e.b_id = '3' THEN" /* 利尻漁協の場合の処理*/
                                    + " CASE WHEN e.sd = '99' THEN" /* 翌月末引落の場合の処理 */
                                            + " target_date(to_date((to_number(c4_y,'999')+diff || '/' || to_number(c4_m,'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                    + " ELSE" /* 翌月末引落以外の場合の処理 */
                                            + " target_date(to_date((to_number(c4_y,'999')+diff || '/' || to_number(c4_m,'99')+1 || '/' || to_number(e.sd,'99')),'yyyy/mm/dd'))"
                                    + " END"
                            + " END"
                        + " ELSE" /* 引落年月日手入力の場合*/
                            + " CASE WHEN e.b_id = '0' THEN null"
                                + " WHEN e.b_id = '1' THEN" /* 稚内信金の場合の処理*/
                                    + " CASE WHEN e.sd = '99' THEN" /* 翌月末引落の場合の処理 */
                                        + " target_date(to_date((to_number(e.sy,'999')+diff || '/' || to_number(e.sm,'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                    + " ELSE" /* 翌月末引落以外の場合の処理 */
                                        + " target_date(to_date((to_number(e.sy,'999')+diff || '/' || to_number(e.sm,'99') || '/' || to_number(e.sd,'99')),'yyyy/mm/dd'))"
                                    + " END"
                                + " WHEN e.b_id = '2' THEN" /* ゆうちょ銀行の場合の処理*/
                                    + " CASE WHEN e.sd = '99' THEN" /* 翌月末引落の場合の処理 */
                                        + " target_date(to_date((to_number(e.sy,'999')+diff || '/' || to_number(e.sm,'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                    + " ELSE" /* 翌月末引落以外の場合の処理 */
                                        + " target_date(to_date((to_number(e.sy,'999')+diff || '/' || to_number(e.sm,'99') || '/' || to_number(e.sd,'99')),'yyyy/mm/dd'))"
                                    + " END"
                                + " WHEN e.b_id = '3' THEN" /* 利尻漁協の場合の処理*/
                                    + " CASE WHEN e.sd = '99' THEN" /* 翌月末引落の場合の処理 */
                                        + " target_date(to_date((to_number(e.sy,'999')+diff || '/' || to_number(e.sm,'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                    + " ELSE" /* 翌月末引落以外の場合の処理 */
                                        + " target_date(to_date((to_number(e.sy,'999')+diff || '/' || to_number(e.sm,'99') || '/' || to_number(e.sd,'99')),'yyyy/mm/dd'))"
                                    + " END"
                            + " END"
                        + " END target_date"
                        + ", CASE WHEN ((h.b_name is null)or(h.b_name = '')) THEN '稚内信用金庫'"
                        + " ELSE h.b_name END b_name"
                        + ", i.c25 shiharaisya"
                        + ", k.gengou"
                        + ", k.g_name"
                        + ", k.start_date"
                        + ", k.end_date"
                        + ", k.diff"
                        + ", j.stuff"
                        + ", m.manager"
                        + " FROM ("
                        + "("
                            + "("
                                + "("
                                    + "("
                                        + "("
                                            + "("
                                                + "("
                                                    + "("
                                                        + "("
                                                            + "("
                                                                + "(SELECT id, c1, c3, c4, c4_y, c4_m, c22, s_id, o_id, req_id"
                                                                + " , time_stamp FROM t_seikyu"
                                                                + " WHERE time_stamp = "
                                                                    + "(SELECT max(time_stamp) FROM t_seikyu WHERE"
                                                                    + " s_id::Integer = " + Cmb_s_id_int
                                                                    + " AND o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                                                                    + " AND c4_y::Text = CASE WHEN length('" + Cmb_nen_str + "')=2 THEN"
                                                                                            + " substr('" + Cmb_nen_str + "',1,1) || ' ' || substr('" + Cmb_nen_str + "', length('" + Cmb_nen_str + "')-1+1, length('" + Cmb_nen_str + "'))"
                                                                                        + " ELSE"
                                                                                            + "'" + Cmb_nen_str + "'"
                                                                                        + " END"
                                                                    + " AND c4_m::Text = CASE WHEN length('" + Cmb_tsuki_str + "')=1 THEN"
                                                                    + " ' ' || '" + Cmb_tsuki_str + "'"
                                                                    + " WHEN length('" + Cmb_tsuki_str + "')=2 THEN"
                                                                    + " '' || '" + Cmb_tsuki_str + "'"
                                                                    + " END"
                                                                    + ")"
                                                                + ") a LEFT JOIN (SELECT c4, c5, c6, c7, c11, c14, c15, c16, c19, s_id, o_id,"
                                                                    + " CASE WHEN c7 = '現金' THEN '1'"
                                                                        + " WHEN c7 = Null THEN '1'"
                                                                        + " WHEN c7 = '引落' THEN '2'"
                                                                        + " WHEN c7 = '振込' THEN '2'"
                                                                        + " ELSE '' END 支払方法"
                                                                    + ", time_stamp FROM t_shiharai_houhou"
                                                                    + " WHERE time_stamp = "
                                                                                        + "(SELECT max(time_stamp) FROM t_shiharai_houhou WHERE"
                                                                                            + " c4_y::Text = CASE WHEN length('" + Cmb_nen_str + "')=2 THEN"
                                                                                                                    + " substr('" + Cmb_nen_str + "',1,1) || ' ' || substr('" + Cmb_nen_str + "', length('" + Cmb_nen_str + "')-1+1, length('" + Cmb_nen_str + "'))"
                                                                                                                + " ELSE"
                                                                                                                    + "'" + Cmb_nen_str + "'"
                                                                                                                + " END"
                                                                                            + " AND c4_m::Text = CASE WHEN length('" + Cmb_tsuki_str + "')=1 THEN"
                                                                                            + " ' ' || '" + Cmb_tsuki_str + "'"
                                                                                            + " WHEN length('" + Cmb_tsuki_str + "')=2 THEN"
                                                                                            + " '' || '" + Cmb_tsuki_str + "'"
                                                                                            + " END"
                                                                                            + " AND s_id::Integer = " + Cmb_s_id_int
                                                                                            + " AND o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                                                                                        + ")"
                                                                                + ") b ON a.c1 = b.c5"
                                                                                + " AND rtrim(replace(a.c3,substr(a.c3,strpos(a.c3, '('), strpos(a.c3, ')')),''))"
                                                                                    + " = rtrim(replace(b.c6,substr(b.c6,strpos(b.c6, '('), strpos(b.c6, ')')),''))"
                                                                                + " AND a.s_id = b.s_id"
                                                                                + " AND a.o_id = b.o_id"
                                                                                + " AND b.s_id::Integer = " + Cmb_s_id_int + ")"
                                                                        + " LEFT JOIN (SELECT s_id, o_id, syubetsu FROM t_syubetsu) c ON a.s_id = c.s_id AND a.o_id = c.o_id)"
                                                                    + " LEFT JOIN (SELECT rep_id, pt_id, s_id, o_id, col0, col1, col2, col3, col4, col5, ac0, ac1, ac2, ac3 FROM t_rep) d ON b.支払方法 = d.pt_id AND a.s_id = d.s_id AND a.o_id = d.o_id)"
                                                                + " LEFT JOIN (SELECT bid, b_id, b_code, b_name, sb_name, br_code, br_name, sd, sm, sy FROM t_bank) e ON b.c11 = e.b_name)"
                                                            + " LEFT JOIN (SELECT req_id, title1, title2, title3, title4, data7, data8, title4_kana FROM t_req) f ON a.req_id = f.req_id::Text)"
                                                        + " LEFT JOIN (SELECT o_id, o_name, o_phone_number FROM t_office) f1 ON a.o_id = f1.o_id::Text)"
                                                    + " LEFT JOIN (SELECT syutsuryokubi, s_id FROM t_syutsuryokubi) g ON a.s_id = g.s_id)"
                                                + " LEFT JOIN (SELECT bid, b_id, b_code, b_name, sb_name, br_code, br_name, sd FROM t_bank WHERE b_id = '1') h ON b.c11 = h.b_name)"
                                            + " LEFT JOIN (SELECT c1, c5, c25, c48, s_id, o_id FROM t_shinzoku_kankei WHERE c48 = '1' AND time_stamp = (SELECT max(time_stamp) FROM t_shinzoku_kankei WHERE"
                                                + " c4_y::Text = CASE WHEN length('" + Cmb_nen_str + "')=2 THEN"
                                                                        + " substr('" + Cmb_nen_str + "',1,1) || ' ' || substr('" + Cmb_nen_str + "', length('" + Cmb_nen_str + "')-1+1, length('" + Cmb_nen_str + "'))"
                                                                    + " ELSE"
                                                                        + "'" + Cmb_nen_str + "'"
                                                                    + " END"
                                                + " AND c4_m::Text = CASE WHEN length('" + Cmb_tsuki_str + "')=1 THEN"
                                                + " ' ' || '" + Cmb_tsuki_str + "'"
                                                + " WHEN length('" + Cmb_tsuki_str + "')=2 THEN"
                                                + " '' || '" + Cmb_tsuki_str + "'"
                                                + " END"
                                                + " AND s_id::Integer = " + Cmb_s_id_int
                                                + " AND o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                                            + " )) i ON a.c1 = i.c1"
                                            + " AND i.s_id::Integer = " + Cmb_s_id_int
                                            + " AND i.o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                                            + ") "
                                        + " LEFT JOIN (SELECT gg_id, g_name, gengou, start_date, end_date, diff FROM t_gengou) k ON substr(c4_y,1,1) = k.g_name)"
                                    + " LEFT JOIN (SELECT m_id, manager, start_date, end_date, o_id FROM t_manager) m ON m.o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                                        + " AND m.start_date <= (SELECT to_date((to_number(c4_y,'999')+k.diff || '/' || to_number(c4_m,'99')+1 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                        + " AND (m.end_date Is Null Or m.end_date >= (SELECT to_date((to_number(c4_y,'999')+k.diff || '/' || to_number(c4_m,'99')+1 || '/' || to_number('01','99')),'yyyy/mm/dd')-1) "
                                    + ")"
                                + " LEFT JOIN (SELECT stf_id, stuff, start_date, end_date, o_id FROM t_stuff) j ON j.o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                                    + " AND j.start_date <= (SELECT to_date((to_number(c4_y,'999')+k.diff || '/' || to_number(c4_m,'99')+1 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                    + " AND (j.end_date Is Null Or j.end_date >= (SELECT to_date((to_number(c4_y,'999')+k.diff || '/' || to_number(c4_m,'99')+1 || '/' || to_number('01','99')),'yyyy/mm/dd')-1) "
                                + ")"
                                + " LEFT JOIN (SELECT acc_id, accounting_manager, start_date, end_date, acc_kana FROM t_accounting_manager) L ON "
                                    + " L.start_date <= (SELECT to_date((to_number(c4_y,'999')+k.diff || '/' || to_number(c4_m,'99')+1 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                    + " AND (L.end_date Is Null Or L.end_date >= (SELECT to_date((to_number(c4_y,'999')+k.diff || '/' || to_number(c4_m,'99')+1 || '/' || to_number('01','99')),'yyyy/mm/dd')-1) "
                                + ")"
                            + ") ORDER BY a.id"
                        + ")"
                        + " SELECT"
                        + " 利用者番号"
                        + ", id"
                        + ", c1"
                        + ", c3"
                        + ", c4"
                        + ", c4_y || '/' || c4_m c4_ym"
                        + ", c22"
                        + ", s_id"
                        + ", o_id"
                        + ", req_id"
                        + ", syubetsu"
                        + ", 利用者名"
                        + ", 支払方法"
                        + ", 引落金融機関支店名"
                        + ", 引落口座種別"
                        + ", 事業所名"
                        + ", col0"
                        + ", col1"
                        + ", col2"
                        + ", col3"
                        + ", col4"
                        + ", col5"
                        + ", ac0"
                        + ", ac1"
                        + ", ac2"
                        + ", ac3"
                        + ", 引落口座番号"
                        + ", 引落口座名義人"
                        + ", 引落金融機関銀行名"
                        + ", b_code"
                        + ", b_name"
                        + ", br_code"
                        + ", sb_name"
                        + ", sd"
                        + ", title1"
                        + ", title2"
                        + ", title3"
                        + ", title4"
                        + ", manager"
                        + ", stuff"
                        + ", o_phone_number name5"
                        + ", o_name data6"
                        + ", data7"
                        + ", data8"
                        + ", title4_kana"
                        + ", accounting_manager"
                        + ", acc_kana"
                        + ", syutsuryokubi"
                        + ", _b_code"
                        + ", _br_code"
                        + ", _br_name"
                        + ", shiharaisya"
                        + ", target_date last_day"
                        + ", gengou"
                        + ", g_name"
                        + ", start_date"
                        + ", end_date"
                        + ", diff"
                        + " FROM r;"
                        , m_conn
                        );

                        if (cmb_c4.SelectedItem == null)
                        {
                            da.SelectCommand.Parameters.Add(new NpgsqlParameter("c4",
                            NpgsqlTypes.NpgsqlDbType.Integer, 0, "c4",
                            ParameterDirection.Input, false, 0, 0, DataRowVersion.Current,
                            DBNull.Value));
                        }
                        else
                        {
                            DataRowView row = (DataRowView)cmb_c4.SelectedItem;
                            da.SelectCommand.Parameters.AddWithValue("c4", row["c4"]);
                        }


                        if (cmb_s_id.SelectedItem == null)
                        {
                            da.SelectCommand.Parameters.Add(new NpgsqlParameter("s_id",
                            NpgsqlTypes.NpgsqlDbType.Integer, 0, "s_id",
                            ParameterDirection.Input, false, 0, 0, DataRowVersion.Current,
                            DBNull.Value));
                        }
                        else
                        {
                            DataRowView row = (DataRowView)cmb_s_id.SelectedItem;
                            da.SelectCommand.Parameters.AddWithValue("s_id", row["s_id"]);
                        }

                        if (ds.Tables["seikyu"] != null)
                            ds.Tables["seikyu"].Clear();
                        da.Fill(ds, "seikyu");

                        crShiharai myReport = new crShiharai();
                        myReport.SetDataSource(ds);

                        myReport.SetParameterValue("s_id", Cmb_s_id_int.ToString());
                        myReport.SetParameterValue("req_id", Form_Seikyu_TextBoxO_id);

                        crvSeikyu.ReportSource = myReport;

                        bindingNavigatorWithdrawal.Visible = false;
                        dataGridViewWithdrawal.Visible = false;
                        crvSeikyu.Visible = true;
                    }
                    break;

                case 5: // 引落請求書
                    {
                        if (checkBoxIni.Checked)
                        {
                            try
                            {
                                m_conn.Open();
                                using (var tran = m_conn.BeginTransaction())
                                {
                                    //データ登録
                                    var cmd = new NpgsqlCommand(@"UPDATE t_seikyu SET w_flg = Null WHERE w_flg = '1';", m_conn);
                                    cmd.ExecuteNonQuery();
                                    //データ検索
                                    var dataAdapter = new NpgsqlDataAdapter(@"SELECT * FROM t_seikyu", m_conn);
                                    var dataSet = new DataSet();
                                    dataAdapter.Fill(dataSet);

                                    DataTable dst = dataSet.Tables[0];
                                    Console.WriteLine("コミット前データ件数：{0}", dst.Rows.Count);

                                    // コミットして、再検索
                                    tran.Commit();

                                    dataSet = new DataSet();
                                    dataAdapter.Fill(dataSet);

                                    dst = dataSet.Tables[0];
                                    Console.WriteLine("コミット後データ件数：{0}", dst.Rows.Count);
                                    rec = dst.Rows.Count;
                                }
                                m_conn.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("保存に失敗しました。\n\n[内容]\n" + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            MessageBox.Show(rec.ToString() + "件、保存しました。", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {

                            Console.WriteLine("Cmb_b_code_str = " + Cmb_b_code_str);

                            da.SelectCommand = new NpgsqlCommand
                            (
                        "WITH RECURSIVE r as ("
                        + " SELECT"
                        + " a.r_id"
                        + ", a.id"
                        + ", a.c1"
                        + ", a.c4"
                        + ", a.c4_y"
                        + ", a.c4_m"
                        + ", a.c22"
                        + ", a.s_id"
                        + ", a.o_id"
                        + ", a.req_id"
                        + ", c.syubetsu"
                        + ", a.c3"
                        + ", rtrim(replace(a.c3,substr(a.c3,strpos(a.c3, '('), strpos(a.c3, ')')),'')) c3_mod"
                        + ", rtrim(replace(b.c6,substr(b.c6,strpos(b.c6, '('), strpos(b.c6, ')')),'')) c6_mod"
                        + ", a.w_flg"
                        + ", c.hyoujimei s_id_str"
                        + ", b.c5"
                        + ", b.c7 支払方法"
                        + ", b.c9"
                        + ", b.c11"
                        + ", b.c14"
                        + ", b.c15 引落口座種別"
                        + ", b.c16"
                        + ", b.c19"
                         + ", CASE WHEN strpos(b.c4, '[')>=1 THEN"
                        + " substr(b.c4, strpos(b.c4, '[') + 1, strpos(b.c4, ']') - strpos(b.c4, '[') - 1)"
                        + " ELSE"
                        + " b.c4"
                        + " END 事業所名"
                        + ", d.col0"
                        + ", d.col1"
                        + ", d.col2"
                        + ", d.col3"
                        + ", d.col4"
                        + ", d.col5"
                        + ", d.ac0"
                        + ", d.ac1"
                        + ", d.ac2"
                        + ", d.ac3"
                        + ", CASE WHEN length(b.c16)=7 THEN left(b.c16,4) || replace(right(b.c16,3),right(b.c16,3),'***')"
                        + " WHEN length(b.c16)=14 THEN left(b.c16,4) || replace(right(b.c16,10),right(b.c16,10),'**-*******')"
                        + " END 引落口座番号"
                        + ", CASE WHEN ((b.c19 is null) OR (b.c19 = '')) AND b.c7 = '1' THEN b.c6"
                        + " ELSE b.c19 END 引落口座名義人"
                        + ", CASE WHEN ((b.c7 = '現金') OR (b.c11 is null)or(b.c11 = '')) THEN '稚内信用金庫'"
                        + " ELSE b.c11 END 引落金融機関銀行名"
                        + ", e.b_code"
                        + ", e.br_code"
                        + ", e.sb_name"
                        + ", e.sd"
                        + ", f.title1"
                        + ", f.title2"
                        + ", f.title3"
                        + ", f.title4"
                        + ", f1.o_phone_number"
                        + ", f1.o_name"
                        + ", f.data7"
                        + ", f.data8"
                        + ", f.title4_kana"
                        + ", L.acc_kana"
                        + ", L.accounting_manager"
                        + ", g.syutsuryokubi"
                        + ", CASE WHEN ((b.c7 = '現金') or (b.c11 = '')) THEN '1021' ELSE h.b_code END _b_code"
                        + ", CASE WHEN ((b.c7 = '現金') or (b.c11 = '')) THEN '稚内信用金庫' ELSE h.b_name END _b_name"
                        + ", CASE WHEN ((b.c7 = '現金') or (b.c11 = '')) THEN '014' ELSE h.br_code END _br_code"
                        + ", CASE WHEN ((b.c7 = '現金') or (b.c11 = '')) THEN '利尻富士支店' ELSE h.br_name END _br_name"
                        + ", CASE WHEN e.sy IS NULL or e.sm IS NULL THEN" /* 引落年月日自動入力の場合*/
                            + " CASE WHEN e.b_id = '0' THEN null"
                                + " WHEN e.b_id = '1' THEN" /* 稚内信金の場合の処理*/
                                    + " CASE WHEN e.sd = '99' THEN" /* 翌月末引落の場合の処理 */
                                            + " target_date(to_date((to_number(c4_y,'999')+diff || '/' || to_number(c4_m,'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                    + " ELSE" /* 翌月末引落以外の場合の処理 */
                                            + " target_date(to_date((to_number(c4_y,'999')+diff || '/' || to_number(c4_m,'99')+1 || '/' || to_number(e.sd,'99')),'yyyy/mm/dd'))"
                                    + " END"
                                + " WHEN e.b_id = '2' THEN" /* ゆうちょ銀行の場合の処理*/
                                    + " CASE WHEN e.sd = '99' THEN" /* 翌月末引落の場合の処理 */
                                            + " target_date(to_date((to_number(c4_y,'999')+diff || '/' || to_number(c4_m,'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                    + " ELSE" /* 翌月末引落以外の場合の処理 */
                                            + " target_date(to_date((to_number(c4_y,'999')+diff || '/' || to_number(c4_m,'99')+1 || '/' || to_number(e.sd,'99')),'yyyy/mm/dd'))"
                                    + " END"
                                + " WHEN e.b_id = '3' THEN" /* 利尻漁協の場合の処理*/
                                    + " CASE WHEN e.sd = '99' THEN" /* 翌月末引落の場合の処理 */
                                            + " target_date(to_date((to_number(c4_y,'999')+diff || '/' || to_number(c4_m,'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                    + " ELSE" /* 翌月末引落以外の場合の処理 */
                                            + " target_date(to_date((to_number(c4_y,'999')+diff || '/' || to_number(c4_m,'99')+1 || '/' || to_number(e.sd,'99')),'yyyy/mm/dd'))"
                                    + " END"
                            + " END"
                        + " ELSE" /* 引落年月日手入力の場合*/
                            + " CASE WHEN e.b_id = '0' THEN null"
                                + " WHEN e.b_id = '1' THEN" /* 稚内信金の場合の処理*/
                                    + " CASE WHEN e.sd = '99' THEN" /* 翌月末引落の場合の処理 */
                                        + " target_date(to_date((to_number(e.sy,'999')+diff || '/' || to_number(e.sm,'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                    + " ELSE" /* 翌月末引落以外の場合の処理 */
                                        + " target_date(to_date((to_number(e.sy,'999')+diff || '/' || to_number(e.sm,'99') || '/' || to_number(e.sd,'99')),'yyyy/mm/dd'))"
                                    + " END"
                                + " WHEN e.b_id = '2' THEN" /* ゆうちょ銀行の場合の処理*/
                                    + " CASE WHEN e.sd = '99' THEN" /* 翌月末引落の場合の処理 */
                                        + " target_date(to_date((to_number(e.sy,'999')+diff || '/' || to_number(e.sm,'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                    + " ELSE" /* 翌月末引落以外の場合の処理 */
                                        + " target_date(to_date((to_number(e.sy,'999')+diff || '/' || to_number(e.sm,'99') || '/' || to_number(e.sd,'99')),'yyyy/mm/dd'))"
                                    + " END"
                                + " WHEN e.b_id = '3' THEN" /* 利尻漁協の場合の処理*/
                                    + " CASE WHEN e.sd = '99' THEN" /* 翌月末引落の場合の処理 */
                                        + " target_date(to_date((to_number(e.sy,'999')+diff || '/' || to_number(e.sm,'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                    + " ELSE" /* 翌月末引落以外の場合の処理 */
                                        + " target_date(to_date((to_number(e.sy,'999')+diff || '/' || to_number(e.sm,'99') || '/' || to_number(e.sd,'99')),'yyyy/mm/dd'))"
                                    + " END"
                            + " END"
                        + " END target_date"
                        + ", CASE WHEN ((h.b_name is null)or(h.b_name = '')) THEN '稚内信用金庫'"
                        + " ELSE h.b_name END b_name"
                        + ", i.c25 shiharaisya"
                        + ", k.gengou"
                        + ", k.g_name"
                        + ", k.start_date"
                        + ", k.end_date"
                        + ", k.diff"
                        + ", j.stuff"
                        + ", m.manager"
                        + " FROM ("
                        + "("
                            + "("
                                + "("
                                    + "("
                                        + "("
                                            + "("
                                                + "("
                                                    + "("
                                                        + "("
                                                            + "("
                                                                + "(SELECT r_id, id, c1, c3, c4, c4_y, c4_m, c22, s_id, o_id, req_id, w_flg"
                                                                + " , time_stamp FROM t_seikyu t1"
                                                                + " WHERE time_stamp = "
                                                                    + "(SELECT max(time_stamp) FROM t_seikyu WHERE"
                                                                    + " s_id = t1.s_id"
                                                                    + " AND o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                                                                    + " AND c4_y::Text = CASE WHEN length('" + Cmb_nen_str + "')=2 THEN"
                                                                                            + " substr('" + Cmb_nen_str + "',1,1) || ' ' || substr('" + Cmb_nen_str + "', length('" + Cmb_nen_str + "')-1+1, length('" + Cmb_nen_str + "'))"
                                                                                        + " ELSE"
                                                                                            + "'" + Cmb_nen_str + "'"
                                                                                        + " END"
                                                                    + " AND c4_m::Text = CASE WHEN length('" + Cmb_tsuki_str + "')=1 THEN"
                                                                    + " ' ' || '" + Cmb_tsuki_str + "'"
                                                                    + " WHEN length('" + Cmb_tsuki_str + "')=2 THEN"
                                                                    + " '' || '" + Cmb_tsuki_str + "'"
                                                                    + " END"
                                                                    + ")"
                                                                + ") a LEFT JOIN (SELECT c4, c5, c6, c7, c9, c11, c14, c15, c16, c19, s_id, o_id,"
                                                                    + " CASE WHEN c7 = '現金' THEN '1'"
                                                                        + " WHEN c7 = Null THEN '1'"
                                                                        + " WHEN c7 = '引落' THEN '2'"
                                                                        + " WHEN c7 = '振込' THEN '2'"
                                                                        + " ELSE '' END 支払方法"
                                                                    + ", time_stamp FROM t_shiharai_houhou t2"
                                                                    + " WHERE time_stamp = "
                                                                                        + "(SELECT max(time_stamp) FROM t_shiharai_houhou WHERE"
                                                                                            + " c4_y::Text = CASE WHEN length('" + Cmb_nen_str + "')=2 THEN"
                                                                                                                    + " substr('" + Cmb_nen_str + "',1,1) || ' ' || substr('" + Cmb_nen_str + "', length('" + Cmb_nen_str + "')-1+1, length('" + Cmb_nen_str + "'))"
                                                                                                                + " ELSE"
                                                                                                                    + "'" + Cmb_nen_str + "'"
                                                                                                                + " END"
                                                                                            + " AND c4_m::Text = CASE WHEN length('" + Cmb_tsuki_str + "')=1 THEN"
                                                                                            + " ' ' || '" + Cmb_tsuki_str + "'"
                                                                                            + " WHEN length('" + Cmb_tsuki_str + "')=2 THEN"
                                                                                            + " '' || '" + Cmb_tsuki_str + "'"
                                                                                            + " END"
                                                                                            + " AND s_id = t2.s_id"
                                                                                            + " AND o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                                                                                        + ")"
                                                                                + ") b ON a.c1 = b.c5"
                                                                                + " AND rtrim(replace(a.c3,substr(a.c3,strpos(a.c3, '('), strpos(a.c3, ')')),''))"
                                                                                    + " = rtrim(replace(b.c6,substr(b.c6,strpos(b.c6, '('), strpos(b.c6, ')')),''))"
                                                                                + " AND a.s_id = b.s_id"
                                                                                + " AND a.o_id = b.o_id"
                                                                                + ")"
                                                                                //+ " AND b.s_id::Integer = " + Cmb_s_id_int + ")"
                                                                        + " LEFT JOIN (SELECT s_id, o_id, syubetsu, hyoujimei FROM t_syubetsu) c ON a.s_id::Text = c.s_id AND a.o_id = c.o_id)"
                                                                    + " LEFT JOIN (SELECT rep_id, pt_id, s_id, o_id, col0, col1, col2, col3, col4, col5, ac0, ac1, ac2, ac3 FROM t_rep) d ON b.支払方法 = d.pt_id AND a.s_id = d.s_id AND a.o_id::Text = d.o_id)"
                                                                + " LEFT JOIN (SELECT bid, b_id, b_code, b_name, sb_name, br_code, br_name, sd, sm, sy FROM t_bank) e ON b.c11 = e.b_name)"
                                                            + " LEFT JOIN (SELECT req_id, title1, title2, title3, title4, data7, data8, title4_kana FROM t_req) f ON a.req_id::Integer = f.req_id)"
                                                        + " LEFT JOIN (SELECT o_id, o_name, o_phone_number FROM t_office) f1 ON a.o_id::Integer = f1.o_id)"
                                                    + " LEFT JOIN (SELECT syutsuryokubi, s_id FROM t_syutsuryokubi) g ON a.s_id = g.s_id)"
                                                + " LEFT JOIN (SELECT bid, b_id, b_code, b_name, sb_name, br_code, br_name, sd FROM t_bank WHERE b_id = '1') h ON b.c11 = h.b_name)"
                                            + " LEFT JOIN (SELECT c1, c5, c25, c48, s_id, o_id FROM t_shinzoku_kankei t3"
                                            + " WHERE c48 = '1' AND time_stamp = "
                                                                            + "(SELECT max(time_stamp) FROM t_shinzoku_kankei WHERE"
                                                                                + " c4_y::Text = CASE WHEN length('" + Cmb_nen_str + "')=2 THEN"
                                                                                                        + " substr('" + Cmb_nen_str + "',1,1) || ' ' || substr('" + Cmb_nen_str + "', length('" + Cmb_nen_str + "')-1+1, length('" + Cmb_nen_str + "'))"
                                                                                                    + " ELSE"
                                                                                                        + "'" + Cmb_nen_str + "'"
                                                                                                    + " END"
                                                                                + " AND c4_m::Text = CASE WHEN length('" + Cmb_tsuki_str + "')=1 THEN"
                                                                                                        + " ' ' || '" + Cmb_tsuki_str + "'"
                                                                                                        + " WHEN length('" + Cmb_tsuki_str + "')=2 THEN"
                                                                                                        + " '' || '" + Cmb_tsuki_str + "'"
                                                                                                        + " END"
                                                                                + " AND s_id = t3.s_id"
                                                                                + " AND o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                                                                            + ")"
                                                        + ") i ON a.c1 = i.c1"
                                                        + " AND a.s_id = i.s_id"
                                                        //+ " AND i.s_id::Integer = " + Cmb_s_id_int
                                                        + " AND i.o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                                            + ") "
                                        + " LEFT JOIN (SELECT gg_id, g_name, gengou, start_date, end_date, diff FROM t_gengou) k ON substr(c4_y,1,1) = k.g_name)"
                                    + " LEFT JOIN (SELECT m_id, manager, start_date, end_date, o_id FROM t_manager) m ON m.o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                                        + " AND m.start_date <= (SELECT to_date((to_number(c4_y,'999')+k.diff || '/' || to_number(c4_m,'99')+1 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                        + " AND (m.end_date Is Null Or m.end_date >= (SELECT to_date((to_number(c4_y,'999')+k.diff || '/' || to_number(c4_m,'99')+1 || '/' || to_number('01','99')),'yyyy/mm/dd')-1) "
                                    + ")"
                                + " LEFT JOIN (SELECT stf_id, stuff, start_date, end_date, o_id FROM t_stuff) j ON j.o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                                    + " AND j.start_date <= (SELECT to_date((to_number(c4_y,'999')+k.diff || '/' || to_number(c4_m,'99')+1 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                    + " AND (j.end_date Is Null Or j.end_date >= (SELECT to_date((to_number(c4_y,'999')+k.diff || '/' || to_number(c4_m,'99')+1 || '/' || to_number('01','99')),'yyyy/mm/dd')-1) "
                                + ")"
                                + " LEFT JOIN (SELECT acc_id, accounting_manager, start_date, end_date, acc_kana FROM t_accounting_manager) L ON "
                                    + " L.start_date <= (SELECT to_date((to_number(c4_y,'999')+k.diff || '/' || to_number(c4_m,'99')+1 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                    + " AND (L.end_date Is Null Or L.end_date >= (SELECT to_date((to_number(c4_y,'999')+k.diff || '/' || to_number(c4_m,'99')+1 || '/' || to_number('01','99')),'yyyy/mm/dd')-1) "
                                + ")"
                            + ") ORDER BY a.id"
                        + ")"
                        + " SELECT"
                        + " r_id"
                        + ", id"
                        + ", c1"
                        + ", c3"
                        + ", c3_mod"
                        + ", c4"
                        + ", c4_y || '/' || c4_m c4_ym"
                        + ", c5"
                        + ", c6_mod"
                        + ", c9"
                        + ", c11"
                        + ", c14"
                        + ", c16"
                        + ", c19"
                        + ", c22"
                        + ", s_id"
                        + ", o_id"
                        + ", w_flg"
                        + ", req_id"
                        + ", syubetsu"
                        + ", 支払方法"
                        + ", 引落口座種別"
                        + ", 事業所名"
                        + ", col0"
                        + ", col1"
                        + ", col2"
                        + ", col3"
                        + ", col4"
                        + ", col5"
                        + ", ac0"
                        + ", ac1"
                        + ", ac2"
                        + ", ac3"
                        + ", 引落口座番号"
                        + ", 引落口座名義人"
                        + ", 引落金融機関銀行名"
                        + ", b_code"
                        + ", b_name"
                        + ", br_code"
                        + ", sb_name"
                        + ", sd"
                        + ", title1"
                        + ", title2"
                        + ", title3"
                        + ", title4"
                        + ", manager"
                        + ", stuff"
                        + ", o_phone_number name5"
                        + ", o_name data6"
                        + ", data7"
                        + ", data8"
                        + ", title4_kana"
                        + ", accounting_manager"
                        + ", acc_kana"
                        + ", syutsuryokubi"
                        + ", _b_code"
                        + ", _br_code"
                        + ", _br_name"
                        + ", shiharaisya"
                        + ", target_date last_day"
                        + ", gengou"
                        + ", g_name"
                        + ", start_date"
                        + ", end_date"
                        + ", diff"
                        + " FROM r"
                        + " WHERE CASE WHEN '" + Cmb_b_code_str + "' ='0000' THEN"
                                + " c9 = ''"
                                + " ELSE"
                                + " c9 = '" + Cmb_b_code_str + "'"
                                + " END;"

                        , m_conn
                                );

                            // update
                            da.UpdateCommand = new NpgsqlCommand(
                                "UPDATE t_seikyu SET w_flg = :w_flg"
                                + " WHERE"
                                //+ " c4_y = '" + Cmb_nen_str + "'AND"
                                //+ " c4_m = '" + Cmb_tsuki_str + "' AND"
                                + " r_id = :r_id;"
                                , m_conn
                                );
                            //da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4_y", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4_y", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            //da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4_y", NpgsqlTypes.NpgsqlDbType.Text) { Value = " + Cmb_nen_str + " });
                            //da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4_m", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4_m", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            //da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4_m", NpgsqlTypes.NpgsqlDbType.Text) { Value = " + Cmb_tsuki_str + " });
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("w_flg", NpgsqlTypes.NpgsqlDbType.Integer, 0, "w_flg", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("r_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "r_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                            // RowUpdate
                            da.RowUpdated += new NpgsqlRowUpdatedEventHandler(WithdrawalRowUpdated);

                            if (withdrawalds.Tables["withdrawal_ds"] != null)
                                withdrawalds.Tables["withdrawal_ds"].Clear();
                            da.Fill(withdrawalds, "withdrawal_ds");

                            bindingSourceWithdrawal.DataSource = withdrawalds;
                            bindingSourceWithdrawal.DataMember = "withdrawal_ds";

                            bindingNavigatorWithdrawal.BindingSource = bindingSourceWithdrawal;

                            dataGridViewWithdrawal.AutoGenerateColumns = false;

                            dataGridViewWithdrawal.DataSource = bindingSourceWithdrawal;

                            dataGridViewWithdrawal.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                            crvSeikyu.Visible = false;
                            bindingNavigatorWithdrawal.Visible = true;
                            dataGridViewWithdrawal.Visible = true;
                        }
                        break;
                    }
            }
        }

        private void WithdrawalRowUpdated(Object sender, NpgsqlRowUpdatedEventArgs e)
        {
            if (e.Status == UpdateStatus.Continue)
            {
                if (e.StatementType == System.Data.StatementType.Insert)
                {
                    Console.WriteLine("変更は、INSERTです！");

                    da.SelectCommand = new NpgsqlCommand
                    (
                    "WITH RECURSIVE r as ("
                    + "SELECT"
                    + " a.r_id"
                    + ", a.c1"
                    + ", a.c3"
                    + ", rtrim(replace(a.c3,substr(a.c3,strpos(a.c3, '('), strpos(a.c3, ')')),'')) c3_mod"
                    + ", a.c4"
                    + ", c.c5"
                    + ", c.c6"
                    + ", rtrim(replace(c.c6,substr(c.c6,strpos(c.c6, '('), strpos(c.c6, ')')),'')) c6_mod"
                    + ", c.c9"
                    + ", c.c11"
                    + ", c.c14"
                    + ", c.c16"
                    + ", c.c19"
                    + ", a.c22"
                    + ", e.hyoujimei s_id_str"
                    + ", a.s_id"
                    + ", a.o_id"
                    + ", a.time_stamp"
                    + ", a.w_flg"
                    + ", a.c4_y"
                    + ", a.c4_m"
                    + " FROM t_seikyu a LEFT JOIN t_shiharai_houhou c"
                    + " ON a.c1 = c.c5"
                    + " AND rtrim(replace(a.c3,substr(a.c3,strpos(a.c3, '('), strpos(a.c3, ')')),''))"
                        + " = rtrim(replace(c.c6,substr(c.c6,strpos(c.c6, '('), strpos(c.c6, ')')),''))"
                    + " AND a.s_id = c.s_id"
                    + " AND a.o_id = c.o_id"
                    + " AND a.w_flg = '1'"
                    + " AND c.c9 = '" + Cmb_b_code_str + "'"
                    + " AND a.o_id::Text= '" + Form_Seikyu_TextBoxO_id + "'"
                    + " LEFT JOIN t_syubetsu e ON a.o_id = e.o_id AND a.s_id = e.s_id"
                    + " WHERE NOT EXISTS ("
                                            + " SELECT 1"
                                            + " FROM t_seikyu b"
                                            + " WHERE a.s_id = b.s_id"
                                            + " AND a.o_id = b.o_id"
                                            + " AND a.c4_y = b.c4_y"
                                            + " AND a.c4_m = b.c4_m"
                                            + " AND a.time_stamp < b.time_stamp"
                                            + " AND a.c4_y::Text = CASE WHEN length('" + Cmb_nen_str + "')=2 THEN"
                                                                    + " substr('" + Cmb_nen_str + "',1,1) || ' ' || substr('" + Cmb_nen_str + "', length('" + Cmb_nen_str + "')-1+1, length('" + Cmb_nen_str + "'))"
                                                                + " ELSE"
                                                                    + "'" + Cmb_nen_str + "'"
                                                                + " END"
                                            + " AND a.c4_m::Text = CASE WHEN length('" + Cmb_tsuki_str + "')=1 THEN"
                                                                    + " ' ' || '" + Cmb_tsuki_str + "'"
                                                                    + " WHEN length('" + Cmb_tsuki_str + "')=2 THEN"
                                                                    + " '' || '" + Cmb_tsuki_str + "'"
                                                                    + " END"
                                        + ")"
                    + " AND a.s_id = c.s_id"
                    + " AND a.o_id = c.o_id"
                    + " AND a.c4_y = c.c4_y"
                    + " AND a.c4_m = c.c4_m"
                    + " AND a.c4_y::Text = CASE WHEN length('" + Cmb_nen_str + "')=2 THEN"
                                            + " substr('" + Cmb_nen_str + "',1,1) || ' ' || substr('" + Cmb_nen_str + "', length('" + Cmb_nen_str + "')-1+1, length('" + Cmb_nen_str + "'))"
                                        + " ELSE"
                                            + "'" + Cmb_nen_str + "'"
                                        + " END"
                    + " AND a.c4_m::Text = CASE WHEN length('" + Cmb_tsuki_str + "')=1 THEN"
                                            + " ' ' || '" + Cmb_tsuki_str + "'"
                                            + " WHEN length('" + Cmb_tsuki_str + "')=2 THEN"
                                            + " '' || '" + Cmb_tsuki_str + "'"
                                            + " END"
                    + " AND NOT EXISTS ("
                                            + " SELECT 1"
                                            + " FROM t_shiharai_houhou d"
                                            + " WHERE c.s_id = d.s_id"
                                            + " AND c.o_id = d.o_id"
                                            + " AND c.c4_y = d.c4_y"
                                            + " AND c.c4_m = d.c4_m"
                                            + " AND c.time_stamp < d.time_stamp"
                                            + " AND c.c4_y::Text = CASE WHEN length('" + Cmb_nen_str + "')=2 THEN"
                                                                    + " substr('" + Cmb_nen_str + "',1,1) || ' ' || substr('" + Cmb_nen_str + "', length('" + Cmb_nen_str + "')-1+1, length('" + Cmb_nen_str + "'))"
                                                                + " ELSE"
                                                                    + "'" + Cmb_nen_str + "'"
                                                                + " END"
                                            + " AND c.c4_m::Text = CASE WHEN length('" + Cmb_tsuki_str + "')=1 THEN"
                                                                    + " ' ' || '" + Cmb_tsuki_str + "'"
                                                                    + " WHEN length('" + Cmb_tsuki_str + "')=2 THEN"
                                                                    + " '' || '" + Cmb_tsuki_str + "'"
                                                                    + " END"
                                       + ")"
                    + " AND a.s_id = c.s_id"
                    + " AND a.o_id = c.o_id"
                    + " AND a.c4_y = c.c4_y"
                    + " AND a.c4_m = c.c4_m"
                    + " AND a.c4_y::Text = CASE WHEN length('" + Cmb_nen_str + "')=2 THEN"
                                            + " substr('" + Cmb_nen_str + "',1,1) || ' ' || substr('" + Cmb_nen_str + "', length('" + Cmb_nen_str + "')-1+1, length('" + Cmb_nen_str + "'))"
                                        + " ELSE"
                                            + "'" + Cmb_nen_str + "'"
                                        + " END"
                    + " AND a.c4_m::Text = CASE WHEN length('" + Cmb_tsuki_str + "')=1 THEN"
                                            + " ' ' || '" + Cmb_tsuki_str + "'"
                                            + " WHEN length('" + Cmb_tsuki_str + "')=2 THEN"
                                            + " '' || '" + Cmb_tsuki_str + "'"
                                            + " END"
                    + " ORDER BY a.s_id, a.c1, a.r_id, a.c4"
                    + ")"
                    + " SELECT"
                    + " distinct array_to_string(ARRAY(SELECT distinct ON (to_number(ltrim(right(c4,2)),'99')) ltrim(right(c4,2)) FROM r"
                        + " WHERE w_flg = '1' ORDER BY to_number(ltrim(right(c4,2)),'99')),'-') title"
                    + ", ltrim(right(r.c4,2)) array_length"
                    + ", r.r_id"
                    + ", r.c1"
                    + ", r.c3"
                    + ", r.c3_mod"
                    + ", r.c4"
                    + ", r.c9"
                    + ", r.c11"
                    + ", r.c14"
                    + ", r.c16"
                    + ", r.c19"
                    + ", r.c22"
                    + ", r.s_id"
                    + ", r.o_id"
                    + ", r.s_id_str"
                    + ", r.w_flg"
                    + ", r.time_stamp"
                    + ", to_number(ltrim(right(c4,2)),'99')"
                    + " FROM r"
                    + " WHERE r.w_flg = '1'"
                    + " AND r.r_id = currval('t_seikyu_r_id_seq')"
                    + " ORDER BY r.s_id, r.c1, r.r_id, to_number(ltrim(right(r.c4,2)),'99');"
                    , m_conn
                    );
                }

                try
                {
                    NpgsqlDataReader reader = da.SelectCommand.ExecuteReader();
                    reader.Read();
                    e.Row["w_flg"] = reader["w_flg"];
                    e.Row["r_id"] = reader["r_id"];
                    reader.Close();
                    //Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }
            else if (e.StatementType == System.Data.StatementType.Update)
            {
                Console.WriteLine("変更は、UPDATEです！");

                da.SelectCommand = new NpgsqlCommand
                (
                    "WITH RECURSIVE r AS ("
                    + "SELECT"
                    + " a.r_id"
                    + ", a.c1"
                    + ", a.c3"
                    + ", a.c4"
                    + ", c.c5"
                    + ", c.c9"
                    + ", c.c11"
                    + ", c.c14"
                    + ", c.c16"
                    + ", c.c19"
                    + ", a.c22"
                    + ", e.hyoujimei s_id_str"
                    + ", a.s_id"
                    + ", a.o_id"
                    + ", a.time_stamp"
                    + ", a.w_flg"
                    + ", a.c4_y"
                    + ", a.c4_m"
                    + " FROM t_seikyu a LEFT JOIN t_shiharai_houhou c"
                    + " ON a.c1 = c.c5"
                    + " AND rtrim(replace(a.c3,substr(a.c3,strpos(a.c3, '('), strpos(a.c3, ')')),'')) = rtrim(replace(c.c6,substr(c.c6,strpos(c.c6, '('), strpos(c.c6, ')')),''))"
                    + " AND a.s_id = c.s_id"
                    + " AND a.o_id = c.o_id"
                    + " AND a.w_flg = '1'"
                    + " AND c.c9 = '" + Cmb_b_code_str + "'"
                    + " LEFT JOIN t_syubetsu e ON a.o_id = e.o_id AND a.s_id = e.s_id"
                    + " WHERE NOT EXISTS ("
                                        + " SELECT 1"
                                        + " FROM t_seikyu b"
                                        + " WHERE a.s_id = b.s_id"
                                        + " AND a.o_id = b.o_id"
                                        + " AND a.c4_y = b.c4_y"
                                        + " AND a.c4_m = b.c4_m"
                                        + " AND a.time_stamp < b.time_stamp"
                                        + " AND a.c4_y::Text = CASE WHEN length('" + Cmb_nen_str + "')=2 THEN"
                                                                    + " substr('" + Cmb_nen_str + "',1,1) || ' ' || substr('" + Cmb_nen_str + "', length('" + Cmb_nen_str + "')-1+1, length('" + Cmb_nen_str + "'))"
                                                                + " ELSE"
                                                                    + "'" + Cmb_nen_str + "'"
                                                                + " END"
                                        + " AND a.c4_m::Text = CASE WHEN length('" + Cmb_tsuki_str + "')=1 then"
                                                                + " ' ' || '" + Cmb_tsuki_str + "'"
                                                                + " WHEN length('" + Cmb_tsuki_str + "')=2 then"
                                                                + " '' || '" + Cmb_tsuki_str + "'"
                                                                + " END"
                                        + ")"
                    + " AND a.s_id = c.s_id"
                    + " AND a.o_id = c.o_id"
                    + " AND a.c4_y = c.c4_y"
                    + " AND a.c4_m = c.c4_m"
                    + " AND NOT EXISTS ("
                                        + " SELECT 1"
                                        + " FROM t_shiharai_houhou d"
                                        + " WHERE c.s_id = d.s_id"
                                        + " AND c.o_id = d.o_id"
                                        + " AND c.s_id = d.s_id"
                                        + " AND c.o_id = d.o_id"
                                        + " AND c.time_stamp < d.time_stamp"
                                        + " AND c.c4_y::Text = CASE WHEN length('" + Cmb_nen_str + "')=2 THEN"
                                                                    + " substr('" + Cmb_nen_str + "',1,1) || ' ' || substr('" + Cmb_nen_str + "', length('" + Cmb_nen_str + "')-1+1, length('" + Cmb_nen_str + "'))"
                                                                + " ELSE"
                                                                    + "'" + Cmb_nen_str + "'"
                                                                + " END"
                                        + " AND c.c4_m::Text = CASE WHEN length('" + Cmb_tsuki_str + "')=1 then"
                                                                + " ' ' || '" + Cmb_tsuki_str + "'"
                                                                + " WHEN length('" + Cmb_tsuki_str + "')=2 then"
                                                                + " '' || '" + Cmb_tsuki_str + "'"
                                                                + " END"
                                        + ")"
                    + " AND a.s_id = c.s_id"
                    + " AND a.o_id = c.o_id"
                    + " AND a.c4_y = c.c4_y"
                    + " AND a.c4_m = c.c4_m"
                    + " AND a.c4_y::Text = CASE WHEN length('" + Cmb_nen_str + "')=2 THEN"
                                                + " substr('" + Cmb_nen_str + "',1,1) || ' ' || substr('" + Cmb_nen_str + "', length('" + Cmb_nen_str + "')-1+1, length('" + Cmb_nen_str + "'))"
                                            + " ELSE"
                                                + "'" + Cmb_nen_str + "'"
                                            + " END"
                    + " AND a.c4_m::Text = CASE WHEN length('" + Cmb_tsuki_str + "')=1 then"
                                            + " ' ' || '" + Cmb_tsuki_str + "'"
                                            + " WHEN length('" + Cmb_tsuki_str + "')=2 then"
                                            + " '' || '" + Cmb_tsuki_str + "'"
                                            + " END"
                    + " ORDER BY a.s_id, a.c1, a.r_id, a.c4"
                    + ")"
                    + " SELECT"
                    + " distinct array_to_string(ARRAY(SELECT distinct ON (to_number(ltrim(right(c4,2)),'99')) ltrim(right(c4,2)) FROM r WHERE w_flg = '1' ORDER BY to_number(ltrim(right(c4,2)),'99')),'-') title"
                    + ", ltrim(right(r.c4,2)) array_length"
                    + ", r.r_id"
                    + ", r.c1"
                    + ", r.c3"
                    + ", r.c4"
                    + ", r.c9"
                    + ", r.c11"
                    + ", r.c14"
                    + ", r.c16"
                    + ", r.c19"
                    + ", r.c22"
                    + ", r.s_id"
                    + ", r.o_id"
                    + ", r.s_id_str"
                    + ", r.w_flg"
                    + ", r.time_stamp"
                    + ", to_number(ltrim(right(c4,2)),'99')"
                    + " FROM r"
                    + " WHERE r.w_flg = '1'"
                    + " AND r.r_id = " + e.Row["r_id"].ToString()
                    + " ORDER BY r.s_id, r.c1, r.r_id, to_number(ltrim(right(r.c4,2)),'99');"
                    , m_conn
                );
            }

            try
            {
                NpgsqlDataReader reader = da.SelectCommand.ExecuteReader();
                reader.Read();
                e.Row["w_flg"] = reader["w_flg"];
                e.Row["r_id"] = reader["r_id"];
                reader.Close();
                //Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void Cmb_prn_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmb_prn_id_int = cmb_prn_id.SelectedIndex + 1;
            Console.WriteLine("Cmb_prn_id_int1 = " + Cmb_prn_id_int);

            switch (Cmb_prn_id_int)
            {
                case 1: // 
                    {
                        cmb_b_code.Visible = false;
                        cmdPrnWithdrawal.Visible = false;
                        checkBoxIni.Visible = false;
                    }
                    break;
                case 2: // 
                    {
                        cmb_b_code.Visible = false;
                        cmdPrnWithdrawal.Visible = false;
                        checkBoxIni.Visible = false;
                    }
                    break;
                case 3: // 
                    {
                        cmb_b_code.Visible = false;
                        cmdPrnWithdrawal.Visible = false;
                        checkBoxIni.Visible = false;
                    }
                    break;
                case 4: // 
                    {
                        cmb_b_code.Visible = false;
                        cmdPrnWithdrawal.Visible = false;
                        checkBoxIni.Visible = false;
                    }
                    break;
                case 5: // 
                    {
                        cmb_b_code.Visible = true;
                        cmdPrnWithdrawal.Visible = true;
                        checkBoxIni.Visible = true;

                    }
                    break;
            }
        }

        private void Cmd_holiday_Click(object sender, EventArgs e)
        {
            Form_holiday Form = new Form_holiday
            {
                WindowState = FormWindowState.Maximized
            };
            Form.ShowDialog();
        }

        private void Cmd_bank_Click(object sender, EventArgs e)
        {
            Form_bank Form = new Form_bank
            {
                WindowState = FormWindowState.Maximized
            };
            Form.ShowDialog();
        }

        private void Cmb_nen_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmb_nen_str = cmb_nen.Text;
            Console.WriteLine("Cmb_nen_str = " + Cmb_nen_str);
        }

        private void Cmb_tsuki_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmb_tsuki_str = cmb_tsuki.Text;
            Console.WriteLine("Cmb_tsuki_str = " + Cmb_tsuki_str);
        }

        private void Cmb_b_code_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmb_b_code_str = cmb_b_code.SelectedValue.ToString();

            //Cmb_b_code_str = cmb_b_code.Text;
            Console.WriteLine("Cmb_b_code_str = " + Cmb_b_code_str);

            //dataGridViewWithdrawal.Columns[0].HeaderText = "選択";
            dataGridViewWithdrawal.Columns[1].HeaderText = "氏名";
            dataGridViewWithdrawal.Columns[2].HeaderText = "支払者";
            dataGridViewWithdrawal.Columns[3].HeaderText = "年月";
            dataGridViewWithdrawal.Columns[4].HeaderText = "銀行ｺｰﾄﾞ";
            dataGridViewWithdrawal.Columns[5].HeaderText = "金融機関名";
            dataGridViewWithdrawal.Columns[6].HeaderText = "支店名";
            dataGridViewWithdrawal.Columns[7].HeaderText = "口座番号";
            dataGridViewWithdrawal.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewWithdrawal.Columns[8].HeaderText = "請求金額";
            dataGridViewWithdrawal.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewWithdrawal.Columns[8].DefaultCellStyle.Format = "#,##0";
            dataGridViewWithdrawal.Columns[9].HeaderText = "種別";
            dataGridViewWithdrawal.Columns[10].HeaderText = "番号";
        }

        private void Cmd_Ins_Click(object sender, EventArgs e)
        {
            int update_count = 0;
            try
            {
                update_count += da.Update(withdrawalds.Tables["withdrawal_ds"].Select(null, null, DataViewRowState.Deleted));
                update_count += da.Update(withdrawalds.Tables["withdrawal_ds"].Select(null, null, DataViewRowState.ModifiedCurrent));
                update_count += da.Update(withdrawalds.Tables["withdrawal_ds"].Select(null, null, DataViewRowState.Added));
            }
            catch (Exception ex)
            {
                MessageBox.Show("レコードの保存に失敗しました。\n\n[内容]\n" + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(update_count.ToString() + "件、保存しました。", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DataGridViewWithdrawal_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

            // 列ヘッダーにチェックボックスを表示
            // 列ヘッダーのみ処理を行う。(CheckBox配置列が先頭列の場合)
            if (e.ColumnIndex == 0 && e.RowIndex == -1)
            {
                using (Bitmap bmp = new Bitmap(100, 100))
                {
                    // チェックボックスの描画領域を確保
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.Transparent);
                    }

                    // 描画領域の中央に配置
                    Point pt1 = new Point((bmp.Width - checkBoxAll.Width) / 2, (bmp.Height - checkBoxAll.Height) / 2);
                    if (pt1.X < 0) pt1.X = 0;
                    if (pt1.Y < 0) pt1.Y = 0;

                    // Bitmapに描画
                    checkBoxAll.DrawToBitmap(bmp, new Rectangle(pt1.X, pt1.Y, bmp.Width, bmp.Height));

                    // DataGridViewの現在描画中のセルの中央に描画
                    int x = (e.CellBounds.Width - bmp.Width) / 2;
                    int y = (e.CellBounds.Height - bmp.Height) / 2;

                    Point pt2 = new Point(e.CellBounds.Left + x, e.CellBounds.Top + y);

                    e.Paint(e.ClipBounds, e.PaintParts);
                    e.Graphics.DrawImage(bmp, pt2);
                    e.Handled = true;
                }
            }
        }

        private void Form_prn_FormClosing(object sender, FormClosingEventArgs e)
        {
            int update_count = 0;
            {
                update_count += da.Update(withdrawalds.Tables["withdrawal_ds"].Select(null, null, DataViewRowState.Deleted));
                update_count += da.Update(withdrawalds.Tables["withdrawal_ds"].Select(null, null, DataViewRowState.ModifiedCurrent));
                update_count += da.Update(withdrawalds.Tables["withdrawal_ds"].Select(null, null, DataViewRowState.Added));
            }
            if (update_count > 0)    // 1件以上更新されていれば確認画面を表示
            {
                if (MessageBox.Show("データが保存されていません。\n本当に閉じますか？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void DataGridViewWithdrawal_CurrentCellDirtyStateChanged(
          object sender, EventArgs e)
        {
            if (dataGridViewWithdrawal.IsCurrentCellDirty)
            {
                //コミットする
                dataGridViewWithdrawal.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        //CellValueChangedイベントハンドラ
        private void DataGridViewWithdrawal_CellValueChanged(
          object sender, DataGridViewCellEventArgs e)
        {
            //チェックボックスの列かどうか調べる
            if (dataGridViewWithdrawal.Columns[e.ColumnIndex].ValueType == typeof(bool))
            {
                MessageBox.Show(
                  string.Format("{0}行目のチェックボックスが{1}に変わりました。",
                  e.RowIndex,
                  dataGridViewWithdrawal[e.ColumnIndex, e.RowIndex].Value));
            }
        }

        private void DataGridViewWithdrawal_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
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

        private void CmdPrnWithdrawal_Click(object sender, EventArgs e)
        {
            switch (Chk_title_str)
            {
                case '0': // 
                    {
                        da.SelectCommand = new NpgsqlCommand
                        (
                        "WITH RECURSIVE h as ("
                        + "WITH RECURSIVE r as ("
                                + "SELECT"
                                + " a.r_id"
                                + ", a.c1"
                                + ", a.c3"
                                + ", rtrim(replace(a.c3,substr(a.c3,strpos(a.c3, '('), strpos(a.c3, ')')),'')) c3_mod"
                                + ", a.c4"
                                + ", c.c5"
                                + ", rtrim(replace(c.c6,substr(c.c6,strpos(c.c6, '('), strpos(c.c6, ')')),'')) c6_mod"
                                + ", c.c6"
                                + ", CASE  c.c9 WHEN '' THEN '0000'"
                                + " ELSE"
                                + " c.c9"
                                + " END c9"
                                + ", c.c11"
                                + ", c.c14"
                                + ", c.c16"
                                + ", c.c19"
                                + ", a.c22"
                                + ", e.hyoujimei s_id_str"
                                + ", a.s_id"
                                + ", a.o_id"
                                + ", a.time_stamp"
                                + ", a.w_flg"
                                + ", a.c4_y"
                                + ", a.c4_m"
                                + ", i.gengou"
                                + ", i.g_name"
                                + ", i.start_date"
                                + ", i.end_date"
                                + ", i.diff"
                                + " FROM t_seikyu a LEFT JOIN t_shiharai_houhou c"
                                + " ON a.c1 = c.c5"
                                + " AND rtrim(replace(a.c3,substr(a.c3,strpos(a.c3, '('), strpos(a.c3, ')')),''))"
                                    + " = rtrim(replace(c.c6,substr(c.c6,strpos(c.c6, '('), strpos(c.c6, ')')),''))"
                                + " AND a.s_id = c.s_id"
                                + " AND a.w_flg = '1'"
                                + " AND CASE c.c9 WHEN '' THEN '0000' ELSE c.c9 END = '" + Cmb_b_code_str + "'"
                                + " AND a.o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                                + " INNER JOIN t_syubetsu e ON a.o_id = e.o_id AND a.s_id = e.s_id"
                                + " INNER JOIN t_gengou i ON substr(a.c4_y,1,1) = i.g_name"
                                + " WHERE NOT EXISTS ("
                                + " SELECT 1"
                                + " FROM t_seikyu b"
                                + " WHERE a.s_id = b.s_id"
                                + " AND a.o_id = b.o_id"
                                + " AND a.c4_y = b.c4_y"
                                + " AND a.c4_m = b.c4_m"
                                //+ " AND a.c4_y::Text = CASE WHEN length('" + Cmb_nen_str + "')=2 THEN"
                                //                            + " substr('" + Cmb_nen_str + "',1,1) || ' ' || substr('" + Cmb_nen_str + "', length('" + Cmb_nen_str + "')-1+1, length('" + Cmb_nen_str + "'))"
                                //                        + " ELSE"
                                //                            + "'" + Cmb_nen_str + "'"
                                //                        + " END"
                                //+ " AND a.c4_m::Text = CASE WHEN length('" + Cmb_tsuki_str + "')=1 then"
                                //                        + " ' ' || '" + Cmb_tsuki_str + "'"
                                //                        + " WHEN length('" + Cmb_tsuki_str + "')=2 then"
                                //                        + " '' || '" + Cmb_tsuki_str + "'"
                                //                        + " END"
                                + " AND a.time_stamp < b.time_stamp)"
                                + " AND a.c4_y = c.c4_y"
                                + " AND a.c4_m = c.c4_m"
                                //+ " AND a.c4_y::Text = CASE WHEN length('" + Cmb_nen_str + "')=2 THEN"
                                //                        + " substr('" + Cmb_nen_str + "',1,1) || ' ' || substr('" + Cmb_nen_str + "', length('" + Cmb_nen_str + "')-1+1, length('" + Cmb_nen_str + "'))"
                                //                    + " ELSE"
                                //                        + "'" + Cmb_nen_str + "'"
                                //                    + " END"
                                //+ " AND a.c4_m::Text = CASE WHEN length('" + Cmb_tsuki_str + "')=1 then"
                                //                        + " ' ' || '" + Cmb_tsuki_str + "'"
                                //                        + " WHEN length('" + Cmb_tsuki_str + "')=2 then"
                                //                        + " '' || '" + Cmb_tsuki_str + "'"
                                //                        + " END"
                                + " AND NOT EXISTS ("
                                + " SELECT 1"
                                + " FROM t_shiharai_houhou d"
                                + " WHERE c.s_id = d.s_id"
                                + " AND c.o_id = d.o_id"
                                + " AND c.c4_y = d.c4_y"
                                + " AND c.c4_m = d.c4_m"
                                //+ " AND c.c4_y::Text = CASE WHEN length('" + Cmb_nen_str + "')=2 THEN"
                                //                        + " substr('" + Cmb_nen_str + "',1,1) || ' ' || substr('" + Cmb_nen_str + "', length('" + Cmb_nen_str + "')-1+1, length('" + Cmb_nen_str + "'))"
                                //                    + " ELSE"
                                //                        + "'" + Cmb_nen_str + "'"
                                //                    + " END"
                                //+ " AND c.c4_m::Text = CASE WHEN length('" + Cmb_tsuki_str + "')=1 then"
                                //                        + " ' ' || '" + Cmb_tsuki_str + "'"
                                //                        + " WHEN length('" + Cmb_tsuki_str + "')=2 then"
                                //                        + " '' || '" + Cmb_tsuki_str + "'"
                                //                        + " END"
                                + " AND c.time_stamp < d.time_stamp)"
                                + " AND a.s_id = c.s_id"
                                + " AND a.o_id = c.o_id"
                                + " AND a.c4_y = c.c4_y"
                                + " AND a.c4_m = c.c4_m"
                                //+ " AND a.c4_y::Text = CASE WHEN length('" + Cmb_nen_str + "')=2 THEN"
                                //                        + " substr('" + Cmb_nen_str + "',1,1) || ' ' || substr('" + Cmb_nen_str + "', length('" + Cmb_nen_str + "')-1+1, length('" + Cmb_nen_str + "'))"
                                //                    + " ELSE"
                                //                        + "'" + Cmb_nen_str + "'"
                                //                    + " END"
                                //+ " AND a.c4_m::Text = CASE WHEN length('" + Cmb_tsuki_str + "')=1 then"
                                //                        + " ' ' || '" + Cmb_tsuki_str + "'"
                                //                        + " WHEN length('" + Cmb_tsuki_str + "')=2 then"
                                //                        + " '' || '" + Cmb_tsuki_str + "'"
                                //                        + " END"
                                + " ORDER BY a.r_id"
                                + ")"
                                + " SELECT"
                                + "'" + Cmb_tsuki_str + "' title"
                                + ", ltrim(right(r.c4,2)) array_length"
                                + ", r.r_id"
                                + ", r.c1"
                                + ", r.c3"
                                + ", r.c3_mod"
                                + ", r.c4"
                                + ", r.c9"
                                + ", r.c11"
                                + ", r.c14"
                                + ", r.c16"
                                + ", r.c19"
                                + ", r.c22"
                                + ", r.s_id"
                                + ", r.s_id_str"
                                + ", r.o_id"
                                + ", r.w_flg"
                                + ", r.time_stamp"
                                + ", to_number(concat(to_number(ltrim(left(c4,3)),'999')+r.diff ,lpad(trim(right(c4,2)),2,'0')),'999999')"
                                + ", r.gengou"
                                + ", r.g_name"
                                + ", r.start_date"
                                + ", r.end_date"
                                + ", r.diff"
                                + " FROM r"
                                + " WHERE r.w_flg = '1'"
                                + " ORDER BY r.r_id, to_number(concat(to_number(ltrim(left(r.c4,3)),'999')+r.diff ,lpad(trim(right(r.c4,2)),2,'0')),'999999')"
                                + " )"
                                    + " SELECT"
                                    + " h.title"
                                    + ", h.array_length"
                                    + ", count(*) OVER (PARTITION BY h.c3) cnt"
                                    + ", h.r_id"
                                    + ", h.c1"
                                    + ", h.c3"
                                    + ", h.c3_mod"
                                    + ", h.c4"
                                    + ", h.c9"
                                    + ", h.c11"
                                    + ", h.c14"
                                    + ", h.c16"
                                    + ", h.c19"
                                    + ", h.c22"
                                    + ", h.s_id sort_s_id"
                                    + ", h.s_id_str as s_id"
                                    + ", h.w_flg"
                                    + ", h.time_stamp"
                                    + ", h.o_id"
                                    + ", CASE WHEN b.sy IS NULL OR b.sm IS NULL THEN" /* 引落年月日自動入力の場合*/
                                        + " CASE WHEN b.b_id = '0' then null"
                                            + " WHEN b.b_id = '1' then" /* 稚内信金の場合の処理*/
                                                + " CASE WHEN b.sd = '99' then" /* 翌月末引落の場合の処理 */
                                                                                + " CASE WHEN '" + Cmb_tsuki_str + "' = '11' Or '" + Cmb_tsuki_str + "' = '12' then" /* 年末12月の場合の処理 */
                                                                                    + " target_date(to_date((to_number('" + Cmb_nen_str + "','999')+h.diff+1 || '/' || to_number('" + Cmb_tsuki_str + "','99')-10 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                                                                + " ELSE"
                                                                                    /* 11, 12月以外の場合の処理 */
                                                                                    + " target_date(to_date((to_number('" + Cmb_nen_str + "','999')+h.diff || '/' || to_number('" + Cmb_tsuki_str + "','99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                                                                + " END"
                                                + " ELSE" /* 翌月末引落以外の場合の処理 */
                                                    + " CASE WHEN '" + Cmb_tsuki_str + "' = '12' then" /* 年末12月の場合の処理 */
                                                        + " target_date(to_date((to_number('" + Cmb_nen_str + "','999')+h.diff+1 || '/' || to_number('" + Cmb_tsuki_str + "','99')-11 || '/' || to_number(b.sd,'99')),'yyyy/mm/dd'))"
                                                    + " ELSE"
                                                        /* 11, 12月以外の場合の処理 */
                                                        + " target_date(to_date((to_number('" + Cmb_nen_str + "','999')+h.diff || '/' || to_number('" + Cmb_tsuki_str + "','99')+1 || '/' || to_number(b.sd,'99')),'yyyy/mm/dd'))"
                                                    + " END"
                                                + " END"
                                            + " WHEN b.b_id = '2' then" /* ゆうちょ銀行の場合の処理*/
                                                + " CASE WHEN b.sd = '99' then" /* 翌月末引落の場合の処理 */
                                                                                + " CASE WHEN '" + Cmb_tsuki_str + "' = '11' Or '" + Cmb_tsuki_str + "' = '12' then" /* 年末12月の場合の処理 */
                                                                                    + " target_date(to_date((to_number('" + Cmb_nen_str + "','999')+h.diff+1 || '/' || to_number('" + Cmb_tsuki_str + "','99')-10 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                                                                + " ELSE"
                                                                                    /* 11, 12月以外の場合の処理 */
                                                                                    + " target_date(to_date((to_number('" + Cmb_nen_str + "','999')+h.diff || '/' || to_number('" + Cmb_tsuki_str + "','99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                                                                + " END"
                                                + " ELSE" /* 翌月末引落以外の場合の処理 */
                                                    + " CASE WHEN '" + Cmb_tsuki_str + "' = '12' then" /* 年末12月の場合の処理 */
                                                        + " target_date(to_date((to_number('" + Cmb_nen_str + "','999')+h.diff+1 || '/' || to_number('" + Cmb_tsuki_str + "','99')-11 || '/' || to_number(b.sd,'99')),'yyyy/mm/dd'))"
                                                    + " ELSE"
                                                        /* 12月以外の場合の処理 */
                                                        + " target_date(to_date((to_number('" + Cmb_nen_str + "','999')+h.diff || '/' || to_number('" + Cmb_tsuki_str + "','99')+1 || '/' || to_number(b.sd,'99')),'yyyy/mm/dd'))"
                                                    + " END"
                                                + " END"
                                            + " WHEN b.b_id = '3' then" /* 利尻漁協の場合の処理*/
                                                + " CASE WHEN b.sd = '99' then" /* 翌月末引落の場合の処理 */
                                                                                + " CASE WHEN '" + Cmb_tsuki_str + "' = '11' Or '" + Cmb_tsuki_str + "' = '12' then" /* 年末12月の場合の処理 */
                                                                                    + " target_date(to_date((to_number('" + Cmb_nen_str + "','999')+h.diff+1 || '/' || to_number('" + Cmb_tsuki_str + "','99')-10 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                                                                + " ELSE"
                                                                                    /* 11, 12月以外の場合の処理 */
                                                                                    + " target_date(to_date((to_number('" + Cmb_nen_str + "','999')+h.diff || '/' || to_number('" + Cmb_tsuki_str + "','99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                                                                + " END"
                                                + " ELSE" /* 翌月末引落以外の場合の処理 */
                                                    + " CASE WHEN '" + Cmb_tsuki_str + "' = '12' then" /* 年末12月の場合の処理 */
                                                        + " target_date(to_date((to_number('" + Cmb_nen_str + "','999')+h.diff+1 || '/' || to_number('" + Cmb_tsuki_str + "','99')-11 || '/' || to_number(b.sd,'99')),'yyyy/mm/dd'))"
                                                    + " ELSE"
                                                        /* 12月以外の場合の処理 */
                                                        + " target_date(to_date((to_number('" + Cmb_nen_str + "','999')+h.diff || '/' || to_number('" + Cmb_tsuki_str + "','99')+1 || '/' || to_number(b.sd,'99')),'yyyy/mm/dd'))"
                                                    + " END"
                                                + " END"
                                        + " END"
                                    + " ELSE" /* 引落年月日手入力の場合*/
                                        + " CASE WHEN b.b_id = '0' then null"
                                            + " WHEN b.b_id = '1' then" /* 稚内信金の場合の処理*/
                                                + " CASE WHEN b.sd = '99' then" /* 翌月末引落の場合の処理 */
                                                    + " target_date(to_date((to_number(b.sy,'999')+h.diff || '/' || to_number(b.sm,'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                                + " ELSE" /* 翌月末引落以外の場合の処理 */
                                                    + " target_date(to_date((to_number(b.sy,'999')+h.diff || '/' || to_number(b.sm,'99') || '/' || to_number(b.sd,'99')),'yyyy/mm/dd'))"
                                                + " END"
                                            + " WHEN b.b_id = '2' then" /* ゆうちょ銀行の場合の処理*/
                                                + " CASE WHEN b.sd = '99' then" /* 翌月末引落の場合の処理 */
                                                    + " target_date(to_date((to_number(b.sy,'999')+h.diff || '/' || to_number(b.sm,'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                                + " ELSE" /* 翌月末引落以外の場合の処理 */
                                                    + " target_date(to_date((to_number(b.sy,'999')+h.diff || '/' || to_number(b.sm,'99') || '/' || to_number(b.sd,'99')),'yyyy/mm/dd'))"
                                                + " END"
                                            + " WHEN b.b_id = '3' then" /* 利尻漁協の場合の処理*/
                                                + " CASE WHEN b.sd = '99' then" /* 翌月末引落の場合の処理 */
                                                    + " target_date(to_date((to_number(b.sy,'999')+h.diff || '/' || to_number(b.sm,'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                                + " ELSE" /* 翌月末引落以外の場合の処理 */
                                                    + " target_date(to_date((to_number(b.sy,'999')+h.diff || '/' || to_number(b.sm,'99') || '/' || to_number(b.sd,'99')),'yyyy/mm/dd'))"
                                                + " END"
                                        + " END"
                                    + " END last_day"
                                    + ", o.o_name data6"
                                    + ", m.manager name3"
                                    + ", x.syubetsu"
                                    + ", x.shisetsumei"
                                    + ", h.gengou"
                                    + ", h.g_name"
                                    + ", h.start_date"
                                    + ", h.end_date"
                                    + ", h.diff"
                            + " FROM h LEFT JOIN t_bank b"
                            + " ON CASE h.c9 WHEN '' THEN '0000' ELSE h.c9 END = b.b_code, t_office o, t_manager m, t_syubetsu x"
                            + " WHERE x.o_id = h.o_id"
                            + " AND x.s_id = h.s_id"
                            + " AND x.o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                            + " AND m.o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                            + " AND o.o_id::Text= '" + Form_Seikyu_TextBoxO_id + "'"
                            + " ORDER BY to_number(concat(to_number(ltrim(left(h.c4,3)),'999')+h.diff ,lpad(trim(right(h.c4,2)),2,'0')),'999999'), h.r_id;"
                            , m_conn
                        );

                        da.SelectCommand.Parameters.Add(new NpgsqlParameter("add_year", NpgsqlTypes.NpgsqlDbType.Text));
                        da.SelectCommand.Parameters.Add(new NpgsqlParameter("add_month", NpgsqlTypes.NpgsqlDbType.Text));
                        da.SelectCommand.Parameters.Add(new NpgsqlParameter("add_day", NpgsqlTypes.NpgsqlDbType.Text));
                        da.SelectCommand.Parameters["add_year"].Value = Cmb_nen_str;
                        da.SelectCommand.Parameters["add_month"].Value = Cmb_tsuki_str;
                        da.SelectCommand.Parameters["add_day"].Value = "1";


                        if (withdrawalds.Tables["withdrawal_ds"] != null)
                            withdrawalds.Tables["withdrawal_ds"].Clear();
                        da.Fill(withdrawalds, "withdrawal_ds");
                        crWithdrawal myReport = new crWithdrawal();
                        myReport.SetDataSource(withdrawalds);
                        myReport.SetParameterValue("r_cmb_o_id_item", cmb_o_id_item);  // 指定したパラメータ値をセット
                        crvSeikyu.ReportSource = myReport;

                        bindingNavigatorWithdrawal.Visible = true;
                        dataGridViewWithdrawal.Visible = false;
                        crvSeikyu.Visible = true;
                    }
                    break;

                case '1': // 
                    {
                        da.SelectCommand = new NpgsqlCommand
                        (
                        "WITH RECURSIVE h AS ("
                        + "WITH RECURSIVE r AS ("
                                + "select"
                                + " a.r_id"
                                + ", a.c1"
                                + ", a.c3"
                                + ", rtrim(replace(a.c3,substr(a.c3,strpos(a.c3, '('), strpos(a.c3, ')')),'')) c3_mod"
                                + ", a.c4"
                                + ", c.c5"
                                + ", rtrim(replace(c.c6,substr(c.c6,strpos(c.c6, '('), strpos(c.c6, ')')),'')) c6_mod"
                                + ", c.c6"
                                + ", CASE  c.c9 WHEN '' THEN '0000'"
                                + " ELSE"
                                + " c.c9"
                                + " END c9"
                                + ", c.c11"
                                + ", c.c14"
                                + ", c.c16"
                                + ", c.c19"
                                + ", a.c22"
                                + ", CASE substr(c.c4,strpos(c.c4, '[')+1, strpos(c.c4, ']')-strpos(c.c4, '[')-1)"
                                + ", e.hyoujimei s_id_str"
                                + ", a.s_id"
                                + ", a.o_id"
                                + ", a.time_stamp"
                                + ", a.w_flg"
                                + ", a.c4_y"
                                + ", a.c4_m"
                                + ", i.gengou"
                                + ", i.g_name"
                                + ", i.start_date"
                                + ", i.end_date"
                                + ", i.diff"
                                + " FROM t_seikyu a LEFT JOIN t_shiharai_houhou c"
                                + " ON a.c1 = c.c5"
                                + " AND rtrim(replace(a.c3,substr(a.c3,strpos(a.c3, '('), strpos(a.c3, ')')),''))"
                                    + " = rtrim(replace(c.c6,substr(c.c6,strpos(c.c6, '('), strpos(c.c6, ')')),''))"
                                + " AND a.s_id = c.s_id"
                                + " AND a.w_flg = '1'"
                                + " AND CASE c.c9 WHEN '' THEN '0000' ELSE c.c9 END = '" + Cmb_b_code_str + "'"
                                + " AND a.o_id = '" + cmb_o_id_str + "'"
                                + " INNER JOIN t_syubetsu e ON a.o_id = e.o_id AND a.s_id = e.s_id"
                                + " INNER JOIN t_gengou i ON substr(a.c4_y,1,1) = i.g_name"
                                + " WHERE NOT EXISTS ("
                                + " SELECT 1"
                                + " FROM t_seikyu b"
                                + " WHERE a.s_id = b.s_id"
                                + " AND a.o_id = b.o_id"
                                + " AND a.c4_y = b.c4_y"
                                + " AND a.c4_m = b.c4_m"
                                //+ " AND a.c4_y::Text = CASE WHEN length('" + Cmb_nen_str + "')=2 THEN"
                                //                        + " substr('" + Cmb_nen_str + "',1,1) || ' ' || substr('" + Cmb_nen_str + "', length('" + Cmb_nen_str + "')-1+1, length('" + Cmb_nen_str + "'))"
                                //                    + " ELSE"
                                //                        + "'" + Cmb_nen_str + "'"
                                //                    + " END"
                                //+ " AND a.c4_m::Text = CASE WHEN length('" + Cmb_tsuki_str + "')=1 then"
                                //                        + " ' ' || '" + Cmb_tsuki_str + "'"
                                //                        + " WHEN length('" + Cmb_tsuki_str + "')=2 then"
                                //                        + " '' || '" + Cmb_tsuki_str + "'"
                                //                        + " END"
                                + " AND a.time_stamp < b.time_stamp)"
                                + " AND a.s_id = c.s_id"
                                + " AND a.o_id = c.o_id"
                                + " AND a.c4_y = c.c4_y"
                                + " AND a.c4_m = c.c4_m"
                                //+ " AND a.c4_y::Text = CASE WHEN length('" + Cmb_nen_str + "')=2 THEN"
                                //                        + " substr('" + Cmb_nen_str + "',1,1) || ' ' || substr('" + Cmb_nen_str + "', length('" + Cmb_nen_str + "')-1+1, length('" + Cmb_nen_str + "'))"
                                //                    + " ELSE"
                                //                        + "'" + Cmb_nen_str + "'"
                                //                    + " END"
                                //+ " AND a.c4_m::Text = CASE WHEN length('" + Cmb_tsuki_str + "')=1 then"
                                //                        + " ' ' || '" + Cmb_tsuki_str + "'"
                                //                        + " WHEN length('" + Cmb_tsuki_str + "')=2 then"
                                //                        + " '' || '" + Cmb_tsuki_str + "'"
                                //                        + " END"
                                + " AND NOT EXISTS ("
                                + " SELECT 1"
                                + " FROM t_shiharai_houhou d"
                                + " WHERE c.s_id = d.s_id"
                                + " AND c.o_id = d.o_id"
                                + " AND c.c4_y = d.c4_y"
                                + " AND c.c4_m = d.c4_m"
                                //+ " AND c.c4_y::Text = CASE WHEN length('" + Cmb_nen_str + "')=2 THEN"
                                //                        + " substr('" + Cmb_nen_str + "',1,1) || ' ' || substr('" + Cmb_nen_str + "', length('" + Cmb_nen_str + "')-1+1, length('" + Cmb_nen_str + "'))"
                                //                    + " ELSE"
                                //                        + "'" + Cmb_nen_str + "'"
                                //                    + " END"
                                //+ " AND c.c4_m::Text = CASE WHEN length('" + Cmb_tsuki_str + "')=1 then"
                                //                        + " ' ' || '" + Cmb_tsuki_str + "'"
                                //                        + " WHEN length('" + Cmb_tsuki_str + "')=2 then"
                                //                        + " '' || '" + Cmb_tsuki_str + "'"
                                //                        + " END"
                                + " AND c.time_stamp < d.time_stamp)"
                                + " AND a.c4_y = c.c4_y"
                                + " AND a.c4_m = c.c4_m"
                                //+ " AND a.c4_y::Text = CASE WHEN length('" + Cmb_nen_str + "')=2 THEN"
                                //                        + " substr('" + Cmb_nen_str + "',1,1) || ' ' || substr('" + Cmb_nen_str + "', length('" + Cmb_nen_str + "')-1+1, length('" + Cmb_nen_str + "'))"
                                //                    + " ELSE"
                                //                        + "'" + Cmb_nen_str + "'"
                                //                    + " END"
                                //+ " AND a.c4_m::Text = CASE WHEN length('" + Cmb_tsuki_str + "')=1 then"
                                //                        + " ' ' || '" + Cmb_tsuki_str + "'"
                                //                        + " WHEN length('" + Cmb_tsuki_str + "')=2 then"
                                //                        + " '' || '" + Cmb_tsuki_str + "'"
                                //                        + " END"
                                + " ORDER BY a.r_id"
                                + ")"
                                + " SELECT"
                                + " distinct array_to_string(ARRAY(select distinct ON (to_number(concat(to_number(ltrim(left(r.c4,3)),'999')+r.diff ,lpad(trim(right(r.c4,2)),2,'0')),'999999')) ltrim(right(r.c4,2)) FROM t_seikyu"
                                + " INNER JOIN t_shiharai_houhou s"
                                + " ON r.c1 = s.c5 AND r.c3 = s.c6"
                                + " WHERE w_flg = '1' AND s.c9 = '" + Cmb_b_code_str + "' ORDER BY to_number(concat(to_number(ltrim(left(r.c4,3)),'999')+r.diff ,lpad(trim(right(r.c4,2)),2,'0')),'999999')),'-') title"
                                + ", ltrim(right(r.c4,2)) array_length"
                                + ", r.r_id"
                                + ", r.c1"
                                + ", r.c3"
                                + ", r.c3_mod"
                                + ", r.c4"
                                + ", r.c9"
                                + ", r.c11"
                                + ", r.c14"
                                + ", r.c16"
                                + ", r.c19"
                                + ", r.c22"
                                + ", r.s_id"
                                + ", r.s_id_str"
                                + ", r.w_flg"
                                + ", r.time_stamp"
                                + ", r.o_id"
                                + ", to_number(concat(to_number(ltrim(left(c4,3)),'999')+r.diff ,lpad(trim(right(c4,2)),2,'0')),'999999')"
                                + ", r.gengou"
                                + ", r.g_name"
                                + ", r.start_date"
                                + ", r.end_date"
                                + ", r.diff"
                                + " FROM r"
                                + " WHERE r.w_flg = '1'"
                                + " ORDER BY r.r_id, to_number(concat(to_number(ltrim(left(r.c4,3)),'999')+r.diff ,lpad(trim(right(r.c4,2)),2,'0')),'999999')"
                                + " )"
                                    + " SELECT"
                                    + " h.title"
                                    + ", h.array_length"
                                    + ", count(*) OVER (PARTITION BY h.c3) cnt"
                                    + ", h.r_id"
                                    + ", h.c1"
                                    + ", h.c3"
                                    + ", h.c3_mod"
                                    + ", h.c4"
                                    + ", h.c9"
                                    + ", h.c11"
                                    + ", h.c14"
                                    + ", h.c16"
                                    + ", h.c19"
                                    + ", h.c22"
                                    + ", h.s_id sort_s_id"
                                    + ", h.s_id_str AS s_id"
                                    + ", h.o_id"
                                    + ", h.w_flg"
                                    + ", h.time_stamp"
                                    + ", CASE WHEN b.sy IS NULL or b.sm IS NULL then" /* 引落年月日自動入力の場合*/
                                        + " CASE WHEN b.b_id = '0' then null"
                                            + " WHEN b.b_id = '1' then" /* 稚内信金の場合の処理*/
                                                                        + " CASE WHEN b.sd = '99' then" /* 翌月末引落の場合の処理 */
                                                                                + " target_date(to_date((to_number('" + Cmb_nen_str + "','999')+h.diff || '/' || to_number('" + Cmb_tsuki_str + "','99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                                                        + " ELSE" /* 翌月末引落以外の場合の処理 */
                                                                                + " target_date(to_date((to_number('" + Cmb_nen_str + "','999')+h.diff || '/' || to_number('" + Cmb_tsuki_str + "','99')+1 || '/' || to_number(b.sd,'99')),'yyyy/mm/dd'))"
                                                                        + " END"
                                            + " WHEN b.b_id = '2' then" /* ゆうちょ銀行の場合の処理*/
                                                + " CASE WHEN b.sd = '99' then" /* 翌月末引落の場合の処理 */
                                                        + " target_date(to_date((to_number('" + Cmb_nen_str + "','999')+h.diff || '/' || to_number('" + Cmb_tsuki_str + "','99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                                + " ELSE" /* 翌月末引落以外の場合の処理 */
                                                        + " target_date(to_date((to_number('" + Cmb_nen_str + "','999')+h.diff || '/' || to_number('" + Cmb_tsuki_str + "','99')+1 || '/' || to_number(b.sd,'99')),'yyyy/mm/dd'))"
                                                + " END"
                                            + " WHEN b.b_id = '3' then" /* 利尻漁協の場合の処理*/
                                                + " CASE WHEN b.sd = '99' then" /* 翌月末引落の場合の処理 */
                                                        + " target_date(to_date((to_number('" + Cmb_nen_str + "','999')+h.diff || '/' || to_number('" + Cmb_tsuki_str + "','99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                                + " ELSE" /* 翌月末引落以外の場合の処理 */
                                                        + " target_date(to_date((to_number('" + Cmb_nen_str + "','999')+h.diff || '/' || to_number('" + Cmb_tsuki_str + "','99')+1 || '/' || to_number(b.sd,'99')),'yyyy/mm/dd'))"
                                                + " END"
                                        + " END"
                                    + " ELSE" /* 引落年月日手入力の場合*/
                                        + " CASE WHEN b.b_id = '0' then null"
                                            + " WHEN b.b_id = '1' then" /* 稚内信金の場合の処理*/
                                                + " CASE WHEN b.sd = '99' then" /* 翌月末引落の場合の処理 */
                                                    + " target_date(to_date((to_number(b.sy,'999')-12+2000 || '/' || to_number(b.sm,'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                                + " ELSE" /* 翌月末引落以外の場合の処理 */
                                                    + " target_date(to_date((to_number(b.sy,'999')-12+2000 || '/' || to_number(b.sm,'99') || '/' || to_number(b.sd,'99')),'yyyy/mm/dd'))"
                                                + " END"
                                            + " WHEN b.b_id = '2' then" /* ゆうちょ銀行の場合の処理*/
                                                + " CASE WHEN b.sd = '99' then" /* 翌月末引落の場合の処理 */
                                                    + " target_date(to_date((to_number(b.sy,'999')-12+2000 || '/' || to_number(b.sm,'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                                + " ELSE" /* 翌月末引落以外の場合の処理 */
                                                    + " target_date(to_date((to_number(b.sy,'999')-12+2000 || '/' || to_number(b.sm,'99') || '/' || to_number(b.sd,'99')),'yyyy/mm/dd'))"
                                                + " END"
                                            + " WHEN b.b_id = '3' then" /* 利尻漁協の場合の処理*/
                                                + " CASE WHEN b.sd = '99' then" /* 翌月末引落の場合の処理 */
                                                    + " target_date(to_date((to_number(b.sy,'999')-12+2000 || '/' || to_number(b.sm,'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                                + " ELSE" /* 翌月末引落以外の場合の処理 */
                                                    + " target_date(to_date((to_number(b.sy,'999')-12+2000 || '/' || to_number(b.sm,'99') || '/' || to_number(b.sd,'99')),'yyyy/mm/dd'))"
                                                + " END"
                                        + " END"
                                    + " END last_day"
                                    + ", o.o_name data6"
                                    + ", m.manager name3"
                                    + ", x.syubetsu"
                                    + ", h.gengou"
                                    + ", h.g_name"
                                    + ", h.start_date"
                                    + ", h.end_date"
                                    + ", h.diff"
                            + " FROM h LEFT JOIN t_bank b"
                            + " ON CASE h.c9 WHEN '' THEN '0000' ELSE h.c9 END = b.b_code, t_office o, t_manager m, t_syubetsu x"
                            + " WHERE x.o_id = h.o_id"
                            + " AND x.s_id = h.s_id"
                            + " AND x.o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                            + " AND m.o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                            + " AND o.o_id::Text= '" + Form_Seikyu_TextBoxO_id + "'"
                            + " ORDER BY to_number(concat(to_number(ltrim(left(h.c4,3)),'999')+h.diff ,lpad(trim(right(h.c4,2)),2,'0')),'999999'), h.r_id;"
                        , m_conn
                        );

                        if (withdrawalds.Tables["withdrawal_ds"] != null)
                            withdrawalds.Tables["withdrawal_ds"].Clear();
                        da.Fill(withdrawalds, "withdrawal_ds");

                        crWithdrawal myReport = new crWithdrawal();
                        myReport.SetDataSource(withdrawalds);
                        myReport.SetParameterValue("r_cmb_o_id_item", cmb_o_id_item);  // 指定したパラメータ値をセット
                        //myReport.SetParameterValue("Cmb_nen_str", Cmb_nen_str);  // 指定したパラメータ値をセット
                        //myReport.SetParameterValue("Cmb_tsuki_str", Cmb_tsuki_str);  // 指定したパラメータ値をセット
                        crvSeikyu.ReportSource = myReport;

                        bindingNavigatorWithdrawal.Visible = true;
                        dataGridViewWithdrawal.Visible = false;
                        crvSeikyu.Visible = true;
                    }
                    break;
            }
        }

        private void DataGridViewWithdrawal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        // 列ヘッダーのチェックボックスを押したときに、すべて選択用のチェックボックス状態を切り替え
        private void DataGridViewWithdrawal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex == -1)
            {
                checkBoxAll.Checked = !checkBoxAll.Checked;
            }
        }

        // すべての行のチェック状態を切り替える
        private void CheckBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridViewWithdrawal.Rows)
            {
                row.Cells[0].Value = checkBoxAll.Checked;
            }
        }

        private void Chk_title_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_title.Checked)
            {
                //Chk_title.Text = "Checked";
                Chk_title_str = '1';
            }
            else
            {
                //Chk_title.Text = "Unchecked";
                Chk_title_str = '0';
            }
        }

        public char Chk_title_str { get; set; }
    }
}
