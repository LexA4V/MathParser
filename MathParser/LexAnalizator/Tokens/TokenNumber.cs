namespace MathParser.Analizator.Tokens
{
    class TokenNumber : Token
    {
        public double Value { get; }

        public TokenNumber(string value)
        {
            Value = double.Parse(value);
        }
    }
}
