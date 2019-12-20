namespace MathParser.Analizator.Tokens
{
    class TokenPair : TokenOperator
    {
        public TokenPair(string operation) : base(operation)
        {
            IsLeft = Operation == "(";
        }

        public bool IsLeft { get; }
    }
}
