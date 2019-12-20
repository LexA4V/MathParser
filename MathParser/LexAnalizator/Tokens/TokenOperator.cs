namespace MathParser.Analizator.Tokens
{
    class TokenOperator : Token
    {
        public string Operation { get; }

        public TokenOperator(string operation)
        {
            Operation = operation;
        }
    }
}
