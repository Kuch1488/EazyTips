using System;
using System.Text.RegularExpressions;

namespace EazyTips.Repository
{
    [Serializable]
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int IsAdmin { get; set; }

        public static bool isPhoneValid(string Phone)
        {
            return Regex.IsMatch(Phone, @"^([7]\d{10}$)");
        }

        public static bool isEmailValid(string Email)
        {
            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.
                        [0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            return regex.Match(Email).Success;
            /*try
            {
                MailAddress mailAddress = new MailAddress(Email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }*/
        }
    }
}
