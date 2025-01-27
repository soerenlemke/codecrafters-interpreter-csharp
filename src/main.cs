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

scanner.ScanTokens();

foreach (var token in scanner.Tokens)
{
    Console.WriteLine(token);
}