using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019_day4
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Convert
    {
        public static int[] NumberToDigits(int number)
        {
            List<int> listOfInts = new List<int>();
            if (number == 0)
            {
                listOfInts.Add(0);
            }
            else
            {
                while (number > 0)
                {
                    listOfInts.Add(number % 10);
                    number = number / 10;
                }
            }
            listOfInts.Reverse();
            return listOfInts.ToArray();
        }


    }
}