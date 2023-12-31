﻿/******************************************************************************
 * Filename    = Expressions.cs
 *
 * Author      = VM Sreeram
 *
 * Product     = InterpreterArithmeticOperationsDemo
 * 
 * Project     = InterpreterArithmeticOperations
 *
 * Description = Defines a set of classes for implementing an interpreter pattern to perform simple arithmetic operations on expressions.
 *****************************************************************************/

namespace InterpreterArithmeticOperations
{

    /// <summary>
    /// Terminal expression to interpret and return a stored integer value, which is initialized during construction
    /// </summary>
    public class NumberExpression : IExpressionEvaluater
    {
        private readonly int _number;

        public NumberExpression(int number)
        {
            _number = number;
        }

        public int Interpret()
        {
            return _number;
        }
    }

    /// <summary>
    /// Non-terminal expression to interpret and return the result of adding the interpretations of its left and right sub-expressions
    /// </summary>
    public class AddExpression : IExpressionEvaluater
    {
        private readonly IExpressionEvaluater _left;
        private readonly IExpressionEvaluater _right;

        public AddExpression(IExpressionEvaluater left, IExpressionEvaluater right)
        {
            _left = left;
            _right = right;
        }

        public int Interpret()
        {
            return _left.Interpret() + _right.Interpret();
        }
    }

    /// <summary>
    /// Non-terminal expression to interpret and return the result of subtracting the interpretations of its left and right sub-expressions
    /// </summary>
    public class SubtractExpression : IExpressionEvaluater
    {
        private readonly IExpressionEvaluater _left;
        private readonly IExpressionEvaluater _right;

        public SubtractExpression(IExpressionEvaluater left, IExpressionEvaluater right)
        {
            _left = left;
            _right = right;
        }

        public int Interpret()
        {
            return _left.Interpret() - _right.Interpret();
        }
    }

    /// <summary>
    /// Non-terminal expression to interpret and return the result of multiplying the interpretations of its left and right sub-expressions
    /// </summary>
    public class MultiplyExpression : IExpressionEvaluater
    {
        private readonly IExpressionEvaluater _left;
        private readonly IExpressionEvaluater _right;

        public MultiplyExpression(IExpressionEvaluater left, IExpressionEvaluater right)
        {
            _left = left;
            _right = right;
        }

        public int Interpret()
        {
            return _left.Interpret() * _right.Interpret();
        }
    }

    /// <summary>
    /// Non-terminal expression to interpret and return the result of dividing the interpretations of its left and right sub-expressions
    /// </summary>
    /// <exception cref="DivideByZeroException">
    /// Raised when division by zero is attemted.
    /// </exception>
    public class DivideExpression : IExpressionEvaluater
    {
        private readonly IExpressionEvaluater _left;
        private readonly IExpressionEvaluater _right;

        public DivideExpression(IExpressionEvaluater left, IExpressionEvaluater right)
        {
            _left = left;
            _right = right;
        }

        public int Interpret()
        {
            int interpretedRight = _right.Interpret();
            int interpretedLeft = _left.Interpret();

            return interpretedRight != 0
                ? interpretedLeft / interpretedRight
                : throw new DivideByZeroException("Division by zero is not allowed.");
        }
    }
}

