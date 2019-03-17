namespace rk_seikyu
{
    partial class Form_dbconfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_dbconfig));
            this.CmdDbconfigSave = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.DataGridViewDbconfig = new System.Windows.Forms.DataGridView();
            this.bindingNavigatorDbconfig = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingSourceDbconfig = new System.Windows.Forms.BindingSource(this.components);
            this.d_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_oct1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_oct2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_oct3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_oct4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_pass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_database_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_flg = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewDbconfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorDbconfig)).BeginInit();
            this.bindingNavigatorDbconfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDbconfig)).BeginInit();
            this.SuspendLayout();
            // 
            // CmdDbconfigSave
            // 
            this.CmdDbconfigSave.Location = new System.Drawing.Point(56, 159);
            this.CmdDbconfigSave.Name = "CmdDbconfigSave";
            this.CmdDbconfigSave.Size = new System.Drawing.Size(75, 23);
            this.CmdDbconfigSave.TabIndex = 0;
            this.CmdDbconfigSave.Text = "更新";
            this.CmdDbconfigSave.UseVisualStyleBackColor = true;
            this.CmdDbconfigSave.Click += new System.EventHandler(this.CmdDbconfigSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(55, 235);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 1;
            this.cmdClose.Text = "閉じる";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.CmdClose_Click);
            // 
            // DataGridViewDbconfig
            // 
            this.DataGridViewDbconfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewDbconfig.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.d_id,
            this.d_name,
            this.d_oct1,
            this.d_oct2,
            this.d_oct3,
            this.d_oct4,
            this.d_port,
            this.d_user,
            this.d_pass,
            this.d_database_name,
            this.d_flg});
            this.DataGridViewDbconfig.Location = new System.Drawing.Point(157, 135);
            this.DataGridViewDbconfig.Name = "DataGridViewDbconfig";
            this.DataGridViewDbconfig.RowTemplate.Height = 21;
            this.DataGridViewDbconfig.Size = new System.Drawing.Size(1012, 150);
            this.DataGridViewDbconfig.TabIndex = 2;
            // 
            // bindingNavigatorDbconfig
            // 
            this.bindingNavigatorDbconfig.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigatorDbconfig.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigatorDbconfig.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigatorDbconfig.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bindingNavigatorDbconfig.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigatorDbconfig.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigatorDbconfig.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigatorDbconfig.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigatorDbconfig.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigatorDbconfig.Name = "bindingNavigatorDbconfig";
            this.bindingNavigatorDbconfig.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigatorDbconfig.Size = new System.Drawing.Size(1232, 25);
            this.bindingNavigatorDbconfig.TabIndex = 3;
            this.bindingNavigatorDbconfig.Text = "bindingNavigatorDbconfig";
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
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(29, 22);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "項目の総数";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
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
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "削除";
            // 
            // d_id
            // 
            this.d_id.DataPropertyName = "d_id";
            this.d_id.HeaderText = "ID";
            this.d_id.Name = "d_id";
            // 
            // d_name
            // 
            this.d_name.DataPropertyName = "d_name";
            this.d_name.HeaderText = "接続文字列";
            this.d_name.Name = "d_name";
            // 
            // d_oct1
            // 
            this.d_oct1.DataPropertyName = "d_oct1";
            this.d_oct1.HeaderText = "第1オクテット";
            this.d_oct1.Name = "d_oct1";
            // 
            // d_oct2
            // 
            this.d_oct2.DataPropertyName = "d_oct2";
            this.d_oct2.HeaderText = "第2オクテット";
            this.d_oct2.Name = "d_oct2";
            // 
            // d_oct3
            // 
            this.d_oct3.DataPropertyName = "d_oct3";
            this.d_oct3.HeaderText = "第3オクテット";
            this.d_oct3.Name = "d_oct3";
            // 
            // d_oct4
            // 
            this.d_oct4.DataPropertyName = "d_oct4";
            this.d_oct4.HeaderText = "第4オクテット";
            this.d_oct4.Name = "d_oct4";
            // 
            // d_port
            // 
            this.d_port.DataPropertyName = "d_port";
            this.d_port.HeaderText = "ポート";
            this.d_port.Name = "d_port";
            // 
            // d_user
            // 
            this.d_user.DataPropertyName = "d_user";
            this.d_user.HeaderText = "ユーザー名";
            this.d_user.Name = "d_user";
            // 
            // d_pass
            // 
            this.d_pass.DataPropertyName = "d_pass";
            this.d_pass.HeaderText = "パスワード";
            this.d_pass.Name = "d_pass";
            // 
            // d_database_name
            // 
            this.d_database_name.DataPropertyName = "d_database_name";
            this.d_database_name.HeaderText = "データベース名";
            this.d_database_name.Name = "d_database_name";
            // 
            // d_flg
            // 
            this.d_flg.DataPropertyName = "d_flg";
            this.d_flg.HeaderText = "選択";
            this.d_flg.Name = "d_flg";
            this.d_flg.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.d_flg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Form_dbconfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 450);
            this.Controls.Add(this.bindingNavigatorDbconfig);
            this.Controls.Add(this.DataGridViewDbconfig);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.CmdDbconfigSave);
            this.Name = "Form_dbconfig";
            this.Text = "Form_dbconfig";
            this.Load += new System.EventHandler(this.Form_dbconfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewDbconfig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorDbconfig)).EndInit();
            this.bindingNavigatorDbconfig.ResumeLayout(false);
            this.bindingNavigatorDbconfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDbconfig)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CmdDbconfigSave;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.DataGridView DataGridViewDbconfig;
        private System.Windows.Forms.BindingNavigator bindingNavigatorDbconfig;
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
        private System.Windows.Forms.BindingSource bindingSourceDbconfig;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_oct1;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_oct2;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_oct3;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_oct4;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_port;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_user;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_pass;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_database_name;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d_flg;
    }
}