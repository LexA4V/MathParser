using System;

namespace MathParser.Expressions
{
    class Variable : Expression
    {
        public string Name { get; }

        public Variable(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public override Constant Evaluate()
        {
            throw new NotImplementedException();
        }
    }
}
