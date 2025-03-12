using MediaHawk.ChainOfResponsability;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaHawk
{
    public partial class MediaHawk: Form
    {
        public MediaHawk()
        {
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            //Close the Application
            Application.Exit();
        }

        private void closeBtn_MouseEnter(object sender, EventArgs e)
        {
            //Hover Effect
            closeBtn.BackColor = Color.DarkRed;
        }

        private void closeBtn_MouseLeave(object sender, EventArgs e)
        {
            //Hover Effect
            closeBtn.BackColor = Color.FromArgb(192, 255, 192);
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            //Minimize app button
            this.WindowState = FormWindowState.Minimized;
        }

        private void minimizeBtn_MouseEnter(object sender, EventArgs e)
        {
            //Hover Event
            minimizeBtn.BackColor = Color.DarkRed;
        }

        private void minimizeBtn_MouseLeave(object sender, EventArgs e)
        {
            //Hover Effect
            minimizeBtn.BackColor = Color.FromArgb(192, 255, 192);
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            //Configure the file dialog
            fileDialogUpload.Filter = "Text Files (*.txt)|*.txt"; //to allow only txt files
            fileDialogUpload.Multiselect = true;
            fileDialogUpload.Title = "Select TXT File(s)";

            //Show the dialog and check if the user selected files
            if (fileDialogUpload.ShowDialog() == DialogResult.OK && fileDialogUpload.FileNames.Length > 0)
            {
                fileList.Items.Clear();
                foreach (string filePath in fileDialogUpload.FileNames)
                {
                    fileList.Items.Add(System.IO.Path.GetFileName(filePath));
                }

                DialogResult result = MessageBox.Show("Do you want to process the files?", "Confimation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    tabControl1.SelectedTab = tabControl1.TabPages[2];
                }
            }
            else
            {
                MessageBox.Show("You must select at least one .txt file!", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void ProcessBtn_Click(object sender, EventArgs e)
        {
            if (fileList.Items.Count == 0)
            {
                MessageBox.Show("No files to process!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Get file names from filelist in the order they were added
            Queue<string> filesQueue = new Queue<string>();
            foreach (var item in fileList.Items)
            {
                filesQueue.Enqueue(item.ToString());
            }
            //Setting up the Chain of Responsibility
            FileProcessorHandler cleaning = new CleaningHandler();
            FileProcessorHandler tokenizer = new TokenizerHandler();
            FileProcessorHandler analyser = new AnalyzerHandler();
            FileProcessorHandler predictor = new PredictorHandler();

            cleaning.SetNext(tokenizer);
            tokenizer.SetNext(analyser);
            analyser.SetNext(predictor);

            //Start processing
            while (filesQueue.Count > 0)
            {
                string currentFile = filesQueue.Dequeue();
                Console.WriteLine($"Processing file: {currentFile}");

                cleaning.Process(new List<string> { currentFile });
            }
            //if one file do something
            MessageBox.Show("Processing completed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
