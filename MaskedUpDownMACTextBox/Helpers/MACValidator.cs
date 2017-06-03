using System.Text.RegularExpressions;

namespace MaskedUpDownMACTextBox.Helpers
{
    class MACValidator
    {
        private const string macRegex = @"^([0-9A-Fa-f_]{2}[:-]){5}([0-9A-Fa-f_]{2})$";

        public static string Validate(string MAC, string oldMAC)
        {

            bool ok = Regex.IsMatch(MAC, macRegex);
            if (ok) return MAC;
            else return oldMAC;
        }
    }
}
