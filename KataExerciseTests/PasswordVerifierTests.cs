using System;
using Xunit;
using KataExercises;

namespace KataExercisesTests
{
    public class PasswordVerifierTests
    {
        [Fact]
        public void Password_Verifier_Handles_Empty_Password()
        {
            PasswordVerifier verifier = new PasswordVerifier();

            Action action = () => verifier.Verify(string.Empty);

            Exception exception = Assert.Throws<Exception>(action);
            Assert.Equal("Password must not be null or empty", exception.Message);
        }
        
        [Fact]
        public void Password_Verifier_Handles_Null_Password()
        {
            PasswordVerifier verifier = new PasswordVerifier();

            Action action = () => verifier.Verify(null);

            Exception exception = Assert.Throws<Exception>(action);
            Assert.Equal("Password must not be null or empty", exception.Message);
        }
        
        [Fact]
        public void Password_Verifier_Handles_Short_Password()
        {
            PasswordVerifier verifier = new PasswordVerifier();

            Action action = () => verifier.Verify("We1eWew");

            Exception exception = Assert.Throws<Exception>(action);
            Assert.Equal("Password must be at least 8 chars", exception.Message);
        }

        [Fact]
        public void Password_Verifier_Throws_When_No_Uppercase()
        {
            PasswordVerifier verifier = new PasswordVerifier();

            Action action = () => verifier.Verify("aaaaaaaaaaa1");

            Exception exception = Assert.Throws<Exception>(action);
            Assert.Equal("Password must contain at least one uppercse letter", exception.Message);
        }
        
        
        [Fact]
        public void Password_Verifier_Throws_When_No_Lowercase()
        {
            PasswordVerifier verifier = new PasswordVerifier();

            Action action = () => verifier.Verify("AAAAAAAAAAAAA1");

            Exception exception = Assert.Throws<Exception>(action);
            Assert.Equal("Password must contain at least one lowercase letter", exception.Message);
        }
        
        [Fact]
        public void Password_Verifier_Throws_When_No_Number()
        {
            PasswordVerifier verifier = new PasswordVerifier();

            Action action = () => verifier.Verify("AAAAaaaaaaaaa");

            Exception exception = Assert.Throws<Exception>(action);
            Assert.Equal("Password must contain at least one number", exception.Message);
        }
    }
}