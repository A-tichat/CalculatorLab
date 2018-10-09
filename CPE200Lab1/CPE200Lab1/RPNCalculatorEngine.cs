using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i] == "")
                {
                    continue;
                }

                if (isNumber(parts[i]))
                {
                    myStack.Push(parts[i]);
                }
                else if (isOperator(parts[i]))
                {
                    if (parts[i] == "1/x" || parts[i] == "√")
                    {
                        secondOperand = myStack.Pop();
                        myStack.Push(calculate(parts[i], secondOperand));
                        continue;
                    }

                    if (parts[i] == "%")
                    {
                        try
                        {
                            secondOperand = myStack.Pop();
                            firstOperand = myStack.Peek();
                            myStack.Push(calculate(parts[i], firstOperand, secondOperand));
                        }
                        catch
                        {
                            myStack.Push(calculate(parts[i], "1", secondOperand));
                        }

                        continue;
                    }
                    try
                    {
                        secondOperand = myStack.Pop();
                        firstOperand = myStack.Pop();
                        myStack.Push(calculate(parts[i], firstOperand, secondOperand));
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

            return myStack.Peek();
        }
    }
}
