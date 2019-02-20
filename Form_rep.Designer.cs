namespace rk_seikyu
{
    partial class Form_rep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_rep));
            this.bindingNavigatorRep = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.dataGridViewRep = new System.Windows.Forms.DataGridView();
            this.pt_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ac0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ac1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ac2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ac3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rep_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceRep = new System.Windows.Forms.BindingSource(this.components);
            this.rep = new rk_seikyu.rep();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmb_n_id = new System.Windows.Forms.ComboBox();
            this.cmb_s_id = new System.Windows.Forms.ComboBox();
            this.cmb_t_id = new System.Windows.Forms.ComboBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmb_pt_id = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorRep)).BeginInit();
            this.bindingNavigatorRep.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingNavigatorRep
            // 
            this.bindingNavigatorRep.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigatorRep.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigatorRep.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigatorRep.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bindingNavigatorRep.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigatorRep.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigatorRep.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigatorRep.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigatorRep.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigatorRep.Name = "bindingNavigatorRep";
            this.bindingNavigatorRep.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigatorRep.Size = new System.Drawing.Size(992, 25);
            this.bindingNavigatorRep.TabIndex = 0;
            this.bindingNavigatorRep.Text = "bindingNavigator1";
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
            // dataGridViewRep
            // 
            this.dataGridViewRep.AutoGenerateColumns = false;
            this.dataGridViewRep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRep.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pt_id,
            this.s_id,
            this.col0,
            this.col1,
            this.col2,
            this.col3,
            this.col4,
            this.col5,
            this.ac0,
            this.ac1,
            this.ac2,
            this.ac3,
            this.rep_id});
            this.dataGridViewRep.DataSource = this.bindingSourceRep;
            this.dataGridViewRep.Location = new System.Drawing.Point(152, 56);
            this.dataGridViewRep.Name = "dataGridViewRep";
            this.dataGridViewRep.RowTemplate.Height = 42;
            this.dataGridViewRep.Size = new System.Drawing.Size(828, 220);
            this.dataGridViewRep.TabIndex = 1;
            // 
            // pt_id
            // 
            this.pt_id.DataPropertyName = "pt_id";
            this.pt_id.HeaderText = "pt_id";
            this.pt_id.Name = "pt_id";
            // 
            // s_id
            // 
            this.s_id.DataPropertyName = "s_id";
            this.s_id.HeaderText = "s_id";
            this.s_id.Name = "s_id";
            // 
            // col0
            // 
            this.col0.DataPropertyName = "col0";
            this.col0.HeaderText = "col0";
            this.col0.Name = "col0";
            // 
            // col1
            // 
            this.col1.DataPropertyName = "col1";
            this.col1.HeaderText = "col1";
            this.col1.Name = "col1";
            // 
            // col2
            // 
            this.col2.DataPropertyName = "col2";
            this.col2.HeaderText = "col2";
            this.col2.Name = "col2";
            // 
            // col3
            // 
            this.col3.DataPropertyName = "col3";
            this.col3.HeaderText = "col3";
            this.col3.Name = "col3";
            // 
            // col4
            // 
            this.col4.DataPropertyName = "col4";
            this.col4.HeaderText = "col4";
            this.col4.Name = "col4";
            // 
            // col5
            // 
            this.col5.DataPropertyName = "col5";
            this.col5.HeaderText = "col5";
            this.col5.Name = "col5";
            // 
            // ac0
            // 
            this.ac0.DataPropertyName = "ac0";
            this.ac0.HeaderText = "ac0";
            this.ac0.Name = "ac0";
            // 
            // ac1
            // 
            this.ac1.DataPropertyName = "ac1";
            this.ac1.HeaderText = "ac1";
            this.ac1.Name = "ac1";
            // 
            // ac2
            // 
            this.ac2.DataPropertyName = "ac2";
            this.ac2.HeaderText = "ac2";
            this.ac2.Name = "ac2";
            // 
            // ac3
            // 
            this.ac3.DataPropertyName = "ac3";
            this.ac3.HeaderText = "ac3";
            this.ac3.Name = "ac3";
            // 
            // rep_id
            // 
            this.rep_id.DataPropertyName = "rep_id";
            this.rep_id.HeaderText = "rep_id";
            this.rep_id.Name = "rep_id";
            this.rep_id.Visible = false;
            // 
            // bindingSourceRep
            // 
            this.bindingSourceRep.DataMember = "rep";
            this.bindingSourceRep.DataSource = this.rep;
            // 
            // rep
            // 
            this.rep.DataSetName = "rep";
            this.rep.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(58, 244);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 2;
            this.cmdClose.Text = "閉じる";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.CmdClose_Click);
            // 
            // cmb_n_id
            // 
            this.cmb_n_id.FormattingEnabled = true;
            this.cmb_n_id.Location = new System.Drawing.Point(12, 70);
            this.cmb_n_id.Name = "cmb_n_id";
            this.cmb_n_id.Size = new System.Drawing.Size(121, 20);
            this.cmb_n_id.TabIndex = 3;
            this.cmb_n_id.Visible = false;
            this.cmb_n_id.SelectedIndexChanged += new System.EventHandler(this.Cmb_n_id_SelectedIndexChanged);
            // 
            // cmb_s_id
            // 
            this.cmb_s_id.FormattingEnabled = true;
            this.cmb_s_id.Location = new System.Drawing.Point(14, 122);
            this.cmb_s_id.Name = "cmb_s_id";
            this.cmb_s_id.Size = new System.Drawing.Size(121, 20);
            this.cmb_s_id.TabIndex = 4;
            this.cmb_s_id.SelectedIndexChanged += new System.EventHandler(this.Cmb_s_id_SelectedIndexChanged);
            // 
            // cmb_t_id
            // 
            this.cmb_t_id.FormattingEnabled = true;
            this.cmb_t_id.Location = new System.Drawing.Point(12, 96);
            this.cmb_t_id.Name = "cmb_t_id";
            this.cmb_t_id.Size = new System.Drawing.Size(121, 20);
            this.cmb_t_id.TabIndex = 5;
            this.cmb_t_id.Visible = false;
            this.cmb_t_id.SelectedIndexChanged += new System.EventHandler(this.Cmb_s_id_SelectedIndexChanged);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(58, 194);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 6;
            this.cmdSave.Text = "更新";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.CmdSave_Click);
            // 
            // cmb_pt_id
            // 
            this.cmb_pt_id.FormattingEnabled = true;
            this.cmb_pt_id.Location = new System.Drawing.Point(14, 157);
            this.cmb_pt_id.Name = "cmb_pt_id";
            this.cmb_pt_id.Size = new System.Drawing.Size(121, 20);
            this.cmb_pt_id.TabIndex = 7;
            this.cmb_pt_id.SelectedIndexChanged += new System.EventHandler(this.Cmb_pt_id_SelectedIndexChanged);
            // 
            // Form_rep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 298);
            this.Controls.Add(this.cmb_pt_id);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmb_t_id);
            this.Controls.Add(this.cmb_s_id);
            this.Controls.Add(this.cmb_n_id);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.dataGridViewRep);
            this.Controls.Add(this.bindingNavigatorRep);
            this.Name = "Form_rep";
            this.Text = "Form_rep";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_rep_FormClosing);
            this.Load += new System.EventHandler(this.Form_rep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorRep)).EndInit();
            this.bindingNavigatorRep.ResumeLayout(false);
            this.bindingNavigatorRep.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private rep rep;
        private System.Windows.Forms.BindingNavigator bindingNavigatorRep;
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
        private System.Windows.Forms.BindingSource bindingSourceRep;
        private System.Windows.Forms.DataGridView dataGridViewRep;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.ComboBox cmb_n_id;
        private System.Windows.Forms.ComboBox cmb_s_id;
        private System.Windows.Forms.ComboBox cmb_t_id;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.ComboBox cmb_pt_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn pt_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col0;
        private System.Windows.Forms.DataGridViewTextBoxColumn col1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col3;
        private System.Windows.Forms.DataGridViewTextBoxColumn col4;
        private System.Windows.Forms.DataGridViewTextBoxColumn col5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ac0;
        private System.Windows.Forms.DataGridViewTextBoxColumn ac1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ac2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ac3;
        private System.Windows.Forms.DataGridViewTextBoxColumn rep_id;
    }
}