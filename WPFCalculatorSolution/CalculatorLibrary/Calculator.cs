using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CalculatorLibrary
{
    public static class Calculator
    {


        public static string Arithmetic(string first, string second, string oprt) {

            string value = "";

            switch (oprt) {
                case "+": value = Addition(first, second) ; break;
                case "-": value = Subtraction(first, second); break;
                case "*": value = Multiplication(first, second); break;
                case "/": value = Division(first, second); break;
            }

            return value;

        
        }

        private static string Addition(string first, string second)
        {

            double firstArg, secArg;

            if (first == "")
                firstArg = 0.0;
            else
            {
                firstArg = double.Parse(first);
            }
            secArg = double.Parse(second);


            return (firstArg + secArg).ToString();

        }

        private static string Subtraction(string first, string second)
        {

           

            double firstArg, secArg;

            firstArg = double.Parse(first);
            secArg = double.Parse(second);


            return (firstArg - secArg).ToString();
        }

        private static string Multiplication(string first, string second)
        {

            double firstArg, secArg;

            firstArg = double.Parse(first);
            secArg = double.Parse(second);


            return (firstArg * secArg).ToString();

        }

        private static string Division(string first, string second)
        {
            

            double firstArg, secArg;

            firstArg = double.Parse(first);
            secArg = double.Parse(second);


            if (secArg == 0.0)
                return "Error: Division by Zero";
            else
                return (firstArg / secArg).ToString();

        }



    }
}
