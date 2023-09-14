using System;
namespace InterpreterArithmeticOperations
{
    /// <summary>
    /// Provides the functionality to evaluate simple arithmetic expressions provided as strings.
    /// </summary>
    public class Interpreter
    {
        /// <summary>
        /// Evaluates the arithmetic expression provided as a string.
        /// </summary>
        /// <param name="expression">the arithmetic expression to be evaluated.</param>
        public static int Evaluate( string expression )
        {
            Stack<Expression> stack = new();

            string[] tokens = expression.Split( ' ' );

            foreach (string token in tokens)
            {
                if (int.TryParse( token , out int number ))
                {
                    stack.Push( new NumberExpression( number ) );
                }
                else if (token == "+")
                {
                    Expression right = stack.Pop();
                    Expression left = stack.Pop();
                    stack.Push( new AddExpression( left , right ) );
                }
                else if (token == "-")
                {
                    Expression right = stack.Pop();
                    Expression left = stack.Pop();
                    stack.Push( new SubtractExpression( left , right ) );
                }
                else if (token == "*")
                {
                    Expression right = stack.Pop();
                    Expression left = stack.Pop();
                    stack.Push( new MultiplyExpression( left , right ) );
                }
                else if (token == "/")
                {
                    Expression right = stack.Pop();
                    Expression left = stack.Pop();
                    stack.Push( new DivideExpression( left , right ) );
                }
            }

            return stack.Pop().Interpret();
        }
    }
}

