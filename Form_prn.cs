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

        public int cmb_n_id_int { get; set; }
        public int cmb_t_id_int { get; set; }
        public int cmb_p_id_int { get; set; }
        public int cmb_prn_id_int { get; set; }
        public int cmb_req_id_int { get; set; }
        public int cmb_s_id_int { get; set; }
        public int _year { get; set; }
        public int _month { get; set; }
        public int _day { get; set; }

        public object cmb_n_id_str { get; set; }
        public object cmb_t_id_str { get; set; }
        public string cmb_s_id_str { get; set; }
        public string cmb_req_id_str { get; set; }
        public string cmb_c4_str { get; set; }
        public string cmb_nen_str { get; set; }
        public string cmb_tsuki_str { get; set; }
        public string cmb_b_code_str { get; set; }
        public int cmb_o_id_int { get; set; }
        public string StrDateTime { get; set; }

        public String cmb_o_id_str;
        public String cmb_o_id_item;

        private Form_seikyu form_seikyu_Instance;

        public Form_prn()
        {
            InitializeComponent();

            //Form_seikyuのインスタンスを取得
            form_seikyu_Instance = Form_seikyu.Form_seikyu_Instance;
            //Form_seikyuのテキストボックス文字列を
            //Form_prnの文字列変数cmb_o_id_strへ設定
            cmb_o_id_str = form_seikyu_Instance.cmb_o_id_Text;
            cmb_o_id_item = form_seikyu_Instance.cmb_o_id_Item;
            Console.WriteLine("cmb_o_idからのメンバーは、" + cmb_o_id_item);

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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormPrn_Load(object sender, EventArgs e)
        {
            //FormWaiting formWaiting = new FormWaiting();
            //formWaiting.Show();
            //formWaiting.Refresh();
            chk_title_str = '0';
            this.Width = Screen.GetBounds(this).Width;
            this.Height = Screen.GetBounds(this).Height - 30;
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;

            Console.WriteLine("Form_prn_cmb_o_id_str = " + cmb_o_id_str);


            nen_da.SelectCommand = new NpgsqlCommand
            (
                   "select"
                + " n_id"
                + ", nen"
                + " from"
                + " t_nen"
                + " order by n_id;",
                m_conn
            );

            tsuki_da.SelectCommand = new NpgsqlCommand
            (
                   "select"
                + " t_id"
                + ", tsuki"
                + " from"
                + " t_tsuki"
                + " order by t_id;",
                m_conn
            );

            da.SelectCommand = new NpgsqlCommand
            (
                "select"
                + " r_id"
                + ", c1"
                + ", c2"
                + ", c3"
                + ", c4"
                + ", c4_array"
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
                + " from t_seikyu"
                + " order by r_id;"
                , m_conn
            );

            prn_id_da.SelectCommand = new NpgsqlCommand
            (
                   "select"
                + " ps_id"
                + ", syubetsu"
                + " from"
                + " t_prn_syubetsu"
                + " order by ps_id;",
                m_conn
            );

            c4_da.SelectCommand = new NpgsqlCommand
            (
                   "select"
                + " distinct"
                + " c4"
                + " from"
                + " t_seikyu"
                + " order by c4;",
                m_conn
            );

            s_id_da.SelectCommand = new NpgsqlCommand
            (
                   "select"
                + " s_id"
                + ", syubetsu"
                + ", shisetsumei"
                + ", o_id"
                + " from"
                + " t_syubetsu"
                + " where o_id = " + cmb_o_id_str
                //+ " and s_id = '" + cmb_s_id_int + "'"
                + " order by s_id;",
                m_conn
            );

            req_id_da.SelectCommand = new NpgsqlCommand
            (
                   "select"
                + " req_id"
                + ", title1"
                + ", title2"
                + ", name1"
                + ", title3"
                + ", title4"
                + ", name2"
                + " from"
                + " t_req"
                + " order by req_id;",
                m_conn
            );

            b_code_da.SelectCommand = new NpgsqlCommand
            (
                "select"
                + " b_code"
                + ", b_name"
                + ", b_id"
                + " from"
                + " t_bank"
                + " order by b_id;",
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
            cmb_prn_id.SelectedIndexChanged += new EventHandler(cmb_prn_id_SelectedIndexChanged);

            cmb_c4.DataSource = c4_ds.Tables["c4"];
            cmb_c4.DisplayMember = "c4";
            cmb_c4.ValueMember = "c4";
            this.cmb_c4.SelectedIndex = 0;
            cmb_c4.SelectedIndexChanged += new EventHandler(cmb_c4_SelectedIndexChanged);

            cmb_s_id.DataSource = s_id_ds.Tables["t_syubetsu"];
            cmb_s_id.DisplayMember = "syubetsu";
            cmb_s_id.ValueMember = "s_id";
            this.cmb_s_id.SelectedIndex = 0;
            cmb_s_id.SelectedIndexChanged += new EventHandler(cmb_s_id_SelectedIndexChanged);

            cmb_req_id.DataSource = req_id_ds.Tables["t_req"];
            cmb_req_id.DisplayMember = "name1";
            cmb_req_id.ValueMember = "req_id";
            //this.cmb_req_id.SelectedIndex = 0;
            cmb_req_id.SelectedIndexChanged += new EventHandler(cmb_req_id_SelectedIndexChanged);

            cmb_b_code.DataSource = b_codeds.Tables["t_bank"];
            cmb_b_code.DisplayMember = "b_name";
            cmb_b_code.ValueMember = "b_code";
            //this.cmb_req_id.SelectedIndex = 0;
            cmb_b_code.SelectedIndexChanged += new EventHandler(cmb_b_code_SelectedIndexChanged);


            //formWaiting.Close();


            double val = 1.5;

            double ret1 = Math.Floor(val);
            //1
            double ret2 = Math.Truncate(val);

            //1

            if (ds.Tables["seikyu"] != null)
                ds.Tables["seikyu"].Clear();
            da.Fill(ds, "seikyu");

            bindingNavigatorWithdrawal.Visible = false;
            dataGridViewWithdrawal.Visible = false;

            DataGridViewEvent();

        }

        private void DataGridViewEvent()
        {
            //dataGridViewWithdrawal.DefaultValuesNeeded += new DataGridViewRowEventHandler(dataGridViewWithdrawal_DefaultValuesNeeded);

            dataGridViewWithdrawal.CellMouseMove += new DataGridViewCellMouseEventHandler(dataGridViewWithdrawal_CellMouseMove);

            //dataGridViewWithdrawal.CellValidating += new DataGridViewCellValidatingEventHandler(dataGridViewWithdrawal_CellValidating);

            //dataGridViewWithdrawal.CellEnter += new DataGridViewCellEventHandler(dataGridView_CellEnter);

            //dataGridViewWithdrawal.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView_EditingControlShowing);

            dataGridViewWithdrawal.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridViewWithdrawal_CellPainting);
            //dataGridViewWithdrawal.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridViewWithdrawal_CellFormatting);
            //dataGridViewWithdrawal.CellValueChanged += new DataGridViewCellEventHandler(dataGridViewWithdrawal_CellValueChanged);

        }
        private void cmb_req_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_req_id_int = cmb_req_id.SelectedIndex + 1;
            Console.WriteLine("cmb_req_id_int1 = " + cmb_req_id_int);
            cmb_req_id_str = cmb_req_id.Text;
            Console.WriteLine("cmb_req_id_str1 = " + cmb_req_id_str);
        }

        private void cmb_p_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_p_id_int = cmb_p_id.SelectedIndex + 1;
            Console.WriteLine("cmb_p_id_int1 = " + cmb_p_id_int);
        }

        private void cmb_s_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_s_id_int = cmb_s_id.SelectedIndex + 1;
            //cmb_s_id_int = int.Parse(cmb_s_id.SelectedValue.ToString());
            Console.WriteLine("cmb_s_id_int1 = " + cmb_s_id_int);
            cmb_s_id_str = cmb_s_id.Text;
            Console.WriteLine("cmb_s_id_str1 = " + cmb_s_id_str);
        }

        private void cmb_c4_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_c4_str = cmb_c4.Text;
            Console.WriteLine("cmb_c4_str1 = " + cmb_c4_str);
        }

        private void cmdPrv_Click(object sender, EventArgs e)
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
                    "select * from t_syutsuryokubi"
                    + " where s_id::Integer = " + cmb_s_id_int.ToString(), m_conn);

                NpgsqlCommand command = new NpgsqlCommand(
                    "select"
                    + " count(*)"
                    + " from"
                    + " t_syutsuryokubi"
                    + " where s_id::Integer = " + cmb_s_id_int.ToString()
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
                        "delete"
                        + " from t_syutsuryokubi"
                        + " where s_id::Integer = " + cmb_s_id_int.ToString()
                        , m_conn);
                        command.ExecuteNonQuery();
                    }
                }

                da.InsertCommand = new NpgsqlCommand(
                       "insert into t_syutsuryokubi ("
                    + "syutsuryokubi, s_nen, s_tsuki, s_hi, s_id"
                    + " ) values ("
                    + " :syutsuryokubi, :s_nen, :s_tsuki, :s_hi, :s_id"
                    + ")"
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
                dr["s_id"] = cmb_s_id_int;

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

            switch (cmb_prn_id_int)
            {
                case 1: // 納額通知書
                    {
                        da.SelectCommand = new NpgsqlCommand
                        (
                        "with recursive r as ("
                        + "select"
                        + " c1"
                        + ", c2"
                        + ", c3"
                        + ", rtrim(replace(c3,substr(c3,strpos(c3, '('), strpos(c3, ')')),'')) c3_mod"
                        + ", c4"
                        + ", c4_array"
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
                        + ", name1"
                        + ", title3"
                        + ", title4"
                        + ", name2"
                        + ", syutsuryokubi"
                        + ", s_nen"
                        + ", s_tsuki"
                        + ", s_hi"
                        + ", srb_id"
                        + ", time_stamp"
                        + ", t_seikyu.id"
                        + " from"
                        + " (((t_seikyu inner join t_syubetsu"
                        + " on t_seikyu.s_id::integer = t_syubetsu.s_id and t_seikyu.o_id::integer = t_syubetsu.o_id)"
                        + " inner join t_par on t_seikyu.p_id::integer = t_par.p_id)"
                        + " inner join t_req on t_seikyu.req_id::integer = t_req.req_id)"
                        + " inner join t_syutsuryokubi on t_seikyu.s_id::text = t_syutsuryokubi.s_id"
                        + " order by id"
                        + ")"
                        + "select"
                        + " r.c1"
                        + ", r.c2"
                        + ", r.c3"
                        + ", r.c3_mod"
                        + ", r.c4"
                        + ", to_date((to_number(r.c4_array[1],'999')-12+2000 || '/' || r.c4_array[2] || '/' || 1),'yyyy/mm/dd') first_date"
                        + ", case when left(r.c4_array[1],1) = 'H' then '平成' end as gengou"
                        + ", cast(case when date_part('month', to_date((to_number(r.c4_array[1],'999')-12+2000 || '/' || r.c4_array[2] || '/' || 1),'yyyy/mm/dd')::timestamp) < 4 then"
                        + " to_number(r.c4_array[1],'999')-1 else to_number(r.c4_array[1],'999') end as text) as nendo"
                        + ", to_number(r.c4_array[1],'999')::text as nen"
                        + ", to_number(r.c4_array[2],'99')::text as tsuki"
                        + ", rank() over (partition by r.c4, r.s_id order by r.c1)::text as noufusyo_bangou"
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
                        + ", r.name1"
                        + ", r.title3"
                        + ", r.title4"
                        + ", r.name2"
                        + ", r.syutsuryokubi"
                        + ", r.s_nen"
                        + ", r.s_tsuki"
                        + ", r.s_hi"
                        + ", r.srb_id"
                        + ", r.time_stamp"
                        + " from r"
                        + " left join (select c4, c5, c6, c7, c9, c11, c14, c15, c16, c17, c19, s_id, case when c7 = '現金' then '1' when c7 = '引落' then '2' when c7 = '振込' then '2' else '' end 支払方法, time_stamp from t_shiharai_houhou"
                        + " where time_stamp = (select max(time_stamp) from t_shiharai_houhou where"
                            + " c4_array[1]::text || '/' || c4_array[2]::Text = "
                            + " case when length('" + cmb_tsuki_str + "')=1 then"
                            + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                            + "       when length('" + cmb_tsuki_str + "')=2 then"
                            + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                            + " end"
                            + " and s_id::Integer = " + cmb_s_id_int
                        + ")) s on r.c1 = s.c5 and rtrim(replace(r.c3,substr(r.c3,strpos(r.c3, '('), strpos(r.c3, ')')),'')) = rtrim(replace(s.c6,substr(s.c6,strpos(s.c6, '('), strpos(s.c6, ')')),'')) and r.s_id = s.s_id and s.s_id::Integer = " + cmb_s_id_int
                        + " where"
                        + " r.s_id::Integer = " + cmb_s_id_int
                        + " and r.time_stamp = (select max(time_stamp) from t_seikyu where s_id::Integer = " + cmb_s_id_int
                            + " and c4_array[1]::text || '/' || c4_array[2]::Text = "
                            + " case when length('" + cmb_tsuki_str + "')=1 then"
                            + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                            + "       when length('" + cmb_tsuki_str + "')=2 then"
                            + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                            + " end)"
                            + " and r.c4_array[1]::text || '/' || r.c4_array[2]::Text = "
                            + " case when length('" + cmb_tsuki_str + "')=1 then"
                            + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                            + "       when length('" + cmb_tsuki_str + "')=2 then"
                            + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                            + " end"
                        + " and r.req_id::Integer = :req_id"
                        + " order by r.id;"
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

                        if (cmb_req_id.SelectedItem == null)
                        {
                            da.SelectCommand.Parameters.Add(new NpgsqlParameter("req_id",
                            NpgsqlTypes.NpgsqlDbType.Integer, 0, "req_id",
                            ParameterDirection.Input, false, 0, 0, DataRowVersion.Current,
                            DBNull.Value));
                        }
                        else
                        {
                            DataRowView row = (DataRowView)cmb_req_id.SelectedItem;
                            da.SelectCommand.Parameters.AddWithValue("req_id", row["req_id"]);
                        }

                        if (ds.Tables["seikyu"] != null)
                            ds.Tables["seikyu"].Clear();
                        da.Fill(ds, "seikyu");

                        crNoufusyo myReport = new crNoufusyo();
                        myReport.SetDataSource(ds);

                        myReport.SetParameterValue("s_id", cmb_s_id_int.ToString());
                        myReport.SetParameterValue("req_id", cmb_req_id_int.ToString());

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
                        "with recursive r as ("
                        + "select"
                        + " c1"
                        + ", c2"
                        + ", c3"
                        + ", rtrim(replace(c3,substr(c3,strpos(c3, '('), strpos(c3, ')')),'')) c3_mod"
                        + ", rtrim(substr(c3,strpos(c3, '('), strpos(c3, ')'))) c3_flg"
                        + ", c4"
                        + ", c4_array"
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
                        + ", name1"
                        + ", title3"
                        + ", title4"
                        + ", name2"
                        + ", syutsuryokubi"
                        + ", s_nen"
                        + ", s_tsuki"
                        + ", s_hi"
                        + ", srb_id"
                        + ", time_stamp"
                        + ", t_seikyu.id"
                        + " from"
                        + " (((t_seikyu inner join t_syubetsu"
                        + " on t_seikyu.s_id::integer = t_syubetsu.s_id and t_seikyu.o_id::integer = t_syubetsu.o_id)"
                        + " inner join t_par on t_seikyu.p_id::integer = t_par.p_id)"
                        + " inner join t_req on t_seikyu.req_id::integer = t_req.req_id)"
                        + " inner join t_syutsuryokubi on t_seikyu.s_id::text = t_syutsuryokubi.s_id"
                        + " order by id"
                        + ")"
                        + "select"
                        + " r.c1"
                        + ", r.c2"
                        + ", r.c3"
                        + ", r.c3_mod"
                        + ", r.c3_flg"
                        + ", r.c4"
                        + ", to_date((to_number(r.c4_array[1],'999')-12+2000 || '/' || r.c4_array[2] || '/' || 1),'yyyy/mm/dd') first_date"
                        + ", case when left(r.c4_array[1],1) = 'H' then '平成' end as gengou"
                        + ", cast(case when date_part('month', to_date((to_number(r.c4_array[1],'999')-12+2000 || '/' || r.c4_array[2] || '/' || 1),'yyyy/mm/dd')::timestamp) < 4 then"
                        + " to_number(r.c4_array[1],'999')-1 else to_number(r.c4_array[1],'999') end as text) as nendo"
                        + ", to_number(r.c4_array[1],'999')::text as nen"
                        + ", to_number(r.c4_array[2],'99')::text as tsuki"
                        + ", rank() over (partition by r.c4, r.s_id order by r.id)::text as noufusyo_bangou"
                        + ", r.c5"
                        + ", r.c6"
                        + ", r.c7"
                        + ", s.c7 as s_c7"
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
                        + ", r.name1"
                        + ", r.title3"
                        + ", r.title4"
                        + ", r.name2"
                        + ", r.syutsuryokubi"
                        + ", r.s_nen"
                        + ", r.s_tsuki"
                        + ", r.s_hi"
                        + ", r.srb_id"
                        + ", r.time_stamp"
                        + ", r.id"
                        + " from r"
                        + " left join (select c4, c5, c6, c7, c9, c11, c14, c15, c16, c17, c19, s_id, o_id, case when c7 = '現金' then '1' when c7 = '引落' then '2' when c7 = '振込' then '2' else '' end 支払方法, time_stamp from t_shiharai_houhou"
                        + " where time_stamp = (select max(time_stamp) from t_shiharai_houhou where"
                            + " c4_array[1]::text || '/' || c4_array[2]::Text = "
                            + " case when length('" + cmb_tsuki_str + "')=1 then"
                            + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                            + "       when length('" + cmb_tsuki_str + "')=2 then"
                            + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                            + " end"
                            + " and s_id::Integer = " + cmb_s_id_int
                            + " and o_id::Integer = " + cmb_o_id_int
                        + ")) s on r.c1 = s.c5 and rtrim(replace(r.c3,substr(r.c3,strpos(r.c3, '('), strpos(r.c3, ')')),'')) = rtrim(replace(s.c6,substr(s.c6,strpos(s.c6, '('), strpos(s.c6, ')')),'')) and r.s_id = s.s_id and r.o_id = s.o_id and s.s_id::Integer = " + cmb_s_id_int
                        + " where"
                        + " r.s_id::Integer = " + cmb_s_id_int
                        + " and r.o_id::Integer = " + cmb_o_id_int
                        + " and r.time_stamp = (select max(time_stamp) from t_seikyu where"
                        + " s_id::Integer = " + cmb_s_id_int
                        + " and o_id::Integer = " + cmb_o_id_int
                            + " and c4_array[1]::text || '/' || c4_array[2]::Text = "
                            + " case when length('" + cmb_tsuki_str + "')=1 then"
                            + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                            + "       when length('" + cmb_tsuki_str + "')=2 then"
                            + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                            + " end)"
                            + " and r.c4_array[1]::text || '/' || r.c4_array[2]::Text = "
                            + " case when length('" + cmb_tsuki_str + "')=1 then"
                            + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                            + "       when length('" + cmb_tsuki_str + "')=2 then"
                            + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                            + " end"
                        + " and r.req_id::Integer = :req_id"
                        + " order by r.id;"
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

                        if (cmb_req_id.SelectedItem == null)
                        {
                            da.SelectCommand.Parameters.Add(new NpgsqlParameter("req_id",
                            NpgsqlTypes.NpgsqlDbType.Integer, 0, "req_id",
                            ParameterDirection.Input, false, 0, 0, DataRowVersion.Current,
                            DBNull.Value));
                        }
                        else
                        {
                            DataRowView row = (DataRowView)cmb_req_id.SelectedItem;
                            da.SelectCommand.Parameters.AddWithValue("req_id", row["req_id"]);
                        }

                        if (ds.Tables["seikyu"] != null)
                            ds.Tables["seikyu"].Clear();
                        da.Fill(ds, "seikyu");

                        crGenbo myReport = new crGenbo();
                        myReport.SetDataSource(ds);

                        myReport.SetParameterValue("s_id", cmb_s_id_int.ToString());
                        myReport.SetParameterValue("req_id", cmb_req_id_int.ToString());

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
                        "with recursive r as ("
                        + "select"
                        + " c1"
                        + ", c2"
                        + ", c3"
                        + ", rtrim(replace(c3,substr(c3,strpos(c3, '('), strpos(c3, ')')),'')) c3_mod"
                        + ", c4"
                        + ", c4_array"
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
                        + ", name1"
                        + ", title3"
                        + ", title4"
                        + ", name2"
                        + ", syutsuryokubi"
                        + ", s_nen"
                        + ", s_tsuki"
                        + ", s_hi"
                        + ", srb_id"
                        + ", time_stamp"
                        + ", to_number(c4_array[1],'999')::text as nen"
                        + ", to_number(c4_array[2],'99')::text as tsuki"
                        + " from"
                        + " (((t_seikyu inner join t_syubetsu"
                        + " on t_seikyu.s_id::integer = t_syubetsu.s_id and t_seikyu.o_id::integer = t_syubetsu.o_id)"
                        + " inner join t_par on t_seikyu.p_id::integer = t_par.p_id)"
                        + " inner join t_req on t_seikyu.req_id::integer = t_req.req_id)"
                        + " inner join t_syutsuryokubi on t_seikyu.s_id::text = t_syutsuryokubi.s_id"
                        + " order by c1"
                        + ")"
                        + "select"
                        + " c4"
                        + ", c4_array"
                        + ", syubetsu"
                        + ", tsuki"
                        + ", count(cast(c22 as integer)) as rec_count"
                        + ", sum(cast(c5 as integer)) as g_c5"
                        + ", sum(cast(c6 as integer)) as g_c6"
                        + ", sum(cast(c7 as integer)) as g_c7"
                        + ", sum(cast(c8 as integer)) as g_c8"
                        + ", sum(cast(c9 as integer)) as g_c9"
                        + ", sum(cast(c10 as integer)) as g_c10"
                        + ", sum(cast(c11 as integer)) as g_c11"
                        + ", sum(cast(c12 as integer)) as g_c12"
                        + ", sum(cast(c13 as integer)) as g_c13"
                        + ", sum(cast(c14 as integer)) as g_c14"
                        + ", sum(cast(c15 as integer)) as g_c15"
                        + ", sum(cast(c16 as integer)) as g_c16"
                        + ", sum(cast(c17 as integer)) as g_c17"
                        + ", sum(cast(c18 as integer)) as g_c18"
                        + ", sum(cast(c19 as integer)) as g_c19"
                        + ", sum(cast(c20 as integer)) as g_c20"
                        + ", sum(cast(c21 as integer)) as g_c21"
                        + ", sum(cast(c22 as integer)) as goukei"
                        + ", sum(cast(c7 as integer)) as g_c7"
                        + ", case when left(c4_array[1],1) = 'H' then '平成' end as gengou"
                        + ", cast(case when date_part('month', to_date((to_number(c4_array[1],'999')-12+2000 || '/' || c4_array[2] || '/' || 1),'yyyy/mm/dd')::timestamp) < 4 then"
                        + " to_number(c4_array[1],'999')-1 else to_number(c4_array[1],'999') end as text) as nendo"
                        + ", to_number(c4_array[1],'999')::text as nen"
                        + ", to_number(c4_array[2],'99')::text as tsuki"
                        + " from r"
                        + " group by c4, s_id, o_id, c4_array, req_id, syubetsu, tsuki, time_stamp"
                        + " having c4::Text = case when length('" + cmb_tsuki_str + "')=1 then"
                                        + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                                        + "       when length('" + cmb_tsuki_str + "')=2 then"
                                        + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                                        + " end"
                        + " and s_id::Integer = :s_id"
                        + " and o_id::Integer = :o_id"
                        + " and req_id::Integer = :req_id"
                        + " and time_stamp = (select max(time_stamp) from t_seikyu where"
                        + " s_id::Integer = :s_id"
                        + " and o_id::Integer = :o_id"
                        + " and c4::Text = case when length('" + cmb_tsuki_str + "')=1 then"
                                        + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                                        + "       when length('" + cmb_tsuki_str + "')=2 then"
                                        + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                                        + " end)"
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

                        if (cmb_req_id.SelectedItem == null)
                        {
                            da.SelectCommand.Parameters.Add(new NpgsqlParameter("req_id",
                            NpgsqlTypes.NpgsqlDbType.Integer, 0, "req_id",
                            ParameterDirection.Input, false, 0, 0, DataRowVersion.Current,
                            DBNull.Value));
                        }
                        else
                        {
                            DataRowView row = (DataRowView)cmb_req_id.SelectedItem;
                            da.SelectCommand.Parameters.AddWithValue("req_id", row["req_id"]);
                        }

                        if (ds.Tables["seikyu"] != null)
                            ds.Tables["seikyu"].Clear();
                        da.Fill(ds, "seikyu");

                        crUchiwake myReport = new crUchiwake();
                        myReport.SetDataSource(ds);

                        myReport.SetParameterValue("s_id", cmb_s_id_int.ToString());
                        myReport.SetParameterValue("req_id", cmb_req_id_int.ToString());

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
                        "with recursive r as ("
                        + " select"
                        + " t2.c5 利用者番号"
                        + ", t1.id"
                        + ", t1.c1"
                        + ", t1.c4"
                        + ", t1.c22"
                        + ", t1.s_id"
                        + ", t1.o_id"
                        + ", t1.req_id"
                        + ", t3.syubetsu"
                        + ", t1.c3"
                        + ", rtrim(replace(t1.c3,substr(t1.c3,strpos(t1.c3, '('), strpos(t1.c3, ')')),'')) 利用者名"
                        + ", t2.c7 支払方法"
                        + ", t2.c14 引落金融機関支店名"
                        + ", t2.c15 引落口座種別"
                        + ", substr(t2.c4,strpos(t2.c4, '[')+1, strpos(t2.c4, ']')-strpos(t2.c4, '[')-1) 事業所名"
                        + ", t4.col0"
                        + ", t4.col1"
                        + ", t4.col2"
                        + ", t4.col3"
                        + ", t4.col4"
                        + ", case when left(t1.c4_array[1],1) = 'H' then '平成' end as gengou"
                        + ", t4.col5"
                        + ", t4.ac0"
                        + ", t4.ac1"
                        + ", t4.ac2"
                        + ", t4.ac3"
                        + ", case when length(t2.c16)=7 then left(t2.c16,4) || replace(right(t2.c16,3),right(t2.c16,3),'***')"
                        + " when length(t2.c16)=14 then left(t2.c16,4) || replace(right(t2.c16,10),right(t2.c16,10),'**-*******')"
                        + " end 引落口座番号"
                        + ", case when ((t2.c19 is null)or(t2.c19 = '')) and t2.c7 = '1' then t2.c6"
                        + " else t2.c19 end 引落口座名義人"
                        + ", case when ((t2.c7 = '現金')or(t2.c11 is null)or(t2.c11 = '')) then '稚内信用金庫'"
                        + " else t2.c11 end 引落金融機関銀行名"
                        + ", t5.b_code"
                        + ", t5.br_code"
                        + ", t5.sb_name"
                        + ", t5.sd"
                        + ", t6.title1"
                        + ", t6.title2"
                        + ", t6.title3"
                        + ", t6.title4"
                        + ", t6.name1"
                        + ", t6.name2"
                        + ", t6.name3"
                        + ", t6.name4"
                        + ", t6.name5"
                        + ", t6.data6"
                        + ", t6.data7"
                        + ", t6.data8"
                        + ", t6.title4_kana"
                        + ", t6.name2_kana"
                        + ", t7.syutsuryokubi"
                        + ", case when ((t2.c7 = '現金') or (t2.c11 = '')) then '1021' else t8.b_code end _b_code"
                        + ", case when ((t2.c7 = '現金') or (t2.c11 = '')) then '稚内信用金庫' else t8.b_name end _b_name"
                        + ", case when ((t2.c7 = '現金') or (t2.c11 = '')) then '014' else t8.br_code end _br_code"
                        + ", case when ((t2.c7 = '現金') or (t2.c11 = '')) then '利尻富士支店' else t8.br_name end _br_name"
                        + ", case when t5.sy IS NULL or t5.sm IS NULL then" /* 引落年月日自動入力の場合*/
                            + " case when t5.b_id = '0' then null"
                                + " when t5.b_id = '1' then" /* 稚内信金の場合の処理*/
                                    + " case when t5.sd = '99' then" /* 翌月末引落の場合の処理 */
                                            + " target_date(to_date((to_number(c4_array[1],'999')-12+2000 || '/' || to_number(c4_array[2],'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                    + " else" /* 翌月末引落以外の場合の処理 */
                                            + " target_date(to_date((to_number(c4_array[1],'999')-12+2000 || '/' || to_number(c4_array[2],'99')+1 || '/' || to_number(t5.sd,'99')),'yyyy/mm/dd'))"
                                    + " end"
                                + " when t5.b_id = '2' then" /* ゆうちょ銀行の場合の処理*/
                                    + " case when t5.sd = '99' then" /* 翌月末引落の場合の処理 */
                                            + " target_date(to_date((to_number(c4_array[1],'999')-12+2000 || '/' || to_number(c4_array[2],'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                    + " else" /* 翌月末引落以外の場合の処理 */
                                            + " target_date(to_date((to_number(c4_array[1],'999')-12+2000 || '/' || to_number(c4_array[2],'99')+1 || '/' || to_number(t5.sd,'99')),'yyyy/mm/dd'))"
                                    + " end"
                                + " when t5.b_id = '3' then" /* 利尻漁協の場合の処理*/
                                    + " case when t5.sd = '99' then" /* 翌月末引落の場合の処理 */
                                            + " target_date(to_date((to_number(c4_array[1],'999')-12+2000 || '/' || to_number(c4_array[2],'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                    + " else" /* 翌月末引落以外の場合の処理 */
                                            + " target_date(to_date((to_number(c4_array[1],'999')-12+2000 || '/' || to_number(c4_array[2],'99')+1 || '/' || to_number(t5.sd,'99')),'yyyy/mm/dd'))"
                                    + " end"
                            + " end"
                        + " else" /* 引落年月日手入力の場合*/
                            + " case when t5.b_id = '0' then null"
                                + " when t5.b_id = '1' then" /* 稚内信金の場合の処理*/
                                    + " case when t5.sd = '99' then" /* 翌月末引落の場合の処理 */
                                        + " target_date(to_date((to_number(t5.sy,'999')-12+2000 || '/' || to_number(t5.sm,'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                    + " else" /* 翌月末引落以外の場合の処理 */
                                        + " target_date(to_date((to_number(t5.sy,'999')-12+2000 || '/' || to_number(t5.sm,'99') || '/' || to_number(t5.sd,'99')),'yyyy/mm/dd'))"
                                    + " end"
                                + " when t5.b_id = '2' then" /* ゆうちょ銀行の場合の処理*/
                                    + " case when t5.sd = '99' then" /* 翌月末引落の場合の処理 */
                                        + " target_date(to_date((to_number(t5.sy,'999')-12+2000 || '/' || to_number(t5.sm,'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                    + " else" /* 翌月末引落以外の場合の処理 */
                                        + " target_date(to_date((to_number(t5.sy,'999')-12+2000 || '/' || to_number(t5.sm,'99') || '/' || to_number(t5.sd,'99')),'yyyy/mm/dd'))"
                                    + " end"
                                + " when t5.b_id = '3' then" /* 利尻漁協の場合の処理*/
                                    + " case when t5.sd = '99' then" /* 翌月末引落の場合の処理 */
                                        + " target_date(to_date((to_number(t5.sy,'999')-12+2000 || '/' || to_number(t5.sm,'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                    + " else" /* 翌月末引落以外の場合の処理 */
                                        + " target_date(to_date((to_number(t5.sy,'999')-12+2000 || '/' || to_number(t5.sm,'99') || '/' || to_number(t5.sd,'99')),'yyyy/mm/dd'))"
                                    + " end"
                            + " end"
                        + " end target_date"
                        + ", case when ((t8.b_name is null)or(t8.b_name = '')) then '稚内信用金庫'"
                        + " else t8.b_name end b_name"
                            //+ ", t5,sd"
                            //+ ", t5,sm"
                            //+ ", t5,sy"
                        + ", t9.c25 shiharaisya"
                            //+ ", target_date(to_date((to_number(t5.sy,'999')-12+2000 || '/' || to_number(t5.sm,'99') || '/' || to_number(t5.sd,'99')),'yyyy/mm/dd'))"
                        + " from ((((((((select id, c1, c3, c4, c4_array, c22, s_id, o_id, req_id"
                        + " , time_stamp from t_seikyu"
                        + " where time_stamp = (select max(time_stamp) from t_seikyu where"
                        + " s_id::Integer = " + cmb_s_id_int
                        + " and o_id::Integer = " + cmb_o_id_int
                        + " and c4 = case when length('" + cmb_tsuki_str + "')=1 then"
                                        + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                                        + "       when length('" + cmb_tsuki_str + "')=2 then"
                                        + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                                        + " end)) t1"
                        + " left join (select c4, c5, c6, c7, c11, c14, c15, c16, c19, s_id, o_id, case when c7 = '現金' then '1' when c7 = '引落' then '2' when c7 = '振込' then '2' else '' end 支払方法, time_stamp from t_shiharai_houhou"
                        + " where time_stamp = (select max(time_stamp) from t_shiharai_houhou where"
                            + " c4_array[1]::text || '/' || c4_array[2]::Text = "
                            + " case when length('" + cmb_tsuki_str + "')=1 then"
                            + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                            + "       when length('" + cmb_tsuki_str + "')=2 then"
                            + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                            + " end"
                            + " and s_id::Integer = " + cmb_s_id_int
                            + " and o_id::Integer = " + cmb_o_id_int
                        + ")) t2 on t1.c1 = t2.c5 and rtrim(replace(t1.c3,substr(t1.c3,strpos(t1.c3, '('), strpos(t1.c3, ')')),'')) = rtrim(replace(t2.c6,substr(t2.c6,strpos(t2.c6, '('), strpos(t2.c6, ')')),'')) and t1.s_id = t2.s_id and t1.o_id = t2.o_id and t2.s_id::Integer = " + cmb_s_id_int + ")"
                        + " left join (select s_id, syubetsu from t_syubetsu) t3 on t1.s_id::Integer = t3.s_id and t1.o_id::Integer = t3.o_id)"
                        + " left join (select rep_id, pt_id, s_id, col0, col1, col2, col3, col4, col5, ac0, ac1, ac2, ac3 from t_rep) t4 on t2.支払方法 = t4.pt_id and t1.s_id = t4.s_id)"
                        + " left join (select bid, b_id, b_code, b_name, sb_name, br_code, br_name, sd, sm, sy from t_bank) t5 on t2.c11 = t5.b_name)"
                        + " left join (select req_id, title1, title2, title3, title4, name1, name2, name3, name4, name5, data6, data7, data8, title4_kana, name2_kana from t_req) t6 on t1.req_id::Integer = t6.req_id)"
                        + " left join (select syutsuryokubi, s_id from t_syutsuryokubi) t7 on t1.s_id = t7.s_id)"
                        + " left join (select bid, b_id, b_code, b_name, sb_name, br_code, br_name, sd from t_bank where b_id = '1') t8 on t2.c11 = t8.b_name)"
                        + " left join (select c1, c5, c25, c48, s_id, o_id from t_shinzoku_kankei where c48 = '1' and time_stamp = (select max(time_stamp) from t_shinzoku_kankei where"
                            + " c4_array[1]::text || '/' || c4_array[2]::Text = "
                            + " case when length('" + cmb_tsuki_str + "')=1 then"
                            + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                            + "       when length('" + cmb_tsuki_str + "')=2 then"
                            + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                            + " end"
                            + " and s_id::Integer = " + cmb_s_id_int
                            + " and o_id::Integer = " + cmb_o_id_int
                        + " )) t9 on t1.c1 = t9.c1"
                        + " and t9.s_id::Integer = " + cmb_s_id_int
                        + " and t9.o_id::Integer = " + cmb_o_id_int
                        + " order by t1.id)"
                        + " select"
                        + " 利用者番号"
                        + ", id"
                        + ", c1"
                        + ", c3"
                        + ", c4"
                        + ", c22"
                        + ", s_id"
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
                        + ", gengou"
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
                        + ", name1"
                        + ", name2"
                        + ", name3"
                        + ", name4"
                        + ", name5"
                        + ", data6"
                        + ", data7"
                        + ", data8"
                        + ", title4_kana"
                        + ", name2_kana"
                        + ", syutsuryokubi"
                        + ", _b_code"
                        + ", _br_code"
                        + ", _br_name"
                            /* + ", last_day"
                            + ", last_days"
                            + ", tran_day" */
                        + ", shiharaisya"
                        + ", target_date last_day"
                        + " from r"
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

                        if (cmb_req_id.SelectedItem == null)
                        {
                            da.SelectCommand.Parameters.Add(new NpgsqlParameter("req_id",
                            NpgsqlTypes.NpgsqlDbType.Integer, 0, "req_id",
                            ParameterDirection.Input, false, 0, 0, DataRowVersion.Current,
                            DBNull.Value));
                        }
                        else
                        {
                            DataRowView row = (DataRowView)cmb_req_id.SelectedItem;
                            da.SelectCommand.Parameters.AddWithValue("req_id", row["req_id"]);
                        }

                        if (ds.Tables["seikyu"] != null)
                            ds.Tables["seikyu"].Clear();
                        da.Fill(ds, "seikyu");

                        crShiharai myReport = new crShiharai();
                        myReport.SetDataSource(ds);

                        myReport.SetParameterValue("s_id", cmb_s_id_int.ToString());
                        myReport.SetParameterValue("req_id", cmb_req_id_int.ToString());

                        crvSeikyu.ReportSource = myReport;

                        bindingNavigatorWithdrawal.Visible = false;
                        dataGridViewWithdrawal.Visible = false;
                        crvSeikyu.Visible = true;
                    }
                    break;
                case 5: // 引落請求書
                    {
                        Console.WriteLine("cmb_b_code_str = " + cmb_b_code_str);

                        da.SelectCommand = new NpgsqlCommand
                        (
                            "select"
                            + " a.r_id"
                            + ", a.c1"
                            + ", c.c5"
                            + ", c.c6"
                            + ", a.c3"
                            + ", rtrim(replace(a.c3,substr(a.c3,strpos(a.c3, '('), strpos(a.c3, ')')),'')) c3_mod"
                            + ", a.c4"
                            + ", rtrim(replace(c.c6,substr(c.c6,strpos(c.c6, '('), strpos(c.c6, ')')),'')) c6_mod"
                            + ", c.c6"
                            + ", c.c9"
                            + ", c.c11"
                            + ", c.c14"
                            + ", c.c16"
                            + ", c.c19"
                            + ", a.c22"
                            + ", c.c4_array"
                            + ", case substr(c.c4,strpos(c.c4, '[')+1, strpos(c.c4, ']')-strpos(c.c4, '[')-1)"
                            + " when '入所' then '入所'"
                            + " when '介護通所' then '通所'"
                            + " when '介護短期' then '短期'"
                            + " when '予防通所' then '予防通所'"
                            + " when '予防短期' then '予防短期'"
                            + " when '通所型サービス' then '通所型'"
                            + " end"
                            + ", a.w_flg"
                            + " from t_seikyu a left join t_shiharai_houhou c"
                            + " on a.c1 = c.c5"
                            + " and rtrim(replace(a.c3,substr(a.c3,strpos(a.c3, '('), strpos(a.c3, ')')),'')) = rtrim(replace(c.c6,substr(c.c6,strpos(c.c6, '('), strpos(c.c6, ')')),''))"
                            + " and a.o_id = c.o_id"
                            + " and a.s_id = c.s_id"
                            + " where not exists ("
                            + " select 1 from t_seikyu b"
                            + " where c4_array[1]::text || '/' || c4_array[2]::Text = case when length('" + cmb_tsuki_str + "')=1 then"
                                                                    + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                                                                    + "       when length('" + cmb_tsuki_str + "')=2 then"
                                                                    + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                                                                    + " end"
                                                    + " and a.s_id = b.s_id"
                                                    + " and a.o_id = b.o_id"
                            + " and a.time_stamp < b.time_stamp"
                            + " )"
                            + " and a.c4_array[1]::text || '/' || a.c4_array[2]::Text = case when length('" + cmb_tsuki_str + "')=1 then"
                                                                    + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                                                                    + "       when length('" + cmb_tsuki_str + "')=2 then"
                                                                    + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                                                                    + " end"
                            + " and not exists ("
                            + " select 1 from t_shiharai_houhou d"
                            + " where c4_array[1]::text || '/' || c4_array[2]::Text = case when length('" + cmb_tsuki_str + "')=1 then"
                                                                    + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                                                                    + "       when length('" + cmb_tsuki_str + "')=2 then"
                                                                    + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                                                                    + " end"
                                                   + " and c.s_id = d.s_id"
                                                   + " and c.o_id = d.o_id"
                            + " and c.time_stamp < d.time_stamp)"
                            + " and c.c4_array[1]::text || '/' || c.c4_array[2]::Text = case when length('" + cmb_tsuki_str + "')=1 then"
                                                                    + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                                                                    + "       when length('" + cmb_tsuki_str + "')=2 then"
                                                                    + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                                                                    + " end"
                            + " and case when '" + cmb_b_code_str + "' ='0000' then"
                                        + " c.c9 = ''"
                            + " else"
                                        + " c.c9 = '" + cmb_b_code_str + "'"
                                        + " end"
                                        + " and a.o_id = '" + cmb_o_id_str + "'"
                            + " order by a.r_id;"
                                , m_conn
                            );

                        da.InsertCommand = new NpgsqlCommand(
                        "insert into t_seikyu ("
                                    + " r_id"
                                    + ", c3"
                                    + ", c4"
                                    + ", c9"
                                    + ", c11"
                                    + ", c14"
                                    + ", c19"
                                    + ", c22"
                                    + ", s_id"
                                    + ", o_id"
                                    + " ) select"
                                    + " r_id"
                                    + ", c3"
                                    + ", c4"
                                    + ", c9"
                                    + ", c11"
                                    + ", c14"
                                    + ", c19"
                                    + ", c22"
                                    + ", s_id"
                                    + ", o_id"
                                    + " from t_csv"
                                    + " order by id;"
                                        , m_conn);
                        da.InsertCommand.Parameters.Add(new NpgsqlParameter("c3", NpgsqlTypes.NpgsqlDbType.Text, 0, "c3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                        da.InsertCommand.Parameters.Add(new NpgsqlParameter("c4", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                        da.InsertCommand.Parameters.Add(new NpgsqlParameter("c9", NpgsqlTypes.NpgsqlDbType.Text, 0, "c9", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                        da.InsertCommand.Parameters.Add(new NpgsqlParameter("c11", NpgsqlTypes.NpgsqlDbType.Text, 0, "c11", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                        da.InsertCommand.Parameters.Add(new NpgsqlParameter("c14", NpgsqlTypes.NpgsqlDbType.Text, 0, "c14", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                        da.InsertCommand.Parameters.Add(new NpgsqlParameter("c19", NpgsqlTypes.NpgsqlDbType.Text, 0, "c19", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                        da.InsertCommand.Parameters.Add(new NpgsqlParameter("c22", NpgsqlTypes.NpgsqlDbType.Text, 0, "c22", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                        da.InsertCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                        da.InsertCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));

                        // update
                        da.UpdateCommand = new NpgsqlCommand(
                                "update t_seikyu set"
                                + " w_flg = :w_flg"
                                + " where r_id=:r_id;"
                            , m_conn
                            );
                        da.UpdateCommand.Parameters.Add(new NpgsqlParameter("w_flg", NpgsqlTypes.NpgsqlDbType.Integer, 0, "w_flg", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                        da.UpdateCommand.Parameters.Add(new NpgsqlParameter("r_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "r_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                        // delete
                        da.DeleteCommand = new NpgsqlCommand
                        (
                               "delete from t_withdrawal"
                            + " where"
                            + " w_id=:w_id;"
                            , m_conn
                        );
                        da.DeleteCommand.Parameters.Add(new NpgsqlParameter("w_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "w_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));


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


        private void WithdrawalRowUpdated(Object sender, NpgsqlRowUpdatedEventArgs e)
        {
            if (e.Status == UpdateStatus.Continue)
            {
                if (e.StatementType == System.Data.StatementType.Insert)
                {
                    da.SelectCommand = new NpgsqlCommand
                    (
                    "with recursive r as ("
                    + "select"
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
                    + ", case substr(c.c4,strpos(c.c4, '[')+1, strpos(c.c4, ']')-strpos(c.c4, '[')-1)"
                    + " when '入所' then '入所'"
                    + " when '介護通所' then '通所'"
                    + " when '介護短期' then '短期'"
                    + " when '予防通所' then '予防通所'"
                    + " when '予防短期' then '予防短期'"
                    + " when '通所型サービス' then '通所型'"
                    + " end s_id_str"
                    + ", a.s_id"
                    + ", a.o_id"
                    + ", a.time_stamp"
                    + ", a.w_flg"
                    + " from t_seikyu a left join t_shiharai_houhou c"
                    + " on a.c1 = c.c5"
                    + " and rtrim(replace(a.c3,substr(a.c3,strpos(a.c3, '('), strpos(a.c3, ')')),'')) = rtrim(replace(c.c6,substr(c.c6,strpos(c.c6, '('), strpos(c.c6, ')')),''))"
                    + " and a.s_id = c.s_id"
                    + " and a.o_id = c.o_id"
                    + " and a.w_flg = '1'"
                    + " and c.c9 = '" + cmb_b_code_str + "'"
                    + " where not exists ("
                    + " select 1"
                    + " from t_seikyu b"
                    + " where a.s_id = b.s_id"
                    + " and a.o_id = b.o_id"
                    + " and a.c4_array = b.c4_array"
                    + " and a.time_stamp < b.time_stamp)"
                                + " and a.s_id = c.s_id"
                                + " and a.o_id = c.o_id"
                                + " and a.c4_array = c.c4_array"
                    + " and not exists ("
                    + " select 1"
                    + " from t_shiharai_houhou d"
                    + " where c.s_id = d.s_id"
                    + " and c.o_id = d.o_id"
                    + " and c.c4_array = d.c4_array"
                    + " and c.time_stamp < d.time_stamp)"
                                + " and a.s_id = c.s_id"
                                + " and a.o_id = c.o_id"
                                + " and a.c4_array = c.c4_array"
                    + " order by a.s_id, a.c1, a.r_id, a.c4"
                    + ")"
                    + " select"
                    + " distinct array_to_string(ARRAY(select distinct on (to_number(ltrim(right(c4,2)),'99')) ltrim(right(c4,2)) from r where w_flg = '1' order by to_number(ltrim(right(c4,2)),'99')),'-') title"
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
                    + " from r"
                    + " where r.w_flg = '1'"
                    + " and r.r_id = currval('t_seikyu_r_id_seq')"
                    + " order by r.s_id, r.c1, r.r_id, to_number(ltrim(right(r.c4,2)),'99');"
                    , m_conn
                    );
                }

                try
                {
                    NpgsqlDataReader reader = da.SelectCommand.ExecuteReader();
                    reader.Read();
                    e.Row["w_flg"] = reader["w_flg"];
                    e.Row["r_id"] = reader["r_id"];

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }
            else if (e.StatementType == System.Data.StatementType.Update)
            {
                da.SelectCommand = new NpgsqlCommand
                (
                    "with recursive r as ("
                    + "select"
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
                    + ", case substr(c.c4,strpos(c.c4, '[')+1, strpos(c.c4, ']')-strpos(c.c4, '[')-1)"
                    + " when '入所' then '入所'"
                    + " when '介護通所' then '通所'"
                    + " when '介護短期' then '短期'"
                    + " when '予防通所' then '予防通所'"
                    + " when '予防短期' then '予防短期'"
                    + " when '通所型サービス' then '通所型'"
                    + " end s_id_str"
                    + ", a.s_id"
                    + ", a.o_id"
                    + ", a.time_stamp"
                    + ", a.w_flg"
                    + " from t_seikyu a left join t_shiharai_houhou c"
                    + " on a.c1 = c.c5"
                    + " and rtrim(replace(a.c3,substr(a.c3,strpos(a.c3, '('), strpos(a.c3, ')')),'')) = rtrim(replace(c.c6,substr(c.c6,strpos(c.c6, '('), strpos(c.c6, ')')),''))"
                    + " and a.s_id = c.s_id"
                    + " and a.o_id = c.o_id"
                    + " and a.w_flg = '1'"
                    + " and c.c9 = '" + cmb_b_code_str + "'"
                    + " where not exists ("
                    + " select 1"
                    + " from t_seikyu b"
                    + " where a.s_id = b.s_id"
                    + " and a.o_id = b.o_id"
                    + " and a.c4_array = b.c4_array"
                    + " and a.time_stamp < b.time_stamp)"
                                + " and a.s_id = c.s_id"
                                + " and a.o_id = c.o_id"
                                + " and a.c4_array = c.c4_array"
                    + " and not exists ("
                    + " select 1"
                    + " from t_shiharai_houhou d"
                    + " where c.s_id = d.s_id"
                    + " and c.o_id = d.o_id"
                    + " and c.c4_array = d.c4_array"
                    + " and c.time_stamp < d.time_stamp)"
                                + " and a.s_id = c.s_id"
                                + " and a.o_id = c.o_id"
                                + " and a.c4_array = c.c4_array"
                    + " order by a.s_id, a.c1, a.r_id, a.c4"
                    + ")"
                    + " select"
                    + " distinct array_to_string(ARRAY(select distinct on (to_number(ltrim(right(c4,2)),'99')) ltrim(right(c4,2)) from r where w_flg = '1' order by to_number(ltrim(right(c4,2)),'99')),'-') title"
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
                    + " from r"
                    + " where r.w_flg = '1'"
                    + " and r.r_id = " + e.Row["r_id"].ToString()
                    + " order by r.s_id, r.c1, r.r_id, to_number(ltrim(right(r.c4,2)),'99')"
                    , m_conn
                );

            }

            try
            {
                NpgsqlDataReader reader = da.SelectCommand.ExecuteReader();
                reader.Read();
                e.Row["w_flg"] = reader["w_flg"];
                e.Row["r_id"] = reader["r_id"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }


        }

        private void cmb_prn_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_prn_id_int = cmb_prn_id.SelectedIndex + 1;
            Console.WriteLine("cmb_prn_id_int1 = " + cmb_prn_id_int);

            switch (cmb_prn_id_int)
            {
                case 1: // 
                    {
                        cmb_b_code.Visible = false;
                        cmdPrnWithdrawal.Visible = false;
                    }
                    break;
                case 2: // 
                    {
                        cmb_b_code.Visible = false;
                        cmdPrnWithdrawal.Visible = false;
                    }
                    break;
                case 3: // 
                    {
                        cmb_b_code.Visible = false;
                        cmdPrnWithdrawal.Visible = false;
                    }
                    break;
                case 4: // 
                    {
                        cmb_b_code.Visible = false;
                        cmdPrnWithdrawal.Visible = false;
                    }
                    break;
                case 5: // 
                    {
                        cmb_b_code.Visible = true;
                        cmdPrnWithdrawal.Visible = true;
                    }
                    break;
            }
        }

        private void cmd_holiday_Click(object sender, EventArgs e)
        {
            Form_holiday Form = new Form_holiday();
            Form.WindowState = FormWindowState.Maximized;
            Form.ShowDialog();
        }

        private void cmd_bank_Click(object sender, EventArgs e)
        {
            Form_bank Form = new Form_bank();
            Form.WindowState = FormWindowState.Maximized;
            Form.ShowDialog();
        }

        private void cmb_nen_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_nen_str = cmb_nen.Text;
            Console.WriteLine("cmb_nen_str = " + cmb_nen_str);
        }

        private void cmb_tsuki_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_tsuki_str = cmb_tsuki.Text;
            Console.WriteLine("cmb_tsuki_str = " + cmb_tsuki_str);
        }

        private void cmb_b_code_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_b_code_str = cmb_b_code.SelectedValue.ToString();

            //cmb_b_code_str = cmb_b_code.Text;
            Console.WriteLine("cmb_b_code_str = " + cmb_b_code_str);

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

        private void cmd_Ins_Click(object sender, EventArgs e)
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

            da.SelectCommand = new NpgsqlCommand
            (
                "with recursive h as ("
                + "select"
                + " a.r_id"
                + ", a.c1"
                + ", b.c5"
                + ", a.c3"
                + ", rtrim(replace(a.c3,substr(a.c3,strpos(a.c3, '('), strpos(a.c3, ')')),'')) c3_mod"
                + ", a.c4"
                + ", rtrim(replace(b.c6,substr(b.c6,strpos(b.c6, '('), strpos(b.c6, ')')),'')) c6_mod"
                + ", b.c6"
                + ", b.c9"
                + ", b.c11"
                + ", b.c14"
                + ", b.c16"
                + ", b.c19"
                + ", a.c22"
                + ", b.c4_array"
                + ", case substr(b.c4,strpos(b.c4, '[')+1, strpos(b.c4, ']')-strpos(b.c4, '[')-1)"
                + " when '入所' then '入所'"
                + " when '介護通所' then '通所'"
                + " when '介護短期' then '短期'"
                + " when '予防通所' then '予防通所'"
                + " when '予防短期' then '予防短期'"
                + " when '通所型サービス' then '通所型'"
                + ", a.w_flg"
                + " from t_seikyu a inner join t_shiharai_houhou b"
                + " on a.c1=b.c5"
                + " and rtrim(replace(a.c3,substr(a.c3,strpos(a.c3, '('), strpos(a.c3, ')')),'')) = rtrim(replace(b.c6,substr(b.c6,strpos(b.c6, '('), strpos(b.c6, ')')),''))"
                + " and a.s_id = case substr(b.c4,strpos(b.c4, '[')+1, strpos(b.c4, ']')-strpos(b.c4, '[')-1)"
                    + " when '入所' then '1'"
                    + " when '介護通所' then '2'"
                    + " when '介護短期' then '3'"
                    + " when '予防通所' then '4'"
                    + " when '予防短期' then '5'"
                    + " when '通所型サービス' then '6'"
                    + " end"
                + " where not exists (select 1 from t_seikyu as s"
                + " where a.c1 = s.c1 and a.c3 = s.c3 and a.time_stamp < s.time_stamp"
                + " and s.c4 = case when length('" + cmb_tsuki_str + "')=1 then"
                                + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                                + "       when length('" + cmb_tsuki_str + "')=2 then"
                                + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                                + " end)"
                + " and not exists (select 1 from t_shiharai_houhou as r"
                + " where b.c5 = r.c5 and b.c6 = r.c6 and b.time_stamp < r.time_stamp"
                + " and r.c4_array[1]::text || '/' || r.c4_array[2]::Text = case when length('" + cmb_tsuki_str + "')=1 then"
                                + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                                + "       when length('" + cmb_tsuki_str + "')=2 then"
                                + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                                + " end)"
                + " and a.c4_array[1]::text || '/' || a.c4_array[2]::Text = case when length('" + cmb_tsuki_str + "')=1 then"
                                + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                                + "       when length('" + cmb_tsuki_str + "')=2 then"
                                + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                                + " end"
                + " and b.c4_array[1]::text || '/' || b.c4_array[2]::Text = case when length('" + cmb_tsuki_str + "')=1 then"
                                + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                                + "       when length('" + cmb_tsuki_str + "')=2 then"
                                + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                                + " end"
                + " and b.c9 = '" + cmb_b_code_str + "'"
                + " order by a.r_id)"
                + " select"
                + " c1"
                + ", c3"
                + ", c4"
                + ", c9"
                + ", c11"
                + ", c14"
                + ", c16"
                + ", c19"
                + ", c22"
                + ", s_id"
                + ", w_flg"
                + " from h"
                + " where h.w_flg = '1';"
                , m_conn
                );

            if (ds.Tables["withdrawal_ds"] != null)
                ds.Tables["withdrawal_ds"].Clear();
            da.Fill(ds, "withdrawal_ds");

            bindingSourceWithdrawal.DataSource = withdrawalds;
            bindingSourceWithdrawal.DataMember = "withdrawal_ds";

            bindingNavigatorWithdrawal.BindingSource = bindingSourceWithdrawal;

            dataGridViewWithdrawal.AutoGenerateColumns = false;

            dataGridViewWithdrawal.DataSource = bindingSourceWithdrawal;

            dataGridViewWithdrawal.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void dataGridViewWithdrawal_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
                //this.dataGridViewWithdrawal.EndEdit();
                //this.dataGridViewWithdrawal.Refresh();
            }
        }

        private void dataGridViewWithdrawal_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
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

        private void cmdPrnWithdrawal_Click(object sender, EventArgs e)
        {
            switch (chk_title_str)
            {
                case '0': // 
                    {
                        da.SelectCommand = new NpgsqlCommand
                        (
                        "with recursive h as ("
                        + "with recursive r as ("
                                + "select"
                                + " a.r_id"
                                + ", a.c1"
                                + ", a.c3"
                                + ", rtrim(replace(a.c3,substr(a.c3,strpos(a.c3, '('), strpos(a.c3, ')')),'')) c3_mod"
                                + ", a.c4"
                                + ", a.c4_array"
                                + ", c.c5"
                                + ", rtrim(replace(c.c6,substr(c.c6,strpos(c.c6, '('), strpos(c.c6, ')')),'')) c6_mod"
                                + ", c.c6"
                                + ", c.c9"
                                + ", c.c11"
                                + ", c.c14"
                                + ", c.c16"
                                + ", c.c19"
                                + ", a.c22"
                                + ", case substr(c.c4,strpos(c.c4, '[')+1, strpos(c.c4, ']')-strpos(c.c4, '[')-1)"
                                + " when '入所' then '入所'"
                                + " when '介護通所' then '通所'"
                                + " when '介護短期' then '短期'"
                                + " when '予防通所' then '予防通所'"
                                + " when '予防短期' then '予防短期'"
                                + " when '通所型サービス' then '通所型'"
                                + " end s_id_str"
                                + ", a.s_id"
                                + ", a.o_id"
                                + ", a.time_stamp"
                                + ", a.w_flg"
                                + " from t_seikyu a left join t_shiharai_houhou c"
                                + " on a.c1 = c.c5 and rtrim(replace(a.c3,substr(a.c3,strpos(a.c3, '('), strpos(a.c3, ')')),'')) = rtrim(replace(c.c6,substr(c.c6,strpos(c.c6, '('), strpos(c.c6, ')')),'')) and a.s_id = c.s_id and a.w_flg = '1' and c.c9 = '" + cmb_b_code_str + "'"
                                + " where not exists ("
                                + " select 1"
                                + " from t_seikyu b"
                                + " where a.s_id = b.s_id"
                                + " and a.o_id = b.o_id"
                                + " and a.c4_array = b.c4_array"
                                + " and a.time_stamp < b.time_stamp)"
                                + " and a.c4_array = c.c4_array"
                                + " and not exists ("
                                + " select 1"
                                + " from t_shiharai_houhou d"
                                + " where c.s_id = d.s_id"
                                + " and c.o_id = d.o_id"
                                + " and c.c4_array = d.c4_array"
                                + " and c.time_stamp < d.time_stamp)"
                                + " and a.s_id = c.s_id"
                                + " and a.o_id = c.o_id"
                                + " and a.c4_array = c.c4_array"
                                //+ " order by a.s_id, a.r_id, a.c1, a.c4"
                                + " order by a.r_id"
                                + ")"
                                + " select"
                                + "'"+ cmb_tsuki_str + "' title"
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
                                + ", to_number(concat(to_number(ltrim(left(c4,3)),'999')-12+2000 ,lpad(trim(right(c4,2)),2,'0')),'999999')"
                                + " from r"
                                + " where r.w_flg = '1'"
                                //+ " order by r.s_id, r.r_id, r.c1, to_number(concat(to_number(ltrim(left(r.c4,3)),'999')-12+2000 ,lpad(trim(right(r.c4,2)),2,'0')),'999999')"
                                + " order by r.r_id, to_number(concat(to_number(ltrim(left(r.c4,3)),'999')-12+2000 ,lpad(trim(right(r.c4,2)),2,'0')),'999999')"
                                + " )"
                                    + " select"
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
                                    //+ ", h.s_id"
                                    + ", h.w_flg"
                                    + ", h.time_stamp"
                                    + ", case when b.sy IS NULL or b.sm IS NULL then" /* 引落年月日自動入力の場合*/
                                        + " case when b.b_id = '0' then null"
                                            + " when b.b_id = '1' then" /* 稚内信金の場合の処理*/
                                                + " case when b.sd = '99' then" /* 翌月末引落の場合の処理 */
                                                    + " case when '" + cmb_tsuki_str + "' = '11' Or '" + cmb_tsuki_str + "' = '12' then" /* 年末12月の場合の処理 */
                                                        + " target_date(to_date((to_number('" + cmb_nen_str + "','999')-12+2000+1 || '/' || to_number('" + cmb_tsuki_str + "','99')-10 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                                    + " else"
                                                    /* 11, 12月以外の場合の処理 */
                                                        + " target_date(to_date((to_number('" + cmb_nen_str + "','999')-12+2000 || '/' || to_number('" + cmb_tsuki_str + "','99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                                    + " end"
                                                + " else" /* 翌月末引落以外の場合の処理 */
                                                    + " case when '" + cmb_tsuki_str + "' = '12' then" /* 年末12月の場合の処理 */
                                                        + " target_date(to_date((to_number('" + cmb_nen_str + "','999')-12+2000+1 || '/' || to_number('" + cmb_tsuki_str + "','99')-11 || '/' || to_number(b.sd,'99')),'yyyy/mm/dd'))"
                                                    + " else"
                                                        /* 11, 12月以外の場合の処理 */
                                                        + " target_date(to_date((to_number('" + cmb_nen_str + "','999')-12+2000 || '/' || to_number('" + cmb_tsuki_str + "','99')+1 || '/' || to_number(b.sd,'99')),'yyyy/mm/dd'))"
                                                    + " end"
                                                //+ " target_date(to_date((to_number('" + cmb_nen_str + "','999')-12+2000 || '/' || to_number('" + cmb_tsuki_str + "','99')+1 || '/' || to_number(b.sd,'99')),'yyyy/mm/dd'))"
                                                + " end"
                                            + " when b.b_id = '2' then" /* ゆうちょ銀行の場合の処理*/
                                                + " case when b.sd = '99' then" /* 翌月末引落の場合の処理 */
                                                    + " case when '" + cmb_tsuki_str + "' = '11' Or '" + cmb_tsuki_str + "' = '12' then" /* 年末12月の場合の処理 */
                                                        + " target_date(to_date((to_number('" + cmb_nen_str + "','999')-12+2000+1 || '/' || to_number('" + cmb_tsuki_str + "','99')-10 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                                    + " else"
                                                        /* 11, 12月以外の場合の処理 */
                                                        + " target_date(to_date((to_number('" + cmb_nen_str + "','999')-12+2000 || '/' || to_number('" + cmb_tsuki_str + "','99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                                    + " end"
                                                + " else" /* 翌月末引落以外の場合の処理 */
                                                    + " case when '" + cmb_tsuki_str + "' = '12' then" /* 年末12月の場合の処理 */
                                                        + " target_date(to_date((to_number('" + cmb_nen_str + "','999')-12+2000+1 || '/' || to_number('" + cmb_tsuki_str + "','99')-11 || '/' || to_number(b.sd,'99')),'yyyy/mm/dd'))"
                                                    + " else"
                                                        /* 12月以外の場合の処理 */
                                                        + " target_date(to_date((to_number('" + cmb_nen_str + "','999')-12+2000 || '/' || to_number('" + cmb_tsuki_str + "','99')+1 || '/' || to_number(b.sd,'99')),'yyyy/mm/dd'))"
                                                    + " end"
                                                //+ " target_date(to_date((to_number('" + cmb_nen_str + "','999')-12+2000 || '/' || to_number('" + cmb_tsuki_str + "','99')+1 || '/' || to_number(b.sd,'99')),'yyyy/mm/dd'))"
                                                + " end"
                                            + " when b.b_id = '3' then" /* 利尻漁協の場合の処理*/
                                                + " case when b.sd = '99' then" /* 翌月末引落の場合の処理 */
                                                    + " case when '" + cmb_tsuki_str + "' = '11' Or '" + cmb_tsuki_str + "' = '12' then" /* 年末12月の場合の処理 */
                                                        + " target_date(to_date((to_number('" + cmb_nen_str + "','999')-12+2000+1 || '/' || to_number('" + cmb_tsuki_str + "','99')-10 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                                    + " else"
                                                        /* 11, 12月以外の場合の処理 */
                                                        + " target_date(to_date((to_number('" + cmb_nen_str + "','999')-12+2000 || '/' || to_number('" + cmb_tsuki_str + "','99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                                    + " end"
                                                + " else" /* 翌月末引落以外の場合の処理 */
                                                    + " case when '" + cmb_tsuki_str + "' = '12' then" /* 年末12月の場合の処理 */
                                                        + " target_date(to_date((to_number('" + cmb_nen_str + "','999')-12+2000+1 || '/' || to_number('" + cmb_tsuki_str + "','99')-11 || '/' || to_number(b.sd,'99')),'yyyy/mm/dd'))"
                                                    + " else"
                                                        /* 12月以外の場合の処理 */
                                                        + " target_date(to_date((to_number('" + cmb_nen_str + "','999')-12+2000 || '/' || to_number('" + cmb_tsuki_str + "','99')+1 || '/' || to_number(b.sd,'99')),'yyyy/mm/dd'))"
                                                    + " end"
                                                //+ " target_date(to_date((to_number('" + cmb_nen_str + "','999')-12+2000 || '/' || to_number('" + cmb_tsuki_str + "','99')+1 || '/' || to_number(b.sd,'99')),'yyyy/mm/dd'))"
                                                + " end"
                                        + " end"
                                    + " else" /* 引落年月日手入力の場合*/
                                        + " case when b.b_id = '0' then null"
                                            + " when b.b_id = '1' then" /* 稚内信金の場合の処理*/
                                                + " case when b.sd = '99' then" /* 翌月末引落の場合の処理 */
                                                    + " target_date(to_date((to_number(b.sy,'999')-12+2000 || '/' || to_number(b.sm,'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                                + " else" /* 翌月末引落以外の場合の処理 */
                                                    + " target_date(to_date((to_number(b.sy,'999')-12+2000 || '/' || to_number(b.sm,'99') || '/' || to_number(b.sd,'99')),'yyyy/mm/dd'))"
                                                + " end"
                                            + " when b.b_id = '2' then" /* ゆうちょ銀行の場合の処理*/
                                                + " case when b.sd = '99' then" /* 翌月末引落の場合の処理 */
                                                    + " target_date(to_date((to_number(b.sy,'999')-12+2000 || '/' || to_number(b.sm,'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                                + " else" /* 翌月末引落以外の場合の処理 */
                                                    + " target_date(to_date((to_number(b.sy,'999')-12+2000 || '/' || to_number(b.sm,'99') || '/' || to_number(b.sd,'99')),'yyyy/mm/dd'))"
                                                + " end"
                                            + " when b.b_id = '3' then" /* 利尻漁協の場合の処理*/
                                                + " case when b.sd = '99' then" /* 翌月末引落の場合の処理 */
                                                    + " target_date(to_date((to_number(b.sy,'999')-12+2000 || '/' || to_number(b.sm,'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                                + " else" /* 翌月末引落以外の場合の処理 */
                                                    + " target_date(to_date((to_number(b.sy,'999')-12+2000 || '/' || to_number(b.sm,'99') || '/' || to_number(b.sd,'99')),'yyyy/mm/dd'))"
                                                + " end"
                                        + " end"
                                    + " end last_day"
                                    + ", s.data6"
                                    + ", s.name3"
                                    + ", x.syubetsu"
                                    + ", x.shisetsumei"
                            + " from h left join t_bank b"
                            + " on h.c9 = b.b_code, t_req s, t_syubetsu x"
                            + " where x.o_id = " + cmb_o_id_str + " and x.s_id = " + cmb_s_id_int
                            + " order by to_number(concat(to_number(ltrim(left(h.c4,3)),'999')-12+2000 ,lpad(trim(right(h.c4,2)),2,'0')),'999999'), h.r_id"
                            , m_conn
                        );

                        if (withdrawalds.Tables["withdrawal_ds"] != null)
                            withdrawalds.Tables["withdrawal_ds"].Clear();
                        da.Fill(withdrawalds, "withdrawal_ds");
                        crWithdrawal myReport = new crWithdrawal();
                        myReport.SetDataSource(withdrawalds);
                        myReport.SetParameterValue("r_cmb_o_id_item", cmb_o_id_item);  // 指定したパラメータ値をセット
                        crvSeikyu.ReportSource = myReport;

                        bindingNavigatorWithdrawal.Visible = false;
                        dataGridViewWithdrawal.Visible = false;
                        crvSeikyu.Visible = true;
                    }
                    break;
                case '1': // 
                    {
                        da.SelectCommand = new NpgsqlCommand
                        (
                        "with recursive h as ("
                        + "with recursive r as ("
                                + "select"
                                + " a.r_id"
                                + ", a.c1"
                                + ", a.c3"
                                + ", rtrim(replace(a.c3,substr(a.c3,strpos(a.c3, '('), strpos(a.c3, ')')),'')) c3_mod"
                                + ", a.c4"
                                + ", c.c5"
                                + ", rtrim(replace(c.c6,substr(c.c6,strpos(c.c6, '('), strpos(c.c6, ')')),'')) c6_mod"
                                + ", c.c6"
                                + ", c.c9"
                                + ", c.c11"
                                + ", c.c14"
                                + ", c.c16"
                                + ", c.c19"
                                + ", a.c22"
                                + ", case substr(c.c4,strpos(c.c4, '[')+1, strpos(c.c4, ']')-strpos(c.c4, '[')-1)"
                                + " when '入所' then '入所'"
                                + " when '介護通所' then '通所'"
                                + " when '介護短期' then '短期'"
                                + " when '予防通所' then '予防通所'"
                                + " when '予防短期' then '予防短期'"
                                + " when '通所型サービス' then '通所型'"
                                + " end s_id_str"
                                + ", a.s_id"
                                + ", a.time_stamp"
                                + ", a.w_flg"
                                + " from t_seikyu a left join t_shiharai_houhou c"
                                + " on a.c1 = c.c5 and rtrim(replace(a.c3,substr(a.c3,strpos(a.c3, '('), strpos(a.c3, ')')),'')) = rtrim(replace(c.c6,substr(c.c6,strpos(c.c6, '('), strpos(c.c6, ')')),'')) and a.s_id = c.s_id and a.w_flg = '1' and c.c9 = '" + cmb_b_code_str + "'"
                                + " where not exists ("
                                + " select 1"
                                + " from t_seikyu b"
                                + " where a.s_id = b.s_id"
                                + " and a.o_id = b.o_id"
                                + " and a.c4_array = b.c4_array"
                                + " and a.time_stamp < b.time_stamp)"
                                + " and a.s_id = c.s_id"
                                + " and a.o_id = c.o_id"
                                + " and a.c4_array = c.c4_array"
                                + " and not exists ("
                                + " select 1"
                                + " from t_shiharai_houhou d"
                                + " where c.s_id = d.s_id"
                                + " and c.o_id = d.o_id"
                                + " and c.c4_array = d.c4_array"
                                + " and c.time_stamp < d.time_stamp)"
                                + " and a.c4_array = c.c4_array"
                                //+ " order by a.s_id, a.r_id, a.c1, a.c4"
                                + " order by a.r_id"
                                + ")"
                                + " select"
                                + " distinct array_to_string(ARRAY(select distinct on (to_number(concat(to_number(ltrim(left(r.c4,3)),'999')-12+2000 ,lpad(trim(right(r.c4,2)),2,'0')),'999999')) ltrim(right(r.c4,2)) from t_seikyu r"
                                + " inner join t_shiharai_houhou s"
                                + " on r.c1 = s.c5 and r.c3 = s.c6"
                                + " where w_flg = '1' and s.c9 = '" + cmb_b_code_str + "' order by to_number(concat(to_number(ltrim(left(r.c4,3)),'999')-12+2000 ,lpad(trim(right(r.c4,2)),2,'0')),'999999')),'-') title"
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
                                + ", to_number(concat(to_number(ltrim(left(c4,3)),'999')-12+2000 ,lpad(trim(right(c4,2)),2,'0')),'999999')"
                                + " from r"
                                + " where r.w_flg = '1'"
                                + " order by r.r_id, to_number(concat(to_number(ltrim(left(r.c4,3)),'999')-12+2000 ,lpad(trim(right(r.c4,2)),2,'0')),'999999')"
                                + " )"
                                    + " select"
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
                                    //+ ", h.s_id"
                                    + ", h.w_flg"
                                    + ", h.time_stamp"
                                    + ", case when b.sy IS NULL or b.sm IS NULL then" /* 引落年月日自動入力の場合*/
                                        + " case when b.b_id = '0' then null"
                                            + " when b.b_id = '1' then" /* 稚内信金の場合の処理*/
                                                + " case when b.sd = '99' then" /* 翌月末引落の場合の処理 */
                                                        + " target_date(to_date((to_number('" + cmb_nen_str + "','999')-12+2000 || '/' || to_number('" + cmb_tsuki_str + "','99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                                + " else" /* 翌月末引落以外の場合の処理 */
                                                        + " target_date(to_date((to_number('" + cmb_nen_str + "','999')-12+2000 || '/' || to_number('" + cmb_tsuki_str + "','99')+1 || '/' || to_number(b.sd,'99')),'yyyy/mm/dd'))"
                                                + " end"
                                            + " when b.b_id = '2' then" /* ゆうちょ銀行の場合の処理*/
                                                + " case when b.sd = '99' then" /* 翌月末引落の場合の処理 */
                                                        + " target_date(to_date((to_number('" + cmb_nen_str + "','999')-12+2000 || '/' || to_number('" + cmb_tsuki_str + "','99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                                + " else" /* 翌月末引落以外の場合の処理 */
                                                        + " target_date(to_date((to_number('" + cmb_nen_str + "','999')-12+2000 || '/' || to_number('" + cmb_tsuki_str + "','99')+1 || '/' || to_number(b.sd,'99')),'yyyy/mm/dd'))"
                                                + " end"
                                            + " when b.b_id = '3' then" /* 利尻漁協の場合の処理*/
                                                + " case when b.sd = '99' then" /* 翌月末引落の場合の処理 */
                                                        + " target_date(to_date((to_number('" + cmb_nen_str + "','999')-12+2000 || '/' || to_number('" + cmb_tsuki_str + "','99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                                + " else" /* 翌月末引落以外の場合の処理 */
                                                        + " target_date(to_date((to_number('" + cmb_nen_str + "','999')-12+2000 || '/' || to_number('" + cmb_tsuki_str + "','99')+1 || '/' || to_number(b.sd,'99')),'yyyy/mm/dd'))"
                                                + " end"
                                        + " end"
                                    + " else" /* 引落年月日手入力の場合*/
                                        + " case when b.b_id = '0' then null"
                                            + " when b.b_id = '1' then" /* 稚内信金の場合の処理*/
                                                + " case when b.sd = '99' then" /* 翌月末引落の場合の処理 */
                                                    + " target_date(to_date((to_number(b.sy,'999')-12+2000 || '/' || to_number(b.sm,'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                                + " else" /* 翌月末引落以外の場合の処理 */
                                                    + " target_date(to_date((to_number(b.sy,'999')-12+2000 || '/' || to_number(b.sm,'99') || '/' || to_number(b.sd,'99')),'yyyy/mm/dd'))"
                                                + " end"
                                            + " when b.b_id = '2' then" /* ゆうちょ銀行の場合の処理*/
                                                + " case when b.sd = '99' then" /* 翌月末引落の場合の処理 */
                                                    + " target_date(to_date((to_number(b.sy,'999')-12+2000 || '/' || to_number(b.sm,'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                                + " else" /* 翌月末引落以外の場合の処理 */
                                                    + " target_date(to_date((to_number(b.sy,'999')-12+2000 || '/' || to_number(b.sm,'99') || '/' || to_number(b.sd,'99')),'yyyy/mm/dd'))"
                                                + " end"
                                            + " when b.b_id = '3' then" /* 利尻漁協の場合の処理*/
                                                + " case when b.sd = '99' then" /* 翌月末引落の場合の処理 */
                                                    + " target_date(to_date((to_number(b.sy,'999')-12+2000 || '/' || to_number(b.sm,'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
                                                + " else" /* 翌月末引落以外の場合の処理 */
                                                    + " target_date(to_date((to_number(b.sy,'999')-12+2000 || '/' || to_number(b.sm,'99') || '/' || to_number(b.sd,'99')),'yyyy/mm/dd'))"
                                                + " end"
                                        + " end"
                                    + " end last_day"
                                    + ", s.data6"
                                    + ", s.name3"
                                    + ", x.syubetsu"
                            + " from h left join t_bank b"
                            + " on h.c9 = b.b_code, t_req s, t_syubetsu x"
                            + " where x.o_id = " + cmb_o_id_str + " and x.s_id = " + cmb_s_id_int
                            + " order by to_number(concat(to_number(ltrim(left(h.c4,3)),'999')-12+2000 ,lpad(trim(right(h.c4,2)),2,'0')),'999999'), h.r_id"
                            , m_conn
                        );

                        if (withdrawalds.Tables["withdrawal_ds"] != null)
                            withdrawalds.Tables["withdrawal_ds"].Clear();
                        da.Fill(withdrawalds, "withdrawal_ds");

                        crWithdrawal myReport = new crWithdrawal();
                        myReport.SetDataSource(withdrawalds);
                        myReport.SetParameterValue("r_cmb_o_id_item", cmb_o_id_item);  // 指定したパラメータ値をセット
                        crvSeikyu.ReportSource = myReport;

                        bindingNavigatorWithdrawal.Visible = false;
                        dataGridViewWithdrawal.Visible = false;
                        crvSeikyu.Visible = true;
                    }
                    break;
            }
        }

        private void dataGridViewWithdrawal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //foreach (DataGridViewCell c in this.dataGridViewWithdrawal.SelectedCells)
            //{
            //    // 設定チェックボックスの場合
            //    if (c.ColumnIndex == 0)
            //    {
            //        this.dataGridViewWithdrawal.EndEdit();
            //        this.dataGridViewWithdrawal.Refresh();
            //    }
            //}
            //if (e.ColumnIndex == 0)//ﾁｪｯｸﾎﾞｯｸｽの列かどうか判別して
            //{
            //    if (dataGridViewWithdrawal.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.Equals(true))
            //    {
            //        this.dataGridViewWithdrawal.EndEdit();
            //        this.dataGridViewWithdrawal.Refresh();
            //    }
            //    else
            //    {
            //        this.dataGridViewWithdrawal.EndEdit();
            //        this.dataGridViewWithdrawal.Refresh();
            //    }
            //}

        }

        //private CheckBox checkBoxAll = new System.Windows.Forms.CheckBox();

        // 列ヘッダーのチェックボックスを押したときに、すべて選択用のチェックボックス状態を切り替え
        private void dataGridViewWithdrawal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex == -1)
            {
                checkBoxAll.Checked = !checkBoxAll.Checked;
            }
        }

        // すべての行のチェック状態を切り替える
        private void checkBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridViewWithdrawal.Rows)
            {
                row.Cells[0].Value = checkBoxAll.Checked;
            }
        }

        private void chk_title_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_title.Checked)
            {
                //chk_title.Text = "Checked";
                chk_title_str = '1';
            }
            else
            {
                //chk_title.Text = "Unchecked";
                chk_title_str = '0';
            }
        }

        public char chk_title_str { get; set; }
    }
}
