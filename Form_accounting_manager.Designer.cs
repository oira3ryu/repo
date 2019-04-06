namespace rk_seikyu
{
    partial class Form_accounting_manager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_accounting_manager));
            this.CmdSaveAccounting_manager = new System.Windows.Forms.Button();
            this.CmdClose = new System.Windows.Forms.Button();
            this.dataGridViewAccounting_manager = new System.Windows.Forms.DataGridView();
            this.acc_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accounting_manager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.end_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceAccounting_manager = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorAccounting_manager = new System.Windows.Forms.BindingNavigator(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccounting_manager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAccounting_manager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorAccounting_manager)).BeginInit();
            this.bindingNavigatorAccounting_manager.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmdSaveAccounting_manager
            // 
            this.CmdSaveAccounting_manager.Location = new System.Drawing.Point(32, 100);
            this.CmdSaveAccounting_manager.Name = "CmdSaveAccounting_manager";
            this.CmdSaveAccounting_manager.Size = new System.Drawing.Size(75, 23);
            this.CmdSaveAccounting_manager.TabIndex = 0;
            this.CmdSaveAccounting_manager.Text = "更新";
            this.CmdSaveAccounting_manager.UseVisualStyleBackColor = true;
            this.CmdSaveAccounting_manager.Click += new System.EventHandler(this.CmdAccounting_managerSave_Click);
            // 
            // CmdClose
            // 
            this.CmdClose.Location = new System.Drawing.Point(32, 184);
            this.CmdClose.Name = "CmdClose";
            this.CmdClose.Size = new System.Drawing.Size(75, 23);
            this.CmdClose.TabIndex = 1;
            this.CmdClose.Text = "閉じる";
            this.CmdClose.UseVisualStyleBackColor = true;
            this.CmdClose.Click += new System.EventHandler(this.CmdClose_Click);
            // 
            // dataGridViewAccounting_manager
            // 
            this.dataGridViewAccounting_manager.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAccounting_manager.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.acc_id,
            this.accounting_manager,
            this.start_date,
            this.end_date});
            this.dataGridViewAccounting_manager.Location = new System.Drawing.Point(150, 100);
            this.dataGridViewAccounting_manager.Name = "dataGridViewAccounting_manager";
            this.dataGridViewAccounting_manager.RowTemplate.Height = 21;
            this.dataGridViewAccounting_manager.Size = new System.Drawing.Size(500, 150);
            this.dataGridViewAccounting_manager.TabIndex = 2;
            this.dataGridViewAccounting_manager.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewAccounting_manager_CellMouseMove);
            this.dataGridViewAccounting_manager.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DataGridViewAccounting_manager_CellPainting);
            // 
            // acc_id
            // 
            this.acc_id.DataPropertyName = "acc_id";
            this.acc_id.HeaderText = "acc_id";
            this.acc_id.Name = "acc_id";
            // 
            // accounting_manager
            // 
            this.accounting_manager.DataPropertyName = "accounting_manager";
            this.accounting_manager.HeaderText = "accounting_manager";
            this.accounting_manager.Name = "accounting_manager";
            // 
            // start_date
            // 
            this.start_date.DataPropertyName = "start_date";
            this.start_date.HeaderText = "start_date";
            this.start_date.Name = "start_date";
            // 
            // end_date
            // 
            this.end_date.DataPropertyName = "end_date";
            this.end_date.HeaderText = "end_date";
            this.end_date.Name = "end_date";
            // 
            // bindingNavigatorAccounting_manager
            // 
            this.bindingNavigatorAccounting_manager.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigatorAccounting_manager.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigatorAccounting_manager.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigatorAccounting_manager.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bindingNavigatorAccounting_manager.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigatorAccounting_manager.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigatorAccounting_manager.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigatorAccounting_manager.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigatorAccounting_manager.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigatorAccounting_manager.Name = "bindingNavigatorAccounting_manager";
            this.bindingNavigatorAccounting_manager.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigatorAccounting_manager.Size = new System.Drawing.Size(784, 25);
            this.bindingNavigatorAccounting_manager.TabIndex = 3;
            this.bindingNavigatorAccounting_manager.Text = "bindingNavigator1";
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
            // Form_accounting_manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.bindingNavigatorAccounting_manager);
            this.Controls.Add(this.dataGridViewAccounting_manager);
            this.Controls.Add(this.CmdClose);
            this.Controls.Add(this.CmdSaveAccounting_manager);
            this.Name = "Form_accounting_manager";
            this.Text = "Form_accounting_manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Accounting_manager_FormClosing);
            this.Load += new System.EventHandler(this.Form_accounting_manager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccounting_manager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAccounting_manager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorAccounting_manager)).EndInit();
            this.bindingNavigatorAccounting_manager.ResumeLayout(false);
            this.bindingNavigatorAccounting_manager.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CmdSaveAccounting_manager;
        private System.Windows.Forms.Button CmdClose;
        private System.Windows.Forms.DataGridView dataGridViewAccounting_manager;
        private System.Windows.Forms.BindingSource bindingSourceAccounting_manager;
        private System.Windows.Forms.BindingNavigator bindingNavigatorAccounting_manager;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn acc_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn accounting_manager;
        private System.Windows.Forms.DataGridViewTextBoxColumn start_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn end_date;
    }
}