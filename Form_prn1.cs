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
        private NpgsqlDataAdapter prn_id_da = new NpgsqlDataAdapter();

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
        private DataSet prn_id_ds = new DataSet();
        private DataSet abd_ds = new DataSet();
        //private DataSet cmb_s_id_ds = new DataSet();

        public string Cmb_nen_str { get; set; }
        public string Cmb_tsuki_str { get; set; }
        public string Cmb_b_code_str { get; set; }
        public string Cmb_s_id_str { get; set; }

        public int Cmb_s_id_int { get; set; }
        public int Cmb_prn_id_int { get; set; }

        //public string cmb_s_id_item;
        //public string cmb_s_id_str;

        public string Form_Seikyu_TextBoxS_id;
        public string Form_Seikyu_TextBoxO_id;
        public string Form_Seikyu_TextBoxNen;
        public string Form_Seikyu_TextBoxTsuki;
        public string Form_Seikyu_TextBoxN_id;
        public string Form_Seikyu_TextBoxT_id;

        private static Form_prn1 _form_prn1_Instance;

        private Form_seikyu form_seikyu_Instance;
        private Form_prn1 form_prn1_Instance;



        public Form_prn1()
        {
            InitializeComponent();
            _form_prn1_Instance = this;

            //Form_seikyuのインスタンスを取得
            form_seikyu_Instance = Form_seikyu.Form_seikyu_Instance;
            form_prn1_Instance = Form_prn1.Form_prn1_Instance;
            //Form_seikyuのテキストボックス文字列を
            //Form_prnの文字列変数Form_Seikyu_TextBoxO_idへ設定
            Form_Seikyu_TextBoxO_id = form_seikyu_Instance.TextBoxO_id;
            Form_Seikyu_TextBoxS_id = form_seikyu_Instance.TextBoxS_id;
            Form_Seikyu_TextBoxN_id = form_seikyu_Instance.TextBoxN_id;
            Form_Seikyu_TextBoxT_id = form_seikyu_Instance.TextBoxT_id;
            Form_Seikyu_TextBoxNen = form_seikyu_Instance.TextBoxNen;
            Form_Seikyu_TextBoxTsuki = form_seikyu_Instance.TextBoxTsuki;

        }

        //Form_prnインスタンスを設定、取得する。
        public static Form_prn1 Form_prn1_Instance
        {
            get
            {
                return _form_prn1_Instance;
            }
            set
            {
                _form_prn1_Instance = value;
            }
        }

        public string TextBoxO_id
        {
            get
            {
                return textBoxO_id.Text;
            }
            set
            {
                textBoxO_id.Text = value;
            }
        }

        public string TextBoxS_id
        {
            get
            {
                return textBoxS_id.Text;
            }
            set
            {
                textBoxS_id.Text = value;
            }
        }

        public string TextBoxN_id
        {
            get
            {
                return textBoxN_id.Text;
            }
            set
            {
                textBoxN_id.Text = value;
            }
        }

        public string TextBoxT_id
        {
            get
            {
                return textBoxT_id.Text;
            }
            set
            {
                textBoxT_id.Text = value;
            }
        }

        public string TextBoxNen
        {
            get
            {
                return textBoxNen.Text;
            }
            set
            {
                textBoxNen.Text = value;
            }
        }

        public string TextBoxTsuki
        {
            get
            {
                return textBoxTsuki.Text;
            }
            set
            {
                textBoxTsuki.Text = value;
            }
        }

        private void CmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // コンボボックスが未選択の場合
            if (dataGridViewAbd[4, 0].FormattedValue == null)
            {
                textBox1.Text = "null";
            }
            else
            {
                textBox1.Text = dataGridViewAbd[4, 0].FormattedValue.ToString();
            }
        }

        private void Form_prn1_Load(object sender, EventArgs e)
        {
            this.textBoxO_id.Text = Form_Seikyu_TextBoxO_id;
            this.textBoxS_id.Text = Form_Seikyu_TextBoxS_id;
            this.textBoxN_id.Text = Form_Seikyu_TextBoxN_id;
            this.textBoxT_id.Text = Form_Seikyu_TextBoxT_id;
            this.textBoxNen.Text = Form_Seikyu_TextBoxNen;
            this.textBoxTsuki.Text = Form_Seikyu_TextBoxTsuki;

            Console.WriteLine("Form_Seikyu_TextBoxO_id = " + Form_Seikyu_TextBoxO_id);
            Console.WriteLine("Form_Seikyu_TextBoxS_id = " + Form_Seikyu_TextBoxS_id);
            Console.WriteLine("Form_Seikyu_TextBoxN_id = " + Form_Seikyu_TextBoxN_id);
            Console.WriteLine("Form_Seikyu_TextBoxT_id = " + Form_Seikyu_TextBoxT_id);
            Console.WriteLine("Form_Seikyu_TextBoxNen = " + Form_Seikyu_TextBoxNen);
            Console.WriteLine("Form_Seikyu_TextBoxTsuki = " + Form_Seikyu_TextBoxTsuki);


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
            cmb_nen.SelectedValue = Form_Seikyu_TextBoxNen;

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
            cmb_tsuki.SelectedValue = Form_Seikyu_TextBoxTsuki;

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
            if (prn_id_ds.Tables["t_prn_syubetsu"] != null)
                prn_id_ds.Tables["t_prn_syubetsu"].Clear();
            prn_id_da.Fill(prn_id_ds, "t_prn_syubetsu");

            cmb_prn_id.DataSource = prn_id_ds.Tables["t_prn_syubetsu"];
            cmb_prn_id.DisplayMember = "syubetsu";
            cmb_prn_id.ValueMember = "ps_id";
            this.cmb_prn_id.SelectedIndex = 0;
            //cmb_prn_id.SelectedIndexChanged += new EventHandler(Cmb_prn_id_SelectedIndexChanged);

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
            if (b_codeds.Tables["t_bank"] != null)
                b_codeds.Tables["t_bank"].Clear();
            b_code_da.Fill(b_codeds, "t_bank");

            cmb_b_code.DataSource = b_codeds.Tables["t_bank"];
            cmb_b_code.DisplayMember = "b_name";
            cmb_b_code.ValueMember = "b_code";
            cmb_b_code.SelectedIndexChanged += new EventHandler(Cmb_b_code_SelectedIndexChanged);

            // コンボボックスで支払者を表示
            c19_da.SelectCommand = new NpgsqlCommand
            (
                   "SELECT"
                   + " b.c1,CASE WHEN a.c19 = '' THEN a.c6 ELSE a.c19 END c19"
                   + " FROM t_shiharai_houhou a INNER JOIN t_seikyu b"
                   + " ON a.c5 = b.c1"
                   + " WHERE b.c4_y = '" + Form_Seikyu_TextBoxNen + "'"
                   + " AND b.c4_m = CASE WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=1 THEN"
                                                            + " ' ' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=2 THEN"
                                                            + " '' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " END"
                   + " AND b.s_id = '" + Form_Seikyu_TextBoxS_id + "'"
                   + " AND b.o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                   + " AND a.time_stamp = (SELECT max(time_stamp) FROM t_shiharai_houhou WHERE c4_y = '" + Form_Seikyu_TextBoxNen + "'"
                                                            + " AND c4_m = CASE WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=1 THEN"
                                                            + " ' ' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=2 THEN"
                                                            + " '' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " END"
                                                            + " AND s_id = '" + Form_Seikyu_TextBoxS_id + "' AND o_id = '" + Form_Seikyu_TextBoxO_id + "')"
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
                   + " WHERE b.c4_y = '" + Form_Seikyu_TextBoxNen + "'"
                   + " AND b.c4_m = CASE WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=1 THEN"
                                                            + " ' ' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=2 THEN"
                                                            + " '' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " END"
                   + " AND b.s_id = '" + Form_Seikyu_TextBoxS_id + "'"
                   + " AND b.o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                   + " AND a.time_stamp = (SELECT max(time_stamp) FROM t_shiharai_houhou WHERE c4_y = '" + Form_Seikyu_TextBoxNen + "'"
                                                            + " AND c4_m = CASE WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=1 THEN"
                                                            + " ' ' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=2 THEN"
                                                            + " '' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " END"
                                                            + " AND s_id = '" + Form_Seikyu_TextBoxS_id + "' AND o_id = '" + Form_Seikyu_TextBoxO_id + "')"
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
                   + " WHERE b.c4_y = '" + Form_Seikyu_TextBoxNen + "'"
                   + " AND b.c4_m = CASE WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=1 THEN"
                                                            + " ' ' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=2 THEN"
                                                            + " '' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " END"
                   + " AND b.s_id = '" + Form_Seikyu_TextBoxS_id + "'"
                   + " AND b.o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                   + " AND a.time_stamp = (SELECT max(time_stamp) FROM t_shiharai_houhou WHERE c4_y = '" + Form_Seikyu_TextBoxNen + "'"
                                                            + " AND c4_m = CASE WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=1 THEN"
                                                            + " ' ' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=2 THEN"
                                                            + " '' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " END"
                                                            + " AND s_id = '" + Form_Seikyu_TextBoxS_id + "' AND o_id = '" + Form_Seikyu_TextBoxO_id + "')"
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
                   + " WHERE b.c4_y = '" + Form_Seikyu_TextBoxNen + "'"
                   + " AND b.c4_m = CASE WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=1 THEN"
                                                            + " ' ' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=2 THEN"
                                                            + " '' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " END"
                   + " AND b.s_id = '" + Form_Seikyu_TextBoxS_id + "'"
                   + " AND b.o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                   + " AND a.time_stamp = (SELECT max(time_stamp) FROM t_shiharai_houhou WHERE c4_y = '" + Form_Seikyu_TextBoxNen + "'"
                                                            + " AND c4_m = CASE WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=1 THEN"
                                                            + " ' ' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=2 THEN"
                                                            + " '' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " END"
                                                            + " AND s_id = '" + Form_Seikyu_TextBoxS_id + "' AND o_id = '" + Form_Seikyu_TextBoxO_id + "')"
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
                   + " WHERE b.c4_y = '" + Form_Seikyu_TextBoxNen + "'"
                   + " AND b.c4_m = CASE WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=1 THEN"
                                                            + " ' ' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=2 THEN"
                                                            + " '' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " END"
                   + " AND b.s_id = '" + Form_Seikyu_TextBoxS_id + "'"
                   + " AND b.o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                   + " AND a.time_stamp = (SELECT max(time_stamp) FROM t_shiharai_houhou WHERE c4_y = '" + Form_Seikyu_TextBoxNen + "'"
                                                            + " AND c4_m = CASE WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=1 THEN"
                                                            + " ' ' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=2 THEN"
                                                            + " '' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " END"
                                                            + " AND s_id = '" + Form_Seikyu_TextBoxS_id + "' AND o_id = '" + Form_Seikyu_TextBoxO_id + "')"
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
            dataGridViewAbd.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewAbd.Columns[5].HeaderText = "金融機関名";
            dataGridViewAbd.Columns[6].HeaderText = "支店名";
            dataGridViewAbd.Columns[7].HeaderText = "口座番号";
            dataGridViewAbd.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewAbd.Columns[8].HeaderText = "請求額";
            dataGridViewAbd.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewAbd.Columns[8].DefaultCellStyle.Format = "#,##0";
            dataGridViewAbd.Columns[9].HeaderText = "種別";
            dataGridViewAbd.Columns[10].HeaderText = "番号";
            dataGridViewAbd.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dataGridViewAbd.Columns[11].HeaderText = "引落日ﾞ";

            da.SelectCommand = new NpgsqlCommand
            (
                   "SELECT"
                + " a.w_flg"
                + ", a.c3"
                + ", a.c1"
                + ", concat_ws('/', a.c4_y, a.c4_m) c4_ym"
                + ", a.c9"
                + ", a.c1 c1_bc"
                + ", a.c11"
                + ", a.c1 c1_bn"
                + ", a.c14"
                + ", a.c1 c1_brn"
                + ", a.c16"
                + ", a.c1 c1_acn"
                + ", a.c22"
                + ", a.s_id"
                + ", a.o_id"
                + ", a.r_id"
                //+ ", last_day"
                + " FROM"
                + " t_seikyu a"
                + " WHERE a.time_stamp = (SELECT max(time_stamp) FROM t_seikyu b"
                + " WHERE b.c4_m = CASE WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=1 THEN"
                                                            + " ' ' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=2 THEN"
                                                            + " '' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " END"
                + " AND b.s_id = '" + Form_Seikyu_TextBoxS_id + "'"
                + " AND b.o_id = '" + Form_Seikyu_TextBoxO_id + "')"
                + " ORDER BY a.r_id;",
                m_conn
                );

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

        private void Cmb_prn_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmb_prn_id_int = cmb_prn_id.SelectedIndex + 1;
            Console.WriteLine("Cmb_prn_id_int1 = " + Cmb_prn_id_int);

            switch (Cmb_prn_id_int)
            {
                case 1: // 
                    {
                        cmb_b_code.Visible = false;
                        //cmdPrnWithdrawal.Visible = false;
                        //checkBoxIni.Visible = false;
                    }
                    break;
                case 2: // 
                    {
                        cmb_b_code.Visible = false;
                        //cmdPrnWithdrawal.Visible = false;
                        //checkBoxIni.Visible = false;
                    }
                    break;
                case 3: // 
                    {
                        cmb_b_code.Visible = false;
                        //cmdPrnWithdrawal.Visible = false;
                        //checkBoxIni.Visible = false;
                    }
                    break;
                case 4: // 
                    {
                        cmb_b_code.Visible = false;
                        //cmdPrnWithdrawal.Visible = false;
                        //checkBoxIni.Visible = false;
                    }
                    break;
                case 5: // 
                    {
                        cmb_b_code.Visible = true;
                        //cmdPrnWithdrawal.Visible = true;
                        //checkBoxIni.Visible = true;

                    }
                    break;
            }
        }


        private void Cmb_nen_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmb_nen_str = cmb_nen.Text;
            Console.WriteLine("cmb_nen_str = " + Cmb_nen_str);
            textBoxN_id.Text = cmb_nen.SelectedIndex.ToString();
            textBoxNen.Text = cmb_nen.SelectedValue.ToString();
        }

        private void Cmb_tsuki_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmb_tsuki_str = cmb_tsuki.Text;
            Console.WriteLine("cmb_tsuki_str = " + Cmb_tsuki_str);
            textBoxT_id.Text = cmb_tsuki.SelectedIndex.ToString();
            textBoxTsuki.Text = cmb_tsuki.SelectedValue.ToString();
        }

        private void Cmb_s_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmb_s_id_int = cmb_s_id.SelectedIndex + 1;
            Console.WriteLine("cmb_s_id_int1 = " + Cmb_s_id_int);
            Cmb_s_id_str = cmb_s_id.Text;
            Console.WriteLine("cmb_s_id_str1 = " + Cmb_s_id_str);
            textBoxS_id.Text = Cmb_s_id_int.ToString();
            //textBoxS_id.Text = Form_Seikyu_TextBoxS_id;
        }

        private void Cmb_b_code_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmb_b_code_str = cmb_b_code.SelectedValue.ToString();

            Console.WriteLine("Cmb_b_code_str = " + Cmb_b_code_str);

            //dataGridViewWithdrawal.Columns[0].HeaderText = "選択";
            dataGridViewAbd.Columns[1].HeaderText = "氏名";
            dataGridViewAbd.Columns[2].HeaderText = "支払者";
            dataGridViewAbd.Columns[3].HeaderText = "年月";
            dataGridViewAbd.Columns[4].HeaderText = "銀行ｺｰﾄﾞ";
            dataGridViewAbd.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewAbd.Columns[5].HeaderText = "金融機関名";
            dataGridViewAbd.Columns[6].HeaderText = "支店名";
            dataGridViewAbd.Columns[7].HeaderText = "口座番号";
            dataGridViewAbd.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewAbd.Columns[8].HeaderText = "請求金額";
            dataGridViewAbd.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewAbd.Columns[8].DefaultCellStyle.Format = "#,##0";
            dataGridViewAbd.Columns[9].HeaderText = "種別";
            dataGridViewAbd.Columns[10].HeaderText = "番号";
            dataGridViewAbd.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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

        private void cmdPrv_Click(object sender, EventArgs e)
        {
            //da.SelectCommand = new NpgsqlCommand
            //    (
            //    "WITH RECURSIVE r as ("
            //    + " SELECT"
            //    + " a.r_id"
            //    + ", a.id"
            //    + ", a.c1"
            //    + ", a.c4"
            //    + ", a.c4_y"
            //    + ", a.c4_m"
            //    + ", a.c22"
            //    + ", a.s_id"
            //    + ", a.o_id"
            //    + ", a.req_id"
            //    + ", c.syubetsu"
            //    + ", a.c3"
            //    + ", rtrim(replace(a.c3,substr(a.c3,strpos(a.c3, '('), strpos(a.c3, ')')),'')) c3_mod"
            //    + ", rtrim(replace(b.c6,substr(b.c6,strpos(b.c6, '('), strpos(b.c6, ')')),'')) c6_mod"
            //    + ", a.w_flg"
            //    + ", c.hyoujimei s_id_str"
            //    + ", b.c5"
            //    + ", b.c7 支払方法"
            //    + ", b.c9"
            //    + ", b.c11"
            //    + ", b.c14"
            //    + ", b.c15 引落口座種別"
            //    + ", b.c16"
            //    + ", b.c19"
            //    + ", CASE WHEN strpos(b.c4, '[')>=1 THEN"
            //    + " substr(b.c4, strpos(b.c4, '[') + 1, strpos(b.c4, ']') - strpos(b.c4, '[') - 1)"
            //    + " ELSE"
            //    + " b.c4"
            //    + " END 事業所名"
            //    + ", d.col0"
            //    + ", d.col1"
            //    + ", d.col2"
            //    + ", d.col3"
            //    + ", d.col4"
            //    + ", d.col5"
            //    + ", d.ac0"
            //    + ", d.ac1"
            //    + ", d.ac2"
            //    + ", d.ac3"
            //    + ", CASE WHEN length(b.c16)=7 THEN left(b.c16,4) || replace(right(b.c16,3),right(b.c16,3),'***')"
            //    + " WHEN length(b.c16)=14 THEN left(b.c16,4) || replace(right(b.c16,10),right(b.c16,10),'**-*******')"
            //    + " END 引落口座番号"
            //    + ", CASE WHEN ((b.c19 is null) OR (b.c19 = '')) AND b.c7 = '1' THEN b.c6"
            //    + " ELSE b.c19 END 引落口座名義人"
            //    + ", CASE WHEN ((b.c7 = '現金') OR (b.c11 is null)or(b.c11 = '')) THEN '稚内信用金庫'"
            //    + " ELSE b.c11 END 引落金融機関銀行名"
            //    + ", e.b_code"
            //    + ", e.br_code"
            //    + ", e.sb_name"
            //    + ", e.sd"
            //    + ", f.title1"
            //    + ", f.title2"
            //    + ", f.title3"
            //    + ", f.title4"
            //    + ", f1.o_phone_number"
            //    + ", f1.o_name"
            //    + ", f.data7"
            //    + ", f.data8"
            //    + ", f.title4_kana"
            //    + ", L.acc_kana"
            //    + ", L.accounting_manager"
            //    + ", g.syutsuryokubi"
            //    + ", CASE WHEN ((b.c7 = '現金') or (b.c11 = '')) THEN '1021' ELSE h.b_code END _b_code"
            //    + ", CASE WHEN ((b.c7 = '現金') or (b.c11 = '')) THEN '稚内信用金庫' ELSE h.b_name END _b_name"
            //    + ", CASE WHEN ((b.c7 = '現金') or (b.c11 = '')) THEN '014' ELSE h.br_code END _br_code"
            //    + ", CASE WHEN ((b.c7 = '現金') or (b.c11 = '')) THEN '利尻富士支店' ELSE h.br_name END _br_name"
            //    + ", CASE WHEN e.sy IS NULL or e.sm IS NULL THEN" /* 引落年月日自動入力の場合*/
            //    + " CASE WHEN e.b_id = '0' THEN null"
            //        + " WHEN e.b_id = '1' THEN" /* 稚内信金の場合の処理*/
            //            + " CASE WHEN e.sd = '99' THEN" /* 翌月末引落の場合の処理 */
            //                    + " target_date(to_date((to_number(c4_y,'999')+diff || '/' || to_number(c4_m,'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
            //            + " ELSE" /* 翌月末引落以外の場合の処理 */
            //                    + " target_date(to_date((to_number(c4_y,'999')+diff || '/' || to_number(c4_m,'99')+1 || '/' || to_number(e.sd,'99')),'yyyy/mm/dd'))"
            //            + " END"
            //        + " WHEN e.b_id = '2' THEN" /* ゆうちょ銀行の場合の処理*/
            //            + " CASE WHEN e.sd = '99' THEN" /* 翌月末引落の場合の処理 */
            //                    + " target_date(to_date((to_number(c4_y,'999')+diff || '/' || to_number(c4_m,'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
            //            + " ELSE" /* 翌月末引落以外の場合の処理 */
            //                    + " target_date(to_date((to_number(c4_y,'999')+diff || '/' || to_number(c4_m,'99')+1 || '/' || to_number(e.sd,'99')),'yyyy/mm/dd'))"
            //            + " END"
            //        + " WHEN e.b_id = '3' THEN" /* 利尻漁協の場合の処理*/
            //            + " CASE WHEN e.sd = '99' THEN" /* 翌月末引落の場合の処理 */
            //                    + " target_date(to_date((to_number(c4_y,'999')+diff || '/' || to_number(c4_m,'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
            //            + " ELSE" /* 翌月末引落以外の場合の処理 */
            //                    + " target_date(to_date((to_number(c4_y,'999')+diff || '/' || to_number(c4_m,'99')+1 || '/' || to_number(e.sd,'99')),'yyyy/mm/dd'))"
            //            + " END"
            //    + " END"
            //    + " ELSE" /* 引落年月日手入力の場合*/
            //    + " CASE WHEN e.b_id = '0' THEN null"
            //        + " WHEN e.b_id = '1' THEN" /* 稚内信金の場合の処理*/
            //            + " CASE WHEN e.sd = '99' THEN" /* 翌月末引落の場合の処理 */
            //                + " target_date(to_date((to_number(e.sy,'999')+diff || '/' || to_number(e.sm,'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
            //            + " ELSE" /* 翌月末引落以外の場合の処理 */
            //                + " target_date(to_date((to_number(e.sy,'999')+diff || '/' || to_number(e.sm,'99') || '/' || to_number(e.sd,'99')),'yyyy/mm/dd'))"
            //            + " END"
            //        + " WHEN e.b_id = '2' THEN" /* ゆうちょ銀行の場合の処理*/
            //            + " CASE WHEN e.sd = '99' THEN" /* 翌月末引落の場合の処理 */
            //                + " target_date(to_date((to_number(e.sy,'999')+diff || '/' || to_number(e.sm,'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
            //            + " ELSE" /* 翌月末引落以外の場合の処理 */
            //                + " target_date(to_date((to_number(e.sy,'999')+diff || '/' || to_number(e.sm,'99') || '/' || to_number(e.sd,'99')),'yyyy/mm/dd'))"
            //            + " END"
            //        + " WHEN e.b_id = '3' THEN" /* 利尻漁協の場合の処理*/
            //            + " CASE WHEN e.sd = '99' THEN" /* 翌月末引落の場合の処理 */
            //                + " target_date(to_date((to_number(e.sy,'999')+diff || '/' || to_number(e.sm,'99')+2 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
            //            + " ELSE" /* 翌月末引落以外の場合の処理 */
            //                + " target_date(to_date((to_number(e.sy,'999')+diff || '/' || to_number(e.sm,'99') || '/' || to_number(e.sd,'99')),'yyyy/mm/dd'))"
            //            + " END"
            //    + " END"
            //    + " END target_date"
            //    + ", CASE WHEN ((h.b_name is null)or(h.b_name = '')) THEN '稚内信用金庫'"
            //    + " ELSE h.b_name END b_name"
            //    + ", i.c25 shiharaisya"
            //    + ", k.gengou"
            //    + ", k.g_name"
            //    + ", k.start_date"
            //    + ", k.end_date"
            //    + ", k.diff"
            //    + ", j.stuff"
            //    + ", m.manager"
            //    + " FROM ("
            //    + "("
            //    + "("
            //        + "("
            //            + "("
            //                + "("
            //                    + "("
            //                        + "("
            //                            + "("
            //                                + "("
            //                                    + "("
            //                                        + "(SELECT r_id, id, c1, c3, c4, c4_y, c4_m, c22, s_id, o_id, req_id, w_flg"
            //                                        + " , time_stamp FROM t_seikyu t1"
            //                                        + " WHERE time_stamp = "
            //                                            + "(SELECT max(time_stamp) FROM t_seikyu WHERE"
            //                                            + " s_id = t1.s_id"
            //                                            + " AND o_id = '" + Form_Seikyu_TextBoxO_id + "'"
            //                                            + " AND c4_y::Text = CASE WHEN length('" + Cmb_nen_str + "')=2 THEN"
            //                                                                    + " substr('" + Cmb_nen_str + "',1,1) || ' ' || substr('" + Cmb_nen_str + "', length('" + Cmb_nen_str + "')-1+1, length('" + Cmb_nen_str + "'))"
            //                                                                + " ELSE"
            //                                                                    + "'" + Cmb_nen_str + "'"
            //                                                                + " END"
            //                                            + " AND c4_m::Text = CASE WHEN length('" + Cmb_tsuki_str + "')=1 THEN"
            //                                            + " ' ' || '" + Cmb_tsuki_str + "'"
            //                                            + " WHEN length('" + Cmb_tsuki_str + "')=2 THEN"
            //                                            + " '' || '" + Cmb_tsuki_str + "'"
            //                                            + " END"
            //                                            + ")"
            //                                        + ") a LEFT JOIN (SELECT c4, c5, c6, c7, c9, c11, c14, c15, c16, c19, s_id, o_id,"
            //                                            + " CASE WHEN c7 = '現金' THEN '1'"
            //                                                + " WHEN c7 = Null THEN '1'"
            //                                                + " WHEN c7 = '引落' THEN '2'"
            //                                                + " WHEN c7 = '振込' THEN '2'"
            //                                                + " ELSE '' END 支払方法"
            //                                            + ", time_stamp FROM t_shiharai_houhou t2"
            //                                            + " WHERE time_stamp = "
            //                                                                + "(SELECT max(time_stamp) FROM t_shiharai_houhou WHERE"
            //                                                                    + " c4_y::Text = CASE WHEN length('" + Cmb_nen_str + "')=2 THEN"
            //                                                                                            + " substr('" + Cmb_nen_str + "',1,1) || ' ' || substr('" + Cmb_nen_str + "', length('" + Cmb_nen_str + "')-1+1, length('" + Cmb_nen_str + "'))"
            //                                                                                        + " ELSE"
            //                                                                                            + "'" + Cmb_nen_str + "'"
            //                                                                                        + " END"
            //                                                                    + " AND c4_m::Text = CASE WHEN length('" + Cmb_tsuki_str + "')=1 THEN"
            //                                                                    + " ' ' || '" + Cmb_tsuki_str + "'"
            //                                                                    + " WHEN length('" + Cmb_tsuki_str + "')=2 THEN"
            //                                                                    + " '' || '" + Cmb_tsuki_str + "'"
            //                                                                    + " END"
            //                                                                    + " AND s_id = t2.s_id"
            //                                                                    + " AND o_id = '" + Form_Seikyu_TextBoxO_id + "'"
            //                                                                + ")"
            //                                                        + ") b ON a.c1 = b.c5"
            //                                                        + " AND rtrim(replace(a.c3,substr(a.c3,strpos(a.c3, '('), strpos(a.c3, ')')),''))"
            //                                                            + " = rtrim(replace(b.c6,substr(b.c6,strpos(b.c6, '('), strpos(b.c6, ')')),''))"
            //                                                        + " AND a.s_id = b.s_id"
            //                                                        + " AND a.o_id = b.o_id"
            //                                                        + ")"
            //                                                //+ " AND b.s_id::Integer = " + Cmb_s_id_int + ")"
            //                                                + " LEFT JOIN (SELECT s_id, o_id, syubetsu, hyoujimei FROM t_syubetsu) c ON a.s_id::Text = c.s_id AND a.o_id = c.o_id)"
            //                                            + " LEFT JOIN (SELECT rep_id, pt_id, s_id, o_id, col0, col1, col2, col3, col4, col5, ac0, ac1, ac2, ac3 FROM t_rep) d ON b.支払方法 = d.pt_id AND a.s_id = d.s_id AND a.o_id::Text = d.o_id)"
            //                                        + " LEFT JOIN (SELECT bid, b_id, b_code, b_name, sb_name, br_code, br_name, sd, sm, sy FROM t_bank) e ON b.c11 = e.b_name)"
            //                                    + " LEFT JOIN (SELECT req_id, title1, title2, title3, title4, data7, data8, title4_kana FROM t_req) f ON a.req_id::Integer = f.req_id)"
            //                                + " LEFT JOIN (SELECT o_id, o_name, o_phone_number FROM t_office) f1 ON a.o_id::Integer = f1.o_id)"
            //                            + " LEFT JOIN (SELECT syutsuryokubi, s_id FROM t_syutsuryokubi) g ON a.s_id = g.s_id)"
            //                        + " LEFT JOIN (SELECT bid, b_id, b_code, b_name, sb_name, br_code, br_name, sd FROM t_bank WHERE b_id = '1') h ON b.c11 = h.b_name)"
            //                    + " LEFT JOIN (SELECT c1, c5, c25, c48, s_id, o_id FROM t_shinzoku_kankei t3"
            //                    + " WHERE c48 = '1' AND time_stamp = "
            //                                                    + "(SELECT max(time_stamp) FROM t_shinzoku_kankei WHERE"
            //                                                        + " c4_y::Text = CASE WHEN length('" + Cmb_nen_str + "')=2 THEN"
            //                                                                                + " substr('" + Cmb_nen_str + "',1,1) || ' ' || substr('" + Cmb_nen_str + "', length('" + Cmb_nen_str + "')-1+1, length('" + Cmb_nen_str + "'))"
            //                                                                            + " ELSE"
            //                                                                                + "'" + Cmb_nen_str + "'"
            //                                                                            + " END"
            //                                                        + " AND c4_m::Text = CASE WHEN length('" + Cmb_tsuki_str + "')=1 THEN"
            //                                                                                + " ' ' || '" + Cmb_tsuki_str + "'"
            //                                                                                + " WHEN length('" + Cmb_tsuki_str + "')=2 THEN"
            //                                                                                + " '' || '" + Cmb_tsuki_str + "'"
            //                                                                                + " END"
            //                                                        + " AND s_id = t3.s_id"
            //                                                        + " AND o_id = '" + Form_Seikyu_TextBoxO_id + "'"
            //                                                    + ")"
            //                                + ") i ON a.c1 = i.c1"
            //                                + " AND a.s_id = i.s_id"
            //                                //+ " AND i.s_id::Integer = " + Cmb_s_id_int
            //                                + " AND i.o_id = '" + Form_Seikyu_TextBoxO_id + "'"
            //                    + ") "
            //                + " LEFT JOIN (SELECT gg_id, g_name, gengou, start_date, end_date, diff FROM t_gengou) k ON substr(c4_y,1,1) = k.g_name)"
            //            + " LEFT JOIN (SELECT m_id, manager, start_date, end_date, o_id FROM t_manager) m ON m.o_id = '" + Form_Seikyu_TextBoxO_id + "'"
            //                + " AND m.start_date <= (SELECT to_date((to_number(c4_y,'999')+k.diff || '/' || to_number(c4_m,'99')+1 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
            //                + " AND (m.end_date Is Null Or m.end_date >= (SELECT to_date((to_number(c4_y,'999')+k.diff || '/' || to_number(c4_m,'99')+1 || '/' || to_number('01','99')),'yyyy/mm/dd')-1) "
            //            + ")"
            //        + " LEFT JOIN (SELECT stf_id, stuff, start_date, end_date, o_id FROM t_stuff) j ON j.o_id = '" + Form_Seikyu_TextBoxO_id + "'"
            //            + " AND j.start_date <= (SELECT to_date((to_number(c4_y,'999')+k.diff || '/' || to_number(c4_m,'99')+1 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
            //            + " AND (j.end_date Is Null Or j.end_date >= (SELECT to_date((to_number(c4_y,'999')+k.diff || '/' || to_number(c4_m,'99')+1 || '/' || to_number('01','99')),'yyyy/mm/dd')-1) "
            //        + ")"
            //        + " LEFT JOIN (SELECT acc_id, accounting_manager, start_date, end_date, acc_kana FROM t_accounting_manager) L ON "
            //            + " L.start_date <= (SELECT to_date((to_number(c4_y,'999')+k.diff || '/' || to_number(c4_m,'99')+1 || '/' || to_number('01','99')),'yyyy/mm/dd')-1)"
            //            + " AND (L.end_date Is Null Or L.end_date >= (SELECT to_date((to_number(c4_y,'999')+k.diff || '/' || to_number(c4_m,'99')+1 || '/' || to_number('01','99')),'yyyy/mm/dd')-1) "
            //        + ")"
            //    + ") ORDER BY a.id"
            //    + ")"
            //    + " SELECT"
            //    + " r_id"
            //    + ", id"
            //    + ", c1"
            //    + ", c3"
            //    + ", c3_mod"
            //    + ", c4"
            //    + ", c4_y || '/' || c4_m c4_ym"
            //    + ", c5"
            //    + ", c6_mod"
            //    + ", c9"
            //    + ", c11"
            //    + ", c14"
            //    + ", c16"
            //    + ", c19"
            //    + ", c22"
            //    + ", s_id"
            //    + ", o_id"
            //    + ", w_flg"
            //    + ", req_id"
            //    + ", syubetsu"
            //    + ", 支払方法"
            //    + ", 引落口座種別"
            //    + ", 事業所名"
            //    + ", col0"
            //    + ", col1"
            //    + ", col2"
            //    + ", col3"
            //    + ", col4"
            //    + ", col5"
            //    + ", ac0"
            //    + ", ac1"
            //    + ", ac2"
            //    + ", ac3"
            //    + ", 引落口座番号"
            //    + ", 引落口座名義人"
            //    + ", 引落金融機関銀行名"
            //    + ", b_code"
            //    + ", b_name"
            //    + ", br_code"
            //    + ", sb_name"
            //    + ", sd"
            //    + ", title1"
            //    + ", title2"
            //    + ", title3"
            //    + ", title4"
            //    + ", manager"
            //    + ", stuff"
            //    + ", o_phone_number name5"
            //    + ", o_name data6"
            //    + ", data7"
            //    + ", data8"
            //    + ", title4_kana"
            //    + ", accounting_manager"
            //    + ", acc_kana"
            //    + ", syutsuryokubi"
            //    + ", _b_code"
            //    + ", _br_code"
            //    + ", _br_name"
            //    + ", shiharaisya"
            //    + ", target_date last_day"
            //    + ", gengou"
            //    + ", g_name"
            //    + ", start_date"
            //    + ", end_date"
            //    + ", diff"
            //    + " FROM r"
            //    + " WHERE CASE WHEN '" + Cmb_b_code_str + "' ='0000' THEN"
            //        + " c9 = ''"
            //        + " ELSE"
            //        + " c9 = '" + Cmb_b_code_str + "'"
            //        + " END;"
            //    , m_conn
            //        );

            //// update
            //da.UpdateCommand = new NpgsqlCommand(
            //    "UPDATE t_seikyu SET w_flg = :w_flg"
            //    + " WHERE"
            //    //+ " c4_y = '" + Cmb_nen_str + "'AND"
            //    //+ " c4_m = '" + Cmb_tsuki_str + "' AND"
            //    + " r_id = :r_id;"
            //    , m_conn
            //    );
            ////da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4_y", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4_y", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            ////da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4_y", NpgsqlTypes.NpgsqlDbType.Text) { Value = " + Cmb_nen_str + " });
            ////da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4_m", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4_m", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            ////da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4_m", NpgsqlTypes.NpgsqlDbType.Text) { Value = " + Cmb_tsuki_str + " });
            //da.UpdateCommand.Parameters.Add(new NpgsqlParameter("w_flg", NpgsqlTypes.NpgsqlDbType.Integer, 0, "w_flg", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            //da.UpdateCommand.Parameters.Add(new NpgsqlParameter("r_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "r_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));






            //this.textBoxO_id.Text = Form_Seikyu_TextBoxO_id;
            //this.textBoxS_id.Text = Form_Seikyu_TextBoxS_id;
            //this.textBoxN_id.Text = Form_Seikyu_TextBoxN_id;
            //this.textBoxT_id.Text = Form_Seikyu_TextBoxT_id;
            //this.textBoxNen.Text = Form_Seikyu_TextBoxNen;
            //this.textBoxTsuki.Text = Form_Seikyu_TextBoxTsuki;

            //Console.WriteLine("Form_Seikyu_TextBoxO_id = " + Form_Seikyu_TextBoxO_id);
            //Console.WriteLine("Form_Seikyu_TextBoxS_id = " + Form_Seikyu_TextBoxS_id);
            //Console.WriteLine("Form_Seikyu_TextBoxN_id = " + Form_Seikyu_TextBoxN_id);
            //Console.WriteLine("Form_Seikyu_TextBoxT_id = " + Form_Seikyu_TextBoxT_id);
            //Console.WriteLine("Form_Seikyu_TextBoxNen = " + Form_Seikyu_TextBoxNen);
            //Console.WriteLine("Form_Seikyu_TextBoxTsuki = " + Form_Seikyu_TextBoxTsuki);


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
            cmb_nen.SelectedValue = Form_Seikyu_TextBoxNen;

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
            cmb_tsuki.SelectedValue = Form_Seikyu_TextBoxTsuki;

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
            if (prn_id_ds.Tables["t_prn_syubetsu"] != null)
                prn_id_ds.Tables["t_prn_syubetsu"].Clear();
            prn_id_da.Fill(prn_id_ds, "t_prn_syubetsu");

            cmb_prn_id.DataSource = prn_id_ds.Tables["t_prn_syubetsu"];
            cmb_prn_id.DisplayMember = "syubetsu";
            cmb_prn_id.ValueMember = "ps_id";
            this.cmb_prn_id.SelectedIndex = 0;
            //cmb_prn_id.SelectedIndexChanged += new EventHandler(Cmb_prn_id_SelectedIndexChanged);

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
            if (b_codeds.Tables["t_bank"] != null)
                b_codeds.Tables["t_bank"].Clear();
            b_code_da.Fill(b_codeds, "t_bank");

            cmb_b_code.DataSource = b_codeds.Tables["t_bank"];
            cmb_b_code.DisplayMember = "b_name";
            cmb_b_code.ValueMember = "b_code";
            cmb_b_code.SelectedIndexChanged += new EventHandler(Cmb_b_code_SelectedIndexChanged);

            // コンボボックスで支払者を表示
            c19_da.SelectCommand = new NpgsqlCommand
            (
                   "SELECT"
                   + " b.c1,CASE WHEN a.c19 = '' THEN a.c6 ELSE a.c19 END c19"
                   + " FROM t_shiharai_houhou a INNER JOIN t_seikyu b"
                   + " ON a.c5 = b.c1"
                   + " WHERE b.c4_y = '" + Form_Seikyu_TextBoxNen + "'"
                   + " AND b.c4_m = CASE WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=1 THEN"
                                                            + " ' ' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=2 THEN"
                                                            + " '' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " END"
                   + " AND b.s_id = '" + Form_Seikyu_TextBoxS_id + "'"
                   + " AND b.o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                   + " AND a.time_stamp = (SELECT max(time_stamp) FROM t_shiharai_houhou WHERE c4_y = '" + Form_Seikyu_TextBoxNen + "'"
                                                            + " AND c4_m = CASE WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=1 THEN"
                                                            + " ' ' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=2 THEN"
                                                            + " '' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " END"
                                                            + " AND s_id = '" + Form_Seikyu_TextBoxS_id + "' AND o_id = '" + Form_Seikyu_TextBoxO_id + "')"
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
                   + " WHERE b.c4_y = '" + Form_Seikyu_TextBoxNen + "'"
                   + " AND b.c4_m = CASE WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=1 THEN"
                                                            + " ' ' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=2 THEN"
                                                            + " '' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " END"
                   + " AND b.s_id = '" + Form_Seikyu_TextBoxS_id + "'"
                   + " AND b.o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                   + " AND a.time_stamp = (SELECT max(time_stamp) FROM t_shiharai_houhou WHERE c4_y = '" + Form_Seikyu_TextBoxNen + "'"
                                                            + " AND c4_m = CASE WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=1 THEN"
                                                            + " ' ' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=2 THEN"
                                                            + " '' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " END"
                                                            + " AND s_id = '" + Form_Seikyu_TextBoxS_id + "' AND o_id = '" + Form_Seikyu_TextBoxO_id + "')"
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
                   + " WHERE b.c4_y = '" + Form_Seikyu_TextBoxNen + "'"
                   + " AND b.c4_m = CASE WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=1 THEN"
                                                            + " ' ' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=2 THEN"
                                                            + " '' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " END"
                   + " AND b.s_id = '" + Form_Seikyu_TextBoxS_id + "'"
                   + " AND b.o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                   + " AND a.time_stamp = (SELECT max(time_stamp) FROM t_shiharai_houhou WHERE c4_y = '" + Form_Seikyu_TextBoxNen + "'"
                                                            + " AND c4_m = CASE WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=1 THEN"
                                                            + " ' ' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=2 THEN"
                                                            + " '' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " END"
                                                            + " AND s_id = '" + Form_Seikyu_TextBoxS_id + "' AND o_id = '" + Form_Seikyu_TextBoxO_id + "')"
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
                   + " WHERE b.c4_y = '" + Form_Seikyu_TextBoxNen + "'"
                   + " AND b.c4_m = CASE WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=1 THEN"
                                                            + " ' ' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=2 THEN"
                                                            + " '' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " END"
                   + " AND b.s_id = '" + Form_Seikyu_TextBoxS_id + "'"
                   + " AND b.o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                   + " AND a.time_stamp = (SELECT max(time_stamp) FROM t_shiharai_houhou WHERE c4_y = '" + Form_Seikyu_TextBoxNen + "'"
                                                            + " AND c4_m = CASE WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=1 THEN"
                                                            + " ' ' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=2 THEN"
                                                            + " '' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " END"
                                                            + " AND s_id = '" + Form_Seikyu_TextBoxS_id + "' AND o_id = '" + Form_Seikyu_TextBoxO_id + "')"
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
                   + " WHERE b.c4_y = '" + Form_Seikyu_TextBoxNen + "'"
                   + " AND b.c4_m = CASE WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=1 THEN"
                                                            + " ' ' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=2 THEN"
                                                            + " '' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " END"
                   + " AND b.s_id = '" + Form_Seikyu_TextBoxS_id + "'"
                   + " AND b.o_id = '" + Form_Seikyu_TextBoxO_id + "'"
                   + " AND a.time_stamp = (SELECT max(time_stamp) FROM t_shiharai_houhou WHERE c4_y = '" + Form_Seikyu_TextBoxNen + "'"
                                                            + " AND c4_m = CASE WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=1 THEN"
                                                            + " ' ' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=2 THEN"
                                                            + " '' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " END"
                                                            + " AND s_id = '" + Form_Seikyu_TextBoxS_id + "' AND o_id = '" + Form_Seikyu_TextBoxO_id + "')"
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

            // RowUpdate
            //da.RowUpdated += new NpgsqlRowUpdatedEventHandler(AbdRowUpdated);

            //if (abd_ds.Tables["abd_ds"] != null)
            //    abd_ds.Tables["abd_ds"].Clear();
            //da.Fill(abd_ds, "abd_ds");

            //bindingSourceAbd.DataSource = abd_ds;
            //bindingSourceAbd.DataMember = "abd_ds";

            //bindingNavigatorAbd.BindingSource = bindingSourceAbd;

            //dataGridViewAbd.AutoGenerateColumns = false;

            //dataGridViewAbd.DataSource = bindingSourceAbd;

            //dataGridViewAbd.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            //crvSeikyu.Visible = false;
            //bindingNavigatorWithdrawal.Visible = true;
            //dataGridViewWithdrawal.Visible = true;


            dataGridViewAbd.Columns[0].HeaderText = "□";
            dataGridViewAbd.Columns[1].HeaderText = "氏名";
            dataGridViewAbd.Columns[2].HeaderText = "支払者";
            dataGridViewAbd.Columns[3].HeaderText = "年月";
            dataGridViewAbd.Columns[4].HeaderText = "銀行ｺｰﾄﾞ";
            dataGridViewAbd.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewAbd.Columns[5].HeaderText = "金融機関名";
            dataGridViewAbd.Columns[6].HeaderText = "支店名";
            dataGridViewAbd.Columns[7].HeaderText = "口座番号";
            dataGridViewAbd.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewAbd.Columns[8].HeaderText = "請求額";
            dataGridViewAbd.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewAbd.Columns[8].DefaultCellStyle.Format = "#,##0";
            dataGridViewAbd.Columns[9].HeaderText = "種別";
            dataGridViewAbd.Columns[10].HeaderText = "番号";
            dataGridViewAbd.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dataGridViewAbd.Columns[11].HeaderText = "引落日ﾞ";

            da.SelectCommand = new NpgsqlCommand
            (
                   "SELECT"
                + " a.w_flg"
                + ", a.c3"
                + ", a.c1"
                + ", concat_ws('/', a.c4_y, a.c4_m) c4_ym"
                + ", a.c9"
                + ", a.c1 c1_bc"
                + ", a.c11"
                + ", a.c1 c1_bn"
                + ", a.c14"
                + ", a.c1 c1_brn"
                + ", a.c16"
                + ", a.c1 c1_acn"
                + ", a.c22"
                + ", a.s_id"
                + ", a.o_id"
                + ", a.r_id"
                //+ ", last_day"
                + " FROM"
                + " t_seikyu a"
                + " WHERE a.time_stamp = (SELECT max(time_stamp) FROM t_seikyu b"
                + " WHERE b.c4_m = CASE WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=1 THEN"
                                                            + " ' ' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " WHEN length('" + Form_Seikyu_TextBoxTsuki + "')=2 THEN"
                                                            + " '' || '" + Form_Seikyu_TextBoxTsuki + "'"
                                                            + " END"
                + " AND b.s_id = '" + Form_Seikyu_TextBoxS_id + "'"
                + " AND b.o_id = '" + Form_Seikyu_TextBoxO_id + "')"
                + " ORDER BY a.r_id;",
                m_conn
                );
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
    }
}
