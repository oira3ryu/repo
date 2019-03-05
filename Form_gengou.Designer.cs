namespace rk_seikyu
{
    partial class Form_gengou
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_gengou));
            this.CmdGengouSave = new System.Windows.Forms.Button();
            this.cmdClose_Form_gengou = new System.Windows.Forms.Button();
            this.bindingNavigatorGengou = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingSourceGengou = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewGengou = new System.Windows.Forms.DataGridView();
            this.gg_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gengou = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.end_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorGengou)).BeginInit();
            this.bindingNavigatorGengou.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceGengou)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGengou)).BeginInit();
            this.SuspendLayout();
            // 
            // CmdGengouSave
            // 
            this.CmdGengouSave.Location = new System.Drawing.Point(53, 91);
            this.CmdGengouSave.Name = "CmdGengouSave";
            this.CmdGengouSave.Size = new System.Drawing.Size(75, 23);
            this.CmdGengouSave.TabIndex = 1;
            this.CmdGengouSave.Text = "更　新";
            this.CmdGengouSave.UseVisualStyleBackColor = true;
            this.CmdGengouSave.Click += new System.EventHandler(this.CmdGengouSave_Click);
            // 
            // cmdClose_Form_gengou
            // 
            this.cmdClose_Form_gengou.Location = new System.Drawing.Point(53, 138);
            this.cmdClose_Form_gengou.Name = "cmdClose_Form_gengou";
            this.cmdClose_Form_gengou.Size = new System.Drawing.Size(75, 23);
            this.cmdClose_Form_gengou.TabIndex = 2;
            this.cmdClose_Form_gengou.Text = "閉じる";
            this.cmdClose_Form_gengou.UseVisualStyleBackColor = true;
            this.cmdClose_Form_gengou.Click += new System.EventHandler(this.CmdClose_Click);
            // 
            // bindingNavigatorGengou
            // 
            this.bindingNavigatorGengou.AddNewItem = this.toolStripButton5;
            this.bindingNavigatorGengou.CountItem = this.toolStripLabel1;
            this.bindingNavigatorGengou.DeleteItem = this.toolStripButton6;
            this.bindingNavigatorGengou.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripTextBox1,
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator3,
            this.toolStripButton5,
            this.toolStripButton6});
            this.bindingNavigatorGengou.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigatorGengou.MoveFirstItem = this.toolStripButton1;
            this.bindingNavigatorGengou.MoveLastItem = this.toolStripButton4;
            this.bindingNavigatorGengou.MoveNextItem = this.toolStripButton3;
            this.bindingNavigatorGengou.MovePreviousItem = this.toolStripButton2;
            this.bindingNavigatorGengou.Name = "bindingNavigatorGengou";
            this.bindingNavigatorGengou.PositionItem = this.toolStripTextBox1;
            this.bindingNavigatorGengou.Size = new System.Drawing.Size(1132, 25);
            this.bindingNavigatorGengou.TabIndex = 3;
            this.bindingNavigatorGengou.Text = "bindingNavigator1";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.RightToLeftAutoMirrorImage = true;
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "新規追加";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(29, 22);
            this.toolStripLabel1.Text = "/ {0}";
            this.toolStripLabel1.ToolTipText = "項目の総数";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.RightToLeftAutoMirrorImage = true;
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "削除";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.RightToLeftAutoMirrorImage = true;
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "最初に移動";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.RightToLeftAutoMirrorImage = true;
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "前に戻る";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.AccessibleName = "位置";
            this.toolStripTextBox1.AutoSize = false;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(50, 23);
            this.toolStripTextBox1.Text = "0";
            this.toolStripTextBox1.ToolTipText = "現在の場所";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.RightToLeftAutoMirrorImage = true;
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "次に移動";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.RightToLeftAutoMirrorImage = true;
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "最後に移動";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingSourceGengou
            // 
            this.bindingSourceGengou.DataMember = "gengou_ds";
            // 
            // dataGridViewGengou
            // 
            this.dataGridViewGengou.AutoGenerateColumns = false;
            this.dataGridViewGengou.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGengou.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gg_id,
            this.gengou,
            this.g_name,
            this.start_date,
            this.end_date,
            this.diff});
            this.dataGridViewGengou.DataSource = this.bindingSourceGengou;
            this.dataGridViewGengou.Location = new System.Drawing.Point(243, 66);
            this.dataGridViewGengou.Name = "dataGridViewGengou";
            this.dataGridViewGengou.RowTemplate.Height = 21;
            this.dataGridViewGengou.Size = new System.Drawing.Size(666, 150);
            this.dataGridViewGengou.TabIndex = 4;
            // 
            // gg_id
            // 
            this.gg_id.DataPropertyName = "gg_id";
            this.gg_id.HeaderText = "ID";
            this.gg_id.Name = "gg_id";
            // 
            // gengou
            // 
            this.gengou.DataPropertyName = "gengou";
            this.gengou.HeaderText = "元号";
            this.gengou.Name = "gengou";
            // 
            // g_name
            // 
            this.g_name.DataPropertyName = "g_name";
            this.g_name.HeaderText = "略号";
            this.g_name.Name = "g_name";
            // 
            // start_date
            // 
            this.start_date.DataPropertyName = "start_date";
            this.start_date.HeaderText = "開始日";
            this.start_date.Name = "start_date";
            // 
            // end_date
            // 
            this.end_date.DataPropertyName = "end_date";
            this.end_date.HeaderText = "終了日";
            this.end_date.Name = "end_date";
            // 
            // diff
            // 
            this.diff.DataPropertyName = "diff";
            this.diff.HeaderText = "西暦との年差";
            this.diff.Name = "diff";
            // 
            // Form_gengou
            // 
            this.ClientSize = new System.Drawing.Size(1132, 261);
            this.Controls.Add(this.dataGridViewGengou);
            this.Controls.Add(this.bindingNavigatorGengou);
            this.Controls.Add(this.cmdClose_Form_gengou);
            this.Controls.Add(this.CmdGengouSave);
            this.Name = "Form_gengou";
            this.Load += new System.EventHandler(this.Form_Gengou_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorGengou)).EndInit();
            this.bindingNavigatorGengou.ResumeLayout(false);
            this.bindingNavigatorGengou.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceGengou)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGengou)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CmdGengouSave;
        private System.Windows.Forms.Button cmdClose_Form_gengou;
        private System.Windows.Forms.BindingNavigator bindingNavigatorGengou;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.BindingSource bindingSourceGengou;
        private System.Windows.Forms.DataGridView dataGridViewGengou;
        private System.Windows.Forms.DataGridViewTextBoxColumn gg_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn gengou;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn start_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn end_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn diff;
    }
}