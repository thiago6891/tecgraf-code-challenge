using System;

namespace Registration.Services
{
    public class RegistrationService
    {
        public static char GetDigit(string registration)
        {
            if (!RegistrationService.IsFormatValid(registration))
                throw new FormatException();

            int sum = 0;
            for (int i = 0, factor = 5; i < registration.Length; i++, factor--)
                sum += registration[i] * factor;
            
            var modulo = sum % 16;

            if (modulo < 10) return (char)('0' + modulo);
            return (char)('A' + modulo - 10);
        }

        public static bool IsFormatValid(string registration)
        {
            if (registration.Length != 4)
                return false;

            int regInt = Convert.ToInt32(registration);
            if (regInt < 0 || 9999 < regInt)
                return false;
            
            return true;
        }
    }
}