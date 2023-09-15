/******************************************************************************
 * Filename    = Expressions.cs
 *
 * Author      = VM Sreeram
 *
 * Product     = InterpreterArithmeticOperationsDemo
 * 
 * Project     = InterpreterArithmeticOperations
 *
 * Description = An arithmetic expression interpreter for evaluating simple arithmetic expressions.
 *****************************************************************************/

namespace InterpreterArithmeticOperations
{
    /// <summary>
    /// Provides the functionality to evaluate simple arithmetic expressions provided as strings.
    /// </summary>
    public static class Interpreter
    {
        /// <summary>
        /// Evaluates the arithmetic expression provided as a string.
        /// </summary>
        /// <param name="expression">The arithmetic expression to be evaluated.</param>
        public static int Evaluate(string expression)
        {
            Stack<IExpression> stack = new();

            string[] tokens = expression.Split(' ');
            foreach (string token in tokens)
            {
                if (int.TryParse(token, out int number))
                {
                    stack.Push(new NumberExpression(number));
                    continue;
                }

                if(stack.Count<2)               // Because all supported operators are binary operators
                {
                    throw new Exception("Invalid input string. Stack underflow.");
                }

                IExpression right = stack.Pop();
                IExpression left = stack.Pop();

                if (token == "+")
                {
                    stack.Push(new AddExpression(left, right));
                }
                else if (token == "-")
                {
                    stack.Push(new SubtractExpression(left, right));
                }
                else if (token == "*")
                {
                    stack.Push(new MultiplyExpression(left, right));
                }
                else if (token == "/")
                {
                    stack.Push(new DivideExpression(left, right));
                }
                else
                {
                    throw new Exception("Invalid input string. Invalid operator found.");
                }
            }

            if (stack.Count() != 1)
            {
                throw new Exception("Invalid input string. Stack overflow.");
            }

            return stack.Pop().Interpret();
        }
    }
}

