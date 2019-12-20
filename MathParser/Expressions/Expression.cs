namespace MathParser.Expressions
{
    public abstract class Expression
    {
        public abstract Constant Evaluate(); //visitor
    }
}
