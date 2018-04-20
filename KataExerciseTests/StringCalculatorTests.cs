using System;
using KataExercises;
using Xunit;

namespace KataExercisesTests
{
    public class CalculatorTests
    {
        private readonly Calculator _calculator;
        
        public CalculatorTests()
        {
            _calculator = new Calculator();    
        }
        
        [Fact]
        public void String_Calculator_Handles_Empty_String()
        {            
            Assert.Equal(0, _calculator.Add(string.Empty));
        }
        
        [Fact]
        public void String_Calculator_Handles_Single_Value()
        {
            Assert.Equal(1, _calculator.Add("1"));
        }
        
        [Fact]
        public void String_Calculator_Handles_Two_Values()
        {
            Assert.Equal(3, _calculator.Add("1\n2"));
        }
        
        [Fact]
        public void String_Calculator_Handles_Three_Values()
        {
            Assert.Equal(6, _calculator.Add("1\n2\n3"));
        }
        
        [Fact]
        public void String_Calculator_Handles_Two_Comma_Seperated_Values()
        {
            Assert.Equal(3, _calculator.Add("1,2"));
        }
        
        [Fact]
        public void String_Calculator_Handles_Three_Comma_Seperated_Values()
        {
            Assert.Equal(6, _calculator.Add("1,2,3"));
        }
        
        [Fact]
        public void String_Calculator_Ignores_Max_Values()
        {
            Assert.Equal(6, _calculator.Add("1,2,3,1001"));
        }
        
        [Fact]
        public void String_Calculator_Ignores_Delimeter_Max_Values()
        {
            Assert.Equal(6, _calculator.Add("//*\n1*2*3,1001"));
        }
        
        [Fact]
        public void String_Calculator_Allows_For_Delimiter_Spec()
        {
            Assert.Equal(6, _calculator.Add("//*\n1*2*3"));
        }
        
        [Fact]
        public void String_Calculator_Allows_For_Delimiter_Spec_And_Single_Value()
        {
            Assert.Equal(1, _calculator.Add("//*\n1"));
        }
        
        [Fact]
        public void String_Calculator_Allows_For_Negative_Values()
        {
            Action action = () => _calculator.Add("//*\n-1*2*3");
            
            Exception exception = Assert.Throws<Exception>(action);
            Assert.Equal("negatives not allowed (-1)".ToLower(), exception.Message.ToLower());
        }
        
        [Fact]
        public void String_Calculator_Allows_For_Multiple_Negative_Values()
        {
            Action action = () => _calculator.Add("//*\n-1*-5*2*3");
            
            Exception exception = Assert.Throws<Exception>(action);
            Assert.Equal("negatives not allowed (-1, -5)".ToLower(), exception.Message.ToLower());
        }
        
        [Fact]
        public void String_Calculator_Allows_For_Multi_Char_Delimiter_Spec()
        {            
            Assert.Equal(6, _calculator.Add("//[*][#]\n1*2#3"));
        }
        
        [Fact]
        public void String_Calculator_Allows_For_Delimieter_Spec_As_NewLine()
        {            
            Assert.Equal(6, _calculator.Add("//\n\n1\n2\n3"));
        }
    }
}