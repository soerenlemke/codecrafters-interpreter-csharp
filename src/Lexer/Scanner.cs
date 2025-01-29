public class Scanner(string source)
{
    int _start;
    int _currentPosition;
    int _line = 1;
    public List<Token> Tokens = [];
    bool _comment;
    string sourceTrimmed = source.Trim();
    
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
        return _currentPosition >= sourceTrimmed.Length;
    }

    void ScanToken()
    {
        if (_comment)
        {
            var commentChar = Advance();
            if (commentChar == '\n')
            {
                _comment = false;
            }
            return;
        }

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
            case '!':
                HandleBangSign();
                break;
            case '<':
                HandleLessSign();
                break;
            case '>':
                HandleGreaterSign();
                break;
            case '/':
                HandleSlashSign();
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
        if (_currentPosition < sourceTrimmed.Length && sourceTrimmed[_currentPosition] == '=')
        {
            _currentPosition++;
            AddToken(TokenType.EQUAL_EQUAL, "==");
        }
        else
        {
            AddToken(TokenType.EQUAL, "=");
        }
    }

    void HandleBangSign()
    {
        if (_currentPosition < sourceTrimmed.Length && sourceTrimmed[_currentPosition] == '=')
        {
            _currentPosition++;
            AddToken(TokenType.BANG_EQUAL, "!=");
        }
        else
        {
            AddToken(TokenType.BANG, "!");
        }
    }

    void HandleLessSign()
    {
        if (_currentPosition < sourceTrimmed.Length && sourceTrimmed[_currentPosition] == '=')
        {
            _currentPosition++;
            AddToken(TokenType.LESS_EQUAL, "<=");
        }
        else
        {
            AddToken(TokenType.LESS, "<");
        }
    }
    
    void HandleGreaterSign()
    {
        if (_currentPosition < sourceTrimmed.Length && sourceTrimmed[_currentPosition] == '=')
        {
            _currentPosition++;
            AddToken(TokenType.GREATER_EQUAL, ">=");
        }
        else
        {
            AddToken(TokenType.GREATER, ">");
        }
    }

    void HandleSlashSign()
    {
        if (_currentPosition < sourceTrimmed.Length && sourceTrimmed[_currentPosition] == '/')
        {
            _comment = true;
        }
        else
        {
            AddToken(TokenType.SLASH, "/");
        }
    }
    
    char Advance()
    {
        return sourceTrimmed[_currentPosition++];
    }
    
    void AddToken(TokenType tokenType, string literal)
    {
        var text = sourceTrimmed.Substring(_start, _currentPosition - _start);
        Tokens.Add(new Token
        {
            Type = tokenType,
            Lexeme = text,
            Literal = literal,
            Line = _line,
        });
    }
}
