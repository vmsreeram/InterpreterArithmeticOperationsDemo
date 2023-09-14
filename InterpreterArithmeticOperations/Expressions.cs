using System;
namespace InterpreterArithmeticOperations
{
    /// <summary>
    /// Abstract base class with an abstract "Interpret()" method for expression interpretation.
    /// </summary>
    public abstract class Expression
    {
        public abstract int Interpret();
    }

    /// <summary>
    /// Terminal expression to interpret and return a stored integer value, which is initialized during construction
    /// </summary>
    public class NumberExpression : Expression
    {
        private readonly int _number;

        public NumberExpression( int number )
        {
            _number = number;
        }

        public override int Interpret()
        {
            return _number;
        }
    }

    /// <summary>
    /// Non-terminal expression to interpret and return the result of adding the interpretations of its left and right sub-expressions
    /// </summary>
    public class AddExpression : Expression
    {
        private readonly Expression _left;
        private readonly Expression _right;

        public AddExpression( Expression left , Expression right )
        {
            _left = left;
            _right = right;
        }

        public override int Interpret()
        {
            return _left.Interpret() + _right.Interpret();
        }
    }

    /// <summary>
    /// Non-terminal expression to interpret and return the result of subtracting the interpretations of its left and right sub-expressions
    /// </summary>
    public class SubtractExpression : Expression
    {
        private readonly Expression _left;
        private readonly Expression _right;

        public SubtractExpression( Expression left , Expression right )
        {
            _left = left;
            _right = right;
        }

        public override int Interpret()
        {
            return _left.Interpret() - _right.Interpret();
        }
    }

    /// <summary>
    /// Non-terminal expression to interpret and return the result of multiplying the interpretations of its left and right sub-expressions
    /// </summary>
    public class MultiplyExpression : Expression
    {
        private readonly Expression _left;
        private readonly Expression _right;

        public MultiplyExpression( Expression left , Expression right )
        {
            _left = left;
            _right = right;
        }

        public override int Interpret()
        {
            return _left.Interpret() * _right.Interpret();
        }
    }

    /// <summary>
    /// Non-terminal expression to interpret and return the result of dividing the interpretations of its left and right sub-expressions
    /// </summary>
    public class DivideExpression : Expression
    {
        private readonly Expression _left;
        private readonly Expression _right;

        public DivideExpression( Expression left , Expression right )
        {
            _left = left;
            _right = right;
        }

        public override int Interpret()
        {
            int interpretedRight = _right.Interpret();
            int interpretedLeft = _left.Interpret();

            if (interpretedRight != 0)
            {
                return interpretedLeft / interpretedRight;
            }
            else
            {
                throw new DivideByZeroException( "Division by zero is not allowed." );
            }
        }
    }
}

