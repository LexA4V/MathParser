namespace MathParser.Expressions
{
    public class Constant : Expression
    {
        public double Value { get; }

        public Constant(double value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override Constant Evaluate()
        {
            return this;
        }
    }
}
