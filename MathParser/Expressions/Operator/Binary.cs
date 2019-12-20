using System;

namespace MathParser.Expressions
{
    class Binary : Operator
    {
        public Binary(string operation, Expression Operand1, Expression Operand2) 
            : base(operation, new Expression[] { Operand1, Operand2 })
        {

        }

        public Binary(string operation) 
            : base(operation, new Expression[2])
        {

        }

        static readonly string[] T = { "+", "-", "*", "/", "%" };
        
        public Expression Operand1
        {
            get => base[0];

            internal set {
                base[0] = value;
            }
        }

        public Expression Operand2
        {
            get => base[1];

            internal set {
                base[1] = value;
            }
        }

        public override Constant Evaluate()
        {
            var c1 = Operand1.Evaluate().Value;
            var c2 = Operand2.Evaluate().Value;

            switch (Operation)
            {
                case "+": return new Constant(c1 + c2);
                case "-": return new Constant(c1 - c2);
                case "*": return new Constant(c1 * c2);
                case "/": return new Constant(c1 / c2);
                default: throw new Exception();
            }
        }

        public override string ToString()
            => $"({Operand1}{Operation}{Operand2})";

        //enum Operators
        //{
        //    Add,
        //    Sub,
        //    Multiply,
        //    Divide
        //}
    }
}
