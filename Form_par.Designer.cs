namespace rk_seikyu
{
    partial class Form_par
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_par));
            this.bindingNavigatorPar = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingSourcePar = new System.Windows.Forms.BindingSource(this.components);
            this.par = new rk_seikyu.par();
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
            this.parBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewPar = new System.Windows.Forms.DataGridView();
            this.p_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sub_title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.content1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.content2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.content3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmb_n_id = new System.Windows.Forms.ComboBox();
            this.cmb_t_id = new System.Windows.Forms.ComboBox();
            this.cmb_s_id = new System.Windows.Forms.ComboBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdParSave = new System.Windows.Forms.Button();
            this.rep = new rk_seikyu.rep();
            this.bindingSourceRep = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorPar)).BeginInit();
            this.bindingNavigatorPar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.par)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRep)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingNavigatorPar
            // 
            this.bindingNavigatorPar.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigatorPar.BindingSource = this.bindingSourcePar;
            this.bindingNavigatorPar.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigatorPar.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigatorPar.Dock = System.Windows.Forms.DockStyle.None;
            this.bindingNavigatorPar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.parBindingNavigatorSaveItem});
            this.bindingNavigatorPar.Location = new System.Drawing.Point(187, 26);
            this.bindingNavigatorPar.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigatorPar.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigatorPar.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigatorPar.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigatorPar.Name = "bindingNavigatorPar";
            this.bindingNavigatorPar.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigatorPar.Size = new System.Drawing.Size(280, 25);
            this.bindingNavigatorPar.TabIndex = 0;
            this.bindingNavigatorPar.Text = "bindingNavigator1";
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
            // bindingSourcePar
            // 
            this.bindingSourcePar.DataMember = "par";
            this.bindingSourcePar.DataSource = this.par;
            // 
            // par
            // 
            this.par.DataSetName = "par";
            this.par.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // parBindingNavigatorSaveItem
            // 
            this.parBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.parBindingNavigatorSaveItem.Enabled = false;
            this.parBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("parBindingNavigatorSaveItem.Image")));
            this.parBindingNavigatorSaveItem.Name = "parBindingNavigatorSaveItem";
            this.parBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.parBindingNavigatorSaveItem.Text = "データの保存";
            // 
            // dataGridViewPar
            // 
            this.dataGridViewPar.AutoGenerateColumns = false;
            this.dataGridViewPar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.p_id,
            this.title,
            this.sub_title,
            this.content1,
            this.content2,
            this.content3});
            this.dataGridViewPar.DataSource = this.bindingSourcePar;
            this.dataGridViewPar.Location = new System.Drawing.Point(187, 54);
            this.dataGridViewPar.Name = "dataGridViewPar";
            this.dataGridViewPar.RowTemplate.Height = 21;
            this.dataGridViewPar.Size = new System.Drawing.Size(797, 220);
            this.dataGridViewPar.TabIndex = 1;
            // 
            // p_id
            // 
            this.p_id.DataPropertyName = "p_id";
            this.p_id.HeaderText = "p_id";
            this.p_id.Name = "p_id";
            // 
            // title
            // 
            this.title.DataPropertyName = "title";
            this.title.HeaderText = "title";
            this.title.Name = "title";
            // 
            // sub_title
            // 
            this.sub_title.DataPropertyName = "sub_title";
            this.sub_title.HeaderText = "sub_title";
            this.sub_title.Name = "sub_title";
            // 
            // content1
            // 
            this.content1.DataPropertyName = "content1";
            this.content1.HeaderText = "content1";
            this.content1.Name = "content1";
            // 
            // content2
            // 
            this.content2.DataPropertyName = "content2";
            this.content2.HeaderText = "content2";
            this.content2.Name = "content2";
            // 
            // content3
            // 
            this.content3.DataPropertyName = "content3";
            this.content3.HeaderText = "content3";
            this.content3.Name = "content3";
            // 
            // cmb_n_id
            // 
            this.cmb_n_id.FormattingEnabled = true;
            this.cmb_n_id.Location = new System.Drawing.Point(33, 54);
            this.cmb_n_id.Name = "cmb_n_id";
            this.cmb_n_id.Size = new System.Drawing.Size(121, 20);
            this.cmb_n_id.TabIndex = 2;
            this.cmb_n_id.Visible = false;
            // 
            // cmb_t_id
            // 
            this.cmb_t_id.FormattingEnabled = true;
            this.cmb_t_id.Location = new System.Drawing.Point(33, 80);
            this.cmb_t_id.Name = "cmb_t_id";
            this.cmb_t_id.Size = new System.Drawing.Size(121, 20);
            this.cmb_t_id.TabIndex = 3;
            this.cmb_t_id.Visible = false;
            // 
            // cmb_s_id
            // 
            this.cmb_s_id.FormattingEnabled = true;
            this.cmb_s_id.Location = new System.Drawing.Point(33, 106);
            this.cmb_s_id.Name = "cmb_s_id";
            this.cmb_s_id.Size = new System.Drawing.Size(121, 20);
            this.cmb_s_id.TabIndex = 4;
            this.cmb_s_id.Visible = false;
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(79, 178);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "閉じる";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.CmdClose_Click);
            // 
            // cmdParSave
            // 
            this.cmdParSave.Location = new System.Drawing.Point(79, 132);
            this.cmdParSave.Name = "cmdParSave";
            this.cmdParSave.Size = new System.Drawing.Size(75, 23);
            this.cmdParSave.TabIndex = 6;
            this.cmdParSave.Text = "更新";
            this.cmdParSave.UseVisualStyleBackColor = true;
            this.cmdParSave.Click += new System.EventHandler(this.cmdParSave_Click);
            // 
            // rep
            // 
            this.rep.DataSetName = "rep";
            this.rep.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingSourceRep
            // 
            this.bindingSourceRep.DataMember = "rep";
            this.bindingSourceRep.DataSource = this.rep;
            // 
            // Form_par
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1588, 350);
            this.Controls.Add(this.cmdParSave);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmb_s_id);
            this.Controls.Add(this.cmb_t_id);
            this.Controls.Add(this.cmb_n_id);
            this.Controls.Add(this.dataGridViewPar);
            this.Controls.Add(this.bindingNavigatorPar);
            this.Name = "Form_par";
            this.Text = "Form_par";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_par_FormClosing);
            this.Load += new System.EventHandler(this.Form_par_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorPar)).EndInit();
            this.bindingNavigatorPar.ResumeLayout(false);
            this.bindingNavigatorPar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.par)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private par par;
        private System.Windows.Forms.BindingSource bindingSourcePar;
        private System.Windows.Forms.BindingNavigator bindingNavigatorPar;
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
        private System.Windows.Forms.ToolStripButton parBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView dataGridViewPar;
        private System.Windows.Forms.ComboBox cmb_n_id;
        private System.Windows.Forms.ComboBox cmb_t_id;
        private System.Windows.Forms.ComboBox cmb_s_id;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdParSave;
        private rep rep;
        private System.Windows.Forms.BindingSource bindingSourceRep;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn sub_title;
        private System.Windows.Forms.DataGridViewTextBoxColumn content1;
        private System.Windows.Forms.DataGridViewTextBoxColumn content2;
        private System.Windows.Forms.DataGridViewTextBoxColumn content3;
    }
}