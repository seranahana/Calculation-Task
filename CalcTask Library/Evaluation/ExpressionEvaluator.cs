using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CalcTask.WebAPI.Library.Evaluation
{
    internal static class ExpressionEvaluator
    {
        internal static double Evaluate(string expression)
        {
            List<string> tokens = Tokenize(expression);
            List<string> postfixNotation = ConvertToPostfixNotation(tokens);

            Stack<double> stack = new();
            foreach (string token in postfixNotation)
            {
                if (IsOperator(token))
                {
                    double operand2 = stack.Pop();
                    double operand1 = 0;
                    if (token != "sqrt")
                        operand1 = stack.Pop();

                    double s = 0;

                    switch (token)
                    {
                        case "+":
                            s = operand1 + operand2;
                            if (double.IsInfinity(s) || double.IsNaN(s))
                                throw new OverflowException();
                            stack.Push(s);
                            break;
                        case "-":
                            s = operand1 - operand2;
                            if (double.IsInfinity(s) || double.IsNaN(s))
                                throw new OverflowException();
                            stack.Push(s);
                            break;
                        case "*":
                            s = operand1 * operand2;
                            if (double.IsInfinity(s) || double.IsNaN(s))
                                throw new OverflowException();
                            stack.Push(s);
                            break;
                        case "/":
                            s = operand1 / operand2;
                            if (double.IsInfinity(s) || double.IsNaN(s))
                                throw new OverflowException();
                            stack.Push(s);
                            break;
                        case "^":
                            s = Math.Pow(operand1, operand2);
                            if (double.IsInfinity(s) || double.IsNaN(s))
                                throw new OverflowException();
                            stack.Push(s);
                            break;
                        case "sqrt":
                            s = Math.Sqrt(operand2);
                            if (double.IsInfinity(s) || double.IsNaN(s))
                                throw new OverflowException();
                            stack.Push(s);
                            break;
                    }
                }
                else
                {
                    double operand = double.Parse(token);
                    stack.Push(operand);
                }
            }

            return stack.Pop();
        }


        private static List<string> Tokenize(string expression)
        {
            List<string> tokens = new();

            string pattern = @"([+\-*/^()])|\d+(\.\d+)?|sqrt";
            Regex regex = new(pattern);

            expression = expression.Replace(" ", "");

            if (regex.Matches(expression).Count != expression.Length)
                throw new ArgumentException("Expression contains illegal charaters", nameof(Params.Expression));

            foreach (Match match in regex.Matches(expression).Cast<Match>())
            {
                tokens.Add(match.Value);
            }

            return tokens;
        }

        private static List<string> ConvertToPostfixNotation(List<string> tokens)
        {
            List<string> output = new();
            Stack<string> operators = new();

            Dictionary<string, int> precedence = new()
            {
                { "sqrt", 4 },
                { "^", 4 },
                { "*", 3 },
                { "/", 3 },
                { "+", 2 },
                { "-", 2 },
                { "(", 1 },
            };

            foreach (string token in tokens)
            {
                if (double.TryParse(token, out double number)) 
                {
                    output.Add(token);
                }
                else if (token == "(")
                {
                    operators.Push(token);
                }
                else if (token == ")")
                {
                    while (operators.Peek() != "(")
                    {
                        output.Add(operators.Pop());
                    }
                    operators.Pop();
                }
                else
                {
                    while (operators.Count > 0 && precedence[token] <= precedence[operators.Peek()])
                    {
                        output.Add(operators.Pop());
                    }
                    operators.Push(token);
                }
            }

            while (operators.Count > 0)
            {
                output.Add(operators.Pop());
            }

            return output;
        }

        private static bool IsOperator(string token)
        {
            return token == "+" || token == "-" || token == "*" || token == "/" || token == "^" || token == "sqrt";
        }
    }
}
