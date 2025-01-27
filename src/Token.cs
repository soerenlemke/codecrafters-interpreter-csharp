public class Token
{
    public TokenType Type { get; set; }
    public string? Lexeme { get; set; }
    public object? Literal { get; set; }
    public int Line { get; set; }

    public override string ToString()
    {
        return Type + " " + Lexeme + " " + "null";
    }
}
