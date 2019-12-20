using System;

namespace MathParser.Expressions
{
    abstract class Operator : Expression
    {
        protected Expression[] operands;

        public string Operation { get; }

        protected Expression this[int index]
        {
            get {
                if (operands == null)
                    throw new Exception("operators == null");
                if (index < -1 || index >= operands.Length)
                    throw new Exception("number < -1 || number > (int)Type");

                return operands[index];
            }
            set
            {
                if (operands == null) throw new Exception("operators == null");
                if (index < -1 || index > 5) throw new Exception("number < -1 || number > (int)Type");

                operands[index] = value;
            } 
        }

        protected Operator(string operation, Expression[] operands)
        {
            this.Operation = operation;
            this.operands = operands;
        }
    }
}
