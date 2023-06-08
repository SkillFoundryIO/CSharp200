namespace IntroductionInterface
{
    public interface IPaymentProcessor
    {
        string APIKey { get; set; }
        bool ProcessPayment(string accountNumber, decimal amount);
    }
}
