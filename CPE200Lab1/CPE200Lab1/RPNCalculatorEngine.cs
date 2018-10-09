using System;
using System.Collections.Generic;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : TheCalculatorEngine
    {
        protected Stack<string> myStack = new Stack<string>();

        public string calculate(string oper)
        {
            string secondOperand = null;
            string firstOperand = null;
            string[] parts = oper.Split(' ');
            if (parts.Length < 3)
            {
                return "E";
            }
            foreach (string token in parts)
            {
                if (token == "")
                {
                    continue;
                }

                if (isNumber(token))
                {
                    myStack.Push(token);
                }
                else if (isOperator(token))
                {
                    if (token == "1/x" || token == "√")
                    {
                        secondOperand = myStack.Pop();
                        myStack.Push(calculate(token, secondOperand));
                        continue;
                    }

                    if (token == "%")
                    {
                        try
                        {
                            secondOperand = myStack.Pop();
                            firstOperand = myStack.Peek();
                            myStack.Push(calculate(token, firstOperand, secondOperand));
                        }
                        catch
                        {
                            myStack.Push(calculate(token, "1", secondOperand));
                        }

                        continue;
                    }
                    try
                    {
                        secondOperand = myStack.Pop();
                        firstOperand = myStack.Pop();
                        myStack.Push(calculate(token, firstOperand, secondOperand));
                    }
                    catch (Exception e)
                    {
                        return "E";
                    }
                }
            }

            if (myStack.Count != 1)
            {
                return "E";
            }

            return myStack.Pop();
        }
    }
}
