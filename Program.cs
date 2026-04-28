using LogAnalyzer.Services;

var filePath = Path.Combine(AppContext.BaseDirectory, "log.txt");

//1. parse

var parser = new LogParser();

var logs = parser.Parse(filePath);

//2. filter

var analyzer = new LogAnalyzerService();
logs = analyzer.FilterByTime(logs, DateTime.Nwo.AddHours(-1));

//3. analyze

analyzer.Analyze(logs);

//4. generate JSON report
var reportService = new LogReportService();
reportService.GenerateReport(logs);

Console.ReadLine();