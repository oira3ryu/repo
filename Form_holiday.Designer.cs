namespace rk_seikyu
{
    partial class Form_holiday
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_holiday));
            this.holiday = new rk_seikyu.holiday();
            this.bindingSourceHoliday = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorHoliday = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.holidayBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewHoliday = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmb_year = new System.Windows.Forms.ComboBox();
            this.cmdHoliday = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.holiday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceHoliday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorHoliday)).BeginInit();
            this.bindingNavigatorHoliday.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHoliday)).BeginInit();
            this.SuspendLayout();
            // 
            // holiday
            // 
            this.holiday.DataSetName = "holiday";
            this.holiday.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingSourceHoliday
            // 
            this.bindingSourceHoliday.DataMember = "holiday";
            this.bindingSourceHoliday.DataSource = this.holiday;
            // 
            // bindingNavigatorHoliday
            // 
            this.bindingNavigatorHoliday.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigatorHoliday.BindingSource = this.bindingSourceHoliday;
            this.bindingNavigatorHoliday.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigatorHoliday.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigatorHoliday.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.holidayBindingNavigatorSaveItem});
            this.bindingNavigatorHoliday.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigatorHoliday.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigatorHoliday.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigatorHoliday.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigatorHoliday.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigatorHoliday.Name = "bindingNavigatorHoliday";
            this.bindingNavigatorHoliday.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigatorHoliday.Size = new System.Drawing.Size(530, 25);
            this.bindingNavigatorHoliday.TabIndex = 0;
            this.bindingNavigatorHoliday.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "新規追加";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "項目の総数";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "削除";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "最初に移動";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "前に戻る";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "位置";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "現在の場所";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "次に移動";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "最後に移動";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // holidayBindingNavigatorSaveItem
            // 
            this.holidayBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.holidayBindingNavigatorSaveItem.Enabled = false;
            this.holidayBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("holidayBindingNavigatorSaveItem.Image")));
            this.holidayBindingNavigatorSaveItem.Name = "holidayBindingNavigatorSaveItem";
            this.holidayBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.holidayBindingNavigatorSaveItem.Text = "データの保存";
            // 
            // dataGridViewHoliday
            // 
            this.dataGridViewHoliday.AutoGenerateColumns = false;
            this.dataGridViewHoliday.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHoliday.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dataGridViewHoliday.DataSource = this.bindingSourceHoliday;
            this.dataGridViewHoliday.Location = new System.Drawing.Point(149, 69);
            this.dataGridViewHoliday.Name = "dataGridViewHoliday";
            this.dataGridViewHoliday.RowTemplate.Height = 21;
            this.dataGridViewHoliday.Size = new System.Drawing.Size(354, 519);
            this.dataGridViewHoliday.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "h_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "h_id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "holiday";
            this.dataGridViewTextBoxColumn2.HeaderText = "holiday";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "h_name";
            this.dataGridViewTextBoxColumn3.HeaderText = "h_name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // cmb_year
            // 
            this.cmb_year.FormattingEnabled = true;
            this.cmb_year.Location = new System.Drawing.Point(12, 108);
            this.cmb_year.Name = "cmb_year";
            this.cmb_year.Size = new System.Drawing.Size(121, 20);
            this.cmb_year.TabIndex = 2;
            this.cmb_year.SelectedIndexChanged += new System.EventHandler(this.Cmb_year_SelectedIndexChanged);
            // 
            // cmdHoliday
            // 
            this.cmdHoliday.Location = new System.Drawing.Point(49, 173);
            this.cmdHoliday.Name = "cmdHoliday";
            this.cmdHoliday.Size = new System.Drawing.Size(75, 23);
            this.cmdHoliday.TabIndex = 3;
            this.cmdHoliday.Text = "更新";
            this.cmdHoliday.UseVisualStyleBackColor = true;
            this.cmdHoliday.Click += new System.EventHandler(this.CmdHolidaySave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(51, 240);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 4;
            this.cmdClose.Text = "閉じる";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.CmdClose_Click);
            // 
            // Form_holiday
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 586);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdHoliday);
            this.Controls.Add(this.cmb_year);
            this.Controls.Add(this.dataGridViewHoliday);
            this.Controls.Add(this.bindingNavigatorHoliday);
            this.Name = "Form_holiday";
            this.Text = "Form_holiday";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_holiday_FormClosing);
            this.Load += new System.EventHandler(this.Form_holiday_Load);
            ((System.ComponentModel.ISupportInitialize)(this.holiday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceHoliday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorHoliday)).EndInit();
            this.bindingNavigatorHoliday.ResumeLayout(false);
            this.bindingNavigatorHoliday.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHoliday)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private holiday holiday;
        private System.Windows.Forms.BindingSource bindingSourceHoliday;
        private System.Windows.Forms.BindingNavigator bindingNavigatorHoliday;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton holidayBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView dataGridViewHoliday;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ComboBox cmb_year;
        private System.Windows.Forms.Button cmdHoliday;
        private System.Windows.Forms.Button cmdClose;
    }
}