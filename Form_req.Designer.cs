namespace rk_seikyu
{
    partial class Form_req
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_req));
            this.bindingNavigatorReq = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingSourceReq = new System.Windows.Forms.BindingSource(this.components);
            this.req_ds = new rk_seikyu.req_ds();
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
            this.req_dsBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewReq = new System.Windows.Forms.DataGridView();
            this.cmdReqSave = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.req_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title4_kana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.o_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorReq)).BeginInit();
            this.bindingNavigatorReq.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceReq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.req_ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReq)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingNavigatorReq
            // 
            this.bindingNavigatorReq.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigatorReq.BindingSource = this.bindingSourceReq;
            this.bindingNavigatorReq.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigatorReq.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigatorReq.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.req_dsBindingNavigatorSaveItem});
            this.bindingNavigatorReq.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigatorReq.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigatorReq.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigatorReq.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigatorReq.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigatorReq.Name = "bindingNavigatorReq";
            this.bindingNavigatorReq.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigatorReq.Size = new System.Drawing.Size(1551, 25);
            this.bindingNavigatorReq.TabIndex = 0;
            this.bindingNavigatorReq.Text = "bindingNavigator1";
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
            // bindingSourceReq
            // 
            this.bindingSourceReq.DataMember = "req_ds";
            this.bindingSourceReq.DataSource = this.req_ds;
            // 
            // req_ds
            // 
            this.req_ds.DataSetName = "req_ds";
            this.req_ds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // req_dsBindingNavigatorSaveItem
            // 
            this.req_dsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.req_dsBindingNavigatorSaveItem.Enabled = false;
            this.req_dsBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("req_dsBindingNavigatorSaveItem.Image")));
            this.req_dsBindingNavigatorSaveItem.Name = "req_dsBindingNavigatorSaveItem";
            this.req_dsBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.req_dsBindingNavigatorSaveItem.Text = "データの保存";
            // 
            // dataGridViewReq
            // 
            this.dataGridViewReq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReq.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.req_id,
            this.title1,
            this.title2,
            this.title3,
            this.title4,
            this.title4_kana,
            this.data7,
            this.data8,
            this.data9,
            this.data10,
            this.o_id});
            this.dataGridViewReq.Location = new System.Drawing.Point(24, 78);
            this.dataGridViewReq.Name = "dataGridViewReq";
            this.dataGridViewReq.RowTemplate.Height = 21;
            this.dataGridViewReq.Size = new System.Drawing.Size(1504, 220);
            this.dataGridViewReq.TabIndex = 1;
            // 
            // cmdReqSave
            // 
            this.cmdReqSave.Location = new System.Drawing.Point(309, 39);
            this.cmdReqSave.Name = "cmdReqSave";
            this.cmdReqSave.Size = new System.Drawing.Size(75, 23);
            this.cmdReqSave.TabIndex = 2;
            this.cmdReqSave.Text = "保存";
            this.cmdReqSave.UseVisualStyleBackColor = true;
            this.cmdReqSave.Click += new System.EventHandler(this.CmdReqSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(426, 39);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 3;
            this.cmdClose.Text = "閉じる";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.CmdClose_Click);
            // 
            // req_id
            // 
            this.req_id.DataPropertyName = "req_id";
            this.req_id.HeaderText = "ID";
            this.req_id.Name = "req_id";
            // 
            // title1
            // 
            this.title1.DataPropertyName = "title1";
            this.title1.HeaderText = "予備";
            this.title1.Name = "title1";
            // 
            // title2
            // 
            this.title2.DataPropertyName = "title2";
            this.title2.HeaderText = "職名";
            this.title2.Name = "title2";
            // 
            // title3
            // 
            this.title3.DataPropertyName = "title3";
            this.title3.HeaderText = "住所";
            this.title3.Name = "title3";
            // 
            // title4
            // 
            this.title4.DataPropertyName = "title4";
            this.title4.HeaderText = "会計管理者";
            this.title4.Name = "title4";
            // 
            // title4_kana
            // 
            this.title4_kana.DataPropertyName = "title4_kana";
            this.title4_kana.HeaderText = "会計管理者カナ";
            this.title4_kana.Name = "title4_kana";
            // 
            // data7
            // 
            this.data7.DataPropertyName = "data7";
            this.data7.HeaderText = "口座種別";
            this.data7.Name = "data7";
            // 
            // data8
            // 
            this.data8.DataPropertyName = "data8";
            this.data8.HeaderText = "口座番号";
            this.data8.Name = "data8";
            // 
            // data9
            // 
            this.data9.DataPropertyName = "data9";
            this.data9.HeaderText = "予備";
            this.data9.Name = "data9";
            // 
            // data10
            // 
            this.data10.DataPropertyName = "data10";
            this.data10.HeaderText = "予備";
            this.data10.Name = "data10";
            // 
            // o_id
            // 
            this.o_id.DataPropertyName = "o_id";
            this.o_id.HeaderText = "o_id";
            this.o_id.Name = "o_id";
            // 
            // Form_req
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1551, 336);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdReqSave);
            this.Controls.Add(this.dataGridViewReq);
            this.Controls.Add(this.bindingNavigatorReq);
            this.Name = "Form_req";
            this.Text = "Form_req";
            this.Load += new System.EventHandler(this.Form_req_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorReq)).EndInit();
            this.bindingNavigatorReq.ResumeLayout(false);
            this.bindingNavigatorReq.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceReq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.req_ds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReq)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private req_ds req_ds;
        private System.Windows.Forms.BindingSource bindingSourceReq;
        private System.Windows.Forms.BindingNavigator bindingNavigatorReq;
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
        private System.Windows.Forms.ToolStripButton req_dsBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView dataGridViewReq;
        private System.Windows.Forms.Button cmdReqSave;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn req_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn title1;
        private System.Windows.Forms.DataGridViewTextBoxColumn title2;
        private System.Windows.Forms.DataGridViewTextBoxColumn title3;
        private System.Windows.Forms.DataGridViewTextBoxColumn title4;
        private System.Windows.Forms.DataGridViewTextBoxColumn title4_kana;
        private System.Windows.Forms.DataGridViewTextBoxColumn data7;
        private System.Windows.Forms.DataGridViewTextBoxColumn data8;
        private System.Windows.Forms.DataGridViewTextBoxColumn data9;
        private System.Windows.Forms.DataGridViewTextBoxColumn data10;
        private System.Windows.Forms.DataGridViewTextBoxColumn o_id;
    }
}