using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumeralConverter;

namespace TestNumeralConverter
{
    [TestClass]
    public class RomanNumeralConverterTest
    {


        [TestMethod]
        public void ConvertTest_Valid_Conversion()
        {
            RomanNumberConverter testRomanNumber = new RomanNumberConverter(); 
            Assert.AreEqual(testRomanNumber.Convert("V"), 5);

        }

        [TestMethod]
        public void ConvertTest_Invalid_Conversion()
        {
            RomanNumberConverter testRomanNumber = new RomanNumberConverter();
            Assert.AreNotEqual(testRomanNumber.Convert("IIV"), 3);

        }


        [TestMethod]
        public void ConvertTest_Invalid_Input()
        {
            RomanNumberConverter testRomanNumber = new RomanNumberConverter();
            Assert.AreNotEqual(testRomanNumber.Convert("XXXX"), 40);

        }

        [TestMethod]
        public void ConvertTest_Return_Zero_Invalid_RomanNumeral()
        {
            RomanNumberConverter testRomanNumber = new RomanNumberConverter();
            Assert.AreEqual(testRomanNumber.Convert("N"), 0);

        }

        [TestMethod]
        public void ConvertTest_Return_Zero_Max_RomanNumeral()
        {
            RomanNumberConverter testRomanNumber = new RomanNumberConverter();
            Assert.AreNotEqual(testRomanNumber.Convert("IIIII"), 5);

        }


        

    }
}
