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
                var parts = line.Split(' ', 2); // depart Level + Message

                if(parts.Length == 2)
                {
                    logs.Add(new LogEntry
                    {
                        Level = parts[0],
                        Message = parts[1]
                    });
                }
            }

            return logs;
        }
    }
}
