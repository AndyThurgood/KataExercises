using System;
using Xunit;
using KataExercises;

namespace KataExercisesTests
{
    public class PasswordVerifierTests
    {
        private readonly PasswordVerifier _passwordVerifier;
        
        public PasswordVerifierTests()
        {
            _passwordVerifier = new PasswordVerifier();
        }

        [Fact]
        public void Password_Verifier_Handles_Empty_Password()
        {
            
            Action action = () => _passwordVerifier.Verify(string.Empty);

            Exception exception = Assert.Throws<Exception>(action);
            Assert.Equal("Password must not be null or empty", exception.Message);
        }
        
        [Fact]
        public void Password_Verifier_Handles_Null_Password()
        {
            Action action = () => _passwordVerifier.Verify(null);

            Exception exception = Assert.Throws<Exception>(action);
            Assert.Equal("Password must not be null or empty", exception.Message);
        }
        
        [Fact]
        public void Password_Verifier_Handles_Short_Password()
        {
            Action action = () => _passwordVerifier.Verify("We1eWew");

            Exception exception = Assert.Throws<Exception>(action);
            Assert.Equal("Password must be at least 8 chars", exception.Message);
        }

        [Fact]
        public void Password_Verifier_Throws_When_No_Uppercase()
        {
            Action action = () => _passwordVerifier.Verify("aaaaaaaaaaa1");

            Exception exception = Assert.Throws<Exception>(action);
            Assert.Equal("Password must contain at least one uppercse letter", exception.Message);
        }
        
        
        [Fact]
        public void Password_Verifier_Throws_When_No_Lowercase()
        {
            Action action = () => _passwordVerifier.Verify("AAAAAAAAAAAAA1");

            Exception exception = Assert.Throws<Exception>(action);
            Assert.Equal("Password must contain at least one lowercase letter", exception.Message);
        }
        
        [Fact]
        public void Password_Verifier_Throws_When_No_Number()
        {
            Action action = () => _passwordVerifier.Verify("AAAAaaaaaaaaa");

            Exception exception = Assert.Throws<Exception>(action);
            Assert.Equal("Password must contain at least one number", exception.Message);
        }
    }
}