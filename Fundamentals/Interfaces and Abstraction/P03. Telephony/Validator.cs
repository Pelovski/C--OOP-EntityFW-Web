namespace P03._Telephony
{
    public static class Validator
    {
        public static string PhoneNumberIsIncorrect(string phoneNumber, string type)
        {
           return phoneNumber.ToArray().All(x => Char.IsDigit(x)) ? $"{type}... {phoneNumber}" : "Invalid number!";
        }

        public static string WebsiteIsIncorrect(string website)
        {
            return website.ToArray().All(x => !Char.IsDigit(x)) ? $"Browsing: {website}" : "Invalid URL!";
        }
    }
}
