using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaHawk.ChainOfResponsability
{
    public class TokenizerHandler : FileProcessorHandler
    {
        private readonly string tokenizedFolder = "TokenizedFiles";

        public TokenizerHandler()
        {
            Directory.CreateDirectory(tokenizedFolder);
        }

        public override void Process(List<string> files)
        {
            foreach (var file in files)
            {
                string cleanedFilePath = Path.Combine(FilePaths.CleanedFolder, Path.GetFileName(file));
                string tokenizedFilePath = Path.Combine(FilePaths.TokenizedFolder, Path.GetFileNameWithoutExtension(file)+ ".csv");

                try
                {
                    if (!File.Exists(cleanedFilePath))
                    {
                        MessageBox.Show($"File not found: {cleanedFilePath}",
                            "Processing 1 Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        continue;

                    }

                    string text = File.ReadAllText(cleanedFilePath);
                    var tokens = TokenizeText(text);
                    SaveTokenizedData(tokenizedFilePath, tokens);
                    // Add to analys
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error tokenizing file {Path.GetFileName(file)}:\n{ex.Message}",
                        "Proccessing Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

            base.Process(files);
        }
        private Dictionary<string, int> TokenizeText(string text)
        {
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            //Regex to split words, removing puntuation and convert to lower case
            //string[] words = Regex.Split(text.ToLower(), @"\W+");
            string[] words = Regex.Split(text.ToLower(), @"\s+|[^a-zA-Z0-9']+");

            foreach (string word in words)
            {
                string cleanedWord = word.Trim('\'');
                if (!string.IsNullOrWhiteSpace(word))
                {
                    if (wordCounts.ContainsKey(word))
                        wordCounts[word]++;
                    else
                        wordCounts[word] = 1;
                }
            }

            return wordCounts;

        }

        private void SaveTokenizedData(string filePath, Dictionary<string, int> wordCounts)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Word,Count"); // CSV Header
                foreach (var kv in wordCounts.OrderByDescending(kv => kv.Value))
                {
                    writer.WriteLine($"{kv.Key},{kv.Value}");
                }
            }

        }
    }
}
