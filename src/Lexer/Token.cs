public class Token
{
    public TokenType Type { get; set; }
    public string? Lexeme { get; set; }
    public string? Literal { get; set; }
    public int Line { get; set; }

    public override string ToString()
    {
        if (Type == TokenType.ERROR)
        {
            return $"[line {Line}] " + "Error: Unexpected character: " + Lexeme;
        }
        return Type + " " + Lexeme + " " + "null";
    }
}
