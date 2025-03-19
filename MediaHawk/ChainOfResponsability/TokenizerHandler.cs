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
                try
                {
                    string text = File.ReadAllText(file);
                    var tokens = TokenizeText(text);

                    string tokenizedFilePath = Path.Combine(tokenizedFolder, Path.GetFileName(file));
                    SaveTokenizedData(tokenizedFilePath, tokens);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error tokenising file {Path.GetFileName(file)}:\n{ex.Message}",
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
            string[] words = Regex.Split(text.ToLower(), @"\W+");

            foreach (string word in words)
            {
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
            List<string> lines = wordCounts.Select(kv => $"{kv.Key}: {kv.Value}").ToList();
            File.WriteAllLines(filePath, lines);
        }
    }
}
