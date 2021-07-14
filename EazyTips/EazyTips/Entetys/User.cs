using System;
using System.Text.RegularExpressions;

namespace EazyTips.Repository
{
    [Serializable]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int IsAdmin { get; set; }
        public string FullName { get; set; }

        public static bool isPhoneValid(string Phone)
        {
            return Regex.Match(Phone, @"^([7]\d{10}$)").Success;
        }

        public static bool isEmailValid(string Email)
        {
            Regex regex = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
            return regex.Match(Email).Success;
        }
    }
}
