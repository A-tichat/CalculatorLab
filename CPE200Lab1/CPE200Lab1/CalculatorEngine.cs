using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine : TheCalculatorEngine
    {
        protected double firstOperand;
        protected double secondOperand;

        public void setFristOperand(string num)
        {
            firstOperand = Convert.ToDouble(num);
        }

        public void setSecondOperand(string num)
        {
            secondOperand = Convert.ToDouble(num);
        }

        public string calculate(string oper)
        {
            switch(oper)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                    return calculate(oper, firstOperand.ToString(), secondOperand.ToString());
                case "%":
                    if (firstOperand == 0)
                    {
                        return calculate(oper, secondOperand.ToString());
                    }
                    else
                    {
                        return calculate(oper, firstOperand.ToString(), secondOperand.ToString());
                    }
                case "√":
                case "1/x":
                    return calculate(oper, firstOperand.ToString());
            }
            return "E"; 
        }
        
    }
}
