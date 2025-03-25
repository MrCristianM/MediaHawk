namespace MediaHawk
{
    partial class MediaHawk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MediaHawk));
            this.closeBtn = new System.Windows.Forms.Button();
            this.minimizeBtn = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.fileDialogUpload = new System.Windows.Forms.OpenFileDialog();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.AnalysListBox = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ProcessBtn = new System.Windows.Forms.Button();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.clearBtn = new System.Windows.Forms.Button();
            this.fileList = new System.Windows.Forms.ListBox();
            this.uploadBtn = new System.Windows.Forms.Button();
            this.pageTab = new System.Windows.Forms.TabPage();
            this.proceedBtn = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.CleanAnalysBtn = new System.Windows.Forms.Button();
            this.DownloadSelectedBtn = new System.Windows.Forms.Button();
            this.DownloadAllBtn = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.richTextBox5 = new System.Windows.Forms.RichTextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.pageTab.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.closeBtn.Font = new System.Drawing.Font("Mistral", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.ForeColor = System.Drawing.Color.IndianRed;
            this.closeBtn.Location = new System.Drawing.Point(1058, 1);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(40, 30);
            this.closeBtn.TabIndex = 0;
            this.closeBtn.TabStop = false;
            this.closeBtn.Text = "X";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            this.closeBtn.MouseEnter += new System.EventHandler(this.closeBtn_MouseEnter);
            this.closeBtn.MouseLeave += new System.EventHandler(this.closeBtn_MouseLeave);
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.minimizeBtn.Font = new System.Drawing.Font("Mistral", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizeBtn.ForeColor = System.Drawing.Color.IndianRed;
            this.minimizeBtn.Location = new System.Drawing.Point(1012, 1);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(40, 30);
            this.minimizeBtn.TabIndex = 1;
            this.minimizeBtn.TabStop = false;
            this.minimizeBtn.Text = "-";
            this.minimizeBtn.UseVisualStyleBackColor = false;
            this.minimizeBtn.Click += new System.EventHandler(this.minimizeBtn_Click);
            this.minimizeBtn.MouseEnter += new System.EventHandler(this.minimizeBtn_MouseEnter);
            this.minimizeBtn.MouseLeave += new System.EventHandler(this.minimizeBtn_MouseLeave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(80, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(885, 57);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // fileDialogUpload
            // 
            this.fileDialogUpload.FileName = "fileDialogUpload";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.richTextBox2);
            this.tabPage4.Controls.Add(this.DownloadAllBtn);
            this.tabPage4.Controls.Add(this.DownloadSelectedBtn);
            this.tabPage4.Controls.Add(this.CleanAnalysBtn);
            this.tabPage4.Controls.Add(this.AnalysListBox);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1098, 529);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Analysis";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // AnalysListBox
            // 
            this.AnalysListBox.FormattingEnabled = true;
            this.AnalysListBox.HorizontalScrollbar = true;
            this.AnalysListBox.ItemHeight = 20;
            this.AnalysListBox.Location = new System.Drawing.Point(9, 6);
            this.AnalysListBox.Name = "AnalysListBox";
            this.AnalysListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.AnalysListBox.Size = new System.Drawing.Size(399, 264);
            this.AnalysListBox.TabIndex = 0;
            this.AnalysListBox.SelectedIndexChanged += new System.EventHandler(this.AnalysListBox_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox4);
            this.tabPage2.Controls.Add(this.ProcessBtn);
            this.tabPage2.Controls.Add(this.richTextBox3);
            this.tabPage2.Controls.Add(this.clearBtn);
            this.tabPage2.Controls.Add(this.fileList);
            this.tabPage2.Controls.Add(this.uploadBtn);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1098, 529);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "File Upload";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ProcessBtn
            // 
            this.ProcessBtn.Location = new System.Drawing.Point(611, 334);
            this.ProcessBtn.Name = "ProcessBtn";
            this.ProcessBtn.Size = new System.Drawing.Size(170, 53);
            this.ProcessBtn.TabIndex = 5;
            this.ProcessBtn.Text = "Process";
            this.ProcessBtn.UseVisualStyleBackColor = true;
            this.ProcessBtn.Click += new System.EventHandler(this.ProcessBtn_Click_1);
            // 
            // richTextBox3
            // 
            this.richTextBox3.Enabled = false;
            this.richTextBox3.Font = new System.Drawing.Font("MingLiU-ExtB", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.richTextBox3.Location = new System.Drawing.Point(164, 19);
            this.richTextBox3.Multiline = false;
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.ReadOnly = true;
            this.richTextBox3.Size = new System.Drawing.Size(811, 39);
            this.richTextBox3.TabIndex = 4;
            this.richTextBox3.Text = "Please upload only .txt files. Multiple files can be selected.";
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(50, 405);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(76, 31);
            this.clearBtn.TabIndex = 2;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click_1);
            // 
            // fileList
            // 
            this.fileList.FormattingEnabled = true;
            this.fileList.ItemHeight = 20;
            this.fileList.Location = new System.Drawing.Point(277, 64);
            this.fileList.Name = "fileList";
            this.fileList.ScrollAlwaysVisible = true;
            this.fileList.Size = new System.Drawing.Size(575, 244);
            this.fileList.TabIndex = 1;
            // 
            // uploadBtn
            // 
            this.uploadBtn.Location = new System.Drawing.Point(340, 334);
            this.uploadBtn.Name = "uploadBtn";
            this.uploadBtn.Size = new System.Drawing.Size(170, 53);
            this.uploadBtn.TabIndex = 0;
            this.uploadBtn.Text = "Upload";
            this.uploadBtn.UseVisualStyleBackColor = true;
            this.uploadBtn.Click += new System.EventHandler(this.uploadBtn_Click);
            // 
            // pageTab
            // 
            this.pageTab.Controls.Add(this.richTextBox5);
            this.pageTab.Controls.Add(this.proceedBtn);
            this.pageTab.Controls.Add(this.richTextBox1);
            this.pageTab.Location = new System.Drawing.Point(4, 29);
            this.pageTab.Name = "pageTab";
            this.pageTab.Padding = new System.Windows.Forms.Padding(3);
            this.pageTab.Size = new System.Drawing.Size(1098, 529);
            this.pageTab.TabIndex = 0;
            this.pageTab.Text = "Home";
            this.pageTab.UseVisualStyleBackColor = true;
            // 
            // proceedBtn
            // 
            this.proceedBtn.Location = new System.Drawing.Point(464, 238);
            this.proceedBtn.Name = "proceedBtn";
            this.proceedBtn.Size = new System.Drawing.Size(170, 53);
            this.proceedBtn.TabIndex = 1;
            this.proceedBtn.Text = "Proceed";
            this.proceedBtn.UseVisualStyleBackColor = true;
            this.proceedBtn.Click += new System.EventHandler(this.proceedBtn_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Font = new System.Drawing.Font("MingLiU-ExtB", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.richTextBox1.Location = new System.Drawing.Point(153, 58);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(785, 129);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "MediaHawk SCIoT processes transcription files by:\n        ✔ Cleaning the text (re" +
    "moves unnecessary words)\n        ✔ Analyzing word frequency\n        ✔ Generating" +
    " word clouds for insights\n";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged_1);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.pageTab);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(-1, 57);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1106, 562);
            this.tabControl1.TabIndex = 4;
            // 
            // CleanAnalysBtn
            // 
            this.CleanAnalysBtn.Location = new System.Drawing.Point(9, 425);
            this.CleanAnalysBtn.Name = "CleanAnalysBtn";
            this.CleanAnalysBtn.Size = new System.Drawing.Size(93, 31);
            this.CleanAnalysBtn.TabIndex = 3;
            this.CleanAnalysBtn.Text = "Restart";
            this.CleanAnalysBtn.UseVisualStyleBackColor = true;
            this.CleanAnalysBtn.Click += new System.EventHandler(this.CleanAnalysBtn_Click);
            // 
            // DownloadSelectedBtn
            // 
            this.DownloadSelectedBtn.Location = new System.Drawing.Point(9, 287);
            this.DownloadSelectedBtn.Name = "DownloadSelectedBtn";
            this.DownloadSelectedBtn.Size = new System.Drawing.Size(170, 53);
            this.DownloadSelectedBtn.TabIndex = 4;
            this.DownloadSelectedBtn.Text = "Download Selected Files";
            this.DownloadSelectedBtn.UseVisualStyleBackColor = true;
            this.DownloadSelectedBtn.Click += new System.EventHandler(this.DownloadSelectedBtn_Click);
            // 
            // DownloadAllBtn
            // 
            this.DownloadAllBtn.Location = new System.Drawing.Point(238, 287);
            this.DownloadAllBtn.Name = "DownloadAllBtn";
            this.DownloadAllBtn.Size = new System.Drawing.Size(170, 53);
            this.DownloadAllBtn.TabIndex = 5;
            this.DownloadAllBtn.Text = "Download All";
            this.DownloadAllBtn.UseVisualStyleBackColor = true;
            this.DownloadAllBtn.Click += new System.EventHandler(this.DownloadAllBtn_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Enabled = false;
            this.richTextBox2.Font = new System.Drawing.Font("MingLiU-ExtB", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.richTextBox2.Location = new System.Drawing.Point(335, 425);
            this.richTextBox2.Multiline = false;
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(459, 39);
            this.richTextBox2.TabIndex = 6;
            this.richTextBox2.Text = "Design by Cristian Munteanu 303704";
            this.richTextBox2.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // richTextBox4
            // 
            this.richTextBox4.Enabled = false;
            this.richTextBox4.Font = new System.Drawing.Font("MingLiU-ExtB", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.richTextBox4.Location = new System.Drawing.Point(322, 425);
            this.richTextBox4.Multiline = false;
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.ReadOnly = true;
            this.richTextBox4.Size = new System.Drawing.Size(459, 39);
            this.richTextBox4.TabIndex = 7;
            this.richTextBox4.Text = "Design by Cristian Munteanu 303704";
            // 
            // richTextBox5
            // 
            this.richTextBox5.Enabled = false;
            this.richTextBox5.Font = new System.Drawing.Font("MingLiU-ExtB", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox5.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.richTextBox5.Location = new System.Drawing.Point(322, 425);
            this.richTextBox5.Multiline = false;
            this.richTextBox5.Name = "richTextBox5";
            this.richTextBox5.ReadOnly = true;
            this.richTextBox5.Size = new System.Drawing.Size(451, 39);
            this.richTextBox5.TabIndex = 7;
            this.richTextBox5.Text = "Design by Cristian Munteanu 303704";
            // 
            // MediaHawk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 562);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.minimizeBtn);
            this.Controls.Add(this.closeBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MediaHawk";
            this.Text = "Media Hawk";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.pageTab.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button minimizeBtn;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.OpenFileDialog fileDialogUpload;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage pageTab;
        private System.Windows.Forms.Button proceedBtn;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button ProcessBtn;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.ListBox fileList;
        private System.Windows.Forms.Button uploadBtn;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListBox AnalysListBox;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button DownloadAllBtn;
        private System.Windows.Forms.Button DownloadSelectedBtn;
        private System.Windows.Forms.Button CleanAnalysBtn;
        private System.Windows.Forms.RichTextBox richTextBox5;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

