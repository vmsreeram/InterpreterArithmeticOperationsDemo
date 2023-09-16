# Interpreter for arithmetic operations

## Overview
Software design patterns are programming paradigms that describe reusable patterns for common design problems. 

**Interpreter design pattern**, one of the 23 software design patterns described in the [Gang of Four book](https://en.wikipedia.org/wiki/Design_Patterns_(book)), is demonstrated in this project. The Interpreter pattern is a behavioral pattern. The intent of the design pattern is, given a language, to define a representation for its grammar along with an interpreter that uses the representation to interpret sentences in the language.

**Real-world applications** of the interpreter design pattern include:
- SQL query parsers and evaluators.
- Regular expression matches.
- Language interpreters for scripting languages.
- Configurable rule engines.


## The interpreter for arithmetic operations
The interpreter can evaluate simple strings of arithmetic expressions in [postfix format](https://en.wikipedia.org/wiki/Reverse_Polish_notation).
- The interpreter can handle the binary operators `+`, `-`, `*`, and `/`.
- Only English script whole numbers are supported.
- Invalid input strings will fail gracefully throwing an exception.
- If the number exceeds the bounds of `int`, the program will fail gracefully throwing an exception.

## Interface and Classes
### Interface
- `IExpressionEvaluater`: Exposes an interface for expression interpretation.
### Classes 
- `NumberExpression`: Terminal expression to interpret and return a stored integer value, which is initialized during construction.
- `AddExpression`: Non-terminal expression to interpret and return the result of adding the interpretations of its left and right sub-expressions.
- `SubtractExpression`: Non-terminal expression to interpret and return the result of subtracting the interpretations of its left and right sub-expressions.
- `MultiplyExpression`: Non-terminal expression to interpret and return the result of multiplying the interpretations of its left and right sub-expressions.
- `DivideExpression`: Non-terminal expression to interpret and return the result of dividing the interpretations of its left and right sub-expressions.
- `Interpreter`: Provides the functionality to evaluate simple arithmetic expressions provided as strings.
- `InterpreterUnitTest`: Unit tests for the demo.

## Design
![image](./ClassDiagram1.png)

## Environment
The project builds and runs with Visual Studio Community 2022 when the required workloads are installed.

