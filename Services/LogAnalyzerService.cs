using LogAnalyzer.Models;

namespace LogAnalyzer.Services
{
    public class LogAnalyzerService
    {
        public void Analyze(List<LogEntry> logs)
        {
            var infoCount = logs.Count(x => x.Level == "INFO");
            var warningCount = logs.Count(x => x.Level == "WARNING");
            var errorCount = logs.Count(x => x.Level == "ERROR");

            Console.WriteLine("========== SUMMARY ==========");
            Console.WriteLine($"INFO: {infoCount}");
            Console.WriteLine($"WARNING: {warningCount}");
            Console.WriteLine($"ERROR: {errorCount}");

            Console.WriteLine("\n===== ERROR TREND =====");

            var trend = logs
                .Where(x => x.Level == "ERROR")
                .GroupBy(x => x.Timestamp.ToString("HH:mm"))
                .Select(g => new { Time = g.Key, Count = g.Count() });

            foreach (var t in trend)
            {
                Console.WriteLine($"{t.Time} ¡ú {t.Count}");
            }
        }

        //Time filter
        public List<LogEntry> FilterByTime(List<LogEntry> logs, DateTime from)
        {
            return logs.Where(x => x.Timestamp >= from).ToList();
        }
    }
}