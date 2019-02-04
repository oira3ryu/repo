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

namespace rk_seikyu
{
    public partial class Form_rep : Form
    {
        private NpgsqlConnection m_conn = new NpgsqlConnection(rk_seikyu.Properties.Settings.Default.PostgresConnect);

        private NpgsqlDataAdapter da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter t_id_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter n_id_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter s_id_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter pt_id_da = new NpgsqlDataAdapter();

        private NpgsqlDataAdapter sub_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter cmb_da = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter dup_da = new NpgsqlDataAdapter();

        private DataSet ds = new DataSet();
        private DataSet n_id_ds = new DataSet();
        private DataSet t_id_ds = new DataSet();
        private DataSet s_id_ds = new DataSet();
        private DataSet pt_id_ds = new DataSet();
        private DataSet Cntds = new DataSet();
        private DataSet CntMends = new DataSet();
        private DataSet CntWomends = new DataSet();
        private DataSet Cmbds = new DataSet();
        private DataSet dupds = new DataSet();

        public string ofdstr { get; set; }
        public int cmb_n_id_int { get; set; }
        public int cmb_t_id_int { get; set; }
        public int cmb_s_id_int { get; set; }
        public int cmb_pt_id_int { get; set; }

        public int hour { get; set; }
        public int minute { get; set; }
        public int second { get; set; }

        public int VarHour { get; set; }
        public int VarMinute { get; set; }
        public int VarSecond { get; set; }

        public Form_rep()
        {
            InitializeComponent();
        }

        private void Form_rep_Load(object sender, EventArgs e)
        {

            dataGridViewRep.Columns[0].HeaderText = "ID";
            dataGridViewRep.Columns[1].HeaderText = "種別ID";
            dataGridViewRep.Columns[2].HeaderText = "項目１";
            dataGridViewRep.Columns[3].HeaderText = "項目２";
            dataGridViewRep.Columns[4].HeaderText = "項目３";
            dataGridViewRep.Columns[5].HeaderText = "項目４";
            dataGridViewRep.Columns[6].HeaderText = "項目５";
            dataGridViewRep.Columns[7].HeaderText = "項目６";
            dataGridViewRep.Columns[8].HeaderText = "項目７";
            dataGridViewRep.Columns[9].HeaderText = "項目８";
            dataGridViewRep.Columns[10].HeaderText = "項目９";
            dataGridViewRep.Columns[11].HeaderText = "項目１０";
            dataGridViewRep.Columns[12].HeaderText = "項目１１";
            
            da.SelectCommand = new NpgsqlCommand
            (
                "select"
				 + " pt_id"
				 + ", s_id"
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
				 + ", rep_id"
                 + " from"
                 + " t_rep"
                 + " where s_id::Integer = :s_id"
                 + " and pt_id::Integer = :pt_id"
                 + " order by rep_id"
                ,m_conn
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

            if (cmb_pt_id.SelectedItem == null)
            {
                da.SelectCommand.Parameters.Add(new NpgsqlParameter("pt_id",
                NpgsqlTypes.NpgsqlDbType.Integer, 0, "pt_id",
                ParameterDirection.Input, false, 0, 0, DataRowVersion.Current,
                DBNull.Value));
            }
            else
            {
                DataRowView row = (DataRowView)cmb_pt_id.SelectedItem;
                da.SelectCommand.Parameters.AddWithValue("pt_id", row["pt_id"]);
            }

            // insert
            da.InsertCommand = new NpgsqlCommand
            (
                 "insert into t_rep ("
				 + " pt_id"
				 + ", s_id"
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
                    + " ) values ("
				 + " :pt_id"
				 + ", :s_id"
				 + ", :col0"
				 + ", :col1"
				 + ", :col2"
				 + ", :col3"
				 + ", :col4"
				 + ", :col5"
				 + ", :ac0"
				 + ", :ac1"
				 + ", :ac2"
				 + ", :ac3"
                    + ")",
                m_conn
            );
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("pt_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "pt_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("col0", NpgsqlTypes.NpgsqlDbType.Text, 0, "col0", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("col1", NpgsqlTypes.NpgsqlDbType.Text, 0, "col1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("col2", NpgsqlTypes.NpgsqlDbType.Text, 0, "col2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("col3", NpgsqlTypes.NpgsqlDbType.Text, 0, "col3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("col4", NpgsqlTypes.NpgsqlDbType.Text, 0, "col4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("col5", NpgsqlTypes.NpgsqlDbType.Text, 0, "col5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("ac0", NpgsqlTypes.NpgsqlDbType.Text, 0, "ac0", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("ac1", NpgsqlTypes.NpgsqlDbType.Text, 0, "ac1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("ac2", NpgsqlTypes.NpgsqlDbType.Text, 0, "ac2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("ac3", NpgsqlTypes.NpgsqlDbType.Text, 0, "ac3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));

            // update
            da.UpdateCommand = new NpgsqlCommand(
                "update t_rep set"
				 + " pt_id = :pt_id"
				 + ", s_id = :s_id"
				 + ", col0 = :col0"
				 + ", col1 = :col1"
				 + ", col2 = :col2"
				 + ", col3 = :col3"
				 + ", col4 = :col4"
				 + ", col5 = :col5"
				 + ", ac0 = :ac0"
				 + ", ac1 = :ac1"
				 + ", ac2 = :ac2"
				 + ", ac3 = :ac3"
                + " where"
                + " rep_id=:rep_id"
                ,m_conn
                );
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("pt_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "pt_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("col0", NpgsqlTypes.NpgsqlDbType.Text, 0, "col0", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("col1", NpgsqlTypes.NpgsqlDbType.Text, 0, "col1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("col2", NpgsqlTypes.NpgsqlDbType.Text, 0, "col2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("col3", NpgsqlTypes.NpgsqlDbType.Text, 0, "col3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("col4", NpgsqlTypes.NpgsqlDbType.Text, 0, "col4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("col5", NpgsqlTypes.NpgsqlDbType.Text, 0, "col5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("ac0", NpgsqlTypes.NpgsqlDbType.Text, 0, "ac0", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("ac1", NpgsqlTypes.NpgsqlDbType.Text, 0, "ac1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("ac2", NpgsqlTypes.NpgsqlDbType.Text, 0, "ac2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("ac3", NpgsqlTypes.NpgsqlDbType.Text, 0, "ac3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("rep_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "rep_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

            // delete
            da.DeleteCommand = new NpgsqlCommand
            (
                   "delete from t_rep"
                + " where"
                + " rep_id=:rep_id"
                ,m_conn
            );
            da.DeleteCommand.Parameters.Add(new NpgsqlParameter("rep_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "rep_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

            // RowUpdate
            da.RowUpdated += new NpgsqlRowUpdatedEventHandler(repRowUpdated);

            n_id_da.SelectCommand = new NpgsqlCommand
            (
                   "select"
                + " n_id"
                + ", nen"
                + " from t_nen"
                + " order by n_id"
                  ,m_conn
            );

            t_id_da.SelectCommand = new NpgsqlCommand
            (
                   "select"
                  + " t_id"
                  + ", tsuki"
                  + " from t_tsuki"
                  + " order by t_id"
                    ,m_conn
            );

            s_id_da.SelectCommand = new NpgsqlCommand
            (
                   "select"
                  + " s_id"
                  + ", syubetsu"
                  + " from t_syubetsu"
                  + " where s_id < 6"
                  + " order by s_id",
                    m_conn
            );

            pt_id_da.SelectCommand = new NpgsqlCommand
            (
                   "select"
                  + " pt_id"
                  + ", syubetsu"
                  + " from t_shiharai_syubetsu"
                  + " order by pt_id",
                    m_conn
            );

            da.Fill(ds, "rep");
            t_id_da.Fill(t_id_ds, "t_tsuki");
            n_id_da.Fill(n_id_ds, "t_nen");
            s_id_da.Fill(s_id_ds, "t_syubetsu");
            pt_id_da.Fill(pt_id_ds, "t_shiharai_syubetsu");

            cmb_n_id.DataSource = n_id_ds.Tables[0]; ;
            cmb_n_id.DisplayMember = "nen";
            cmb_n_id.ValueMember = "n_id";

            cmb_t_id.DataSource = t_id_ds.Tables[0]; ;
            cmb_t_id.DisplayMember = "tsuki";
            cmb_t_id.ValueMember = "t_id";

            cmb_s_id.DataSource = s_id_ds.Tables[0]; ;
            cmb_s_id.DisplayMember = "syubetsu";
            cmb_s_id.ValueMember = "s_id";

            cmb_pt_id.DataSource = pt_id_ds.Tables[0]; ;
            cmb_pt_id.DisplayMember = "syubetsu";
            cmb_pt_id.ValueMember = "pt_id";

            bindingSourceRep.DataSource = ds;
            bindingSourceRep.DataMember = "rep";

            bindingNavigatorRep.BindingSource = bindingSourceRep;
            dataGridViewRep.AutoGenerateColumns = false;
            dataGridViewRep.DataSource = bindingSourceRep;

            dataGridViewRep.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            DataGridViewEvent();

        }

        private void DataGridViewEvent()
        {
            //dataGridViewRep.DefaultValuesNeeded += new DataGridViewRowEventHandler(dataGridViewRep_DefaultValuesNeeded);

            dataGridViewRep.CellMouseMove += new DataGridViewCellMouseEventHandler(dataGridViewRep_CellMouseMove);

            //dataGridViewRep.CellValidating += new DataGridViewCellValidatingEventHandler(dataGridViewRep_CellValidating);

            //dataGridViewRep.CellEnter += new DataGridViewCellEventHandler(dataGridView_CellEnter);

            //dataGridViewRep.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView_EditingControlShowing);

            dataGridViewRep.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridViewRep_CellPainting);
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            int update_count = 0;
            try
            {
                update_count += da.Update(ds.Tables["rep"].Select(null, null, DataViewRowState.Deleted));
                update_count += da.Update(ds.Tables["rep"].Select(null, null, DataViewRowState.ModifiedCurrent));
                update_count += da.Update(ds.Tables["rep"].Select(null, null, DataViewRowState.Added));
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存に失敗しました。\n\n[内容]\n" + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(update_count.ToString() + "件、保存しました。", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void repRowUpdated(Object sender, NpgsqlRowUpdatedEventArgs e)
        {
            if (e.Status == UpdateStatus.Continue)
            {
                if (e.StatementType == System.Data.StatementType.Insert)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand
                (
                "select"
				 + " pt_id"
				 + ", s_id"
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
				 + ", rep_id"
                + " from"
                + " t_rep"
                + " where rep_id=currval('t_rep_rep_id_seq')"
                + " order by rep_id"
                , m_conn
                 );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        e.Row["pt_id"] = reader["pt_id"];
                        e.Row["s_id"] = reader["s_id"];
                        e.Row["col0"] = reader["col0"];
                        e.Row["col1"] = reader["col1"];
                        e.Row["col2"] = reader["col2"];
                        e.Row["col3"] = reader["col3"];
                        e.Row["col4"] = reader["col4"];
                        e.Row["col5"] = reader["col5"];
                        e.Row["ac0"] = reader["ac0"];
                        e.Row["ac1"] = reader["ac1"];
                        e.Row["ac2"] = reader["ac2"];
                        e.Row["ac3"] = reader["ac3"];
                        e.Row["rep_id"] = reader["rep_id"];
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
				 + " pt_id"
				 + ", s_id"
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
				 + ", rep_id"
                + " from"
                + " t_rep"
                + " where rep_id=" + e.Row["rep_id"].ToString()
                + " order by rep_id"
                ,m_conn
                    );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        e.Row["pt_id"] = reader["pt_id"];
                        e.Row["s_id"] = reader["s_id"];
                        e.Row["col0"] = reader["col0"];
                        e.Row["col1"] = reader["col1"];
                        e.Row["col2"] = reader["col2"];
                        e.Row["col3"] = reader["col3"];
                        e.Row["col4"] = reader["col4"];
                        e.Row["col5"] = reader["col5"];
                        e.Row["ac0"] = reader["ac0"];
                        e.Row["ac1"] = reader["ac1"];
                        e.Row["ac2"] = reader["ac2"];
                        e.Row["ac3"] = reader["ac3"];
                        e.Row["rep_id"] = reader["rep_id"];
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                        throw;
                    }
                }
            }
        }

        private void dataGridViewRep_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e == null) return;

            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;

            if (e.Value == null || e.Value.ToString() == "") return;

            switch (this.dataGridViewRep.Columns[e.ColumnIndex].Name)
            {
                case "results":
                    //string input = e.Value.ToString();
                    string input = (string)dataGridViewRep[2, e.RowIndex].Value.ToString();
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


        private void dataGridViewRep_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;

            if (e.Value == null || e.Value == DBNull.Value) return;

            switch (this.dataGridViewRep.Columns[e.ColumnIndex].Name)
            {
                case "results":

                    e.Value = string.Format("{0:HH:mm:ss}", e.Value);
                    e.FormattingApplied = true;
                    break;
            }
        }

        private void dataGridViewRep_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
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

        private void dataGridViewRep_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cmb_n_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_n_id_int = cmb_n_id.SelectedIndex + 1;
            Console.WriteLine("cmb_n_id_int = " + cmb_n_id_int);
        }

        private void cmb_t_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_t_id_int = cmb_t_id.SelectedIndex + 1;
            Console.WriteLine("cmb_t_id_int = " + cmb_t_id_int);
        }

        private void cmb_s_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_s_id_int = cmb_s_id.SelectedIndex + 1;
            Console.WriteLine("cmb_s_id_int = " + cmb_s_id_int);

            da.SelectCommand = new NpgsqlCommand
            (
                "select"
                 + " pt_id"
                 + ", s_id"
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
                 + ", rep_id"
                 + " from"
                 + " t_rep"
                 + " where s_id::Integer = :s_id"
                 + " and pt_id::Integer = :pt_id"
                 + " order by rep_id"
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

            if (cmb_pt_id.SelectedItem == null)
            {
                da.SelectCommand.Parameters.Add(new NpgsqlParameter("pt_id",
                NpgsqlTypes.NpgsqlDbType.Integer, 0, "pt_id",
                ParameterDirection.Input, false, 0, 0, DataRowVersion.Current,
                DBNull.Value));
            }
            else
            {
                DataRowView row = (DataRowView)cmb_pt_id.SelectedItem;
                da.SelectCommand.Parameters.AddWithValue("pt_id", row["pt_id"]);
            }

            // insert
            da.InsertCommand = new NpgsqlCommand
            (
                 "insert into t_rep ("
                 + " pt_id"
                 + ", s_id"
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
                    + " ) values ("
                 + " :pt_id"
                 + ", :s_id"
                 + ", :col0"
                 + ", :col1"
                 + ", :col2"
                 + ", :col3"
                 + ", :col4"
                 + ", :col5"
                 + ", :ac0"
                 + ", :ac1"
                 + ", :ac2"
                 + ", :ac3"
                    + ")",
                m_conn
            );
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("pt_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "pt_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("col0", NpgsqlTypes.NpgsqlDbType.Text, 0, "col0", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("col1", NpgsqlTypes.NpgsqlDbType.Text, 0, "col1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("col2", NpgsqlTypes.NpgsqlDbType.Text, 0, "col2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("col3", NpgsqlTypes.NpgsqlDbType.Text, 0, "col3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("col4", NpgsqlTypes.NpgsqlDbType.Text, 0, "col4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("col5", NpgsqlTypes.NpgsqlDbType.Text, 0, "col5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("ac0", NpgsqlTypes.NpgsqlDbType.Text, 0, "ac0", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("ac1", NpgsqlTypes.NpgsqlDbType.Text, 0, "ac1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("ac2", NpgsqlTypes.NpgsqlDbType.Text, 0, "ac2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("ac3", NpgsqlTypes.NpgsqlDbType.Text, 0, "ac3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));

            // update
            da.UpdateCommand = new NpgsqlCommand(
                "update t_rep set"
                 + " pt_id = :pt_id"
                 + ", s_id = :s_id"
                 + ", col0 = :col0"
                 + ", col1 = :col1"
                 + ", col2 = :col2"
                 + ", col3 = :col3"
                 + ", col4 = :col4"
                 + ", col5 = :col5"
                 + ", ac0 = :ac0"
                 + ", ac1 = :ac1"
                 + ", ac2 = :ac2"
                 + ", ac3 = :ac3"
                + " where"
                + " rep_id=:rep_id"
                , m_conn
                );
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("pt_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "pt_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("col0", NpgsqlTypes.NpgsqlDbType.Text, 0, "col0", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("col1", NpgsqlTypes.NpgsqlDbType.Text, 0, "col1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("col2", NpgsqlTypes.NpgsqlDbType.Text, 0, "col2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("col3", NpgsqlTypes.NpgsqlDbType.Text, 0, "col3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("col4", NpgsqlTypes.NpgsqlDbType.Text, 0, "col4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("col5", NpgsqlTypes.NpgsqlDbType.Text, 0, "col5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("ac0", NpgsqlTypes.NpgsqlDbType.Text, 0, "ac0", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("ac1", NpgsqlTypes.NpgsqlDbType.Text, 0, "ac1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("ac2", NpgsqlTypes.NpgsqlDbType.Text, 0, "ac2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("ac3", NpgsqlTypes.NpgsqlDbType.Text, 0, "ac3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("rep_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "rep_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

            // delete
            da.DeleteCommand = new NpgsqlCommand
            (
                   "delete from t_rep"
                + " where"
                + " rep_id=:rep_id"
                , m_conn
            );
            da.DeleteCommand.Parameters.Add(new NpgsqlParameter("rep_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "rep_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

            // RowUpdate
            da.RowUpdated += new NpgsqlRowUpdatedEventHandler(repRowUpdated);

            //n_id_da.SelectCommand = new NpgsqlCommand
            //(
            //       "select"
            //    + " n_id"
            //    + ", nen"
            //    + " from t_nen"
            //    + " order by n_id"
            //      , m_conn
            //);

            //t_id_da.SelectCommand = new NpgsqlCommand
            //(
            //       "select"
            //      + " t_id"
            //      + ", tsuki"
            //      + " from t_tsuki"
            //      + " order by t_id"
            //        , m_conn
            //);

            //s_id_da.SelectCommand = new NpgsqlCommand
            //(
            //       "select"
            //      + " s_id"
            //      + ", syubetsu"
            //      + " from t_syubetsu"
            //      + " order by s_id",
            //        m_conn
            //);

            //da.Fill(ds, "rep");
            if (ds.Tables["rep"] != null)
                ds.Tables["rep"].Clear();
            da.Fill(ds, "rep");
            //t_id_da.Fill(t_id_ds, "t_tsuki");
            //n_id_da.Fill(n_id_ds, "t_nen");
            //s_id_da.Fill(s_id_ds, "t_syubetsu");

            //cmb_n_id.DataSource = n_id_ds.Tables[0]; ;
            //cmb_n_id.DisplayMember = "nen";
            //cmb_n_id.ValueMember = "n_id";

            //cmb_t_id.DataSource = t_id_ds.Tables[0]; ;
            //cmb_t_id.DisplayMember = "tsuki";
            //cmb_t_id.ValueMember = "t_id";

            //cmb_s_id.DataSource = s_id_ds.Tables[0]; ;
            //cmb_s_id.DisplayMember = "syubetsu";
            //cmb_s_id.ValueMember = "s_id";

            bindingSourceRep.DataSource = ds;
            bindingSourceRep.DataMember = "rep";

            bindingNavigatorRep.BindingSource = bindingSourceRep;
            dataGridViewRep.AutoGenerateColumns = false;
            dataGridViewRep.DataSource = bindingSourceRep;

            dataGridViewRep.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            DataGridViewEvent();


        }

        private void cmdPrn_Click(object sender, EventArgs e)
        {
            Form_prn Form = new Form_prn();
            Form.ShowDialog();
        }

        private void cmb_pt_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_pt_id_int = cmb_pt_id.SelectedIndex + 1;
            Console.WriteLine("cmb_pt_id_int = " + cmb_pt_id_int);

            da.SelectCommand = new NpgsqlCommand
            (
                "select"
                 + " pt_id"
                 + ", s_id"
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
                 + ", rep_id"
                 + " from"
                 + " t_rep"
                 + " where s_id::Integer = :s_id"
                 + " and pt_id::Integer = :pt_id"
                 + " order by rep_id"
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

            if (cmb_pt_id.SelectedItem == null)
            {
                da.SelectCommand.Parameters.Add(new NpgsqlParameter("pt_id",
                NpgsqlTypes.NpgsqlDbType.Integer, 0, "pt_id",
                ParameterDirection.Input, false, 0, 0, DataRowVersion.Current,
                DBNull.Value));
            }
            else
            {
                DataRowView row = (DataRowView)cmb_pt_id.SelectedItem;
                da.SelectCommand.Parameters.AddWithValue("pt_id", row["pt_id"]);
            }

            // insert
            da.InsertCommand = new NpgsqlCommand
            (
                 "insert into t_rep ("
                 + " pt_id"
                 + ", s_id"
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
                    + " ) values ("
                 + " :pt_id"
                 + ", :s_id"
                 + ", :col0"
                 + ", :col1"
                 + ", :col2"
                 + ", :col3"
                 + ", :col4"
                 + ", :col5"
                 + ", :ac0"
                 + ", :ac1"
                 + ", :ac2"
                 + ", :ac3"
                    + ")",
                m_conn
            );
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("pt_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "pt_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("col0", NpgsqlTypes.NpgsqlDbType.Text, 0, "col0", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("col1", NpgsqlTypes.NpgsqlDbType.Text, 0, "col1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("col2", NpgsqlTypes.NpgsqlDbType.Text, 0, "col2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("col3", NpgsqlTypes.NpgsqlDbType.Text, 0, "col3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("col4", NpgsqlTypes.NpgsqlDbType.Text, 0, "col4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("col5", NpgsqlTypes.NpgsqlDbType.Text, 0, "col5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("ac0", NpgsqlTypes.NpgsqlDbType.Text, 0, "ac0", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("ac1", NpgsqlTypes.NpgsqlDbType.Text, 0, "ac1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("ac2", NpgsqlTypes.NpgsqlDbType.Text, 0, "ac2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("ac3", NpgsqlTypes.NpgsqlDbType.Text, 0, "ac3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));

            // update
            da.UpdateCommand = new NpgsqlCommand(
                "update t_rep set"
                 + " pt_id = :pt_id"
                 + ", s_id = :s_id"
                 + ", col0 = :col0"
                 + ", col1 = :col1"
                 + ", col2 = :col2"
                 + ", col3 = :col3"
                 + ", col4 = :col4"
                 + ", col5 = :col5"
                 + ", ac0 = :ac0"
                 + ", ac1 = :ac1"
                 + ", ac2 = :ac2"
                 + ", ac3 = :ac3"
                + " where"
                + " rep_id=:rep_id"
                , m_conn
                );
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("pt_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "pt_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("s_id", NpgsqlTypes.NpgsqlDbType.Text, 0, "s_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("col0", NpgsqlTypes.NpgsqlDbType.Text, 0, "col0", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("col1", NpgsqlTypes.NpgsqlDbType.Text, 0, "col1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("col2", NpgsqlTypes.NpgsqlDbType.Text, 0, "col2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("col3", NpgsqlTypes.NpgsqlDbType.Text, 0, "col3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("col4", NpgsqlTypes.NpgsqlDbType.Text, 0, "col4", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("col5", NpgsqlTypes.NpgsqlDbType.Text, 0, "col5", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("ac0", NpgsqlTypes.NpgsqlDbType.Text, 0, "ac0", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("ac1", NpgsqlTypes.NpgsqlDbType.Text, 0, "ac1", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("ac2", NpgsqlTypes.NpgsqlDbType.Text, 0, "ac2", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("ac3", NpgsqlTypes.NpgsqlDbType.Text, 0, "ac3", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("rep_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "rep_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

            // delete
            da.DeleteCommand = new NpgsqlCommand
            (
                   "delete from t_rep"
                + " where"
                + " rep_id=:rep_id"
                , m_conn
            );
            da.DeleteCommand.Parameters.Add(new NpgsqlParameter("rep_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "rep_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

            // RowUpdate
            da.RowUpdated += new NpgsqlRowUpdatedEventHandler(repRowUpdated);

            //n_id_da.SelectCommand = new NpgsqlCommand
            //(
            //       "select"
            //    + " n_id"
            //    + ", nen"
            //    + " from t_nen"
            //    + " order by n_id"
            //      , m_conn
            //);

            //t_id_da.SelectCommand = new NpgsqlCommand
            //(
            //       "select"
            //      + " t_id"
            //      + ", tsuki"
            //      + " from t_tsuki"
            //      + " order by t_id"
            //        , m_conn
            //);

            //s_id_da.SelectCommand = new NpgsqlCommand
            //(
            //       "select"
            //      + " s_id"
            //      + ", syubetsu"
            //      + " from t_syubetsu"
            //      + " order by s_id",
            //        m_conn
            //);

            //da.Fill(ds, "rep");
            if (ds.Tables["rep"] != null)
                ds.Tables["rep"].Clear();
            da.Fill(ds, "rep");
            //t_id_da.Fill(t_id_ds, "t_tsuki");
            //n_id_da.Fill(n_id_ds, "t_nen");
            //s_id_da.Fill(s_id_ds, "t_syubetsu");

            //cmb_n_id.DataSource = n_id_ds.Tables[0]; ;
            //cmb_n_id.DisplayMember = "nen";
            //cmb_n_id.ValueMember = "n_id";

            //cmb_t_id.DataSource = t_id_ds.Tables[0]; ;
            //cmb_t_id.DisplayMember = "tsuki";
            //cmb_t_id.ValueMember = "t_id";

            //cmb_s_id.DataSource = s_id_ds.Tables[0]; ;
            //cmb_s_id.DisplayMember = "syubetsu";
            //cmb_s_id.ValueMember = "s_id";

            bindingSourceRep.DataSource = ds;
            bindingSourceRep.DataMember = "rep";

            bindingNavigatorRep.BindingSource = bindingSourceRep;
            dataGridViewRep.AutoGenerateColumns = false;
            dataGridViewRep.DataSource = bindingSourceRep;

            dataGridViewRep.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            DataGridViewEvent();
        }

        private void Form_rep_FormClosing(object sender, FormClosingEventArgs e)
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