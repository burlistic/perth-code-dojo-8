using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringCalc;
using Xunit;

namespace StringCalcTests
{
    
    public class StringCalcTests
    {

        [Fact]
        public void EmptyStringReturnsZero()
        {
           Assert.Equal(0, StringCalculator.Add("")); 
        }

        [Fact]
        public void WhitespaceReturnsZero()
        {
            Assert.Equal(0, StringCalculator.Add(" "));
        }

        [Fact]
        public void SingleNumber()
        {
            Assert.Equal(1, StringCalculator.Add("1"));
        }

        [Fact]
        public void TwoNumbers()
        {
            Assert.Equal(3, StringCalculator.Add("1,2"));
        }

        [Fact]
        public void ThreeNumbers()
        {
            Assert.Equal(5, StringCalculator.Add("1,2,2"));
        }

        [Fact]
        public void HandlesNewLine()
        {
            Assert.Equal(6, StringCalculator.Add("1\n2,3"));
        }

        [Fact]
        public void SupportDifferentDelimiters()
        {
            Assert.Equal(3, StringCalculator.Add("//[;]\n1;2"));
        }

        [Fact]
        public void NegativesThrowExceptions()
        {
            var exception = Assert.Throws<Exception>(() => StringCalculator.Add("1,-2, -1, -3, -2"));
            Assert.Contains("negatives not allowed", exception.Message.ToLower());
            Assert.Contains("-2", exception.Message.ToLower()); // Test it is listed twice?
            Assert.Contains("-1", exception.Message.ToLower());
            Assert.Contains("-3", exception.Message.ToLower());
        }

        [Fact]
        public void NumbersGreaterThan1000ShouldBeIgnored()
        {
            Assert.Equal(2, StringCalculator.Add("2,1001"));
            Assert.Equal(2, StringCalculator.Add("2,2001"));
            Assert.Equal(2, StringCalculator.Add("2,9991"));
        }

        [Fact]
        public void SupportLongDelimiters()
        {
            Assert.Equal(6, StringCalculator.Add("//[***]\n1***2***3"));
        }

        [Fact]
        public void SupportMultipleSpecifiedDelimiters()
        {
            Assert.Equal(6, StringCalculator.Add("//[*][%]\n1*2%3"));
        }

    }
}
