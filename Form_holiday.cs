﻿using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace rk_seikyu
{
    public partial class Form_holiday : Form
    {
        private NpgsqlConnection m_conn = new NpgsqlConnection(rk_seikyu.Properties.Settings.Default.PostgresConnect);

        private NpgsqlDataAdapter da = new NpgsqlDataAdapter();
        private DataSet ds = new DataSet();
        private DataSet year_ds = new DataSet();
       
        public Form_holiday()
        {
            InitializeComponent();
        }

        private void Form_holiday_Load(object sender, EventArgs e)
        {
            dataGridViewHoliday.Columns[0].HeaderText = "ID";
            dataGridViewHoliday.Columns[1].HeaderText = "祝日名";
            dataGridViewHoliday.Columns[2].HeaderText = "説明";

            da.SelectCommand = new NpgsqlCommand
            (
            "SELECT"
            + " distinct DATE_PART('YEAR',holiday) AS year"
            + " FROM t_holiday"
            + " ORDER BY DATE_PART('YEAR',holiday);",
            m_conn
            );
            //if (ds.Tables["t_holiday"] != null)
            //    ds.Tables["t_holiday"].Clear();
            da.Fill(year_ds, "year");

            da.SelectCommand = new NpgsqlCommand
            (
                   "SELECT"
                + " h_id"
                + ", holiday"
                + ", h_name"
                + " FROM"
                + " t_holiday"
                + " ORDER BY holiday;",
                m_conn
            );

            // insert
            da.InsertCommand = new NpgsqlCommand
            (
                    "INSERT INTO t_holiday ("
                + "holiday"
                + ", h_name"
                + " ) VALUES ("
                + " :holiday"
                + ", :h_name"
                + ");",
                m_conn
            );
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("holiday", NpgsqlTypes.NpgsqlDbType.Date, 0, "holiday", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.InsertCommand.Parameters.Add(new NpgsqlParameter("h_name", NpgsqlTypes.NpgsqlDbType.Text, 0, "h_name", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));

            // update
            da.UpdateCommand = new NpgsqlCommand(
                "UPDATE t_holiday SET"
                + " holiday = :holiday"
                + ", h_name = :h_name"
                + " WHERE"
                + " h_id = :h_id;"
                , m_conn
                );
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("holiday", NpgsqlTypes.NpgsqlDbType.Date, 0, "holiday", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("h_name", NpgsqlTypes.NpgsqlDbType.Text, 0, "h_name", ParameterDirection.Input, false, 0, 0, DataRowVersion.Current, DBNull.Value));
            da.UpdateCommand.Parameters.Add(new NpgsqlParameter("h_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "h_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

            // delete
            da.DeleteCommand = new NpgsqlCommand
            (
                   "DELETE FROM t_holiday"
                + " WHERE"
                + " h_id = :h_id;"
                , m_conn
            );
            da.DeleteCommand.Parameters.Add(new NpgsqlParameter("h_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "h_id", ParameterDirection.Input, false, 0, 0, DataRowVersion.Original, DBNull.Value));

            // RowUpdate
            da.RowUpdated += new NpgsqlRowUpdatedEventHandler(HolidayRowUpdated);


            //if (ds.Tables["t_holiday"] != null)
            //    ds.Tables["t_holiday"].Clear();
            da.Fill(ds, "holiday");

            bindingSourceHoliday.DataSource = ds;
            bindingSourceHoliday.DataMember = "holiday";

            bindingNavigatorHoliday.BindingSource = bindingSourceHoliday;

            //dataGridViewHoliday.AutoGenerateColumns = false;

            dataGridViewHoliday.DataSource = bindingSourceHoliday;

            dataGridViewHoliday.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            bindingNavigatorHoliday.Visible = true;

            dataGridViewHoliday.Visible = true;

            cmb_year.DataSource = year_ds.Tables[0]; ;
            cmb_year.DisplayMember = "year";
            cmb_year.ValueMember = "year";

            DataGridViewEvent();
        }

        private void DataGridViewEvent()
        {
            dataGridViewHoliday.CellMouseMove += new DataGridViewCellMouseEventHandler(DataGridViewHoliday_CellMouseMove);
            dataGridViewHoliday.CellPainting += new DataGridViewCellPaintingEventHandler(DataGridViewHoliday_CellPainting);
        }

        private void CmdHolidaySave_Click(object sender, EventArgs e)
        {
            int update_count = 0;
            try
            {
                update_count += da.Update(ds.Tables["holiday"].Select(null, null, DataViewRowState.Deleted));
                update_count += da.Update(ds.Tables["holiday"].Select(null, null, DataViewRowState.ModifiedCurrent));
                update_count += da.Update(ds.Tables["holiday"].Select(null, null, DataViewRowState.Added));
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存に失敗しました。\n\n[内容]\n" + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(update_count.ToString() + "件、保存しました。", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void HolidayRowUpdated(Object sender, NpgsqlRowUpdatedEventArgs e)
        {
            if (e.Status == UpdateStatus.Continue)
            {
                if (e.StatementType == System.Data.StatementType.Insert)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand
                (
                "SELECT"
                + " h_id"
                + ", holiday"
                + ", h_name"
                + " FROM"
                + " t_holiday"
                + " WHERE h_id = currval('t_holiday_h_id_seq')"
                + " ORDER BY h_id;"
                , m_conn
                 );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        e.Row["h_id"] = reader["h_id"];
                        e.Row["holiday"] = reader["holiday"];
                        e.Row["h_name"] = reader["h_name"];
                        reader.Close();
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
                + " h_id"
                + ", holiday"
                + ", h_name"
                + " FROM"
                + " t_holiday"
                + " WHERE h_id = " + e.Row["h_id"].ToString()
                + " ORDER BY h_id;"
                , m_conn
                    );
                    try
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        e.Row["h_id"] = reader["h_id"];
                        e.Row["holiday"] = reader["holiday"];
                        e.Row["h_name"] = reader["h_name"];
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                        throw;
                    }
                }
            }
        }

        private void Cmb_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Data.DataRowView view_year = (DataRowView)this.cmb_year.SelectedItem;
            Console.WriteLine("view_year  = " + view_year);
            Cmb_year_str = view_year.Row.ItemArray[0].ToString();

            da.SelectCommand = new NpgsqlCommand
            (
                   "SELECT"
                + " h_id"
                + ", holiday"
                + ", h_name"
                + " FROM"
                + " t_holiday"
                + " WHERE DATE_PART('YEAR',holiday) = '" + Cmb_year_str + "'"
                + " ORDER BY holiday;",
                m_conn

            );

            if (ds.Tables["holiday"] != null)
                ds.Tables["holiday"].Clear();
            da.Fill(ds, "holiday");

            bindingSourceHoliday.DataSource = ds;
            bindingSourceHoliday.DataMember = "holiday";

            bindingNavigatorHoliday.BindingSource = bindingSourceHoliday;

            //dataGridViewHoliday.AutoGenerateColumns = false;

            dataGridViewHoliday.DataSource = bindingSourceHoliday;

            dataGridViewHoliday.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            bindingNavigatorHoliday.Visible = true;

        }

        private void CmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Form_holiday_FormClosing(object sender, FormClosingEventArgs e)
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

        private void DataGridViewHoliday_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
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

        private void DataGridViewHoliday_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        public object Cmb_year_str { get; set; }
    }
}
