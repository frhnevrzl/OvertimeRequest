using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Handler
{
    public class Hashing
    {
        private static string GenerateSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt();
        }
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, GenerateSalt());
        }
        public static bool ValidatePassword(string password, string correcthash)
        {
            return BCrypt.Net.BCrypt.Verify(password, correcthash);
        }
    }
}
