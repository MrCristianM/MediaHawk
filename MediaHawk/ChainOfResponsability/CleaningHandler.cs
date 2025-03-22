using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.CodeDom;

namespace MediaHawk.ChainOfResponsability
{
    public class CleaningHandler : FileProcessorHandler
    {

        //list of common words to remove
        private readonly HashSet<string> stopwords = new HashSet<string>
        {
             "a", "an", "the", "and", "or", "but", "if", "then", "this", "that",
            "those", "these", "is", "was", "were", "be", "been", "being",
            "he", "she", "it", "they", "we", "you", "i", "me", "my", "mine",
            "your", "yours", "his", "her", "its", "their", "theirs",
            "of", "in", "on", "at", "by", "with", "about", "against",
            "for", "to", "from", "up", "down", "out", "over", "under",
            "as", "into", "between", "through", "during", "before",
            "after", "above", "below", "while", "so", "because", "mhm", "it's"
        };

        public override void Process(List<string> files)
        {
            foreach (var file in files)
            {

                string sourcePath = Path.Combine(FilePaths.UploadFolder, Path.GetFileName(file));
                string cleanedFilePath = Path.Combine(FilePaths.CleanedFolder, Path.GetFileName(file));

                if (!File.Exists(sourcePath))
                {
                    MessageBox.Show($"File not found: {sourcePath}", "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    continue;
                }
                try
                {
                    string content = File.ReadAllText(sourcePath);
                    string cleanedContent = CleanText(content);
                    File.WriteAllText(cleanedFilePath, cleanedContent);
                    //Delete the original uploaded file after cleaning
                    File.Delete(sourcePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error cleaning file: {Path.GetFileName(file)}", "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error); 
                }
            }
            base.Process(files); //Call the next handler
        }
        private string CleanText(string text)
        {
            text = text.ToLower();
            text = Regex.Replace(text, @"\b\d+\b", ""); //remove numbers
            text = Regex.Replace(text, @"(?<!\w)['’](?!\w)|(?<!\w)-|-(?!\w)|[^\w\s'-]", ""); //remove puntuation
            text = Regex.Replace(text, @"\s+", " ").Trim(); //normalise spaces

            //remove stopwords.
            var words = text.Split(' ').Where(word => !string.IsNullOrWhiteSpace(word) && !stopwords.Contains(word)).ToList();
            return string.Join(" ", words);
        }
    }
}
