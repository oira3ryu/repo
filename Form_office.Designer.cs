namespace rk_seikyu
{
    partial class Form_office
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_office));
            this.dataGridViewOffice = new System.Windows.Forms.DataGridView();
            this.CmdOfficeSave = new System.Windows.Forms.Button();
            this.CmdClose = new System.Windows.Forms.Button();
            this.bindingSourceOffice = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorOffice = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.o_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flg = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.o_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.o_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.o_p_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.o_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.o_phone_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.o_manager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.o_stuff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOffice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceOffice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorOffice)).BeginInit();
            this.bindingNavigatorOffice.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewOffice
            // 
            this.dataGridViewOffice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOffice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.o_id,
            this.flg,
            this.o_number,
            this.o_name,
            this.o_p_code,
            this.o_address,
            this.o_phone_number,
            this.o_manager,
            this.o_stuff});
            this.dataGridViewOffice.Location = new System.Drawing.Point(142, 115);
            this.dataGridViewOffice.Name = "dataGridViewOffice";
            this.dataGridViewOffice.RowTemplate.Height = 21;
            this.dataGridViewOffice.Size = new System.Drawing.Size(1027, 150);
            this.dataGridViewOffice.TabIndex = 0;
            // 
            // CmdOfficeSave
            // 
            this.CmdOfficeSave.Location = new System.Drawing.Point(36, 136);
            this.CmdOfficeSave.Name = "CmdOfficeSave";
            this.CmdOfficeSave.Size = new System.Drawing.Size(75, 23);
            this.CmdOfficeSave.TabIndex = 1;
            this.CmdOfficeSave.Text = "更新";
            this.CmdOfficeSave.UseVisualStyleBackColor = true;
            this.CmdOfficeSave.Click += new System.EventHandler(this.CmdOfficeSave_Click);
            // 
            // CmdClose
            // 
            this.CmdClose.Location = new System.Drawing.Point(36, 213);
            this.CmdClose.Name = "CmdClose";
            this.CmdClose.Size = new System.Drawing.Size(75, 23);
            this.CmdClose.TabIndex = 2;
            this.CmdClose.Text = "閉じる";
            this.CmdClose.UseVisualStyleBackColor = true;
            this.CmdClose.Click += new System.EventHandler(this.CmdClose_Click);
            // 
            // bindingNavigatorOffice
            // 
            this.bindingNavigatorOffice.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigatorOffice.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigatorOffice.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigatorOffice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bindingNavigatorOffice.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigatorOffice.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigatorOffice.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigatorOffice.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigatorOffice.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigatorOffice.Name = "bindingNavigatorOffice";
            this.bindingNavigatorOffice.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigatorOffice.Size = new System.Drawing.Size(1197, 25);
            this.bindingNavigatorOffice.TabIndex = 3;
            this.bindingNavigatorOffice.Text = "bindingNavigator1";
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
            // o_id
            // 
            this.o_id.DataPropertyName = "o_id";
            this.o_id.HeaderText = "ID";
            this.o_id.Name = "o_id";
            // 
            // flg
            // 
            this.flg.DataPropertyName = "flg";
            this.flg.HeaderText = "既定";
            this.flg.Name = "flg";
            this.flg.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.flg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // o_number
            // 
            this.o_number.DataPropertyName = "o_number";
            this.o_number.HeaderText = "事業所番号";
            this.o_number.Name = "o_number";
            // 
            // o_name
            // 
            this.o_name.DataPropertyName = "o_name";
            this.o_name.HeaderText = "事業所名";
            this.o_name.Name = "o_name";
            // 
            // o_p_code
            // 
            this.o_p_code.DataPropertyName = "o_p_code";
            this.o_p_code.HeaderText = "郵便番号";
            this.o_p_code.Name = "o_p_code";
            // 
            // o_address
            // 
            this.o_address.DataPropertyName = "o_address";
            this.o_address.HeaderText = "住所";
            this.o_address.Name = "o_address";
            // 
            // o_phone_number
            // 
            this.o_phone_number.DataPropertyName = "o_phone_number";
            this.o_phone_number.HeaderText = "電話番号";
            this.o_phone_number.Name = "o_phone_number";
            // 
            // o_manager
            // 
            this.o_manager.DataPropertyName = "o_manager";
            this.o_manager.HeaderText = "管理者";
            this.o_manager.Name = "o_manager";
            // 
            // o_stuff
            // 
            this.o_stuff.DataPropertyName = "o_stuff";
            this.o_stuff.HeaderText = "担当者";
            this.o_stuff.Name = "o_stuff";
            // 
            // Form_office
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 450);
            this.Controls.Add(this.bindingNavigatorOffice);
            this.Controls.Add(this.CmdClose);
            this.Controls.Add(this.CmdOfficeSave);
            this.Controls.Add(this.dataGridViewOffice);
            this.Name = "Form_office";
            this.Text = "Form_office";
            this.Load += new System.EventHandler(this.Form_office_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOffice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceOffice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorOffice)).EndInit();
            this.bindingNavigatorOffice.ResumeLayout(false);
            this.bindingNavigatorOffice.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewOffice;
        private System.Windows.Forms.Button CmdOfficeSave;
        private System.Windows.Forms.Button CmdClose;
        private System.Windows.Forms.BindingSource bindingSourceOffice;
        private System.Windows.Forms.BindingNavigator bindingNavigatorOffice;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn o_id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn flg;
        private System.Windows.Forms.DataGridViewTextBoxColumn o_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn o_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn o_p_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn o_address;
        private System.Windows.Forms.DataGridViewTextBoxColumn o_phone_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn o_manager;
        private System.Windows.Forms.DataGridViewTextBoxColumn o_stuff;
    }
}