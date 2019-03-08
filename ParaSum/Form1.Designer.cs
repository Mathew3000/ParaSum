namespace ParaSum
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bt_generate = new System.Windows.Forms.Button();
            this.lb_files = new System.Windows.Forms.ListBox();
            this.bt_browse = new System.Windows.Forms.Button();
            this.tb_path = new System.Windows.Forms.TextBox();
            this.bt_scanFiles = new System.Windows.Forms.Button();
            this.cb_subdir = new System.Windows.Forms.CheckBox();
            this.bt_clear = new System.Windows.Forms.Button();
            this.bt_verify = new System.Windows.Forms.Button();
            this.fbd_scan = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_total = new System.Windows.Forms.Label();
            this.lbl_done = new System.Windows.Forms.Label();
            this.ti_ui = new System.Windows.Forms.Timer(this.components);
            this.bt_save = new System.Windows.Forms.Button();
            this.sfd_main = new System.Windows.Forms.SaveFileDialog();
            this.ofd_main = new System.Windows.Forms.OpenFileDialog();
            this.lbl_failed = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ti_verify = new System.Windows.Forms.Timer(this.components);
            this.bt_export = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_generate
            // 
            this.bt_generate.Location = new System.Drawing.Point(362, 151);
            this.bt_generate.Name = "bt_generate";
            this.bt_generate.Size = new System.Drawing.Size(75, 23);
            this.bt_generate.TabIndex = 0;
            this.bt_generate.Text = "generate";
            this.bt_generate.UseVisualStyleBackColor = true;
            this.bt_generate.Click += new System.EventHandler(this.bt_generate_Click);
            // 
            // lb_files
            // 
            this.lb_files.FormattingEnabled = true;
            this.lb_files.Location = new System.Drawing.Point(13, 13);
            this.lb_files.Name = "lb_files";
            this.lb_files.Size = new System.Drawing.Size(610, 134);
            this.lb_files.TabIndex = 1;
            // 
            // bt_browse
            // 
            this.bt_browse.Location = new System.Drawing.Point(183, 154);
            this.bt_browse.Name = "bt_browse";
            this.bt_browse.Size = new System.Drawing.Size(45, 20);
            this.bt_browse.TabIndex = 2;
            this.bt_browse.Text = "...";
            this.bt_browse.UseVisualStyleBackColor = true;
            this.bt_browse.Click += new System.EventHandler(this.bt_browse_Click);
            // 
            // tb_path
            // 
            this.tb_path.Location = new System.Drawing.Point(13, 154);
            this.tb_path.Name = "tb_path";
            this.tb_path.Size = new System.Drawing.Size(164, 20);
            this.tb_path.TabIndex = 3;
            // 
            // bt_scanFiles
            // 
            this.bt_scanFiles.Location = new System.Drawing.Point(234, 151);
            this.bt_scanFiles.Name = "bt_scanFiles";
            this.bt_scanFiles.Size = new System.Drawing.Size(75, 23);
            this.bt_scanFiles.TabIndex = 4;
            this.bt_scanFiles.Text = "scan for files";
            this.bt_scanFiles.UseVisualStyleBackColor = true;
            this.bt_scanFiles.Click += new System.EventHandler(this.bt_scanFiles_Click);
            // 
            // cb_subdir
            // 
            this.cb_subdir.AutoSize = true;
            this.cb_subdir.Location = new System.Drawing.Point(13, 180);
            this.cb_subdir.Name = "cb_subdir";
            this.cb_subdir.Size = new System.Drawing.Size(126, 17);
            this.cb_subdir.TabIndex = 5;
            this.cb_subdir.Text = "search subdirectories";
            this.cb_subdir.UseVisualStyleBackColor = true;
            this.cb_subdir.CheckedChanged += new System.EventHandler(this.cb_subdir_CheckedChanged);
            // 
            // bt_clear
            // 
            this.bt_clear.Location = new System.Drawing.Point(315, 151);
            this.bt_clear.Name = "bt_clear";
            this.bt_clear.Size = new System.Drawing.Size(41, 23);
            this.bt_clear.TabIndex = 6;
            this.bt_clear.Text = "clear";
            this.bt_clear.UseVisualStyleBackColor = true;
            this.bt_clear.Click += new System.EventHandler(this.bt_clear_Click);
            // 
            // bt_verify
            // 
            this.bt_verify.Location = new System.Drawing.Point(443, 151);
            this.bt_verify.Name = "bt_verify";
            this.bt_verify.Size = new System.Drawing.Size(51, 23);
            this.bt_verify.TabIndex = 7;
            this.bt_verify.Text = "verify";
            this.bt_verify.UseVisualStyleBackColor = true;
            this.bt_verify.Click += new System.EventHandler(this.bt_verify_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Files Total:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(312, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Files Done:";
            // 
            // lbl_total
            // 
            this.lbl_total.AutoSize = true;
            this.lbl_total.Location = new System.Drawing.Point(244, 191);
            this.lbl_total.Name = "lbl_total";
            this.lbl_total.Size = new System.Drawing.Size(13, 13);
            this.lbl_total.TabIndex = 10;
            this.lbl_total.Text = "0";
            // 
            // lbl_done
            // 
            this.lbl_done.AutoSize = true;
            this.lbl_done.Location = new System.Drawing.Point(378, 191);
            this.lbl_done.Name = "lbl_done";
            this.lbl_done.Size = new System.Drawing.Size(13, 13);
            this.lbl_done.TabIndex = 11;
            this.lbl_done.Text = "0";
            // 
            // ti_ui
            // 
            this.ti_ui.Enabled = true;
            this.ti_ui.Tick += new System.EventHandler(this.ti_ui_Tick);
            // 
            // bt_save
            // 
            this.bt_save.Location = new System.Drawing.Point(500, 151);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(51, 23);
            this.bt_save.TabIndex = 12;
            this.bt_save.Text = "save";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // ofd_main
            // 
            this.ofd_main.FileName = "sums";
            // 
            // lbl_failed
            // 
            this.lbl_failed.AutoSize = true;
            this.lbl_failed.Location = new System.Drawing.Point(506, 191);
            this.lbl_failed.Name = "lbl_failed";
            this.lbl_failed.Size = new System.Drawing.Size(13, 13);
            this.lbl_failed.TabIndex = 14;
            this.lbl_failed.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(440, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Files Failed:";
            // 
            // ti_verify
            // 
            this.ti_verify.Tick += new System.EventHandler(this.ti_verify_Tick);
            // 
            // bt_export
            // 
            this.bt_export.Location = new System.Drawing.Point(557, 151);
            this.bt_export.Name = "bt_export";
            this.bt_export.Size = new System.Drawing.Size(66, 23);
            this.bt_export.TabIndex = 15;
            this.bt_export.Text = "export diff";
            this.bt_export.UseVisualStyleBackColor = true;
            this.bt_export.Visible = false;
            this.bt_export.Click += new System.EventHandler(this.bt_export_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 219);
            this.Controls.Add(this.bt_export);
            this.Controls.Add(this.lbl_failed);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.lbl_done);
            this.Controls.Add(this.lbl_total);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_verify);
            this.Controls.Add(this.bt_clear);
            this.Controls.Add(this.cb_subdir);
            this.Controls.Add(this.bt_scanFiles);
            this.Controls.Add(this.tb_path);
            this.Controls.Add(this.bt_browse);
            this.Controls.Add(this.lb_files);
            this.Controls.Add(this.bt_generate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_generate;
        private System.Windows.Forms.ListBox lb_files;
        private System.Windows.Forms.Button bt_browse;
        private System.Windows.Forms.TextBox tb_path;
        private System.Windows.Forms.Button bt_scanFiles;
        private System.Windows.Forms.CheckBox cb_subdir;
        private System.Windows.Forms.Button bt_clear;
        private System.Windows.Forms.Button bt_verify;
        private System.Windows.Forms.FolderBrowserDialog fbd_scan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_total;
        private System.Windows.Forms.Label lbl_done;
        private System.Windows.Forms.Timer ti_ui;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.SaveFileDialog sfd_main;
        private System.Windows.Forms.OpenFileDialog ofd_main;
        private System.Windows.Forms.Label lbl_failed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer ti_verify;
        private System.Windows.Forms.Button bt_export;
    }
}

