if (args.Length < 2)
{
    Console.Error.WriteLine("Usage: ./your_program.sh tokenize <filename>");
    Environment.Exit(1);
}

string command = args[0];
string filename = args[1];

if (command != "tokenize")
{
    Console.Error.WriteLine($"Unknown command: {command}");
    Environment.Exit(1);
}

var fileContents = File.ReadAllText(filename);
var scanner = new Scanner(fileContents);

foreach (var c in fileContents)
{
    scanner.ScanToken();
}

foreach (var token in scanner.Tokens)
{
    Console.WriteLine(token);
}