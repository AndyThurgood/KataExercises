using System;
using System.Collections.Generic;
using System.Linq;

namespace KataExercises
{
    public class Calculator
    {    
        private readonly List<char> _permittedDelimiters = new List<char>{',', '\n'};
        private readonly List<char> _delimiterDelimiters = new List<char> {'[', ']'};
        private const string DelimiterFlag = "//";
        private const int MaxValue = 1000;
        
        /// <summary>
        /// Sums a delimited string of numbers
        /// </summary>
        /// <param name="numberList"></param>
        /// <returns></returns>
        public int Add(string numberList)
        {
            // Defensive coding
            if (string.IsNullOrEmpty(numberList))
            {
                return 0;
            }
            
            // we don't have a delimiter so process the number list
            if (!numberList.StartsWith(DelimiterFlag))
            {
                return SumNumbers(numberList);
            }
            
            // split the string to get delimiter and target string
            string[] splitNumbers = numberList.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            
            // Add any further delimiters
            ExtendDelimiters(splitNumbers.First());

            // Edge case we have a duplicate delimeter (\n)
            if (splitNumbers.Length > 2)
            {
                return SumNumbers(splitNumbers.Skip(1).Select(int.Parse).ToList());
            }

            return SumNumbers(splitNumbers.Last());
        }
        
        /// <summary>
        /// Generate the sum of a delimited string
        /// </summary>
        /// <param name="numberList"></param>
        /// <returns></returns>
        private int SumNumbers(string numberList)
        {
            List<int> targetNumbers = numberList.Split(_permittedDelimiters.ToArray()).Select(int.Parse).ToList();
            return SumNumbers(targetNumbers);
        }

        /// <summary>
        /// Generates the sum of an IEnumerable int
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        private int SumNumbers(List<int> numbers)
        {
            if (numbers.Any(x => x < 0))
            {
                GenerateNegativeException(numbers.Where(x => x < 0));
            }   

            return numbers.Where(x => x < MaxValue).Sum();
        }
        
        /// <summary>
        /// Helper method to get the delimter for the target string
        /// </summary>
        /// <param name="delimeters"></param>
        /// <returns></returns>
        private void ExtendDelimiters(string delimeters)
        {
            string newDelimeter = (new string(delimeters.Skip(2).ToArray()));
            
            //Handle and remove bracket seperators
            newDelimeter = string.Join(string.Empty, 
                                       newDelimeter.Split(_delimiterDelimiters.ToArray(), 
                                           StringSplitOptions.RemoveEmptyEntries));
            
            _permittedDelimiters.AddRange(newDelimeter.ToCharArray());
        }
        
        /// <summary>
        /// Helper method to generate a negative number exception
        /// </summary>
        /// <param name="negativeNumbers"></param>
        /// <exception cref="Exception"></exception>
        private void GenerateNegativeException(IEnumerable<int> negativeNumbers)
        {
            string exceptionMessage = "negatives not allowed ({0})";

            exceptionMessage = string.Format(exceptionMessage, string.Join(", ", negativeNumbers));
            
            throw new Exception(exceptionMessage);
        }
    }
}