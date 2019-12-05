namespace adventofcode2019_day4.Part2
{
    public class PasswordValidator
    {
        public bool IsValid(int password)
        {
            var digits = Convert.NumberToDigits(password);

            // It is a six - digit number.
            if (digits.Length != 6) return false;


            // The value is within the range given in your puzzle input.
            // Two adjacent digits are the same(like 22 in 122345).
            if (!HasDoubleDigitsOnly(digits)) return false;

            // Going from left to right, the digits never decrease;
            if (!HasIncreasingDigitsOnly(digits)) return false;

            return true;

        }

        private bool HasDoubleDigitsOnly(int[] digits)
        {
            var nbrOfSameDigits = 1;
            var lastDigit = -1;
            for (var idx = 0; idx < digits.Length; idx++)
            {
                var currentDigit = digits[idx];
                if (lastDigit == currentDigit)
                {
                    nbrOfSameDigits++;
                }
                else
                {
                    if (nbrOfSameDigits == 2)
                        return true;
                    nbrOfSameDigits = 1;
                }
                lastDigit = currentDigit;
            }
            return nbrOfSameDigits==2;
        }
        private bool HasIncreasingDigitsOnly(int[] digits)
        {
            var lastDigit = -1;
            for (var idx = 0; idx < digits.Length; idx++)
            {
                var currentDigit = digits[idx];
                if (lastDigit > currentDigit)
                    return false;
                lastDigit = currentDigit;
            }
            return true;
        }
    }
}