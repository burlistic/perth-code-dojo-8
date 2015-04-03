using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalc
{
    public class StringCalculator
    {
        public static int Add(string stringInput)
        {


            if (string.IsNullOrEmpty(stringInput) || string.IsNullOrWhiteSpace(stringInput))
            {
                return 0;
            }


            var delimiterString = "";

            if (stringInput.Length > 2 && stringInput.Substring(0, 3) == "//[")
            {
                var regEx = new Regex(@"\[(.)\]");
                var delimiters = regEx.Matches(stringInput);

                delimiterString = string.Join(",", delimiters);

                var lastEndBracket = stringInput.LastIndexOf(']');
                stringInput = stringInput.Remove(0, (lastEndBracket + 1));
            }


            var splitString = stringInput.Split(new string[] { ",", "\n", delimiterString }, StringSplitOptions.RemoveEmptyEntries);

            int total = 0;
            List<string> negativeNumbers = new List<string>();

            foreach (var s in splitString)
            {
                int number = int.Parse(s);
                number = number > 1000 ? 0 : number;

                if (number < 0)
                {
                    negativeNumbers.Add(s);
                }

                total += number;
            }

            if (negativeNumbers.Count > 0)
            {
                throw new Exception(string.Format("Negatives not allowed. Value(s) {0} invalid.", string.Join(",", negativeNumbers)));
            }

            return total;
        }


    }
}
