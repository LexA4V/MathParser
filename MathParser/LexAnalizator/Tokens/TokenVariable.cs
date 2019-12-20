namespace MathParser.Analizator.Tokens
{
    class TokenVariable : Token
    {
        public string Name { get; }

        public TokenVariable(string name)
        {
            Name = name;
        }
    }
}