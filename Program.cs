using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

public class MathExpressionParser
{
    // Определение приоритетов операторов
    private static readonly Dictionary<string, int> Precedence = new Dictionary<string, int>
    {
        { "+", 1 },
        { "-", 1 },
        { "*", 2 },
        { "/", 2 }
    };

    // Проверка, является ли токен оператором
    private static bool IsOperator(string token) => Precedence.ContainsKey(token);

    // Проверка, имеет ли op1 более высокий или равный приоритет, чем op2
    private static bool HasHigherOrEqualPrecedence(string op1, string op2)
    {
        if (!Precedence.ContainsKey(op1) || !Precedence.ContainsKey(op2))
            return false;
        return Precedence[op1] >= Precedence[op2];
    }

    /// <summary>
    /// Шаг 1: Преобразует инфиксное выражение в обратную польскую запись (ОПЗ/RPN).
    /// Использует алгоритм сортировочной станции.
    /// </summary>
    /// <param name="expression">Строка математического выражения.</param>
    /// <returns>Список токенов в ОПЗ.</returns>
    private static List<string> ShuntingYard(string expression)
    {
        // Регулярное выражение для разделения выражения на токены: числа, операторы, скобки.
        // Игнорирует пробелы.
        var tokens = Regex.Matches(expression, @"(\d+\.?\d*)|([+\-*/()])")
                          .Cast<Match>()
                          .Select(m => m.Value)
                          .Where(t => !string.IsNullOrWhiteSpace(t))
                          .ToList();

        var output = new List<string>();
        var operators = new Stack<string>();

        foreach (var token in tokens)
        {
            if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out _))
            {
                // Если число - добавляем в выходную очередь
                output.Add(token);
            }
            else if (IsOperator(token))
            {
                // Если оператор
                while (operators.Count > 0 &&
                       IsOperator(operators.Peek()) &&
                       HasHigherOrEqualPrecedence(operators.Peek(), token))
                {
                    output.Add(operators.Pop());
                }
                operators.Push(token);
            }
            else if (token == "(")
            {
                // Если открывающая скобка - помещаем в стек операторов
                operators.Push(token);
            }
            else if (token == ")")
            {
                // Если закрывающая скобка
                while (operators.Count > 0 && operators.Peek() != "(")
                {
                    output.Add(operators.Pop());
                }
                if (operators.Count == 0 || operators.Peek() != "(")
                {
                    throw new ArgumentException("Несогласованные скобки в выражении.");
                }
                operators.Pop(); // Удаляем открывающую скобку
            }
        }

        // Перемещаем оставшиеся операторы из стека в выходную очередь
        while (operators.Count > 0)
        {
            if (operators.Peek() == "(" || operators.Peek() == ")")
            {
                throw new ArgumentException("Несогласованные скобки в выражении.");
            }
            output.Add(operators.Pop());
            
        }
        return output;
    }

    /// <summary>
    /// Шаг 2: Вычисляет результат из обратной польской записи (ОПЗ).
    /// </summary>
    /// <param name="rpn">Список токенов в ОПЗ.</param>
    /// <returns>Результат вычисления.</returns>
    private static double EvaluateRpn(List<string> rpn)
    {
        var stack = new Stack<double>();

        foreach (var token in rpn)
        {
            if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
            {
                stack.Push(number);
            }
            else if (IsOperator(token))
            {
                if (stack.Count < 2)
                {
                    throw new InvalidOperationException("Недостаточно операндов для оператора.");
                }
                var operand2 = stack.Pop();
                var operand1 = stack.Pop();
                double result = 0;

                switch (token)
                {
                    case "+": result = operand1 + operand2; break;
                    case "-": result = operand1 - operand2; break;
                    case "*": result = operand1 * operand2; break;
                    case "/":
                        if (operand2 == 0) throw new DivideByZeroException("Деление на ноль.");
                        result = operand1 / operand2;
                        break;
                }
                stack.Push(result);
            }
        }

        if (stack.Count != 1)
        {
            throw new InvalidOperationException("Некорректное выражение (осталось несколько значений в стеке).");
        }

        return stack.Pop();
    }

    /// <summary>
    /// Главный метод для парсинга и вычисления.
    /// </summary>
    public static double ParseAndEvaluate(string expression)
    {
        if (string.IsNullOrWhiteSpace(expression))
        {
            throw new ArgumentException("Выражение не может быть пустым.");
        }

        // Шаг 1: Инфикс -> ОПЗ
        var rpnTokens = ShuntingYard(expression);

        // Шаг 2: Вычисление ОПЗ
        return EvaluateRpn(rpnTokens);
    }
}
public class Program
{
    public static void Main()
    {
        String input=null;
        try
        {
            
            while (input != "")
            {
                input = Console.ReadLine();
                double result1 = MathExpressionParser.ParseAndEvaluate(input);
                Console.WriteLine(result1 + "\n");
            }
            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при вычислении: {ex.Message}");
        }
    }
}