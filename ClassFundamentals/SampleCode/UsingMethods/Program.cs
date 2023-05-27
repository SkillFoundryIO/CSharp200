using UsingMethods;

Account a1 = new Account();

a1.SetName("Acme, Inc.");
a1.Deposit(500M);

if(a1.Withdraw(300))
{
    Console.WriteLine($"The new balance for {a1.GetName()} is {a1.GetBalance()}");
}

if(a1.Withdraw(400, true))
{
    Console.WriteLine($"The new balance for {a1.GetName()} is {a1.GetBalance()}");
}