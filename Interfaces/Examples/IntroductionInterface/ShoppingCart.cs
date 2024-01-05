namespace IntroductionInterface
{
    public class ShoppingCart
    {
        // assume these have data
        private string _accountNumber;
        private decimal _amount;

        public IPaymentProcessor Processor { get; set; }

        public bool CheckOut()
        {
            return Processor.ProcessPayment(_accountNumber, _amount);
        }
    }
}
