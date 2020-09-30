namespace rk_seikyu
{
    partial class Form_chg
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
            this.CmdOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_gengou = new System.Windows.Forms.RadioButton();
            this.rb_req = new System.Windows.Forms.RadioButton();
            this.rb_rep = new System.Windows.Forms.RadioButton();
            this.rb_par = new System.Windows.Forms.RadioButton();
            this.CmdClose = new System.Windows.Forms.Button();
            this.rb_chief = new System.Windows.Forms.RadioButton();
            this.rb_accounting_manager = new System.Windows.Forms.RadioButton();
            this.rb_manager = new System.Windows.Forms.RadioButton();
            this.rb_stuff = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmdOK
            // 
            this.CmdOK.Location = new System.Drawing.Point(111, 219);
            this.CmdOK.Name = "CmdOK";
            this.CmdOK.Size = new System.Drawing.Size(75, 23);
            this.CmdOK.TabIndex = 2;
            this.CmdOK.Text = "OK";
            this.CmdOK.UseVisualStyleBackColor = true;
            this.CmdOK.Click += new System.EventHandler(this.CmdOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_stuff);
            this.groupBox1.Controls.Add(this.rb_manager);
            this.groupBox1.Controls.Add(this.rb_accounting_manager);
            this.groupBox1.Controls.Add(this.rb_chief);
            this.groupBox1.Controls.Add(this.rb_gengou);
            this.groupBox1.Controls.Add(this.rb_req);
            this.groupBox1.Controls.Add(this.rb_rep);
            this.groupBox1.Controls.Add(this.rb_par);
            this.groupBox1.Location = new System.Drawing.Point(45, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(446, 172);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // rb_gengou
            // 
            this.rb_gengou.AutoSize = true;
            this.rb_gengou.Location = new System.Drawing.Point(22, 127);
            this.rb_gengou.Name = "rb_gengou";
            this.rb_gengou.Size = new System.Drawing.Size(97, 16);
            this.rb_gengou.TabIndex = 5;
            this.rb_gengou.TabStop = true;
            this.rb_gengou.Text = "元号マスタ設定";
            this.rb_gengou.UseVisualStyleBackColor = true;
            // 
            // rb_req
            // 
            this.rb_req.AutoSize = true;
            this.rb_req.Location = new System.Drawing.Point(22, 96);
            this.rb_req.Name = "rb_req";
            this.rb_req.Size = new System.Drawing.Size(119, 16);
            this.rb_req.TabIndex = 4;
            this.rb_req.TabStop = true;
            this.rb_req.Text = "納付共通項目設定";
            this.rb_req.UseVisualStyleBackColor = true;
            // 
            // rb_rep
            // 
            this.rb_rep.AutoSize = true;
            this.rb_rep.Location = new System.Drawing.Point(21, 64);
            this.rb_rep.Name = "rb_rep";
            this.rb_rep.Size = new System.Drawing.Size(143, 16);
            this.rb_rep.TabIndex = 3;
            this.rb_rep.TabStop = true;
            this.rb_rep.Text = "納付案内表示項目設定";
            this.rb_rep.UseVisualStyleBackColor = true;
            // 
            // rb_par
            // 
            this.rb_par.AutoSize = true;
            this.rb_par.Location = new System.Drawing.Point(22, 31);
            this.rb_par.Name = "rb_par";
            this.rb_par.Size = new System.Drawing.Size(131, 16);
            this.rb_par.TabIndex = 2;
            this.rb_par.TabStop = true;
            this.rb_par.Text = "納付書表示項目設定";
            this.rb_par.UseVisualStyleBackColor = true;
            // 
            // CmdClose
            // 
            this.CmdClose.Location = new System.Drawing.Point(348, 219);
            this.CmdClose.Name = "CmdClose";
            this.CmdClose.Size = new System.Drawing.Size(75, 23);
            this.CmdClose.TabIndex = 4;
            this.CmdClose.Text = "閉じる";
            this.CmdClose.UseVisualStyleBackColor = true;
            this.CmdClose.Click += new System.EventHandler(this.CmdClose_Click);
            // 
            // rb_chief
            // 
            this.rb_chief.AutoSize = true;
            this.rb_chief.Location = new System.Drawing.Point(261, 31);
            this.rb_chief.Name = "rb_chief";
            this.rb_chief.Size = new System.Drawing.Size(83, 16);
            this.rb_chief.TabIndex = 6;
            this.rb_chief.TabStop = true;
            this.rb_chief.Text = "理事者設定";
            this.rb_chief.UseVisualStyleBackColor = true;
            // 
            // rb_accounting_manager
            // 
            this.rb_accounting_manager.AutoSize = true;
            this.rb_accounting_manager.Location = new System.Drawing.Point(261, 64);
            this.rb_accounting_manager.Name = "rb_accounting_manager";
            this.rb_accounting_manager.Size = new System.Drawing.Size(107, 16);
            this.rb_accounting_manager.TabIndex = 7;
            this.rb_accounting_manager.TabStop = true;
            this.rb_accounting_manager.Text = "会計管理者設定";
            this.rb_accounting_manager.UseVisualStyleBackColor = true;
            // 
            // rb_manager
            // 
            this.rb_manager.AutoSize = true;
            this.rb_manager.Location = new System.Drawing.Point(261, 96);
            this.rb_manager.Name = "rb_manager";
            this.rb_manager.Size = new System.Drawing.Size(107, 16);
            this.rb_manager.TabIndex = 8;
            this.rb_manager.TabStop = true;
            this.rb_manager.Text = "施設管理者設定";
            this.rb_manager.UseVisualStyleBackColor = true;
            // 
            // rb_stuff
            // 
            this.rb_stuff.AutoSize = true;
            this.rb_stuff.Location = new System.Drawing.Point(261, 127);
            this.rb_stuff.Name = "rb_stuff";
            this.rb_stuff.Size = new System.Drawing.Size(83, 16);
            this.rb_stuff.TabIndex = 9;
            this.rb_stuff.TabStop = true;
            this.rb_stuff.Text = "担当者設定";
            this.rb_stuff.UseVisualStyleBackColor = true;
            // 
            // Form_chg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 266);
            this.Controls.Add(this.CmdClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CmdOK);
            this.Name = "Form_chg";
            this.Text = "Form_chg";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CmdOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_rep;
        private System.Windows.Forms.RadioButton rb_par;
        private System.Windows.Forms.RadioButton rb_req;
        private System.Windows.Forms.RadioButton rb_gengou;
        private System.Windows.Forms.Button CmdClose;
        private System.Windows.Forms.RadioButton rb_stuff;
        private System.Windows.Forms.RadioButton rb_manager;
        private System.Windows.Forms.RadioButton rb_accounting_manager;
        private System.Windows.Forms.RadioButton rb_chief;
    }
}