using LogAnalyzer.Models;

namespace LogAnalyzer.Services
{
    public class LogParser
    {
        public List<LogEntry> Parse(string filePath)
        {
            var logs = new List<LogEntry>();

            var lines = File.ReadAllLines(filePath);

            foreach(var line in lines)
            {
                var parts = line.Split(' ', 4);

                if (parts.Length < 4) continue;

                var timestamp = DateTime.Parse($"{parts[0]} {parts[1]}");
                var level = parts[2];
                var message = parts[3];

                logs.Add(new LogEntry
                {
                    Timestamp = timestamp,
                    Level = level,
                    Message = message
                });
            }

            return logs;
            }

            return logs;
        }
    }
}
