namespace rk_seikyu
{
    partial class Form_prn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_prn));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmb_n_id = new System.Windows.Forms.ComboBox();
            this.cmb_t_id = new System.Windows.Forms.ComboBox();
            this.crvSeikyu = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.cmb_p_id = new System.Windows.Forms.ComboBox();
            this.cmb_req_id = new System.Windows.Forms.ComboBox();
            this.cmb_s_id = new System.Windows.Forms.ComboBox();
            this.cmb_c4 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cmdPrv = new System.Windows.Forms.Button();
            this.cmb_prn_id = new System.Windows.Forms.ComboBox();
            this.cmd_holiday = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmb_nen = new System.Windows.Forms.ComboBox();
            this.nenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nen = new rk_seikyu.nen();
            this.cmb_tsuki = new System.Windows.Forms.ComboBox();
            this.tsukiBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tsukiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tsuki = new rk_seikyu.tsuki();
            this.withdrawal_ds = new rk_seikyu.withdrawal_ds();
            this.bindingSourceWithdrawal = new System.Windows.Forms.BindingSource(this.components);
            this.syubetsuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorWithdrawal = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.cmb_b_code = new System.Windows.Forms.ComboBox();
            this.cmd_Ins = new System.Windows.Forms.Button();
            this.syubetsuBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewWithdrawal = new System.Windows.Forms.DataGridView();
            this.wflgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.c3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c19DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c4DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c9DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c11DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c14DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c16DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c22DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ridDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timestampDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.last_day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdPrnWithdrawal = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBoxAll = new System.Windows.Forms.CheckBox();
            this.chk_title = new System.Windows.Forms.CheckBox();
            this.checkBoxIni = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nenBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsukiBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsukiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsuki)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.withdrawal_ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceWithdrawal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.syubetsuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorWithdrawal)).BeginInit();
            this.bindingNavigatorWithdrawal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.syubetsuBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWithdrawal)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(89, 723);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 1;
            this.cmdClose.Text = "閉じる";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.CmdClose_Click);
            // 
            // cmb_n_id
            // 
            this.cmb_n_id.Location = new System.Drawing.Point(46, 30);
            this.cmb_n_id.Name = "cmb_n_id";
            this.cmb_n_id.Size = new System.Drawing.Size(121, 20);
            this.cmb_n_id.TabIndex = 10;
            this.cmb_n_id.Visible = false;
            // 
            // cmb_t_id
            // 
            this.cmb_t_id.Location = new System.Drawing.Point(46, 56);
            this.cmb_t_id.Name = "cmb_t_id";
            this.cmb_t_id.Size = new System.Drawing.Size(121, 20);
            this.cmb_t_id.TabIndex = 9;
            this.cmb_t_id.Visible = false;
            // 
            // crvSeikyu
            // 
            this.crvSeikyu.ActiveViewIndex = -1;
            this.crvSeikyu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvSeikyu.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvSeikyu.Location = new System.Drawing.Point(219, 114);
            this.crvSeikyu.Name = "crvSeikyu";
            this.crvSeikyu.Size = new System.Drawing.Size(1114, 826);
            this.crvSeikyu.TabIndex = 4;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(219, 1);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1114, 696);
            this.crystalReportViewer1.TabIndex = 4;
            // 
            // cmb_p_id
            // 
            this.cmb_p_id.FormattingEnabled = true;
            this.cmb_p_id.Location = new System.Drawing.Point(44, 77);
            this.cmb_p_id.Name = "cmb_p_id";
            this.cmb_p_id.Size = new System.Drawing.Size(121, 20);
            this.cmb_p_id.TabIndex = 5;
            this.cmb_p_id.Visible = false;
            this.cmb_p_id.SelectedIndexChanged += new System.EventHandler(this.Cmb_p_id_SelectedIndexChanged);
            // 
            // cmb_req_id
            // 
            this.cmb_req_id.FormattingEnabled = true;
            this.cmb_req_id.Location = new System.Drawing.Point(44, 103);
            this.cmb_req_id.Name = "cmb_req_id";
            this.cmb_req_id.Size = new System.Drawing.Size(121, 20);
            this.cmb_req_id.TabIndex = 6;
            this.cmb_req_id.Visible = false;
            this.cmb_req_id.SelectedIndexChanged += new System.EventHandler(this.Cmb_req_id_SelectedIndexChanged);
            // 
            // cmb_s_id
            // 
            this.cmb_s_id.FormattingEnabled = true;
            this.cmb_s_id.Location = new System.Drawing.Point(44, 288);
            this.cmb_s_id.Name = "cmb_s_id";
            this.cmb_s_id.Size = new System.Drawing.Size(121, 20);
            this.cmb_s_id.TabIndex = 7;
            this.cmb_s_id.SelectedIndexChanged += new System.EventHandler(this.Cmb_s_id_SelectedIndexChanged);
            // 
            // cmb_c4
            // 
            this.cmb_c4.FormattingEnabled = true;
            this.cmb_c4.Location = new System.Drawing.Point(46, 129);
            this.cmb_c4.Name = "cmb_c4";
            this.cmb_c4.Size = new System.Drawing.Size(121, 20);
            this.cmb_c4.TabIndex = 8;
            this.cmb_c4.Visible = false;
            this.cmb_c4.SelectedIndexChanged += new System.EventHandler(this.Cmb_c4_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(44, 417);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(121, 19);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // cmdPrv
            // 
            this.cmdPrv.Location = new System.Drawing.Point(90, 447);
            this.cmdPrv.Name = "cmdPrv";
            this.cmdPrv.Size = new System.Drawing.Size(75, 23);
            this.cmdPrv.TabIndex = 12;
            this.cmdPrv.Text = "表示";
            this.cmdPrv.UseVisualStyleBackColor = true;
            this.cmdPrv.Click += new System.EventHandler(this.CmdPrv_Click);
            // 
            // cmb_prn_id
            // 
            this.cmb_prn_id.FormattingEnabled = true;
            this.cmb_prn_id.Location = new System.Drawing.Point(44, 331);
            this.cmb_prn_id.Name = "cmb_prn_id";
            this.cmb_prn_id.Size = new System.Drawing.Size(121, 20);
            this.cmb_prn_id.TabIndex = 13;
            this.cmb_prn_id.SelectedIndexChanged += new System.EventHandler(this.Cmb_prn_id_SelectedIndexChanged);
            // 
            // cmd_holiday
            // 
            this.cmd_holiday.Location = new System.Drawing.Point(90, 612);
            this.cmd_holiday.Name = "cmd_holiday";
            this.cmd_holiday.Size = new System.Drawing.Size(75, 23);
            this.cmd_holiday.TabIndex = 14;
            this.cmd_holiday.Text = "祝日設定";
            this.cmd_holiday.UseVisualStyleBackColor = true;
            this.cmd_holiday.Click += new System.EventHandler(this.Cmd_holiday_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(89, 650);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "口座設定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Cmd_bank_Click);
            // 
            // cmb_nen
            // 
            this.cmb_nen.DataSource = this.nenBindingSource;
            this.cmb_nen.DisplayMember = "nen";
            this.cmb_nen.FormattingEnabled = true;
            this.cmb_nen.Location = new System.Drawing.Point(44, 243);
            this.cmb_nen.Name = "cmb_nen";
            this.cmb_nen.Size = new System.Drawing.Size(56, 20);
            this.cmb_nen.TabIndex = 16;
            this.cmb_nen.ValueMember = "n_id";
            this.cmb_nen.SelectedIndexChanged += new System.EventHandler(this.Cmb_nen_SelectedIndexChanged);
            // 
            // nenBindingSource
            // 
            this.nenBindingSource.DataMember = "nen";
            this.nenBindingSource.DataSource = this.nen;
            // 
            // nen
            // 
            this.nen.DataSetName = "nen";
            this.nen.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cmb_tsuki
            // 
            this.cmb_tsuki.DataSource = this.tsukiBindingSource1;
            this.cmb_tsuki.DisplayMember = "tsuki";
            this.cmb_tsuki.FormattingEnabled = true;
            this.cmb_tsuki.Location = new System.Drawing.Point(109, 243);
            this.cmb_tsuki.Name = "cmb_tsuki";
            this.cmb_tsuki.Size = new System.Drawing.Size(56, 20);
            this.cmb_tsuki.TabIndex = 17;
            this.cmb_tsuki.ValueMember = "t_id";
            this.cmb_tsuki.SelectedIndexChanged += new System.EventHandler(this.Cmb_tsuki_SelectedIndexChanged);
            // 
            // tsukiBindingSource1
            // 
            this.tsukiBindingSource1.DataMember = "tsuki";
            this.tsukiBindingSource1.DataSource = this.tsukiBindingSource;
            // 
            // tsukiBindingSource
            // 
            this.tsukiBindingSource.DataSource = this.tsuki;
            this.tsukiBindingSource.Position = 0;
            // 
            // tsuki
            // 
            this.tsuki.DataSetName = "tsuki";
            this.tsuki.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // withdrawal_ds
            // 
            this.withdrawal_ds.DataSetName = "withdrawal_ds";
            this.withdrawal_ds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingSourceWithdrawal
            // 
            this.bindingSourceWithdrawal.DataMember = "withdrawal_ds";
            this.bindingSourceWithdrawal.DataSource = this.withdrawal_ds;
            // 
            // syubetsuBindingSource
            // 
            this.syubetsuBindingSource.DataMember = "syubetsu";
            // 
            // bindingNavigatorWithdrawal
            // 
            this.bindingNavigatorWithdrawal.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigatorWithdrawal.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigatorWithdrawal.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigatorWithdrawal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bindingNavigatorDeleteItem});
            this.bindingNavigatorWithdrawal.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigatorWithdrawal.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigatorWithdrawal.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigatorWithdrawal.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigatorWithdrawal.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigatorWithdrawal.Name = "bindingNavigatorWithdrawal";
            this.bindingNavigatorWithdrawal.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigatorWithdrawal.Size = new System.Drawing.Size(1604, 25);
            this.bindingNavigatorWithdrawal.TabIndex = 18;
            this.bindingNavigatorWithdrawal.Text = "bindingNavigator1";
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
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(29, 22);
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
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
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
            // cmb_b_code
            // 
            this.cmb_b_code.FormattingEnabled = true;
            this.cmb_b_code.Location = new System.Drawing.Point(44, 373);
            this.cmb_b_code.Name = "cmb_b_code";
            this.cmb_b_code.Size = new System.Drawing.Size(121, 20);
            this.cmb_b_code.TabIndex = 19;
            this.cmb_b_code.SelectedIndexChanged += new System.EventHandler(this.Cmb_b_code_SelectedIndexChanged);
            // 
            // cmd_Ins
            // 
            this.cmd_Ins.Location = new System.Drawing.Point(90, 476);
            this.cmd_Ins.Name = "cmd_Ins";
            this.cmd_Ins.Size = new System.Drawing.Size(75, 23);
            this.cmd_Ins.TabIndex = 20;
            this.cmd_Ins.Text = "保存";
            this.cmd_Ins.UseVisualStyleBackColor = true;
            this.cmd_Ins.Click += new System.EventHandler(this.Cmd_Ins_Click);
            // 
            // syubetsuBindingSource1
            // 
            this.syubetsuBindingSource1.DataMember = "syubetsu";
            // 
            // dataGridViewWithdrawal
            // 
            this.dataGridViewWithdrawal.AutoGenerateColumns = false;
            this.dataGridViewWithdrawal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWithdrawal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.wflgDataGridViewTextBoxColumn,
            this.c3DataGridViewTextBoxColumn,
            this.c19DataGridViewTextBoxColumn,
            this.c4DataGridViewTextBoxColumn,
            this.c9DataGridViewTextBoxColumn,
            this.c11DataGridViewTextBoxColumn,
            this.c14DataGridViewTextBoxColumn,
            this.c16DataGridViewTextBoxColumn,
            this.c22DataGridViewTextBoxColumn,
            this.sidDataGridViewTextBoxColumn,
            this.ridDataGridViewTextBoxColumn,
            this.timestampDataGridViewTextBoxColumn,
            this.last_day});
            this.dataGridViewWithdrawal.DataSource = this.bindingSourceWithdrawal;
            this.dataGridViewWithdrawal.Location = new System.Drawing.Point(219, 28);
            this.dataGridViewWithdrawal.Name = "dataGridViewWithdrawal";
            this.dataGridViewWithdrawal.RowTemplate.Height = 21;
            this.dataGridViewWithdrawal.Size = new System.Drawing.Size(1246, 912);
            this.dataGridViewWithdrawal.TabIndex = 21;
            this.dataGridViewWithdrawal.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewWithdrawal_CellClick);
            this.dataGridViewWithdrawal.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewWithdrawal_CellContentClick);
            this.dataGridViewWithdrawal.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewWithdrawal_CellMouseMove);
            this.dataGridViewWithdrawal.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewWithdrawal_CellMouseMove);
            this.dataGridViewWithdrawal.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DataGridViewWithdrawal_CellPainting);
            this.dataGridViewWithdrawal.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewWithdrawal_CellValueChanged);
            this.dataGridViewWithdrawal.CurrentCellDirtyStateChanged += new System.EventHandler(this.DataGridViewWithdrawal_CurrentCellDirtyStateChanged);
            this.dataGridViewWithdrawal.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewWithdrawal_CellValueChanged);
            // 
            // wflgDataGridViewTextBoxColumn
            // 
            this.wflgDataGridViewTextBoxColumn.DataPropertyName = "w_flg";
            this.wflgDataGridViewTextBoxColumn.HeaderText = "";
            this.wflgDataGridViewTextBoxColumn.Name = "wflgDataGridViewTextBoxColumn";
            this.wflgDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.wflgDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.wflgDataGridViewTextBoxColumn.TrueValue = "1";
            // 
            // c3DataGridViewTextBoxColumn
            // 
            this.c3DataGridViewTextBoxColumn.DataPropertyName = "c3";
            this.c3DataGridViewTextBoxColumn.HeaderText = "c3";
            this.c3DataGridViewTextBoxColumn.Name = "c3DataGridViewTextBoxColumn";
            // 
            // c19DataGridViewTextBoxColumn
            // 
            this.c19DataGridViewTextBoxColumn.DataPropertyName = "c19";
            this.c19DataGridViewTextBoxColumn.HeaderText = "c19";
            this.c19DataGridViewTextBoxColumn.Name = "c19DataGridViewTextBoxColumn";
            // 
            // c4DataGridViewTextBoxColumn
            // 
            this.c4DataGridViewTextBoxColumn.DataPropertyName = "c4_ym";
            this.c4DataGridViewTextBoxColumn.HeaderText = "c4_ym";
            this.c4DataGridViewTextBoxColumn.Name = "c4DataGridViewTextBoxColumn";
            // 
            // c9DataGridViewTextBoxColumn
            // 
            this.c9DataGridViewTextBoxColumn.DataPropertyName = "c9";
            this.c9DataGridViewTextBoxColumn.HeaderText = "c9";
            this.c9DataGridViewTextBoxColumn.Name = "c9DataGridViewTextBoxColumn";
            // 
            // c11DataGridViewTextBoxColumn
            // 
            this.c11DataGridViewTextBoxColumn.DataPropertyName = "c11";
            this.c11DataGridViewTextBoxColumn.HeaderText = "c11";
            this.c11DataGridViewTextBoxColumn.Name = "c11DataGridViewTextBoxColumn";
            // 
            // c14DataGridViewTextBoxColumn
            // 
            this.c14DataGridViewTextBoxColumn.DataPropertyName = "c14";
            this.c14DataGridViewTextBoxColumn.HeaderText = "c14";
            this.c14DataGridViewTextBoxColumn.Name = "c14DataGridViewTextBoxColumn";
            // 
            // c16DataGridViewTextBoxColumn
            // 
            this.c16DataGridViewTextBoxColumn.DataPropertyName = "c16";
            this.c16DataGridViewTextBoxColumn.HeaderText = "c16";
            this.c16DataGridViewTextBoxColumn.Name = "c16DataGridViewTextBoxColumn";
            // 
            // c22DataGridViewTextBoxColumn
            // 
            this.c22DataGridViewTextBoxColumn.DataPropertyName = "c22";
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.c22DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.c22DataGridViewTextBoxColumn.HeaderText = "c22";
            this.c22DataGridViewTextBoxColumn.Name = "c22DataGridViewTextBoxColumn";
            // 
            // sidDataGridViewTextBoxColumn
            // 
            this.sidDataGridViewTextBoxColumn.DataPropertyName = "s_id";
            this.sidDataGridViewTextBoxColumn.HeaderText = "s_id";
            this.sidDataGridViewTextBoxColumn.Name = "sidDataGridViewTextBoxColumn";
            // 
            // ridDataGridViewTextBoxColumn
            // 
            this.ridDataGridViewTextBoxColumn.DataPropertyName = "r_id";
            this.ridDataGridViewTextBoxColumn.HeaderText = "r_id";
            this.ridDataGridViewTextBoxColumn.Name = "ridDataGridViewTextBoxColumn";
            // 
            // timestampDataGridViewTextBoxColumn
            // 
            this.timestampDataGridViewTextBoxColumn.DataPropertyName = "time_stamp";
            this.timestampDataGridViewTextBoxColumn.HeaderText = "time_stamp";
            this.timestampDataGridViewTextBoxColumn.Name = "timestampDataGridViewTextBoxColumn";
            this.timestampDataGridViewTextBoxColumn.Visible = false;
            // 
            // last_day
            // 
            this.last_day.DataPropertyName = "last_day";
            this.last_day.HeaderText = "last_day";
            this.last_day.Name = "last_day";
            // 
            // cmdPrnWithdrawal
            // 
            this.cmdPrnWithdrawal.Location = new System.Drawing.Point(89, 505);
            this.cmdPrnWithdrawal.Name = "cmdPrnWithdrawal";
            this.cmdPrnWithdrawal.Size = new System.Drawing.Size(75, 23);
            this.cmdPrnWithdrawal.TabIndex = 22;
            this.cmdPrnWithdrawal.Text = "印刷";
            this.cmdPrnWithdrawal.UseVisualStyleBackColor = true;
            this.cmdPrnWithdrawal.Click += new System.EventHandler(this.CmdPrnWithdrawal_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(44, 155);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 19);
            this.textBox1.TabIndex = 23;
            this.textBox1.Visible = false;
            // 
            // checkBoxAll
            // 
            this.checkBoxAll.AutoSize = true;
            this.checkBoxAll.Location = new System.Drawing.Point(291, 33);
            this.checkBoxAll.Name = "checkBoxAll";
            this.checkBoxAll.Size = new System.Drawing.Size(15, 14);
            this.checkBoxAll.TabIndex = 24;
            this.checkBoxAll.UseVisualStyleBackColor = true;
            this.checkBoxAll.Visible = false;
            this.checkBoxAll.CheckedChanged += new System.EventHandler(this.CheckBoxAll_CheckedChanged);
            // 
            // chk_title
            // 
            this.chk_title.AutoSize = true;
            this.chk_title.Location = new System.Drawing.Point(89, 577);
            this.chk_title.Name = "chk_title";
            this.chk_title.Size = new System.Drawing.Size(121, 16);
            this.chk_title.TabIndex = 25;
            this.chk_title.Text = "請求月を配列にする";
            this.chk_title.UseVisualStyleBackColor = true;
            this.chk_title.CheckedChanged += new System.EventHandler(this.Chk_title_CheckedChanged);
            // 
            // checkBoxIni
            // 
            this.checkBoxIni.AutoSize = true;
            this.checkBoxIni.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxIni.Location = new System.Drawing.Point(90, 555);
            this.checkBoxIni.Name = "checkBoxIni";
            this.checkBoxIni.Size = new System.Drawing.Size(60, 16);
            this.checkBoxIni.TabIndex = 26;
            this.checkBoxIni.Text = "初期化";
            this.checkBoxIni.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxIni.UseVisualStyleBackColor = true;
            // 
            // Form_prn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1604, 968);
            this.Controls.Add(this.checkBoxIni);
            this.Controls.Add(this.chk_title);
            this.Controls.Add(this.checkBoxAll);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cmdPrnWithdrawal);
            this.Controls.Add(this.dataGridViewWithdrawal);
            this.Controls.Add(this.cmd_Ins);
            this.Controls.Add(this.cmb_b_code);
            this.Controls.Add(this.bindingNavigatorWithdrawal);
            this.Controls.Add(this.cmb_tsuki);
            this.Controls.Add(this.cmb_nen);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmd_holiday);
            this.Controls.Add(this.cmb_prn_id);
            this.Controls.Add(this.cmdPrv);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.cmb_c4);
            this.Controls.Add(this.cmb_s_id);
            this.Controls.Add(this.cmb_req_id);
            this.Controls.Add(this.cmb_p_id);
            this.Controls.Add(this.crvSeikyu);
            this.Controls.Add(this.cmb_t_id);
            this.Controls.Add(this.cmb_n_id);
            this.Controls.Add(this.cmdClose);
            this.Name = "Form_prn";
            this.Text = "FormPrn";
            this.Load += new System.EventHandler(this.FormPrn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nenBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsukiBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsukiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsuki)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.withdrawal_ds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceWithdrawal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.syubetsuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorWithdrawal)).EndInit();
            this.bindingNavigatorWithdrawal.ResumeLayout(false);
            this.bindingNavigatorWithdrawal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.syubetsuBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWithdrawal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.ComboBox cmb_n_id;
        private System.Windows.Forms.ComboBox cmb_t_id;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvSeikyu;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.ComboBox cmb_p_id;
        private System.Windows.Forms.ComboBox cmb_req_id;
        private System.Windows.Forms.ComboBox cmb_s_id;
        private System.Windows.Forms.ComboBox cmb_c4;

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button cmdPrv;
        private System.Windows.Forms.ComboBox cmb_prn_id;
        private System.Windows.Forms.Button cmd_holiday;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmb_nen;
        private System.Windows.Forms.BindingSource nenBindingSource;
        private nen nen;
        private System.Windows.Forms.ComboBox cmb_tsuki;
        private System.Windows.Forms.BindingSource tsukiBindingSource1;
        private System.Windows.Forms.BindingSource tsukiBindingSource;
        private tsuki tsuki;
        private withdrawal_ds withdrawal_ds;
        private System.Windows.Forms.BindingSource bindingSourceWithdrawal;
        private System.Windows.Forms.BindingNavigator bindingNavigatorWithdrawal;
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
        private System.Windows.Forms.ComboBox cmb_b_code;
        private System.Windows.Forms.Button cmd_Ins;
        private System.Windows.Forms.BindingSource syubetsuBindingSource;
        //private s_id s_id;
        private System.Windows.Forms.BindingSource syubetsuBindingSource1;
        private System.Windows.Forms.DataGridView dataGridViewWithdrawal;
        private System.Windows.Forms.Button cmdPrnWithdrawal;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBoxAll;
        private System.Windows.Forms.CheckBox chk_title;
        private System.Windows.Forms.DataGridViewCheckBoxColumn wflgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn c3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn c19DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn c4DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn c9DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn c11DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn c14DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn c16DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn c22DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ridDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timestampDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn last_day;
        private System.Windows.Forms.CheckBox checkBoxIni;
    }
}