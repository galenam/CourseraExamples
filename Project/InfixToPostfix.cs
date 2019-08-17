using System;
using System.Collections.Generic;
using System.Text;

namespace CourseraCourseComputerScienceAlgorithmsTheoryAndMachines.InfixToPostfix
{

    public static class InfixToPostfix
    {

        public static string Tranform(string source)
        {
            var stackOperations = new Stack<char>();
            var postfix = new StringBuilder();
            foreach (char c in source)
            {
                if ("/+-*()".IndexOf(c) < 0)
                {
                    postfix.Append(c);
                }
                else
                {
                    if (stackOperations.Count > 0 && c != '(')
                    {
                        if (c == ')')
                        {
                            GetStackEmpty(stackOperations, postfix, '(');
                            continue;
                        }
                        var previousOperation = stackOperations.Peek();
                        if (IsPriorityOperationGreater(previousOperation, c))
                        {
                            GetStackEmpty(stackOperations, postfix);
                        }
                    }
                    stackOperations.Push(c);
                }
            }
            GetStackEmpty(stackOperations, postfix);
            return postfix.ToString();
        }

        private static void GetStackEmpty(Stack<char> stackOperations, StringBuilder postfix, char? delimeter = null)
        {
            while (stackOperations != null && stackOperations.Count > 0)
            {
                var operation = stackOperations.Pop();
                if (delimeter.HasValue && operation == delimeter.Value)
                {
                    break;
                }
                postfix.Append(operation);
            }
        }

        private static bool IsPriorityOperationGreater(char previousOperation, char c)
        {
            if (IsPriority0(previousOperation) && IsPriority1(c) || previousOperation == '(')
            {
                return false;
            }
            return true;
        }

        private static bool IsPriority0(char c) => IsOperationIncluded(c, "+-");

        private static bool IsPriority1(char c) => IsOperationIncluded(c, "*/");

        private static bool IsOperationIncluded(char c, string operations) =>
            !string.IsNullOrEmpty(operations) && operations.IndexOf(c) >= 0;
    }
}