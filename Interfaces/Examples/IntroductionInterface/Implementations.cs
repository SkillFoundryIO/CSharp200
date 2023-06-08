/*
 * Note, all of these implementations are in one file for convenience.
 * In a real project you would give each their own class file.
 */
namespace IntroductionInterface
{
    public class PayPalProcessor : IPaymentProcessor
    {
        public string APIKey { get; set; }

        public bool ProcessPayment(string accountNumber, decimal amount)
        {
            Console.WriteLine("Processed Paypal");
            return true;
        }
    }

    public class VisaProcessor : IPaymentProcessor
    {
        public string APIKey { get; set; }

        public bool ProcessPayment(string accountNumber, decimal amount)
        {
            Console.WriteLine("Processed Visa");
            return true;
        }
    }

    public class ACHProcessor : IPaymentProcessor
    {
        public string APIKey { get; set; }

        public bool ProcessPayment(string accountNumber, decimal amount)
        {
            Console.WriteLine("Processed ACH");
            return true;
        }
    }
}
