using LogAnalyzer.Models;

namespace LogAnalyzer.Services
{
    public class LogAnalyzerService
    {
        public void Analyze(List<LogEntry> logs)
        {
            int infoCount = 0;
            int warningCount = 0;
            int errorCount = 0;

            foreach (var log in logs)
            {
                switch(log.Level)
                {
                    case "INFO":
                        infoCount++;
                        break;

                    case "WARNING":
                        warningCount++;
                        break;

                    case "ERROR":
                        errorCount++;
                        Console.WriteLine("ERROR:" + log.Message);
                        break;
                }
            }

            Console.WriteLine("========== RESULT ==========");
            Console.WriteLine($"INFO: {infoCount}");
            Console.WriteLine($"WARNING: {warningCount}");
            Console.WriteLine($"ERROR: {errorCount}");
        }
    }
}