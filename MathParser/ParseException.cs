using System;

namespace MathParser
{
    class ParseException : Exception
    {
        public int Position { get; }

        public ParseException(string reason, int position) : base(reason)
        {
            this.Position = position;
        }
    }
}
