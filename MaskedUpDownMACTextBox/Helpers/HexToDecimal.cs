using System;

namespace MaskedUpDownMACTextBox.Helpers
{
    class HexToUDecimal
    {
        public static Int64 ParseLong(string hexLine)
        {
            try
            {
                return Int64.Parse(hexLine, System.Globalization.NumberStyles.HexNumber);
            }
            catch
            {
                throw new Exception("Invalid hex");
            }
        }
    }
}
