using System;
using System.Collections.Generic;
using ConsoleCalculatorV2.Exceptions;

namespace ConsoleCalculatorV2
{
    internal class Tokenizer
    {
        internal static List<string> Tokenize(string input)
        {
            var result = new List<string>();
            var operationStack = new Stack<char>();
            var prevToken = '\0';
            
            for (var i = 0; i < input.Length; i++)
            {
                if (input[i].IsInvalidSymbol())
                    throw new UnrecognizedSymbolException($"Symbol \"{input[i]}\" is not correct. " +
                                                          "Expected math operations. Please, try to enter math expression again");

                if (char.IsDigit(input[i]))
                {
                    var currentNumber = "";

                    while (!input[i].IsOperator() && !input[i].IsInvalidSymbol())
                    {
                        currentNumber += input[i];
                        i++;

                        if (i == input.Length) break;
                    }
                    
                    if (prevToken == '-')
                    {
                        currentNumber = $"-{currentNumber}";
                        operationStack.Pop();
                    }
                    
                    result.Add(currentNumber);

                    i--;
                    prevToken = input[i];
                }

                if (!input[i].IsOperator()) continue;

                switch (input[i])
                {
                    case '(':
                    {
                        if (prevToken == '-')
                        {
                            result.Add("0");
                        }
                        
                        operationStack.Push(input[i]);
                    }

                        break;
                    case ')':
                    {
                        var symbol = operationStack.Pop();

                        if (prevToken == '(')
                            throw new SystemException();
                        
                        while (symbol != '(')
                        {
                            result.Add(symbol.ToString());
                            symbol = operationStack.Pop();
                        }

                        break;
                    }
                    default:
                    {
                        if (operationStack.Count > 0)
                        {
                            if (input[i].GetOperationPriority() <= operationStack.Peek().GetOperationPriority())
                            {
                                result.Add(operationStack.Pop().ToString());
                            }
                        }
                        
                        operationStack.Push(input[i]);
                        
                        break;
                    }
                }
                
                prevToken = input[i];
            }

            while (operationStack.Count > 0)
            {
                result.Add(operationStack.Pop().ToString());   
            }

            
            return result;
        }
    }
}