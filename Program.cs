using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsageOfYield
{
    public class Invoice
    {
        public int Amount { get; set; }
    }
    class Program
    {
        public static List<int> listInts = new List<int>()
        {
            1,2,3,5,6,7
        };
        static void Main(string[] args)
        {
            var nums = GetUsingYield();
            foreach(int num in nums)
                Console.WriteLine(num);

            Console.WriteLine(".................Break.................");

            var invoices = GetInvoices();
            DoubleAmounts(invoices);

            Console.WriteLine(invoices.First().Amount);
            Console.ReadKey();
        }
        private static IEnumerable<Invoice> GetInvoices()
        {
            try
            {
                for (var i = 1; i < 11; i++)
                    yield return new Invoice { Amount = i * 10 };
            }
            finally
            {

            }
        }
        private static void DoubleAmounts(IEnumerable<Invoice> invoices)
        {
            foreach (var invoice in invoices)
                invoice.Amount = invoice.Amount * 2;
        }
        private static IEnumerable<int> GetUsingYield()
        {
            int x = 1;
            Console.WriteLine("in it i: {0}", x);
            foreach (var i in listInts)
                if (i != 0)
                {
                    x++;
                    yield return i;
                }

        }
    }
}
