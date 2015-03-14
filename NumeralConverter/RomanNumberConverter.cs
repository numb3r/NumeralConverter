using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NumeralConverter
{
    public class RomanNumberConverter
    {
        private enum RomanMapping
        {
            I = 1,
            V = 5,
            X = 10,
            L = 50,
            C = 100,
            D = 500,
            M = 1000
        }

        public int Convert(string romanNumeral)
        {
            romanNumeral = romanNumeral.ToUpper().Trim();
            if (romanNumeral == "N" || romanNumeral.Split('V').Length > 2 || romanNumeral.Split('L').Length > 2 || romanNumeral.Split('D').Length > 2)
            {
                return 0;
            }

            int returnValue;
            if (IndexOfRoman(romanNumeral, out returnValue))
            {
                return returnValue;
            }

            int pointer = 0;

            ArrayList values = new ArrayList();
            int maxSingleRomanValue = 1000;
            while (pointer < romanNumeral.Length)
            {
                char numeral = romanNumeral[pointer];
                int romanNumberValue = (int)Enum.Parse(typeof(RomanMapping), numeral.ToString());

                if (romanNumberValue > maxSingleRomanValue)
                {
                    return 0;
                }

                int nextRomanNumberValue = 0;
                if (pointer < romanNumeral.Length - 1)
                {
                    char nextNumeral = romanNumeral[pointer + 1];
                    nextRomanNumberValue = (int)Enum.Parse(typeof(RomanMapping), nextNumeral.ToString());

                    if (nextRomanNumberValue > romanNumberValue)
                    {
                        if (nextRomanNumberValue > (romanNumberValue * 10) || romanNumeral.Split(numeral).Length > 3 || "IXC".IndexOf(numeral) == -1)
                        {
                            return 0;
                        }

                        maxSingleRomanValue = romanNumberValue - 1;
                        romanNumberValue = nextRomanNumberValue - romanNumberValue;
                        pointer++;
                    }
                }

                values.Add(romanNumberValue);

                pointer++;
            }

            for (int i = 0; i < values.Count - 1; i++)
            {
                if ((int)values[i] < (int)values[i + 1])
                    return 0;
            }

            int total = 0;
            foreach (int digit in values)
            {
                total += digit;
            }
            return total;
        }
 
        private bool IndexOfRoman(string romanNumeral, out int value)
        {
            char dummy = '\0';
            value = 0;
            int count = 1;
            foreach (char numeral in romanNumeral)
            {
                if ("IVXLCDM".IndexOf(numeral) == -1)
                {
                    value = 0;
                    return true;
                }

                if (numeral == dummy)
                {
                    count++;
                    if (count == 4)
                    {
                        value = 0;
                        return true;
                    }
                }
                else
                {
                    count = 1;
                    dummy = numeral;
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            RomanNumberConverter romanConverter = new RomanNumberConverter();

            Console.WriteLine("Enter roman number: ");
            string number = Console.ReadLine();
            var value = romanConverter.Convert(number);
            Console.WriteLine("Int value: " + value +"\n" );
            Console.ReadLine();

        }

       

    

    }
}