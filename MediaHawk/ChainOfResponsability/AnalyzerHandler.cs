using MediaHawk.ChainOfResponsability;
using MediaHawk.ChainOfResponsibility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MediaHawk.ChainOfResponsibility
{
    public class AnalyzerHandler : FileProcessorHandler
    {
        public override void Process(List<string> files)
        {
            Directory.CreateDirectory(FilePaths.AnalyzerFolder);

            Dictionary<string, int> globalWordCounts = new Dictionary<string, int>();
            int totalGlobalWords = 0;
            List<string> analyzedFiles = new List<string>();

            foreach (var file in files)
            {
                string tokenizedFilePath = Path.Combine(FilePaths.TokenizedFolder, Path.GetFileNameWithoutExtension(file) + ".csv");
                string analyzedFilePath = Path.Combine(FilePaths.AnalyzerFolder, Path.GetFileNameWithoutExtension(file) + "_analyzed.csv");

                try
                {
                    if (!File.Exists(tokenizedFilePath))
                    {
                        MessageBox.Show($"File not found: {tokenizedFilePath}", "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }

                    File.Copy(tokenizedFilePath, analyzedFilePath, true);

                    // Use the new method
                    var (wordPercentages, fileWordCounts, totalWords) = CalculateWordPercentages(tokenizedFilePath);

                    SaveAnalysis(analyzedFilePath, fileWordCounts, wordPercentages);

                    foreach (var kv in fileWordCounts)
                    {
                        if (globalWordCounts.ContainsKey(kv.Key))
                            globalWordCounts[kv.Key] += kv.Value;
                        else
                            globalWordCounts[kv.Key] = kv.Value;

                        totalGlobalWords += kv.Value;
                    }

                    analyzedFiles.Add(analyzedFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error analyzing file {Path.GetFileName(file)}:\n{ex.Message}",
                        "Analyzer Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

            SaveGlobalAnalysis(FilePaths.TokenizedFolder);

            base.Process(files);
        }


        private (Dictionary<string, double>, Dictionary<string, int>, int) CalculateWordPercentages(string filePath)
        {
            var wordCounts = new Dictionary<string, int>();
            int totalWords = 0;

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(',');
                if (parts.Length == 2 && int.TryParse(parts[1].Trim(), out int count))
                {
                    string word = parts[0].Trim();
                    wordCounts[word] = count;
                    totalWords += count;
                }
            }

            var wordPercentages = wordCounts
                .ToDictionary(kv => kv.Key, kv => (double)kv.Value / totalWords * 100);

            return (wordPercentages, wordCounts, totalWords);
        }
        private void SaveAnalysis(string filePath, Dictionary<string, int> wordCounts, Dictionary<string, double> wordPercentages)
        {
            var lines = wordCounts
                .OrderByDescending(entry => entry.Value)
                .Select(entry => $"{entry.Key},{entry.Value},{wordPercentages[entry.Key]:F2}%")
                .ToList();

            File.WriteAllLines(filePath, new[] { "Word,Count,Percentage" }.Concat(lines));
        }

        private void SaveGlobalAnalysis(string tokenizedFolder)
        {
            string globalAnalysisPath = Path.Combine(FilePaths.AnalyzerFolder, "global_analysis.csv");
            Dictionary<string, int> globalWordCounts = new Dictionary<string, int>();
            int totalGlobalWords = 0;

            // Get all tokenized CSV files
            var tokenizedFiles = Directory.GetFiles(tokenizedFolder, "*.csv");

            // Read each file and update the word counts
            foreach (var file in tokenizedFiles)
            {
                var lines = File.ReadAllLines(file).Skip(1); // Skip the header line
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 2 && int.TryParse(parts[1].Trim(), out int count))
                    {
                        string word = parts[0].Trim();
                        if (globalWordCounts.ContainsKey(word))
                            globalWordCounts[word] += count;
                        else
                            globalWordCounts[word] = count;

                        totalGlobalWords += count;
                    }
                }
            }

            if (totalGlobalWords == 0)
            {
                MessageBox.Show("No words found for global analysis.", "Global Analysis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Calculate percentages and sort
            var globalWordPercentages = globalWordCounts
                .OrderByDescending(entry => entry.Value) // Sort by highest occurrences
                .Select(entry => $"{entry.Key},{entry.Value},{(double)entry.Value / totalGlobalWords * 100:F2}%")
                .ToList();

            // Add headers and write to file
            List<string> header = new List<string> { "Word,Count,Percentage" };
            File.WriteAllLines(globalAnalysisPath, header.Concat(globalWordPercentages));

            MessageBox.Show($"Global analysis completed! File saved at: {globalAnalysisPath}", "Global Analysis", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



    }
}
