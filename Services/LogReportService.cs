using System.Text.Json;
using LogAnalyzer.Models;

namespace LogAnalyzer.Services
{
    public class LogReportService
    {
        public void GenerateReport(List<logEntry> logs)
        {
            var report = new
            {
                infoCount = logs.Count(x => x.Level == "INFO"),
                warningCount = logs.Count(x => x.Level == "WARNING"),
                errorCount = logs.Count(x => x.Level == "ERROR"),
                generatedAt = DateTime.Now
            };

            var json = JsonSerializer.Serialize(report, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            var path = path.Combine("Reports", "report.json");

            Directory.CreateDirectory("Reports");

            File.WriteAllText(path, json)

            Console.WriteLine("\nJSON report generated at: " + path);
        }
    }
}