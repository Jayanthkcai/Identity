using System;
using System.Security.Cryptography;

namespace JWTKeyGen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            
            var secretKey = KeyGenerator.GenerateSecretKey();
            Console.WriteLine(secretKey);
        }
    }


    public class KeyGenerator
    {
        public static string GenerateSecretKey()
        {
            var key = new byte[32];
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(key);
                return Convert.ToBase64String(key);
            }
        }
    }



}
