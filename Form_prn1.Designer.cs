namespace rk_seikyu
{
    partial class Form_prn1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_prn1));
            this.dataGridViewAbd = new System.Windows.Forms.DataGridView();
            this.c19ds1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorAbd = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.button1 = new System.Windows.Forms.Button();
            this.CmdClose = new System.Windows.Forms.Button();
            this.bindingSourceAbd = new System.Windows.Forms.BindingSource(this.components);
            this.abd = new rk_seikyu.abd();
            this.c19_ds1 = new rk_seikyu.c19_ds();
            this.c19ds1BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.c9_ds1 = new rk_seikyu.c9_ds();
            this.c9ds1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.w_flg = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.c3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.c4_ym = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c1_bc = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.c11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.r_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.o_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.last_day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAbd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c19ds1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorAbd)).BeginInit();
            this.bindingNavigatorAbd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAbd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.abd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c19_ds1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c19ds1BindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c9_ds1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c9ds1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAbd
            // 
            this.dataGridViewAbd.AutoGenerateColumns = false;
            this.dataGridViewAbd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAbd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.w_flg,
            this.c3,
            this.c1,
            this.c4_ym,
            this.c1_bc,
            this.c11,
            this.c14,
            this.c16,
            this.c22,
            this.s_id,
            this.r_id,
            this.o_id,
            this.last_day});
            this.dataGridViewAbd.DataSource = this.bindingSourceAbd;
            this.dataGridViewAbd.Location = new System.Drawing.Point(202, 100);
            this.dataGridViewAbd.Name = "dataGridViewAbd";
            this.dataGridViewAbd.RowTemplate.Height = 21;
            this.dataGridViewAbd.Size = new System.Drawing.Size(1089, 314);
            this.dataGridViewAbd.TabIndex = 0;
            // 
            // bindingNavigatorAbd
            // 
            this.bindingNavigatorAbd.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigatorAbd.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigatorAbd.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigatorAbd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bindingNavigatorAbd.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigatorAbd.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigatorAbd.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigatorAbd.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigatorAbd.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigatorAbd.Name = "bindingNavigatorAbd";
            this.bindingNavigatorAbd.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigatorAbd.Size = new System.Drawing.Size(1321, 25);
            this.bindingNavigatorAbd.TabIndex = 1;
            this.bindingNavigatorAbd.Text = "bindingNavigator1";
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(63, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // CmdClose
            // 
            this.CmdClose.Location = new System.Drawing.Point(63, 174);
            this.CmdClose.Name = "CmdClose";
            this.CmdClose.Size = new System.Drawing.Size(75, 23);
            this.CmdClose.TabIndex = 3;
            this.CmdClose.Text = "閉じる";
            this.CmdClose.UseVisualStyleBackColor = true;
            this.CmdClose.Click += new System.EventHandler(this.CmdClose_Click_1);
            // 
            // bindingSourceAbd
            // 
            this.bindingSourceAbd.DataSource = this.abd;
            this.bindingSourceAbd.Position = 0;
            this.bindingSourceAbd.CurrentChanged += new System.EventHandler(this.abdBindingSource_CurrentChanged);
            // 
            // abd
            // 
            this.abd.DataSetName = "abd";
            this.abd.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // c19_ds1
            // 
            this.c19_ds1.DataSetName = "c19_ds";
            this.c19_ds1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // c19ds1BindingSource1
            // 
            this.c19ds1BindingSource1.DataSource = this.c19_ds1;
            this.c19ds1BindingSource1.Position = 0;
            // 
            // c9_ds1
            // 
            this.c9_ds1.DataSetName = "c9_ds";
            this.c9_ds1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // c9ds1BindingSource
            // 
            this.c9ds1BindingSource.DataSource = this.c9_ds1;
            this.c9ds1BindingSource.Position = 0;
            // 
            // w_flg
            // 
            this.w_flg.DataPropertyName = "w_flg";
            this.w_flg.HeaderText = "□";
            this.w_flg.Name = "w_flg";
            this.w_flg.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.w_flg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // c3
            // 
            this.c3.DataPropertyName = "c3";
            this.c3.HeaderText = "氏名";
            this.c3.Name = "c3";
            // 
            // c1
            // 
            this.c1.DataPropertyName = "c1";
            this.c1.DataSource = this.c19ds1BindingSource;
            this.c1.HeaderText = "支払者";
            this.c1.Name = "c1";
            this.c1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.c1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // c4_ym
            // 
            this.c4_ym.DataPropertyName = "c4_ym";
            this.c4_ym.HeaderText = "年月";
            this.c4_ym.Name = "c4_ym";
            // 
            // c1_bc
            // 
            this.c1_bc.DataPropertyName = "c1_bc";
            this.c1_bc.DataSource = this.c9ds1BindingSource;
            this.c1_bc.HeaderText = "銀行ｺｰﾄﾞ";
            this.c1_bc.Name = "c1_bc";
            this.c1_bc.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.c1_bc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // c11
            // 
            this.c11.DataPropertyName = "c11";
            this.c11.HeaderText = "金融機関名";
            this.c11.Name = "c11";
            // 
            // c14
            // 
            this.c14.DataPropertyName = "c14";
            this.c14.HeaderText = "支店名";
            this.c14.Name = "c14";
            // 
            // c16
            // 
            this.c16.DataPropertyName = "c16";
            this.c16.HeaderText = "口座番号";
            this.c16.Name = "c16";
            // 
            // c22
            // 
            this.c22.DataPropertyName = "c22";
            this.c22.HeaderText = "請求額";
            this.c22.Name = "c22";
            // 
            // s_id
            // 
            this.s_id.DataPropertyName = "s_id";
            this.s_id.HeaderText = "種別";
            this.s_id.Name = "s_id";
            // 
            // r_id
            // 
            this.r_id.DataPropertyName = "r_id";
            this.r_id.HeaderText = "番号";
            this.r_id.Name = "r_id";
            // 
            // o_id
            // 
            this.o_id.DataPropertyName = "o_id";
            this.o_id.HeaderText = "事業名";
            this.o_id.Name = "o_id";
            // 
            // last_day
            // 
            this.last_day.HeaderText = "引落日";
            this.last_day.Name = "last_day";
            // 
            // Form_prn1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 450);
            this.Controls.Add(this.CmdClose);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bindingNavigatorAbd);
            this.Controls.Add(this.dataGridViewAbd);
            this.Name = "Form_prn1";
            this.Text = "Form_prn1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_prn1_FormClosing);
            this.Load += new System.EventHandler(this.Form_prn1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAbd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c19ds1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorAbd)).EndInit();
            this.bindingNavigatorAbd.ResumeLayout(false);
            this.bindingNavigatorAbd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAbd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.abd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c19_ds1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c19ds1BindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c9_ds1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c9ds1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAbd;
        private System.Windows.Forms.BindingSource bindingSourceAbd;
        private abd abd;
        private System.Windows.Forms.BindingNavigator bindingNavigatorAbd;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button CmdClose;
        private System.Windows.Forms.BindingSource c19ds1BindingSource;
        private c19_ds c19_ds1;
        private System.Windows.Forms.BindingSource c19ds1BindingSource1;
        private System.Windows.Forms.BindingSource c9ds1BindingSource;
        private c9_ds c9_ds1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn w_flg;
        private System.Windows.Forms.DataGridViewTextBoxColumn c3;
        private System.Windows.Forms.DataGridViewComboBoxColumn c1;
        private System.Windows.Forms.DataGridViewTextBoxColumn c4_ym;
        private System.Windows.Forms.DataGridViewComboBoxColumn c1_bc;
        private System.Windows.Forms.DataGridViewTextBoxColumn c11;
        private System.Windows.Forms.DataGridViewTextBoxColumn c14;
        private System.Windows.Forms.DataGridViewTextBoxColumn c16;
        private System.Windows.Forms.DataGridViewTextBoxColumn c22;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn r_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn o_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn last_day;
    }
}