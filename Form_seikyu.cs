using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Npgsql;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.SqlTypes;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;

namespace rk_seikyu
{
    public partial class Form_seikyu : Form
    {
        private NpgsqlConnection m_conn = new NpgsqlConnection(rk_seikyu.Properties.Settings.Default.PostgresConnect);

        private NpgsqlDataAdapter da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter New_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter t_id_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter n_id_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter s_id_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter g_id_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter req_id_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter sub_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter cmb_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter dup_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter c4_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter nen_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter tsuki_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter o_id_da = new NpgsqlDataAdapter();


        private DataSet _seikyu_ds = new DataSet();
        private DataSet _shiharai_houhou_ds = new DataSet();
        private DataSet _shinzoku_kankei_ds = new DataSet();

        private DataSet New_ds = new DataSet();
        private DataSet n_id_ds = new DataSet();
        private DataSet t_id_ds = new DataSet();
        private DataSet s_id_ds = new DataSet();
        private DataSet g_id_ds = new DataSet();
        private DataSet req_id_ds = new DataSet();
        private DataSet c4_ds = new DataSet();
        private DataSet o_id_ds = new DataSet();

        private DataSet Cntds = new DataSet();
        private DataSet CntMends = new DataSet();
        private DataSet CntWomends = new DataSet();
        private DataSet Cmbds = new DataSet();
        private DataSet dupds = new DataSet();
        private DataSet nends = new DataSet();
        private DataSet tsukids = new DataSet();

        public string ofdstr { get; set; }
        public string tblStr { get; set; }
        public string onumStr { get; set; }

        public int cmb_n_id_int { get; set; }
        public int cmb_t_id_int { get; set; }
        public int cmb_s_id_int { get; set; }
        public int cmb_g_id_int { get; set; }
        public int cmb_o_id_int { get; set; }
        public int cmb_req_id_int { get; set; }


        public String cmb_c4_str { get; set; }
        public String cmb_nen_str { get; set; }
        public String cmb_tsuki_str { get; set; }
        public String cmb_s_id_str { get; set; }

        public int hour { get; set; }
        public int minute { get; set; }
        public int second { get; set; }

        public int VarHour { get; set; }
        public int VarMinute { get; set; }
        public int VarSecond { get; set; }

        public string cmb_o_id_str_TEXT { get => cmb_o_id.SelectedIndex.ToString(); set => cmb_o_id.Text = value; }
        private static Form_seikyu _form_seikyu_Instance;
        //private Form_seikyu form_seikyu_Instance;

        public String cmb_o_id_str;

        public Form_seikyu()
        {
            InitializeComponent();
            _form_seikyu_Instance = this;
            //this.cmb_o_id.SelectedIndex = 0;

        }

        //Form_seikyuインスタンスを設定、取得する。
        public static Form_seikyu Form_seikyu_Instance { get => _form_seikyu_Instance; set => _form_seikyu_Instance = value; }
        //文字列変数cmb_o_id_Textへコンボボックスcmb_o_idの値を設定、取得する。
        public string cmb_o_id_Text { get => cmb_o_id.SelectedIndex.ToString(); set => cmb_o_id.Text = value; }

        private void Form_seikyu_Load(object sender, EventArgs e)
        {
            // TODO: このコード行はデータを 'o_id_ds1.DataTable' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            //this.dataTableTableAdapter.Fill(this.o_id_ds1.DataTable);
            o_id_da.SelectCommand = new NpgsqlCommand
            (
                    "select"
                + " o_id"
                + ", o_number"
                + ", o_name"
                + ", o_p_code"
                + ", o_address"
                + ", o_phone_number"
                + ", o_manager"
                + ", o_stuff"
                + " from"
                + " t_office"
                + " order by o_id;",
                m_conn
            );

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
                + " where o_id = '" + cmb_o_id_int + "'"
                + " and s_id = '" + cmb_s_id_int + "'"
                + " order by s_id;",
                    m_conn
            );

            g_id_da.SelectCommand = new NpgsqlCommand
            (
                   "select"
                  + " g_id"
                  + ", gyoumu"
                  + " from t_gyoumu"
                  + " order by g_id;",
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
                  + " from t_req"
                  + " order by req_id;",
                    m_conn
            );

            if (nends.Tables["t_nen"] != null)
                nends.Tables["t_nen"].Clear();
            nen_da.Fill(nends, "t_nen");

            if (tsukids.Tables["t_tsuki"] != null)
                tsukids.Tables["t_tsuki"].Clear();
            tsuki_da.Fill(tsukids, "t_tsuki");

            if (o_id_ds.Tables["t_office"] != null)
                o_id_ds.Tables["t_office"].Clear();
            o_id_da.Fill(o_id_ds, "t_office");

            if (c4_ds.Tables["t_seikyu"] != null)
                c4_ds.Tables["t_seikyu"].Clear();
            c4_da.Fill(c4_ds, "t_seikyu");

            if (s_id_ds.Tables["t_syubetsu"] != null)
                s_id_ds.Tables["t_syubetsu"].Clear();
            s_id_da.Fill(s_id_ds, "t_syubetsu");

            g_id_da.Fill(g_id_ds, "t_gyoumu");

            req_id_da.Fill(req_id_ds, "t_req");

            cmb_nen.DataSource = nends.Tables[0];
            cmb_nen.DisplayMember = "nen";
            cmb_nen.ValueMember = "nen";

            cmb_tsuki.DataSource = tsukids.Tables[0];
            cmb_tsuki.DisplayMember = "tsuki";
            cmb_tsuki.ValueMember = "tsuki";

            cmb_o_id.DataSource = o_id_ds.Tables[0]; ;
            cmb_o_id.DisplayMember = "o_name";
            cmb_o_id.ValueMember = "o_id";

            cmb_c4.DataSource = c4_ds.Tables[0];
            cmb_c4.DisplayMember = "c4";
            cmb_c4.ValueMember = "c4";

            cmb_s_id.DataSource = s_id_ds.Tables[0]; ;
            cmb_s_id.DisplayMember = "syubetsu";
            cmb_s_id.ValueMember = "s_id";

            cmb_g_id.DataSource = g_id_ds.Tables[0]; ;
            cmb_g_id.DisplayMember = "gyoumu";
            cmb_g_id.ValueMember = "g_id";

            cmb_req_id.DataSource = req_id_ds.Tables[0]; ;
            cmb_req_id.DisplayMember = "name1";
            cmb_req_id.ValueMember = "req_id";

            switch (cmb_g_id_int)
            {
                case 1:
                    tblStr = " t_seikyu";
                    Console.WriteLine("tblStr = " + tblStr);
                    dataGridViewSeikyu.Columns[0].HeaderText = "利用者番号";
                    dataGridViewSeikyu.Columns[1].HeaderText = "要介護度";
                    dataGridViewSeikyu.Columns[2].HeaderText = "利用者名";
                    dataGridViewSeikyu.Columns[3].HeaderText = "提供月";
                    dataGridViewSeikyu.Columns[4].HeaderText = "合計額";
                    dataGridViewSeikyu.Columns[5].HeaderText = "サービス費（保険請求）";
                    dataGridViewSeikyu.Columns[6].HeaderText = "サービス費（公費請求）";
                    dataGridViewSeikyu.Columns[7].HeaderText = "食費（保険請求）";
                    dataGridViewSeikyu.Columns[8].HeaderText = "食費（公費請求）";
                    dataGridViewSeikyu.Columns[9].HeaderText = "居住費（保険請求）";
                    dataGridViewSeikyu.Columns[10].HeaderText = "居住費（公費請求）";
                    dataGridViewSeikyu.Columns[11].HeaderText = "介護請求合計額";
                    dataGridViewSeikyu.Columns[12].HeaderText = "利用者負担額";
                    dataGridViewSeikyu.Columns[13].HeaderText = "自費負担額";
                    dataGridViewSeikyu.Columns[14].HeaderText = "食事負担額";
                    dataGridViewSeikyu.Columns[15].HeaderText = "室料負担額";
                    dataGridViewSeikyu.Columns[16].HeaderText = "特定公費本人支払";
                    dataGridViewSeikyu.Columns[17].HeaderText = "高額介護超過額";
                    dataGridViewSeikyu.Columns[18].HeaderText = "その他実費";
                    dataGridViewSeikyu.Columns[19].HeaderText = "減免額";
                    dataGridViewSeikyu.Columns[20].HeaderText = "過入金";
                    dataGridViewSeikyu.Columns[21].HeaderText = "利用料請求合計額";
                    dataGridViewSeikyu.Columns[21].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("ja-JP");
                    dataGridViewSeikyu.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    for (int i = 0; i < dataGridViewSeikyu.Columns.Count; i++)
                    {
                        if (i < 1 || i > 3)
                        {
                            dataGridViewSeikyu.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            dataGridViewSeikyu.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridViewSeikyu.Columns[i].DefaultCellStyle.Format = "#,0";
                        }
                        else
                        {
                            dataGridViewSeikyu.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            dataGridViewSeikyu.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        }
                    }

                    break;
                case 2:
                    tblStr = "t_shiharai_houhou";
                    Console.WriteLine("tblStr = " + tblStr);
                    dataGridViewShiharai_houhou.Columns[0].HeaderText = "法人名";
                    dataGridViewShiharai_houhou.Columns[1].HeaderText = "施設名";
                    dataGridViewShiharai_houhou.Columns[2].HeaderText = "事業所番号";
                    dataGridViewShiharai_houhou.Columns[3].HeaderText = "事業所名";
                    dataGridViewShiharai_houhou.Columns[4].HeaderText = "利用者番号";
                    dataGridViewShiharai_houhou.Columns[5].HeaderText = "利用者名";
                    dataGridViewShiharai_houhou.Columns[6].HeaderText = "支払方法";
                    dataGridViewShiharai_houhou.Columns[7].HeaderText = "引落口座";
                    dataGridViewShiharai_houhou.Columns[8].HeaderText = "引落金融機関銀行コード";
                    dataGridViewShiharai_houhou.Columns[9].HeaderText = "引落金融機関銀行名（フリガナ）";
                    dataGridViewShiharai_houhou.Columns[10].HeaderText = "引落金融機関銀行名";
                    dataGridViewShiharai_houhou.Columns[11].HeaderText = "引落金融機関支店コード";
                    dataGridViewShiharai_houhou.Columns[12].HeaderText = "引落金融機関支店名（フリガナ）";
                    dataGridViewShiharai_houhou.Columns[13].HeaderText = "引落金融機関支店名";
                    dataGridViewShiharai_houhou.Columns[14].HeaderText = "引落口座種別";
                    dataGridViewShiharai_houhou.Columns[15].HeaderText = "引落口座番号";
                    dataGridViewShiharai_houhou.Columns[16].HeaderText = "引落口座名義人区分";
                    dataGridViewShiharai_houhou.Columns[17].HeaderText = "引落口座名義人（フリガナ）";
                    dataGridViewShiharai_houhou.Columns[18].HeaderText = "引落口座名義人";
                    dataGridViewShiharai_houhou.Columns[19].HeaderText = "引落口座開設日";
                    dataGridViewShiharai_houhou.Columns[20].HeaderText = "引落口座解約日";
                    dataGridViewShiharai_houhou.Columns[21].HeaderText = "引落口座メモ";
                    dataGridViewShiharai_houhou.Columns[22].HeaderText = "振込先委託者名（フリガナ）";
                    dataGridViewShiharai_houhou.Columns[23].HeaderText = "振込先委託者名";
                    dataGridViewShiharai_houhou.Columns[24].HeaderText = "振込先委託者コード";
                    dataGridViewShiharai_houhou.Columns[25].HeaderText = "振込先金融機関銀行コード";
                    dataGridViewShiharai_houhou.Columns[26].HeaderText = "振込先金融機関銀行名（フリガナ）";
                    dataGridViewShiharai_houhou.Columns[27].HeaderText = "振込先金融機関銀行名";
                    dataGridViewShiharai_houhou.Columns[28].HeaderText = "振込先金融機関支店コード";
                    dataGridViewShiharai_houhou.Columns[29].HeaderText = "振込先金融機関支店名（フリガナ）";
                    dataGridViewShiharai_houhou.Columns[30].HeaderText = "振込先金融機関支店名";
                    dataGridViewShiharai_houhou.Columns[31].HeaderText = "振込先口座種別";
                    dataGridViewShiharai_houhou.Columns[32].HeaderText = "振込先口座番号";
                    dataGridViewShiharai_houhou.Columns[33].HeaderText = "振込先口座記号";
                    dataGridViewShiharai_houhou.Columns[34].HeaderText = "振込先引落日";
                    dataGridViewShiharai_houhou.Columns[35].HeaderText = "振込先再振替日";
                    dataGridViewShiharai_houhou.Columns[36].HeaderText = "振込先契約種別コード";
                    dataGridViewShiharai_houhou.Columns[37].HeaderText = "振込先受入事業所センターコード";
                    dataGridViewShiharai_houhou.Columns[38].HeaderText = "振込先手数料：自行";
                    dataGridViewShiharai_houhou.Columns[39].HeaderText = "振込先手数料：他行";
                    dataGridViewShiharai_houhou.Columns[40].HeaderText = "初回引落月";
                    dataGridViewShiharai_houhou.Columns[41].HeaderText = "顧客番号";
                    dataGridViewShiharai_houhou.Columns[42].HeaderText = "被保険者番号";
                    dataGridViewShiharai_houhou.Columns[43].HeaderText = "被保険者氏名";
                    dataGridViewShiharai_houhou.Columns[44].HeaderText = "預金者郵便番号";
                    dataGridViewShiharai_houhou.Columns[45].HeaderText = "預金者氏名";
                    dataGridViewShiharai_houhou.Columns[46].HeaderText = "預金者住所１";
                    dataGridViewShiharai_houhou.Columns[47].HeaderText = "預金者住所２";
                    dataGridViewShiharai_houhou.Columns[48].HeaderText = "預金者住所３";

                    for (int i = 0; i < dataGridViewShiharai_houhou.Columns.Count; i++)
                    {
                        dataGridViewShiharai_houhou.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridViewShiharai_houhou.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    }

                    break;
                case 3:
                    tblStr = " t_shinzoku_kankei";
                    Console.WriteLine("tblStr = " + tblStr);
                    dataGridViewShinzoku_kankei.Columns[0].HeaderText = "利用者番号";
                    dataGridViewShinzoku_kankei.Columns[1].HeaderText = "利用者名（姓）";
                    dataGridViewShinzoku_kankei.Columns[2].HeaderText = "利用者名（名）";
                    dataGridViewShinzoku_kankei.Columns[3].HeaderText = "利用者名";
                    dataGridViewShinzoku_kankei.Columns[4].HeaderText = "フリガナ（姓）";
                    dataGridViewShinzoku_kankei.Columns[5].HeaderText = "フリガナ（名）";
                    dataGridViewShinzoku_kankei.Columns[6].HeaderText = "フリガナ";
                    dataGridViewShinzoku_kankei.Columns[7].HeaderText = "同名識別";
                    dataGridViewShinzoku_kankei.Columns[8].HeaderText = "性別";
                    dataGridViewShinzoku_kankei.Columns[9].HeaderText = "血液型";
                    dataGridViewShinzoku_kankei.Columns[10].HeaderText = "RH";
                    dataGridViewShinzoku_kankei.Columns[11].HeaderText = "生年月日";
                    dataGridViewShinzoku_kankei.Columns[12].HeaderText = "郵便番号";
                    dataGridViewShinzoku_kankei.Columns[13].HeaderText = "住所";
                    dataGridViewShinzoku_kankei.Columns[14].HeaderText = "電話番号";
                    dataGridViewShinzoku_kankei.Columns[15].HeaderText = "携帯番号";
                    dataGridViewShinzoku_kankei.Columns[16].HeaderText = "E-mail";
                    dataGridViewShinzoku_kankei.Columns[17].HeaderText = "郵便番号（他の住所）";
                    dataGridViewShinzoku_kankei.Columns[18].HeaderText = "住所（他の住所）";
                    dataGridViewShinzoku_kankei.Columns[19].HeaderText = "世帯区分";
                    dataGridViewShinzoku_kankei.Columns[20].HeaderText = "メモ";
                    dataGridViewShinzoku_kankei.Columns[21].HeaderText = "統計用住所";
                    dataGridViewShinzoku_kankei.Columns[22].HeaderText = "親族・関係者名（姓）";
                    dataGridViewShinzoku_kankei.Columns[23].HeaderText = "親族・関係者名（名）";
                    dataGridViewShinzoku_kankei.Columns[24].HeaderText = "親族・関係者名";
                    dataGridViewShinzoku_kankei.Columns[25].HeaderText = "フリガナ（姓）（親族・関係者）";
                    dataGridViewShinzoku_kankei.Columns[26].HeaderText = "フリガナ（名）（親族・関係者）";
                    dataGridViewShinzoku_kankei.Columns[27].HeaderText = "フリガナ（親族・関係者）";
                    dataGridViewShinzoku_kankei.Columns[28].HeaderText = "性別（親族・関係者）";
                    dataGridViewShinzoku_kankei.Columns[29].HeaderText = "生年月日（親族・関係者）";
                    dataGridViewShinzoku_kankei.Columns[30].HeaderText = "続柄";
                    dataGridViewShinzoku_kankei.Columns[31].HeaderText = "健康状態";
                    dataGridViewShinzoku_kankei.Columns[32].HeaderText = "職業";
                    dataGridViewShinzoku_kankei.Columns[33].HeaderText = "〒（親族・関係者）";
                    dataGridViewShinzoku_kankei.Columns[34].HeaderText = "住所（親族・関係者）";
                    dataGridViewShinzoku_kankei.Columns[35].HeaderText = "住所（地域）（親族・関係者）";
                    dataGridViewShinzoku_kankei.Columns[36].HeaderText = "宛先";
                    dataGridViewShinzoku_kankei.Columns[37].HeaderText = "電話番号（親族・関係者）";
                    dataGridViewShinzoku_kankei.Columns[38].HeaderText = "携帯番号（親族・関係者）";
                    dataGridViewShinzoku_kankei.Columns[39].HeaderText = "E-mail（親族・関係者）";
                    dataGridViewShinzoku_kankei.Columns[40].HeaderText = "連絡先種別";
                    dataGridViewShinzoku_kankei.Columns[41].HeaderText = "連絡先番号";
                    dataGridViewShinzoku_kankei.Columns[42].HeaderText = "優先順";
                    dataGridViewShinzoku_kankei.Columns[43].HeaderText = "申請者";
                    dataGridViewShinzoku_kankei.Columns[44].HeaderText = "同居家族";
                    dataGridViewShinzoku_kankei.Columns[45].HeaderText = "主介護者";
                    dataGridViewShinzoku_kankei.Columns[46].HeaderText = "保証人";
                    dataGridViewShinzoku_kankei.Columns[47].HeaderText = "支払者";
                    dataGridViewShinzoku_kankei.Columns[48].HeaderText = "相談者";
                    dataGridViewShinzoku_kankei.Columns[49].HeaderText = "（未使用1）";
                    dataGridViewShinzoku_kankei.Columns[50].HeaderText = "（未使用2）";
                    dataGridViewShinzoku_kankei.Columns[51].HeaderText = "（未使用3）";
                    dataGridViewShinzoku_kankei.Columns[52].HeaderText = "（未使用4）";
                    dataGridViewShinzoku_kankei.Columns[53].HeaderText = "メモ（親族・関係者）";
                    dataGridViewShinzoku_kankei.Columns[54].HeaderText = "面会";
                    dataGridViewShinzoku_kankei.Columns[55].HeaderText = "郵便番号（連絡先住所）";
                    dataGridViewShinzoku_kankei.Columns[56].HeaderText = "住所（連絡先住所）";
                    dataGridViewShinzoku_kankei.Columns[57].HeaderText = "FAX番号";

                    for (int i = 0; i < dataGridViewShinzoku_kankei.Columns.Count; i++)
                    {
                        dataGridViewShinzoku_kankei.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridViewShinzoku_kankei.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    }

                    break;
            }


            // 再表示
            switch (cmb_o_id_int)
            {
                case 1:
                    Console.WriteLine("Case " + cmb_o_id_int + "!");

                    switch (cmb_g_id_int)
                    {
                        case 1:
                            Console.WriteLine("Case " + cmb_g_id_int + "!");
                            switch (cmb_s_id_int)
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:

                                    Console.WriteLine("Case " + cmb_s_id_int + "!");

                                    da.SelectCommand = new NpgsqlCommand
                                    (
                                        "select"
                                        + " c1"
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
                                        + ", cast(c6 as Integer) + cast(c7 as Integer) + cast(c8 as Integer) + cast(c9 as Integer) + cast(c10 as Integer) + cast(c11 as Integer) c12"
                                        //+ ", c12"
                                        + ", c13"
                                        + ", c14"
                                        + ", c15"
                                        + ", c16"
                                        + ", c17"
                                        + ", c18"
                                        + ", c19"
                                        + ", c20"
                                        + ", c21"
                                        + ", cast(c13 as Integer) + cast(c14 as Integer) + cast(c15 as Integer) + cast(c16 as Integer) + cast(c19 as Integer) c22"
                                        //+ ", c22"
                                        + ", c4_array"
                                        + ", time_stamp"
                                        + ", r_id"
                                        + ", s_id"
                                        + ", o_id"
                                        + ", id"
                                        + ", p_id"
                                        + ", req_id"
                                        + " from"
                                        + " t_seikyu"
                                        + " where time_stamp = (select max(time_stamp) from t_seikyu"
                                        + " where s_id::Integer = " + cmb_s_id_int
                                        + " and g_id::Integer = " + cmb_g_id_int
                                        + " and o_id::Integer = " + cmb_o_id_int
                                        + " and c4_array[1]::text || '/' || c4_array[2]::Text = case when length('" + cmb_tsuki_str + "')=1 then"
                                                        + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                                                        + "       when length('" + cmb_tsuki_str + "')=2 then"
                                                        + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                                                        + " end)"
                                        //+ " order by id"
                                        , m_conn
                                    );

                                    if (cmb_c4.SelectedItem == null)
                                    {
                                        da.SelectCommand.Parameters.Add(new NpgsqlParameter("c4",
                                        NpgsqlTypes.NpgsqlDbType.Text, 0, "c4",
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

                                    // update
                                    da.UpdateCommand = new NpgsqlCommand(
                                            "update t_seikyu set"
                                            + " c1 = :c1"
                                            + ", c2 = :c2"
                                            + ", c3 = :c3"
                                            + ", c4 = :c4"
                                            + ", c5 = :c5"
                                            + ", c6 = :c6"
                                            + ", c7 = :c7"
                                            + ", c8 = :c8"
                                            + ", c9 = :c9"
                                            + ", c10 = :c10"
                                            + ", c11 = :c11"
                                            + ", c12 = :c12"
                                            + ", c13 = :c13"
                                            + ", c14 = :c14"
                                            + ", c15 = :c15"
                                            + ", c16 = :c16"
                                            + ", c17 = :c17"
                                            + ", c18 = :c18"
                                            + ", c19 = :c19"
                                            + ", c20 = :c20"
                                            + ", c21 = :c21"
                                            + ", c22 = :c22"
                                            + ", c4_array = :c4_array"
                                            + ", id = :id"
                                            + ", req_id = :req_id"
                                            + ", s_id = :s_id"
                                            + ", g_id = :g_id"
                                            + ", o_id = :o_id"
                                            + " where r_id=:r_id;"
                                        , m_conn
                                        );
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c1", NpgsqlTypes.NpgsqlDbType.Text, 0, "c1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c2", NpgsqlTypes.NpgsqlDbType.Text, 0, "c2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c3", NpgsqlTypes.NpgsqlDbType.Text, 0, "c3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c5", NpgsqlTypes.NpgsqlDbType.Text, 0, "c5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c6", NpgsqlTypes.NpgsqlDbType.Text, 0, "c6", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c7", NpgsqlTypes.NpgsqlDbType.Text, 0, "c7", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c8", NpgsqlTypes.NpgsqlDbType.Text, 0, "c8", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c9", NpgsqlTypes.NpgsqlDbType.Text, 0, "c9", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c10", NpgsqlTypes.NpgsqlDbType.Text, 0, "c10", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c11", NpgsqlTypes.NpgsqlDbType.Text, 0, "c11", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c12", NpgsqlTypes.NpgsqlDbType.Text, 0, "c12", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c13", NpgsqlTypes.NpgsqlDbType.Text, 0, "c13", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c14", NpgsqlTypes.NpgsqlDbType.Text, 0, "c14", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c15", NpgsqlTypes.NpgsqlDbType.Text, 0, "c15", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c16", NpgsqlTypes.NpgsqlDbType.Text, 0, "c16", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c17", NpgsqlTypes.NpgsqlDbType.Text, 0, "c17", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c18", NpgsqlTypes.NpgsqlDbType.Text, 0, "c18", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c19", NpgsqlTypes.NpgsqlDbType.Text, 0, "c19", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c20", NpgsqlTypes.NpgsqlDbType.Text, 0, "c20", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c21", NpgsqlTypes.NpgsqlDbType.Text, 0, "c21", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c22", NpgsqlTypes.NpgsqlDbType.Text, 0, "c22", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4_array", NpgsqlTypes.NpgsqlDbType.Array | NpgsqlTypes.NpgsqlDbType.Text, 0, "c4_array", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("req_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "req_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("g_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "g_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("r_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "r_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                                    // delete
                                    da.DeleteCommand = new NpgsqlCommand
                                    (
                                           "delete from t_seikyu"
                                        + " where"
                                        + " r_id=:r_id;"
                                        , m_conn
                                    );
                                    da.DeleteCommand.Parameters.Add(new NpgsqlParameter("r_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "r_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                                    // RowUpdate
                                    da.RowUpdated += new NpgsqlRowUpdatedEventHandler(SeikyuRowUpdated);

                                    if (_seikyu_ds.Tables["seikyu_ds"] != null)
                                        _seikyu_ds.Tables["seikyu_ds"].Clear();
                                    da.Fill(_seikyu_ds, "seikyu_ds");

                                    bindingSourceSeikyu.DataSource = _seikyu_ds;
                                    bindingSourceSeikyu.DataMember = "seikyu_ds";

                                    bindingNavigatorSeikyu.BindingSource = bindingSourceSeikyu;

                                    dataGridViewSeikyu.AutoGenerateColumns = false;

                                    dataGridViewSeikyu.DataSource = bindingSourceSeikyu;

                                    dataGridViewSeikyu.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                                    bindingNavigatorSeikyu.Visible = true;
                                    bindingNavigatorShiharai_houhou.Visible = false;
                                    bindingNavigatorShinzoku_kankei.Visible = false;

                                    dataGridViewSeikyu.Visible = true;
                                    dataGridViewShiharai_houhou.Visible = false;
                                    dataGridViewShinzoku_kankei.Visible = false;

                                    break;
                            }
                            break;

                        // 支払方法
                        case 2:
                            Console.WriteLine("Case " + cmb_g_id_int + "!");
                            switch (cmb_s_id_int)
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:

                                    Console.WriteLine("Case " + cmb_s_id_int + "!");
                                    da.SelectCommand = new NpgsqlCommand
                                    (
                                        "select"
                                        + " c1"
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
                                        + ", c23"
                                        + ", c24"
                                        + ", c25"
                                        + ", c26"
                                        + ", c27"
                                        + ", c28"
                                        + ", c29"
                                        + ", c30"
                                        + ", c31"
                                        + ", c32"
                                        + ", c33"
                                        + ", c34"
                                        + ", c35"
                                        + ", c36"
                                        + ", c37"
                                        + ", c38"
                                        + ", c39"
                                        + ", c40"
                                        + ", c41"
                                        + ", c42"
                                        + ", c43"
                                        + ", c44"
                                        + ", c45"
                                        + ", c46"
                                        + ", c47"
                                        + ", c48"
                                        + ", c49"
                                        + ", sh_id"
                                        + ", s_id"
                                        + ", g_id"
                                        + ", o_id"
                                        + ", p_id"
                                        + ", req_id"
                                        + ", time_stamp"
                                        + ", c4_array"
                                        + " from"
                                        + " t_shiharai_houhou"
                                        + " where time_stamp = (select max(time_stamp) from t_shiharai_houhou"
                                        + " where s_id::Integer = " + cmb_s_id_int
                                        + " and g_id::Integer = " + cmb_g_id_int
                                        + " and o_id::Integer = " + cmb_o_id_int
                                        + " and c4_array[1]::text || '/' || c4_array[2]::Text = case when length('" + cmb_tsuki_str + "')=1 then"
                                                        + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                                                        + "       when length('" + cmb_tsuki_str + "')=2 then"
                                                        + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                                                        + " end"
                                        + ");"
                                        , m_conn
                                    );

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

                                    // update
                                    da.UpdateCommand = new NpgsqlCommand(
                                            "update t_shiharai_houhou set"
                                            + " c1 = :c1"
                                            + ", c2 = :c2"
                                            + ", c3 = :c3"
                                            + ", c4 = :c4"
                                            + ", c5 = :c5"
                                            + ", c6 = :c6"
                                            + ", c7 = :c7"
                                            + ", c8 = :c8"
                                            + ", c9 = :c9"
                                            + ", c10 = :c10"
                                            + ", c11 = :c11"
                                            + ", c12 = :c12"
                                            + ", c13 = :c13"
                                            + ", c14 = :c14"
                                            + ", c15 = :c15"
                                            + ", c16 = :c16"
                                            + ", c17 = :c17"
                                            + ", c18 = :c18"
                                            + ", c19 = :c19"
                                            + ", c20 = :c20"
                                            + ", c21 = :c21"
                                            + ", c22 = :c22"
                                            + ", c23 = :c23"
                                            + ", c24 = :c24"
                                            + ", c25 = :c25"
                                            + ", c26 = :c26"
                                            + ", c27 = :c27"
                                            + ", c28 = :c28"
                                            + ", c29 = :c29"
                                            + ", c30 = :c30"
                                            + ", c31 = :c31"
                                            + ", c32 = :c32"
                                            + ", c33 = :c33"
                                            + ", c34 = :c34"
                                            + ", c35 = :c35"
                                            + ", c36 = :c36"
                                            + ", c37 = :c37"
                                            + ", c38 = :c38"
                                            + ", c39 = :c39"
                                            + ", c40 = :c40"
                                            + ", c41 = :c41"
                                            + ", c42 = :c42"
                                            + ", c43 = :c43"
                                            + ", c44 = :c44"
                                            + ", c45 = :c45"
                                            + ", c46 = :c46"
                                            + ", c47 = :c47"
                                            + ", c48 = :c48"
                                            + ", c49 = :c49"
                                            + ", s_id = :s_id"
                                            + ", g_id = :g_id"
                                            + ", o_id = :o_id"
                                            + ", p_id = :p_id"
                                            + ", req_id = :req_id"
                                            + ", c4_array = :c4_array"
                                            + " where sh_id=:sh_id;"
                                        , m_conn
                                        );
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c1", NpgsqlTypes.NpgsqlDbType.Text, 0, "c1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c2", NpgsqlTypes.NpgsqlDbType.Text, 0, "c2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c3", NpgsqlTypes.NpgsqlDbType.Text, 0, "c3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c5", NpgsqlTypes.NpgsqlDbType.Text, 0, "c5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c6", NpgsqlTypes.NpgsqlDbType.Text, 0, "c6", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c7", NpgsqlTypes.NpgsqlDbType.Text, 0, "c7", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c8", NpgsqlTypes.NpgsqlDbType.Text, 0, "c8", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c9", NpgsqlTypes.NpgsqlDbType.Text, 0, "c9", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c10", NpgsqlTypes.NpgsqlDbType.Text, 0, "c10", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c11", NpgsqlTypes.NpgsqlDbType.Text, 0, "c11", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c12", NpgsqlTypes.NpgsqlDbType.Text, 0, "c12", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c13", NpgsqlTypes.NpgsqlDbType.Text, 0, "c13", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c14", NpgsqlTypes.NpgsqlDbType.Text, 0, "c14", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c15", NpgsqlTypes.NpgsqlDbType.Text, 0, "c15", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c16", NpgsqlTypes.NpgsqlDbType.Text, 0, "c16", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c17", NpgsqlTypes.NpgsqlDbType.Text, 0, "c17", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c18", NpgsqlTypes.NpgsqlDbType.Text, 0, "c18", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c19", NpgsqlTypes.NpgsqlDbType.Text, 0, "c19", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c20", NpgsqlTypes.NpgsqlDbType.Text, 0, "c20", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c21", NpgsqlTypes.NpgsqlDbType.Text, 0, "c21", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c22", NpgsqlTypes.NpgsqlDbType.Text, 0, "c22", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c23", NpgsqlTypes.NpgsqlDbType.Text, 0, "c23", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c24", NpgsqlTypes.NpgsqlDbType.Text, 0, "c24", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c25", NpgsqlTypes.NpgsqlDbType.Text, 0, "c25", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c26", NpgsqlTypes.NpgsqlDbType.Text, 0, "c26", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c27", NpgsqlTypes.NpgsqlDbType.Text, 0, "c27", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c28", NpgsqlTypes.NpgsqlDbType.Text, 0, "c28", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c29", NpgsqlTypes.NpgsqlDbType.Text, 0, "c29", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c30", NpgsqlTypes.NpgsqlDbType.Text, 0, "c30", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c31", NpgsqlTypes.NpgsqlDbType.Text, 0, "c31", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c32", NpgsqlTypes.NpgsqlDbType.Text, 0, "c32", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c33", NpgsqlTypes.NpgsqlDbType.Text, 0, "c33", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c34", NpgsqlTypes.NpgsqlDbType.Text, 0, "c34", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c35", NpgsqlTypes.NpgsqlDbType.Text, 0, "c35", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c36", NpgsqlTypes.NpgsqlDbType.Text, 0, "c36", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c37", NpgsqlTypes.NpgsqlDbType.Text, 0, "c37", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c38", NpgsqlTypes.NpgsqlDbType.Text, 0, "c38", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c39", NpgsqlTypes.NpgsqlDbType.Text, 0, "c39", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c40", NpgsqlTypes.NpgsqlDbType.Text, 0, "c40", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c41", NpgsqlTypes.NpgsqlDbType.Text, 0, "c41", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c42", NpgsqlTypes.NpgsqlDbType.Text, 0, "c42", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c43", NpgsqlTypes.NpgsqlDbType.Text, 0, "c43", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c44", NpgsqlTypes.NpgsqlDbType.Text, 0, "c44", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c45", NpgsqlTypes.NpgsqlDbType.Text, 0, "c45", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c46", NpgsqlTypes.NpgsqlDbType.Text, 0, "c46", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c47", NpgsqlTypes.NpgsqlDbType.Text, 0, "c47", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c48", NpgsqlTypes.NpgsqlDbType.Text, 0, "c48", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c49", NpgsqlTypes.NpgsqlDbType.Text, 0, "c49", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("g_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "g_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("p_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "p_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("req_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "req_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4_array", NpgsqlTypes.NpgsqlDbType.Array | NpgsqlTypes.NpgsqlDbType.Text, 0, "c4_array", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("sh_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "sh_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                                    // delete
                                    da.DeleteCommand = new NpgsqlCommand
                                    (
                                           "delete from t_shiharai_houhou"
                                        + " where"
                                        + " sh_id=:sh_id;"
                                        , m_conn
                                    );
                                    da.DeleteCommand.Parameters.Add(new NpgsqlParameter("sh_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "sh_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                                    // RowUpdate
                                    da.RowUpdated += new NpgsqlRowUpdatedEventHandler(SeikyuRowUpdated);

                                    if (_shiharai_houhou_ds.Tables["shiharai_houhou_ds"] != null)
                                        _shiharai_houhou_ds.Tables["shiharai_houhou_ds"].Clear();
                                    da.Fill(_shiharai_houhou_ds, "shiharai_houhou_ds");

                                    bindingSourceShiharai_houhou.DataSource = _shiharai_houhou_ds;
                                    bindingSourceShiharai_houhou.DataMember = "shiharai_houhou_ds";

                                    bindingNavigatorShiharai_houhou.BindingSource = bindingSourceShiharai_houhou;

                                    dataGridViewShiharai_houhou.AutoGenerateColumns = false;

                                    dataGridViewShiharai_houhou.DataSource = bindingSourceShiharai_houhou;

                                    dataGridViewShiharai_houhou.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                                    bindingNavigatorSeikyu.Visible = false;
                                    bindingNavigatorShiharai_houhou.Visible = true;
                                    bindingNavigatorShinzoku_kankei.Visible = false;

                                    dataGridViewSeikyu.Visible = false;
                                    dataGridViewShiharai_houhou.Visible = true;
                                    dataGridViewShinzoku_kankei.Visible = false;

                                    break;
                            }
                            break;

                        // 親族関係
                        case 3:
                            //MessageBox.Show("Case " + cmb_s_id_int + "!");
                            Console.WriteLine("Case " + cmb_g_id_int + "!");
                            switch (cmb_s_id_int)
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:

                                    Console.WriteLine("Case " + cmb_s_id_int + "!");
                                    da.SelectCommand = new NpgsqlCommand
                                    (
                                        "select"
                                        + " c1"
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
                                        + ", c23"
                                        + ", c24"
                                        + ", c25"
                                        + ", c26"
                                        + ", c27"
                                        + ", c28"
                                        + ", c29"
                                        + ", c30"
                                        + ", c31"
                                        + ", c32"
                                        + ", c33"
                                        + ", c34"
                                        + ", c35"
                                        + ", c36"
                                        + ", c37"
                                        + ", c38"
                                        + ", c39"
                                        + ", c40"
                                        + ", c41"
                                        + ", c42"
                                        + ", c43"
                                        + ", c44"
                                        + ", c45"
                                        + ", c46"
                                        + ", c47"
                                        + ", c48"
                                        + ", c49"
                                        + ", c50"
                                        + ", c51"
                                        + ", c52"
                                        + ", c53"
                                        + ", c54"
                                        + ", c55"
                                        + ", c56"
                                        + ", c57"
                                        + ", c58"
                                        + ", s_id"
                                        + ", g_id"
                                        + ", o_id"
                                        + ", p_id"
                                        + ", req_id"
                                        + ", time_stamp"
                                        + ", c4_array"
                                        + " from"
                                        + " t_shinzoku_kankei"
                                        + " where time_stamp = (select max(time_stamp) from t_shinzoku_kankei"
                                        + " where s_id::Integer = " + cmb_s_id_int
                                        + " and g_id::Integer = " + cmb_g_id_int
                                        + " and o_id::Integer = " + cmb_o_id_int
                                        + " and c4_array[1]::text || '/' || c4_array[2]::Text = case when length('" + cmb_tsuki_str + "')=1 then"
                                                        + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                                                        + "       when length('" + cmb_tsuki_str + "')=2 then"
                                                        + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                                                        + " end"
                                        + ");"
                                        //+ " order by id"
                                        , m_conn
                                    );

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

                                    // update
                                    da.UpdateCommand = new NpgsqlCommand(
                                    "update t_shinzoku_kankei set"
                                        + " c1 = :c1"
                                        + ", c2 = :c2"
                                        + ", c3 = :c3"
                                        + ", c4 = :c4"
                                        + ", c5 = :c5"
                                        + ", c6 = :c6"
                                        + ", c7 = :c7"
                                        + ", c8 = :c8"
                                        + ", c9 = :c9"
                                        + ", c10 = :c10"
                                        + ", c11 = :c11"
                                        + ", c12 = :c12"
                                        + ", c13 = :c13"
                                        + ", c14 = :c14"
                                        + ", c15 = :c15"
                                        + ", c16 = :c16"
                                        + ", c17 = :c17"
                                        + ", c18 = :c18"
                                        + ", c19 = :c19"
                                        + ", c20 = :c20"
                                        + ", c21 = :c21"
                                        + ", c22 = :c22"
                                        + ", c23 = :c23"
                                        + ", c24 = :c24"
                                        + ", c25 = :c25"
                                        + ", c26 = :c26"
                                        + ", c27 = :c27"
                                        + ", c28 = :c28"
                                        + ", c29 = :c29"
                                        + ", c30 = :c30"
                                        + ", c31 = :c31"
                                        + ", c32 = :c32"
                                        + ", c33 = :c33"
                                        + ", c34 = :c34"
                                        + ", c35 = :c35"
                                        + ", c36 = :c36"
                                        + ", c37 = :c37"
                                        + ", c38 = :c38"
                                        + ", c39 = :c39"
                                        + ", c40 = :c40"
                                        + ", c41 = :c41"
                                        + ", c42 = :c42"
                                        + ", c43 = :c43"
                                        + ", c44 = :c44"
                                        + ", c45 = :c45"
                                        + ", c46 = :c46"
                                        + ", c47 = :c47"
                                        + ", c48 = :c48"
                                        + ", c49 = :c49"
                                        + ", c50 = :c50"
                                        + ", c51 = :c51"
                                        + ", c52 = :c52"
                                        + ", c53 = :c53"
                                        + ", c54 = :c54"
                                        + ", c55 = :c55"
                                        + ", c56 = :c56"
                                        + ", c57 = :c57"
                                        + ", c58 = :c58"
                                        + ", s_id = :s_id"
                                        + ", g_id = :g_id"
                                        + ", o_id = :o_id"
                                        + ", p_id = :p_id"
                                        + ", req_id = :req_id"
                                        + " where sk_id=:sk_id;"
                                        , m_conn
                                        );
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c1", NpgsqlTypes.NpgsqlDbType.Text, 0, "c1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c2", NpgsqlTypes.NpgsqlDbType.Text, 0, "c2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c3", NpgsqlTypes.NpgsqlDbType.Text, 0, "c3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c5", NpgsqlTypes.NpgsqlDbType.Text, 0, "c5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c6", NpgsqlTypes.NpgsqlDbType.Text, 0, "c6", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c7", NpgsqlTypes.NpgsqlDbType.Text, 0, "c7", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c8", NpgsqlTypes.NpgsqlDbType.Text, 0, "c8", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c9", NpgsqlTypes.NpgsqlDbType.Text, 0, "c9", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c10", NpgsqlTypes.NpgsqlDbType.Text, 0, "c10", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c11", NpgsqlTypes.NpgsqlDbType.Text, 0, "c11", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c12", NpgsqlTypes.NpgsqlDbType.Text, 0, "c12", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c13", NpgsqlTypes.NpgsqlDbType.Text, 0, "c13", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c14", NpgsqlTypes.NpgsqlDbType.Text, 0, "c14", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c15", NpgsqlTypes.NpgsqlDbType.Text, 0, "c15", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c16", NpgsqlTypes.NpgsqlDbType.Text, 0, "c16", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c17", NpgsqlTypes.NpgsqlDbType.Text, 0, "c17", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c18", NpgsqlTypes.NpgsqlDbType.Text, 0, "c18", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c19", NpgsqlTypes.NpgsqlDbType.Text, 0, "c19", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c20", NpgsqlTypes.NpgsqlDbType.Text, 0, "c20", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c21", NpgsqlTypes.NpgsqlDbType.Text, 0, "c21", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c22", NpgsqlTypes.NpgsqlDbType.Text, 0, "c22", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c23", NpgsqlTypes.NpgsqlDbType.Text, 0, "c23", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c24", NpgsqlTypes.NpgsqlDbType.Text, 0, "c24", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c25", NpgsqlTypes.NpgsqlDbType.Text, 0, "c25", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c26", NpgsqlTypes.NpgsqlDbType.Text, 0, "c26", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c27", NpgsqlTypes.NpgsqlDbType.Text, 0, "c27", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c28", NpgsqlTypes.NpgsqlDbType.Text, 0, "c28", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c29", NpgsqlTypes.NpgsqlDbType.Text, 0, "c29", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c30", NpgsqlTypes.NpgsqlDbType.Text, 0, "c30", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c31", NpgsqlTypes.NpgsqlDbType.Text, 0, "c31", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c32", NpgsqlTypes.NpgsqlDbType.Text, 0, "c32", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c33", NpgsqlTypes.NpgsqlDbType.Text, 0, "c33", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c34", NpgsqlTypes.NpgsqlDbType.Text, 0, "c34", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c35", NpgsqlTypes.NpgsqlDbType.Text, 0, "c35", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c36", NpgsqlTypes.NpgsqlDbType.Text, 0, "c36", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c37", NpgsqlTypes.NpgsqlDbType.Text, 0, "c37", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c38", NpgsqlTypes.NpgsqlDbType.Text, 0, "c38", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c39", NpgsqlTypes.NpgsqlDbType.Text, 0, "c39", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c40", NpgsqlTypes.NpgsqlDbType.Text, 0, "c40", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c41", NpgsqlTypes.NpgsqlDbType.Text, 0, "c41", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c42", NpgsqlTypes.NpgsqlDbType.Text, 0, "c42", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c43", NpgsqlTypes.NpgsqlDbType.Text, 0, "c43", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c44", NpgsqlTypes.NpgsqlDbType.Text, 0, "c44", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c45", NpgsqlTypes.NpgsqlDbType.Text, 0, "c45", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c46", NpgsqlTypes.NpgsqlDbType.Text, 0, "c46", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c47", NpgsqlTypes.NpgsqlDbType.Text, 0, "c47", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c48", NpgsqlTypes.NpgsqlDbType.Text, 0, "c48", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c49", NpgsqlTypes.NpgsqlDbType.Text, 0, "c49", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c50", NpgsqlTypes.NpgsqlDbType.Text, 0, "c50", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c51", NpgsqlTypes.NpgsqlDbType.Text, 0, "c51", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c52", NpgsqlTypes.NpgsqlDbType.Text, 0, "c52", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c53", NpgsqlTypes.NpgsqlDbType.Text, 0, "c53", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c54", NpgsqlTypes.NpgsqlDbType.Text, 0, "c54", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c55", NpgsqlTypes.NpgsqlDbType.Text, 0, "c55", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c56", NpgsqlTypes.NpgsqlDbType.Text, 0, "c56", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c57", NpgsqlTypes.NpgsqlDbType.Text, 0, "c57", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c58", NpgsqlTypes.NpgsqlDbType.Text, 0, "c58", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("g_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "g_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("p_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "p_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("req_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "req_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("sk_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "sk_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                                    // delete
                                    da.DeleteCommand = new NpgsqlCommand
                                    (
                                           "delete from t_shinzoku_kankei"
                                        + " where"
                                        + " sk_id=:sk_id;"
                                        , m_conn
                                    );
                                    da.DeleteCommand.Parameters.Add(new NpgsqlParameter("skz_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "skz_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                                    // RowUpdate
                                    da.RowUpdated += new NpgsqlRowUpdatedEventHandler(SeikyuRowUpdated);

                                    if (_shinzoku_kankei_ds.Tables["shinzoku_kankei_ds"] != null)
                                        _shinzoku_kankei_ds.Tables["shinzoku_kankei_ds"].Clear();
                                    da.Fill(_shinzoku_kankei_ds, "shinzoku_kankei_ds");

                                    bindingSourceSeikyu.DataSource = _shinzoku_kankei_ds;
                                    bindingSourceSeikyu.DataMember = "shinzoku_kankei_ds";

                                    bindingNavigatorSeikyu.BindingSource = bindingSourceSeikyu;

                                    dataGridViewSeikyu.AutoGenerateColumns = false;

                                    dataGridViewSeikyu.DataSource = bindingSourceSeikyu;

                                    dataGridViewSeikyu.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                                    bindingNavigatorSeikyu.Visible = false;
                                    bindingNavigatorShiharai_houhou.Visible = false;
                                    bindingNavigatorShinzoku_kankei.Visible = true;

                                    dataGridViewSeikyu.Visible = false;
                                    dataGridViewShiharai_houhou.Visible = false;
                                    dataGridViewShinzoku_kankei.Visible = true;

                                    break;
                            }
                            break;
                    }
                    break;
            }

            DataGridViewEvent();
            this.WindowState = FormWindowState.Maximized;
            //}
        }

        private void DataGridViewEvent()
        {
            dataGridViewSeikyu.CellMouseMove += new DataGridViewCellMouseEventHandler(dataGridViewSeikyu_CellMouseMove);
            dataGridViewSeikyu.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridViewSeikyu_CellPainting);
            dataGridViewSeikyu.CellValueChanged += new DataGridViewCellEventHandler(dataGridViewSeikyu_CellValueChanged);
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            int update_count = 0;
            try
            {
                switch (cmb_g_id_int)
                {
                    case 1:
                        switch (cmb_s_id_int)
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:

                                update_count += da.Update(_seikyu_ds.Tables["seikyu_ds"].Select(null, null, DataViewRowState.Deleted));
                                update_count += da.Update(_seikyu_ds.Tables["seikyu_ds"].Select(null, null, DataViewRowState.ModifiedCurrent));
                                update_count += da.Update(_seikyu_ds.Tables["seikyu_ds"].Select(null, null, DataViewRowState.Added));
                                break;
                        }
                        break;
                    case 2:
                        switch (cmb_s_id_int)
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:

                                update_count += da.Update(_shiharai_houhou_ds.Tables["shiharai_houhou_ds"].Select(null, null, DataViewRowState.Deleted));
                                update_count += da.Update(_shiharai_houhou_ds.Tables["shiharai_houhou_ds"].Select(null, null, DataViewRowState.ModifiedCurrent));
                                update_count += da.Update(_shiharai_houhou_ds.Tables["shiharai_houhou_ds"].Select(null, null, DataViewRowState.Added));
                                break;
                        }
                        break;
                    case 3:
                        switch (cmb_s_id_int)
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:

                                update_count += da.Update(_shinzoku_kankei_ds.Tables["shinzoku_kankei_ds"].Select(null, null, DataViewRowState.Deleted));
                                update_count += da.Update(_shinzoku_kankei_ds.Tables["shinzoku_kankei_ds"].Select(null, null, DataViewRowState.ModifiedCurrent));
                                update_count += da.Update(_shinzoku_kankei_ds.Tables["shinzoku_kankei_ds"].Select(null, null, DataViewRowState.Added));
                                break;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("レコードの保存に失敗しました。\n\n[内容]\n" + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(update_count.ToString() + "件、保存しました。", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void SeikyuRowUpdated(Object sender, NpgsqlRowUpdatedEventArgs e)
        {
            if (e.Status == UpdateStatus.Continue)
            {
                if (e.StatementType == System.Data.StatementType.Insert)
                {
                    // 
                    switch (cmb_g_id_int)
                    {
                        case 1:
                            switch (cmb_s_id_int)
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:

                                    da.SelectCommand = new NpgsqlCommand
                                    (
                                        "select"
                                        + " c1"
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
                                        + ", c4_array"
                                        + ", time_stamp"
                                        + ", r_id"
                                        + ", s_id"
                                        + ", g_id"
                                        + ", o_id"
                                        + ", id"
                                        + ", p_id"
                                        + ", req_id"
                                        + " from"
                                        + " t_seikyu"
                                        + " where r_id=currval('t_seikyu_r_id_seq');"
                                        //+ " order by id"
                                        , m_conn
                                    );

                                    break;
                            }
                            break;
                        // 支払方法
                        case 2:
                            switch (cmb_s_id_int)
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:

                                    da.SelectCommand = new NpgsqlCommand
                                    (
                                        "select"
                                        + " c1"
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
                                        + ", c23"
                                        + ", c24"
                                        + ", c25"
                                        + ", c26"
                                        + ", c27"
                                        + ", c28"
                                        + ", c29"
                                        + ", c30"
                                        + ", c31"
                                        + ", c32"
                                        + ", c33"
                                        + ", c34"
                                        + ", c35"
                                        + ", c36"
                                        + ", c37"
                                        + ", c38"
                                        + ", c39"
                                        + ", c40"
                                        + ", c41"
                                        + ", c42"
                                        + ", c43"
                                        + ", c44"
                                        + ", c45"
                                        + ", c46"
                                        + ", c47"
                                        + ", c48"
                                        + ", c49"
                                        + ", s_id"
                                        + ", g_id"
                                        + ", o_id"
                                        + ", sh_id"
                                        + ", p_id"
                                        + ", req_id"
                                        + ", c4_array"
                                        + ", time_stamp"
                                        + " from"
                                        + " t_shiharai_houhou"
                                        + " where sh_id=currval('t_shiharai_houhou_sh_id_seq');"
                                        //+ " order by id"
                                        , m_conn
                                    );

                                    break;
                            }
                            break;
                        // 親族関係
                        case 7:
                            switch (cmb_s_id_int)
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:

                                    da.SelectCommand = new NpgsqlCommand
                                    (
                                        "select"
                                        + " c1"
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
                                        + ", c23"
                                        + ", c24"
                                        + ", c25"
                                        + ", c26"
                                        + ", c27"
                                        + ", c28"
                                        + ", c29"
                                        + ", c30"
                                        + ", c31"
                                        + ", c32"
                                        + ", c33"
                                        + ", c34"
                                        + ", c35"
                                        + ", c36"
                                        + ", c37"
                                        + ", c38"
                                        + ", c39"
                                        + ", c40"
                                        + ", c41"
                                        + ", c42"
                                        + ", c43"
                                        + ", c44"
                                        + ", c45"
                                        + ", c46"
                                        + ", c47"
                                        + ", c48"
                                        + ", c49"
                                        + ", c50"
                                        + ", c51"
                                        + ", c52"
                                        + ", c53"
                                        + ", c54"
                                        + ", c55"
                                        + ", c56"
                                        + ", c57"
                                        + ", c58"
                                        + ", s_id"
                                        + ", g_id"
                                        + ", o_id"
                                        + ", p_id"
                                        + ", req_id"
                                        + ", time_stamp"
                                        + ", sk_id"
                                        + " from"
                                        + " t_shinzoku_kankei"
                                        + " where sk_id=currval('t_shizoku_kankei_sk_id_seq');"
                                        //+ " order by id"
                                        , m_conn
                                    );
                                    break;
                            }
                            break;
                    }

                    try
                    {
                        NpgsqlDataReader reader = da.SelectCommand.ExecuteReader();
                        reader.Read();
                        // 
                        switch (cmb_g_id_int)
                        {
                            case 1:
                                switch (cmb_s_id_int)
                                {
                                    case 1:
                                    case 2:
                                    case 3:
                                    case 4:
                                    case 5:
                                    case 6:

                                        e.Row["c1"] = reader["c1"];
                                        e.Row["c2"] = reader["c2"];
                                        e.Row["c3"] = reader["c3"];
                                        e.Row["c4"] = reader["c4"];
                                        e.Row["c5"] = reader["c5"];
                                        e.Row["c6"] = reader["c6"];
                                        e.Row["c7"] = reader["c7"];
                                        e.Row["c8"] = reader["c8"];
                                        e.Row["c9"] = reader["c9"];
                                        e.Row["c10"] = reader["c10"];
                                        e.Row["c11"] = reader["c11"];
                                        e.Row["c12"] = reader["c12"];
                                        e.Row["c13"] = reader["c13"];
                                        e.Row["c14"] = reader["c14"];
                                        e.Row["c15"] = reader["c15"];
                                        e.Row["c16"] = reader["c16"];
                                        e.Row["c17"] = reader["c17"];
                                        e.Row["c18"] = reader["c18"];
                                        e.Row["c19"] = reader["c19"];
                                        e.Row["c20"] = reader["c20"];
                                        e.Row["c21"] = reader["c21"];
                                        e.Row["c22"] = reader["c22"];
                                        e.Row["c4_array"] = reader["c4_array"];
                                        e.Row["time_stamp"] = reader["time_stamp"];
                                        e.Row["r_id"] = reader["r_id"];
                                        e.Row["s_id"] = reader["s_id"];
                                        e.Row["g_id"] = reader["g_id"];
                                        e.Row["o_id"] = reader["o_id"];
                                        e.Row["id"] = reader["id"];
                                        e.Row["p_id"] = reader["p_id"];
                                        e.Row["req_id"] = reader["req_id"];

                                        break;
                                }
                                break;
                            case 2:
                                switch (cmb_s_id_int)
                                {
                                    case 1:
                                    case 2:
                                    case 3:
                                    case 4:
                                    case 5:
                                    case 6:

                                        e.Row["c1"] = reader["c1"];
                                        e.Row["c2"] = reader["c2"];
                                        e.Row["c3"] = reader["c3"];
                                        e.Row["c4"] = reader["c4"];
                                        e.Row["c5"] = reader["c5"];
                                        e.Row["c6"] = reader["c6"];
                                        e.Row["c7"] = reader["c7"];
                                        e.Row["c8"] = reader["c8"];
                                        e.Row["c9"] = reader["c9"];
                                        e.Row["c10"] = reader["c10"];
                                        e.Row["c11"] = reader["c11"];
                                        e.Row["c12"] = reader["c12"];
                                        e.Row["c13"] = reader["c13"];
                                        e.Row["c14"] = reader["c14"];
                                        e.Row["c15"] = reader["c15"];
                                        e.Row["c16"] = reader["c16"];
                                        e.Row["c17"] = reader["c17"];
                                        e.Row["c18"] = reader["c18"];
                                        e.Row["c19"] = reader["c19"];
                                        e.Row["c20"] = reader["c20"];
                                        e.Row["c21"] = reader["c21"];
                                        e.Row["c22"] = reader["c22"];
                                        e.Row["c23"] = reader["c23"];
                                        e.Row["c24"] = reader["c24"];
                                        e.Row["c25"] = reader["c25"];
                                        e.Row["c26"] = reader["c26"];
                                        e.Row["c27"] = reader["c27"];
                                        e.Row["c28"] = reader["c28"];
                                        e.Row["c29"] = reader["c29"];
                                        e.Row["c30"] = reader["c30"];
                                        e.Row["c31"] = reader["c31"];
                                        e.Row["c32"] = reader["c32"];
                                        e.Row["c33"] = reader["c33"];
                                        e.Row["c34"] = reader["c34"];
                                        e.Row["c35"] = reader["c35"];
                                        e.Row["c36"] = reader["c36"];
                                        e.Row["c37"] = reader["c37"];
                                        e.Row["c38"] = reader["c38"];
                                        e.Row["c39"] = reader["c39"];
                                        e.Row["c40"] = reader["c40"];
                                        e.Row["c41"] = reader["c41"];
                                        e.Row["c42"] = reader["c42"];
                                        e.Row["c43"] = reader["c43"];
                                        e.Row["c44"] = reader["c44"];
                                        e.Row["c45"] = reader["c45"];
                                        e.Row["c46"] = reader["c46"];
                                        e.Row["c47"] = reader["c47"];
                                        e.Row["c48"] = reader["c48"];
                                        e.Row["c49"] = reader["c49"];
                                        e.Row["sh_id"] = reader["sh_id"];
                                        e.Row["s_id"] = reader["s_id"];
                                        e.Row["g_id"] = reader["g_id"];
                                        e.Row["o_id"] = reader["o_id"];
                                        e.Row["p_id"] = reader["p_id"];
                                        e.Row["req_id"] = reader["req_id"];
                                        e.Row["time_stamp"] = reader["time_stamp"];

                                        break;
                                }
                                break;
                            case 3:
                                switch (cmb_s_id_int)
                                {
                                    case 1:
                                    case 2:
                                    case 3:
                                    case 4:
                                    case 5:
                                    case 6:

                                        e.Row["c1"] = reader["c1"];
                                        e.Row["c2"] = reader["c2"];
                                        e.Row["c3"] = reader["c3"];
                                        e.Row["c4"] = reader["c4"];
                                        e.Row["c5"] = reader["c5"];
                                        e.Row["c6"] = reader["c6"];
                                        e.Row["c7"] = reader["c7"];
                                        e.Row["c8"] = reader["c8"];
                                        e.Row["c9"] = reader["c9"];
                                        e.Row["c10"] = reader["c10"];
                                        e.Row["c11"] = reader["c11"];
                                        e.Row["c12"] = reader["c12"];
                                        e.Row["c13"] = reader["c13"];
                                        e.Row["c14"] = reader["c14"];
                                        e.Row["c15"] = reader["c15"];
                                        e.Row["c16"] = reader["c16"];
                                        e.Row["c17"] = reader["c17"];
                                        e.Row["c18"] = reader["c18"];
                                        e.Row["c19"] = reader["c19"];
                                        e.Row["c20"] = reader["c20"];
                                        e.Row["c21"] = reader["c21"];
                                        e.Row["c22"] = reader["c22"];
                                        e.Row["c23"] = reader["c23"];
                                        e.Row["c24"] = reader["c24"];
                                        e.Row["c25"] = reader["c25"];
                                        e.Row["c26"] = reader["c26"];
                                        e.Row["c27"] = reader["c27"];
                                        e.Row["c28"] = reader["c28"];
                                        e.Row["c29"] = reader["c29"];
                                        e.Row["c30"] = reader["c30"];
                                        e.Row["c31"] = reader["c31"];
                                        e.Row["c32"] = reader["c32"];
                                        e.Row["c33"] = reader["c33"];
                                        e.Row["c34"] = reader["c34"];
                                        e.Row["c35"] = reader["c35"];
                                        e.Row["c36"] = reader["c36"];
                                        e.Row["c37"] = reader["c37"];
                                        e.Row["c38"] = reader["c38"];
                                        e.Row["c39"] = reader["c39"];
                                        e.Row["c40"] = reader["c40"];
                                        e.Row["c41"] = reader["c41"];
                                        e.Row["c42"] = reader["c42"];
                                        e.Row["c43"] = reader["c43"];
                                        e.Row["c44"] = reader["c44"];
                                        e.Row["c45"] = reader["c45"];
                                        e.Row["c46"] = reader["c46"];
                                        e.Row["c47"] = reader["c47"];
                                        e.Row["c48"] = reader["c48"];
                                        e.Row["c49"] = reader["c49"];
                                        e.Row["c50"] = reader["c50"];
                                        e.Row["c51"] = reader["c51"];
                                        e.Row["c52"] = reader["c52"];
                                        e.Row["c53"] = reader["c53"];
                                        e.Row["c54"] = reader["c54"];
                                        e.Row["c55"] = reader["c55"];
                                        e.Row["c56"] = reader["c56"];
                                        e.Row["c57"] = reader["c57"];
                                        e.Row["c58"] = reader["c58"];
                                        e.Row["sk_id"] = reader["sk_id"];
                                        e.Row["s_id"] = reader["s_id"];
                                        e.Row["g_id"] = reader["g_id"];
                                        e.Row["o_id"] = reader["o_id"];
                                        e.Row["p_id"] = reader["p_id"];
                                        e.Row["req_id"] = reader["req_id"];
                                        e.Row["time_stamp"] = reader["time_stamp"];

                                        break;
                                }
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw;
                    }
                }
                else if (e.StatementType == System.Data.StatementType.Update)
                {
                    switch (cmb_g_id_int)
                    {
                        case 1:
                            switch (cmb_s_id_int)
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:

                                    da.SelectCommand = new NpgsqlCommand
                                    (
                                        "select"
                                        + " c1"
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
                                        + ", c4_array"
                                        + ", time_stamp"
                                        + ", s_id"
                                        + ", g_id"
                                        + ", o_id"
                                        + ", id"
                                        + ", p_id"
                                        + ", req_id"
                                        + ", r_id"
                                        + " from"
                                        + " t_seikyu"
                                        + " where r_id=" + e.Row["r_id"].ToString()
                                        //+ " order by id"
                                        , m_conn
                                    );

                                    break;
                            }
                            break;
                        // 支払方法
                        case 2:
                            switch (cmb_s_id_int)
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:

                                    da.SelectCommand = new NpgsqlCommand
                                    (
                                        "select"
                                        + " c1"
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
                                        + ", c23"
                                        + ", c24"
                                        + ", c25"
                                        + ", c26"
                                        + ", c27"
                                        + ", c28"
                                        + ", c29"
                                        + ", c30"
                                        + ", c31"
                                        + ", c32"
                                        + ", c33"
                                        + ", c34"
                                        + ", c35"
                                        + ", c36"
                                        + ", c37"
                                        + ", c38"
                                        + ", c39"
                                        + ", c40"
                                        + ", c41"
                                        + ", c42"
                                        + ", c43"
                                        + ", c44"
                                        + ", c45"
                                        + ", c46"
                                        + ", c47"
                                        + ", c48"
                                        + ", c49"
                                        + ", sh_id"
                                        + ", s_id"
                                        + ", g_id"
                                        + ", o_id"
                                        + ", p_id"
                                        + ", req_id"
                                        + ", time_stamp"
                                        + " from"
                                        + " t_shiharai_houhou"
                                        + " where sh_id=" + e.Row["sh_id"].ToString()
                                        //+ " order by id"
                                        , m_conn
                                    );

                                    break;
                            }
                            break;
                        // 親族関係
                        case 3:
                            switch (cmb_s_id_int)
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:

                                    da.SelectCommand = new NpgsqlCommand
                                    (
                                        "select"
                                        + " c1"
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
                                        + ", c23"
                                        + ", c24"
                                        + ", c25"
                                        + ", c26"
                                        + ", c27"
                                        + ", c28"
                                        + ", c29"
                                        + ", c30"
                                        + ", c31"
                                        + ", c32"
                                        + ", c33"
                                        + ", c34"
                                        + ", c35"
                                        + ", c36"
                                        + ", c37"
                                        + ", c38"
                                        + ", c39"
                                        + ", c40"
                                        + ", c41"
                                        + ", c42"
                                        + ", c43"
                                        + ", c44"
                                        + ", c45"
                                        + ", c46"
                                        + ", c47"
                                        + ", c48"
                                        + ", c49"
                                        + ", c50"
                                        + ", c51"
                                        + ", c52"
                                        + ", c53"
                                        + ", c54"
                                        + ", c55"
                                        + ", c56"
                                        + ", c57"
                                        + ", c58"
                                        + ", sk_id"
                                        + ", s_id"
                                        + ", g_id"
                                        + ", o_id"
                                        + ", p_id"
                                        + ", req_id"
                                        + ", time_stamp"
                                        + " from"
                                        + " t_shinzoku_kankei"
                                        + " where sk_id=" + e.Row["sk_id"].ToString()
                                        //+ " order by id"
                                        , m_conn
                                    );
                                    break;
                            }
                            break;
                    }

                    try
                    {
                        NpgsqlDataReader reader = da.SelectCommand.ExecuteReader();
                        reader.Read();
                        // 
                        switch (cmb_g_id_int)
                        {
                            case 1:
                                switch (cmb_s_id_int)
                                {
                                    case 1:
                                    case 2:
                                    case 3:
                                    case 4:
                                    case 5:
                                    case 6:

                                        e.Row["c1"] = reader["c1"];
                                        e.Row["c2"] = reader["c2"];
                                        e.Row["c3"] = reader["c3"];
                                        e.Row["c4"] = reader["c4"];
                                        e.Row["c5"] = reader["c5"];
                                        e.Row["c6"] = reader["c6"];
                                        e.Row["c7"] = reader["c7"];
                                        e.Row["c8"] = reader["c8"];
                                        e.Row["c9"] = reader["c9"];
                                        e.Row["c10"] = reader["c10"];
                                        e.Row["c11"] = reader["c11"];
                                        e.Row["c12"] = reader["c12"];
                                        e.Row["c13"] = reader["c13"];
                                        e.Row["c14"] = reader["c14"];
                                        e.Row["c15"] = reader["c15"];
                                        e.Row["c16"] = reader["c16"];
                                        e.Row["c17"] = reader["c17"];
                                        e.Row["c18"] = reader["c18"];
                                        e.Row["c19"] = reader["c19"];
                                        e.Row["c20"] = reader["c20"];
                                        e.Row["c21"] = reader["c21"];
                                        e.Row["c22"] = reader["c22"];
                                        e.Row["c4_array"] = reader["c4_array"];
                                        e.Row["time_stamp"] = reader["time_stamp"];
                                        e.Row["r_id"] = reader["r_id"];
                                        e.Row["s_id"] = reader["s_id"];
                                        e.Row["g_id"] = reader["g_id"];
                                        e.Row["o_id"] = reader["o_id"];
                                        e.Row["id"] = reader["id"];
                                        e.Row["p_id"] = reader["p_id"];
                                        e.Row["req_id"] = reader["req_id"];

                                        break;
                                }
                                break;
                            case 2:
                                switch (cmb_s_id_int)
                                {
                                    case 1:
                                    case 2:
                                    case 3:
                                    case 4:
                                    case 5:
                                    case 6:

                                        e.Row["c1"] = reader["c1"];
                                        e.Row["c2"] = reader["c2"];
                                        e.Row["c3"] = reader["c3"];
                                        e.Row["c4"] = reader["c4"];
                                        e.Row["c5"] = reader["c5"];
                                        e.Row["c6"] = reader["c6"];
                                        e.Row["c7"] = reader["c7"];
                                        e.Row["c8"] = reader["c8"];
                                        e.Row["c9"] = reader["c9"];
                                        e.Row["c10"] = reader["c10"];
                                        e.Row["c11"] = reader["c11"];
                                        e.Row["c12"] = reader["c12"];
                                        e.Row["c13"] = reader["c13"];
                                        e.Row["c14"] = reader["c14"];
                                        e.Row["c15"] = reader["c15"];
                                        e.Row["c16"] = reader["c16"];
                                        e.Row["c17"] = reader["c17"];
                                        e.Row["c18"] = reader["c18"];
                                        e.Row["c19"] = reader["c19"];
                                        e.Row["c20"] = reader["c20"];
                                        e.Row["c21"] = reader["c21"];
                                        e.Row["c22"] = reader["c22"];
                                        e.Row["c23"] = reader["c23"];
                                        e.Row["c24"] = reader["c24"];
                                        e.Row["c25"] = reader["c25"];
                                        e.Row["c26"] = reader["c26"];
                                        e.Row["c27"] = reader["c27"];
                                        e.Row["c28"] = reader["c28"];
                                        e.Row["c29"] = reader["c29"];
                                        e.Row["c30"] = reader["c30"];
                                        e.Row["c31"] = reader["c31"];
                                        e.Row["c32"] = reader["c32"];
                                        e.Row["c33"] = reader["c33"];
                                        e.Row["c34"] = reader["c34"];
                                        e.Row["c35"] = reader["c35"];
                                        e.Row["c36"] = reader["c36"];
                                        e.Row["c37"] = reader["c37"];
                                        e.Row["c38"] = reader["c38"];
                                        e.Row["c39"] = reader["c39"];
                                        e.Row["c40"] = reader["c40"];
                                        e.Row["c41"] = reader["c41"];
                                        e.Row["c42"] = reader["c42"];
                                        e.Row["c43"] = reader["c43"];
                                        e.Row["c44"] = reader["c44"];
                                        e.Row["c45"] = reader["c45"];
                                        e.Row["c46"] = reader["c46"];
                                        e.Row["c47"] = reader["c47"];
                                        e.Row["c48"] = reader["c48"];
                                        e.Row["c49"] = reader["c49"];
                                        e.Row["sh_id"] = reader["sh_id"];
                                        e.Row["s_id"] = reader["s_id"];
                                        e.Row["g_id"] = reader["g_id"];
                                        e.Row["o_id"] = reader["o_id"];
                                        e.Row["p_id"] = reader["p_id"];
                                        e.Row["req_id"] = reader["req_id"];
                                        e.Row["time_stamp"] = reader["time_stamp"];

                                        break;
                                }
                                break;
                            case 3:
                                switch (cmb_s_id_int)
                                {
                                    case 1:
                                    case 2:
                                    case 3:
                                    case 4:
                                    case 5:
                                    case 6:

                                        e.Row["c1"] = reader["c1"];
                                        e.Row["c2"] = reader["c2"];
                                        e.Row["c3"] = reader["c3"];
                                        e.Row["c4"] = reader["c4"];
                                        e.Row["c5"] = reader["c5"];
                                        e.Row["c6"] = reader["c6"];
                                        e.Row["c7"] = reader["c7"];
                                        e.Row["c8"] = reader["c8"];
                                        e.Row["c9"] = reader["c9"];
                                        e.Row["c10"] = reader["c10"];
                                        e.Row["c11"] = reader["c11"];
                                        e.Row["c12"] = reader["c12"];
                                        e.Row["c13"] = reader["c13"];
                                        e.Row["c14"] = reader["c14"];
                                        e.Row["c15"] = reader["c15"];
                                        e.Row["c16"] = reader["c16"];
                                        e.Row["c17"] = reader["c17"];
                                        e.Row["c18"] = reader["c18"];
                                        e.Row["c19"] = reader["c19"];
                                        e.Row["c20"] = reader["c20"];
                                        e.Row["c21"] = reader["c21"];
                                        e.Row["c22"] = reader["c22"];
                                        e.Row["c23"] = reader["c23"];
                                        e.Row["c24"] = reader["c24"];
                                        e.Row["c25"] = reader["c25"];
                                        e.Row["c26"] = reader["c26"];
                                        e.Row["c27"] = reader["c27"];
                                        e.Row["c28"] = reader["c28"];
                                        e.Row["c29"] = reader["c29"];
                                        e.Row["c30"] = reader["c30"];
                                        e.Row["c31"] = reader["c31"];
                                        e.Row["c32"] = reader["c32"];
                                        e.Row["c33"] = reader["c33"];
                                        e.Row["c34"] = reader["c34"];
                                        e.Row["c35"] = reader["c35"];
                                        e.Row["c36"] = reader["c36"];
                                        e.Row["c37"] = reader["c37"];
                                        e.Row["c38"] = reader["c38"];
                                        e.Row["c39"] = reader["c39"];
                                        e.Row["c40"] = reader["c40"];
                                        e.Row["c41"] = reader["c41"];
                                        e.Row["c42"] = reader["c42"];
                                        e.Row["c43"] = reader["c43"];
                                        e.Row["c44"] = reader["c44"];
                                        e.Row["c45"] = reader["c45"];
                                        e.Row["c46"] = reader["c46"];
                                        e.Row["c47"] = reader["c47"];
                                        e.Row["c48"] = reader["c48"];
                                        e.Row["c49"] = reader["c49"];
                                        e.Row["c50"] = reader["c50"];
                                        e.Row["c51"] = reader["c51"];
                                        e.Row["c52"] = reader["c52"];
                                        e.Row["c53"] = reader["c53"];
                                        e.Row["c54"] = reader["c54"];
                                        e.Row["c55"] = reader["c55"];
                                        e.Row["c56"] = reader["c56"];
                                        e.Row["c57"] = reader["c57"];
                                        e.Row["c58"] = reader["c58"];
                                        e.Row["sk_id"] = reader["sk_id"];
                                        e.Row["s_id"] = reader["s_id"];
                                        e.Row["g_id"] = reader["g_id"];
                                        e.Row["o_id"] = reader["o_id"];
                                        e.Row["p_id"] = reader["p_id"];
                                        e.Row["req_id"] = reader["req_id"];
                                        e.Row["time_stamp"] = reader["time_stamp"];

                                        break;
                                }
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (cmb_g_id_int)
            {
                case 1:
                    switch (cmb_s_id_int)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:

                            tblStr = " t_seikyu";
                            Console.WriteLine("tblStr = " + tblStr);
                            dataGridViewSeikyu.Columns[0].HeaderText = "利用者番号";
                            dataGridViewSeikyu.Columns[1].HeaderText = "要介護度";
                            dataGridViewSeikyu.Columns[2].HeaderText = "利用者名";
                            dataGridViewSeikyu.Columns[3].HeaderText = "提供月";
                            dataGridViewSeikyu.Columns[4].HeaderText = "合計額";
                            dataGridViewSeikyu.Columns[5].HeaderText = "サービス費（保険請求）";
                            dataGridViewSeikyu.Columns[6].HeaderText = "サービス費（公費請求）";
                            dataGridViewSeikyu.Columns[7].HeaderText = "食費（保険請求）";
                            dataGridViewSeikyu.Columns[8].HeaderText = "食費（公費請求）";
                            dataGridViewSeikyu.Columns[9].HeaderText = "居住費（保険請求）";
                            dataGridViewSeikyu.Columns[10].HeaderText = "居住費（公費請求）";
                            dataGridViewSeikyu.Columns[11].HeaderText = "介護請求合計額";
                            dataGridViewSeikyu.Columns[12].HeaderText = "利用者負担額";
                            dataGridViewSeikyu.Columns[13].HeaderText = "自費負担額";
                            dataGridViewSeikyu.Columns[14].HeaderText = "食事負担額";
                            dataGridViewSeikyu.Columns[15].HeaderText = "室料負担額";
                            dataGridViewSeikyu.Columns[16].HeaderText = "特定公費本人支払";
                            dataGridViewSeikyu.Columns[17].HeaderText = "高額介護超過額";
                            dataGridViewSeikyu.Columns[18].HeaderText = "その他実費";
                            dataGridViewSeikyu.Columns[19].HeaderText = "減免額";
                            dataGridViewSeikyu.Columns[20].HeaderText = "過入金";
                            dataGridViewSeikyu.Columns[21].HeaderText = "利用料請求合計額";
                            dataGridViewSeikyu.Columns[21].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("ja-JP");
                            dataGridViewSeikyu.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                            for (int i = 0; i < dataGridViewSeikyu.Columns.Count; i++)
                            {
                                if (i < 1 || i > 4)
                                {
                                    dataGridViewSeikyu.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    dataGridViewSeikyu.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    dataGridViewSeikyu.Columns[i].DefaultCellStyle.Format = "#,##0";
                                }
                                else
                                {
                                    dataGridViewSeikyu.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    dataGridViewSeikyu.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                                }
                            }

                            break;
                    }
                    break;
                case 2:
                    switch (cmb_s_id_int)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:

                            tblStr = "t_shiharai_houhou";
                            Console.WriteLine("tblStr = " + tblStr);
                            dataGridViewShiharai_houhou.Columns[0].HeaderText = "法人名";
                            dataGridViewShiharai_houhou.Columns[1].HeaderText = "施設名";
                            dataGridViewShiharai_houhou.Columns[2].HeaderText = "事業所番号";
                            dataGridViewShiharai_houhou.Columns[3].HeaderText = "事業所名";
                            dataGridViewShiharai_houhou.Columns[4].HeaderText = "利用者番号";
                            dataGridViewShiharai_houhou.Columns[5].HeaderText = "利用者名";
                            dataGridViewShiharai_houhou.Columns[6].HeaderText = "支払方法";
                            dataGridViewShiharai_houhou.Columns[7].HeaderText = "引落口座";
                            dataGridViewShiharai_houhou.Columns[8].HeaderText = "引落金融機関銀行コード";
                            dataGridViewShiharai_houhou.Columns[9].HeaderText = "引落金融機関銀行名（フリガナ）";
                            dataGridViewShiharai_houhou.Columns[10].HeaderText = "引落金融機関銀行名";
                            dataGridViewShiharai_houhou.Columns[11].HeaderText = "引落金融機関支店コード";
                            dataGridViewShiharai_houhou.Columns[12].HeaderText = "引落金融機関支店名（フリガナ）";
                            dataGridViewShiharai_houhou.Columns[13].HeaderText = "引落金融機関支店名";
                            dataGridViewShiharai_houhou.Columns[14].HeaderText = "引落口座種別";
                            dataGridViewShiharai_houhou.Columns[15].HeaderText = "引落口座番号";
                            dataGridViewShiharai_houhou.Columns[16].HeaderText = "引落口座名義人区分";
                            dataGridViewShiharai_houhou.Columns[17].HeaderText = "引落口座名義人（フリガナ）";
                            dataGridViewShiharai_houhou.Columns[18].HeaderText = "引落口座名義人";
                            dataGridViewShiharai_houhou.Columns[19].HeaderText = "引落口座開設日";
                            dataGridViewShiharai_houhou.Columns[20].HeaderText = "引落口座解約日";
                            dataGridViewShiharai_houhou.Columns[21].HeaderText = "引落口座メモ";
                            dataGridViewShiharai_houhou.Columns[22].HeaderText = "振込先委託者名（フリガナ）";
                            dataGridViewShiharai_houhou.Columns[23].HeaderText = "振込先委託者名";
                            dataGridViewShiharai_houhou.Columns[24].HeaderText = "振込先委託者コード";
                            dataGridViewShiharai_houhou.Columns[25].HeaderText = "振込先金融機関銀行コード";
                            dataGridViewShiharai_houhou.Columns[26].HeaderText = "振込先金融機関銀行名（フリガナ）";
                            dataGridViewShiharai_houhou.Columns[27].HeaderText = "振込先金融機関銀行名";
                            dataGridViewShiharai_houhou.Columns[28].HeaderText = "振込先金融機関支店コード";
                            dataGridViewShiharai_houhou.Columns[29].HeaderText = "振込先金融機関支店名（フリガナ）";
                            dataGridViewShiharai_houhou.Columns[30].HeaderText = "振込先金融機関支店名";
                            dataGridViewShiharai_houhou.Columns[31].HeaderText = "振込先口座種別";
                            dataGridViewShiharai_houhou.Columns[32].HeaderText = "振込先口座番号";
                            dataGridViewShiharai_houhou.Columns[33].HeaderText = "振込先口座記号";
                            dataGridViewShiharai_houhou.Columns[34].HeaderText = "振込先引落日";
                            dataGridViewShiharai_houhou.Columns[35].HeaderText = "振込先再振替日";
                            dataGridViewShiharai_houhou.Columns[36].HeaderText = "振込先契約種別コード";
                            dataGridViewShiharai_houhou.Columns[37].HeaderText = "振込先受入事業所センターコード";
                            dataGridViewShiharai_houhou.Columns[38].HeaderText = "振込先手数料：自行";
                            dataGridViewShiharai_houhou.Columns[39].HeaderText = "振込先手数料：他行";
                            dataGridViewShiharai_houhou.Columns[40].HeaderText = "初回引落月";
                            dataGridViewShiharai_houhou.Columns[41].HeaderText = "顧客番号";
                            dataGridViewShiharai_houhou.Columns[42].HeaderText = "被保険者番号";
                            dataGridViewShiharai_houhou.Columns[43].HeaderText = "被保険者氏名";
                            dataGridViewShiharai_houhou.Columns[44].HeaderText = "預金者郵便番号";
                            dataGridViewShiharai_houhou.Columns[45].HeaderText = "預金者氏名";
                            dataGridViewShiharai_houhou.Columns[46].HeaderText = "預金者住所１";
                            dataGridViewShiharai_houhou.Columns[47].HeaderText = "預金者住所２";
                            dataGridViewShiharai_houhou.Columns[48].HeaderText = "預金者住所３";

                            for (int i = 0; i < dataGridViewShiharai_houhou.Columns.Count; i++)
                            {
                                dataGridViewShiharai_houhou.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                dataGridViewShiharai_houhou.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            }
                            break;
                    }
                    break;
                case 3:
                    switch (cmb_s_id_int)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:

                            tblStr = " t_shinzoku_kankei";
                            Console.WriteLine("tblStr = " + tblStr);
                            dataGridViewShinzoku_kankei.Columns[0].HeaderText = "利用者番号";
                            dataGridViewShinzoku_kankei.Columns[1].HeaderText = "利用者名（姓）";
                            dataGridViewShinzoku_kankei.Columns[2].HeaderText = "利用者名（名）";
                            dataGridViewShinzoku_kankei.Columns[3].HeaderText = "利用者名";
                            dataGridViewShinzoku_kankei.Columns[4].HeaderText = "フリガナ（姓）";
                            dataGridViewShinzoku_kankei.Columns[5].HeaderText = "フリガナ（名）";
                            dataGridViewShinzoku_kankei.Columns[6].HeaderText = "フリガナ";
                            dataGridViewShinzoku_kankei.Columns[7].HeaderText = "同名識別";
                            dataGridViewShinzoku_kankei.Columns[8].HeaderText = "性別";
                            dataGridViewShinzoku_kankei.Columns[9].HeaderText = "血液型";
                            dataGridViewShinzoku_kankei.Columns[10].HeaderText = "RH";
                            dataGridViewShinzoku_kankei.Columns[11].HeaderText = "生年月日";
                            dataGridViewShinzoku_kankei.Columns[12].HeaderText = "郵便番号";
                            dataGridViewShinzoku_kankei.Columns[13].HeaderText = "住所";
                            dataGridViewShinzoku_kankei.Columns[14].HeaderText = "電話番号";
                            dataGridViewShinzoku_kankei.Columns[15].HeaderText = "携帯番号";
                            dataGridViewShinzoku_kankei.Columns[16].HeaderText = "E-mail";
                            dataGridViewShinzoku_kankei.Columns[17].HeaderText = "郵便番号（他の住所）";
                            dataGridViewShinzoku_kankei.Columns[18].HeaderText = "住所（他の住所）";
                            dataGridViewShinzoku_kankei.Columns[19].HeaderText = "世帯区分";
                            dataGridViewShinzoku_kankei.Columns[20].HeaderText = "メモ";
                            dataGridViewShinzoku_kankei.Columns[21].HeaderText = "統計用住所";
                            dataGridViewShinzoku_kankei.Columns[22].HeaderText = "親族・関係者名（姓）";
                            dataGridViewShinzoku_kankei.Columns[23].HeaderText = "親族・関係者名（名）";
                            dataGridViewShinzoku_kankei.Columns[24].HeaderText = "親族・関係者名";
                            dataGridViewShinzoku_kankei.Columns[25].HeaderText = "フリガナ（姓）（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[26].HeaderText = "フリガナ（名）（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[27].HeaderText = "フリガナ（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[28].HeaderText = "性別（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[29].HeaderText = "生年月日（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[30].HeaderText = "続柄";
                            dataGridViewShinzoku_kankei.Columns[31].HeaderText = "健康状態";
                            dataGridViewShinzoku_kankei.Columns[32].HeaderText = "職業";
                            dataGridViewShinzoku_kankei.Columns[33].HeaderText = "〒（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[34].HeaderText = "住所（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[35].HeaderText = "住所（地域）（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[36].HeaderText = "宛先";
                            dataGridViewShinzoku_kankei.Columns[37].HeaderText = "電話番号（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[38].HeaderText = "携帯番号（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[39].HeaderText = "E-mail（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[40].HeaderText = "連絡先種別";
                            dataGridViewShinzoku_kankei.Columns[41].HeaderText = "連絡先番号";
                            dataGridViewShinzoku_kankei.Columns[42].HeaderText = "優先順";
                            dataGridViewShinzoku_kankei.Columns[43].HeaderText = "申請者";
                            dataGridViewShinzoku_kankei.Columns[44].HeaderText = "同居家族";
                            dataGridViewShinzoku_kankei.Columns[45].HeaderText = "主介護者";
                            dataGridViewShinzoku_kankei.Columns[46].HeaderText = "保証人";
                            dataGridViewShinzoku_kankei.Columns[47].HeaderText = "支払者";
                            dataGridViewShinzoku_kankei.Columns[48].HeaderText = "相談者";
                            dataGridViewShinzoku_kankei.Columns[49].HeaderText = "（未使用1）";
                            dataGridViewShinzoku_kankei.Columns[50].HeaderText = "（未使用2）";
                            dataGridViewShinzoku_kankei.Columns[51].HeaderText = "（未使用3）";
                            dataGridViewShinzoku_kankei.Columns[52].HeaderText = "（未使用4）";
                            dataGridViewShinzoku_kankei.Columns[53].HeaderText = "メモ（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[54].HeaderText = "面会";
                            dataGridViewShinzoku_kankei.Columns[55].HeaderText = "郵便番号（連絡先住所）";
                            dataGridViewShinzoku_kankei.Columns[56].HeaderText = "住所（連絡先住所）";
                            dataGridViewShinzoku_kankei.Columns[57].HeaderText = "FAX番号";

                            for (int i = 0; i < dataGridViewShinzoku_kankei.Columns.Count; i++)
                            {
                                dataGridViewShinzoku_kankei.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                dataGridViewShinzoku_kankei.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            }
                            break;
                    }
                    break;
            }

            try
            {
                m_conn.Open();

                DataSet ds = new DataSet();
                DataSet Newds = new DataSet();

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(
                    "select"
                    + " *"
                    + " from "
                    + " t_csv"
                    , m_conn);

                NpgsqlCommand command = new NpgsqlCommand(
                    "select"
                    + " count(*)"
                    + " from "
                    + " t_csv"
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
                    + " from "
                    + " t_csv"
                        , m_conn);
                        command.ExecuteNonQuery();
                    }
                }

                switch (cmb_g_id_int)
                {
                    case 1:
                        switch (cmb_s_id_int)
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:

                                da.InsertCommand = new NpgsqlCommand(
                                    "insert into t_csv ("
                                    + " c1"
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
                                    + ", c23"
                                    + ", c24"
                                    + ", c25"
                                    + ", c26"
                                    + ", c27"
                                    + ", c28"
                                    + ", c29"
                                    + ", c30"
                                    + ", c31"
                                    + ", c32"
                                    + ", c33"
                                    + ", c34"
                                    + ", c35"
                                    + ", c36"
                                    + ", c37"
                                    + ", c38"
                                    + ", c39"
                                    + ", c40"
                                    + ", c41"
                                    + ", c42"
                                    + ", c43"
                                    + ", c44"
                                    + ", c45"
                                    + ", c46"
                                    + ", c47"
                                    + ", c48"
                                    + ", c49"
                                    + ", s_id"
                                    + ", g_id"
                                    + " ) values ("
                                    + " :c1"
                                    + ", :c2"
                                    + ", :c3"
                                    + ", :c4"
                                    + ", :c5"
                                    + ", :c6"
                                    + ", :c7"
                                    + ", :c8"
                                    + ", :c9"
                                    + ", :c10"
                                    + ", :c11"
                                    + ", :c12"
                                    + ", :c13"
                                    + ", :c14"
                                    + ", :c15"
                                    + ", :c16"
                                    + ", :c17"
                                    + ", :c18"
                                    + ", :c19"
                                    + ", :c20"
                                    + ", :c21"
                                    + ", :c22"
                                    + ", :c23"
                                    + ", :c24"
                                    + ", :c25"
                                    + ", :c26"
                                    + ", :c27"
                                    + ", :c28"
                                    + ", :c29"
                                    + ", :c30"
                                    + ", :c31"
                                    + ", :c32"
                                    + ", :c33"
                                    + ", :c34"
                                    + ", :c35"
                                    + ", :c36"
                                    + ", :c37"
                                    + ", :c38"
                                    + ", :c39"
                                    + ", :c40"
                                    + ", :c41"
                                    + ", :c42"
                                    + ", :c43"
                                    + ", :c44"
                                    + ", :c45"
                                    + ", :c46"
                                    + ", :c47"
                                    + ", :c48"
                                    + ", :c49"
                                    + ", :s_id"
                                    + ", :g_id"
                                    + ");"
                                    , m_conn);
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c1", NpgsqlTypes.NpgsqlDbType.Text, 0, "c1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c2", NpgsqlTypes.NpgsqlDbType.Text, 0, "c2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c3", NpgsqlTypes.NpgsqlDbType.Text, 0, "c3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c4", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c5", NpgsqlTypes.NpgsqlDbType.Text, 0, "c5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c6", NpgsqlTypes.NpgsqlDbType.Text, 0, "c6", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c7", NpgsqlTypes.NpgsqlDbType.Text, 0, "c7", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c8", NpgsqlTypes.NpgsqlDbType.Text, 0, "c8", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c9", NpgsqlTypes.NpgsqlDbType.Text, 0, "c9", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c10", NpgsqlTypes.NpgsqlDbType.Text, 0, "c10", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c11", NpgsqlTypes.NpgsqlDbType.Text, 0, "c11", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c12", NpgsqlTypes.NpgsqlDbType.Text, 0, "c12", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c13", NpgsqlTypes.NpgsqlDbType.Text, 0, "c13", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c14", NpgsqlTypes.NpgsqlDbType.Text, 0, "c14", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c15", NpgsqlTypes.NpgsqlDbType.Text, 0, "c15", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c16", NpgsqlTypes.NpgsqlDbType.Text, 0, "c16", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c17", NpgsqlTypes.NpgsqlDbType.Text, 0, "c17", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c18", NpgsqlTypes.NpgsqlDbType.Text, 0, "c18", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c19", NpgsqlTypes.NpgsqlDbType.Text, 0, "c19", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c20", NpgsqlTypes.NpgsqlDbType.Text, 0, "c20", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c21", NpgsqlTypes.NpgsqlDbType.Text, 0, "c21", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c22", NpgsqlTypes.NpgsqlDbType.Text, 0, "c22", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c23", NpgsqlTypes.NpgsqlDbType.Text, 0, "c23", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c24", NpgsqlTypes.NpgsqlDbType.Text, 0, "c24", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c25", NpgsqlTypes.NpgsqlDbType.Text, 0, "c25", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c26", NpgsqlTypes.NpgsqlDbType.Text, 0, "c26", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c27", NpgsqlTypes.NpgsqlDbType.Text, 0, "c27", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c28", NpgsqlTypes.NpgsqlDbType.Text, 0, "c28", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c29", NpgsqlTypes.NpgsqlDbType.Text, 0, "c29", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c30", NpgsqlTypes.NpgsqlDbType.Text, 0, "c30", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c31", NpgsqlTypes.NpgsqlDbType.Text, 0, "c31", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c32", NpgsqlTypes.NpgsqlDbType.Text, 0, "c32", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c33", NpgsqlTypes.NpgsqlDbType.Text, 0, "c33", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c34", NpgsqlTypes.NpgsqlDbType.Text, 0, "c34", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c35", NpgsqlTypes.NpgsqlDbType.Text, 0, "c35", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c36", NpgsqlTypes.NpgsqlDbType.Text, 0, "c36", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c37", NpgsqlTypes.NpgsqlDbType.Text, 0, "c37", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c38", NpgsqlTypes.NpgsqlDbType.Text, 0, "c38", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c39", NpgsqlTypes.NpgsqlDbType.Text, 0, "c39", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c40", NpgsqlTypes.NpgsqlDbType.Text, 0, "c40", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c41", NpgsqlTypes.NpgsqlDbType.Text, 0, "c41", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c42", NpgsqlTypes.NpgsqlDbType.Text, 0, "c42", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c43", NpgsqlTypes.NpgsqlDbType.Text, 0, "c43", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c44", NpgsqlTypes.NpgsqlDbType.Text, 0, "c44", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c45", NpgsqlTypes.NpgsqlDbType.Text, 0, "c45", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c46", NpgsqlTypes.NpgsqlDbType.Text, 0, "c46", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c47", NpgsqlTypes.NpgsqlDbType.Text, 0, "c47", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c48", NpgsqlTypes.NpgsqlDbType.Text, 0, "c48", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c49", NpgsqlTypes.NpgsqlDbType.Text, 0, "c49", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("g_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "g_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));

                                break;
                        }
                        break;
                    case 2:
                        switch (cmb_s_id_int)
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:

                                da.InsertCommand = new NpgsqlCommand(
                                    "insert into t_csv ("
                                    + " c1"
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
                                    + ", c23"
                                    + ", c24"
                                    + ", c25"
                                    + ", c26"
                                    + ", c27"
                                    + ", c28"
                                    + ", c29"
                                    + ", c30"
                                    + ", c31"
                                    + ", c32"
                                    + ", c33"
                                    + ", c34"
                                    + ", c35"
                                    + ", c36"
                                    + ", c37"
                                    + ", c38"
                                    + ", c39"
                                    + ", c40"
                                    + ", c41"
                                    + ", c42"
                                    + ", c43"
                                    + ", c44"
                                    + ", c45"
                                    + ", c46"
                                    + ", c47"
                                    + ", c48"
                                    + ", c49"
                                    + ", s_id"
                                    + ", g_id"
                                    + ", p_id"
                                    + ", req_id"
                                    + ", nen"
                                    + ", tsuki"
                                    + " ) values ("
                                    + " :c1"
                                    + ", :c2"
                                    + ", :c3"
                                    + ", :c4"
                                    + ", :c5"
                                    + ", :c6"
                                    + ", :c7"
                                    + ", :c8"
                                    + ", :c9"
                                    + ", :c10"
                                    + ", :c11"
                                    + ", :c12"
                                    + ", :c13"
                                    + ", :c14"
                                    + ", :c15"
                                    + ", :c16"
                                    + ", :c17"
                                    + ", :c18"
                                    + ", :c19"
                                    + ", :c20"
                                    + ", :c21"
                                    + ", :c22"
                                    + ", :c23"
                                    + ", :c24"
                                    + ", :c25"
                                    + ", :c26"
                                    + ", :c27"
                                    + ", :c28"
                                    + ", :c29"
                                    + ", :c30"
                                    + ", :c31"
                                    + ", :c32"
                                    + ", :c33"
                                    + ", :c34"
                                    + ", :c35"
                                    + ", :c36"
                                    + ", :c37"
                                    + ", :c38"
                                    + ", :c39"
                                    + ", :c40"
                                    + ", :c41"
                                    + ", :c42"
                                    + ", :c43"
                                    + ", :c44"
                                    + ", :c45"
                                    + ", :c46"
                                    + ", :c47"
                                    + ", :c48"
                                    + ", :c49"
                                    + ", :s_id"
                                    + ", :g_id"
                                    + ", :p_id"
                                    + ", :req_id"
                                    + ", '" + cmb_nen_str + "'"
                                    + ", '" + cmb_tsuki_str + "'"
                                    + ");"
                                    , m_conn);
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c1", NpgsqlTypes.NpgsqlDbType.Text, 0, "c1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c2", NpgsqlTypes.NpgsqlDbType.Text, 0, "c2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c3", NpgsqlTypes.NpgsqlDbType.Text, 0, "c3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c4", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c5", NpgsqlTypes.NpgsqlDbType.Text, 0, "c5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c6", NpgsqlTypes.NpgsqlDbType.Text, 0, "c6", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c7", NpgsqlTypes.NpgsqlDbType.Text, 0, "c7", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c8", NpgsqlTypes.NpgsqlDbType.Text, 0, "c8", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c9", NpgsqlTypes.NpgsqlDbType.Text, 0, "c9", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c10", NpgsqlTypes.NpgsqlDbType.Text, 0, "c10", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c11", NpgsqlTypes.NpgsqlDbType.Text, 0, "c11", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c12", NpgsqlTypes.NpgsqlDbType.Text, 0, "c12", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c13", NpgsqlTypes.NpgsqlDbType.Text, 0, "c13", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c14", NpgsqlTypes.NpgsqlDbType.Text, 0, "c14", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c15", NpgsqlTypes.NpgsqlDbType.Text, 0, "c15", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c16", NpgsqlTypes.NpgsqlDbType.Text, 0, "c16", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c17", NpgsqlTypes.NpgsqlDbType.Text, 0, "c17", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c18", NpgsqlTypes.NpgsqlDbType.Text, 0, "c18", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c19", NpgsqlTypes.NpgsqlDbType.Text, 0, "c19", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c20", NpgsqlTypes.NpgsqlDbType.Text, 0, "c20", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c21", NpgsqlTypes.NpgsqlDbType.Text, 0, "c21", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c22", NpgsqlTypes.NpgsqlDbType.Text, 0, "c22", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c23", NpgsqlTypes.NpgsqlDbType.Text, 0, "c23", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c24", NpgsqlTypes.NpgsqlDbType.Text, 0, "c24", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c25", NpgsqlTypes.NpgsqlDbType.Text, 0, "c25", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c26", NpgsqlTypes.NpgsqlDbType.Text, 0, "c26", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c27", NpgsqlTypes.NpgsqlDbType.Text, 0, "c27", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c28", NpgsqlTypes.NpgsqlDbType.Text, 0, "c28", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c29", NpgsqlTypes.NpgsqlDbType.Text, 0, "c29", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c30", NpgsqlTypes.NpgsqlDbType.Text, 0, "c30", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c31", NpgsqlTypes.NpgsqlDbType.Text, 0, "c31", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c32", NpgsqlTypes.NpgsqlDbType.Text, 0, "c32", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c33", NpgsqlTypes.NpgsqlDbType.Text, 0, "c33", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c34", NpgsqlTypes.NpgsqlDbType.Text, 0, "c34", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c35", NpgsqlTypes.NpgsqlDbType.Text, 0, "c35", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c36", NpgsqlTypes.NpgsqlDbType.Text, 0, "c36", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c37", NpgsqlTypes.NpgsqlDbType.Text, 0, "c37", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c38", NpgsqlTypes.NpgsqlDbType.Text, 0, "c38", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c39", NpgsqlTypes.NpgsqlDbType.Text, 0, "c39", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c40", NpgsqlTypes.NpgsqlDbType.Text, 0, "c40", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c41", NpgsqlTypes.NpgsqlDbType.Text, 0, "c41", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c42", NpgsqlTypes.NpgsqlDbType.Text, 0, "c42", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c43", NpgsqlTypes.NpgsqlDbType.Text, 0, "c43", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c44", NpgsqlTypes.NpgsqlDbType.Text, 0, "c44", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c45", NpgsqlTypes.NpgsqlDbType.Text, 0, "c45", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c46", NpgsqlTypes.NpgsqlDbType.Text, 0, "c46", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c47", NpgsqlTypes.NpgsqlDbType.Text, 0, "c47", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c48", NpgsqlTypes.NpgsqlDbType.Text, 0, "c48", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c49", NpgsqlTypes.NpgsqlDbType.Text, 0, "c49", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("g_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "g_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("p_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "p_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("req_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "req_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));

                                break;
                        }
                        break;
                    case 3:
                        switch (cmb_s_id_int)
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:

                                da.InsertCommand = new NpgsqlCommand(
                                    "insert into t_csv ("
                                    + " c1"
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
                                    + ", c23"
                                    + ", c24"
                                    + ", c25"
                                    + ", c26"
                                    + ", c27"
                                    + ", c28"
                                    + ", c29"
                                    + ", c30"
                                    + ", c31"
                                    + ", c32"
                                    + ", c33"
                                    + ", c34"
                                    + ", c35"
                                    + ", c36"
                                    + ", c37"
                                    + ", c38"
                                    + ", c39"
                                    + ", c40"
                                    + ", c41"
                                    + ", c42"
                                    + ", c43"
                                    + ", c44"
                                    + ", c45"
                                    + ", c46"
                                    + ", c47"
                                    + ", c48"
                                    + ", c49"
                                    + ", c50"
                                    + ", c51"
                                    + ", c52"
                                    + ", c53"
                                    + ", c54"
                                    + ", c55"
                                    + ", c56"
                                    + ", c57"
                                    + ", c58"
                                    + ", s_id"
                                    + ", g_id"
                                    + ", p_id"
                                    + ", req_id"
                                    + ", nen"
                                    + ", tsuki"
                                    + " ) values ("
                                    + " :c1"
                                    + ", :c2"
                                    + ", :c3"
                                    + ", :c4"
                                    + ", :c5"
                                    + ", :c6"
                                    + ", :c7"
                                    + ", :c8"
                                    + ", :c9"
                                    + ", :c10"
                                    + ", :c11"
                                    + ", :c12"
                                    + ", :c13"
                                    + ", :c14"
                                    + ", :c15"
                                    + ", :c16"
                                    + ", :c17"
                                    + ", :c18"
                                    + ", :c19"
                                    + ", :c20"
                                    + ", :c21"
                                    + ", :c22"
                                    + ", :c23"
                                    + ", :c24"
                                    + ", :c25"
                                    + ", :c26"
                                    + ", :c27"
                                    + ", :c28"
                                    + ", :c29"
                                    + ", :c30"
                                    + ", :c31"
                                    + ", :c32"
                                    + ", :c33"
                                    + ", :c34"
                                    + ", :c35"
                                    + ", :c36"
                                    + ", :c37"
                                    + ", :c38"
                                    + ", :c39"
                                    + ", :c40"
                                    + ", :c41"
                                    + ", :c42"
                                    + ", :c43"
                                    + ", :c44"
                                    + ", :c45"
                                    + ", :c46"
                                    + ", :c47"
                                    + ", :c48"
                                    + ", :c49"
                                    + ", :c50"
                                    + ", :c51"
                                    + ", :c52"
                                    + ", :c53"
                                    + ", :c54"
                                    + ", :c55"
                                    + ", :c56"
                                    + ", :c57"
                                    + ", :c58"
                                    + ", :s_id"
                                    + ", :g_id"
                                    + ", :p_id"
                                    + ", :req_id"
                                    + ", '" + cmb_nen_str + "'"
                                    + ", '" + cmb_tsuki_str + "'"
                                    + ");"
                                    , m_conn);
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c1", NpgsqlTypes.NpgsqlDbType.Text, 0, "c1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c2", NpgsqlTypes.NpgsqlDbType.Text, 0, "c2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c3", NpgsqlTypes.NpgsqlDbType.Text, 0, "c3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c4", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c5", NpgsqlTypes.NpgsqlDbType.Text, 0, "c5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c6", NpgsqlTypes.NpgsqlDbType.Text, 0, "c6", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c7", NpgsqlTypes.NpgsqlDbType.Text, 0, "c7", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c8", NpgsqlTypes.NpgsqlDbType.Text, 0, "c8", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c9", NpgsqlTypes.NpgsqlDbType.Text, 0, "c9", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c10", NpgsqlTypes.NpgsqlDbType.Text, 0, "c10", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c11", NpgsqlTypes.NpgsqlDbType.Text, 0, "c11", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c12", NpgsqlTypes.NpgsqlDbType.Text, 0, "c12", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c13", NpgsqlTypes.NpgsqlDbType.Text, 0, "c13", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c14", NpgsqlTypes.NpgsqlDbType.Text, 0, "c14", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c15", NpgsqlTypes.NpgsqlDbType.Text, 0, "c15", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c16", NpgsqlTypes.NpgsqlDbType.Text, 0, "c16", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c17", NpgsqlTypes.NpgsqlDbType.Text, 0, "c17", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c18", NpgsqlTypes.NpgsqlDbType.Text, 0, "c18", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c19", NpgsqlTypes.NpgsqlDbType.Text, 0, "c19", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c20", NpgsqlTypes.NpgsqlDbType.Text, 0, "c20", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c21", NpgsqlTypes.NpgsqlDbType.Text, 0, "c21", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c22", NpgsqlTypes.NpgsqlDbType.Text, 0, "c22", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c23", NpgsqlTypes.NpgsqlDbType.Text, 0, "c23", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c24", NpgsqlTypes.NpgsqlDbType.Text, 0, "c24", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c25", NpgsqlTypes.NpgsqlDbType.Text, 0, "c25", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c26", NpgsqlTypes.NpgsqlDbType.Text, 0, "c26", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c27", NpgsqlTypes.NpgsqlDbType.Text, 0, "c27", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c28", NpgsqlTypes.NpgsqlDbType.Text, 0, "c28", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c29", NpgsqlTypes.NpgsqlDbType.Text, 0, "c29", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c30", NpgsqlTypes.NpgsqlDbType.Text, 0, "c30", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c31", NpgsqlTypes.NpgsqlDbType.Text, 0, "c31", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c32", NpgsqlTypes.NpgsqlDbType.Text, 0, "c32", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c33", NpgsqlTypes.NpgsqlDbType.Text, 0, "c33", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c34", NpgsqlTypes.NpgsqlDbType.Text, 0, "c34", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c35", NpgsqlTypes.NpgsqlDbType.Text, 0, "c35", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c36", NpgsqlTypes.NpgsqlDbType.Text, 0, "c36", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c37", NpgsqlTypes.NpgsqlDbType.Text, 0, "c37", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c38", NpgsqlTypes.NpgsqlDbType.Text, 0, "c38", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c39", NpgsqlTypes.NpgsqlDbType.Text, 0, "c39", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c40", NpgsqlTypes.NpgsqlDbType.Text, 0, "c40", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c41", NpgsqlTypes.NpgsqlDbType.Text, 0, "c41", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c42", NpgsqlTypes.NpgsqlDbType.Text, 0, "c42", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c43", NpgsqlTypes.NpgsqlDbType.Text, 0, "c43", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c44", NpgsqlTypes.NpgsqlDbType.Text, 0, "c44", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c45", NpgsqlTypes.NpgsqlDbType.Text, 0, "c45", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c46", NpgsqlTypes.NpgsqlDbType.Text, 0, "c46", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c47", NpgsqlTypes.NpgsqlDbType.Text, 0, "c47", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c48", NpgsqlTypes.NpgsqlDbType.Text, 0, "c48", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c49", NpgsqlTypes.NpgsqlDbType.Text, 0, "c49", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c50", NpgsqlTypes.NpgsqlDbType.Text, 0, "c50", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c51", NpgsqlTypes.NpgsqlDbType.Text, 0, "c51", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c52", NpgsqlTypes.NpgsqlDbType.Text, 0, "c52", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c53", NpgsqlTypes.NpgsqlDbType.Text, 0, "c53", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c54", NpgsqlTypes.NpgsqlDbType.Text, 0, "c54", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c55", NpgsqlTypes.NpgsqlDbType.Text, 0, "c55", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c56", NpgsqlTypes.NpgsqlDbType.Text, 0, "c56", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c57", NpgsqlTypes.NpgsqlDbType.Text, 0, "c57", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("c58", NpgsqlTypes.NpgsqlDbType.Text, 0, "c58", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("g_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "g_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("p_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "p_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                da.InsertCommand.Parameters.Add(new NpgsqlParameter("req_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "req_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));

                                break;
                        }
                        break;
                }

                da.Fill(ds);

                DataTable dt = ds.Tables[0];

                OpenFileDialog ofd = new OpenFileDialog();

                ofd.FileName = "*.csv";
                ofd.Filter = "CSVファイル(*.csv)|*.csv|すべてのファイル(*.*)|*.*";
                ofd.FilterIndex = 2;
                ofd.Title = "開くファイルを選択してください";
                ofd.RestoreDirectory = true;
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;

                DialogResult btn = ofd.ShowDialog();
                if (btn == System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show(ofd.FileName + "が選択されました");
                    String str = ofd.FileName;
                    Console.WriteLine("str: {0}", str);
                    ofdstr = Path.GetFileName(str);
                    //ofdstr = Regex.Replace(str, @"[^\d]", string.Empty);
                    Console.WriteLine("ofdstr: {0}", ofdstr);
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        // 構造化テキストファイルの解析に使用するメソッドとプロパティを提供するクラス
                        // ※Microsoft.VisualBasic.FileIO.TextFieldParser を使用する
                        TextFieldParser tfp = new TextFieldParser(str, Encoding.GetEncoding(932));
                        tfp.Delimiters = new string[] { "," };
                        string[] colheaders = tfp.ReadFields(); // 1行読み込み

                        ArrayList list = new ArrayList();

                        // ファイルの中身をArrayListに格納
                        while (!tfp.EndOfData)
                        {
                            string[] fields = tfp.ReadFields();
                            list.Add(fields);
                        }

                        // 行オブジェクト
                        DataRow row;

                        // ファイルの中身をDataTableに格納
                        row = dt.NewRow();

                        foreach (string[] fields in list)
                        {
                            row = dt.NewRow();

                            for (int n = 0; n < colheaders.Length; n++)
                            {
                                row[n] = fields[n];
                            }
                            // データテーブルに行追加
                            dt.Rows.Add(row);

                        }
                        DataSet ds2 = ds.GetChanges();

                        da.Update(ds2);

                        //ds.Merge(ds2);
                        ds.AcceptChanges();

                        tblStr = "t_csv";

                        command = new NpgsqlCommand(
                            "update " + tblStr + " set o_id = " + cmb_o_id_int
                            , m_conn);
                        command.ExecuteNonQuery();

                        command = new NpgsqlCommand(
                            "update " + tblStr + " set s_id = " + cmb_s_id_int
                            , m_conn);
                        command.ExecuteNonQuery();

                        command = new NpgsqlCommand(
                            "update " + tblStr + " set g_id = " + cmb_g_id_int
                            , m_conn);
                        command.ExecuteNonQuery();

                        command = new NpgsqlCommand(
                            "update " + tblStr + " set p_id = " + 1
                            , m_conn);
                        command.ExecuteNonQuery();

                        command = new NpgsqlCommand(
                            "update " + tblStr + " set req_id = " + cmb_req_id_int
                            , m_conn);
                        command.ExecuteNonQuery();

                        // RowUpdate
                        da.RowUpdated += new NpgsqlRowUpdatedEventHandler(SeikyuRowUpdated);

                        switch (cmb_g_id_int)
                        {
                            case 1:
                                switch (cmb_s_id_int)
                                {
                                    case 1:
                                    case 2:
                                    case 3:
                                    case 4:
                                    case 5:
                                    case 6:

                                        if (_seikyu_ds.Tables["seikyu_ds"] != null)
                                            _seikyu_ds.Tables["seikyu_ds"].Clear();
                                        da.Fill(_seikyu_ds, "seikyu_ds");

                                        bindingSourceSeikyu.DataSource = _seikyu_ds;

                                        bindingNavigatorSeikyu.BindingSource = bindingSourceSeikyu;

                                        dataGridViewSeikyu.DataSource = bindingSourceSeikyu;

                                        dataGridViewSeikyu.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                                        bindingNavigatorSeikyu.Visible = true;
                                        bindingNavigatorShiharai_houhou.Visible = false;
                                        bindingNavigatorShinzoku_kankei.Visible = false;

                                        dataGridViewSeikyu.Visible = true;
                                        dataGridViewShiharai_houhou.Visible = false;
                                        dataGridViewShinzoku_kankei.Visible = false;

                                        break;
                                }
                                break;

                            case 2:
                                switch (cmb_s_id_int)
                                {
                                    case 1:
                                    case 2:
                                    case 3:
                                    case 4:
                                    case 5:
                                    case 6:

                                        if (_shiharai_houhou_ds.Tables["shiharai_houhou_ds"] != null)
                                            _shiharai_houhou_ds.Tables["shiharai_houhou_ds"].Clear();
                                        da.Fill(_shiharai_houhou_ds, "shiharai_houhou_ds");

                                        bindingSourceShiharai_houhou.DataSource = _shiharai_houhou_ds;
                                        bindingSourceShiharai_houhou.DataMember = "shiharai_houhou_ds";

                                        bindingNavigatorShiharai_houhou.BindingSource = bindingSourceShiharai_houhou;

                                        dataGridViewShiharai_houhou.AutoGenerateColumns = false;

                                        dataGridViewShiharai_houhou.DataSource = bindingSourceShiharai_houhou;

                                        dataGridViewShiharai_houhou.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                                        bindingNavigatorSeikyu.Visible = false;
                                        bindingNavigatorShiharai_houhou.Visible = true;
                                        bindingNavigatorShinzoku_kankei.Visible = false;

                                        dataGridViewSeikyu.Visible = false;
                                        dataGridViewShiharai_houhou.Visible = true;
                                        dataGridViewShinzoku_kankei.Visible = false;

                                        break;
                                }
                                break;

                            case 3:
                                switch (cmb_s_id_int)
                                {
                                    case 1:
                                    case 2:
                                    case 3:
                                    case 4:
                                    case 5:
                                    case 6:

                                        if (_shinzoku_kankei_ds.Tables["shinzoku_kankei_ds"] != null)
                                            _shinzoku_kankei_ds.Tables["shinzoku_kankei_ds"].Clear();
                                        da.Fill(_shinzoku_kankei_ds, "shinzoku_kankei_ds");

                                        bindingSourceShinzoku_kankei.DataSource = _shinzoku_kankei_ds;
                                        bindingSourceShinzoku_kankei.DataMember = "shinzoku_kankei_ds";

                                        bindingNavigatorShinzoku_kankei.BindingSource = bindingSourceShinzoku_kankei;

                                        dataGridViewShinzoku_kankei.AutoGenerateColumns = false;

                                        dataGridViewShinzoku_kankei.DataSource = bindingSourceShinzoku_kankei;

                                        dataGridViewShinzoku_kankei.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                                        bindingNavigatorSeikyu.Visible = false;
                                        bindingNavigatorShiharai_houhou.Visible = false;
                                        bindingNavigatorShinzoku_kankei.Visible = true;

                                        dataGridViewSeikyu.Visible = false;
                                        dataGridViewShiharai_houhou.Visible = false;
                                        dataGridViewShinzoku_kankei.Visible = true;

                                        break;
                                }
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        MessageBox.Show(ofd.FileName + "が、インポートされました");
                        Cursor.Current = Cursors.Default;
                        //m_conn.Close();
                    }

                    switch (cmb_g_id_int)
                    {
                        case 1:
                            switch (cmb_s_id_int)
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:
                                    try
                                    {
                                        //m_conn.Open();
                                        //NpgsqlTransaction t = m_conn.BeginTransaction();
                                        Cursor.Current = Cursors.WaitCursor;
                                        {
                                            //command = new NpgsqlCommand(
                                            da.InsertCommand = new NpgsqlCommand(
                                            "insert into t_seikyu ("
                                            + " c1"
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
                                            + ", c4_array"
                                            + ", s_id"
                                            + ", g_id"
                                            + ", o_id"
                                            + ", p_id"
                                            + ", req_id"
                                            + ", id"
                                            + " ) select"
                                            + " c1"
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
                                            + ", string_to_array (c4, '/') as c4_array"
                                            + ", s_id"
                                            + ", g_id"
                                            + ", o_id"
                                            + ", p_id"
                                            + ", req_id"
                                            + ", id"
                                            + " from t_csv"
                                            + " order by id;"
                                                , m_conn);

                                            da.InsertCommand.ExecuteNonQuery();
                                            //t.Commit();
                                        }

                                        if (_seikyu_ds.Tables["seikyu_ds"] != null)
                                            _seikyu_ds.Tables["seikyu_ds"].Clear();
                                        da.Fill(_seikyu_ds, "seikyu_ds");

                                        bindingSourceSeikyu.DataSource = _seikyu_ds;

                                        bindingNavigatorSeikyu.BindingSource = bindingSourceSeikyu;

                                        dataGridViewSeikyu.DataSource = bindingSourceSeikyu;

                                        dataGridViewSeikyu.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                    finally
                                    {
                                        MessageBox.Show(ofd.FileName + "が、追加されました");
                                        Cursor.Current = Cursors.Default;
                                        m_conn.Close();
                                    }
                                    break;
                            }
                            break;

                        case 2:
                            switch (cmb_s_id_int)
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:
                                    {
                                        try
                                        {
                                            Cursor.Current = Cursors.WaitCursor;
                                            {
                                                da.InsertCommand = new NpgsqlCommand(
                                                "insert into t_shiharai_houhou ("
                                                + " c1"
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
                                                + ", c23"
                                                + ", c24"
                                                + ", c25"
                                                + ", c26"
                                                + ", c27"
                                                + ", c28"
                                                + ", c29"
                                                + ", c30"
                                                + ", c31"
                                                + ", c32"
                                                + ", c33"
                                                + ", c34"
                                                + ", c35"
                                                + ", c36"
                                                + ", c37"
                                                + ", c38"
                                                + ", c39"
                                                + ", c40"
                                                + ", c41"
                                                + ", c42"
                                                + ", c43"
                                                + ", c44"
                                                + ", c45"
                                                + ", c46"
                                                + ", c47"
                                                + ", c48"
                                                + ", c49"
                                                + ", s_id"
                                                + ", g_id"
                                                + ", o_id"
                                                + ", p_id"
                                                + ", req_id"
                                                + ", c4_array"
                                                + " ) select"
                                                + " coalesce(c1, '') c1"
                                                + ", coalesce(c2, '') c2"
                                                + ", coalesce(c3, '') c3"
                                                + ", coalesce(c4, '') c4"
                                                + ", coalesce(c5, '') c5"
                                                + ", coalesce(c6, '') c6"
                                                + ", coalesce(c7, '') c7"
                                                + ", coalesce(c8, '') c8"
                                                + ", coalesce(c9, '') c9"
                                                + ", coalesce(c10, '') c10"
                                                + ", coalesce(c11, '') c11"
                                                + ", coalesce(c12, '') c12"
                                                + ", coalesce(c13, '') c13"
                                                + ", coalesce(c14, '') c14"
                                                + ", coalesce(c15, '') c15"
                                                + ", coalesce(c16, '') c16"
                                                + ", coalesce(c17, '') c17"
                                                + ", coalesce(c18, '') c18"
                                                + ", coalesce(c19, '') c19"
                                                + ", coalesce(c20, '') c20"
                                                + ", coalesce(c21, '') c21"
                                                + ", coalesce(c22, '') c22"
                                                + ", coalesce(c23, '') c23"
                                                + ", coalesce(c24, '') c24"
                                                + ", coalesce(c25, '') c25"
                                                + ", coalesce(c26, '') c26"
                                                + ", coalesce(c27, '') c27"
                                                + ", coalesce(c28, '') c28"
                                                + ", coalesce(c29, '') c29"
                                                + ", coalesce(c30, '') c30"
                                                + ", coalesce(c31, '') c31"
                                                + ", coalesce(c32, '') c32"
                                                + ", coalesce(c33, '') c33"
                                                + ", coalesce(c34, '') c34"
                                                + ", coalesce(c35, '') c35"
                                                + ", coalesce(c36, '') c36"
                                                + ", coalesce(c37, '') c37"
                                                + ", coalesce(c38, '') c38"
                                                + ", coalesce(c39, '') c39"
                                                + ", coalesce(c40, '') c40"
                                                + ", coalesce(c41, '') c41"
                                                + ", coalesce(c42, '') c42"
                                                + ", coalesce(c43, '') c43"
                                                + ", coalesce(c44, '') c44"
                                                + ", coalesce(c45, '') c45"
                                                + ", coalesce(c46, '') c46"
                                                + ", coalesce(c47, '') c47"
                                                + ", coalesce(c48, '') c48"
                                                + ", coalesce(c49, '') c49"
                                                + ", s_id"
                                                + ", g_id"
                                                + ", o_id"
                                                + ", p_id"
                                                + ", req_id"
                                                + ", case when length('" + cmb_tsuki_str + "')=1 then"
                                                + " string_to_array ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "', '/')"
                                                + "       when length('" + cmb_tsuki_str + "')=2 then"
                                                + " string_to_array ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "', '/')"
                                                + " end"
                                                // 事業者番号設定
                                                //+ " from t_csv where c3 = '0176700250';"
                                                + " from t_csv where o_id = " + cmb_o_id_int + ";"
                                                    , m_conn);
                                                da.InsertCommand.ExecuteNonQuery();
                                            }

                                            if (_shiharai_houhou_ds.Tables["shiharai_houhou_ds"] != null)
                                                _shiharai_houhou_ds.Tables["shiharai_houhou_ds"].Clear();
                                            da.Fill(_shiharai_houhou_ds, "shiharai_houhou_ds");

                                            bindingSourceShiharai_houhou.DataSource = _shiharai_houhou_ds;

                                            bindingNavigatorShiharai_houhou.BindingSource = bindingSourceShiharai_houhou;

                                            dataGridViewShiharai_houhou.DataSource = bindingSourceShiharai_houhou;

                                            dataGridViewShiharai_houhou.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }
                                        finally
                                        {
                                            MessageBox.Show(ofd.FileName + "が、追加されました");
                                            Cursor.Current = Cursors.Default;
                                            m_conn.Close();
                                        }
                                    }
                                    break;
                            }
                            break;
                        case 3:
                            switch (cmb_s_id_int)
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:
                                    {
                                        try
                                        {
                                            Cursor.Current = Cursors.WaitCursor;
                                            {
                                                da.InsertCommand = new NpgsqlCommand(
                                                "insert into t_shinzoku_kankei ("
                                                + " c1"
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
                                                + ", c23"
                                                + ", c24"
                                                + ", c25"
                                                + ", c26"
                                                + ", c27"
                                                + ", c28"
                                                + ", c29"
                                                + ", c30"
                                                + ", c31"
                                                + ", c32"
                                                + ", c33"
                                                + ", c34"
                                                + ", c35"
                                                + ", c36"
                                                + ", c37"
                                                + ", c38"
                                                + ", c39"
                                                + ", c40"
                                                + ", c41"
                                                + ", c42"
                                                + ", c43"
                                                + ", c44"
                                                + ", c45"
                                                + ", c46"
                                                + ", c47"
                                                + ", c48"
                                                + ", c49"
                                                + ", c50"
                                                + ", c51"
                                                + ", c52"
                                                + ", c53"
                                                + ", c54"
                                                + ", c55"
                                                + ", c56"
                                                + ", c57"
                                                + ", c58"
                                                + ", s_id"
                                                + ", g_id"
                                                + ", o_id"
                                                + ", p_id"
                                                + ", req_id"
                                                + ", c4_array"
                                                + " ) select"
                                                + " coalesce(c1, '') c1"
                                                + ", coalesce(c2, '') c2"
                                                + ", coalesce(c3, '') c3"
                                                + ", coalesce(c4, '') c4"
                                                + ", coalesce(c5, '') c5"
                                                + ", coalesce(c6, '') c6"
                                                + ", coalesce(c7, '') c7"
                                                + ", coalesce(c8, '') c8"
                                                + ", coalesce(c9, '') c9"
                                                + ", coalesce(c10, '') c10"
                                                + ", coalesce(c11, '') c11"
                                                + ", coalesce(c12, '') c12"
                                                + ", coalesce(c13, '') c13"
                                                + ", coalesce(c14, '') c14"
                                                + ", coalesce(c15, '') c15"
                                                + ", coalesce(c16, '') c16"
                                                + ", coalesce(c17, '') c17"
                                                + ", coalesce(c18, '') c18"
                                                + ", coalesce(c19, '') c19"
                                                + ", coalesce(c20, '') c20"
                                                + ", coalesce(c21, '') c21"
                                                + ", coalesce(c22, '') c22"
                                                + ", coalesce(c23, '') c23"
                                                + ", coalesce(c24, '') c24"
                                                + ", coalesce(c25, '') c25"
                                                + ", coalesce(c26, '') c26"
                                                + ", coalesce(c27, '') c27"
                                                + ", coalesce(c28, '') c28"
                                                + ", coalesce(c29, '') c29"
                                                + ", coalesce(c30, '') c30"
                                                + ", coalesce(c31, '') c31"
                                                + ", coalesce(c32, '') c32"
                                                + ", coalesce(c33, '') c33"
                                                + ", coalesce(c34, '') c34"
                                                + ", coalesce(c35, '') c35"
                                                + ", coalesce(c36, '') c36"
                                                + ", coalesce(c37, '') c37"
                                                + ", coalesce(c38, '') c38"
                                                + ", coalesce(c39, '') c39"
                                                + ", coalesce(c40, '') c40"
                                                + ", coalesce(c41, '') c41"
                                                + ", coalesce(c42, '') c42"
                                                + ", coalesce(c43, '') c43"
                                                + ", coalesce(c44, '') c44"
                                                + ", coalesce(c45, '') c45"
                                                + ", coalesce(c46, '') c46"
                                                + ", coalesce(c47, '') c47"
                                                + ", coalesce(c48, '') c48"
                                                + ", coalesce(c49, '') c49"
                                                + ", coalesce(c50, '') c50"
                                                + ", coalesce(c51, '') c51"
                                                + ", coalesce(c52, '') c52"
                                                + ", coalesce(c53, '') c53"
                                                + ", coalesce(c54, '') c54"
                                                + ", coalesce(c55, '') c55"
                                                + ", coalesce(c56, '') c56"
                                                + ", coalesce(c57, '') c57"
                                                + ", coalesce(c58, '') c58"
                                                + ", s_id"
                                                + ", g_id"
                                                + ", o_id"
                                                + ", p_id"
                                                + ", req_id"
                                                + ", case when length('" + cmb_tsuki_str + "')=1 then"
                                                + " string_to_array ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "', '/')"
                                                + "       when length('" + cmb_tsuki_str + "')=2 then"
                                                + " string_to_array ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "', '/')"
                                                + " end"
                                                + " from t_csv;"
                                                    //+ " order by id"
                                                    , m_conn);
                                                da.InsertCommand.ExecuteNonQuery();
                                            }
                                            if (_shinzoku_kankei_ds.Tables["shinzoku_kankei_ds"] != null)
                                                _shinzoku_kankei_ds.Tables["shinzoku_kankei_ds"].Clear();
                                            da.Fill(_shinzoku_kankei_ds, "shinzoku_kankei_ds");

                                            bindingSourceSeikyu.DataSource = _shinzoku_kankei_ds;

                                            bindingNavigatorSeikyu.BindingSource = bindingSourceSeikyu;

                                            dataGridViewSeikyu.DataSource = bindingSourceSeikyu;

                                            dataGridViewSeikyu.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }
                                        finally
                                        {
                                            MessageBox.Show(ofd.FileName + "が、追加されました");
                                            Cursor.Current = Cursors.Default;
                                            m_conn.Close();
                                        }
                                    }
                                    break;
                            }
                            break;
                    }

                    // 再表示
                    switch (cmb_g_id_int)
                    {
                        case 1:
                            switch (cmb_s_id_int)
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:
                                    da.SelectCommand = new NpgsqlCommand
                                    (
                                        "select"
                                        + " c1"
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
                                        + ", c4_array"
                                        + ", time_stamp"
                                        + ", r_id"
                                        + ", s_id"
                                        + ", g_id"
                                        + ", o_id"
                                        + ", id"
                                        + ", p_id"
                                        + ", req_id"
                                        + " from"
                                        + " t_seikyu"
                                        + " where time_stamp = (select max(time_stamp) from t_seikyu"
                                        + " where s_id::Integer = " + cmb_s_id_int
                                        + " and g_id::Integer = " + cmb_g_id_int
                                        + " and o_id::Integer = " + cmb_o_id_int
                                        //+ " where s_id::Integer = " + cmb_s_id_int + " and g_id::Integer = " + cmb_g_id_int
                                        + " and c4_array[1]::text || '/' || c4_array[2]::Text = case when length('" + cmb_tsuki_str + "')=1 then"
                                                + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                                                + "       when length('" + cmb_tsuki_str + "')=2 then"
                                                + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                                                + " end"
                                        + ");"
                                        //+ " order by id"
                                        , m_conn
                                    );

                                    if (cmb_c4.SelectedItem == null)
                                    {
                                        da.SelectCommand.Parameters.Add(new NpgsqlParameter("c4",
                                        NpgsqlTypes.NpgsqlDbType.Text, 0, "c4",
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

                                    // insert
                                    da.InsertCommand = new NpgsqlCommand(
                                    "insert into t_seikyu ("
                                            + " c1"
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
                                            + ", c4_array"
                                            + ", s_id"
                                            + ", g_id"
                                            + ", o_id"
                                            + ", p_id"
                                            + ", req_id"
                                            + ", id"
                                            + " ) select"
                                            + " :c1"
                                            + ", :c2"
                                            + ", :c3"
                                            + ", :c4"
                                            + ", :c5"
                                            + ", :c6"
                                            + ", :c7"
                                            + ", :c8"
                                            + ", :c9"
                                            + ", :c10"
                                            + ", :c11"
                                            + ", :c12"
                                            + ", :c13"
                                            + ", :c14"
                                            + ", :c15"
                                            + ", :c16"
                                            + ", :c17"
                                            + ", :c18"
                                            + ", :c19"
                                            + ", :c20"
                                            + ", :c21"
                                            + ", :c22"
                                            + ", string_to_array (:c4, '/') as c4_array"
                                            + ", :s_id"
                                            + ", :g_id"
                                            + ", :o_id"
                                            + ", :p_id"
                                            + ", :req_id"
                                            + ", :id"
                                            + " from t_csv;"
                                                , m_conn
                                                );
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c1", NpgsqlTypes.NpgsqlDbType.Text, 0, "c1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c2", NpgsqlTypes.NpgsqlDbType.Text, 0, "c2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c3", NpgsqlTypes.NpgsqlDbType.Text, 0, "c3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c4", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c5", NpgsqlTypes.NpgsqlDbType.Text, 0, "c5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c6", NpgsqlTypes.NpgsqlDbType.Text, 0, "c6", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c7", NpgsqlTypes.NpgsqlDbType.Text, 0, "c7", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c8", NpgsqlTypes.NpgsqlDbType.Text, 0, "c8", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c9", NpgsqlTypes.NpgsqlDbType.Text, 0, "c9", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c10", NpgsqlTypes.NpgsqlDbType.Text, 0, "c10", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c11", NpgsqlTypes.NpgsqlDbType.Text, 0, "c11", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c12", NpgsqlTypes.NpgsqlDbType.Text, 0, "c12", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c13", NpgsqlTypes.NpgsqlDbType.Text, 0, "c13", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c14", NpgsqlTypes.NpgsqlDbType.Text, 0, "c14", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c15", NpgsqlTypes.NpgsqlDbType.Text, 0, "c15", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c16", NpgsqlTypes.NpgsqlDbType.Text, 0, "c16", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c17", NpgsqlTypes.NpgsqlDbType.Text, 0, "c17", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c18", NpgsqlTypes.NpgsqlDbType.Text, 0, "c18", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c19", NpgsqlTypes.NpgsqlDbType.Text, 0, "c19", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c20", NpgsqlTypes.NpgsqlDbType.Text, 0, "c20", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c21", NpgsqlTypes.NpgsqlDbType.Text, 0, "c21", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c22", NpgsqlTypes.NpgsqlDbType.Text, 0, "c22", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c4_array", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4_array", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("time_stamp", NpgsqlTypes.NpgsqlDbType.TimestampTz, 0, "time_stamp", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("req_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "req_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("g_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "g_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("r_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "r_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                                    // update
                                    da.UpdateCommand = new NpgsqlCommand(
                                            "update t_seikyu set"
                                            + " c1 = :c1"
                                            + ", c2 = :c2"
                                            + ", c3 = :c3"
                                            + ", c4 = :c4"
                                            + ", c5 = :c5"
                                            + ", c6 = :c6"
                                            + ", c7 = :c7"
                                            + ", c8 = :c8"
                                            + ", c9 = :c9"
                                            + ", c10 = :c10"
                                            + ", c11 = :c11"
                                            + ", c12 = :c12"
                                            + ", c13 = :c13"
                                            + ", c14 = :c14"
                                            + ", c15 = :c15"
                                            + ", c16 = :c16"
                                            + ", c17 = :c17"
                                            + ", c18 = :c18"
                                            + ", c19 = :c19"
                                            + ", c20 = :c20"
                                            + ", c21 = :c21"
                                            + ", c22 = :c22"
                                            + ", c4_array = :c4_array"
                                            + ", time_stamp = :time_stamp"
                                            + ", id = :id"
                                            + ", req_id = :req_id"
                                            + ", s_id = :s_id"
                                            + ", g_id = :g_id"
                                            + ", o_id = :o_id"
                                            + " where r_id=:r_id;"
                                        , m_conn
                                        );
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c1", NpgsqlTypes.NpgsqlDbType.Text, 0, "c1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c2", NpgsqlTypes.NpgsqlDbType.Text, 0, "c2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c3", NpgsqlTypes.NpgsqlDbType.Text, 0, "c3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c5", NpgsqlTypes.NpgsqlDbType.Text, 0, "c5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c6", NpgsqlTypes.NpgsqlDbType.Text, 0, "c6", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c7", NpgsqlTypes.NpgsqlDbType.Text, 0, "c7", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c8", NpgsqlTypes.NpgsqlDbType.Text, 0, "c8", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c9", NpgsqlTypes.NpgsqlDbType.Text, 0, "c9", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c10", NpgsqlTypes.NpgsqlDbType.Text, 0, "c10", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c11", NpgsqlTypes.NpgsqlDbType.Text, 0, "c11", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c12", NpgsqlTypes.NpgsqlDbType.Text, 0, "c12", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c13", NpgsqlTypes.NpgsqlDbType.Text, 0, "c13", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c14", NpgsqlTypes.NpgsqlDbType.Text, 0, "c14", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c15", NpgsqlTypes.NpgsqlDbType.Text, 0, "c15", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c16", NpgsqlTypes.NpgsqlDbType.Text, 0, "c16", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c17", NpgsqlTypes.NpgsqlDbType.Text, 0, "c17", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c18", NpgsqlTypes.NpgsqlDbType.Text, 0, "c18", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c19", NpgsqlTypes.NpgsqlDbType.Text, 0, "c19", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c20", NpgsqlTypes.NpgsqlDbType.Text, 0, "c20", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c21", NpgsqlTypes.NpgsqlDbType.Text, 0, "c21", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c22", NpgsqlTypes.NpgsqlDbType.Text, 0, "c22", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4_array", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4_array", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("time_stamp", NpgsqlTypes.NpgsqlDbType.TimestampTz, 0, "time_stamp", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("req_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "req_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("g_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "g_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("r_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "r_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                                    // delete
                                    da.DeleteCommand = new NpgsqlCommand
                                    (
                                           "delete from t_seikyu"
                                        + " where"
                                        + " r_id=:r_id;"
                                        , m_conn
                                    );
                                    da.DeleteCommand.Parameters.Add(new NpgsqlParameter("r_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "r_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                                    // RowUpdate
                                    da.RowUpdated += new NpgsqlRowUpdatedEventHandler(SeikyuRowUpdated);

                                    if (_seikyu_ds.Tables["seikyu_ds"] != null)
                                        _seikyu_ds.Tables["seikyu_ds"].Clear();
                                    da.Fill(_seikyu_ds, "seikyu_ds");

                                    bindingSourceSeikyu.DataSource = _seikyu_ds;

                                    bindingNavigatorSeikyu.BindingSource = bindingSourceSeikyu;

                                    dataGridViewSeikyu.DataSource = bindingSourceSeikyu;

                                    dataGridViewSeikyu.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                                    break;
                            }
                            break;
                        // 支払方法
                        case 2:
                            switch (cmb_s_id_int)
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:
                                    da.SelectCommand = new NpgsqlCommand
                                    (
                                        "select"
                                        + " c1"
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
                                        + ", c23"
                                        + ", c24"
                                        + ", c25"
                                        + ", c26"
                                        + ", c27"
                                        + ", c28"
                                        + ", c29"
                                        + ", c30"
                                        + ", c31"
                                        + ", c32"
                                        + ", c33"
                                        + ", c34"
                                        + ", c35"
                                        + ", c36"
                                        + ", c37"
                                        + ", c38"
                                        + ", c39"
                                        + ", c40"
                                        + ", c41"
                                        + ", c42"
                                        + ", c43"
                                        + ", c44"
                                        + ", c45"
                                        + ", c46"
                                        + ", c47"
                                        + ", c48"
                                        + ", c49"
                                        + ", sh_id"
                                        + ", s_id"
                                        + ", g_id"
                                        + ", o_id"
                                        + ", p_id"
                                        + ", req_id"
                                        + ", time_stamp"
                                        + ", c4_array"
                                        + " from"
                                        + " t_shiharai_houhou"
                                        + " where time_stamp = (select max(time_stamp) from t_shiharai_houhou"
                                        + " where s_id::Integer = " + cmb_s_id_int
                                        + " and g_id::Integer = " + cmb_g_id_int
                                        + " and o_id::Integer = " + cmb_o_id_int
                                        //" where s_id::Integer = " + cmb_s_id_int + " and g_id::Integer = " + cmb_g_id_int
                                        + " and c4_array[1]::text || '/' || c4_array[2]::Text = case when length('" + cmb_tsuki_str + "')=1 then"
                                                        + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                                                        + "       when length('" + cmb_tsuki_str + "')=2 then"
                                                        + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                                                        + " end"
                                        + ");"
                                        , m_conn
                                    );

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

                                    // insert
                                    da.InsertCommand = new NpgsqlCommand(
                                    "insert into t_shiharai_houhou ("
                                                + " c1"
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
                                                + ", c23"
                                                + ", c24"
                                                + ", c25"
                                                + ", c26"
                                                + ", c27"
                                                + ", c28"
                                                + ", c29"
                                                + ", c30"
                                                + ", c31"
                                                + ", c32"
                                                + ", c33"
                                                + ", c34"
                                                + ", c35"
                                                + ", c36"
                                                + ", c37"
                                                + ", c38"
                                                + ", c39"
                                                + ", c40"
                                                + ", c41"
                                                + ", c42"
                                                + ", c43"
                                                + ", c44"
                                                + ", c45"
                                                + ", c46"
                                                + ", c47"
                                                + ", c48"
                                                + ", c49"
                                                + ", s_id"
                                                + ", g_id"
                                                + ", o_id"
                                                + ", p_id"
                                                + ", req_id"
                                                + ", c4_array"
                                                + " ) select"
                                                + " coalesce(:c1, '') c1"
                                                + ", coalesce(:c2, '') c2"
                                                + ", coalesce(:c3, '') c3"
                                                + ", coalesce(:c4, '') c4"
                                                + ", coalesce(:c5, '') c5"
                                                + ", coalesce(:c6, '') c6"
                                                + ", coalesce(:c7, '') c7"
                                                + ", coalesce(:c8, '') c8"
                                                + ", coalesce(:c9, '') c9"
                                                + ", coalesce(:c10, '') c10"
                                                + ", coalesce(:c11, '') c11"
                                                + ", coalesce(:c12, '') c12"
                                                + ", coalesce(:c13, '') c13"
                                                + ", coalesce(:c14, '') c14"
                                                + ", coalesce(:c15, '') c15"
                                                + ", coalesce(:c16, '') c16"
                                                + ", coalesce(:c17, '') c17"
                                                + ", coalesce(:c18, '') c18"
                                                + ", coalesce(:c19, '') c19"
                                                + ", coalesce(:c20, '') c20"
                                                + ", coalesce(:c21, '') c21"
                                                + ", coalesce(:c22, '') c22"
                                                + ", coalesce(:c23, '') c23"
                                                + ", coalesce(:c24, '') c24"
                                                + ", coalesce(:c25, '') c25"
                                                + ", coalesce(:c26, '') c26"
                                                + ", coalesce(:c27, '') c27"
                                                + ", coalesce(:c28, '') c28"
                                                + ", coalesce(:c29, '') c29"
                                                + ", coalesce(:c30, '') c30"
                                                + ", coalesce(:c31, '') c31"
                                                + ", coalesce(:c32, '') c32"
                                                + ", coalesce(:c33, '') c33"
                                                + ", coalesce(:c34, '') c34"
                                                + ", coalesce(:c35, '') c35"
                                                + ", coalesce(:c36, '') c36"
                                                + ", coalesce(:c37, '') c37"
                                                + ", coalesce(:c38, '') c38"
                                                + ", coalesce(:c39, '') c39"
                                                + ", coalesce(:c40, '') c40"
                                                + ", coalesce(:c41, '') c41"
                                                + ", coalesce(:c42, '') c42"
                                                + ", coalesce(:c43, '') c43"
                                                + ", coalesce(:c44, '') c44"
                                                + ", coalesce(:c45, '') c45"
                                                + ", coalesce(:c46, '') c46"
                                                + ", coalesce(:c47, '') c47"
                                                + ", coalesce(:c48, '') c48"
                                                + ", coalesce(:c49, '') c49"
                                                + ", :s_id"
                                                + ", :g_id"
                                                + ", :o_id"
                                                + ", :p_id"
                                                + ", :req_id"
                                                + ", case when length('" + cmb_tsuki_str + "')=1 then"
                                                + " string_to_array ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "', '/')"
                                                + "       when length('" + cmb_tsuki_str + "')=2 then"
                                                + " string_to_array ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "', '/')"
                                                + " end"
                                                + " from t_csv;"
                                                    , m_conn
                                                    );

                                    // update
                                    da.UpdateCommand = new NpgsqlCommand(
                                            "update t_shiharai_houhou set"
                                            + " c1 = :c1"
                                            + ", c2 = :c2"
                                            + ", c3 = :c3"
                                            + ", c4 = :c4"
                                            + ", c5 = :c5"
                                            + ", c6 = :c6"
                                            + ", c7 = :c7"
                                            + ", c8 = :c8"
                                            + ", c9 = :c9"
                                            + ", c10 = :c10"
                                            + ", c11 = :c11"
                                            + ", c12 = :c12"
                                            + ", c13 = :c13"
                                            + ", c14 = :c14"
                                            + ", c15 = :c15"
                                            + ", c16 = :c16"
                                            + ", c17 = :c17"
                                            + ", c18 = :c18"
                                            + ", c19 = :c19"
                                            + ", c20 = :c20"
                                            + ", c21 = :c21"
                                            + ", c22 = :c22"
                                            + ", c23 = :c23"
                                            + ", c24 = :c24"
                                            + ", c25 = :c25"
                                            + ", c26 = :c26"
                                            + ", c27 = :c27"
                                            + ", c28 = :c28"
                                            + ", c29 = :c29"
                                            + ", c30 = :c30"
                                            + ", c31 = :c31"
                                            + ", c32 = :c32"
                                            + ", c33 = :c33"
                                            + ", c34 = :c34"
                                            + ", c35 = :c35"
                                            + ", c36 = :c36"
                                            + ", c37 = :c37"
                                            + ", c38 = :c38"
                                            + ", c39 = :c39"
                                            + ", c40 = :c40"
                                            + ", c41 = :c41"
                                            + ", c42 = :c42"
                                            + ", c43 = :c43"
                                            + ", c44 = :c44"
                                            + ", c45 = :c45"
                                            + ", c46 = :c46"
                                            + ", c47 = :c47"
                                            + ", c48 = :c48"
                                            + ", c49 = :c49"
                                            + ", s_id = :s_id"
                                            + ", g_id = :g_id"
                                            + ", o_id = :o_id"
                                            + ", p_id = :p_id"
                                            + ", req_id = :req_id"
                                            + ", time_stamp = :time_stamp"
                                            + ", c4_array = :c4_array"
                                            + " where sh_id=:sh_id;"
                                        , m_conn
                                        );
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c1", NpgsqlTypes.NpgsqlDbType.Text, 0, "c1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c2", NpgsqlTypes.NpgsqlDbType.Text, 0, "c2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c3", NpgsqlTypes.NpgsqlDbType.Text, 0, "c3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c5", NpgsqlTypes.NpgsqlDbType.Text, 0, "c5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c6", NpgsqlTypes.NpgsqlDbType.Text, 0, "c6", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c7", NpgsqlTypes.NpgsqlDbType.Text, 0, "c7", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c8", NpgsqlTypes.NpgsqlDbType.Text, 0, "c8", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c9", NpgsqlTypes.NpgsqlDbType.Text, 0, "c9", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c10", NpgsqlTypes.NpgsqlDbType.Text, 0, "c10", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c11", NpgsqlTypes.NpgsqlDbType.Text, 0, "c11", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c12", NpgsqlTypes.NpgsqlDbType.Text, 0, "c12", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c13", NpgsqlTypes.NpgsqlDbType.Text, 0, "c13", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c14", NpgsqlTypes.NpgsqlDbType.Text, 0, "c14", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c15", NpgsqlTypes.NpgsqlDbType.Text, 0, "c15", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c16", NpgsqlTypes.NpgsqlDbType.Text, 0, "c16", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c17", NpgsqlTypes.NpgsqlDbType.Text, 0, "c17", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c18", NpgsqlTypes.NpgsqlDbType.Text, 0, "c18", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c19", NpgsqlTypes.NpgsqlDbType.Text, 0, "c19", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c20", NpgsqlTypes.NpgsqlDbType.Text, 0, "c20", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c21", NpgsqlTypes.NpgsqlDbType.Text, 0, "c21", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c22", NpgsqlTypes.NpgsqlDbType.Text, 0, "c22", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c23", NpgsqlTypes.NpgsqlDbType.Text, 0, "c23", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c24", NpgsqlTypes.NpgsqlDbType.Text, 0, "c24", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c25", NpgsqlTypes.NpgsqlDbType.Text, 0, "c25", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c26", NpgsqlTypes.NpgsqlDbType.Text, 0, "c26", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c27", NpgsqlTypes.NpgsqlDbType.Text, 0, "c27", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c28", NpgsqlTypes.NpgsqlDbType.Text, 0, "c28", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c29", NpgsqlTypes.NpgsqlDbType.Text, 0, "c29", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c30", NpgsqlTypes.NpgsqlDbType.Text, 0, "c30", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c31", NpgsqlTypes.NpgsqlDbType.Text, 0, "c31", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c32", NpgsqlTypes.NpgsqlDbType.Text, 0, "c32", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c33", NpgsqlTypes.NpgsqlDbType.Text, 0, "c33", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c34", NpgsqlTypes.NpgsqlDbType.Text, 0, "c34", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c35", NpgsqlTypes.NpgsqlDbType.Text, 0, "c35", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c36", NpgsqlTypes.NpgsqlDbType.Text, 0, "c36", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c37", NpgsqlTypes.NpgsqlDbType.Text, 0, "c37", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c38", NpgsqlTypes.NpgsqlDbType.Text, 0, "c38", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c39", NpgsqlTypes.NpgsqlDbType.Text, 0, "c39", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c40", NpgsqlTypes.NpgsqlDbType.Text, 0, "c40", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c41", NpgsqlTypes.NpgsqlDbType.Text, 0, "c41", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c42", NpgsqlTypes.NpgsqlDbType.Text, 0, "c42", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c43", NpgsqlTypes.NpgsqlDbType.Text, 0, "c43", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c44", NpgsqlTypes.NpgsqlDbType.Text, 0, "c44", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c45", NpgsqlTypes.NpgsqlDbType.Text, 0, "c45", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c46", NpgsqlTypes.NpgsqlDbType.Text, 0, "c46", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c47", NpgsqlTypes.NpgsqlDbType.Text, 0, "c47", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c48", NpgsqlTypes.NpgsqlDbType.Text, 0, "c48", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c49", NpgsqlTypes.NpgsqlDbType.Text, 0, "c49", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("time_stamp", NpgsqlTypes.NpgsqlDbType.TimestampTz, 0, "time_stamp", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4_array", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4_array", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("g_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "g_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("p_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "p_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("req_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "req_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("sh_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "sh_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                                    // delete
                                    da.DeleteCommand = new NpgsqlCommand
                                    (
                                           "delete from t_shiharai_houhou"
                                        + " where"
                                        + " sh_id=:sh_id;"
                                        , m_conn
                                    );
                                    da.DeleteCommand.Parameters.Add(new NpgsqlParameter("sh_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "sh_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                                    // RowUpdate
                                    da.RowUpdated += new NpgsqlRowUpdatedEventHandler(SeikyuRowUpdated);

                                    if (_shiharai_houhou_ds.Tables["shiharai_houhou_ds"] != null)
                                        _shiharai_houhou_ds.Tables["shiharai_houhou_ds"].Clear();
                                    da.Fill(_shiharai_houhou_ds, "shiharai_houhou_ds");

                                    bindingSourceShiharai_houhou.DataSource = _shiharai_houhou_ds;

                                    bindingNavigatorShiharai_houhou.BindingSource = bindingSourceShiharai_houhou;

                                    dataGridViewShiharai_houhou.DataSource = bindingSourceShiharai_houhou;

                                    dataGridViewShiharai_houhou.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                                    break;
                            }
                            break;
                        // 親族関係
                        case 3:
                            switch (cmb_s_id_int)
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:
                                    da.SelectCommand = new NpgsqlCommand
                                    (
                                        "select"
                                        + " c1"
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
                                        + ", c23"
                                        + ", c24"
                                        + ", c25"
                                        + ", c26"
                                        + ", c27"
                                        + ", c28"
                                        + ", c29"
                                        + ", c30"
                                        + ", c31"
                                        + ", c32"
                                        + ", c33"
                                        + ", c34"
                                        + ", c35"
                                        + ", c36"
                                        + ", c37"
                                        + ", c38"
                                        + ", c39"
                                        + ", c40"
                                        + ", c41"
                                        + ", c42"
                                        + ", c43"
                                        + ", c44"
                                        + ", c45"
                                        + ", c46"
                                        + ", c47"
                                        + ", c48"
                                        + ", c49"
                                        + ", c50"
                                        + ", c51"
                                        + ", c52"
                                        + ", c53"
                                        + ", c54"
                                        + ", c55"
                                        + ", c56"
                                        + ", c57"
                                        + ", c58"
                                        + ", sk_id"
                                        + ", s_id"
                                        + ", g_id"
                                        + ", o_id"
                                        + ", p_id"
                                        + ", req_id"
                                        + ", time_stamp"
                                        + ", c4_array"
                                        + " from"
                                        + " t_shinzoku_kankei"
                                        + " where time_stamp = (select max(time_stamp) from t_shinzoku_kankei"
                                        //+ " where s_id::Integer = " + cmb_s_id_int + " and g_id::Integer = " + cmb_g_id_int
                                        + " where s_id::Integer = " + cmb_s_id_int
                                        + " and g_id::Integer = " + cmb_g_id_int
                                        + " and o_id::Integer = " + cmb_o_id_int
                                        + " and c4_array[1]::text || '/' || c4_array[2]::Text = case when length('" + cmb_tsuki_str + "')=1 then"
                                                        + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                                                        + "       when length('" + cmb_tsuki_str + "')=2 then"
                                                        + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                                                        + " end"
                                        + ");"
                                        , m_conn
                                    );

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

                                    // insert
                                    da.InsertCommand = new NpgsqlCommand(
                                    "insert into t_shinzoku_kankei ("
                                                + " c1"
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
                                                + ", c23"
                                                + ", c24"
                                                + ", c25"
                                                + ", c26"
                                                + ", c27"
                                                + ", c28"
                                                + ", c29"
                                                + ", c30"
                                                + ", c31"
                                                + ", c32"
                                                + ", c33"
                                                + ", c34"
                                                + ", c35"
                                                + ", c36"
                                                + ", c37"
                                                + ", c38"
                                                + ", c39"
                                                + ", c40"
                                                + ", c41"
                                                + ", c42"
                                                + ", c43"
                                                + ", c44"
                                                + ", c45"
                                                + ", c46"
                                                + ", c47"
                                                + ", c48"
                                                + ", c49"
                                                + ", c50"
                                                + ", c51"
                                                + ", c52"
                                                + ", c53"
                                                + ", c54"
                                                + ", c55"
                                                + ", c56"
                                                + ", c57"
                                                + ", c58"
                                                + ", s_id"
                                                + ", g_id"
                                                + ", o_id"
                                                + ", p_id"
                                                + ", req_id"
                                                + ", c4_array"
                                                + " ) select"
                                                + " coalesce(:c1, '') c1"
                                                + ", coalesce(:c2, '') c2"
                                                + ", coalesce(:c3, '') c3"
                                                + ", coalesce(:c4, '') c4"
                                                + ", coalesce(:c5, '') c5"
                                                + ", coalesce(:c6, '') c6"
                                                + ", coalesce(:c7, '') c7"
                                                + ", coalesce(:c8, '') c8"
                                                + ", coalesce(:c9, '') c9"
                                                + ", coalesce(:c10, '') c10"
                                                + ", coalesce(:c11, '') c11"
                                                + ", coalesce(:c12, '') c12"
                                                + ", coalesce(:c13, '') c13"
                                                + ", coalesce(:c14, '') c14"
                                                + ", coalesce(:c15, '') c15"
                                                + ", coalesce(:c16, '') c16"
                                                + ", coalesce(:c17, '') c17"
                                                + ", coalesce(:c18, '') c18"
                                                + ", coalesce(:c19, '') c19"
                                                + ", coalesce(:c20, '') c20"
                                                + ", coalesce(:c21, '') c21"
                                                + ", coalesce(:c22, '') c22"
                                                + ", coalesce(:c23, '') c23"
                                                + ", coalesce(:c24, '') c24"
                                                + ", coalesce(:c25, '') c25"
                                                + ", coalesce(:c26, '') c26"
                                                + ", coalesce(:c27, '') c27"
                                                + ", coalesce(:c28, '') c28"
                                                + ", coalesce(:c29, '') c29"
                                                + ", coalesce(:c30, '') c30"
                                                + ", coalesce(:c31, '') c31"
                                                + ", coalesce(:c32, '') c32"
                                                + ", coalesce(:c33, '') c33"
                                                + ", coalesce(:c34, '') c34"
                                                + ", coalesce(:c35, '') c35"
                                                + ", coalesce(:c36, '') c36"
                                                + ", coalesce(:c37, '') c37"
                                                + ", coalesce(:c38, '') c38"
                                                + ", coalesce(:c39, '') c39"
                                                + ", coalesce(:c40, '') c40"
                                                + ", coalesce(:c41, '') c41"
                                                + ", coalesce(:c42, '') c42"
                                                + ", coalesce(:c43, '') c43"
                                                + ", coalesce(:c44, '') c44"
                                                + ", coalesce(:c45, '') c45"
                                                + ", coalesce(:c46, '') c46"
                                                + ", coalesce(:c47, '') c47"
                                                + ", coalesce(:c48, '') c48"
                                                + ", coalesce(:c49, '') c49"
                                                + ", coalesce(:c50, '') c50"
                                                + ", coalesce(:c51, '') c51"
                                                + ", coalesce(:c52, '') c52"
                                                + ", coalesce(:c53, '') c53"
                                                + ", coalesce(:c54, '') c54"
                                                + ", coalesce(:c55, '') c55"
                                                + ", coalesce(:c56, '') c56"
                                                + ", coalesce(:c57, '') c57"
                                                + ", coalesce(:c58, '') c58"
                                                + ", :s_id"
                                                + ", :g_id"
                                                + ", :o_id"
                                                + ", :p_id"
                                                + ", :req_id"
                                                + ", case when length('" + cmb_tsuki_str + "')=1 then"
                                                + " string_to_array ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "', '/')"
                                                + "       when length('" + cmb_tsuki_str + "')=2 then"
                                                + " string_to_array ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "', '/')"
                                                + " end"
                                                + " from t_csv;"
                                                    , m_conn
                                                    );
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c1", NpgsqlTypes.NpgsqlDbType.Text, 0, "c1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c2", NpgsqlTypes.NpgsqlDbType.Text, 0, "c2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c3", NpgsqlTypes.NpgsqlDbType.Text, 0, "c3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c4", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c5", NpgsqlTypes.NpgsqlDbType.Text, 0, "c5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c6", NpgsqlTypes.NpgsqlDbType.Text, 0, "c6", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c7", NpgsqlTypes.NpgsqlDbType.Text, 0, "c7", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c8", NpgsqlTypes.NpgsqlDbType.Text, 0, "c8", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c9", NpgsqlTypes.NpgsqlDbType.Text, 0, "c9", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c10", NpgsqlTypes.NpgsqlDbType.Text, 0, "c10", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c11", NpgsqlTypes.NpgsqlDbType.Text, 0, "c11", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c12", NpgsqlTypes.NpgsqlDbType.Text, 0, "c12", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c13", NpgsqlTypes.NpgsqlDbType.Text, 0, "c13", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c14", NpgsqlTypes.NpgsqlDbType.Text, 0, "c14", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c15", NpgsqlTypes.NpgsqlDbType.Text, 0, "c15", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c16", NpgsqlTypes.NpgsqlDbType.Text, 0, "c16", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c17", NpgsqlTypes.NpgsqlDbType.Text, 0, "c17", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c18", NpgsqlTypes.NpgsqlDbType.Text, 0, "c18", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c19", NpgsqlTypes.NpgsqlDbType.Text, 0, "c19", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c20", NpgsqlTypes.NpgsqlDbType.Text, 0, "c20", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c21", NpgsqlTypes.NpgsqlDbType.Text, 0, "c21", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c22", NpgsqlTypes.NpgsqlDbType.Text, 0, "c22", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c23", NpgsqlTypes.NpgsqlDbType.Text, 0, "c23", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c24", NpgsqlTypes.NpgsqlDbType.Text, 0, "c24", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c25", NpgsqlTypes.NpgsqlDbType.Text, 0, "c25", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c26", NpgsqlTypes.NpgsqlDbType.Text, 0, "c26", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c27", NpgsqlTypes.NpgsqlDbType.Text, 0, "c27", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c28", NpgsqlTypes.NpgsqlDbType.Text, 0, "c28", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c29", NpgsqlTypes.NpgsqlDbType.Text, 0, "c29", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c30", NpgsqlTypes.NpgsqlDbType.Text, 0, "c30", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c31", NpgsqlTypes.NpgsqlDbType.Text, 0, "c31", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c32", NpgsqlTypes.NpgsqlDbType.Text, 0, "c32", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c33", NpgsqlTypes.NpgsqlDbType.Text, 0, "c33", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c34", NpgsqlTypes.NpgsqlDbType.Text, 0, "c34", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c35", NpgsqlTypes.NpgsqlDbType.Text, 0, "c35", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c36", NpgsqlTypes.NpgsqlDbType.Text, 0, "c36", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c37", NpgsqlTypes.NpgsqlDbType.Text, 0, "c37", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c38", NpgsqlTypes.NpgsqlDbType.Text, 0, "c38", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c39", NpgsqlTypes.NpgsqlDbType.Text, 0, "c39", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c40", NpgsqlTypes.NpgsqlDbType.Text, 0, "c40", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c41", NpgsqlTypes.NpgsqlDbType.Text, 0, "c41", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c42", NpgsqlTypes.NpgsqlDbType.Text, 0, "c42", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c43", NpgsqlTypes.NpgsqlDbType.Text, 0, "c43", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c44", NpgsqlTypes.NpgsqlDbType.Text, 0, "c44", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c45", NpgsqlTypes.NpgsqlDbType.Text, 0, "c45", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c46", NpgsqlTypes.NpgsqlDbType.Text, 0, "c46", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c47", NpgsqlTypes.NpgsqlDbType.Text, 0, "c47", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c48", NpgsqlTypes.NpgsqlDbType.Text, 0, "c48", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c49", NpgsqlTypes.NpgsqlDbType.Text, 0, "c49", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c50", NpgsqlTypes.NpgsqlDbType.Text, 0, "c50", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c51", NpgsqlTypes.NpgsqlDbType.Text, 0, "c51", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c52", NpgsqlTypes.NpgsqlDbType.Text, 0, "c52", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c53", NpgsqlTypes.NpgsqlDbType.Text, 0, "c53", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c54", NpgsqlTypes.NpgsqlDbType.Text, 0, "c54", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c55", NpgsqlTypes.NpgsqlDbType.Text, 0, "c55", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c56", NpgsqlTypes.NpgsqlDbType.Text, 0, "c56", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c57", NpgsqlTypes.NpgsqlDbType.Text, 0, "c57", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c58", NpgsqlTypes.NpgsqlDbType.Text, 0, "c58", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("time_stamp", NpgsqlTypes.NpgsqlDbType.TimestampTz, 0, "time_stamp", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("c4_array", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4_array", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("g_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "g_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("p_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "p_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("req_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "req_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.InsertCommand.Parameters.Add(new NpgsqlParameter("sk_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "sk_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                                    // update
                                    da.UpdateCommand = new NpgsqlCommand(
                                        "update t_shinzoku_kankei set"
                                        + " c1 = :c1"
                                        + ", c2 = :c2"
                                        + ", c3 = :c3"
                                        + ", c4 = :c4"
                                        + ", c5 = :c5"
                                        + ", c6 = :c6"
                                        + ", c7 = :c7"
                                        + ", c8 = :c8"
                                        + ", c9 = :c9"
                                        + ", c10 = :c10"
                                        + ", c11 = :c11"
                                        + ", c12 = :c12"
                                        + ", c13 = :c13"
                                        + ", c14 = :c14"
                                        + ", c15 = :c15"
                                        + ", c16 = :c16"
                                        + ", c17 = :c17"
                                        + ", c18 = :c18"
                                        + ", c19 = :c19"
                                        + ", c20 = :c20"
                                        + ", c21 = :c21"
                                        + ", c22 = :c22"
                                        + ", c23 = :c23"
                                        + ", c24 = :c24"
                                        + ", c25 = :c25"
                                        + ", c26 = :c26"
                                        + ", c27 = :c27"
                                        + ", c28 = :c28"
                                        + ", c29 = :c29"
                                        + ", c30 = :c30"
                                        + ", c31 = :c31"
                                        + ", c32 = :c32"
                                        + ", c33 = :c33"
                                        + ", c34 = :c34"
                                        + ", c35 = :c35"
                                        + ", c36 = :c36"
                                        + ", c37 = :c37"
                                        + ", c38 = :c38"
                                        + ", c39 = :c39"
                                        + ", c40 = :c40"
                                        + ", c41 = :c41"
                                        + ", c42 = :c42"
                                        + ", c43 = :c43"
                                        + ", c44 = :c44"
                                        + ", c45 = :c45"
                                        + ", c46 = :c46"
                                        + ", c47 = :c47"
                                        + ", c48 = :c48"
                                        + ", c49 = :c49"
                                        + ", c50 = :c50"
                                        + ", c51 = :c51"
                                        + ", c52 = :c52"
                                        + ", c53 = :c53"
                                        + ", c54 = :c54"
                                        + ", c55 = :c55"
                                        + ", c56 = :c56"
                                        + ", c57 = :c57"
                                        + ", c58 = :c58"
                                        + ", s_id = :s_id"
                                        + ", g_id = :g_id"
                                        + ", o_id = :o_id"
                                        + ", p_id = :p_id"
                                        + ", req_id = :req_id"
                                        + ", time_stamp = :time_stamp"
                                        + ", c4_array = :c4_array"
                                        + " where sk_id=:sk_id;"
                                        , m_conn
                                        );
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c1", NpgsqlTypes.NpgsqlDbType.Text, 0, "c1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c2", NpgsqlTypes.NpgsqlDbType.Text, 0, "c2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c3", NpgsqlTypes.NpgsqlDbType.Text, 0, "c3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c5", NpgsqlTypes.NpgsqlDbType.Text, 0, "c5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c6", NpgsqlTypes.NpgsqlDbType.Text, 0, "c6", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c7", NpgsqlTypes.NpgsqlDbType.Text, 0, "c7", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c8", NpgsqlTypes.NpgsqlDbType.Text, 0, "c8", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c9", NpgsqlTypes.NpgsqlDbType.Text, 0, "c9", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c10", NpgsqlTypes.NpgsqlDbType.Text, 0, "c10", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c11", NpgsqlTypes.NpgsqlDbType.Text, 0, "c11", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c12", NpgsqlTypes.NpgsqlDbType.Text, 0, "c12", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c13", NpgsqlTypes.NpgsqlDbType.Text, 0, "c13", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c14", NpgsqlTypes.NpgsqlDbType.Text, 0, "c14", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c15", NpgsqlTypes.NpgsqlDbType.Text, 0, "c15", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c16", NpgsqlTypes.NpgsqlDbType.Text, 0, "c16", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c17", NpgsqlTypes.NpgsqlDbType.Text, 0, "c17", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c18", NpgsqlTypes.NpgsqlDbType.Text, 0, "c18", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c19", NpgsqlTypes.NpgsqlDbType.Text, 0, "c19", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c20", NpgsqlTypes.NpgsqlDbType.Text, 0, "c20", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c21", NpgsqlTypes.NpgsqlDbType.Text, 0, "c21", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c22", NpgsqlTypes.NpgsqlDbType.Text, 0, "c22", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c23", NpgsqlTypes.NpgsqlDbType.Text, 0, "c23", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c24", NpgsqlTypes.NpgsqlDbType.Text, 0, "c24", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c25", NpgsqlTypes.NpgsqlDbType.Text, 0, "c25", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c26", NpgsqlTypes.NpgsqlDbType.Text, 0, "c26", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c27", NpgsqlTypes.NpgsqlDbType.Text, 0, "c27", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c28", NpgsqlTypes.NpgsqlDbType.Text, 0, "c28", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c29", NpgsqlTypes.NpgsqlDbType.Text, 0, "c29", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c30", NpgsqlTypes.NpgsqlDbType.Text, 0, "c30", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c31", NpgsqlTypes.NpgsqlDbType.Text, 0, "c31", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c32", NpgsqlTypes.NpgsqlDbType.Text, 0, "c32", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c33", NpgsqlTypes.NpgsqlDbType.Text, 0, "c33", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c34", NpgsqlTypes.NpgsqlDbType.Text, 0, "c34", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c35", NpgsqlTypes.NpgsqlDbType.Text, 0, "c35", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c36", NpgsqlTypes.NpgsqlDbType.Text, 0, "c36", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c37", NpgsqlTypes.NpgsqlDbType.Text, 0, "c37", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c38", NpgsqlTypes.NpgsqlDbType.Text, 0, "c38", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c39", NpgsqlTypes.NpgsqlDbType.Text, 0, "c39", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c40", NpgsqlTypes.NpgsqlDbType.Text, 0, "c40", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c41", NpgsqlTypes.NpgsqlDbType.Text, 0, "c41", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c42", NpgsqlTypes.NpgsqlDbType.Text, 0, "c42", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c43", NpgsqlTypes.NpgsqlDbType.Text, 0, "c43", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c44", NpgsqlTypes.NpgsqlDbType.Text, 0, "c44", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c45", NpgsqlTypes.NpgsqlDbType.Text, 0, "c45", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c46", NpgsqlTypes.NpgsqlDbType.Text, 0, "c46", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c47", NpgsqlTypes.NpgsqlDbType.Text, 0, "c47", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c48", NpgsqlTypes.NpgsqlDbType.Text, 0, "c48", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c49", NpgsqlTypes.NpgsqlDbType.Text, 0, "c49", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c50", NpgsqlTypes.NpgsqlDbType.Text, 0, "c50", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c51", NpgsqlTypes.NpgsqlDbType.Text, 0, "c51", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c52", NpgsqlTypes.NpgsqlDbType.Text, 0, "c52", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c53", NpgsqlTypes.NpgsqlDbType.Text, 0, "c53", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c54", NpgsqlTypes.NpgsqlDbType.Text, 0, "c54", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c55", NpgsqlTypes.NpgsqlDbType.Text, 0, "c55", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c56", NpgsqlTypes.NpgsqlDbType.Text, 0, "c56", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c57", NpgsqlTypes.NpgsqlDbType.Text, 0, "c57", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c58", NpgsqlTypes.NpgsqlDbType.Text, 0, "c58", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("time_stamp", NpgsqlTypes.NpgsqlDbType.TimestampTz, 0, "time_stamp", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4_array", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4_array", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("g_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "g_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("p_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "p_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("req_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "req_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("sk_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "sk_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                                    // delete
                                    da.DeleteCommand = new NpgsqlCommand
                                    (
                                           "delete from t_shinzoku_kankei"
                                        + " where"
                                        + " sk_id=:sk_id;"
                                        , m_conn
                                    );
                                    da.DeleteCommand.Parameters.Add(new NpgsqlParameter("sk_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "sk_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                                    // RowUpdate
                                    da.RowUpdated += new NpgsqlRowUpdatedEventHandler(SeikyuRowUpdated);

                                    if (_shinzoku_kankei_ds.Tables["shinzoku_kankei_ds"] != null)
                                        _shinzoku_kankei_ds.Tables["shinzoku_kankei_ds"].Clear();
                                    da.Fill(_shinzoku_kankei_ds, "shinzoku_kankei_ds");

                                    bindingSourceSeikyu.DataSource = _shinzoku_kankei_ds;

                                    bindingNavigatorSeikyu.BindingSource = bindingSourceSeikyu;

                                    dataGridViewSeikyu.DataSource = bindingSourceSeikyu;

                                    dataGridViewSeikyu.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                                    break;
                            }
                            break;
                    }

                }
                else if (btn == System.Windows.Forms.DialogResult.Cancel)
                {
                    MessageBox.Show("キャンセルされました");
                    m_conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //m_conn.Close();
            }

        }

        private void dataGridViewSeikyu_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e == null) return;

            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;

            if (e.Value == null || e.Value.ToString() == "") return;

            switch (this.dataGridViewSeikyu.Columns[e.ColumnIndex].Name)
            {
                case "results":
                    string input = (string)dataGridViewSeikyu[2, e.RowIndex].Value.ToString();
                    Console.WriteLine("input = " + input);

                    DateTime value;
                    if (DateTime.TryParseExact(
                        input, "mm:ss.f",
                        null, System.Globalization.DateTimeStyles.None, out value))
                    {
                        e.Value = value;
                        e.ParsingApplied = true;
                    }
                    break;
            }

        }

        private void dataGridViewSeikyu_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
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

        private void dataGridViewSeikyu_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void Form_Seikyu_FormClosing(object sender, FormClosingEventArgs e)
        {
            int update_count = 0;
            switch (cmb_g_id_int)
            {
                case 1:
                    switch (cmb_s_id_int)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                            update_count += da.Update(_seikyu_ds.Tables["seikyu_ds"].Select(null, null, DataViewRowState.Deleted));
                            update_count += da.Update(_seikyu_ds.Tables["seikyu_ds"].Select(null, null, DataViewRowState.ModifiedCurrent));
                            update_count += da.Update(_seikyu_ds.Tables["seikyu_ds"].Select(null, null, DataViewRowState.Added));
                            break;
                    }
                    break;
                case 2:
                    switch (cmb_s_id_int)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                            update_count += da.Update(_shiharai_houhou_ds.Tables["shiharai_houhou_ds"].Select(null, null, DataViewRowState.Deleted));
                            update_count += da.Update(_shiharai_houhou_ds.Tables["shiharai_houhou_ds"].Select(null, null, DataViewRowState.ModifiedCurrent));
                            update_count += da.Update(_shiharai_houhou_ds.Tables["shiharai_houhou_ds"].Select(null, null, DataViewRowState.Added));
                            break;
                    }
                    break;
                case 3:
                    switch (cmb_s_id_int)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                            update_count += da.Update(_shinzoku_kankei_ds.Tables["shinzoku_kankei_ds"].Select(null, null, DataViewRowState.Deleted));
                            update_count += da.Update(_shinzoku_kankei_ds.Tables["shinzoku_kankei_ds"].Select(null, null, DataViewRowState.ModifiedCurrent));
                            update_count += da.Update(_shinzoku_kankei_ds.Tables["shinzoku_kankei_ds"].Select(null, null, DataViewRowState.Added));
                            break;
                    }
                    break;
            }
            if (update_count > 0)    // 1件以上更新されていれば確認画面を表示
            {
                if (MessageBox.Show("データが保存されていません。\n本当に閉じますか？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void seikyu_ds_OvsToolStripButton_Click(object sender, EventArgs e)
        {
            int update_count = 0;
            switch (cmb_g_id_int)
            {
                case 1:
                    switch (cmb_s_id_int)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                            try
                            {
                                //update_count += da.Update(_seikyu_ds.Tables["seikyu_ds"]);
                                update_count += da.Update(_seikyu_ds.Tables["seikyu_ds"].Select(null, null, DataViewRowState.Deleted));
                                update_count += da.Update(_seikyu_ds.Tables["seikyu_ds"].Select(null, null, DataViewRowState.ModifiedCurrent));
                                update_count += da.Update(_seikyu_ds.Tables["seikyu_ds"].Select(null, null, DataViewRowState.Added));
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("データの保存に失敗しました。\n\n[内容]\n" + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            MessageBox.Show(update_count.ToString() + "件、保存しました。", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                    }
                    break;
            }
        }

        private void shiharai_houhou_ds_OvsToolStripButton_Click(object sender, EventArgs e)
        {
            int update_count = 0;
            switch (cmb_g_id_int)
            {
                case 2:
                    switch (cmb_s_id_int)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                            try
                            {
                                //update_count += da.Update(_shiharai_houhou_ds.Tables["shiharai_houhou_ds"]);
                                update_count += da.Update(_shiharai_houhou_ds.Tables["shiharai_houhou_ds"].Select(null, null, DataViewRowState.Deleted));
                                update_count += da.Update(_shiharai_houhou_ds.Tables["shiharai_houhou_ds"].Select(null, null, DataViewRowState.ModifiedCurrent));
                                update_count += da.Update(_shiharai_houhou_ds.Tables["shiharai_houhou_ds"].Select(null, null, DataViewRowState.Added));
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("データの保存に失敗しました。\n\n[内容]\n" + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            MessageBox.Show(update_count.ToString() + "件、保存しました。", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                    }
                    break;
            }
        }

        private void shinzoku_kankei_ds_OvsToolStripButton_Click(object sender, EventArgs e)
        {
            int update_count = 0;
            switch (cmb_g_id_int)
            {
                case 3:
                    switch (cmb_s_id_int)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:

                            try
                            {
                                //update_count += da.Update(_shinzoku_kankei_ds.Tables["shinzoku_kankei_ds"]);
                                update_count += da.Update(_shinzoku_kankei_ds.Tables["shinzoku_kankei_ds"].Select(null, null, DataViewRowState.Deleted));
                                update_count += da.Update(_shinzoku_kankei_ds.Tables["shinzoku_kankei_ds"].Select(null, null, DataViewRowState.ModifiedCurrent));
                                update_count += da.Update(_shinzoku_kankei_ds.Tables["shinzoku_kankei_ds"].Select(null, null, DataViewRowState.Added));
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("データの保存に失敗しました。\n\n[内容]\n" + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            MessageBox.Show(update_count.ToString() + "件、保存しました。", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                    }
                    break;
            }
        }

        private void cmb_s_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_s_id_int = cmb_s_id.SelectedIndex + 1;
            Console.WriteLine("cmb_s_id_int = " + cmb_s_id_int);


            cmb_s_id_str = cmb_s_id.Text;
            Console.WriteLine("cmb_s_id_str = " + cmb_s_id_str);
            textBox1.Text = cmb_s_id_str;


            switch (cmb_g_id_int)
            {
                case 1:
                    switch (cmb_s_id_int)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:

                            tblStr = " t_seikyu";
                            Console.WriteLine("tblStr = " + tblStr);
                            dataGridViewSeikyu.Columns[0].HeaderText = "利用者番号";
                            dataGridViewSeikyu.Columns[1].HeaderText = "要介護度";
                            dataGridViewSeikyu.Columns[2].HeaderText = "利用者名";
                            dataGridViewSeikyu.Columns[3].HeaderText = "提供月";
                            dataGridViewSeikyu.Columns[4].HeaderText = "合計額";
                            dataGridViewSeikyu.Columns[5].HeaderText = "サービス費（保険請求）";
                            dataGridViewSeikyu.Columns[6].HeaderText = "サービス費（公費請求）";
                            dataGridViewSeikyu.Columns[7].HeaderText = "食費（保険請求）";
                            dataGridViewSeikyu.Columns[8].HeaderText = "食費（公費請求）";
                            dataGridViewSeikyu.Columns[9].HeaderText = "居住費（保険請求）";
                            dataGridViewSeikyu.Columns[10].HeaderText = "居住費（公費請求）";
                            dataGridViewSeikyu.Columns[11].HeaderText = "介護請求合計額";
                            dataGridViewSeikyu.Columns[12].HeaderText = "利用者負担額";
                            dataGridViewSeikyu.Columns[13].HeaderText = "自費負担額";
                            dataGridViewSeikyu.Columns[14].HeaderText = "食事負担額";
                            dataGridViewSeikyu.Columns[15].HeaderText = "室料負担額";
                            dataGridViewSeikyu.Columns[16].HeaderText = "特定公費本人支払";
                            dataGridViewSeikyu.Columns[17].HeaderText = "高額介護超過額";
                            dataGridViewSeikyu.Columns[18].HeaderText = "その他実費";
                            dataGridViewSeikyu.Columns[19].HeaderText = "減免額";
                            dataGridViewSeikyu.Columns[20].HeaderText = "過入金";
                            dataGridViewSeikyu.Columns[21].HeaderText = "利用料請求合計額";
                            dataGridViewSeikyu.Columns[21].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("ja-JP");
                            dataGridViewSeikyu.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                            for (int i = 0; i < dataGridViewSeikyu.Columns.Count; i++)
                            {
                                if (i < 1 || i > 3)
                                {
                                    dataGridViewSeikyu.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    dataGridViewSeikyu.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    dataGridViewSeikyu.Columns[i].DefaultCellStyle.Format = "#,0";
                                }
                                else
                                {
                                    dataGridViewSeikyu.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    dataGridViewSeikyu.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                                }
                            }

                            break;
                    }
                    break;
                case 2:
                    switch (cmb_s_id_int)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:

                            tblStr = "t_shiharai_houhou";
                            Console.WriteLine("tblStr = " + tblStr);
                            dataGridViewShiharai_houhou.Columns[0].HeaderText = "法人名";
                            dataGridViewShiharai_houhou.Columns[1].HeaderText = "施設名";
                            dataGridViewShiharai_houhou.Columns[2].HeaderText = "事業所番号";
                            dataGridViewShiharai_houhou.Columns[3].HeaderText = "事業所名";
                            dataGridViewShiharai_houhou.Columns[4].HeaderText = "利用者番号";
                            dataGridViewShiharai_houhou.Columns[5].HeaderText = "利用者名";
                            dataGridViewShiharai_houhou.Columns[6].HeaderText = "支払方法";
                            dataGridViewShiharai_houhou.Columns[7].HeaderText = "引落口座";
                            dataGridViewShiharai_houhou.Columns[8].HeaderText = "引落金融機関銀行コード";
                            dataGridViewShiharai_houhou.Columns[9].HeaderText = "引落金融機関銀行名（フリガナ）";
                            dataGridViewShiharai_houhou.Columns[10].HeaderText = "引落金融機関銀行名";
                            dataGridViewShiharai_houhou.Columns[11].HeaderText = "引落金融機関支店コード";
                            dataGridViewShiharai_houhou.Columns[12].HeaderText = "引落金融機関支店名（フリガナ）";
                            dataGridViewShiharai_houhou.Columns[13].HeaderText = "引落金融機関支店名";
                            dataGridViewShiharai_houhou.Columns[14].HeaderText = "引落口座種別";
                            dataGridViewShiharai_houhou.Columns[15].HeaderText = "引落口座番号";
                            dataGridViewShiharai_houhou.Columns[16].HeaderText = "引落口座名義人区分";
                            dataGridViewShiharai_houhou.Columns[17].HeaderText = "引落口座名義人（フリガナ）";
                            dataGridViewShiharai_houhou.Columns[18].HeaderText = "引落口座名義人";
                            dataGridViewShiharai_houhou.Columns[19].HeaderText = "引落口座開設日";
                            dataGridViewShiharai_houhou.Columns[20].HeaderText = "引落口座解約日";
                            dataGridViewShiharai_houhou.Columns[21].HeaderText = "引落口座メモ";
                            dataGridViewShiharai_houhou.Columns[22].HeaderText = "振込先委託者名（フリガナ）";
                            dataGridViewShiharai_houhou.Columns[23].HeaderText = "振込先委託者名";
                            dataGridViewShiharai_houhou.Columns[24].HeaderText = "振込先委託者コード";
                            dataGridViewShiharai_houhou.Columns[25].HeaderText = "振込先金融機関銀行コード";
                            dataGridViewShiharai_houhou.Columns[26].HeaderText = "振込先金融機関銀行名（フリガナ）";
                            dataGridViewShiharai_houhou.Columns[27].HeaderText = "振込先金融機関銀行名";
                            dataGridViewShiharai_houhou.Columns[28].HeaderText = "振込先金融機関支店コード";
                            dataGridViewShiharai_houhou.Columns[29].HeaderText = "振込先金融機関支店名（フリガナ）";
                            dataGridViewShiharai_houhou.Columns[30].HeaderText = "振込先金融機関支店名";
                            dataGridViewShiharai_houhou.Columns[31].HeaderText = "振込先口座種別";
                            dataGridViewShiharai_houhou.Columns[32].HeaderText = "振込先口座番号";
                            dataGridViewShiharai_houhou.Columns[33].HeaderText = "振込先口座記号";
                            dataGridViewShiharai_houhou.Columns[34].HeaderText = "振込先引落日";
                            dataGridViewShiharai_houhou.Columns[35].HeaderText = "振込先再振替日";
                            dataGridViewShiharai_houhou.Columns[36].HeaderText = "振込先契約種別コード";
                            dataGridViewShiharai_houhou.Columns[37].HeaderText = "振込先受入事業所センターコード";
                            dataGridViewShiharai_houhou.Columns[38].HeaderText = "振込先手数料：自行";
                            dataGridViewShiharai_houhou.Columns[39].HeaderText = "振込先手数料：他行";
                            dataGridViewShiharai_houhou.Columns[40].HeaderText = "初回引落月";
                            dataGridViewShiharai_houhou.Columns[41].HeaderText = "顧客番号";
                            dataGridViewShiharai_houhou.Columns[42].HeaderText = "被保険者番号";
                            dataGridViewShiharai_houhou.Columns[43].HeaderText = "被保険者氏名";
                            dataGridViewShiharai_houhou.Columns[44].HeaderText = "預金者郵便番号";
                            dataGridViewShiharai_houhou.Columns[45].HeaderText = "預金者氏名";
                            dataGridViewShiharai_houhou.Columns[46].HeaderText = "預金者住所１";
                            dataGridViewShiharai_houhou.Columns[47].HeaderText = "預金者住所２";
                            dataGridViewShiharai_houhou.Columns[48].HeaderText = "預金者住所３";

                            for (int i = 0; i < dataGridViewShiharai_houhou.Columns.Count; i++)
                            {
                                dataGridViewShiharai_houhou.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                dataGridViewShiharai_houhou.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            }

                            break;
                    }
                    break;
                case 3:
                    switch (cmb_s_id_int)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:

                            tblStr = " t_shinzoku_kankei";
                            Console.WriteLine("tblStr = " + tblStr);
                            dataGridViewShinzoku_kankei.Columns[0].HeaderText = "利用者番号";
                            dataGridViewShinzoku_kankei.Columns[1].HeaderText = "利用者名（姓）";
                            dataGridViewShinzoku_kankei.Columns[2].HeaderText = "利用者名（名）";
                            dataGridViewShinzoku_kankei.Columns[3].HeaderText = "利用者名";
                            dataGridViewShinzoku_kankei.Columns[4].HeaderText = "フリガナ（姓）";
                            dataGridViewShinzoku_kankei.Columns[5].HeaderText = "フリガナ（名）";
                            dataGridViewShinzoku_kankei.Columns[6].HeaderText = "フリガナ";
                            dataGridViewShinzoku_kankei.Columns[7].HeaderText = "同名識別";
                            dataGridViewShinzoku_kankei.Columns[8].HeaderText = "性別";
                            dataGridViewShinzoku_kankei.Columns[9].HeaderText = "血液型";
                            dataGridViewShinzoku_kankei.Columns[10].HeaderText = "RH";
                            dataGridViewShinzoku_kankei.Columns[11].HeaderText = "生年月日";
                            dataGridViewShinzoku_kankei.Columns[12].HeaderText = "郵便番号";
                            dataGridViewShinzoku_kankei.Columns[13].HeaderText = "住所";
                            dataGridViewShinzoku_kankei.Columns[14].HeaderText = "電話番号";
                            dataGridViewShinzoku_kankei.Columns[15].HeaderText = "携帯番号";
                            dataGridViewShinzoku_kankei.Columns[16].HeaderText = "E-mail";
                            dataGridViewShinzoku_kankei.Columns[17].HeaderText = "郵便番号（他の住所）";
                            dataGridViewShinzoku_kankei.Columns[18].HeaderText = "住所（他の住所）";
                            dataGridViewShinzoku_kankei.Columns[19].HeaderText = "世帯区分";
                            dataGridViewShinzoku_kankei.Columns[20].HeaderText = "メモ";
                            dataGridViewShinzoku_kankei.Columns[21].HeaderText = "統計用住所";
                            dataGridViewShinzoku_kankei.Columns[22].HeaderText = "親族・関係者名（姓）";
                            dataGridViewShinzoku_kankei.Columns[23].HeaderText = "親族・関係者名（名）";
                            dataGridViewShinzoku_kankei.Columns[24].HeaderText = "親族・関係者名";
                            dataGridViewShinzoku_kankei.Columns[25].HeaderText = "フリガナ（姓）（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[26].HeaderText = "フリガナ（名）（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[27].HeaderText = "フリガナ（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[28].HeaderText = "性別（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[29].HeaderText = "生年月日（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[30].HeaderText = "続柄";
                            dataGridViewShinzoku_kankei.Columns[31].HeaderText = "健康状態";
                            dataGridViewShinzoku_kankei.Columns[32].HeaderText = "職業";
                            dataGridViewShinzoku_kankei.Columns[33].HeaderText = "〒（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[34].HeaderText = "住所（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[35].HeaderText = "住所（地域）（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[36].HeaderText = "宛先";
                            dataGridViewShinzoku_kankei.Columns[37].HeaderText = "電話番号（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[38].HeaderText = "携帯番号（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[39].HeaderText = "E-mail（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[40].HeaderText = "連絡先種別";
                            dataGridViewShinzoku_kankei.Columns[41].HeaderText = "連絡先番号";
                            dataGridViewShinzoku_kankei.Columns[42].HeaderText = "優先順";
                            dataGridViewShinzoku_kankei.Columns[43].HeaderText = "申請者";
                            dataGridViewShinzoku_kankei.Columns[44].HeaderText = "同居家族";
                            dataGridViewShinzoku_kankei.Columns[45].HeaderText = "主介護者";
                            dataGridViewShinzoku_kankei.Columns[46].HeaderText = "保証人";
                            dataGridViewShinzoku_kankei.Columns[47].HeaderText = "支払者";
                            dataGridViewShinzoku_kankei.Columns[48].HeaderText = "相談者";
                            dataGridViewShinzoku_kankei.Columns[49].HeaderText = "（未使用1）";
                            dataGridViewShinzoku_kankei.Columns[50].HeaderText = "（未使用2）";
                            dataGridViewShinzoku_kankei.Columns[51].HeaderText = "（未使用3）";
                            dataGridViewShinzoku_kankei.Columns[52].HeaderText = "（未使用4）";
                            dataGridViewShinzoku_kankei.Columns[53].HeaderText = "メモ（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[54].HeaderText = "面会";
                            dataGridViewShinzoku_kankei.Columns[55].HeaderText = "郵便番号（連絡先住所）";
                            dataGridViewShinzoku_kankei.Columns[56].HeaderText = "住所（連絡先住所）";
                            dataGridViewShinzoku_kankei.Columns[57].HeaderText = "FAX番号";

                            for (int i = 0; i < dataGridViewShinzoku_kankei.Columns.Count; i++)
                            {
                                dataGridViewShinzoku_kankei.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                dataGridViewShinzoku_kankei.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            }

                            break;
                    }
                    break;
            }

            // 再表示
            switch (cmb_g_id_int)
            {
                case 1:
                    switch (cmb_s_id_int)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:

                            Console.WriteLine("Case " + cmb_s_id_int + "!");
                            da.SelectCommand = new NpgsqlCommand
                            (
                                "select"
                                + " c1"
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
                                + ", c4_array"
                                + ", time_stamp"
                                + ", r_id"
                                + ", s_id"
                                + ", g_id"
                                + ", o_id"
                                + ", id"
                                + ", p_id"
                                + ", req_id"
                                + " from"
                                + " t_seikyu"
                                + " where time_stamp = (select max(time_stamp) from t_seikyu"
                                //+ " where s_id::Integer = " + cmb_s_id_int + " and g_id::Integer = " + cmb_g_id_int
                                + " where s_id::Integer = " + cmb_s_id_int
                                + " and g_id::Integer = " + cmb_g_id_int
                                + " and o_id::Integer = " + cmb_o_id_int
                                + " and c4_array[1]::text || '/' || c4_array[2]::Text = case when length('" + cmb_tsuki_str + "')=1 then"
                                                + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                                                + "       when length('" + cmb_tsuki_str + "')=2 then"
                                                + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                                                + " end"
                                + ");"
                                , m_conn
                            );

                            if (cmb_c4.SelectedItem == null)
                            {
                                da.SelectCommand.Parameters.Add(new NpgsqlParameter("c4",
                                NpgsqlTypes.NpgsqlDbType.Text, 0, "c4",
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

                            // update
                            da.UpdateCommand = new NpgsqlCommand(
                                    "update t_seikyu set"
                                    + " c1 = :c1"
                                    + ", c2 = :c2"
                                    + ", c3 = :c3"
                                    + ", c4 = :c4"
                                    + ", c5 = :c5"
                                    + ", c6 = :c6"
                                    + ", c7 = :c7"
                                    + ", c8 = :c8"
                                    + ", c9 = :c9"
                                    + ", c10 = :c10"
                                    + ", c11 = :c11"
                                    + ", c12 = :c12"
                                    + ", c13 = :c13"
                                    + ", c14 = :c14"
                                    + ", c15 = :c15"
                                    + ", c16 = :c16"
                                    + ", c17 = :c17"
                                    + ", c18 = :c18"
                                    + ", c19 = :c19"
                                    + ", c20 = :c20"
                                    + ", c21 = :c21"
                                    + ", c22 = :c22"
                                    + ", c4_array = :c4_array"
                                    + ", id = :id"
                                    + ", req_id = :req_id"
                                    + ", s_id = :s_id"
                                    + ", g_id = :g_id"
                                    + ", o_id = :o_id"
                                    + " where r_id=:r_id;"
                                , m_conn
                                );
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c1", NpgsqlTypes.NpgsqlDbType.Text, 0, "c1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c2", NpgsqlTypes.NpgsqlDbType.Text, 0, "c2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c3", NpgsqlTypes.NpgsqlDbType.Text, 0, "c3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c5", NpgsqlTypes.NpgsqlDbType.Text, 0, "c5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c6", NpgsqlTypes.NpgsqlDbType.Text, 0, "c6", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c7", NpgsqlTypes.NpgsqlDbType.Text, 0, "c7", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c8", NpgsqlTypes.NpgsqlDbType.Text, 0, "c8", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c9", NpgsqlTypes.NpgsqlDbType.Text, 0, "c9", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c10", NpgsqlTypes.NpgsqlDbType.Text, 0, "c10", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c11", NpgsqlTypes.NpgsqlDbType.Text, 0, "c11", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c12", NpgsqlTypes.NpgsqlDbType.Text, 0, "c12", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c13", NpgsqlTypes.NpgsqlDbType.Text, 0, "c13", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c14", NpgsqlTypes.NpgsqlDbType.Text, 0, "c14", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c15", NpgsqlTypes.NpgsqlDbType.Text, 0, "c15", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c16", NpgsqlTypes.NpgsqlDbType.Text, 0, "c16", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c17", NpgsqlTypes.NpgsqlDbType.Text, 0, "c17", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c18", NpgsqlTypes.NpgsqlDbType.Text, 0, "c18", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c19", NpgsqlTypes.NpgsqlDbType.Text, 0, "c19", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c20", NpgsqlTypes.NpgsqlDbType.Text, 0, "c20", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c21", NpgsqlTypes.NpgsqlDbType.Text, 0, "c21", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c22", NpgsqlTypes.NpgsqlDbType.Text, 0, "c22", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4_array", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4_array", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("req_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "req_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("g_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "g_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("r_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "r_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                            // delete
                            da.DeleteCommand = new NpgsqlCommand
                            (
                                   "delete from t_seikyu"
                                + " where"
                                + " r_id=:r_id;"
                                , m_conn
                            );
                            da.DeleteCommand.Parameters.Add(new NpgsqlParameter("r_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "r_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                            // RowUpdate
                            da.RowUpdated += new NpgsqlRowUpdatedEventHandler(SeikyuRowUpdated);

                            if (_seikyu_ds.Tables["seikyu_ds"] != null)
                                _seikyu_ds.Tables["seikyu_ds"].Clear();
                            da.Fill(_seikyu_ds, "seikyu_ds");

                            bindingSourceSeikyu.DataSource = _seikyu_ds;

                            bindingNavigatorSeikyu.BindingSource = bindingSourceSeikyu;

                            dataGridViewSeikyu.DataSource = bindingSourceSeikyu;

                            dataGridViewSeikyu.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                            bindingNavigatorSeikyu.Visible = true;
                            bindingNavigatorShiharai_houhou.Visible = false;
                            bindingNavigatorShinzoku_kankei.Visible = false;

                            dataGridViewSeikyu.Visible = true;
                            dataGridViewShiharai_houhou.Visible = false;
                            dataGridViewShinzoku_kankei.Visible = false;

                            break;
                    }
                    break;

                // 支払方法
                case 2:
                    switch (cmb_s_id_int)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:

                            Console.WriteLine("Case " + cmb_s_id_int + "!");
                            da.SelectCommand = new NpgsqlCommand
                            (
                                "select"
                                + " c1"
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
                                + ", c23"
                                + ", c24"
                                + ", c25"
                                + ", c26"
                                + ", c27"
                                + ", c28"
                                + ", c29"
                                + ", c30"
                                + ", c31"
                                + ", c32"
                                + ", c33"
                                + ", c34"
                                + ", c35"
                                + ", c36"
                                + ", c37"
                                + ", c38"
                                + ", c39"
                                + ", c40"
                                + ", c41"
                                + ", c42"
                                + ", c43"
                                + ", c44"
                                + ", c45"
                                + ", c46"
                                + ", c47"
                                + ", c48"
                                + ", c49"
                                + ", sh_id"
                                + ", s_id"
                                + ", g_id"
                                + ", o_id"
                                + ", p_id"
                                + ", req_id"
                                + ", time_stamp"
                                + ", c4_array"
                                + " from"
                                + " t_shiharai_houhou"
                                + " where time_stamp = (select max(time_stamp) from t_shiharai_houhou"
                                + " where s_id::Integer = " + cmb_s_id_int
                                + " and g_id::Integer = " + cmb_g_id_int
                                + " and o_id::Integer = " + cmb_o_id_int
                                + " and c4_array[1]::text || '/' || c4_array[2]::Text = case when length('" + cmb_tsuki_str + "')=1 then"
                                                + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                                                + "       when length('" + cmb_tsuki_str + "')=2 then"
                                                + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                                                + " end)"
                                + " order by c5;"
                                , m_conn
                            );

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

                            // update
                            da.UpdateCommand = new NpgsqlCommand(
                                    "update t_shiharai_houhou set"
                                    + " c1 = :c1"
                                    + ", c2 = :c2"
                                    + ", c3 = :c3"
                                    + ", c4 = :c4"
                                    + ", c5 = :c5"
                                    + ", c6 = :c6"
                                    + ", c7 = :c7"
                                    + ", c8 = :c8"
                                    + ", c9 = :c9"
                                    + ", c10 = :c10"
                                    + ", c11 = :c11"
                                    + ", c12 = :c12"
                                    + ", c13 = :c13"
                                    + ", c14 = :c14"
                                    + ", c15 = :c15"
                                    + ", c16 = :c16"
                                    + ", c17 = :c17"
                                    + ", c18 = :c18"
                                    + ", c19 = :c19"
                                    + ", c20 = :c20"
                                    + ", c21 = :c21"
                                    + ", c22 = :c22"
                                    + ", c23 = :c23"
                                    + ", c24 = :c24"
                                    + ", c25 = :c25"
                                    + ", c26 = :c26"
                                    + ", c27 = :c27"
                                    + ", c28 = :c28"
                                    + ", c29 = :c29"
                                    + ", c30 = :c30"
                                    + ", c31 = :c31"
                                    + ", c32 = :c32"
                                    + ", c33 = :c33"
                                    + ", c34 = :c34"
                                    + ", c35 = :c35"
                                    + ", c36 = :c36"
                                    + ", c37 = :c37"
                                    + ", c38 = :c38"
                                    + ", c39 = :c39"
                                    + ", c40 = :c40"
                                    + ", c41 = :c41"
                                    + ", c42 = :c42"
                                    + ", c43 = :c43"
                                    + ", c44 = :c44"
                                    + ", c45 = :c45"
                                    + ", c46 = :c46"
                                    + ", c47 = :c47"
                                    + ", c48 = :c48"
                                    + ", c49 = :c49"
                                    + ", s_id = :s_id"
                                    + ", g_id = :g_id"
                                    + ", o_id = :o_id"
                                    + ", p_id = :p_id"
                                    + ", req_id = :req_id"
                                    + ", c4_array = :c4_array"
                                    + " where sh_id=:sh_id;"
                                , m_conn
                                );
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c1", NpgsqlTypes.NpgsqlDbType.Text, 0, "c1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c2", NpgsqlTypes.NpgsqlDbType.Text, 0, "c2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c3", NpgsqlTypes.NpgsqlDbType.Text, 0, "c3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c5", NpgsqlTypes.NpgsqlDbType.Text, 0, "c5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c6", NpgsqlTypes.NpgsqlDbType.Text, 0, "c6", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c7", NpgsqlTypes.NpgsqlDbType.Text, 0, "c7", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c8", NpgsqlTypes.NpgsqlDbType.Text, 0, "c8", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c9", NpgsqlTypes.NpgsqlDbType.Text, 0, "c9", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c10", NpgsqlTypes.NpgsqlDbType.Text, 0, "c10", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c11", NpgsqlTypes.NpgsqlDbType.Text, 0, "c11", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c12", NpgsqlTypes.NpgsqlDbType.Text, 0, "c12", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c13", NpgsqlTypes.NpgsqlDbType.Text, 0, "c13", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c14", NpgsqlTypes.NpgsqlDbType.Text, 0, "c14", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c15", NpgsqlTypes.NpgsqlDbType.Text, 0, "c15", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c16", NpgsqlTypes.NpgsqlDbType.Text, 0, "c16", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c17", NpgsqlTypes.NpgsqlDbType.Text, 0, "c17", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c18", NpgsqlTypes.NpgsqlDbType.Text, 0, "c18", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c19", NpgsqlTypes.NpgsqlDbType.Text, 0, "c19", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c20", NpgsqlTypes.NpgsqlDbType.Text, 0, "c20", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c21", NpgsqlTypes.NpgsqlDbType.Text, 0, "c21", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c22", NpgsqlTypes.NpgsqlDbType.Text, 0, "c22", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c23", NpgsqlTypes.NpgsqlDbType.Text, 0, "c23", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c24", NpgsqlTypes.NpgsqlDbType.Text, 0, "c24", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c25", NpgsqlTypes.NpgsqlDbType.Text, 0, "c25", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c26", NpgsqlTypes.NpgsqlDbType.Text, 0, "c26", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c27", NpgsqlTypes.NpgsqlDbType.Text, 0, "c27", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c28", NpgsqlTypes.NpgsqlDbType.Text, 0, "c28", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c29", NpgsqlTypes.NpgsqlDbType.Text, 0, "c29", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c30", NpgsqlTypes.NpgsqlDbType.Text, 0, "c30", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c31", NpgsqlTypes.NpgsqlDbType.Text, 0, "c31", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c32", NpgsqlTypes.NpgsqlDbType.Text, 0, "c32", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c33", NpgsqlTypes.NpgsqlDbType.Text, 0, "c33", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c34", NpgsqlTypes.NpgsqlDbType.Text, 0, "c34", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c35", NpgsqlTypes.NpgsqlDbType.Text, 0, "c35", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c36", NpgsqlTypes.NpgsqlDbType.Text, 0, "c36", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c37", NpgsqlTypes.NpgsqlDbType.Text, 0, "c37", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c38", NpgsqlTypes.NpgsqlDbType.Text, 0, "c38", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c39", NpgsqlTypes.NpgsqlDbType.Text, 0, "c39", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c40", NpgsqlTypes.NpgsqlDbType.Text, 0, "c40", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c41", NpgsqlTypes.NpgsqlDbType.Text, 0, "c41", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c42", NpgsqlTypes.NpgsqlDbType.Text, 0, "c42", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c43", NpgsqlTypes.NpgsqlDbType.Text, 0, "c43", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c44", NpgsqlTypes.NpgsqlDbType.Text, 0, "c44", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c45", NpgsqlTypes.NpgsqlDbType.Text, 0, "c45", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c46", NpgsqlTypes.NpgsqlDbType.Text, 0, "c46", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c47", NpgsqlTypes.NpgsqlDbType.Text, 0, "c47", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c48", NpgsqlTypes.NpgsqlDbType.Text, 0, "c48", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c49", NpgsqlTypes.NpgsqlDbType.Text, 0, "c49", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("g_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "g_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("p_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "p_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("req_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "req_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4_array", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4_array", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("sh_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "sh_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                            // delete
                            da.DeleteCommand = new NpgsqlCommand
                            (
                                   "delete from t_shiharai_houhou"
                                + " where"
                                + " sh_id=:sh_id;"
                                , m_conn
                            );
                            da.DeleteCommand.Parameters.Add(new NpgsqlParameter("sh_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "sh_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                            // RowUpdate
                            da.RowUpdated += new NpgsqlRowUpdatedEventHandler(SeikyuRowUpdated);

                            if (_shiharai_houhou_ds.Tables["shiharai_houhou_ds"] != null)
                                _shiharai_houhou_ds.Tables["shiharai_houhou_ds"].Clear();
                            da.Fill(_shiharai_houhou_ds, "shiharai_houhou_ds");

                            bindingSourceShiharai_houhou.DataSource = _shiharai_houhou_ds;

                            bindingNavigatorShiharai_houhou.BindingSource = bindingSourceShiharai_houhou;

                            dataGridViewShiharai_houhou.DataSource = bindingSourceShiharai_houhou;

                            dataGridViewShiharai_houhou.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                            bindingNavigatorSeikyu.Visible = false;
                            bindingNavigatorShiharai_houhou.Visible = true;
                            bindingNavigatorShinzoku_kankei.Visible = false;

                            dataGridViewSeikyu.Visible = false;
                            dataGridViewShiharai_houhou.Visible = true;
                            dataGridViewShinzoku_kankei.Visible = false;

                            break;
                    }
                    break;

                // 親族関係
                case 3:
                    switch (cmb_s_id_int)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:

                            //MessageBox.Show("Case " + cmb_s_id_int + "!");
                            Console.WriteLine("Case " + cmb_s_id_int + "!");
                            da.SelectCommand = new NpgsqlCommand
                            (
                                "select"
                                + " c1"
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
                                + ", c23"
                                + ", c24"
                                + ", c25"
                                + ", c26"
                                + ", c27"
                                + ", c28"
                                + ", c29"
                                + ", c30"
                                + ", c31"
                                + ", c32"
                                + ", c33"
                                + ", c34"
                                + ", c35"
                                + ", c36"
                                + ", c37"
                                + ", c38"
                                + ", c39"
                                + ", c40"
                                + ", c41"
                                + ", c42"
                                + ", c43"
                                + ", c44"
                                + ", c45"
                                + ", c46"
                                + ", c47"
                                + ", c48"
                                + ", c49"
                                + ", c50"
                                + ", c51"
                                + ", c52"
                                + ", c53"
                                + ", c54"
                                + ", c55"
                                + ", c56"
                                + ", c57"
                                + ", c58"
                                + ", sk_id"
                                + ", s_id"
                                + ", g_id"
                                + ", o_id"
                                + ", p_id"
                                + ", req_id"
                                + ", time_stamp"
                                + ", c4_array"
                                + " from"
                                + " t_shinzoku_kankei"
                                + " where time_stamp = (select max(time_stamp) from t_shinzoku_kankei"
                                + " where s_id::Integer = " + cmb_s_id_int
                                + " and g_id::Integer = " + cmb_g_id_int
                                + " and o_id::Integer = " + cmb_o_id_int
                                + " and c4_array[1]::text || '/' || c4_array[2]::Text = case when length('" + cmb_tsuki_str + "')=1 then"
                                                + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                                                + "       when length('" + cmb_tsuki_str + "')=2 then"
                                                + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                                                + " end"
                                + ")"
                                + " order by c5"
                                , m_conn
                            );

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

                            // update
                            da.UpdateCommand = new NpgsqlCommand(
                                    "update t_shinzoku_kankei set"
                                + " c1 = :c1"
                                + ", c2 = :c2"
                                + ", c3 = :c3"
                                + ", c4 = :c4"
                                + ", c5 = :c5"
                                + ", c6 = :c6"
                                + ", c7 = :c7"
                                + ", c8 = :c8"
                                + ", c9 = :c9"
                                + ", c10 = :c10"
                                + ", c11 = :c11"
                                + ", c12 = :c12"
                                + ", c13 = :c13"
                                + ", c14 = :c14"
                                + ", c15 = :c15"
                                + ", c16 = :c16"
                                + ", c17 = :c17"
                                + ", c18 = :c18"
                                + ", c19 = :c19"
                                + ", c20 = :c20"
                                + ", c21 = :c21"
                                + ", c22 = :c22"
                                + ", c23 = :c23"
                                + ", c24 = :c24"
                                + ", c25 = :c25"
                                + ", c26 = :c26"
                                + ", c27 = :c27"
                                + ", c28 = :c28"
                                + ", c29 = :c29"
                                + ", c30 = :c30"
                                + ", c31 = :c31"
                                + ", c32 = :c32"
                                + ", c33 = :c33"
                                + ", c34 = :c34"
                                + ", c35 = :c35"
                                + ", c36 = :c36"
                                + ", c37 = :c37"
                                + ", c38 = :c38"
                                + ", c39 = :c39"
                                + ", c40 = :c40"
                                + ", c41 = :c41"
                                + ", c42 = :c42"
                                + ", c43 = :c43"
                                + ", c44 = :c44"
                                + ", c45 = :c45"
                                + ", c46 = :c46"
                                + ", c47 = :c47"
                                + ", c48 = :c48"
                                + ", c49 = :c49"
                                + ", c50 = :c50"
                                + ", c51 = :c51"
                                + ", c52 = :c52"
                                + ", c53 = :c53"
                                + ", c54 = :c54"
                                + ", c55 = :c55"
                                + ", c56 = :c56"
                                + ", c57 = :c57"
                                + ", c58 = :c58"
                                + ", s_id = :s_id"
                                + ", g_id = :g_id"
                                + ", o_id = :o_id"
                                + ", p_id = :p_id"
                                + ", req_id = :req_id"
                                + ", c4_array = :c4_array"
                                + " where sk_id=:sk_id;"
                                , m_conn
                                );
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c1", NpgsqlTypes.NpgsqlDbType.Text, 0, "c1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c2", NpgsqlTypes.NpgsqlDbType.Text, 0, "c2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c3", NpgsqlTypes.NpgsqlDbType.Text, 0, "c3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c5", NpgsqlTypes.NpgsqlDbType.Text, 0, "c5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c6", NpgsqlTypes.NpgsqlDbType.Text, 0, "c6", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c7", NpgsqlTypes.NpgsqlDbType.Text, 0, "c7", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c8", NpgsqlTypes.NpgsqlDbType.Text, 0, "c8", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c9", NpgsqlTypes.NpgsqlDbType.Text, 0, "c9", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c10", NpgsqlTypes.NpgsqlDbType.Text, 0, "c10", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c11", NpgsqlTypes.NpgsqlDbType.Text, 0, "c11", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c12", NpgsqlTypes.NpgsqlDbType.Text, 0, "c12", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c13", NpgsqlTypes.NpgsqlDbType.Text, 0, "c13", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c14", NpgsqlTypes.NpgsqlDbType.Text, 0, "c14", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c15", NpgsqlTypes.NpgsqlDbType.Text, 0, "c15", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c16", NpgsqlTypes.NpgsqlDbType.Text, 0, "c16", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c17", NpgsqlTypes.NpgsqlDbType.Text, 0, "c17", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c18", NpgsqlTypes.NpgsqlDbType.Text, 0, "c18", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c19", NpgsqlTypes.NpgsqlDbType.Text, 0, "c19", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c20", NpgsqlTypes.NpgsqlDbType.Text, 0, "c20", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c21", NpgsqlTypes.NpgsqlDbType.Text, 0, "c21", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c22", NpgsqlTypes.NpgsqlDbType.Text, 0, "c22", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c23", NpgsqlTypes.NpgsqlDbType.Text, 0, "c23", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c24", NpgsqlTypes.NpgsqlDbType.Text, 0, "c24", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c25", NpgsqlTypes.NpgsqlDbType.Text, 0, "c25", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c26", NpgsqlTypes.NpgsqlDbType.Text, 0, "c26", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c27", NpgsqlTypes.NpgsqlDbType.Text, 0, "c27", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c28", NpgsqlTypes.NpgsqlDbType.Text, 0, "c28", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c29", NpgsqlTypes.NpgsqlDbType.Text, 0, "c29", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c30", NpgsqlTypes.NpgsqlDbType.Text, 0, "c30", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c31", NpgsqlTypes.NpgsqlDbType.Text, 0, "c31", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c32", NpgsqlTypes.NpgsqlDbType.Text, 0, "c32", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c33", NpgsqlTypes.NpgsqlDbType.Text, 0, "c33", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c34", NpgsqlTypes.NpgsqlDbType.Text, 0, "c34", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c35", NpgsqlTypes.NpgsqlDbType.Text, 0, "c35", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c36", NpgsqlTypes.NpgsqlDbType.Text, 0, "c36", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c37", NpgsqlTypes.NpgsqlDbType.Text, 0, "c37", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c38", NpgsqlTypes.NpgsqlDbType.Text, 0, "c38", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c39", NpgsqlTypes.NpgsqlDbType.Text, 0, "c39", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c40", NpgsqlTypes.NpgsqlDbType.Text, 0, "c40", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c41", NpgsqlTypes.NpgsqlDbType.Text, 0, "c41", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c42", NpgsqlTypes.NpgsqlDbType.Text, 0, "c42", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c43", NpgsqlTypes.NpgsqlDbType.Text, 0, "c43", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c44", NpgsqlTypes.NpgsqlDbType.Text, 0, "c44", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c45", NpgsqlTypes.NpgsqlDbType.Text, 0, "c45", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c46", NpgsqlTypes.NpgsqlDbType.Text, 0, "c46", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c47", NpgsqlTypes.NpgsqlDbType.Text, 0, "c47", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c48", NpgsqlTypes.NpgsqlDbType.Text, 0, "c48", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c49", NpgsqlTypes.NpgsqlDbType.Text, 0, "c49", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c50", NpgsqlTypes.NpgsqlDbType.Text, 0, "c50", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c51", NpgsqlTypes.NpgsqlDbType.Text, 0, "c51", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c52", NpgsqlTypes.NpgsqlDbType.Text, 0, "c52", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c53", NpgsqlTypes.NpgsqlDbType.Text, 0, "c53", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c54", NpgsqlTypes.NpgsqlDbType.Text, 0, "c54", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c55", NpgsqlTypes.NpgsqlDbType.Text, 0, "c55", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c56", NpgsqlTypes.NpgsqlDbType.Text, 0, "c56", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c57", NpgsqlTypes.NpgsqlDbType.Text, 0, "c57", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c58", NpgsqlTypes.NpgsqlDbType.Text, 0, "c58", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("g_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "g_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("p_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "p_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("req_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "req_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4_array", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4_array", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("sk_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "sk_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                            // delete
                            da.DeleteCommand = new NpgsqlCommand
                            (
                                   "delete from t_shinzoku_kankei"
                                + " where"
                                + " sk_id=:sk_id;"
                                , m_conn
                            );
                            da.DeleteCommand.Parameters.Add(new NpgsqlParameter("sk_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "sk_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                            // RowUpdate
                            da.RowUpdated += new NpgsqlRowUpdatedEventHandler(SeikyuRowUpdated);

                            if (_shinzoku_kankei_ds.Tables["shinzoku_kankei_ds"] != null)
                                _shinzoku_kankei_ds.Tables["shinzoku_kankei_ds"].Clear();
                            da.Fill(_shinzoku_kankei_ds, "shinzoku_kankei_ds");

                            bindingSourceShinzoku_kankei.DataSource = _shinzoku_kankei_ds;

                            bindingNavigatorShinzoku_kankei.BindingSource = bindingSourceShinzoku_kankei;

                            dataGridViewShinzoku_kankei.DataSource = bindingSourceShinzoku_kankei;

                            dataGridViewShinzoku_kankei.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                            bindingNavigatorSeikyu.Visible = false;
                            bindingNavigatorShiharai_houhou.Visible = false;
                            bindingNavigatorShinzoku_kankei.Visible = true;

                            dataGridViewSeikyu.Visible = false;
                            dataGridViewShiharai_houhou.Visible = false;
                            dataGridViewShinzoku_kankei.Visible = true;

                            break;
                    }
                    break;
            }
        }

        private void cmb_req_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_req_id_int = cmb_req_id.SelectedIndex + 1;
            Console.WriteLine("cmb_req_id_int = " + cmb_req_id_int);
        }

        private void cmdPrn_Click(object sender, EventArgs e)
        {
            Form_prn Form = new Form_prn();
            Form.WindowState = FormWindowState.Maximized;
            Form.ShowDialog();
        }

        private void cmdPar_Click(object sender, EventArgs e)
        {
            Form_chg Form = new Form_chg();
            Form.WindowState = FormWindowState.Maximized;
            Form.ShowDialog();
        }

        private void dataGridViewSeikyu_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;

            Console.WriteLine("列名 = " + (this.dataGridViewSeikyu.Columns[e.ColumnIndex].Name));


            switch (this.dataGridViewSeikyu.Columns[e.ColumnIndex].Name)
            {
                case "c6":
                case "c7":
                case "c8":
                case "c9":
                case "c10":
                case "c11":
                    int vc6 = Int32.Parse((string)dataGridViewSeikyu[5, e.RowIndex].Value);
                    int vc7 = Int32.Parse((string)dataGridViewSeikyu[6, e.RowIndex].Value);
                    int vc8 = Int32.Parse((string)dataGridViewSeikyu[7, e.RowIndex].Value);
                    int vc9 = Int32.Parse((string)dataGridViewSeikyu[8, e.RowIndex].Value);
                    int vc10 = Int32.Parse((string)dataGridViewSeikyu[9, e.RowIndex].Value);
                    int vc11 = Int32.Parse((string)dataGridViewSeikyu[10, e.RowIndex].Value);

                    dataGridViewSeikyu[11, e.RowIndex].Value = (vc6 + vc7 + vc8 + vc9 + vc10 + vc11).ToString();

                    break;

                case "c13":
                case "c14":
                case "c15":
                case "c16":
                case "c17":
                case "c18":
                case "c19":
                case "c20":
                case "c21":
                    int vc13 = Int32.Parse((string)dataGridViewSeikyu[12, e.RowIndex].Value);
                    int vc14 = Int32.Parse((string)dataGridViewSeikyu[13, e.RowIndex].Value);
                    int vc15 = Int32.Parse((string)dataGridViewSeikyu[14, e.RowIndex].Value);
                    int vc16 = Int32.Parse((string)dataGridViewSeikyu[15, e.RowIndex].Value);
                    int vc17 = Int32.Parse((string)dataGridViewSeikyu[16, e.RowIndex].Value);
                    int vc18 = Int32.Parse((string)dataGridViewSeikyu[17, e.RowIndex].Value);
                    int vc19 = Int32.Parse((string)dataGridViewSeikyu[18, e.RowIndex].Value);
                    int vc20 = Int32.Parse((string)dataGridViewSeikyu[19, e.RowIndex].Value);
                    int vc21 = Int32.Parse((string)dataGridViewSeikyu[20, e.RowIndex].Value);

                    dataGridViewSeikyu[21, e.RowIndex].Value = (vc13 + vc14 + vc15 + vc16 + vc17 + vc18 + vc19 + vc20 + vc21).ToString();

                    break;
            }
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

        private void cmb_g_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_g_id_int = cmb_g_id.SelectedIndex + 1;
            Console.WriteLine("cmb_g_id_int = " + cmb_g_id_int);
            switch (cmb_g_id_int)
            {
                case 1:
                    switch (cmb_s_id_int)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:

                            tblStr = " t_seikyu";
                            Console.WriteLine("tblStr = " + tblStr);
                            dataGridViewSeikyu.Columns[0].HeaderText = "利用者番号";
                            dataGridViewSeikyu.Columns[1].HeaderText = "要介護度";
                            dataGridViewSeikyu.Columns[2].HeaderText = "利用者名";
                            dataGridViewSeikyu.Columns[3].HeaderText = "提供月";
                            dataGridViewSeikyu.Columns[4].HeaderText = "合計額";
                            dataGridViewSeikyu.Columns[5].HeaderText = "サービス費（保険請求）";
                            dataGridViewSeikyu.Columns[6].HeaderText = "サービス費（公費請求）";
                            dataGridViewSeikyu.Columns[7].HeaderText = "食費（保険請求）";
                            dataGridViewSeikyu.Columns[8].HeaderText = "食費（公費請求）";
                            dataGridViewSeikyu.Columns[9].HeaderText = "居住費（保険請求）";
                            dataGridViewSeikyu.Columns[10].HeaderText = "居住費（公費請求）";
                            dataGridViewSeikyu.Columns[11].HeaderText = "介護請求合計額";
                            dataGridViewSeikyu.Columns[12].HeaderText = "利用者負担額";
                            dataGridViewSeikyu.Columns[13].HeaderText = "自費負担額";
                            dataGridViewSeikyu.Columns[14].HeaderText = "食事負担額";
                            dataGridViewSeikyu.Columns[15].HeaderText = "室料負担額";
                            dataGridViewSeikyu.Columns[16].HeaderText = "特定公費本人支払";
                            dataGridViewSeikyu.Columns[17].HeaderText = "高額介護超過額";
                            dataGridViewSeikyu.Columns[18].HeaderText = "その他実費";
                            dataGridViewSeikyu.Columns[19].HeaderText = "減免額";
                            dataGridViewSeikyu.Columns[20].HeaderText = "過入金";
                            dataGridViewSeikyu.Columns[21].HeaderText = "利用料請求合計額";
                            dataGridViewSeikyu.Columns[21].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("ja-JP");
                            dataGridViewSeikyu.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                            for (int i = 0; i < dataGridViewSeikyu.Columns.Count; i++)
                            {
                                if (i < 1 || i > 3)
                                {
                                    dataGridViewSeikyu.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    dataGridViewSeikyu.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    dataGridViewSeikyu.Columns[i].DefaultCellStyle.Format = "#,0";
                                }
                                else
                                {
                                    dataGridViewSeikyu.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    dataGridViewSeikyu.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                                }
                            }

                            break;
                    }
                    break;
                case 2:
                    switch (cmb_s_id_int)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:

                            tblStr = "t_shiharai_houhou";
                            Console.WriteLine("tblStr = " + tblStr);
                            dataGridViewShiharai_houhou.Columns[0].HeaderText = "法人名";
                            dataGridViewShiharai_houhou.Columns[1].HeaderText = "施設名";
                            dataGridViewShiharai_houhou.Columns[2].HeaderText = "事業所番号";
                            dataGridViewShiharai_houhou.Columns[3].HeaderText = "事業所名";
                            dataGridViewShiharai_houhou.Columns[4].HeaderText = "利用者番号";
                            dataGridViewShiharai_houhou.Columns[5].HeaderText = "利用者名";
                            dataGridViewShiharai_houhou.Columns[6].HeaderText = "支払方法";
                            dataGridViewShiharai_houhou.Columns[7].HeaderText = "引落口座";
                            dataGridViewShiharai_houhou.Columns[8].HeaderText = "引落金融機関銀行コード";
                            dataGridViewShiharai_houhou.Columns[9].HeaderText = "引落金融機関銀行名（フリガナ）";
                            dataGridViewShiharai_houhou.Columns[10].HeaderText = "引落金融機関銀行名";
                            dataGridViewShiharai_houhou.Columns[11].HeaderText = "引落金融機関支店コード";
                            dataGridViewShiharai_houhou.Columns[12].HeaderText = "引落金融機関支店名（フリガナ）";
                            dataGridViewShiharai_houhou.Columns[13].HeaderText = "引落金融機関支店名";
                            dataGridViewShiharai_houhou.Columns[14].HeaderText = "引落口座種別";
                            dataGridViewShiharai_houhou.Columns[15].HeaderText = "引落口座番号";
                            dataGridViewShiharai_houhou.Columns[16].HeaderText = "引落口座名義人区分";
                            dataGridViewShiharai_houhou.Columns[17].HeaderText = "引落口座名義人（フリガナ）";
                            dataGridViewShiharai_houhou.Columns[18].HeaderText = "引落口座名義人";
                            dataGridViewShiharai_houhou.Columns[19].HeaderText = "引落口座開設日";
                            dataGridViewShiharai_houhou.Columns[20].HeaderText = "引落口座解約日";
                            dataGridViewShiharai_houhou.Columns[21].HeaderText = "引落口座メモ";
                            dataGridViewShiharai_houhou.Columns[22].HeaderText = "振込先委託者名（フリガナ）";
                            dataGridViewShiharai_houhou.Columns[23].HeaderText = "振込先委託者名";
                            dataGridViewShiharai_houhou.Columns[24].HeaderText = "振込先委託者コード";
                            dataGridViewShiharai_houhou.Columns[25].HeaderText = "振込先金融機関銀行コード";
                            dataGridViewShiharai_houhou.Columns[26].HeaderText = "振込先金融機関銀行名（フリガナ）";
                            dataGridViewShiharai_houhou.Columns[27].HeaderText = "振込先金融機関銀行名";
                            dataGridViewShiharai_houhou.Columns[28].HeaderText = "振込先金融機関支店コード";
                            dataGridViewShiharai_houhou.Columns[29].HeaderText = "振込先金融機関支店名（フリガナ）";
                            dataGridViewShiharai_houhou.Columns[30].HeaderText = "振込先金融機関支店名";
                            dataGridViewShiharai_houhou.Columns[31].HeaderText = "振込先口座種別";
                            dataGridViewShiharai_houhou.Columns[32].HeaderText = "振込先口座番号";
                            dataGridViewShiharai_houhou.Columns[33].HeaderText = "振込先口座記号";
                            dataGridViewShiharai_houhou.Columns[34].HeaderText = "振込先引落日";
                            dataGridViewShiharai_houhou.Columns[35].HeaderText = "振込先再振替日";
                            dataGridViewShiharai_houhou.Columns[36].HeaderText = "振込先契約種別コード";
                            dataGridViewShiharai_houhou.Columns[37].HeaderText = "振込先受入事業所センターコード";
                            dataGridViewShiharai_houhou.Columns[38].HeaderText = "振込先手数料：自行";
                            dataGridViewShiharai_houhou.Columns[39].HeaderText = "振込先手数料：他行";
                            dataGridViewShiharai_houhou.Columns[40].HeaderText = "初回引落月";
                            dataGridViewShiharai_houhou.Columns[41].HeaderText = "顧客番号";
                            dataGridViewShiharai_houhou.Columns[42].HeaderText = "被保険者番号";
                            dataGridViewShiharai_houhou.Columns[43].HeaderText = "被保険者氏名";
                            dataGridViewShiharai_houhou.Columns[44].HeaderText = "預金者郵便番号";
                            dataGridViewShiharai_houhou.Columns[45].HeaderText = "預金者氏名";
                            dataGridViewShiharai_houhou.Columns[46].HeaderText = "預金者住所１";
                            dataGridViewShiharai_houhou.Columns[47].HeaderText = "預金者住所２";
                            dataGridViewShiharai_houhou.Columns[48].HeaderText = "預金者住所３";

                            for (int i = 0; i < dataGridViewShiharai_houhou.Columns.Count; i++)
                            {
                                dataGridViewShiharai_houhou.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                dataGridViewShiharai_houhou.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            }

                            break;
                    }
                    break;
                case 3:
                    switch (cmb_s_id_int)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                            tblStr = " t_shinzoku_kankei";
                            Console.WriteLine("tblStr = " + tblStr);
                            dataGridViewShinzoku_kankei.Columns[0].HeaderText = "利用者番号";
                            dataGridViewShinzoku_kankei.Columns[1].HeaderText = "利用者名（姓）";
                            dataGridViewShinzoku_kankei.Columns[2].HeaderText = "利用者名（名）";
                            dataGridViewShinzoku_kankei.Columns[3].HeaderText = "利用者名";
                            dataGridViewShinzoku_kankei.Columns[4].HeaderText = "フリガナ（姓）";
                            dataGridViewShinzoku_kankei.Columns[5].HeaderText = "フリガナ（名）";
                            dataGridViewShinzoku_kankei.Columns[6].HeaderText = "フリガナ";
                            dataGridViewShinzoku_kankei.Columns[7].HeaderText = "同名識別";
                            dataGridViewShinzoku_kankei.Columns[8].HeaderText = "性別";
                            dataGridViewShinzoku_kankei.Columns[9].HeaderText = "血液型";
                            dataGridViewShinzoku_kankei.Columns[10].HeaderText = "RH";
                            dataGridViewShinzoku_kankei.Columns[11].HeaderText = "生年月日";
                            dataGridViewShinzoku_kankei.Columns[12].HeaderText = "郵便番号";
                            dataGridViewShinzoku_kankei.Columns[13].HeaderText = "住所";
                            dataGridViewShinzoku_kankei.Columns[14].HeaderText = "電話番号";
                            dataGridViewShinzoku_kankei.Columns[15].HeaderText = "携帯番号";
                            dataGridViewShinzoku_kankei.Columns[16].HeaderText = "E-mail";
                            dataGridViewShinzoku_kankei.Columns[17].HeaderText = "郵便番号（他の住所）";
                            dataGridViewShinzoku_kankei.Columns[18].HeaderText = "住所（他の住所）";
                            dataGridViewShinzoku_kankei.Columns[19].HeaderText = "世帯区分";
                            dataGridViewShinzoku_kankei.Columns[20].HeaderText = "メモ";
                            dataGridViewShinzoku_kankei.Columns[21].HeaderText = "統計用住所";
                            dataGridViewShinzoku_kankei.Columns[22].HeaderText = "親族・関係者名（姓）";
                            dataGridViewShinzoku_kankei.Columns[23].HeaderText = "親族・関係者名（名）";
                            dataGridViewShinzoku_kankei.Columns[24].HeaderText = "親族・関係者名";
                            dataGridViewShinzoku_kankei.Columns[25].HeaderText = "フリガナ（姓）（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[26].HeaderText = "フリガナ（名）（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[27].HeaderText = "フリガナ（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[28].HeaderText = "性別（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[29].HeaderText = "生年月日（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[30].HeaderText = "続柄";
                            dataGridViewShinzoku_kankei.Columns[31].HeaderText = "健康状態";
                            dataGridViewShinzoku_kankei.Columns[32].HeaderText = "職業";
                            dataGridViewShinzoku_kankei.Columns[33].HeaderText = "〒（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[34].HeaderText = "住所（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[35].HeaderText = "住所（地域）（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[36].HeaderText = "宛先";
                            dataGridViewShinzoku_kankei.Columns[37].HeaderText = "電話番号（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[38].HeaderText = "携帯番号（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[39].HeaderText = "E-mail（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[40].HeaderText = "連絡先種別";
                            dataGridViewShinzoku_kankei.Columns[41].HeaderText = "連絡先番号";
                            dataGridViewShinzoku_kankei.Columns[42].HeaderText = "優先順";
                            dataGridViewShinzoku_kankei.Columns[43].HeaderText = "申請者";
                            dataGridViewShinzoku_kankei.Columns[44].HeaderText = "同居家族";
                            dataGridViewShinzoku_kankei.Columns[45].HeaderText = "主介護者";
                            dataGridViewShinzoku_kankei.Columns[46].HeaderText = "保証人";
                            dataGridViewShinzoku_kankei.Columns[47].HeaderText = "支払者";
                            dataGridViewShinzoku_kankei.Columns[48].HeaderText = "相談者";
                            dataGridViewShinzoku_kankei.Columns[49].HeaderText = "（未使用1）";
                            dataGridViewShinzoku_kankei.Columns[50].HeaderText = "（未使用2）";
                            dataGridViewShinzoku_kankei.Columns[51].HeaderText = "（未使用3）";
                            dataGridViewShinzoku_kankei.Columns[52].HeaderText = "（未使用4）";
                            dataGridViewShinzoku_kankei.Columns[53].HeaderText = "メモ（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[54].HeaderText = "面会";
                            dataGridViewShinzoku_kankei.Columns[55].HeaderText = "郵便番号（連絡先住所）";
                            dataGridViewShinzoku_kankei.Columns[56].HeaderText = "住所（連絡先住所）";
                            dataGridViewShinzoku_kankei.Columns[57].HeaderText = "FAX番号";

                            for (int i = 0; i < dataGridViewShinzoku_kankei.Columns.Count; i++)
                            {
                                dataGridViewShinzoku_kankei.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                dataGridViewShinzoku_kankei.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            }

                            break;
                    }
                    break;
            }

            // 再表示
            switch (cmb_g_id_int)
            {
                case 1:
                    switch (cmb_s_id_int)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:

                            Console.WriteLine("Case " + cmb_s_id_int + "!");
                            da.SelectCommand = new NpgsqlCommand
                            (
                                "select"
                                + " c1"
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
                                + ", c4_array"
                                + ", time_stamp"
                                + ", r_id"
                                + ", s_id"
                                + ", g_id"
                                + ", o_id"
                                + ", id"
                                + ", p_id"
                                + ", req_id"
                                + " from"
                                + " t_seikyu"
                                + " where time_stamp = (select max(time_stamp) from t_seikyu"
                                + " where s_id::Integer = " + cmb_s_id_int
                                + " and g_id::Integer = " + cmb_g_id_int
                                + " and o_id::Integer = " + cmb_o_id_int
                                + " and c4_array[1]::text || '/' || c4_array[2]::Text = case when length('" + cmb_tsuki_str + "')=1 then"
                                                + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                                                + "       when length('" + cmb_tsuki_str + "')=2 then"
                                                + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                                                + " end"
                                + ");"
                                //+ " order by id"
                                , m_conn
                            );

                            if (cmb_c4.SelectedItem == null)
                            {
                                da.SelectCommand.Parameters.Add(new NpgsqlParameter("c4",
                                NpgsqlTypes.NpgsqlDbType.Text, 0, "c4",
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

                            // update
                            da.UpdateCommand = new NpgsqlCommand(
                                    "update t_seikyu set"
                                    + " c1 = :c1"
                                    + ", c2 = :c2"
                                    + ", c3 = :c3"
                                    + ", c4 = :c4"
                                    + ", c5 = :c5"
                                    + ", c6 = :c6"
                                    + ", c7 = :c7"
                                    + ", c8 = :c8"
                                    + ", c9 = :c9"
                                    + ", c10 = :c10"
                                    + ", c11 = :c11"
                                    + ", c12 = :c12"
                                    + ", c13 = :c13"
                                    + ", c14 = :c14"
                                    + ", c15 = :c15"
                                    + ", c16 = :c16"
                                    + ", c17 = :c17"
                                    + ", c18 = :c18"
                                    + ", c19 = :c19"
                                    + ", c20 = :c20"
                                    + ", c21 = :c21"
                                    + ", c22 = :c22"
                                    + ", c4_array = :c4_array"
                                    + ", id = :id"
                                    + ", req_id = :req_id"
                                    + ", s_id = :s_id"
                                    + ", g_id = :g_id"
                                    + ", o_id = :o_id"
                                    + " where r_id=:r_id;"
                                , m_conn
                                );
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c1", NpgsqlTypes.NpgsqlDbType.Text, 0, "c1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c2", NpgsqlTypes.NpgsqlDbType.Text, 0, "c2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c3", NpgsqlTypes.NpgsqlDbType.Text, 0, "c3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c5", NpgsqlTypes.NpgsqlDbType.Text, 0, "c5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c6", NpgsqlTypes.NpgsqlDbType.Text, 0, "c6", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c7", NpgsqlTypes.NpgsqlDbType.Text, 0, "c7", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c8", NpgsqlTypes.NpgsqlDbType.Text, 0, "c8", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c9", NpgsqlTypes.NpgsqlDbType.Text, 0, "c9", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c10", NpgsqlTypes.NpgsqlDbType.Text, 0, "c10", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c11", NpgsqlTypes.NpgsqlDbType.Text, 0, "c11", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c12", NpgsqlTypes.NpgsqlDbType.Text, 0, "c12", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c13", NpgsqlTypes.NpgsqlDbType.Text, 0, "c13", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c14", NpgsqlTypes.NpgsqlDbType.Text, 0, "c14", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c15", NpgsqlTypes.NpgsqlDbType.Text, 0, "c15", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c16", NpgsqlTypes.NpgsqlDbType.Text, 0, "c16", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c17", NpgsqlTypes.NpgsqlDbType.Text, 0, "c17", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c18", NpgsqlTypes.NpgsqlDbType.Text, 0, "c18", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c19", NpgsqlTypes.NpgsqlDbType.Text, 0, "c19", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c20", NpgsqlTypes.NpgsqlDbType.Text, 0, "c20", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c21", NpgsqlTypes.NpgsqlDbType.Text, 0, "c21", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c22", NpgsqlTypes.NpgsqlDbType.Text, 0, "c22", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4_array", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4_array", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("req_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "req_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("g_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "g_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("r_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "r_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                            // delete
                            da.DeleteCommand = new NpgsqlCommand
                            (
                                   "delete from t_seikyu"
                                + " where"
                                + " r_id=:r_id;"
                                , m_conn
                            );
                            da.DeleteCommand.Parameters.Add(new NpgsqlParameter("r_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "r_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                            // RowUpdate
                            da.RowUpdated += new NpgsqlRowUpdatedEventHandler(SeikyuRowUpdated);

                            if (_seikyu_ds.Tables["seikyu_ds"] != null)
                                _seikyu_ds.Tables["seikyu_ds"].Clear();
                            da.Fill(_seikyu_ds, "seikyu_ds");

                            bindingSourceSeikyu.DataSource = _seikyu_ds;

                            bindingNavigatorSeikyu.BindingSource = bindingSourceSeikyu;

                            dataGridViewSeikyu.DataSource = bindingSourceSeikyu;

                            dataGridViewSeikyu.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                            bindingNavigatorSeikyu.Visible = true;
                            bindingNavigatorShiharai_houhou.Visible = false;
                            bindingNavigatorShinzoku_kankei.Visible = false;

                            dataGridViewSeikyu.Visible = true;
                            dataGridViewShiharai_houhou.Visible = false;
                            dataGridViewShinzoku_kankei.Visible = false;

                            break;
                    }
                    break;

                // 支払方法
                case 2:
                    switch (cmb_s_id_int)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:

                            Console.WriteLine("Case " + cmb_s_id_int + "!");
                            da.SelectCommand = new NpgsqlCommand
                            (
                                "select"
                                + " c1"
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
                                + ", c23"
                                + ", c24"
                                + ", c25"
                                + ", c26"
                                + ", c27"
                                + ", c28"
                                + ", c29"
                                + ", c30"
                                + ", c31"
                                + ", c32"
                                + ", c33"
                                + ", c34"
                                + ", c35"
                                + ", c36"
                                + ", c37"
                                + ", c38"
                                + ", c39"
                                + ", c40"
                                + ", c41"
                                + ", c42"
                                + ", c43"
                                + ", c44"
                                + ", c45"
                                + ", c46"
                                + ", c47"
                                + ", c48"
                                + ", c49"
                                + ", sh_id"
                                + ", s_id"
                                + ", g_id"
                                + ", p_id"
                                + ", req_id"
                                + ", time_stamp"
                                + ", c4_array"
                                + " from"
                                + " t_shiharai_houhou"
                                + " where time_stamp = (select max(time_stamp) from t_shiharai_houhou"
                                + " where s_id::Integer = " + cmb_s_id_int
                                + " and g_id::Integer = " + cmb_g_id_int
                                + " and o_id::Integer = " + cmb_o_id_int
                                + " and c4_array[1]::text || '/' || c4_array[2]::Text = case when length('" + cmb_tsuki_str + "')=1 then"
                                                + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                                                + "       when length('" + cmb_tsuki_str + "')=2 then"
                                                + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                                                + " end)"
                                + " order by c5;"
                                , m_conn
                            );

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

                            // update
                            da.UpdateCommand = new NpgsqlCommand(
                                    "update t_shiharai_houhou set"
                                    + " c1 = :c1"
                                    + ", c2 = :c2"
                                    + ", c3 = :c3"
                                    + ", c4 = :c4"
                                    + ", c5 = :c5"
                                    + ", c6 = :c6"
                                    + ", c7 = :c7"
                                    + ", c8 = :c8"
                                    + ", c9 = :c9"
                                    + ", c10 = :c10"
                                    + ", c11 = :c11"
                                    + ", c12 = :c12"
                                    + ", c13 = :c13"
                                    + ", c14 = :c14"
                                    + ", c15 = :c15"
                                    + ", c16 = :c16"
                                    + ", c17 = :c17"
                                    + ", c18 = :c18"
                                    + ", c19 = :c19"
                                    + ", c20 = :c20"
                                    + ", c21 = :c21"
                                    + ", c22 = :c22"
                                    + ", c23 = :c23"
                                    + ", c24 = :c24"
                                    + ", c25 = :c25"
                                    + ", c26 = :c26"
                                    + ", c27 = :c27"
                                    + ", c28 = :c28"
                                    + ", c29 = :c29"
                                    + ", c30 = :c30"
                                    + ", c31 = :c31"
                                    + ", c32 = :c32"
                                    + ", c33 = :c33"
                                    + ", c34 = :c34"
                                    + ", c35 = :c35"
                                    + ", c36 = :c36"
                                    + ", c37 = :c37"
                                    + ", c38 = :c38"
                                    + ", c39 = :c39"
                                    + ", c40 = :c40"
                                    + ", c41 = :c41"
                                    + ", c42 = :c42"
                                    + ", c43 = :c43"
                                    + ", c44 = :c44"
                                    + ", c45 = :c45"
                                    + ", c46 = :c46"
                                    + ", c47 = :c47"
                                    + ", c48 = :c48"
                                    + ", c49 = :c49"
                                    + ", s_id = :s_id"
                                    + ", g_id = :g_id"
                                    + ", p_id = :p_id"
                                    + ", req_id = :req_id"
                                    + ", c4_array = :c4_array"
                                    + " where sh_id=:sh_id;"
                                , m_conn
                                );
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c1", NpgsqlTypes.NpgsqlDbType.Text, 0, "c1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c2", NpgsqlTypes.NpgsqlDbType.Text, 0, "c2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c3", NpgsqlTypes.NpgsqlDbType.Text, 0, "c3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c5", NpgsqlTypes.NpgsqlDbType.Text, 0, "c5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c6", NpgsqlTypes.NpgsqlDbType.Text, 0, "c6", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c7", NpgsqlTypes.NpgsqlDbType.Text, 0, "c7", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c8", NpgsqlTypes.NpgsqlDbType.Text, 0, "c8", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c9", NpgsqlTypes.NpgsqlDbType.Text, 0, "c9", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c10", NpgsqlTypes.NpgsqlDbType.Text, 0, "c10", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c11", NpgsqlTypes.NpgsqlDbType.Text, 0, "c11", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c12", NpgsqlTypes.NpgsqlDbType.Text, 0, "c12", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c13", NpgsqlTypes.NpgsqlDbType.Text, 0, "c13", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c14", NpgsqlTypes.NpgsqlDbType.Text, 0, "c14", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c15", NpgsqlTypes.NpgsqlDbType.Text, 0, "c15", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c16", NpgsqlTypes.NpgsqlDbType.Text, 0, "c16", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c17", NpgsqlTypes.NpgsqlDbType.Text, 0, "c17", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c18", NpgsqlTypes.NpgsqlDbType.Text, 0, "c18", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c19", NpgsqlTypes.NpgsqlDbType.Text, 0, "c19", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c20", NpgsqlTypes.NpgsqlDbType.Text, 0, "c20", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c21", NpgsqlTypes.NpgsqlDbType.Text, 0, "c21", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c22", NpgsqlTypes.NpgsqlDbType.Text, 0, "c22", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c23", NpgsqlTypes.NpgsqlDbType.Text, 0, "c23", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c24", NpgsqlTypes.NpgsqlDbType.Text, 0, "c24", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c25", NpgsqlTypes.NpgsqlDbType.Text, 0, "c25", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c26", NpgsqlTypes.NpgsqlDbType.Text, 0, "c26", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c27", NpgsqlTypes.NpgsqlDbType.Text, 0, "c27", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c28", NpgsqlTypes.NpgsqlDbType.Text, 0, "c28", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c29", NpgsqlTypes.NpgsqlDbType.Text, 0, "c29", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c30", NpgsqlTypes.NpgsqlDbType.Text, 0, "c30", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c31", NpgsqlTypes.NpgsqlDbType.Text, 0, "c31", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c32", NpgsqlTypes.NpgsqlDbType.Text, 0, "c32", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c33", NpgsqlTypes.NpgsqlDbType.Text, 0, "c33", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c34", NpgsqlTypes.NpgsqlDbType.Text, 0, "c34", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c35", NpgsqlTypes.NpgsqlDbType.Text, 0, "c35", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c36", NpgsqlTypes.NpgsqlDbType.Text, 0, "c36", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c37", NpgsqlTypes.NpgsqlDbType.Text, 0, "c37", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c38", NpgsqlTypes.NpgsqlDbType.Text, 0, "c38", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c39", NpgsqlTypes.NpgsqlDbType.Text, 0, "c39", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c40", NpgsqlTypes.NpgsqlDbType.Text, 0, "c40", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c41", NpgsqlTypes.NpgsqlDbType.Text, 0, "c41", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c42", NpgsqlTypes.NpgsqlDbType.Text, 0, "c42", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c43", NpgsqlTypes.NpgsqlDbType.Text, 0, "c43", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c44", NpgsqlTypes.NpgsqlDbType.Text, 0, "c44", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c45", NpgsqlTypes.NpgsqlDbType.Text, 0, "c45", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c46", NpgsqlTypes.NpgsqlDbType.Text, 0, "c46", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c47", NpgsqlTypes.NpgsqlDbType.Text, 0, "c47", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c48", NpgsqlTypes.NpgsqlDbType.Text, 0, "c48", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c49", NpgsqlTypes.NpgsqlDbType.Text, 0, "c49", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("g_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "g_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("p_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "p_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("req_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "req_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4_array", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4_array", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("sh_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "sh_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                            // delete
                            da.DeleteCommand = new NpgsqlCommand
                            (
                                   "delete from t_shiharai_houhou"
                                + " where"
                                + " sh_id=:sh_id;"
                                , m_conn
                            );
                            da.DeleteCommand.Parameters.Add(new NpgsqlParameter("sh_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "sh_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                            // RowUpdate
                            da.RowUpdated += new NpgsqlRowUpdatedEventHandler(SeikyuRowUpdated);

                            if (_shiharai_houhou_ds.Tables["shiharai_houhou_ds"] != null)
                                _shiharai_houhou_ds.Tables["shiharai_houhou_ds"].Clear();
                            da.Fill(_shiharai_houhou_ds, "shiharai_houhou_ds");

                            bindingSourceShiharai_houhou.DataSource = _shiharai_houhou_ds;

                            bindingNavigatorShiharai_houhou.BindingSource = bindingSourceShiharai_houhou;

                            dataGridViewShiharai_houhou.DataSource = bindingSourceShiharai_houhou;

                            dataGridViewShiharai_houhou.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                            bindingNavigatorSeikyu.Visible = false;
                            bindingNavigatorShiharai_houhou.Visible = true;
                            bindingNavigatorShinzoku_kankei.Visible = false;

                            dataGridViewSeikyu.Visible = false;
                            dataGridViewShiharai_houhou.Visible = true;
                            dataGridViewShinzoku_kankei.Visible = false;

                            break;
                    }
                    break;

                // 親族関係
                case 3:
                    switch (cmb_s_id_int)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:

                            //MessageBox.Show("Case " + cmb_s_id_int + "!");
                            Console.WriteLine("Case " + cmb_s_id_int + "!");
                            da.SelectCommand = new NpgsqlCommand
                            (
                                "select"
                                + " c1"
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
                                + ", c23"
                                + ", c24"
                                + ", c25"
                                + ", c26"
                                + ", c27"
                                + ", c28"
                                + ", c29"
                                + ", c30"
                                + ", c31"
                                + ", c32"
                                + ", c33"
                                + ", c34"
                                + ", c35"
                                + ", c36"
                                + ", c37"
                                + ", c38"
                                + ", c39"
                                + ", c40"
                                + ", c41"
                                + ", c42"
                                + ", c43"
                                + ", c44"
                                + ", c45"
                                + ", c46"
                                + ", c47"
                                + ", c48"
                                + ", c49"
                                + ", c50"
                                + ", c51"
                                + ", c52"
                                + ", c53"
                                + ", c54"
                                + ", c55"
                                + ", c56"
                                + ", c57"
                                + ", c58"
                                + ", sk_id"
                                + ", s_id"
                                + ", g_id"
                                + ", o_id"
                                + ", p_id"
                                + ", req_id"
                                + ", time_stamp"
                                + ", c4_array"
                                + " from"
                                + " t_shinzoku_kankei"
                                + " where time_stamp = (select max(time_stamp) from t_shinzoku_kankei"
                                + " where s_id::Integer = " + cmb_s_id_int
                                + " and g_id::Integer = " + cmb_g_id_int
                                + " and o_id::Integer = " + cmb_o_id_int
                                + " and c4_array[1]::text || '/' || c4_array[2]::Text = case when length('" + cmb_tsuki_str + "')=1 then"
                                                + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                                                + "       when length('" + cmb_tsuki_str + "')=2 then"
                                                + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                                                + " end"
                                + ")"
                                + " order by c5"
                                , m_conn
                            );

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

                            // update
                            da.UpdateCommand = new NpgsqlCommand(
                                    "update t_shinzoku_kankei set"
                                + " c1 = :c1"
                                + ", c2 = :c2"
                                + ", c3 = :c3"
                                + ", c4 = :c4"
                                + ", c5 = :c5"
                                + ", c6 = :c6"
                                + ", c7 = :c7"
                                + ", c8 = :c8"
                                + ", c9 = :c9"
                                + ", c10 = :c10"
                                + ", c11 = :c11"
                                + ", c12 = :c12"
                                + ", c13 = :c13"
                                + ", c14 = :c14"
                                + ", c15 = :c15"
                                + ", c16 = :c16"
                                + ", c17 = :c17"
                                + ", c18 = :c18"
                                + ", c19 = :c19"
                                + ", c20 = :c20"
                                + ", c21 = :c21"
                                + ", c22 = :c22"
                                + ", c23 = :c23"
                                + ", c24 = :c24"
                                + ", c25 = :c25"
                                + ", c26 = :c26"
                                + ", c27 = :c27"
                                + ", c28 = :c28"
                                + ", c29 = :c29"
                                + ", c30 = :c30"
                                + ", c31 = :c31"
                                + ", c32 = :c32"
                                + ", c33 = :c33"
                                + ", c34 = :c34"
                                + ", c35 = :c35"
                                + ", c36 = :c36"
                                + ", c37 = :c37"
                                + ", c38 = :c38"
                                + ", c39 = :c39"
                                + ", c40 = :c40"
                                + ", c41 = :c41"
                                + ", c42 = :c42"
                                + ", c43 = :c43"
                                + ", c44 = :c44"
                                + ", c45 = :c45"
                                + ", c46 = :c46"
                                + ", c47 = :c47"
                                + ", c48 = :c48"
                                + ", c49 = :c49"
                                + ", c50 = :c50"
                                + ", c51 = :c51"
                                + ", c52 = :c52"
                                + ", c53 = :c53"
                                + ", c54 = :c54"
                                + ", c55 = :c55"
                                + ", c56 = :c56"
                                + ", c57 = :c57"
                                + ", c58 = :c58"
                                + ", s_id = :s_id"
                                + ", g_id = :g_id"
                                + ", o_id = :o_id"
                                + ", p_id = :p_id"
                                + ", req_id = :req_id"
                                + ", c4_array = :c4_array"
                                + " where sk_id=:sk_id;"
                                , m_conn
                                );
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c1", NpgsqlTypes.NpgsqlDbType.Text, 0, "c1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c2", NpgsqlTypes.NpgsqlDbType.Text, 0, "c2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c3", NpgsqlTypes.NpgsqlDbType.Text, 0, "c3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c5", NpgsqlTypes.NpgsqlDbType.Text, 0, "c5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c6", NpgsqlTypes.NpgsqlDbType.Text, 0, "c6", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c7", NpgsqlTypes.NpgsqlDbType.Text, 0, "c7", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c8", NpgsqlTypes.NpgsqlDbType.Text, 0, "c8", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c9", NpgsqlTypes.NpgsqlDbType.Text, 0, "c9", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c10", NpgsqlTypes.NpgsqlDbType.Text, 0, "c10", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c11", NpgsqlTypes.NpgsqlDbType.Text, 0, "c11", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c12", NpgsqlTypes.NpgsqlDbType.Text, 0, "c12", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c13", NpgsqlTypes.NpgsqlDbType.Text, 0, "c13", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c14", NpgsqlTypes.NpgsqlDbType.Text, 0, "c14", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c15", NpgsqlTypes.NpgsqlDbType.Text, 0, "c15", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c16", NpgsqlTypes.NpgsqlDbType.Text, 0, "c16", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c17", NpgsqlTypes.NpgsqlDbType.Text, 0, "c17", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c18", NpgsqlTypes.NpgsqlDbType.Text, 0, "c18", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c19", NpgsqlTypes.NpgsqlDbType.Text, 0, "c19", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c20", NpgsqlTypes.NpgsqlDbType.Text, 0, "c20", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c21", NpgsqlTypes.NpgsqlDbType.Text, 0, "c21", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c22", NpgsqlTypes.NpgsqlDbType.Text, 0, "c22", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c23", NpgsqlTypes.NpgsqlDbType.Text, 0, "c23", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c24", NpgsqlTypes.NpgsqlDbType.Text, 0, "c24", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c25", NpgsqlTypes.NpgsqlDbType.Text, 0, "c25", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c26", NpgsqlTypes.NpgsqlDbType.Text, 0, "c26", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c27", NpgsqlTypes.NpgsqlDbType.Text, 0, "c27", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c28", NpgsqlTypes.NpgsqlDbType.Text, 0, "c28", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c29", NpgsqlTypes.NpgsqlDbType.Text, 0, "c29", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c30", NpgsqlTypes.NpgsqlDbType.Text, 0, "c30", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c31", NpgsqlTypes.NpgsqlDbType.Text, 0, "c31", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c32", NpgsqlTypes.NpgsqlDbType.Text, 0, "c32", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c33", NpgsqlTypes.NpgsqlDbType.Text, 0, "c33", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c34", NpgsqlTypes.NpgsqlDbType.Text, 0, "c34", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c35", NpgsqlTypes.NpgsqlDbType.Text, 0, "c35", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c36", NpgsqlTypes.NpgsqlDbType.Text, 0, "c36", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c37", NpgsqlTypes.NpgsqlDbType.Text, 0, "c37", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c38", NpgsqlTypes.NpgsqlDbType.Text, 0, "c38", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c39", NpgsqlTypes.NpgsqlDbType.Text, 0, "c39", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c40", NpgsqlTypes.NpgsqlDbType.Text, 0, "c40", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c41", NpgsqlTypes.NpgsqlDbType.Text, 0, "c41", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c42", NpgsqlTypes.NpgsqlDbType.Text, 0, "c42", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c43", NpgsqlTypes.NpgsqlDbType.Text, 0, "c43", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c44", NpgsqlTypes.NpgsqlDbType.Text, 0, "c44", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c45", NpgsqlTypes.NpgsqlDbType.Text, 0, "c45", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c46", NpgsqlTypes.NpgsqlDbType.Text, 0, "c46", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c47", NpgsqlTypes.NpgsqlDbType.Text, 0, "c47", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c48", NpgsqlTypes.NpgsqlDbType.Text, 0, "c48", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c49", NpgsqlTypes.NpgsqlDbType.Text, 0, "c49", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c50", NpgsqlTypes.NpgsqlDbType.Text, 0, "c50", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c51", NpgsqlTypes.NpgsqlDbType.Text, 0, "c51", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c52", NpgsqlTypes.NpgsqlDbType.Text, 0, "c52", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c53", NpgsqlTypes.NpgsqlDbType.Text, 0, "c53", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c54", NpgsqlTypes.NpgsqlDbType.Text, 0, "c54", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c55", NpgsqlTypes.NpgsqlDbType.Text, 0, "c55", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c56", NpgsqlTypes.NpgsqlDbType.Text, 0, "c56", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c57", NpgsqlTypes.NpgsqlDbType.Text, 0, "c57", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c58", NpgsqlTypes.NpgsqlDbType.Text, 0, "c58", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("g_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "g_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("p_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "p_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("req_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "req_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4_array", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4_array", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("sk_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "sk_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                            // delete
                            da.DeleteCommand = new NpgsqlCommand
                            (
                                   "delete from t_shinzoku_kankei"
                                + " where"
                                + " sk_id=:sk_id;"
                                , m_conn
                            );
                            da.DeleteCommand.Parameters.Add(new NpgsqlParameter("sk_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "sk_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                            // RowUpdate
                            da.RowUpdated += new NpgsqlRowUpdatedEventHandler(SeikyuRowUpdated);

                            if (_shinzoku_kankei_ds.Tables["shinzoku_kankei_ds"] != null)
                                _shinzoku_kankei_ds.Tables["shinzoku_kankei_ds"].Clear();
                            da.Fill(_shinzoku_kankei_ds, "shinzoku_kankei_ds");

                            bindingSourceShinzoku_kankei.DataSource = _shinzoku_kankei_ds;

                            bindingNavigatorShinzoku_kankei.BindingSource = bindingSourceShinzoku_kankei;

                            dataGridViewShinzoku_kankei.DataSource = bindingSourceShinzoku_kankei;

                            dataGridViewShinzoku_kankei.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                            bindingNavigatorSeikyu.Visible = false;
                            bindingNavigatorShiharai_houhou.Visible = false;
                            bindingNavigatorShinzoku_kankei.Visible = true;

                            dataGridViewSeikyu.Visible = false;
                            dataGridViewShiharai_houhou.Visible = false;
                            dataGridViewShinzoku_kankei.Visible = true;

                            break;
                    }
                    break;
            }
        }

        private void cmdSyubetsu_Click(object sender, EventArgs e)
        {
            Form_syubetsu Form = new Form_syubetsu();
            Form.WindowState = FormWindowState.Maximized;
            Form.ShowDialog();
        }

        private void cmdNenMod_Click(object sender, EventArgs e)
        {
            Form_nen Form = new Form_nen();
            Form.WindowState = FormWindowState.Maximized;
            Form.ShowDialog();

        }

        private void cmdGyoumu_Click(object sender, EventArgs e)
        {
            Form_gyoumu Form = new Form_gyoumu();
            Form.WindowState = FormWindowState.Maximized;
            Form.ShowDialog();

        }

        private void cmb_o_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_o_id_int = cmb_o_id.SelectedIndex + 1;
            Console.WriteLine("cmb_o_id_int = " + cmb_o_id_int);

            s_id_da.SelectCommand = new NpgsqlCommand
            (
                   "select"
                + " s_id"
                + ", syubetsu"
                + ", shisetsumei"
                + ", o_id"
                + " from"
                + " t_syubetsu"
                + " where o_id = '" + cmb_o_id_int + "'"
                + " order by s_id;",
                    m_conn
            );

            if (s_id_ds.Tables["t_syubetsu"] != null)
                s_id_ds.Tables["t_syubetsu"].Clear();
            s_id_da.Fill(s_id_ds, "t_syubetsu");


            cmb_s_id_int = cmb_s_id.SelectedIndex + 1;
            Console.WriteLine("cmb_s_id_int = " + cmb_s_id_int);

            cmb_s_id_str = cmb_s_id.Text;
            Console.WriteLine("cmb_s_id_str = " + cmb_s_id_str);
            textBox1.Text = cmb_s_id_str;


            switch (cmb_g_id_int)
            {
                case 1:
                    switch (cmb_s_id_int)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:

                            tblStr = " t_seikyu";
                            Console.WriteLine("tblStr = " + tblStr);
                            dataGridViewSeikyu.Columns[0].HeaderText = "利用者番号";
                            dataGridViewSeikyu.Columns[1].HeaderText = "要介護度";
                            dataGridViewSeikyu.Columns[2].HeaderText = "利用者名";
                            dataGridViewSeikyu.Columns[3].HeaderText = "提供月";
                            dataGridViewSeikyu.Columns[4].HeaderText = "合計額";
                            dataGridViewSeikyu.Columns[5].HeaderText = "サービス費（保険請求）";
                            dataGridViewSeikyu.Columns[6].HeaderText = "サービス費（公費請求）";
                            dataGridViewSeikyu.Columns[7].HeaderText = "食費（保険請求）";
                            dataGridViewSeikyu.Columns[8].HeaderText = "食費（公費請求）";
                            dataGridViewSeikyu.Columns[9].HeaderText = "居住費（保険請求）";
                            dataGridViewSeikyu.Columns[10].HeaderText = "居住費（公費請求）";
                            dataGridViewSeikyu.Columns[11].HeaderText = "介護請求合計額";
                            dataGridViewSeikyu.Columns[12].HeaderText = "利用者負担額";
                            dataGridViewSeikyu.Columns[13].HeaderText = "自費負担額";
                            dataGridViewSeikyu.Columns[14].HeaderText = "食事負担額";
                            dataGridViewSeikyu.Columns[15].HeaderText = "室料負担額";
                            dataGridViewSeikyu.Columns[16].HeaderText = "特定公費本人支払";
                            dataGridViewSeikyu.Columns[17].HeaderText = "高額介護超過額";
                            dataGridViewSeikyu.Columns[18].HeaderText = "その他実費";
                            dataGridViewSeikyu.Columns[19].HeaderText = "減免額";
                            dataGridViewSeikyu.Columns[20].HeaderText = "過入金";
                            dataGridViewSeikyu.Columns[21].HeaderText = "利用料請求合計額";
                            dataGridViewSeikyu.Columns[21].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("ja-JP");
                            dataGridViewSeikyu.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                            for (int i = 0; i < dataGridViewSeikyu.Columns.Count; i++)
                            {
                                if (i < 1 || i > 3)
                                {
                                    dataGridViewSeikyu.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    dataGridViewSeikyu.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    dataGridViewSeikyu.Columns[i].DefaultCellStyle.Format = "#,0";
                                }
                                else
                                {
                                    dataGridViewSeikyu.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    dataGridViewSeikyu.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                                }
                            }

                            break;
                    }
                    break;
                case 2:
                    switch (cmb_s_id_int)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:

                            tblStr = "t_shiharai_houhou";
                            Console.WriteLine("tblStr = " + tblStr);
                            dataGridViewShiharai_houhou.Columns[0].HeaderText = "法人名";
                            dataGridViewShiharai_houhou.Columns[1].HeaderText = "施設名";
                            dataGridViewShiharai_houhou.Columns[2].HeaderText = "事業所番号";
                            dataGridViewShiharai_houhou.Columns[3].HeaderText = "事業所名";
                            dataGridViewShiharai_houhou.Columns[4].HeaderText = "利用者番号";
                            dataGridViewShiharai_houhou.Columns[5].HeaderText = "利用者名";
                            dataGridViewShiharai_houhou.Columns[6].HeaderText = "支払方法";
                            dataGridViewShiharai_houhou.Columns[7].HeaderText = "引落口座";
                            dataGridViewShiharai_houhou.Columns[8].HeaderText = "引落金融機関銀行コード";
                            dataGridViewShiharai_houhou.Columns[9].HeaderText = "引落金融機関銀行名（フリガナ）";
                            dataGridViewShiharai_houhou.Columns[10].HeaderText = "引落金融機関銀行名";
                            dataGridViewShiharai_houhou.Columns[11].HeaderText = "引落金融機関支店コード";
                            dataGridViewShiharai_houhou.Columns[12].HeaderText = "引落金融機関支店名（フリガナ）";
                            dataGridViewShiharai_houhou.Columns[13].HeaderText = "引落金融機関支店名";
                            dataGridViewShiharai_houhou.Columns[14].HeaderText = "引落口座種別";
                            dataGridViewShiharai_houhou.Columns[15].HeaderText = "引落口座番号";
                            dataGridViewShiharai_houhou.Columns[16].HeaderText = "引落口座名義人区分";
                            dataGridViewShiharai_houhou.Columns[17].HeaderText = "引落口座名義人（フリガナ）";
                            dataGridViewShiharai_houhou.Columns[18].HeaderText = "引落口座名義人";
                            dataGridViewShiharai_houhou.Columns[19].HeaderText = "引落口座開設日";
                            dataGridViewShiharai_houhou.Columns[20].HeaderText = "引落口座解約日";
                            dataGridViewShiharai_houhou.Columns[21].HeaderText = "引落口座メモ";
                            dataGridViewShiharai_houhou.Columns[22].HeaderText = "振込先委託者名（フリガナ）";
                            dataGridViewShiharai_houhou.Columns[23].HeaderText = "振込先委託者名";
                            dataGridViewShiharai_houhou.Columns[24].HeaderText = "振込先委託者コード";
                            dataGridViewShiharai_houhou.Columns[25].HeaderText = "振込先金融機関銀行コード";
                            dataGridViewShiharai_houhou.Columns[26].HeaderText = "振込先金融機関銀行名（フリガナ）";
                            dataGridViewShiharai_houhou.Columns[27].HeaderText = "振込先金融機関銀行名";
                            dataGridViewShiharai_houhou.Columns[28].HeaderText = "振込先金融機関支店コード";
                            dataGridViewShiharai_houhou.Columns[29].HeaderText = "振込先金融機関支店名（フリガナ）";
                            dataGridViewShiharai_houhou.Columns[30].HeaderText = "振込先金融機関支店名";
                            dataGridViewShiharai_houhou.Columns[31].HeaderText = "振込先口座種別";
                            dataGridViewShiharai_houhou.Columns[32].HeaderText = "振込先口座番号";
                            dataGridViewShiharai_houhou.Columns[33].HeaderText = "振込先口座記号";
                            dataGridViewShiharai_houhou.Columns[34].HeaderText = "振込先引落日";
                            dataGridViewShiharai_houhou.Columns[35].HeaderText = "振込先再振替日";
                            dataGridViewShiharai_houhou.Columns[36].HeaderText = "振込先契約種別コード";
                            dataGridViewShiharai_houhou.Columns[37].HeaderText = "振込先受入事業所センターコード";
                            dataGridViewShiharai_houhou.Columns[38].HeaderText = "振込先手数料：自行";
                            dataGridViewShiharai_houhou.Columns[39].HeaderText = "振込先手数料：他行";
                            dataGridViewShiharai_houhou.Columns[40].HeaderText = "初回引落月";
                            dataGridViewShiharai_houhou.Columns[41].HeaderText = "顧客番号";
                            dataGridViewShiharai_houhou.Columns[42].HeaderText = "被保険者番号";
                            dataGridViewShiharai_houhou.Columns[43].HeaderText = "被保険者氏名";
                            dataGridViewShiharai_houhou.Columns[44].HeaderText = "預金者郵便番号";
                            dataGridViewShiharai_houhou.Columns[45].HeaderText = "預金者氏名";
                            dataGridViewShiharai_houhou.Columns[46].HeaderText = "預金者住所１";
                            dataGridViewShiharai_houhou.Columns[47].HeaderText = "預金者住所２";
                            dataGridViewShiharai_houhou.Columns[48].HeaderText = "預金者住所３";

                            for (int i = 0; i < dataGridViewShiharai_houhou.Columns.Count; i++)
                            {
                                dataGridViewShiharai_houhou.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                dataGridViewShiharai_houhou.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            }

                            break;
                    }
                    break;
                case 3:
                    switch (cmb_s_id_int)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:

                            tblStr = " t_shinzoku_kankei";
                            Console.WriteLine("tblStr = " + tblStr);
                            dataGridViewShinzoku_kankei.Columns[0].HeaderText = "利用者番号";
                            dataGridViewShinzoku_kankei.Columns[1].HeaderText = "利用者名（姓）";
                            dataGridViewShinzoku_kankei.Columns[2].HeaderText = "利用者名（名）";
                            dataGridViewShinzoku_kankei.Columns[3].HeaderText = "利用者名";
                            dataGridViewShinzoku_kankei.Columns[4].HeaderText = "フリガナ（姓）";
                            dataGridViewShinzoku_kankei.Columns[5].HeaderText = "フリガナ（名）";
                            dataGridViewShinzoku_kankei.Columns[6].HeaderText = "フリガナ";
                            dataGridViewShinzoku_kankei.Columns[7].HeaderText = "同名識別";
                            dataGridViewShinzoku_kankei.Columns[8].HeaderText = "性別";
                            dataGridViewShinzoku_kankei.Columns[9].HeaderText = "血液型";
                            dataGridViewShinzoku_kankei.Columns[10].HeaderText = "RH";
                            dataGridViewShinzoku_kankei.Columns[11].HeaderText = "生年月日";
                            dataGridViewShinzoku_kankei.Columns[12].HeaderText = "郵便番号";
                            dataGridViewShinzoku_kankei.Columns[13].HeaderText = "住所";
                            dataGridViewShinzoku_kankei.Columns[14].HeaderText = "電話番号";
                            dataGridViewShinzoku_kankei.Columns[15].HeaderText = "携帯番号";
                            dataGridViewShinzoku_kankei.Columns[16].HeaderText = "E-mail";
                            dataGridViewShinzoku_kankei.Columns[17].HeaderText = "郵便番号（他の住所）";
                            dataGridViewShinzoku_kankei.Columns[18].HeaderText = "住所（他の住所）";
                            dataGridViewShinzoku_kankei.Columns[19].HeaderText = "世帯区分";
                            dataGridViewShinzoku_kankei.Columns[20].HeaderText = "メモ";
                            dataGridViewShinzoku_kankei.Columns[21].HeaderText = "統計用住所";
                            dataGridViewShinzoku_kankei.Columns[22].HeaderText = "親族・関係者名（姓）";
                            dataGridViewShinzoku_kankei.Columns[23].HeaderText = "親族・関係者名（名）";
                            dataGridViewShinzoku_kankei.Columns[24].HeaderText = "親族・関係者名";
                            dataGridViewShinzoku_kankei.Columns[25].HeaderText = "フリガナ（姓）（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[26].HeaderText = "フリガナ（名）（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[27].HeaderText = "フリガナ（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[28].HeaderText = "性別（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[29].HeaderText = "生年月日（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[30].HeaderText = "続柄";
                            dataGridViewShinzoku_kankei.Columns[31].HeaderText = "健康状態";
                            dataGridViewShinzoku_kankei.Columns[32].HeaderText = "職業";
                            dataGridViewShinzoku_kankei.Columns[33].HeaderText = "〒（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[34].HeaderText = "住所（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[35].HeaderText = "住所（地域）（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[36].HeaderText = "宛先";
                            dataGridViewShinzoku_kankei.Columns[37].HeaderText = "電話番号（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[38].HeaderText = "携帯番号（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[39].HeaderText = "E-mail（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[40].HeaderText = "連絡先種別";
                            dataGridViewShinzoku_kankei.Columns[41].HeaderText = "連絡先番号";
                            dataGridViewShinzoku_kankei.Columns[42].HeaderText = "優先順";
                            dataGridViewShinzoku_kankei.Columns[43].HeaderText = "申請者";
                            dataGridViewShinzoku_kankei.Columns[44].HeaderText = "同居家族";
                            dataGridViewShinzoku_kankei.Columns[45].HeaderText = "主介護者";
                            dataGridViewShinzoku_kankei.Columns[46].HeaderText = "保証人";
                            dataGridViewShinzoku_kankei.Columns[47].HeaderText = "支払者";
                            dataGridViewShinzoku_kankei.Columns[48].HeaderText = "相談者";
                            dataGridViewShinzoku_kankei.Columns[49].HeaderText = "（未使用1）";
                            dataGridViewShinzoku_kankei.Columns[50].HeaderText = "（未使用2）";
                            dataGridViewShinzoku_kankei.Columns[51].HeaderText = "（未使用3）";
                            dataGridViewShinzoku_kankei.Columns[52].HeaderText = "（未使用4）";
                            dataGridViewShinzoku_kankei.Columns[53].HeaderText = "メモ（親族・関係者）";
                            dataGridViewShinzoku_kankei.Columns[54].HeaderText = "面会";
                            dataGridViewShinzoku_kankei.Columns[55].HeaderText = "郵便番号（連絡先住所）";
                            dataGridViewShinzoku_kankei.Columns[56].HeaderText = "住所（連絡先住所）";
                            dataGridViewShinzoku_kankei.Columns[57].HeaderText = "FAX番号";

                            for (int i = 0; i < dataGridViewShinzoku_kankei.Columns.Count; i++)
                            {
                                dataGridViewShinzoku_kankei.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                dataGridViewShinzoku_kankei.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            }

                            break;
                    }
                    break;
            }

            // 再表示
            switch (cmb_o_id_int)
            {
                case 1:
                    switch (cmb_g_id_int)
                    {
                        case 1:
                            switch (cmb_s_id_int)
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:

                                    Console.WriteLine("Case " + cmb_s_id_int + "!");
                                    da.SelectCommand = new NpgsqlCommand
                                    (
                                        "select"
                                        + " c1"
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
                                        + ", c4_array"
                                        + ", time_stamp"
                                        + ", r_id"
                                        + ", s_id"
                                        + ", g_id"
                                        + ", o_id"
                                        + ", id"
                                        + ", p_id"
                                        + ", req_id"
                                        + " from"
                                        + " t_seikyu"
                                        + " where time_stamp = (select max(time_stamp) from t_seikyu"
                                        + " where s_id::Integer = " + cmb_s_id_int
                                        + " and g_id::Integer = " + cmb_g_id_int
                                        + " and o_id::Integer = " + cmb_o_id_int
                                        + " and c4_array[1]::text || '/' || c4_array[2]::Text = case when length('" + cmb_tsuki_str + "')=1 then"
                                                        + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                                                        + "       when length('" + cmb_tsuki_str + "')=2 then"
                                                        + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                                                        + " end"
                                        + ");"
                                        , m_conn
                                    );

                                    if (cmb_c4.SelectedItem == null)
                                    {
                                        da.SelectCommand.Parameters.Add(new NpgsqlParameter("c4",
                                        NpgsqlTypes.NpgsqlDbType.Text, 0, "c4",
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

                                    // update
                                    da.UpdateCommand = new NpgsqlCommand(
                                            "update t_seikyu set"
                                            + " c1 = :c1"
                                            + ", c2 = :c2"
                                            + ", c3 = :c3"
                                            + ", c4 = :c4"
                                            + ", c5 = :c5"
                                            + ", c6 = :c6"
                                            + ", c7 = :c7"
                                            + ", c8 = :c8"
                                            + ", c9 = :c9"
                                            + ", c10 = :c10"
                                            + ", c11 = :c11"
                                            + ", c12 = :c12"
                                            + ", c13 = :c13"
                                            + ", c14 = :c14"
                                            + ", c15 = :c15"
                                            + ", c16 = :c16"
                                            + ", c17 = :c17"
                                            + ", c18 = :c18"
                                            + ", c19 = :c19"
                                            + ", c20 = :c20"
                                            + ", c21 = :c21"
                                            + ", c22 = :c22"
                                            + ", c4_array = :c4_array"
                                            + ", id = :id"
                                            + ", req_id = :req_id"
                                            + ", s_id = :s_id"
                                            + ", g_id = :g_id"
                                            + ", o_id = :o_id"
                                            + " where r_id=:r_id;"
                                        , m_conn
                                        );
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c1", NpgsqlTypes.NpgsqlDbType.Text, 0, "c1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c2", NpgsqlTypes.NpgsqlDbType.Text, 0, "c2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c3", NpgsqlTypes.NpgsqlDbType.Text, 0, "c3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c5", NpgsqlTypes.NpgsqlDbType.Text, 0, "c5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c6", NpgsqlTypes.NpgsqlDbType.Text, 0, "c6", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c7", NpgsqlTypes.NpgsqlDbType.Text, 0, "c7", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c8", NpgsqlTypes.NpgsqlDbType.Text, 0, "c8", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c9", NpgsqlTypes.NpgsqlDbType.Text, 0, "c9", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c10", NpgsqlTypes.NpgsqlDbType.Text, 0, "c10", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c11", NpgsqlTypes.NpgsqlDbType.Text, 0, "c11", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c12", NpgsqlTypes.NpgsqlDbType.Text, 0, "c12", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c13", NpgsqlTypes.NpgsqlDbType.Text, 0, "c13", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c14", NpgsqlTypes.NpgsqlDbType.Text, 0, "c14", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c15", NpgsqlTypes.NpgsqlDbType.Text, 0, "c15", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c16", NpgsqlTypes.NpgsqlDbType.Text, 0, "c16", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c17", NpgsqlTypes.NpgsqlDbType.Text, 0, "c17", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c18", NpgsqlTypes.NpgsqlDbType.Text, 0, "c18", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c19", NpgsqlTypes.NpgsqlDbType.Text, 0, "c19", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c20", NpgsqlTypes.NpgsqlDbType.Text, 0, "c20", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c21", NpgsqlTypes.NpgsqlDbType.Text, 0, "c21", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c22", NpgsqlTypes.NpgsqlDbType.Text, 0, "c22", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4_array", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4_array", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("req_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "req_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("g_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "g_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("r_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "r_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                                    // delete
                                    da.DeleteCommand = new NpgsqlCommand
                                    (
                                           "delete from t_seikyu"
                                        + " where"
                                        + " r_id=:r_id;"
                                        , m_conn
                                    );
                                    da.DeleteCommand.Parameters.Add(new NpgsqlParameter("r_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "r_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                                    // RowUpdate
                                    da.RowUpdated += new NpgsqlRowUpdatedEventHandler(SeikyuRowUpdated);

                                    if (_seikyu_ds.Tables["seikyu_ds"] != null)
                                        _seikyu_ds.Tables["seikyu_ds"].Clear();
                                    da.Fill(_seikyu_ds, "seikyu_ds");

                                    bindingSourceSeikyu.DataSource = _seikyu_ds;

                                    bindingNavigatorSeikyu.BindingSource = bindingSourceSeikyu;

                                    dataGridViewSeikyu.DataSource = bindingSourceSeikyu;

                                    dataGridViewSeikyu.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                                    bindingNavigatorSeikyu.Visible = true;
                                    bindingNavigatorShiharai_houhou.Visible = false;
                                    bindingNavigatorShinzoku_kankei.Visible = false;

                                    dataGridViewSeikyu.Visible = true;
                                    dataGridViewShiharai_houhou.Visible = false;
                                    dataGridViewShinzoku_kankei.Visible = false;

                                    break;
                            }
                            break;

                        // 支払方法
                        case 2:
                            switch (cmb_s_id_int)
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:

                                    Console.WriteLine("Case " + cmb_s_id_int + "!");
                                    da.SelectCommand = new NpgsqlCommand
                                    (
                                        "select"
                                        + " c1"
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
                                        + ", c23"
                                        + ", c24"
                                        + ", c25"
                                        + ", c26"
                                        + ", c27"
                                        + ", c28"
                                        + ", c29"
                                        + ", c30"
                                        + ", c31"
                                        + ", c32"
                                        + ", c33"
                                        + ", c34"
                                        + ", c35"
                                        + ", c36"
                                        + ", c37"
                                        + ", c38"
                                        + ", c39"
                                        + ", c40"
                                        + ", c41"
                                        + ", c42"
                                        + ", c43"
                                        + ", c44"
                                        + ", c45"
                                        + ", c46"
                                        + ", c47"
                                        + ", c48"
                                        + ", c49"
                                        + ", sh_id"
                                        + ", s_id"
                                        + ", g_id"
                                        + ", o_id"
                                        + ", p_id"
                                        + ", req_id"
                                        + ", time_stamp"
                                        + ", c4_array"
                                        + " from"
                                        + " t_shiharai_houhou"
                                        + " where time_stamp = (select max(time_stamp) from t_shiharai_houhou"
                                        + " where s_id::Integer = " + cmb_s_id_int
                                        + " and g_id::Integer = " + cmb_g_id_int
                                        + " and o_id::Integer = " + cmb_o_id_int
                                        + " and c4_array[1]::text || '/' || c4_array[2]::Text = case when length('" + cmb_tsuki_str + "')=1 then"
                                                        + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                                                        + "       when length('" + cmb_tsuki_str + "')=2 then"
                                                        + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                                                        + " end)"
                                        + " order by c5;"
                                        , m_conn
                                    );

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

                                    // update
                                    da.UpdateCommand = new NpgsqlCommand(
                                            "update t_shiharai_houhou set"
                                            + " c1 = :c1"
                                            + ", c2 = :c2"
                                            + ", c3 = :c3"
                                            + ", c4 = :c4"
                                            + ", c5 = :c5"
                                            + ", c6 = :c6"
                                            + ", c7 = :c7"
                                            + ", c8 = :c8"
                                            + ", c9 = :c9"
                                            + ", c10 = :c10"
                                            + ", c11 = :c11"
                                            + ", c12 = :c12"
                                            + ", c13 = :c13"
                                            + ", c14 = :c14"
                                            + ", c15 = :c15"
                                            + ", c16 = :c16"
                                            + ", c17 = :c17"
                                            + ", c18 = :c18"
                                            + ", c19 = :c19"
                                            + ", c20 = :c20"
                                            + ", c21 = :c21"
                                            + ", c22 = :c22"
                                            + ", c23 = :c23"
                                            + ", c24 = :c24"
                                            + ", c25 = :c25"
                                            + ", c26 = :c26"
                                            + ", c27 = :c27"
                                            + ", c28 = :c28"
                                            + ", c29 = :c29"
                                            + ", c30 = :c30"
                                            + ", c31 = :c31"
                                            + ", c32 = :c32"
                                            + ", c33 = :c33"
                                            + ", c34 = :c34"
                                            + ", c35 = :c35"
                                            + ", c36 = :c36"
                                            + ", c37 = :c37"
                                            + ", c38 = :c38"
                                            + ", c39 = :c39"
                                            + ", c40 = :c40"
                                            + ", c41 = :c41"
                                            + ", c42 = :c42"
                                            + ", c43 = :c43"
                                            + ", c44 = :c44"
                                            + ", c45 = :c45"
                                            + ", c46 = :c46"
                                            + ", c47 = :c47"
                                            + ", c48 = :c48"
                                            + ", c49 = :c49"
                                            + ", s_id = :s_id"
                                            + ", g_id = :g_id"
                                            + ", o_id = :o_id"
                                            + ", p_id = :p_id"
                                            + ", req_id = :req_id"
                                            + ", c4_array = :c4_array"
                                            + " where sh_id=:sh_id;"
                                        , m_conn
                                        );
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c1", NpgsqlTypes.NpgsqlDbType.Text, 0, "c1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c2", NpgsqlTypes.NpgsqlDbType.Text, 0, "c2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c3", NpgsqlTypes.NpgsqlDbType.Text, 0, "c3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c5", NpgsqlTypes.NpgsqlDbType.Text, 0, "c5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c6", NpgsqlTypes.NpgsqlDbType.Text, 0, "c6", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c7", NpgsqlTypes.NpgsqlDbType.Text, 0, "c7", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c8", NpgsqlTypes.NpgsqlDbType.Text, 0, "c8", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c9", NpgsqlTypes.NpgsqlDbType.Text, 0, "c9", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c10", NpgsqlTypes.NpgsqlDbType.Text, 0, "c10", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c11", NpgsqlTypes.NpgsqlDbType.Text, 0, "c11", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c12", NpgsqlTypes.NpgsqlDbType.Text, 0, "c12", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c13", NpgsqlTypes.NpgsqlDbType.Text, 0, "c13", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c14", NpgsqlTypes.NpgsqlDbType.Text, 0, "c14", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c15", NpgsqlTypes.NpgsqlDbType.Text, 0, "c15", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c16", NpgsqlTypes.NpgsqlDbType.Text, 0, "c16", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c17", NpgsqlTypes.NpgsqlDbType.Text, 0, "c17", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c18", NpgsqlTypes.NpgsqlDbType.Text, 0, "c18", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c19", NpgsqlTypes.NpgsqlDbType.Text, 0, "c19", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c20", NpgsqlTypes.NpgsqlDbType.Text, 0, "c20", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c21", NpgsqlTypes.NpgsqlDbType.Text, 0, "c21", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c22", NpgsqlTypes.NpgsqlDbType.Text, 0, "c22", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c23", NpgsqlTypes.NpgsqlDbType.Text, 0, "c23", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c24", NpgsqlTypes.NpgsqlDbType.Text, 0, "c24", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c25", NpgsqlTypes.NpgsqlDbType.Text, 0, "c25", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c26", NpgsqlTypes.NpgsqlDbType.Text, 0, "c26", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c27", NpgsqlTypes.NpgsqlDbType.Text, 0, "c27", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c28", NpgsqlTypes.NpgsqlDbType.Text, 0, "c28", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c29", NpgsqlTypes.NpgsqlDbType.Text, 0, "c29", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c30", NpgsqlTypes.NpgsqlDbType.Text, 0, "c30", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c31", NpgsqlTypes.NpgsqlDbType.Text, 0, "c31", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c32", NpgsqlTypes.NpgsqlDbType.Text, 0, "c32", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c33", NpgsqlTypes.NpgsqlDbType.Text, 0, "c33", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c34", NpgsqlTypes.NpgsqlDbType.Text, 0, "c34", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c35", NpgsqlTypes.NpgsqlDbType.Text, 0, "c35", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c36", NpgsqlTypes.NpgsqlDbType.Text, 0, "c36", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c37", NpgsqlTypes.NpgsqlDbType.Text, 0, "c37", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c38", NpgsqlTypes.NpgsqlDbType.Text, 0, "c38", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c39", NpgsqlTypes.NpgsqlDbType.Text, 0, "c39", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c40", NpgsqlTypes.NpgsqlDbType.Text, 0, "c40", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c41", NpgsqlTypes.NpgsqlDbType.Text, 0, "c41", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c42", NpgsqlTypes.NpgsqlDbType.Text, 0, "c42", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c43", NpgsqlTypes.NpgsqlDbType.Text, 0, "c43", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c44", NpgsqlTypes.NpgsqlDbType.Text, 0, "c44", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c45", NpgsqlTypes.NpgsqlDbType.Text, 0, "c45", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c46", NpgsqlTypes.NpgsqlDbType.Text, 0, "c46", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c47", NpgsqlTypes.NpgsqlDbType.Text, 0, "c47", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c48", NpgsqlTypes.NpgsqlDbType.Text, 0, "c48", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c49", NpgsqlTypes.NpgsqlDbType.Text, 0, "c49", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("g_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "g_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("p_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "p_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("req_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "req_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4_array", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4_array", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("sh_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "sh_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                                    // delete
                                    da.DeleteCommand = new NpgsqlCommand
                                    (
                                           "delete from t_shiharai_houhou"
                                        + " where"
                                        + " sh_id=:sh_id;"
                                        , m_conn
                                    );
                                    da.DeleteCommand.Parameters.Add(new NpgsqlParameter("sh_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "sh_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                                    // RowUpdate
                                    da.RowUpdated += new NpgsqlRowUpdatedEventHandler(SeikyuRowUpdated);

                                    if (_shiharai_houhou_ds.Tables["shiharai_houhou_ds"] != null)
                                        _shiharai_houhou_ds.Tables["shiharai_houhou_ds"].Clear();
                                    da.Fill(_shiharai_houhou_ds, "shiharai_houhou_ds");

                                    bindingSourceShiharai_houhou.DataSource = _shiharai_houhou_ds;

                                    bindingNavigatorShiharai_houhou.BindingSource = bindingSourceShiharai_houhou;

                                    dataGridViewShiharai_houhou.DataSource = bindingSourceShiharai_houhou;

                                    dataGridViewShiharai_houhou.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                                    bindingNavigatorSeikyu.Visible = false;
                                    bindingNavigatorShiharai_houhou.Visible = true;
                                    bindingNavigatorShinzoku_kankei.Visible = false;

                                    dataGridViewSeikyu.Visible = false;
                                    dataGridViewShiharai_houhou.Visible = true;
                                    dataGridViewShinzoku_kankei.Visible = false;

                                    break;
                            }
                            break;

                        // 親族関係
                        case 3:
                            switch (cmb_s_id_int)
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:

                                    //MessageBox.Show("Case " + cmb_s_id_int + "!");
                                    Console.WriteLine("Case " + cmb_s_id_int + "!");
                                    da.SelectCommand = new NpgsqlCommand
                                    (
                                        "select"
                                        + " c1"
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
                                        + ", c23"
                                        + ", c24"
                                        + ", c25"
                                        + ", c26"
                                        + ", c27"
                                        + ", c28"
                                        + ", c29"
                                        + ", c30"
                                        + ", c31"
                                        + ", c32"
                                        + ", c33"
                                        + ", c34"
                                        + ", c35"
                                        + ", c36"
                                        + ", c37"
                                        + ", c38"
                                        + ", c39"
                                        + ", c40"
                                        + ", c41"
                                        + ", c42"
                                        + ", c43"
                                        + ", c44"
                                        + ", c45"
                                        + ", c46"
                                        + ", c47"
                                        + ", c48"
                                        + ", c49"
                                        + ", c50"
                                        + ", c51"
                                        + ", c52"
                                        + ", c53"
                                        + ", c54"
                                        + ", c55"
                                        + ", c56"
                                        + ", c57"
                                        + ", c58"
                                        + ", sk_id"
                                        + ", s_id"
                                        + ", g_id"
                                        + ", p_id"
                                        + ", req_id"
                                        + ", time_stamp"
                                        + ", c4_array"
                                        + " from"
                                        + " t_shinzoku_kankei"
                                        + " where time_stamp = (select max(time_stamp) from t_shinzoku_kankei"
                                        + " where s_id::Integer = " + cmb_s_id_int
                                        + " and g_id::Integer = " + cmb_g_id_int
                                        + " and o_id::Integer = " + cmb_o_id_int
                                        + " and c4_array[1]::text || '/' || c4_array[2]::Text = case when length('" + cmb_tsuki_str + "')=1 then"
                                                        + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                                                        + "       when length('" + cmb_tsuki_str + "')=2 then"
                                                        + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                                                        + " end"
                                        + ")"
                                        + " order by c5"
                                        , m_conn
                                    );

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

                                    // update
                                    da.UpdateCommand = new NpgsqlCommand(
                                            "update t_shinzoku_kankei set"
                                        + " c1 = :c1"
                                        + ", c2 = :c2"
                                        + ", c3 = :c3"
                                        + ", c4 = :c4"
                                        + ", c5 = :c5"
                                        + ", c6 = :c6"
                                        + ", c7 = :c7"
                                        + ", c8 = :c8"
                                        + ", c9 = :c9"
                                        + ", c10 = :c10"
                                        + ", c11 = :c11"
                                        + ", c12 = :c12"
                                        + ", c13 = :c13"
                                        + ", c14 = :c14"
                                        + ", c15 = :c15"
                                        + ", c16 = :c16"
                                        + ", c17 = :c17"
                                        + ", c18 = :c18"
                                        + ", c19 = :c19"
                                        + ", c20 = :c20"
                                        + ", c21 = :c21"
                                        + ", c22 = :c22"
                                        + ", c23 = :c23"
                                        + ", c24 = :c24"
                                        + ", c25 = :c25"
                                        + ", c26 = :c26"
                                        + ", c27 = :c27"
                                        + ", c28 = :c28"
                                        + ", c29 = :c29"
                                        + ", c30 = :c30"
                                        + ", c31 = :c31"
                                        + ", c32 = :c32"
                                        + ", c33 = :c33"
                                        + ", c34 = :c34"
                                        + ", c35 = :c35"
                                        + ", c36 = :c36"
                                        + ", c37 = :c37"
                                        + ", c38 = :c38"
                                        + ", c39 = :c39"
                                        + ", c40 = :c40"
                                        + ", c41 = :c41"
                                        + ", c42 = :c42"
                                        + ", c43 = :c43"
                                        + ", c44 = :c44"
                                        + ", c45 = :c45"
                                        + ", c46 = :c46"
                                        + ", c47 = :c47"
                                        + ", c48 = :c48"
                                        + ", c49 = :c49"
                                        + ", c50 = :c50"
                                        + ", c51 = :c51"
                                        + ", c52 = :c52"
                                        + ", c53 = :c53"
                                        + ", c54 = :c54"
                                        + ", c55 = :c55"
                                        + ", c56 = :c56"
                                        + ", c57 = :c57"
                                        + ", c58 = :c58"
                                        + ", s_id = :s_id"
                                        + ", g_id = :g_id"
                                        + ", p_id = :p_id"
                                        + ", req_id = :req_id"
                                        + ", c4_array = :c4_array"
                                        + " where sk_id=:sk_id;"
                                        , m_conn
                                        );
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c1", NpgsqlTypes.NpgsqlDbType.Text, 0, "c1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c2", NpgsqlTypes.NpgsqlDbType.Text, 0, "c2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c3", NpgsqlTypes.NpgsqlDbType.Text, 0, "c3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c5", NpgsqlTypes.NpgsqlDbType.Text, 0, "c5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c6", NpgsqlTypes.NpgsqlDbType.Text, 0, "c6", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c7", NpgsqlTypes.NpgsqlDbType.Text, 0, "c7", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c8", NpgsqlTypes.NpgsqlDbType.Text, 0, "c8", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c9", NpgsqlTypes.NpgsqlDbType.Text, 0, "c9", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c10", NpgsqlTypes.NpgsqlDbType.Text, 0, "c10", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c11", NpgsqlTypes.NpgsqlDbType.Text, 0, "c11", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c12", NpgsqlTypes.NpgsqlDbType.Text, 0, "c12", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c13", NpgsqlTypes.NpgsqlDbType.Text, 0, "c13", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c14", NpgsqlTypes.NpgsqlDbType.Text, 0, "c14", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c15", NpgsqlTypes.NpgsqlDbType.Text, 0, "c15", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c16", NpgsqlTypes.NpgsqlDbType.Text, 0, "c16", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c17", NpgsqlTypes.NpgsqlDbType.Text, 0, "c17", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c18", NpgsqlTypes.NpgsqlDbType.Text, 0, "c18", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c19", NpgsqlTypes.NpgsqlDbType.Text, 0, "c19", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c20", NpgsqlTypes.NpgsqlDbType.Text, 0, "c20", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c21", NpgsqlTypes.NpgsqlDbType.Text, 0, "c21", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c22", NpgsqlTypes.NpgsqlDbType.Text, 0, "c22", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c23", NpgsqlTypes.NpgsqlDbType.Text, 0, "c23", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c24", NpgsqlTypes.NpgsqlDbType.Text, 0, "c24", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c25", NpgsqlTypes.NpgsqlDbType.Text, 0, "c25", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c26", NpgsqlTypes.NpgsqlDbType.Text, 0, "c26", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c27", NpgsqlTypes.NpgsqlDbType.Text, 0, "c27", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c28", NpgsqlTypes.NpgsqlDbType.Text, 0, "c28", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c29", NpgsqlTypes.NpgsqlDbType.Text, 0, "c29", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c30", NpgsqlTypes.NpgsqlDbType.Text, 0, "c30", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c31", NpgsqlTypes.NpgsqlDbType.Text, 0, "c31", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c32", NpgsqlTypes.NpgsqlDbType.Text, 0, "c32", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c33", NpgsqlTypes.NpgsqlDbType.Text, 0, "c33", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c34", NpgsqlTypes.NpgsqlDbType.Text, 0, "c34", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c35", NpgsqlTypes.NpgsqlDbType.Text, 0, "c35", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c36", NpgsqlTypes.NpgsqlDbType.Text, 0, "c36", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c37", NpgsqlTypes.NpgsqlDbType.Text, 0, "c37", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c38", NpgsqlTypes.NpgsqlDbType.Text, 0, "c38", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c39", NpgsqlTypes.NpgsqlDbType.Text, 0, "c39", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c40", NpgsqlTypes.NpgsqlDbType.Text, 0, "c40", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c41", NpgsqlTypes.NpgsqlDbType.Text, 0, "c41", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c42", NpgsqlTypes.NpgsqlDbType.Text, 0, "c42", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c43", NpgsqlTypes.NpgsqlDbType.Text, 0, "c43", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c44", NpgsqlTypes.NpgsqlDbType.Text, 0, "c44", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c45", NpgsqlTypes.NpgsqlDbType.Text, 0, "c45", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c46", NpgsqlTypes.NpgsqlDbType.Text, 0, "c46", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c47", NpgsqlTypes.NpgsqlDbType.Text, 0, "c47", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c48", NpgsqlTypes.NpgsqlDbType.Text, 0, "c48", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c49", NpgsqlTypes.NpgsqlDbType.Text, 0, "c49", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c50", NpgsqlTypes.NpgsqlDbType.Text, 0, "c50", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c51", NpgsqlTypes.NpgsqlDbType.Text, 0, "c51", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c52", NpgsqlTypes.NpgsqlDbType.Text, 0, "c52", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c53", NpgsqlTypes.NpgsqlDbType.Text, 0, "c53", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c54", NpgsqlTypes.NpgsqlDbType.Text, 0, "c54", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c55", NpgsqlTypes.NpgsqlDbType.Text, 0, "c55", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c56", NpgsqlTypes.NpgsqlDbType.Text, 0, "c56", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c57", NpgsqlTypes.NpgsqlDbType.Text, 0, "c57", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c58", NpgsqlTypes.NpgsqlDbType.Text, 0, "c58", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("g_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "g_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("p_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "p_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("req_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "req_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4_array", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4_array", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("sk_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "sk_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                                    // delete
                                    da.DeleteCommand = new NpgsqlCommand
                                    (
                                           "delete from t_shinzoku_kankei"
                                        + " where"
                                        + " sk_id=:sk_id;"
                                        , m_conn
                                    );
                                    da.DeleteCommand.Parameters.Add(new NpgsqlParameter("sk_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "sk_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                                    // RowUpdate
                                    da.RowUpdated += new NpgsqlRowUpdatedEventHandler(SeikyuRowUpdated);

                                    if (_shinzoku_kankei_ds.Tables["shinzoku_kankei_ds"] != null)
                                        _shinzoku_kankei_ds.Tables["shinzoku_kankei_ds"].Clear();
                                    da.Fill(_shinzoku_kankei_ds, "shinzoku_kankei_ds");

                                    bindingSourceShinzoku_kankei.DataSource = _shinzoku_kankei_ds;

                                    bindingNavigatorShinzoku_kankei.BindingSource = bindingSourceShinzoku_kankei;

                                    dataGridViewShinzoku_kankei.DataSource = bindingSourceShinzoku_kankei;

                                    dataGridViewShinzoku_kankei.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                                    bindingNavigatorSeikyu.Visible = false;
                                    bindingNavigatorShiharai_houhou.Visible = false;
                                    bindingNavigatorShinzoku_kankei.Visible = true;

                                    dataGridViewSeikyu.Visible = false;
                                    dataGridViewShiharai_houhou.Visible = false;
                                    dataGridViewShinzoku_kankei.Visible = true;

                                    break;
                            }
                            break;
                    }
                    break;

                //
                case 2:
                    switch (cmb_g_id_int)
                    {
                        case 1:
                            switch (cmb_s_id_int)
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:

                                    Console.WriteLine("Case " + cmb_s_id_int + "!");
                                    da.SelectCommand = new NpgsqlCommand
                                    (
                                        "select"
                                        + " c1"
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
                                        + ", c4_array"
                                        + ", time_stamp"
                                        + ", r_id"
                                        + ", s_id"
                                        + ", g_id"
                                        + ", o_id"
                                        + ", id"
                                        + ", p_id"
                                        + ", req_id"
                                        + " from"
                                        + " t_seikyu"
                                        + " where time_stamp = (select max(time_stamp) from t_seikyu"
                                        + " where s_id::Integer = " + cmb_s_id_int
                                        + " and g_id::Integer = " + cmb_g_id_int
                                        + " and o_id::Integer = " + cmb_o_id_int
                                        + " and c4_array[1]::text || '/' || c4_array[2]::Text = case when length('" + cmb_tsuki_str + "')=1 then"
                                                        + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                                                        + "       when length('" + cmb_tsuki_str + "')=2 then"
                                                        + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                                                        + " end"
                                        + ");"
                                        , m_conn
                                    );

                                    if (cmb_c4.SelectedItem == null)
                                    {
                                        da.SelectCommand.Parameters.Add(new NpgsqlParameter("c4",
                                        NpgsqlTypes.NpgsqlDbType.Text, 0, "c4",
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

                                    // update
                                    da.UpdateCommand = new NpgsqlCommand(
                                            "update t_seikyu set"
                                            + " c1 = :c1"
                                            + ", c2 = :c2"
                                            + ", c3 = :c3"
                                            + ", c4 = :c4"
                                            + ", c5 = :c5"
                                            + ", c6 = :c6"
                                            + ", c7 = :c7"
                                            + ", c8 = :c8"
                                            + ", c9 = :c9"
                                            + ", c10 = :c10"
                                            + ", c11 = :c11"
                                            + ", c12 = :c12"
                                            + ", c13 = :c13"
                                            + ", c14 = :c14"
                                            + ", c15 = :c15"
                                            + ", c16 = :c16"
                                            + ", c17 = :c17"
                                            + ", c18 = :c18"
                                            + ", c19 = :c19"
                                            + ", c20 = :c20"
                                            + ", c21 = :c21"
                                            + ", c22 = :c22"
                                            + ", c4_array = :c4_array"
                                            + ", id = :id"
                                            + ", req_id = :req_id"
                                            + ", s_id = :s_id"
                                            + ", g_id = :g_id"
                                            + ", o_id = :o_id"
                                            + " where r_id=:r_id;"
                                        , m_conn
                                        );
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c1", NpgsqlTypes.NpgsqlDbType.Text, 0, "c1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c2", NpgsqlTypes.NpgsqlDbType.Text, 0, "c2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c3", NpgsqlTypes.NpgsqlDbType.Text, 0, "c3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c5", NpgsqlTypes.NpgsqlDbType.Text, 0, "c5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c6", NpgsqlTypes.NpgsqlDbType.Text, 0, "c6", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c7", NpgsqlTypes.NpgsqlDbType.Text, 0, "c7", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c8", NpgsqlTypes.NpgsqlDbType.Text, 0, "c8", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c9", NpgsqlTypes.NpgsqlDbType.Text, 0, "c9", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c10", NpgsqlTypes.NpgsqlDbType.Text, 0, "c10", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c11", NpgsqlTypes.NpgsqlDbType.Text, 0, "c11", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c12", NpgsqlTypes.NpgsqlDbType.Text, 0, "c12", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c13", NpgsqlTypes.NpgsqlDbType.Text, 0, "c13", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c14", NpgsqlTypes.NpgsqlDbType.Text, 0, "c14", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c15", NpgsqlTypes.NpgsqlDbType.Text, 0, "c15", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c16", NpgsqlTypes.NpgsqlDbType.Text, 0, "c16", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c17", NpgsqlTypes.NpgsqlDbType.Text, 0, "c17", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c18", NpgsqlTypes.NpgsqlDbType.Text, 0, "c18", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c19", NpgsqlTypes.NpgsqlDbType.Text, 0, "c19", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c20", NpgsqlTypes.NpgsqlDbType.Text, 0, "c20", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c21", NpgsqlTypes.NpgsqlDbType.Text, 0, "c21", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c22", NpgsqlTypes.NpgsqlDbType.Text, 0, "c22", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4_array", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4_array", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("req_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "req_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("g_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "g_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("r_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "r_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                                    // delete
                                    da.DeleteCommand = new NpgsqlCommand
                                    (
                                           "delete from t_seikyu"
                                        + " where"
                                        + " r_id=:r_id;"
                                        , m_conn
                                    );
                                    da.DeleteCommand.Parameters.Add(new NpgsqlParameter("r_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "r_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                                    // RowUpdate
                                    da.RowUpdated += new NpgsqlRowUpdatedEventHandler(SeikyuRowUpdated);

                                    if (_seikyu_ds.Tables["seikyu_ds"] != null)
                                        _seikyu_ds.Tables["seikyu_ds"].Clear();
                                    da.Fill(_seikyu_ds, "seikyu_ds");

                                    bindingSourceSeikyu.DataSource = _seikyu_ds;

                                    bindingNavigatorSeikyu.BindingSource = bindingSourceSeikyu;

                                    dataGridViewSeikyu.DataSource = bindingSourceSeikyu;

                                    dataGridViewSeikyu.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                                    bindingNavigatorSeikyu.Visible = true;
                                    bindingNavigatorShiharai_houhou.Visible = false;
                                    bindingNavigatorShinzoku_kankei.Visible = false;

                                    dataGridViewSeikyu.Visible = true;
                                    dataGridViewShiharai_houhou.Visible = false;
                                    dataGridViewShinzoku_kankei.Visible = false;

                                    break;
                            }
                            break;

                        // 支払方法
                        case 2:
                            switch (cmb_s_id_int)
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:

                                    Console.WriteLine("Case " + cmb_s_id_int + "!");
                                    da.SelectCommand = new NpgsqlCommand
                                    (
                                        "select"
                                        + " c1"
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
                                        + ", c23"
                                        + ", c24"
                                        + ", c25"
                                        + ", c26"
                                        + ", c27"
                                        + ", c28"
                                        + ", c29"
                                        + ", c30"
                                        + ", c31"
                                        + ", c32"
                                        + ", c33"
                                        + ", c34"
                                        + ", c35"
                                        + ", c36"
                                        + ", c37"
                                        + ", c38"
                                        + ", c39"
                                        + ", c40"
                                        + ", c41"
                                        + ", c42"
                                        + ", c43"
                                        + ", c44"
                                        + ", c45"
                                        + ", c46"
                                        + ", c47"
                                        + ", c48"
                                        + ", c49"
                                        + ", sh_id"
                                        + ", s_id"
                                        + ", g_id"
                                        + ", o_id"
                                        + ", p_id"
                                        + ", req_id"
                                        + ", time_stamp"
                                        + ", c4_array"
                                        + " from"
                                        + " t_shiharai_houhou"
                                        + " where time_stamp = (select max(time_stamp) from t_shiharai_houhou"
                                        + " where s_id::Integer = " + cmb_s_id_int
                                        + " and g_id::Integer = " + cmb_g_id_int
                                        + " and o_id::Integer = " + cmb_o_id_int
                                        + " and c4_array[1]::text || '/' || c4_array[2]::Text = case when length('" + cmb_tsuki_str + "')=1 then"
                                                        + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                                                        + "       when length('" + cmb_tsuki_str + "')=2 then"
                                                        + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                                                        + " end)"
                                        + " order by c5;"
                                        , m_conn
                                    );

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

                                    // update
                                    da.UpdateCommand = new NpgsqlCommand(
                                            "update t_shiharai_houhou set"
                                            + " c1 = :c1"
                                            + ", c2 = :c2"
                                            + ", c3 = :c3"
                                            + ", c4 = :c4"
                                            + ", c5 = :c5"
                                            + ", c6 = :c6"
                                            + ", c7 = :c7"
                                            + ", c8 = :c8"
                                            + ", c9 = :c9"
                                            + ", c10 = :c10"
                                            + ", c11 = :c11"
                                            + ", c12 = :c12"
                                            + ", c13 = :c13"
                                            + ", c14 = :c14"
                                            + ", c15 = :c15"
                                            + ", c16 = :c16"
                                            + ", c17 = :c17"
                                            + ", c18 = :c18"
                                            + ", c19 = :c19"
                                            + ", c20 = :c20"
                                            + ", c21 = :c21"
                                            + ", c22 = :c22"
                                            + ", c23 = :c23"
                                            + ", c24 = :c24"
                                            + ", c25 = :c25"
                                            + ", c26 = :c26"
                                            + ", c27 = :c27"
                                            + ", c28 = :c28"
                                            + ", c29 = :c29"
                                            + ", c30 = :c30"
                                            + ", c31 = :c31"
                                            + ", c32 = :c32"
                                            + ", c33 = :c33"
                                            + ", c34 = :c34"
                                            + ", c35 = :c35"
                                            + ", c36 = :c36"
                                            + ", c37 = :c37"
                                            + ", c38 = :c38"
                                            + ", c39 = :c39"
                                            + ", c40 = :c40"
                                            + ", c41 = :c41"
                                            + ", c42 = :c42"
                                            + ", c43 = :c43"
                                            + ", c44 = :c44"
                                            + ", c45 = :c45"
                                            + ", c46 = :c46"
                                            + ", c47 = :c47"
                                            + ", c48 = :c48"
                                            + ", c49 = :c49"
                                            + ", s_id = :s_id"
                                            + ", g_id = :g_id"
                                            + ", o_id = :o_id"
                                            + ", p_id = :p_id"
                                            + ", req_id = :req_id"
                                            + ", c4_array = :c4_array"
                                            + " where sh_id=:sh_id;"
                                        , m_conn
                                        );
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c1", NpgsqlTypes.NpgsqlDbType.Text, 0, "c1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c2", NpgsqlTypes.NpgsqlDbType.Text, 0, "c2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c3", NpgsqlTypes.NpgsqlDbType.Text, 0, "c3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c5", NpgsqlTypes.NpgsqlDbType.Text, 0, "c5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c6", NpgsqlTypes.NpgsqlDbType.Text, 0, "c6", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c7", NpgsqlTypes.NpgsqlDbType.Text, 0, "c7", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c8", NpgsqlTypes.NpgsqlDbType.Text, 0, "c8", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c9", NpgsqlTypes.NpgsqlDbType.Text, 0, "c9", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c10", NpgsqlTypes.NpgsqlDbType.Text, 0, "c10", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c11", NpgsqlTypes.NpgsqlDbType.Text, 0, "c11", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c12", NpgsqlTypes.NpgsqlDbType.Text, 0, "c12", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c13", NpgsqlTypes.NpgsqlDbType.Text, 0, "c13", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c14", NpgsqlTypes.NpgsqlDbType.Text, 0, "c14", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c15", NpgsqlTypes.NpgsqlDbType.Text, 0, "c15", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c16", NpgsqlTypes.NpgsqlDbType.Text, 0, "c16", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c17", NpgsqlTypes.NpgsqlDbType.Text, 0, "c17", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c18", NpgsqlTypes.NpgsqlDbType.Text, 0, "c18", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c19", NpgsqlTypes.NpgsqlDbType.Text, 0, "c19", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c20", NpgsqlTypes.NpgsqlDbType.Text, 0, "c20", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c21", NpgsqlTypes.NpgsqlDbType.Text, 0, "c21", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c22", NpgsqlTypes.NpgsqlDbType.Text, 0, "c22", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c23", NpgsqlTypes.NpgsqlDbType.Text, 0, "c23", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c24", NpgsqlTypes.NpgsqlDbType.Text, 0, "c24", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c25", NpgsqlTypes.NpgsqlDbType.Text, 0, "c25", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c26", NpgsqlTypes.NpgsqlDbType.Text, 0, "c26", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c27", NpgsqlTypes.NpgsqlDbType.Text, 0, "c27", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c28", NpgsqlTypes.NpgsqlDbType.Text, 0, "c28", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c29", NpgsqlTypes.NpgsqlDbType.Text, 0, "c29", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c30", NpgsqlTypes.NpgsqlDbType.Text, 0, "c30", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c31", NpgsqlTypes.NpgsqlDbType.Text, 0, "c31", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c32", NpgsqlTypes.NpgsqlDbType.Text, 0, "c32", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c33", NpgsqlTypes.NpgsqlDbType.Text, 0, "c33", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c34", NpgsqlTypes.NpgsqlDbType.Text, 0, "c34", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c35", NpgsqlTypes.NpgsqlDbType.Text, 0, "c35", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c36", NpgsqlTypes.NpgsqlDbType.Text, 0, "c36", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c37", NpgsqlTypes.NpgsqlDbType.Text, 0, "c37", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c38", NpgsqlTypes.NpgsqlDbType.Text, 0, "c38", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c39", NpgsqlTypes.NpgsqlDbType.Text, 0, "c39", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c40", NpgsqlTypes.NpgsqlDbType.Text, 0, "c40", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c41", NpgsqlTypes.NpgsqlDbType.Text, 0, "c41", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c42", NpgsqlTypes.NpgsqlDbType.Text, 0, "c42", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c43", NpgsqlTypes.NpgsqlDbType.Text, 0, "c43", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c44", NpgsqlTypes.NpgsqlDbType.Text, 0, "c44", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c45", NpgsqlTypes.NpgsqlDbType.Text, 0, "c45", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c46", NpgsqlTypes.NpgsqlDbType.Text, 0, "c46", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c47", NpgsqlTypes.NpgsqlDbType.Text, 0, "c47", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c48", NpgsqlTypes.NpgsqlDbType.Text, 0, "c48", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c49", NpgsqlTypes.NpgsqlDbType.Text, 0, "c49", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("g_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "g_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("p_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "p_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("req_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "req_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4_array", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4_array", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("sh_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "sh_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                                    // delete
                                    da.DeleteCommand = new NpgsqlCommand
                                    (
                                           "delete from t_shiharai_houhou"
                                        + " where"
                                        + " sh_id=:sh_id;"
                                        , m_conn
                                    );
                                    da.DeleteCommand.Parameters.Add(new NpgsqlParameter("sh_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "sh_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                                    // RowUpdate
                                    da.RowUpdated += new NpgsqlRowUpdatedEventHandler(SeikyuRowUpdated);

                                    if (_shiharai_houhou_ds.Tables["shiharai_houhou_ds"] != null)
                                        _shiharai_houhou_ds.Tables["shiharai_houhou_ds"].Clear();
                                    da.Fill(_shiharai_houhou_ds, "shiharai_houhou_ds");

                                    bindingSourceShiharai_houhou.DataSource = _shiharai_houhou_ds;

                                    bindingNavigatorShiharai_houhou.BindingSource = bindingSourceShiharai_houhou;

                                    dataGridViewShiharai_houhou.DataSource = bindingSourceShiharai_houhou;

                                    dataGridViewShiharai_houhou.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                                    bindingNavigatorSeikyu.Visible = false;
                                    bindingNavigatorShiharai_houhou.Visible = true;
                                    bindingNavigatorShinzoku_kankei.Visible = false;

                                    dataGridViewSeikyu.Visible = false;
                                    dataGridViewShiharai_houhou.Visible = true;
                                    dataGridViewShinzoku_kankei.Visible = false;

                                    break;
                            }
                            break;

                        // 親族関係
                        case 3:
                            switch (cmb_s_id_int)
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:

                                    //MessageBox.Show("Case " + cmb_s_id_int + "!");
                                    Console.WriteLine("Case " + cmb_s_id_int + "!");
                                    da.SelectCommand = new NpgsqlCommand
                                    (
                                        "select"
                                        + " c1"
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
                                        + ", c23"
                                        + ", c24"
                                        + ", c25"
                                        + ", c26"
                                        + ", c27"
                                        + ", c28"
                                        + ", c29"
                                        + ", c30"
                                        + ", c31"
                                        + ", c32"
                                        + ", c33"
                                        + ", c34"
                                        + ", c35"
                                        + ", c36"
                                        + ", c37"
                                        + ", c38"
                                        + ", c39"
                                        + ", c40"
                                        + ", c41"
                                        + ", c42"
                                        + ", c43"
                                        + ", c44"
                                        + ", c45"
                                        + ", c46"
                                        + ", c47"
                                        + ", c48"
                                        + ", c49"
                                        + ", c50"
                                        + ", c51"
                                        + ", c52"
                                        + ", c53"
                                        + ", c54"
                                        + ", c55"
                                        + ", c56"
                                        + ", c57"
                                        + ", c58"
                                        + ", sk_id"
                                        + ", s_id"
                                        + ", g_id"
                                        + ", o_id"
                                        + ", p_id"
                                        + ", req_id"
                                        + ", time_stamp"
                                        + ", c4_array"
                                        + " from"
                                        + " t_shinzoku_kankei"
                                        + " where time_stamp = (select max(time_stamp) from t_shinzoku_kankei"
                                        + " where s_id::Integer = " + cmb_s_id_int
                                        + " and g_id::Integer = " + cmb_g_id_int
                                        + " and o_id::Integer = " + cmb_o_id_int
                                        + " and c4_array[1]::text || '/' || c4_array[2]::Text = case when length('" + cmb_tsuki_str + "')=1 then"
                                                        + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                                                        + "       when length('" + cmb_tsuki_str + "')=2 then"
                                                        + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                                                        + " end"
                                        + ")"
                                        + " order by c5"
                                        , m_conn
                                    );

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

                                    // update
                                    da.UpdateCommand = new NpgsqlCommand(
                                            "update t_shinzoku_kankei set"
                                        + " c1 = :c1"
                                        + ", c2 = :c2"
                                        + ", c3 = :c3"
                                        + ", c4 = :c4"
                                        + ", c5 = :c5"
                                        + ", c6 = :c6"
                                        + ", c7 = :c7"
                                        + ", c8 = :c8"
                                        + ", c9 = :c9"
                                        + ", c10 = :c10"
                                        + ", c11 = :c11"
                                        + ", c12 = :c12"
                                        + ", c13 = :c13"
                                        + ", c14 = :c14"
                                        + ", c15 = :c15"
                                        + ", c16 = :c16"
                                        + ", c17 = :c17"
                                        + ", c18 = :c18"
                                        + ", c19 = :c19"
                                        + ", c20 = :c20"
                                        + ", c21 = :c21"
                                        + ", c22 = :c22"
                                        + ", c23 = :c23"
                                        + ", c24 = :c24"
                                        + ", c25 = :c25"
                                        + ", c26 = :c26"
                                        + ", c27 = :c27"
                                        + ", c28 = :c28"
                                        + ", c29 = :c29"
                                        + ", c30 = :c30"
                                        + ", c31 = :c31"
                                        + ", c32 = :c32"
                                        + ", c33 = :c33"
                                        + ", c34 = :c34"
                                        + ", c35 = :c35"
                                        + ", c36 = :c36"
                                        + ", c37 = :c37"
                                        + ", c38 = :c38"
                                        + ", c39 = :c39"
                                        + ", c40 = :c40"
                                        + ", c41 = :c41"
                                        + ", c42 = :c42"
                                        + ", c43 = :c43"
                                        + ", c44 = :c44"
                                        + ", c45 = :c45"
                                        + ", c46 = :c46"
                                        + ", c47 = :c47"
                                        + ", c48 = :c48"
                                        + ", c49 = :c49"
                                        + ", c50 = :c50"
                                        + ", c51 = :c51"
                                        + ", c52 = :c52"
                                        + ", c53 = :c53"
                                        + ", c54 = :c54"
                                        + ", c55 = :c55"
                                        + ", c56 = :c56"
                                        + ", c57 = :c57"
                                        + ", c58 = :c58"
                                        + ", s_id = :s_id"
                                        + ", g_id = :g_id"
                                        + ", o_id = :o_id"
                                        + ", p_id = :p_id"
                                        + ", req_id = :req_id"
                                        + ", c4_array = :c4_array"
                                        + " where sk_id=:sk_id;"
                                        , m_conn
                                        );
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c1", NpgsqlTypes.NpgsqlDbType.Text, 0, "c1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c2", NpgsqlTypes.NpgsqlDbType.Text, 0, "c2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c3", NpgsqlTypes.NpgsqlDbType.Text, 0, "c3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c5", NpgsqlTypes.NpgsqlDbType.Text, 0, "c5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c6", NpgsqlTypes.NpgsqlDbType.Text, 0, "c6", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c7", NpgsqlTypes.NpgsqlDbType.Text, 0, "c7", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c8", NpgsqlTypes.NpgsqlDbType.Text, 0, "c8", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c9", NpgsqlTypes.NpgsqlDbType.Text, 0, "c9", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c10", NpgsqlTypes.NpgsqlDbType.Text, 0, "c10", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c11", NpgsqlTypes.NpgsqlDbType.Text, 0, "c11", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c12", NpgsqlTypes.NpgsqlDbType.Text, 0, "c12", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c13", NpgsqlTypes.NpgsqlDbType.Text, 0, "c13", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c14", NpgsqlTypes.NpgsqlDbType.Text, 0, "c14", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c15", NpgsqlTypes.NpgsqlDbType.Text, 0, "c15", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c16", NpgsqlTypes.NpgsqlDbType.Text, 0, "c16", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c17", NpgsqlTypes.NpgsqlDbType.Text, 0, "c17", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c18", NpgsqlTypes.NpgsqlDbType.Text, 0, "c18", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c19", NpgsqlTypes.NpgsqlDbType.Text, 0, "c19", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c20", NpgsqlTypes.NpgsqlDbType.Text, 0, "c20", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c21", NpgsqlTypes.NpgsqlDbType.Text, 0, "c21", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c22", NpgsqlTypes.NpgsqlDbType.Text, 0, "c22", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c23", NpgsqlTypes.NpgsqlDbType.Text, 0, "c23", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c24", NpgsqlTypes.NpgsqlDbType.Text, 0, "c24", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c25", NpgsqlTypes.NpgsqlDbType.Text, 0, "c25", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c26", NpgsqlTypes.NpgsqlDbType.Text, 0, "c26", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c27", NpgsqlTypes.NpgsqlDbType.Text, 0, "c27", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c28", NpgsqlTypes.NpgsqlDbType.Text, 0, "c28", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c29", NpgsqlTypes.NpgsqlDbType.Text, 0, "c29", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c30", NpgsqlTypes.NpgsqlDbType.Text, 0, "c30", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c31", NpgsqlTypes.NpgsqlDbType.Text, 0, "c31", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c32", NpgsqlTypes.NpgsqlDbType.Text, 0, "c32", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c33", NpgsqlTypes.NpgsqlDbType.Text, 0, "c33", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c34", NpgsqlTypes.NpgsqlDbType.Text, 0, "c34", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c35", NpgsqlTypes.NpgsqlDbType.Text, 0, "c35", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c36", NpgsqlTypes.NpgsqlDbType.Text, 0, "c36", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c37", NpgsqlTypes.NpgsqlDbType.Text, 0, "c37", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c38", NpgsqlTypes.NpgsqlDbType.Text, 0, "c38", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c39", NpgsqlTypes.NpgsqlDbType.Text, 0, "c39", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c40", NpgsqlTypes.NpgsqlDbType.Text, 0, "c40", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c41", NpgsqlTypes.NpgsqlDbType.Text, 0, "c41", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c42", NpgsqlTypes.NpgsqlDbType.Text, 0, "c42", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c43", NpgsqlTypes.NpgsqlDbType.Text, 0, "c43", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c44", NpgsqlTypes.NpgsqlDbType.Text, 0, "c44", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c45", NpgsqlTypes.NpgsqlDbType.Text, 0, "c45", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c46", NpgsqlTypes.NpgsqlDbType.Text, 0, "c46", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c47", NpgsqlTypes.NpgsqlDbType.Text, 0, "c47", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c48", NpgsqlTypes.NpgsqlDbType.Text, 0, "c48", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c49", NpgsqlTypes.NpgsqlDbType.Text, 0, "c49", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c50", NpgsqlTypes.NpgsqlDbType.Text, 0, "c50", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c51", NpgsqlTypes.NpgsqlDbType.Text, 0, "c51", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c52", NpgsqlTypes.NpgsqlDbType.Text, 0, "c52", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c53", NpgsqlTypes.NpgsqlDbType.Text, 0, "c53", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c54", NpgsqlTypes.NpgsqlDbType.Text, 0, "c54", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c55", NpgsqlTypes.NpgsqlDbType.Text, 0, "c55", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c56", NpgsqlTypes.NpgsqlDbType.Text, 0, "c56", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c57", NpgsqlTypes.NpgsqlDbType.Text, 0, "c57", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c58", NpgsqlTypes.NpgsqlDbType.Text, 0, "c58", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("g_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "g_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("p_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "p_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("req_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "req_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4_array", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4_array", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("sk_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "sk_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                                    // delete
                                    da.DeleteCommand = new NpgsqlCommand
                                    (
                                           "delete from t_shinzoku_kankei"
                                        + " where"
                                        + " sk_id=:sk_id;"
                                        , m_conn
                                    );
                                    da.DeleteCommand.Parameters.Add(new NpgsqlParameter("sk_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "sk_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                                    // RowUpdate
                                    da.RowUpdated += new NpgsqlRowUpdatedEventHandler(SeikyuRowUpdated);

                                    if (_shinzoku_kankei_ds.Tables["shinzoku_kankei_ds"] != null)
                                        _shinzoku_kankei_ds.Tables["shinzoku_kankei_ds"].Clear();
                                    da.Fill(_shinzoku_kankei_ds, "shinzoku_kankei_ds");

                                    bindingSourceShinzoku_kankei.DataSource = _shinzoku_kankei_ds;

                                    bindingNavigatorShinzoku_kankei.BindingSource = bindingSourceShinzoku_kankei;

                                    dataGridViewShinzoku_kankei.DataSource = bindingSourceShinzoku_kankei;

                                    dataGridViewShinzoku_kankei.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                                    bindingNavigatorSeikyu.Visible = false;
                                    bindingNavigatorShiharai_houhou.Visible = false;
                                    bindingNavigatorShinzoku_kankei.Visible = true;

                                    dataGridViewSeikyu.Visible = false;
                                    dataGridViewShiharai_houhou.Visible = false;
                                    dataGridViewShinzoku_kankei.Visible = true;

                                    break;
                            }
                            break;
                    }
                    break;
                //
                case 3:
                    switch (cmb_g_id_int)
                    {
                        case 1:
                            switch (cmb_s_id_int)
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:

                                    Console.WriteLine("Case " + cmb_s_id_int + "!");
                                    da.SelectCommand = new NpgsqlCommand
                                    (
                                        "select"
                                        + " c1"
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
                                        + ", c4_array"
                                        + ", time_stamp"
                                        + ", r_id"
                                        + ", s_id"
                                        + ", g_id"
                                        + ", o_id"
                                        + ", id"
                                        + ", p_id"
                                        + ", req_id"
                                        + " from"
                                        + " t_seikyu"
                                        + " where time_stamp = (select max(time_stamp) from t_seikyu"
                                        + " where s_id::Integer = " + cmb_s_id_int
                                        + " and g_id::Integer = " + cmb_g_id_int
                                        + " and o_id::Integer = " + cmb_o_id_int
                                        + " and c4_array[1]::text || '/' || c4_array[2]::Text = case when length('" + cmb_tsuki_str + "')=1 then"
                                                        + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                                                        + "       when length('" + cmb_tsuki_str + "')=2 then"
                                                        + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                                                        + " end"
                                        + ");"
                                        , m_conn
                                    );

                                    if (cmb_c4.SelectedItem == null)
                                    {
                                        da.SelectCommand.Parameters.Add(new NpgsqlParameter("c4",
                                        NpgsqlTypes.NpgsqlDbType.Text, 0, "c4",
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

                                    // update
                                    da.UpdateCommand = new NpgsqlCommand(
                                            "update t_seikyu set"
                                            + " c1 = :c1"
                                            + ", c2 = :c2"
                                            + ", c3 = :c3"
                                            + ", c4 = :c4"
                                            + ", c5 = :c5"
                                            + ", c6 = :c6"
                                            + ", c7 = :c7"
                                            + ", c8 = :c8"
                                            + ", c9 = :c9"
                                            + ", c10 = :c10"
                                            + ", c11 = :c11"
                                            + ", c12 = :c12"
                                            + ", c13 = :c13"
                                            + ", c14 = :c14"
                                            + ", c15 = :c15"
                                            + ", c16 = :c16"
                                            + ", c17 = :c17"
                                            + ", c18 = :c18"
                                            + ", c19 = :c19"
                                            + ", c20 = :c20"
                                            + ", c21 = :c21"
                                            + ", c22 = :c22"
                                            + ", c4_array = :c4_array"
                                            + ", id = :id"
                                            + ", req_id = :req_id"
                                            + ", s_id = :s_id"
                                            + ", g_id = :g_id"
                                            + ", o_id = :o_id"
                                            + " where r_id=:r_id;"
                                        , m_conn
                                        );
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c1", NpgsqlTypes.NpgsqlDbType.Text, 0, "c1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c2", NpgsqlTypes.NpgsqlDbType.Text, 0, "c2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c3", NpgsqlTypes.NpgsqlDbType.Text, 0, "c3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c5", NpgsqlTypes.NpgsqlDbType.Text, 0, "c5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c6", NpgsqlTypes.NpgsqlDbType.Text, 0, "c6", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c7", NpgsqlTypes.NpgsqlDbType.Text, 0, "c7", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c8", NpgsqlTypes.NpgsqlDbType.Text, 0, "c8", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c9", NpgsqlTypes.NpgsqlDbType.Text, 0, "c9", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c10", NpgsqlTypes.NpgsqlDbType.Text, 0, "c10", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c11", NpgsqlTypes.NpgsqlDbType.Text, 0, "c11", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c12", NpgsqlTypes.NpgsqlDbType.Text, 0, "c12", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c13", NpgsqlTypes.NpgsqlDbType.Text, 0, "c13", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c14", NpgsqlTypes.NpgsqlDbType.Text, 0, "c14", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c15", NpgsqlTypes.NpgsqlDbType.Text, 0, "c15", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c16", NpgsqlTypes.NpgsqlDbType.Text, 0, "c16", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c17", NpgsqlTypes.NpgsqlDbType.Text, 0, "c17", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c18", NpgsqlTypes.NpgsqlDbType.Text, 0, "c18", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c19", NpgsqlTypes.NpgsqlDbType.Text, 0, "c19", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c20", NpgsqlTypes.NpgsqlDbType.Text, 0, "c20", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c21", NpgsqlTypes.NpgsqlDbType.Text, 0, "c21", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c22", NpgsqlTypes.NpgsqlDbType.Text, 0, "c22", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4_array", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4_array", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("req_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "req_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("g_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "g_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("r_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "r_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                                    // delete
                                    da.DeleteCommand = new NpgsqlCommand
                                    (
                                           "delete from t_seikyu"
                                        + " where"
                                        + " r_id=:r_id;"
                                        , m_conn
                                    );
                                    da.DeleteCommand.Parameters.Add(new NpgsqlParameter("r_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "r_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                                    // RowUpdate
                                    da.RowUpdated += new NpgsqlRowUpdatedEventHandler(SeikyuRowUpdated);

                                    if (_seikyu_ds.Tables["seikyu_ds"] != null)
                                        _seikyu_ds.Tables["seikyu_ds"].Clear();
                                    da.Fill(_seikyu_ds, "seikyu_ds");

                                    bindingSourceSeikyu.DataSource = _seikyu_ds;

                                    bindingNavigatorSeikyu.BindingSource = bindingSourceSeikyu;

                                    dataGridViewSeikyu.DataSource = bindingSourceSeikyu;

                                    dataGridViewSeikyu.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                                    bindingNavigatorSeikyu.Visible = true;
                                    bindingNavigatorShiharai_houhou.Visible = false;
                                    bindingNavigatorShinzoku_kankei.Visible = false;

                                    dataGridViewSeikyu.Visible = true;
                                    dataGridViewShiharai_houhou.Visible = false;
                                    dataGridViewShinzoku_kankei.Visible = false;

                                    break;
                            }
                            break;

                        // 支払方法
                        case 2:
                            switch (cmb_s_id_int)
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:

                                    Console.WriteLine("Case " + cmb_s_id_int + "!");
                                    da.SelectCommand = new NpgsqlCommand
                                    (
                                        "select"
                                        + " c1"
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
                                        + ", c23"
                                        + ", c24"
                                        + ", c25"
                                        + ", c26"
                                        + ", c27"
                                        + ", c28"
                                        + ", c29"
                                        + ", c30"
                                        + ", c31"
                                        + ", c32"
                                        + ", c33"
                                        + ", c34"
                                        + ", c35"
                                        + ", c36"
                                        + ", c37"
                                        + ", c38"
                                        + ", c39"
                                        + ", c40"
                                        + ", c41"
                                        + ", c42"
                                        + ", c43"
                                        + ", c44"
                                        + ", c45"
                                        + ", c46"
                                        + ", c47"
                                        + ", c48"
                                        + ", c49"
                                        + ", sh_id"
                                        + ", s_id"
                                        + ", g_id"
                                        + ", o_id"
                                        + ", p_id"
                                        + ", req_id"
                                        + ", time_stamp"
                                        + ", c4_array"
                                        + " from"
                                        + " t_shiharai_houhou"
                                        + " where time_stamp = (select max(time_stamp) from t_shiharai_houhou"
                                        + " where s_id::Integer = " + cmb_s_id_int
                                        + " and g_id::Integer = " + cmb_g_id_int
                                        + " and o_id::Integer = " + cmb_o_id_int
                                        + " and c4_array[1]::text || '/' || c4_array[2]::Text = case when length('" + cmb_tsuki_str + "')=1 then"
                                                        + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                                                        + "       when length('" + cmb_tsuki_str + "')=2 then"
                                                        + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                                                        + " end)"
                                        + " order by c5;"
                                        , m_conn
                                    );

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

                                    // update
                                    da.UpdateCommand = new NpgsqlCommand(
                                            "update t_shiharai_houhou set"
                                            + " c1 = :c1"
                                            + ", c2 = :c2"
                                            + ", c3 = :c3"
                                            + ", c4 = :c4"
                                            + ", c5 = :c5"
                                            + ", c6 = :c6"
                                            + ", c7 = :c7"
                                            + ", c8 = :c8"
                                            + ", c9 = :c9"
                                            + ", c10 = :c10"
                                            + ", c11 = :c11"
                                            + ", c12 = :c12"
                                            + ", c13 = :c13"
                                            + ", c14 = :c14"
                                            + ", c15 = :c15"
                                            + ", c16 = :c16"
                                            + ", c17 = :c17"
                                            + ", c18 = :c18"
                                            + ", c19 = :c19"
                                            + ", c20 = :c20"
                                            + ", c21 = :c21"
                                            + ", c22 = :c22"
                                            + ", c23 = :c23"
                                            + ", c24 = :c24"
                                            + ", c25 = :c25"
                                            + ", c26 = :c26"
                                            + ", c27 = :c27"
                                            + ", c28 = :c28"
                                            + ", c29 = :c29"
                                            + ", c30 = :c30"
                                            + ", c31 = :c31"
                                            + ", c32 = :c32"
                                            + ", c33 = :c33"
                                            + ", c34 = :c34"
                                            + ", c35 = :c35"
                                            + ", c36 = :c36"
                                            + ", c37 = :c37"
                                            + ", c38 = :c38"
                                            + ", c39 = :c39"
                                            + ", c40 = :c40"
                                            + ", c41 = :c41"
                                            + ", c42 = :c42"
                                            + ", c43 = :c43"
                                            + ", c44 = :c44"
                                            + ", c45 = :c45"
                                            + ", c46 = :c46"
                                            + ", c47 = :c47"
                                            + ", c48 = :c48"
                                            + ", c49 = :c49"
                                            + ", s_id = :s_id"
                                            + ", g_id = :g_id"
                                            + ", o_id = :o_id"
                                            + ", p_id = :p_id"
                                            + ", req_id = :req_id"
                                            + ", c4_array = :c4_array"
                                            + " where sh_id=:sh_id;"
                                        , m_conn
                                        );
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c1", NpgsqlTypes.NpgsqlDbType.Text, 0, "c1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c2", NpgsqlTypes.NpgsqlDbType.Text, 0, "c2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c3", NpgsqlTypes.NpgsqlDbType.Text, 0, "c3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c5", NpgsqlTypes.NpgsqlDbType.Text, 0, "c5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c6", NpgsqlTypes.NpgsqlDbType.Text, 0, "c6", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c7", NpgsqlTypes.NpgsqlDbType.Text, 0, "c7", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c8", NpgsqlTypes.NpgsqlDbType.Text, 0, "c8", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c9", NpgsqlTypes.NpgsqlDbType.Text, 0, "c9", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c10", NpgsqlTypes.NpgsqlDbType.Text, 0, "c10", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c11", NpgsqlTypes.NpgsqlDbType.Text, 0, "c11", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c12", NpgsqlTypes.NpgsqlDbType.Text, 0, "c12", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c13", NpgsqlTypes.NpgsqlDbType.Text, 0, "c13", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c14", NpgsqlTypes.NpgsqlDbType.Text, 0, "c14", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c15", NpgsqlTypes.NpgsqlDbType.Text, 0, "c15", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c16", NpgsqlTypes.NpgsqlDbType.Text, 0, "c16", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c17", NpgsqlTypes.NpgsqlDbType.Text, 0, "c17", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c18", NpgsqlTypes.NpgsqlDbType.Text, 0, "c18", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c19", NpgsqlTypes.NpgsqlDbType.Text, 0, "c19", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c20", NpgsqlTypes.NpgsqlDbType.Text, 0, "c20", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c21", NpgsqlTypes.NpgsqlDbType.Text, 0, "c21", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c22", NpgsqlTypes.NpgsqlDbType.Text, 0, "c22", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c23", NpgsqlTypes.NpgsqlDbType.Text, 0, "c23", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c24", NpgsqlTypes.NpgsqlDbType.Text, 0, "c24", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c25", NpgsqlTypes.NpgsqlDbType.Text, 0, "c25", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c26", NpgsqlTypes.NpgsqlDbType.Text, 0, "c26", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c27", NpgsqlTypes.NpgsqlDbType.Text, 0, "c27", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c28", NpgsqlTypes.NpgsqlDbType.Text, 0, "c28", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c29", NpgsqlTypes.NpgsqlDbType.Text, 0, "c29", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c30", NpgsqlTypes.NpgsqlDbType.Text, 0, "c30", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c31", NpgsqlTypes.NpgsqlDbType.Text, 0, "c31", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c32", NpgsqlTypes.NpgsqlDbType.Text, 0, "c32", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c33", NpgsqlTypes.NpgsqlDbType.Text, 0, "c33", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c34", NpgsqlTypes.NpgsqlDbType.Text, 0, "c34", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c35", NpgsqlTypes.NpgsqlDbType.Text, 0, "c35", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c36", NpgsqlTypes.NpgsqlDbType.Text, 0, "c36", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c37", NpgsqlTypes.NpgsqlDbType.Text, 0, "c37", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c38", NpgsqlTypes.NpgsqlDbType.Text, 0, "c38", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c39", NpgsqlTypes.NpgsqlDbType.Text, 0, "c39", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c40", NpgsqlTypes.NpgsqlDbType.Text, 0, "c40", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c41", NpgsqlTypes.NpgsqlDbType.Text, 0, "c41", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c42", NpgsqlTypes.NpgsqlDbType.Text, 0, "c42", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c43", NpgsqlTypes.NpgsqlDbType.Text, 0, "c43", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c44", NpgsqlTypes.NpgsqlDbType.Text, 0, "c44", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c45", NpgsqlTypes.NpgsqlDbType.Text, 0, "c45", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c46", NpgsqlTypes.NpgsqlDbType.Text, 0, "c46", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c47", NpgsqlTypes.NpgsqlDbType.Text, 0, "c47", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c48", NpgsqlTypes.NpgsqlDbType.Text, 0, "c48", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c49", NpgsqlTypes.NpgsqlDbType.Text, 0, "c49", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("g_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "g_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("p_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "p_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("req_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "req_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4_array", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4_array", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("sh_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "sh_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                                    // delete
                                    da.DeleteCommand = new NpgsqlCommand
                                    (
                                           "delete from t_shiharai_houhou"
                                        + " where"
                                        + " sh_id=:sh_id;"
                                        , m_conn
                                    );
                                    da.DeleteCommand.Parameters.Add(new NpgsqlParameter("sh_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "sh_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                                    // RowUpdate
                                    da.RowUpdated += new NpgsqlRowUpdatedEventHandler(SeikyuRowUpdated);

                                    if (_shiharai_houhou_ds.Tables["shiharai_houhou_ds"] != null)
                                        _shiharai_houhou_ds.Tables["shiharai_houhou_ds"].Clear();
                                    da.Fill(_shiharai_houhou_ds, "shiharai_houhou_ds");

                                    bindingSourceShiharai_houhou.DataSource = _shiharai_houhou_ds;

                                    bindingNavigatorShiharai_houhou.BindingSource = bindingSourceShiharai_houhou;

                                    dataGridViewShiharai_houhou.DataSource = bindingSourceShiharai_houhou;

                                    dataGridViewShiharai_houhou.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                                    bindingNavigatorSeikyu.Visible = false;
                                    bindingNavigatorShiharai_houhou.Visible = true;
                                    bindingNavigatorShinzoku_kankei.Visible = false;

                                    dataGridViewSeikyu.Visible = false;
                                    dataGridViewShiharai_houhou.Visible = true;
                                    dataGridViewShinzoku_kankei.Visible = false;

                                    break;
                            }
                            break;

                        // 親族関係
                        case 3:
                            switch (cmb_s_id_int)
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:

                                    //MessageBox.Show("Case " + cmb_s_id_int + "!");
                                    Console.WriteLine("Case " + cmb_s_id_int + "!");
                                    da.SelectCommand = new NpgsqlCommand
                                    (
                                        "select"
                                        + " c1"
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
                                        + ", c23"
                                        + ", c24"
                                        + ", c25"
                                        + ", c26"
                                        + ", c27"
                                        + ", c28"
                                        + ", c29"
                                        + ", c30"
                                        + ", c31"
                                        + ", c32"
                                        + ", c33"
                                        + ", c34"
                                        + ", c35"
                                        + ", c36"
                                        + ", c37"
                                        + ", c38"
                                        + ", c39"
                                        + ", c40"
                                        + ", c41"
                                        + ", c42"
                                        + ", c43"
                                        + ", c44"
                                        + ", c45"
                                        + ", c46"
                                        + ", c47"
                                        + ", c48"
                                        + ", c49"
                                        + ", c50"
                                        + ", c51"
                                        + ", c52"
                                        + ", c53"
                                        + ", c54"
                                        + ", c55"
                                        + ", c56"
                                        + ", c57"
                                        + ", c58"
                                        + ", sk_id"
                                        + ", s_id"
                                        + ", g_id"
                                        + ", o_id"
                                        + ", p_id"
                                        + ", req_id"
                                        + ", time_stamp"
                                        + ", c4_array"
                                        + " from"
                                        + " t_shinzoku_kankei"
                                        + " where time_stamp = (select max(time_stamp) from t_shinzoku_kankei"
                                        + " where s_id::Integer = " + cmb_s_id_int
                                        + " and g_id::Integer = " + cmb_g_id_int
                                        + " and o_id::Integer = " + cmb_o_id_int
                                        + " and c4_array[1]::text || '/' || c4_array[2]::Text = case when length('" + cmb_tsuki_str + "')=1 then"
                                                        + " ('" + cmb_nen_str + "' || '/ ' || '" + cmb_tsuki_str + "')"
                                                        + "       when length('" + cmb_tsuki_str + "')=2 then"
                                                        + " ('" + cmb_nen_str + "' || '/' || '" + cmb_tsuki_str + "')"
                                                        + " end"
                                        + ")"
                                        + " order by c5"
                                        , m_conn
                                    );

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

                                    // update
                                    da.UpdateCommand = new NpgsqlCommand(
                                            "update t_shinzoku_kankei set"
                                        + " c1 = :c1"
                                        + ", c2 = :c2"
                                        + ", c3 = :c3"
                                        + ", c4 = :c4"
                                        + ", c5 = :c5"
                                        + ", c6 = :c6"
                                        + ", c7 = :c7"
                                        + ", c8 = :c8"
                                        + ", c9 = :c9"
                                        + ", c10 = :c10"
                                        + ", c11 = :c11"
                                        + ", c12 = :c12"
                                        + ", c13 = :c13"
                                        + ", c14 = :c14"
                                        + ", c15 = :c15"
                                        + ", c16 = :c16"
                                        + ", c17 = :c17"
                                        + ", c18 = :c18"
                                        + ", c19 = :c19"
                                        + ", c20 = :c20"
                                        + ", c21 = :c21"
                                        + ", c22 = :c22"
                                        + ", c23 = :c23"
                                        + ", c24 = :c24"
                                        + ", c25 = :c25"
                                        + ", c26 = :c26"
                                        + ", c27 = :c27"
                                        + ", c28 = :c28"
                                        + ", c29 = :c29"
                                        + ", c30 = :c30"
                                        + ", c31 = :c31"
                                        + ", c32 = :c32"
                                        + ", c33 = :c33"
                                        + ", c34 = :c34"
                                        + ", c35 = :c35"
                                        + ", c36 = :c36"
                                        + ", c37 = :c37"
                                        + ", c38 = :c38"
                                        + ", c39 = :c39"
                                        + ", c40 = :c40"
                                        + ", c41 = :c41"
                                        + ", c42 = :c42"
                                        + ", c43 = :c43"
                                        + ", c44 = :c44"
                                        + ", c45 = :c45"
                                        + ", c46 = :c46"
                                        + ", c47 = :c47"
                                        + ", c48 = :c48"
                                        + ", c49 = :c49"
                                        + ", c50 = :c50"
                                        + ", c51 = :c51"
                                        + ", c52 = :c52"
                                        + ", c53 = :c53"
                                        + ", c54 = :c54"
                                        + ", c55 = :c55"
                                        + ", c56 = :c56"
                                        + ", c57 = :c57"
                                        + ", c58 = :c58"
                                        + ", s_id = :s_id"
                                        + ", g_id = :g_id"
                                        + ", o_id = :o_id"
                                        + ", p_id = :p_id"
                                        + ", req_id = :req_id"
                                        + ", c4_array = :c4_array"
                                        + " where sk_id=:sk_id;"
                                        , m_conn
                                        );
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c1", NpgsqlTypes.NpgsqlDbType.Text, 0, "c1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c2", NpgsqlTypes.NpgsqlDbType.Text, 0, "c2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c3", NpgsqlTypes.NpgsqlDbType.Text, 0, "c3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c5", NpgsqlTypes.NpgsqlDbType.Text, 0, "c5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c6", NpgsqlTypes.NpgsqlDbType.Text, 0, "c6", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c7", NpgsqlTypes.NpgsqlDbType.Text, 0, "c7", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c8", NpgsqlTypes.NpgsqlDbType.Text, 0, "c8", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c9", NpgsqlTypes.NpgsqlDbType.Text, 0, "c9", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c10", NpgsqlTypes.NpgsqlDbType.Text, 0, "c10", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c11", NpgsqlTypes.NpgsqlDbType.Text, 0, "c11", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c12", NpgsqlTypes.NpgsqlDbType.Text, 0, "c12", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c13", NpgsqlTypes.NpgsqlDbType.Text, 0, "c13", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c14", NpgsqlTypes.NpgsqlDbType.Text, 0, "c14", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c15", NpgsqlTypes.NpgsqlDbType.Text, 0, "c15", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c16", NpgsqlTypes.NpgsqlDbType.Text, 0, "c16", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c17", NpgsqlTypes.NpgsqlDbType.Text, 0, "c17", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c18", NpgsqlTypes.NpgsqlDbType.Text, 0, "c18", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c19", NpgsqlTypes.NpgsqlDbType.Text, 0, "c19", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c20", NpgsqlTypes.NpgsqlDbType.Text, 0, "c20", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c21", NpgsqlTypes.NpgsqlDbType.Text, 0, "c21", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c22", NpgsqlTypes.NpgsqlDbType.Text, 0, "c22", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c23", NpgsqlTypes.NpgsqlDbType.Text, 0, "c23", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c24", NpgsqlTypes.NpgsqlDbType.Text, 0, "c24", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c25", NpgsqlTypes.NpgsqlDbType.Text, 0, "c25", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c26", NpgsqlTypes.NpgsqlDbType.Text, 0, "c26", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c27", NpgsqlTypes.NpgsqlDbType.Text, 0, "c27", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c28", NpgsqlTypes.NpgsqlDbType.Text, 0, "c28", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c29", NpgsqlTypes.NpgsqlDbType.Text, 0, "c29", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c30", NpgsqlTypes.NpgsqlDbType.Text, 0, "c30", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c31", NpgsqlTypes.NpgsqlDbType.Text, 0, "c31", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c32", NpgsqlTypes.NpgsqlDbType.Text, 0, "c32", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c33", NpgsqlTypes.NpgsqlDbType.Text, 0, "c33", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c34", NpgsqlTypes.NpgsqlDbType.Text, 0, "c34", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c35", NpgsqlTypes.NpgsqlDbType.Text, 0, "c35", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c36", NpgsqlTypes.NpgsqlDbType.Text, 0, "c36", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c37", NpgsqlTypes.NpgsqlDbType.Text, 0, "c37", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c38", NpgsqlTypes.NpgsqlDbType.Text, 0, "c38", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c39", NpgsqlTypes.NpgsqlDbType.Text, 0, "c39", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c40", NpgsqlTypes.NpgsqlDbType.Text, 0, "c40", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c41", NpgsqlTypes.NpgsqlDbType.Text, 0, "c41", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c42", NpgsqlTypes.NpgsqlDbType.Text, 0, "c42", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c43", NpgsqlTypes.NpgsqlDbType.Text, 0, "c43", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c44", NpgsqlTypes.NpgsqlDbType.Text, 0, "c44", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c45", NpgsqlTypes.NpgsqlDbType.Text, 0, "c45", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c46", NpgsqlTypes.NpgsqlDbType.Text, 0, "c46", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c47", NpgsqlTypes.NpgsqlDbType.Text, 0, "c47", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c48", NpgsqlTypes.NpgsqlDbType.Text, 0, "c48", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c49", NpgsqlTypes.NpgsqlDbType.Text, 0, "c49", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c50", NpgsqlTypes.NpgsqlDbType.Text, 0, "c50", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c51", NpgsqlTypes.NpgsqlDbType.Text, 0, "c51", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c52", NpgsqlTypes.NpgsqlDbType.Text, 0, "c52", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c53", NpgsqlTypes.NpgsqlDbType.Text, 0, "c53", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c54", NpgsqlTypes.NpgsqlDbType.Text, 0, "c54", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c55", NpgsqlTypes.NpgsqlDbType.Text, 0, "c55", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c56", NpgsqlTypes.NpgsqlDbType.Text, 0, "c56", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c57", NpgsqlTypes.NpgsqlDbType.Text, 0, "c57", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c58", NpgsqlTypes.NpgsqlDbType.Text, 0, "c58", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("g_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "g_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("o_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "o_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("p_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "p_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("req_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "req_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("c4_array", NpgsqlTypes.NpgsqlDbType.Text, 0, "c4_array", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
                                    da.UpdateCommand.Parameters.Add(new NpgsqlParameter("sk_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "sk_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                                    // delete
                                    da.DeleteCommand = new NpgsqlCommand
                                    (
                                           "delete from t_shinzoku_kankei"
                                        + " where"
                                        + " sk_id=:sk_id;"
                                        , m_conn
                                    );
                                    da.DeleteCommand.Parameters.Add(new NpgsqlParameter("sk_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "sk_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

                                    // RowUpdate
                                    da.RowUpdated += new NpgsqlRowUpdatedEventHandler(SeikyuRowUpdated);

                                    if (_shinzoku_kankei_ds.Tables["shinzoku_kankei_ds"] != null)
                                        _shinzoku_kankei_ds.Tables["shinzoku_kankei_ds"].Clear();
                                    da.Fill(_shinzoku_kankei_ds, "shinzoku_kankei_ds");

                                    bindingSourceShinzoku_kankei.DataSource = _shinzoku_kankei_ds;

                                    bindingNavigatorShinzoku_kankei.BindingSource = bindingSourceShinzoku_kankei;

                                    dataGridViewShinzoku_kankei.DataSource = bindingSourceShinzoku_kankei;

                                    dataGridViewShinzoku_kankei.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                                    bindingNavigatorSeikyu.Visible = false;
                                    bindingNavigatorShiharai_houhou.Visible = false;
                                    bindingNavigatorShinzoku_kankei.Visible = true;

                                    dataGridViewSeikyu.Visible = false;
                                    dataGridViewShiharai_houhou.Visible = false;
                                    dataGridViewShinzoku_kankei.Visible = true;

                                    break;
                            }
                            break;
                    }
                    break;

            }
        }
    }
}