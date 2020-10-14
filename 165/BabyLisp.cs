using System;
using System.Text.RegularExpressions;

/// <summary>
/// Given a basic Lisp-like string expression, parse it (where the available functions are
/// add, subtract, multiply, and divide, and they all take in 2 values).
///     Examples:
///     $ babyLisp(‘(add 1 2)’)
///     $ 3
///     $ babyLisp(‘(multiply 4 (add 2 3))’)
///     $ 20
/// </summary>
class BabyLisp
{
    static void Main(string[] args)
    {
        if (args.Length == 1 && !string.IsNullOrEmpty(args[0]))
            Console.WriteLine($"Expression: {args[0]}\nAnswer: {EvalExpression(args[0])}");
        else
        {
            // Run Tests
            Console.WriteLine($"Expected: 3  Calculated: {EvalExpression("(add 1 2)")}");
            Console.WriteLine($"Expected: 20 Calculated: {EvalExpression("(multiply 4 (add 2 3))")}");
            Console.WriteLine($"Expected: 6  Calculated: {EvalExpression("(divide 30 (add 2 (subtract 5 2)))")}");
            Console.WriteLine($"Expected: 10 Calculated: {EvalExpression("(subtract (multiply 4 2) (subtract 8 (add 2 (multiply 4 2))))")}");
        }
    }

    static double EvalExpression(string expression)
    {
        string expResult = expression;
        var evaluator = new MatchEvaluator(CalculateExpression);

        while (expResult.Contains('('))
        {
            // Find groups that match solvable parts of the expression, then replace the expression
            // with the calculated answer. Solvable = an operand and two values.
            expResult = Regex.Replace(expResult, @"\(\s?(\w+\s+-?\d+\s+-?\d+\s?)\)", evaluator);
        }

        return double.Parse(expResult);
    }

    static string CalculateExpression(Match matchResult)
    {
        // Toss parentheses then grab the operand and both values.
        var exp = matchResult.Value
            .Replace("(", string.Empty)
            .Replace(")", string.Empty)
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        switch (exp[0].ToLower())
        {
            case "add":
                return $"{double.Parse(exp[1]) + double.Parse(exp[2])}";
            case "subtract":
                return $"{double.Parse(exp[1]) - double.Parse(exp[2])}";
            case "multiply":
                return $"{double.Parse(exp[1]) * double.Parse(exp[2])}";
            case "divide":
                return $"{double.Parse(exp[1]) / double.Parse(exp[2])}";
        }

        return string.Empty;
    }
}

