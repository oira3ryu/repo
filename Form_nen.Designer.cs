namespace rk_seikyu
{
    partial class Form_nen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_nen));
            this.cmdNenSave = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.nen = new rk_seikyu.nen();
            this.bindingSourceNen = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorNen = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.nenBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewNen = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.nen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceNen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorNen)).BeginInit();
            this.bindingNavigatorNen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNen)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdNenSave
            // 
            this.cmdNenSave.Location = new System.Drawing.Point(46, 114);
            this.cmdNenSave.Name = "cmdNenSave";
            this.cmdNenSave.Size = new System.Drawing.Size(75, 23);
            this.cmdNenSave.TabIndex = 0;
            this.cmdNenSave.Text = "更新";
            this.cmdNenSave.UseVisualStyleBackColor = true;
            this.cmdNenSave.Click += new System.EventHandler(this.CmdNenSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(46, 211);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 1;
            this.cmdClose.Text = "閉じる";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.CmdClose_Click);
            // 
            // nen
            // 
            this.nen.DataSetName = "nen";
            this.nen.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingSourceNen
            // 
            this.bindingSourceNen.DataMember = "nen";
            this.bindingSourceNen.DataSource = this.nen;
            // 
            // bindingNavigatorNen
            // 
            this.bindingNavigatorNen.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigatorNen.BindingSource = this.bindingSourceNen;
            this.bindingNavigatorNen.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigatorNen.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigatorNen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.nenBindingNavigatorSaveItem});
            this.bindingNavigatorNen.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigatorNen.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigatorNen.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigatorNen.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigatorNen.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigatorNen.Name = "bindingNavigatorNen";
            this.bindingNavigatorNen.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigatorNen.Size = new System.Drawing.Size(535, 25);
            this.bindingNavigatorNen.TabIndex = 2;
            this.bindingNavigatorNen.Text = "bindingNavigator1";
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 25);
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
            // nenBindingNavigatorSaveItem
            // 
            this.nenBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nenBindingNavigatorSaveItem.Enabled = false;
            this.nenBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("nenBindingNavigatorSaveItem.Image")));
            this.nenBindingNavigatorSaveItem.Name = "nenBindingNavigatorSaveItem";
            this.nenBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.nenBindingNavigatorSaveItem.Text = "データの保存";
            // 
            // dataGridViewNen
            // 
            this.dataGridViewNen.AutoGenerateColumns = false;
            this.dataGridViewNen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridViewNen.DataSource = this.bindingSourceNen;
            this.dataGridViewNen.Location = new System.Drawing.Point(180, 50);
            this.dataGridViewNen.Name = "dataGridViewNen";
            this.dataGridViewNen.RowTemplate.Height = 21;
            this.dataGridViewNen.Size = new System.Drawing.Size(294, 220);
            this.dataGridViewNen.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "n_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "n_id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "nen";
            this.dataGridViewTextBoxColumn2.HeaderText = "nen";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // Form_nen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 310);
            this.Controls.Add(this.dataGridViewNen);
            this.Controls.Add(this.bindingNavigatorNen);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdNenSave);
            this.Name = "Form_nen";
            this.Text = "Form_nen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_nen_FormClosing);
            this.Load += new System.EventHandler(this.Form_nen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceNen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorNen)).EndInit();
            this.bindingNavigatorNen.ResumeLayout(false);
            this.bindingNavigatorNen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdNenSave;
        private System.Windows.Forms.Button cmdClose;
        private nen nen;
        private System.Windows.Forms.BindingSource bindingSourceNen;
        private System.Windows.Forms.BindingNavigator bindingNavigatorNen;
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
        private System.Windows.Forms.ToolStripButton nenBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView dataGridViewNen;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}