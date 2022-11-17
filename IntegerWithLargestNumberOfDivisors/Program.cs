using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace IntegerWithLargestNumberOfDivisors
{
    public class Program
    {
        static void Main(string[] args)
        {
            NumberOfDivisorsCalculationApplication numberOfDivisorsCalculationApplication = new NumberOfDivisorsCalculationApplication();

            numberOfDivisorsCalculationApplication.Launch();
        }
    }
}