using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

using MathParser.Analizator.Tokens;

namespace MathParser.Analizator
{
    class LexAnalizator : IEnumerable<Token>
    {
        List<Token> tokens;

        public LexAnalizator(string source)
        {
            tokens = new List<Token>(source.Length);

            source = Regex.Replace(source, @"\s+", "");

            const string Operator = "Operator";
            const string Number = "Number";
            const string Pair = "Pair";
            const string Variable = "Variable";

            string opV = @"[\+\-*\/]";
            string numV = @"\d+(?:\.\d+)?";
            string pairV = @"[()]";
            string varV = @"[A-ZА-ЯЁ]\w*";

            var matchs = Regex.Matches(source, 
                $@"(?:(?<{Operator}>{opV})|(?<{Number}>{numV})|(?<{Pair}>{pairV})|(?<{Variable}>{varV}))", RegexOptions.IgnoreCase);

            if (matchs.Cast<Match>().Sum(m => m.Length) != source.Length)
                throw new ArgumentException("Были пропущены неизвестные символы. Выражение неккоректно!");
            
            foreach (Match m in matchs)
            {
                if (m.Groups[Operator].Success)
                {
                    tokens.Add(new TokenOperator(m.Value));
                }
                else if (m.Groups[Number].Success)
                {
                    tokens.Add(new TokenNumber(m.Value));
                }
                else if (m.Groups[Pair].Success)
                {
                    tokens.Add(new TokenPair(m.Value));
                }
                else if (m.Groups[Variable].Success)
                {
                    tokens.Add(new TokenVariable(m.Value));
                }
                else
                    throw new ParseException(m.Value, m.Index);
            }
        }

        #region IEnumerable<Token>

        public IEnumerator<Token> GetEnumerator()
        {
            return ((IEnumerable<Token>)tokens).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Token>)tokens).GetEnumerator();
        }

        #endregion
    }
}
