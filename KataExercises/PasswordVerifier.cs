using System;
using System.Linq;

namespace KataExercises
{
    /// <summary>
    /// Verifies a password string
    /// </summary>
    public class PasswordVerifier
    {
        private string _password;
        private bool _result = true;

        private bool Result
        {
            get { return _result && _conditionFailures <= 2; }
        }
        private int _conditionFailures = 0;
        
        public bool Verify(string password)
        {
            _password = password;
            
            return ValidateBase()
                    .ValidateLength()
                    .ValidateUpperCase()
                    .ValidateLowerCase()
                    .ValidateNumeric().Result;
        }
        
        /// <summary>
        /// Handle null or empty strings
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private PasswordVerifier ValidateBase()
        {
            if (string.IsNullOrEmpty(_password))
            {
                _conditionFailures++;
                throw new Exception("Password must not be null or empty");
            }

            return this;
        }
        
        /// <summary>
        /// Check string length
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private PasswordVerifier ValidateLength()
        {
            if (_password.Length < 8)
            {
                _conditionFailures++;
                throw new Exception("Password must be at least 8 chars");
            }

            return this;
        }
        
        /// <summary>
        /// Check the presence of an uppercase char
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private PasswordVerifier ValidateUpperCase()
        {
            if (!_password.Any(char.IsUpper))
            {
                _conditionFailures++;
                throw new Exception("Password must contain at least one uppercse letter");
            }

            return this;
        }
        
        /// <summary>
        /// Check the presence of a lowercase char
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private PasswordVerifier ValidateLowerCase()
        {
            if (!_password.Any(char.IsLower))
            {
                _result = false;
                throw new Exception("Password must contain at least one lowercase letter");
            }

            return this;
        }
        
        /// <summary>
        /// Check the presence of a numeric
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private PasswordVerifier ValidateNumeric()
        {
            if (!_password.Any(char.IsNumber))
            {
                _conditionFailures++;
                throw new Exception("Password must contain at least one number");
            }

            return this;
        }

    }
}