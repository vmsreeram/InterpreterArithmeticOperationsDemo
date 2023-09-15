/******************************************************************************
 * Filename    = IExpression.cs
 *
 * Author      = VM Sreeram
 *
 * Product     = InterpreterArithmeticOperationsDemo
 * 
 * Project     = InterpreterArithmeticOperations
 *
 * Description = Interface for expression.
 *****************************************************************************/

namespace InterpreterArithmeticOperations
{
    /// <summary>
    /// Exposes an interface for expression interpretation.
    /// </summary>
    public interface IExpression
    {
        public int Interpret();
    }
}

