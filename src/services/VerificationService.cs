using System;
using System.Text.RegularExpressions;

namespace Service
{
    class VerificationService
    {
        public bool verifyEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Email is empty, please enter a valid email.");
                return false;
            } 
    
            bool verifyEmail = Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);

            if (!verifyEmail)
            {
                Console.WriteLine("Email is not valid, please enter a valid email.");
                return verifyEmail;
            }
            return verifyEmail;
        }

        public bool verifyUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                Console.WriteLine("Username is empty, please enter a valid username.");
                return false;
            }

            return true;
        }

        public bool verifyPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Password is empty, please enter a valid password.");
                return false;
            }

            if (password.Length < 8)
            {
                Console.WriteLine("Password must be at least 8 characters.");
                return false;
            }

            if (!password.Any(char.IsDigit))
            {
                Console.WriteLine("Password must contain at least 1 digit.");
                return false;
            }

            if (!password.Any(char.IsLower))
            {
                Console.WriteLine("Password must contain at least 1 lowercase letter.");
                return false;
            }

            if (!password.Any(char.IsUpper))
            {
                Console.WriteLine("Password must contain at least 1 uppercase letter.");
                return false;
            }

            if (!password.Any(char.IsPunctuation) && !password.Any(char.IsSymbol))
            {
                Console.WriteLine("Password must contain at least 1 special character.");
                return false;
            }

            return true;
        }
    }
}