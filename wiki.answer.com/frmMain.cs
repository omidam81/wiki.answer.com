using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wiki.answer.com
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpeFile(txtInputFile);
        }

        private void OpeFile(TextBox textBox)
        {
            OpenFileDialog D = new OpenFileDialog();

            if (D.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Environment.CurrentDirectory = new FileInfo(D.FileName).DirectoryName;
                textBox.Text = D.FileName;
            }
        }
        private void SaveFileDialog(TextBox textBox)
        {
            SaveFileDialog D = new SaveFileDialog();

            if (D.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Environment.CurrentDirectory = new FileInfo(D.FileName).DirectoryName;
                textBox.Text = D.FileName;
            }
        }

        private void OpenFolder(TextBox textBox)
        {
            FolderBrowserDialog D = new FolderBrowserDialog();
            if (D.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox.Text = D.SelectedPath;
            }
        }
        private void btnStart2_Click(object sender, EventArgs e)
        {
            TextBox text = new TextBox();
            OpenFolder(text);
            timeTwo.Enabled = true;
            QHelper.FilePath = text.Text;
            QHelper.currentFilePath = text.Text + "/file.csv";

            DisableForm();

            System.Threading.Thread T = new System.Threading.Thread(new System.Threading.ThreadStart(ScrapQuetions));
            T.IsBackground = true;
            T.Start();

        }

        private void ScrapQuetions()
        {

            CategoriesHelper.FilePath = txtInputFile.Text;

            System.Threading.Thread T = new System.Threading.Thread(new System.Threading.ThreadStart(CategoriesHelper.Start));
            T.IsBackground = true;
            T.Start();

            T.Join();

            EnableForm();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            TextBox text = new TextBox();
            SaveFileDialog(text);

            Helper.FilePath = text.Text;
            timeOne.Enabled = true;
            DisableForm();

            System.Threading.Thread T = new System.Threading.Thread(new System.Threading.ThreadStart(ScarpCats));
            T.IsBackground = true;
            T.Start();
        }

        private void ScarpCats()
        {
            System.Threading.Thread T = new System.Threading.Thread(new System.Threading.ThreadStart(Helper.start));
            T.IsBackground = true;
            T.Start();

            T.Join();

            EnableForm();
        }

        public void DisableForm()
        {
            this.Invoke(new MethodInvoker(delegate
            {
                CantClose = true;
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                tsProgress.Visible = true;
            }));

        }
        public void EnableForm()
        {
            this.Invoke(new MethodInvoker(delegate
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
                CantClose = false;
                tsProgress.Visible = false;
            }));

            MessageBox.Show("Operation Complete");
        }

        public bool CantClose { get; set; }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = CantClose;
        }

        private void timeOne_Tick(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate()
            {
                lblPageCount1.Text = "Page Viewed: " + WebHelper.FileDownloaded.ToString() + " Pages";
                lblCategoriesCount.Text ="Categories Scraped: "  + Helper.CategoriesCount.ToString() + " Categories";
            }));
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void timeTwo_Tick(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate()
            {
                pageViewsCount2.Text = "Page Viewed: " + WebHelper.FileDownloaded.ToString() + " Pages";
                pageCounts.Text = "Quetions Scraped: " + QHelper.CurrentQuetionCount.ToString() + " Quetions";
            }));
        }
    }
}
