namespace ConsolePhonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PhoneConverter : IPhoneConverter
    {
        private const string Code = "+359";

        public string Convert(string phoneNumberString)
        {
            StringBuilder result = new StringBuilder();

            foreach (char character in phoneNumberString)
            {
                if (char.IsDigit(character) || (character == '+'))
                {
                    result.Append(character);
                }
            }

            if (result.Length >= 2 && result[0] == '0' && result[1] == '0')
            {
                result.Remove(0, 1);
                result[0] = '+';
            }

            while (result.Length > 0 && result[0] == '0')
            {
                result.Remove(0, 1);
            }

            if (result.Length > 0 && result[0] != '+')
            {
                result.Insert(0, Code);
            }

            return result.ToString();
        }
    }
}
