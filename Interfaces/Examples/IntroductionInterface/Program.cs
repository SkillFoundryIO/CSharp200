using IntroductionInterface;

// note that this code will explode if you don't pick P, V, or A

    ShoppingCart cart = new ShoppingCart();

    Console.Write("(P)ayPal, (V)isa, or (A)CH: ");
    string choice = Console.ReadLine().ToUpper();

    switch(choice)
    {
        case "P":
            cart.Processor = new PayPalProcessor();
            break;
        case "V":
            cart.Processor = new VisaProcessor();
            break;
        case "A":
            cart.Processor = new ACHProcessor();
            break;
    }

    cart.CheckOut();