using System;
using System.IO;
using System.Threading;
using LogAnalyzer.Models;

namespace LogAnalyzer.Services
{
    public class LogMonitorService
    {
        private readonly string _filePath;
        private long _lastPosition = 0;

        public LogMonitorService(string filePath)
        {
            _filePath = filePath;
        }

        public void Start()
        {
            Console.WriteLine("Log Monitor Started...");

            while(true)
            {
                try
                {
                    if(!File.Exists(_filePath))
                    {
                        Console.WriteLine("log.txt not found");
                        Thread.Sleep(2000);
                        continue;
                    }

                    using var stream = new FileStream(_filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    stream.Seek(_lastPosition, SeekOrigin.Begin);

                    using var reader = new StreamReader(stream);

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        ProcessLine(line);
                    }

                    _lastPosition = stream.Position;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("ERROR:" + ex.Message);
                }

                Thread.Sleep(1000);
            }
        }

        private void ProcessLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return;

            Console.WriteLine($"NEW LOG: {line}");

            if(line.Contains("ERROR"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ALERT: ERROR detected!");
                Console.ResetColor();
            }
        }
    }
}