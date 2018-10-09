using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class TheCalculatorEngine
    {
        public bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        public bool isOperator(string str)
        {
            switch (str)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                case "%":
                case "√":
                case "1/x":
                    return true;
            }
            return false;
        }

        public string calculate(string operate, string firstOperand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "√":
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = Math.Sqrt(Convert.ToDouble(firstOperand));
                        parts = result.ToString().Split('.');
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        return Convert.ToDouble(result.ToString("N" + remainLength)).ToString();
                    }
                case "1/x":
                    if (firstOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (1.0 / Convert.ToDouble(firstOperand));
                        parts = result.ToString().Split('.');
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        return Convert.ToDouble(result.ToString("N" + remainLength)).ToString();
                    }
                    break;
                case "%":
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (Convert.ToDouble(firstOperand) / 100);
                        parts = result.ToString().Split('.');
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        return Convert.ToDouble(result.ToString("N" + remainLength)).ToString();
                    }
            }
            return "E";
        }

        public string calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            
            switch (operate)
            {
                case "+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                case "-":
                    return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                case "X":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                case "÷":
                    if (secondOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                        parts = result.ToString().Split('.');

                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        return Convert.ToDouble(result.ToString("N" + remainLength)).ToString();
                    }
                    break;
                case "%":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand) / 100).ToString();
            }
            return "E";
        }
        
    }
}
