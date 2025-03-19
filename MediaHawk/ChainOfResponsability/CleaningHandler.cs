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
        private readonly string processedFolder = "ProcessedFiles";
        private readonly string uploadFolder = "UploadedFiles";

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
            "after", "above", "below", "while", "so", "because", "mhm"
        };

        public override void Process(List<string> files)
        {
            //Ensure the processed files folder exists
            Directory.CreateDirectory(processedFolder);
            List<string> cleanedFiles = new List<string>();

            foreach (var file in files)
            {
                //MessageBox.Show(Path.GetFileName(file));
                //Console.WriteLine("Cleaning Process starter");
                //MessageBox.Show($"Cleaning process started for: {file}");
                try
                {

                    //read the file content
                    string content = File.ReadAllText(file, Encoding.UTF8);

                    //Clean the text
                    string cleanedContent = CleanText(content);

                    //Generate new file path
                    string cleanedFileName = Path.Combine(processedFolder, Path.GetFileName(file));

                    //Save the cleaned text in the processed forlder
                    File.WriteAllText(cleanedFileName, cleanedContent, Encoding.UTF8);
                    //MessageBox.Show($"Cleaning completed. Cleaned file saved as: {cleanedFileName}");
                    cleanedFiles.Add(cleanedFileName);

                    File.Delete(file);


                }
            
                catch (Exception ex)
                {
                MessageBox.Show($"Error cleaning {file}: {ex.Message}");
                }
            }
            base.Process(files); //Call the next handler
        }
        private string CleanText(string text)
        {
            text = text.ToLower();
            text = Regex.Replace(text, @"\b\d+\b", ""); //remove numbers
            text = Regex.Replace(text, @"[^\w\s']", ""); //remove puntuation
            text = Regex.Replace(text, @"\s+", " ").Trim(); //normalise spaces

            //remove stopwords.
            var words = text.Split(' ').Where(word => !string.IsNullOrWhiteSpace(word) && !stopwords.Contains(word)).ToList();
            return string.Join(" ", words);
        }
    }
}
