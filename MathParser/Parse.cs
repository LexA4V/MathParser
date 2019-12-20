using System;
using System.Collections.Generic;

using MathParser.Expressions;
using MathParser.Analizator;
using MathParser.Analizator.Tokens;

namespace MathParser
{
    public class Parse
    {
        public static Expression parse(string source)
        {
            const int WAIT_OPERAND = 1;
            const int WAIT_OPERATOR = 2;

            Stack<Expression> operands = new Stack<Expression>();
            Stack<TokenOperator> operators = new Stack<TokenOperator>();

            int wait_flag = WAIT_OPERAND;
            try
            {
                LexAnalizator analizer = new LexAnalizator(source);
                foreach (Token lex in analizer)
                { 
                    if (wait_flag == WAIT_OPERAND)
                    {
                        var type = lex.GetType();
                        if (lex is TokenNumber number)
                        {
                            operands.Push(new Constant(number.Value));
                            wait_flag = WAIT_OPERATOR;
                        }
                        else if (lex is TokenVariable variable)
                        {
                            operands.Push(new Variable(variable.Name));
                            wait_flag = WAIT_OPERATOR;
                        }
                        else if (lex is TokenPair pair && pair.IsLeft)
                        {
                            operators.Push(pair);
                        }
                        else
                            throw new ParseException("Unknown lexema", 0);
                    }
                    else
                    {
                        if (lex is TokenPair pair && !pair.IsLeft)
                        {
                            doOperators(operands, operators, 1);
                            TokenOperator op = operators.Peek();
                            operators.Pop();
                        }
                        else if (lex is TokenOperator _operator)
                        {
                            doOperators(operands, operators, Priority(_operator));
                            operators.Push(_operator);
                            wait_flag = WAIT_OPERAND;
                        }
                        else
                            throw new ParseException("Unknown lexema", 0);
                    }
                }
            
                doOperators(operands, operators, 0);

                Expression result = operands.Pop();

                return result;

            }
            catch (StackOverflowException)
            {
                throw new ParseException("Expression structure error", 0);
            }
        }

        private static int Priority(TokenOperator @operator)
        {
            switch (@operator.Operation)
            {
                case "-":
                case "+": return 1;

                case "*":
                case "/":
                case "%": return 3;

                default: return 0;
            }
        }

        private static void doOperator(Stack<Expression> operands, Stack<TokenOperator> operators)
        {
            Expression op2 = operands.Pop();
            Expression op1 = operands.Pop();

            string opSign = operators.Pop().Operation;
            operands.Push(new Binary(opSign, op1, op2));
        }

        private static void doOperators(Stack<Expression> operands, Stack<TokenOperator> operators, int minPrio)
        {
            while (operators.Count > 0 && Priority(operators.Peek()) >= minPrio)
            {
                doOperator(operands, operators);
            }
        }
    }
}
