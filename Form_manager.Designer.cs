namespace rk_seikyu
{
    partial class Form_manager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_manager));
            this.CmdSaveManager = new System.Windows.Forms.Button();
            this.CmdClose = new System.Windows.Forms.Button();
            this.dataGridViewManager = new System.Windows.Forms.DataGridView();
            this.m_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.end_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.o_id = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bindingSourceManager = new System.Windows.Forms.BindingSource(this.components);
            this.officedsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.office_ds = new rk_seikyu.office_ds();
            this.bindingNavigatorManager = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.cmb_o_id = new System.Windows.Forms.ComboBox();
            this.textBoxO_id = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officedsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.office_ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorManager)).BeginInit();
            this.bindingNavigatorManager.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmdSaveManager
            // 
            this.CmdSaveManager.Location = new System.Drawing.Point(36, 128);
            this.CmdSaveManager.Name = "CmdSaveManager";
            this.CmdSaveManager.Size = new System.Drawing.Size(75, 23);
            this.CmdSaveManager.TabIndex = 0;
            this.CmdSaveManager.Text = "更新";
            this.CmdSaveManager.UseVisualStyleBackColor = true;
            this.CmdSaveManager.Click += new System.EventHandler(this.CmdManagerSave_Click);
            // 
            // CmdClose
            // 
            this.CmdClose.Location = new System.Drawing.Point(36, 195);
            this.CmdClose.Name = "CmdClose";
            this.CmdClose.Size = new System.Drawing.Size(75, 23);
            this.CmdClose.TabIndex = 1;
            this.CmdClose.Text = "閉じる";
            this.CmdClose.UseVisualStyleBackColor = true;
            this.CmdClose.Click += new System.EventHandler(this.CmdClose_Click);
            // 
            // dataGridViewManager
            // 
            this.dataGridViewManager.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewManager.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_id,
            this.manager,
            this.start_date,
            this.end_date,
            this.o_id});
            this.dataGridViewManager.Location = new System.Drawing.Point(150, 100);
            this.dataGridViewManager.Name = "dataGridViewManager";
            this.dataGridViewManager.RowTemplate.Height = 21;
            this.dataGridViewManager.Size = new System.Drawing.Size(600, 300);
            this.dataGridViewManager.TabIndex = 2;
            this.dataGridViewManager.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewManager_CellMouseMove);
            this.dataGridViewManager.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DataGridViewManager_CellPainting);
            // 
            // m_id
            // 
            this.m_id.DataPropertyName = "m_id";
            this.m_id.HeaderText = "m_id";
            this.m_id.Name = "m_id";
            // 
            // manager
            // 
            this.manager.DataPropertyName = "manager";
            this.manager.HeaderText = "manager";
            this.manager.Name = "manager";
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
            // o_id
            // 
            this.o_id.DataPropertyName = "o_id";
            this.o_id.DataSource = this.bindingSourceManager;
            this.o_id.HeaderText = "o_id";
            this.o_id.Name = "o_id";
            this.o_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.o_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // officedsBindingSource
            // 
            this.officedsBindingSource.DataSource = this.office_ds;
            this.officedsBindingSource.Position = 0;
            // 
            // office_ds
            // 
            this.office_ds.DataSetName = "office_ds";
            this.office_ds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingNavigatorManager
            // 
            this.bindingNavigatorManager.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigatorManager.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigatorManager.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigatorManager.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bindingNavigatorManager.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigatorManager.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigatorManager.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigatorManager.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigatorManager.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigatorManager.Name = "bindingNavigatorManager";
            this.bindingNavigatorManager.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigatorManager.Size = new System.Drawing.Size(800, 25);
            this.bindingNavigatorManager.TabIndex = 3;
            this.bindingNavigatorManager.Text = "bindingNavigator1";
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
            // cmb_o_id
            // 
            this.cmb_o_id.FormattingEnabled = true;
            this.cmb_o_id.Location = new System.Drawing.Point(36, 54);
            this.cmb_o_id.Name = "cmb_o_id";
            this.cmb_o_id.Size = new System.Drawing.Size(265, 20);
            this.cmb_o_id.TabIndex = 4;
            this.cmb_o_id.SelectedIndexChanged += new System.EventHandler(this.cmb_o_id_SelectedIndexChanged);
            // 
            // textBoxO_id
            // 
            this.textBoxO_id.Location = new System.Drawing.Point(12, 54);
            this.textBoxO_id.Name = "textBoxO_id";
            this.textBoxO_id.ReadOnly = true;
            this.textBoxO_id.Size = new System.Drawing.Size(18, 19);
            this.textBoxO_id.TabIndex = 5;
            // 
            // Form_manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxO_id);
            this.Controls.Add(this.cmb_o_id);
            this.Controls.Add(this.bindingNavigatorManager);
            this.Controls.Add(this.dataGridViewManager);
            this.Controls.Add(this.CmdClose);
            this.Controls.Add(this.CmdSaveManager);
            this.Name = "Form_manager";
            this.Text = "Form_manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_manager_FormClosing);
            this.Load += new System.EventHandler(this.Form_manager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officedsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.office_ds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorManager)).EndInit();
            this.bindingNavigatorManager.ResumeLayout(false);
            this.bindingNavigatorManager.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CmdSaveManager;
        private System.Windows.Forms.Button CmdClose;
        private System.Windows.Forms.DataGridView dataGridViewManager;
        private System.Windows.Forms.BindingNavigator bindingNavigatorManager;
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
        private System.Windows.Forms.BindingSource bindingSourceManager;
        private System.Windows.Forms.BindingSource officedsBindingSource;
        private office_ds office_ds;
        private System.Windows.Forms.ComboBox cmb_o_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn manager;
        private System.Windows.Forms.DataGridViewTextBoxColumn start_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn end_date;
        private System.Windows.Forms.DataGridViewComboBoxColumn o_id;
        private System.Windows.Forms.TextBox textBoxO_id;
    }
}