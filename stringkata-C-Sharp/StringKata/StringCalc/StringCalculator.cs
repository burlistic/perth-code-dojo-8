using System;
using System.Collections.Generic;
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

            MatchCollection delimiters = null;

            // get a list of delimiter matches
            if (stringInput.Length > 2 && stringInput.Substring(0, 3) == "//[")
            {
                var regEx = new Regex(@"\[(.*?)\]");
                delimiters = regEx.Matches(stringInput);      
            }

            // clean the end of the string
            var lastEndBracket = stringInput.LastIndexOf(']');
            stringInput = stringInput.Remove(0, (lastEndBracket + 1));

            string[] splitString;

            if (delimiters == null)
            {
                // split using comma and newline characters only
                splitString = stringInput.Split(new[]{',', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                var dCount = delimiters.Count;
                var delimiterStrings = new string[dCount];

                for (int i = 0; i < dCount; i++)
                {
                    delimiterStrings[i] = delimiters[i].Value.Replace("[", "").Replace("]", ""); // TODO - tidy up regex to strip off square brackets
                }

                splitString = stringInput.Split(delimiterStrings, StringSplitOptions.RemoveEmptyEntries);
            }


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
