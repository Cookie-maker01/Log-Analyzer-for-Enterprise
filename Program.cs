using LogAnalyzer.Services;

var filePath = "log.txt";

var parser = new LogParser();

var logs = parser.Parse(filePath);

var analyzer = new LogAnalyzerService();

analyzer.Analyze(logs);

Console.ReadLine();