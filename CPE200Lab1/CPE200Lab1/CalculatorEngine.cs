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
                string[] parts = oper.Split(' ');
                try
                {
                    if (!(isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2])))
                    {
                        return "E";
                    }
                    else if (parts.Length > 3)
                    {
                        if (parts[3] == "%")
                        {
                            parts[2] = calculate(parts[3], parts[0], parts[2]);
                        }
                        else
                        {
                            parts[2] = calculate(parts[3], parts[2]);
                        }
                    }
                }
                catch (Exception e)
                {
                    return "E";
                }
                return calculate(parts[1], parts[0], parts[2], 4);
            }
        }
}
