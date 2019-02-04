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
            this.cmdClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_rep = new System.Windows.Forms.RadioButton();
            this.rb_par = new System.Windows.Forms.RadioButton();
            this.rb_req = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(108, 207);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 2;
            this.cmdClose.Text = "OK";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_req);
            this.groupBox1.Controls.Add(this.rb_rep);
            this.groupBox1.Controls.Add(this.rb_par);
            this.groupBox1.Location = new System.Drawing.Point(42, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 143);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
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
            this.rb_req.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // Form_chg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 266);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdClose);
            this.Name = "Form_chg";
            this.Text = "Form_chg";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_rep;
        private System.Windows.Forms.RadioButton rb_par;
        private System.Windows.Forms.RadioButton rb_req;
    }
}