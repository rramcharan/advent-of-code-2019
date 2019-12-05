namespace adventofcode2019_day4
{
    public class Password
    {
        public static int NumberOfValidInRange(int start, int last)
        {
            var numberOfValid = 0;
            for (var password=start; password<=last; password++)
            {
                if (new PasswordValidator().IsValid(password)) numberOfValid++;
            }
            return numberOfValid;
        }
    }
}