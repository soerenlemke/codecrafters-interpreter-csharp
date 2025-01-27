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
                AddToken(TokenType.LeftParen, '(');
                break;
            case ')':
                AddToken(TokenType.RightParen, ')');
                break;
            case '\n':
                _line++;
                break;
            default:
                break;
        }
    }

    char Advance()
    {
        return source[_currentPosition++];
    }

    void AddToken(TokenType tokenType, char literal)
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
