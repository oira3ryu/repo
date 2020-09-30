namespace rk_seikyu
{
    partial class Form_syubetsu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_syubetsu));
            this.cmdSyubetsuSave = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.bindingNavigatorSyubetsu = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.bindingSourceSyubetsu = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewSyubetsu = new System.Windows.Forms.DataGridView();
            this.syubetsuBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.syubetsuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.syubetsu = new rk_seikyu.syubetsu();
            this.TextBoxS_id = new System.Windows.Forms.TextBox();
            this.s_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.syubetsuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hyoujimei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shisetsumei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.o_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorSyubetsu)).BeginInit();
            this.bindingNavigatorSyubetsu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSyubetsu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSyubetsu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.syubetsuBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.syubetsuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.syubetsu)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdSyubetsuSave
            // 
            this.cmdSyubetsuSave.Location = new System.Drawing.Point(42, 102);
            this.cmdSyubetsuSave.Name = "cmdSyubetsuSave";
            this.cmdSyubetsuSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSyubetsuSave.TabIndex = 1;
            this.cmdSyubetsuSave.Text = "更新";
            this.cmdSyubetsuSave.UseVisualStyleBackColor = true;
            this.cmdSyubetsuSave.Click += new System.EventHandler(this.CmdSyubetsuSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(42, 218);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 2;
            this.cmdClose.Text = "閉じる";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.CmdClose_Click);
            // 
            // bindingNavigatorSyubetsu
            // 
            this.bindingNavigatorSyubetsu.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigatorSyubetsu.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigatorSyubetsu.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigatorSyubetsu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bindingNavigatorSyubetsu.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigatorSyubetsu.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigatorSyubetsu.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigatorSyubetsu.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigatorSyubetsu.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigatorSyubetsu.Name = "bindingNavigatorSyubetsu";
            this.bindingNavigatorSyubetsu.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigatorSyubetsu.Size = new System.Drawing.Size(884, 25);
            this.bindingNavigatorSyubetsu.TabIndex = 3;
            this.bindingNavigatorSyubetsu.Text = "bindingNavigator1";
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
            // bindingSourceSyubetsu
            // 
            this.bindingSourceSyubetsu.DataMember = "syubetsu";
            // 
            // dataGridViewSyubetsu
            // 
            this.dataGridViewSyubetsu.AutoGenerateColumns = false;
            this.dataGridViewSyubetsu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSyubetsu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.s_id,
            this.syubetsuDataGridViewTextBoxColumn,
            this.hyoujimei,
            this.shisetsumei,
            this.o_id});
            this.dataGridViewSyubetsu.DataSource = this.syubetsuBindingSource1;
            this.dataGridViewSyubetsu.Location = new System.Drawing.Point(200, 85);
            this.dataGridViewSyubetsu.Name = "dataGridViewSyubetsu";
            this.dataGridViewSyubetsu.RowTemplate.Height = 21;
            this.dataGridViewSyubetsu.Size = new System.Drawing.Size(600, 300);
            this.dataGridViewSyubetsu.TabIndex = 3;
            this.dataGridViewSyubetsu.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridViewSyubetsu_DefaultValuesNeeded);
            // 
            // syubetsuBindingSource1
            // 
            this.syubetsuBindingSource1.DataMember = "syubetsu";
            this.syubetsuBindingSource1.DataSource = this.syubetsuBindingSource;
            // 
            // syubetsuBindingSource
            // 
            this.syubetsuBindingSource.DataSource = this.syubetsu;
            this.syubetsuBindingSource.Position = 0;
            // 
            // syubetsu
            // 
            this.syubetsu.DataSetName = "syubetsu";
            this.syubetsu.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TextBoxS_id
            // 
            this.TextBoxS_id.Location = new System.Drawing.Point(325, 40);
            this.TextBoxS_id.Name = "TextBoxS_id";
            this.TextBoxS_id.Size = new System.Drawing.Size(23, 19);
            this.TextBoxS_id.TabIndex = 4;
            this.TextBoxS_id.Visible = false;
            // 
            // s_id
            // 
            this.s_id.DataPropertyName = "s_id";
            this.s_id.HeaderText = "s_id";
            this.s_id.Name = "s_id";
            // 
            // syubetsuDataGridViewTextBoxColumn
            // 
            this.syubetsuDataGridViewTextBoxColumn.DataPropertyName = "syubetsu";
            this.syubetsuDataGridViewTextBoxColumn.HeaderText = "syubetsu";
            this.syubetsuDataGridViewTextBoxColumn.Name = "syubetsuDataGridViewTextBoxColumn";
            // 
            // hyoujimei
            // 
            this.hyoujimei.DataPropertyName = "hyoujimei";
            this.hyoujimei.HeaderText = "hyoujimei";
            this.hyoujimei.Name = "hyoujimei";
            // 
            // shisetsumei
            // 
            this.shisetsumei.DataPropertyName = "shisetsumei";
            this.shisetsumei.HeaderText = "shisetsumei";
            this.shisetsumei.Name = "shisetsumei";
            // 
            // o_id
            // 
            this.o_id.DataPropertyName = "o_id";
            this.o_id.HeaderText = "o_id";
            this.o_id.Name = "o_id";
            this.o_id.Visible = false;
            // 
            // Form_syubetsu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.TextBoxS_id);
            this.Controls.Add(this.dataGridViewSyubetsu);
            this.Controls.Add(this.bindingNavigatorSyubetsu);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSyubetsuSave);
            this.Name = "Form_syubetsu";
            this.Text = "Form_syubetsu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_syubetsu_FormClosing);
            this.Load += new System.EventHandler(this.Form_syubetsu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorSyubetsu)).EndInit();
            this.bindingNavigatorSyubetsu.ResumeLayout(false);
            this.bindingNavigatorSyubetsu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSyubetsu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSyubetsu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.syubetsuBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.syubetsuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.syubetsu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSyubetsuSave;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.BindingNavigator bindingNavigatorSyubetsu;
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
//      private syubetsu syubetsu1;
        private System.Windows.Forms.BindingSource bindingSourceSyubetsu;
        private System.Windows.Forms.DataGridView dataGridViewSyubetsu;
        private System.Windows.Forms.BindingSource syubetsuBindingSource1;
        private System.Windows.Forms.BindingSource syubetsuBindingSource;
        private syubetsu syubetsu;
        private System.Windows.Forms.TextBox TextBoxS_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn syubetsuDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hyoujimei;
        private System.Windows.Forms.DataGridViewTextBoxColumn shisetsumei;
        private System.Windows.Forms.DataGridViewTextBoxColumn o_id;
    }
}