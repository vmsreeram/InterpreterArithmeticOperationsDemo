/******************************************************************************
 * Filename    = InterpreterUnitTest.cs
 *
 * Author      = VM Sreeram
 *
 * Product     = InterpreterArithmeticOperationsDemo
 * 
 * Project     = UnitTests
 *
 * Description = Unit tests for the interpreter pattern demo.
 *****************************************************************************/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterpreterArithmeticOperations;
namespace UnitTests
{
    /// <summary>
    /// Unit tests for the interpreter design pattern demo.
    /// </summary>
    [TestClass]
    public class InterpreterUnitTest
    {
        /// <summary>
        /// Tests expression without any operation.
        /// </summary>
        [TestMethod]
        public void TestNumber()
        {
            string expression = "-99";
            int result = Interpreter.Evaluate(expression);

            Assert.AreEqual(-99, result);
        }

        /// <summary>
        /// Tests addition operation.
        /// </summary>
        [TestMethod]
        public void TestAddition()
        {
            string expression = "3 7 +";
            int result = Interpreter.Evaluate(expression);

            Assert.AreEqual(10, result);
        }

        /// <summary>
        /// Tests subtraction operation.
        /// </summary>
        [TestMethod]
        public void TestSubtraction()
        {
            string expression = "625 1624 -";
            int result = Interpreter.Evaluate(expression);

            Assert.AreEqual(-999, result);
        }

        /// <summary>
        /// Tests multiplication operation.
        /// </summary>
        [TestMethod]
        public void TestMultiplication()
        {
            string expression = "4356 35 *";
            int result = Interpreter.Evaluate(expression);

            Assert.AreEqual(152460, result);
        }

        /// <summary>
        /// Tests division operation.
        /// </summary>
        [TestMethod]
        public void TestDivision()
        {
            string expression = "6565 1234 /";
            int result = Interpreter.Evaluate(expression);

            Assert.AreEqual(5, result);
        }

        /// <summary>
        /// Tests division by zero.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestDivisionByZero()
        {
            string expression = "324 4 4 - /";
            _ = Interpreter.Evaluate(expression);

            // If it gets to this line, no exception was thrown.
            Assert.Fail("Divide by zero exception was not raised.");
        }

        /// <summary>
        /// Tests a bigger multi-level expression.
        /// </summary>
        [TestMethod]
        public void TestMultilevelExpression()
        {
            string expression = "124 247 - 1256 2312 / 8237 * + 454 *";
            int result = Interpreter.Evaluate(expression);

            Assert.AreEqual(-55842, result);
        }

        /// <summary>
        /// Tests an expression with invalid operator.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestInvalidOperatorExpression()
        {
            string expression = "124 247 - 1256 2312 / 8237 * ^ 454 *";
            _ = Interpreter.Evaluate(expression);

            // If it gets to this line, no exception was thrown.
            Assert.Fail("Invalid expression did not throw exception.");
        }

        /// <summary>
        /// Tests an invlid expression with stack overflow.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestInvalidExpressionStackOverflow()
        {
            string expression = "2 2 3 *";
            _ = Interpreter.Evaluate(expression);

            // If it gets to this line, no exception was thrown.
            Assert.Fail("Invalid expression did not throw exception.");
        }

        /// <summary>
        /// Tests another invlid expression with stack underflow.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestInvalidExpressionStackUnderflow()
        {
            string expression = "2 /";
            _ = Interpreter.Evaluate(expression);

            // If it gets to this line, no exception was thrown.
            Assert.Fail("Invalid expression did not throw exception.");
        }

        
        /// <summary>
        /// Tests huge integer. Exception needs to be thrown.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestHugeInteger()
        {
            string expression = "1212412412481824618726487126471264 178246817264235325235718264871262421415 +";
            _ = Interpreter.Evaluate( expression );

            // If it gets to this line, no exception was thrown.
            Assert.Fail( "Invalid expression did not throw exception." );
        }
    }
}

