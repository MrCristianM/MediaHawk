using MediaHawk.ChainOfResponsability;
using MediaHawk.ChainOfResponsibility;
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
            //Function which makes sure that all the files are deleted after the execution, by asking if the user agreed to exit.
            var confirm = MessageBox.Show("Do you want to exit? All the files will be wipped!",
                "Confirm Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    DeleteAllFiles(FilePaths.UploadFolder);
                    DeleteAllFiles(FilePaths.CleanedFolder);
                    DeleteAllFiles(FilePaths.TokenizedFolder);
                    DeleteAllFiles(FilePaths.AnalyzerFolder);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error while closing the application: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                Application.Exit();
            }
            else
            {
                return;
            }
            
            
        }

        private void DeleteAllFiles(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                foreach (var file in Directory.GetFiles(folderPath))
                {
                    File.Delete(file);
                }
            }
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
                string uploadedFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UploadedFiles");
                Directory.CreateDirectory(uploadedFolder); // ensure folder exists

                fileList.Items.Clear();

                foreach (string filePath in fileDialogUpload.FileNames)
                {
                    string fileName = Path.GetFileName(filePath);
                    string destinationPath = Path.Combine(uploadedFolder, fileName);

                    try
                    {
                        File.Copy(filePath, destinationPath, true); //copy and overwrite if exists
                        fileList.Items.Add(fileName); //Add to listbox

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error moving {fileName}: \n{ex.Message}","File Move Error", MessageBoxButtons.OK,MessageBoxIcon.Error);

                    }
                }

            }
            else
            {
                MessageBox.Show("You must select at least one .txt file!", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void proceedBtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            fileList.Items.Clear(); // Remove all items from the ListBox
        }

        private void clearBtn_Click_1(object sender, EventArgs e)
        {
            fileList.Items.Clear();
            try
            {
                DeleteAllFiles(FilePaths.UploadFolder);
                DeleteAllFiles(FilePaths.CleanedFolder);
                DeleteAllFiles(FilePaths.TokenizedFolder);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while closing the application: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ProcessBtn_Click_1(object sender, EventArgs e)
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
            //FileProcessorHandler predictor = new PredictorHandler();

            cleaning.SetNext(tokenizer);
            tokenizer.SetNext(analyser);
            tabControl1.SelectedTab = tabControl1.TabPages[2];
            
            //analyser.SetNext(predictor);

            //Start processing
            while (filesQueue.Count > 0)
            {
                string currentFile = filesQueue.Dequeue();

                cleaning.Process(new List<string> { currentFile });
            }
           
            //MessageBox.Show("Processing completed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            string analyzedFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AnalyzerFiles");

            // Check if the directory exists
            if (!Directory.Exists(analyzedFolder))
                return;

            // Get all CSV files in the analyzed folder
            string[] analyzedFiles = Directory.GetFiles(analyzedFolder, "*.csv");

            // Loop through each file in the analyzedFiles array
            foreach (var file in analyzedFiles)
            {
                // Add the file name to the list box
                //AnalysListBox.Items.Add(file);
                AnalysListBox.Items.Add(Path.GetFileName(file));

              
            }
            

        }

        private void AnalysListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void DownloadSelectedBtn_Click(object sender, EventArgs e)
        {
            //if (AnalysListBox.SelectedItems.Count == 0)
            //{
            //    MessageBox.Show("Please select at least one file to download.", "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            //{
            //    if (folderDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        string destinationFolder = folderDialog.SelectedPath;

            //        foreach (var selectedItem in AnalysListBox.SelectedItems)
            //        {
            //            string fileName = selectedItem.ToString();
            //            string sourceFilePath = Path.Combine(FilePaths.AnalyzerFolder, fileName);
            //            string destinationFilePath = Path.Combine(destinationFolder, fileName);

            //            try
            //            {
            //                if (File.Exists(sourceFilePath))
            //                {
            //                    File.Copy(sourceFilePath, destinationFilePath, true);
            //                }
            //                else
            //                {
            //                    MessageBox.Show($"File not found: {sourceFilePath}", "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show($"Error copying {fileName}: {ex.Message}", "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //        }

            //        MessageBox.Show("Selected files downloaded successfully!", "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            if (AnalysListBox.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one file to download.", "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var selectedItem in AnalysListBox.SelectedItems)
            {
                string fileName = selectedItem.ToString(); // Get selected file name
                string sourceFilePath = Path.Combine(FilePaths.AnalyzerFolder, fileName); // Full path

                if (!File.Exists(sourceFilePath))
                {
                    MessageBox.Show($"File not found: {sourceFilePath}", "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Title = "Save File As";
                    saveFileDialog.FileName = fileName; // Set default name
                    saveFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string destinationFilePath = saveFileDialog.FileName;

                        try
                        {
                            File.Copy(sourceFilePath, destinationFilePath, true); // Copy with overwrite
                            MessageBox.Show($"File saved: {destinationFilePath}", "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error saving {fileName}: {ex.Message}", "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            }

        private void CleanAnalysBtn_Click(object sender, EventArgs e)
        {
            AnalysListBox.Items.Clear();
            try
            {
                DeleteAllFiles(FilePaths.UploadFolder);
                DeleteAllFiles(FilePaths.CleanedFolder);
                DeleteAllFiles(FilePaths.TokenizedFolder);
                DeleteAllFiles(FilePaths.AnalyzerFolder);
                tabControl1.SelectedTab = tabControl1.TabPages[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while restarting the processes: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void DownloadAllBtn_Click(object sender, EventArgs e)
        {
            if (AnalysListBox.Items.Count == 0)
            {
                MessageBox.Show("There are no files available for download.", "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select Folder to Save All Files";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string destinationFolder = folderDialog.SelectedPath;
                    int successCount = 0;
                    int failCount = 0;

                    foreach (var item in AnalysListBox.Items)
                    {
                        string fileName = item.ToString();
                        string sourceFilePath = Path.Combine(FilePaths.AnalyzerFolder, fileName);
                        string destinationFilePath = Path.Combine(destinationFolder, fileName);

                        try
                        {
                            if (File.Exists(sourceFilePath))
                            {
                                File.Copy(sourceFilePath, destinationFilePath, true);
                                successCount++;
                            }
                            else
                            {
                                failCount++;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error saving {fileName}: {ex.Message}", "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    MessageBox.Show($"Download complete!\n\n✔ Success: {successCount}\n❌ Failed: {failCount}", "Download Summary", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
