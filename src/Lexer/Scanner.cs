public class Scanner(string source)
{
    int _start;
    int _currentPosition;
    int _line = 1;
    public List<Token> Tokens = [];
    
    public void ScanTokens()
    {
        while (!IsAtEnd())
        {
            _start = _currentPosition;
            ScanToken();
        }

        _start = _currentPosition;
        AddToken(TokenType.EOF, string.Empty);
    }

    bool IsAtEnd()
    {
        return _currentPosition >= source.Length;
    }

    void ScanToken()
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
            case '{':
                AddToken(TokenType.LEFT_BRACE, "{");
                break;
            case '}':
                AddToken(TokenType.RIGHT_BRACE, "{");
                break;
            case ',':
                AddToken(TokenType.COMMA, ",");
                break;
            case ';':
                AddToken(TokenType.SEMICOLON, ";");
                break;
            case '.':
                AddToken(TokenType.DOT, ".");
                break;
            case '+':
                AddToken(TokenType.PLUS, "+");
                break;
            case '-':
                AddToken(TokenType.MINUS, "-");
                break;
            case '*':
                AddToken(TokenType.STAR, "*");
                break;
            case '=':
                HandleEqualSign();
                break;
            case '\n':
                _line++;
                break;
            default:
                AddToken(TokenType.ERROR, c.ToString());
                break;
        }
    }

    void HandleEqualSign()
    {
        if (_currentPosition >= source.Length)
        {
            var nextToken = PeakNextToken();
            if (nextToken == '=')
            {
                AddToken(TokenType.EQUAL, nextToken.ToString());
                //_currentPosition++;
                return;
            }
        }
        
        AddToken(TokenType.EQUAL, "=");
    }

    char Advance()
    {
        return source[_currentPosition++];
    }

    char PeakNextToken()
    {
        return source[_currentPosition + 1];
    }

    void AddToken(TokenType tokenType, string literal)
    {
        var text = source.Substring(_start, _currentPosition - _start);
        Tokens.Add(new Token
        {
            Type = tokenType,
            Lexeme = text,
            Literal = literal,
            Line = _line,
        });
    }
}
