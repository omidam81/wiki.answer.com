namespace wiki.answer.com
{
    partial class frmMain
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblPageCount1 = new System.Windows.Forms.Label();
            this.lblCategoriesCount = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pageViewsCount2 = new System.Windows.Forms.Label();
            this.pageCounts = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInputFile = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnStart2 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.timeOne = new System.Windows.Forms.Timer(this.components);
            this.timeTwo = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(473, 122);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Phase 1: Scrap Categories";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.btnStart2);
            this.groupBox2.Location = new System.Drawing.Point(12, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(473, 146);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Phase 2: Scrap Data";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(8, 92);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(459, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(410, 292);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblPageCount1
            // 
            this.lblPageCount1.AutoSize = true;
            this.lblPageCount1.Location = new System.Drawing.Point(36, 35);
            this.lblPageCount1.Name = "lblPageCount1";
            this.lblPageCount1.Size = new System.Drawing.Size(73, 13);
            this.lblPageCount1.TabIndex = 3;
            this.lblPageCount1.Text = "Page Viewed:";
            // 
            // lblCategoriesCount
            // 
            this.lblCategoriesCount.AutoSize = true;
            this.lblCategoriesCount.Location = new System.Drawing.Point(214, 35);
            this.lblCategoriesCount.Name = "lblCategoriesCount";
            this.lblCategoriesCount.Size = new System.Drawing.Size(103, 13);
            this.lblCategoriesCount.TabIndex = 3;
            this.lblCategoriesCount.Text = "Categories Scraped:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblPageCount1);
            this.groupBox3.Controls.Add(this.lblCategoriesCount);
            this.groupBox3.Location = new System.Drawing.Point(8, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(457, 67);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Downlaod Catgoreis form Wiki,Answer.com";
            // 
            // pageViewsCount2
            // 
            this.pageViewsCount2.AutoSize = true;
            this.pageViewsCount2.Location = new System.Drawing.Point(36, 59);
            this.pageViewsCount2.Name = "pageViewsCount2";
            this.pageViewsCount2.Size = new System.Drawing.Size(73, 13);
            this.pageViewsCount2.TabIndex = 4;
            this.pageViewsCount2.Text = "Page Viewed:";
            // 
            // pageCounts
            // 
            this.pageCounts.AutoSize = true;
            this.pageCounts.Location = new System.Drawing.Point(214, 59);
            this.pageCounts.Name = "pageCounts";
            this.pageCounts.Size = new System.Drawing.Size(83, 13);
            this.pageCounts.TabIndex = 4;
            this.pageCounts.Text = "Pages Scraped:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Input Categoryes Files:";
            // 
            // txtInputFile
            // 
            this.txtInputFile.Location = new System.Drawing.Point(133, 21);
            this.txtInputFile.Name = "txtInputFile";
            this.txtInputFile.ReadOnly = true;
            this.txtInputFile.Size = new System.Drawing.Size(238, 20);
            this.txtInputFile.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(376, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.txtInputFile);
            this.groupBox4.Controls.Add(this.pageViewsCount2);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.pageCounts);
            this.groupBox4.Location = new System.Drawing.Point(8, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(457, 85);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Download Page Data with scraped categories";
            // 
            // btnStart2
            // 
            this.btnStart2.Location = new System.Drawing.Point(8, 110);
            this.btnStart2.Name = "btnStart2";
            this.btnStart2.Size = new System.Drawing.Size(459, 23);
            this.btnStart2.TabIndex = 1;
            this.btnStart2.Text = "Start";
            this.btnStart2.UseVisualStyleBackColor = true;
            this.btnStart2.Click += new System.EventHandler(this.btnStart2_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsProgress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 322);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(489, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsProgress
            // 
            this.tsProgress.Name = "tsProgress";
            this.tsProgress.Size = new System.Drawing.Size(300, 16);
            this.tsProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.tsProgress.Visible = false;
            // 
            // timeOne
            // 
            this.timeOne.Tick += new System.EventHandler(this.timeOne_Tick);
            // 
            // timeTwo
            // 
            this.timeTwo.Tick += new System.EventHandler(this.timeTwo_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 344);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wiki.Answer.com";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblPageCount1;
        private System.Windows.Forms.Label lblCategoriesCount;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtInputFile;
        private System.Windows.Forms.Label pageViewsCount2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label pageCounts;
        private System.Windows.Forms.Button btnStart2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar tsProgress;
        private System.Windows.Forms.Timer timeOne;
        private System.Windows.Forms.Timer timeTwo;
    }
}