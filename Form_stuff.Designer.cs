namespace rk_seikyu
{
    partial class Form_stuff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_stuff));
            this.CmdSaveStuff = new System.Windows.Forms.Button();
            this.CmdClose = new System.Windows.Forms.Button();
            this.bindingNavigatorStuff = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.bindingSourceStuff = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewStuff = new System.Windows.Forms.DataGridView();
            this.cmb_o_id = new System.Windows.Forms.ComboBox();
            this.office_ds = new rk_seikyu.office_ds();
            this.stf_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stuff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.end_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.o_id = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorStuff)).BeginInit();
            this.bindingNavigatorStuff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceStuff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStuff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.office_ds)).BeginInit();
            this.SuspendLayout();
            // 
            // CmdSaveStuff
            // 
            this.CmdSaveStuff.Location = new System.Drawing.Point(34, 130);
            this.CmdSaveStuff.Name = "CmdSaveStuff";
            this.CmdSaveStuff.Size = new System.Drawing.Size(75, 23);
            this.CmdSaveStuff.TabIndex = 0;
            this.CmdSaveStuff.Text = "更新";
            this.CmdSaveStuff.UseVisualStyleBackColor = true;
            this.CmdSaveStuff.Click += new System.EventHandler(this.CmdStuffSave_Click);
            // 
            // CmdClose
            // 
            this.CmdClose.Location = new System.Drawing.Point(34, 199);
            this.CmdClose.Name = "CmdClose";
            this.CmdClose.Size = new System.Drawing.Size(75, 23);
            this.CmdClose.TabIndex = 1;
            this.CmdClose.Text = "閉じる";
            this.CmdClose.UseVisualStyleBackColor = true;
            this.CmdClose.Click += new System.EventHandler(this.CmdClose_Click);
            // 
            // bindingNavigatorStuff
            // 
            this.bindingNavigatorStuff.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigatorStuff.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigatorStuff.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigatorStuff.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bindingNavigatorStuff.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigatorStuff.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigatorStuff.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigatorStuff.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigatorStuff.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigatorStuff.Name = "bindingNavigatorStuff";
            this.bindingNavigatorStuff.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigatorStuff.Size = new System.Drawing.Size(800, 25);
            this.bindingNavigatorStuff.TabIndex = 2;
            this.bindingNavigatorStuff.Text = "bindingNavigator1";
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
            // dataGridViewStuff
            // 
            this.dataGridViewStuff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStuff.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stf_id,
            this.stuff,
            this.start_date,
            this.end_date,
            this.o_id});
            this.dataGridViewStuff.Location = new System.Drawing.Point(150, 100);
            this.dataGridViewStuff.Name = "dataGridViewStuff";
            this.dataGridViewStuff.RowTemplate.Height = 21;
            this.dataGridViewStuff.Size = new System.Drawing.Size(600, 300);
            this.dataGridViewStuff.TabIndex = 3;
            this.dataGridViewStuff.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewStuff_CellMouseMove);
            this.dataGridViewStuff.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DataGridViewStuff_CellPainting);
            // 
            // cmb_o_id
            // 
            this.cmb_o_id.FormattingEnabled = true;
            this.cmb_o_id.Location = new System.Drawing.Point(34, 55);
            this.cmb_o_id.Name = "cmb_o_id";
            this.cmb_o_id.Size = new System.Drawing.Size(260, 20);
            this.cmb_o_id.TabIndex = 4;
            this.cmb_o_id.SelectedIndexChanged += new System.EventHandler(this.cmb_o_id_SelectedIndexChanged);
            // 
            // office_ds
            // 
            this.office_ds.DataSetName = "office_ds";
            this.office_ds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stf_id
            // 
            this.stf_id.DataPropertyName = "stf_id";
            this.stf_id.HeaderText = "stf_id";
            this.stf_id.Name = "stf_id";
            // 
            // stuff
            // 
            this.stuff.DataPropertyName = "stuff";
            this.stuff.HeaderText = "stuff";
            this.stuff.Name = "stuff";
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
            this.o_id.DataSource = this.bindingSourceStuff;
            this.o_id.HeaderText = "o_id";
            this.o_id.Name = "o_id";
            this.o_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.o_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Form_stuff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmb_o_id);
            this.Controls.Add(this.dataGridViewStuff);
            this.Controls.Add(this.bindingNavigatorStuff);
            this.Controls.Add(this.CmdClose);
            this.Controls.Add(this.CmdSaveStuff);
            this.Name = "Form_stuff";
            this.Text = "Form_stuff";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_stuff_FormClosing);
            this.Load += new System.EventHandler(this.Form_stuff_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorStuff)).EndInit();
            this.bindingNavigatorStuff.ResumeLayout(false);
            this.bindingNavigatorStuff.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceStuff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStuff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.office_ds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CmdSaveStuff;
        private System.Windows.Forms.Button CmdClose;
        private System.Windows.Forms.BindingNavigator bindingNavigatorStuff;
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
        private System.Windows.Forms.BindingSource bindingSourceStuff;
        private System.Windows.Forms.DataGridView dataGridViewStuff;
        private System.Windows.Forms.ComboBox cmb_o_id;
        private office_ds office_ds;
        private System.Windows.Forms.DataGridViewTextBoxColumn stf_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn stuff;
        private System.Windows.Forms.DataGridViewTextBoxColumn start_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn end_date;
        private System.Windows.Forms.DataGridViewComboBoxColumn o_id;
    }
}