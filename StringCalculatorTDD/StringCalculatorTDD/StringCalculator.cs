using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorTDD
{
    public class StringCalculator
    {
        internal object Add(string numbers)
        {
            if (String.IsNullOrEmpty(numbers)) return 0;
            var numberStrings = numbers;
            var delimeter = new List<char> { ',', '\n', '#', '!','/' };

            if (numberStrings.StartsWith("//"))
            { var splitInput = numberStrings.Split('\n');
                var delimeter2 = splitInput.First().Trim('/');
                numberStrings = String.Join('\n', splitInput.Skip(1));
                delimeter.Add(Convert.ToChar(delimeter2));
            }
            var numberList = numberStrings.Split(delimeter.ToArray()).Select(s => int.Parse(s));
                        var negatives = numberList.Where(n => n < 0);
            if(negatives.Any())
            {
                string negativeString=String.Join(',',negatives.Select(n=>n.ToString()));
                throw new Exception($"Negatives not allowed :{negativeString}");
            }
            var result = numberList.Where(n=>n<=1000).Sum();

            return result;
        }
    }
}
