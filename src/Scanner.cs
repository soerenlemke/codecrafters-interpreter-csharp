public class Scanner(string source)
{
    int _start = 0;
    int _currentPosition = 0;
    int _line = 0;
    public List<Token> Tokens = [];
    
    public void ScanToken()
    {
        var c = Advance();
        switch (c)
        {
            case '(':
                AddToken(TokenType.LEFT_PAREN, "(");
                break;
            case ')':
                AddToken(TokenType.RIGHT_PAREN, ")");
                break;
            case '\n':
                _line++;
                break;
            case '\0':
                AddToken(TokenType.EOF, string.Empty);
                return;
            default:
                break;
        }
    }

    char Advance()
    {
        return source[_currentPosition++];
    }

    void AddToken(TokenType tokenType, string literal)
    {
        var text = source.Substring(_start, _currentPosition);
        Tokens.Add(new Token
        {
            Type = tokenType,
            Lexeme = text,
            Literal = literal,
            Line = _line,
        });
    }
}
