using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Expressions
{
    class Unary : Operator
    {
        public Unary(string operation, Expression operand) : base(operation, new Expression[] { operand })
        {

        }

        public Unary(string operation) : base(operation, new Expression[1])
        {

        }
        
        Expression Operand1 { get => base[0]; }


        public override string ToString()
        {
            return string.Format("{0}({1})", Operation, Operand1);
        }

        public override Constant Evaluate()
        {
            throw new NotImplementedException();
        }
    }
}
