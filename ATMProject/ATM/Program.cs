using ATM;

public List<Customer> customers = new List<Customer>();
customers.Add(new Customer(1234123412341234, 4325, "Bojan Stojanov", 500));
customers.Add(new Customer(5678567856785678, 1234, "Vlatko Stoimenov", 1000));


while (true)
    {
        Console.Clear();
        Console.WriteLine("Welcome to the ATM app");
        Console.Write("Please enter your card number: ");
        string cardInput = Console.ReadLine();
        long cardNumber;

            if (!long.TryParse(cardInput.Replace("-", ""), out cardNumber))
            {
                Console.WriteLine("Invalid card number format. Please try again.");
                continue;
            }

        Customer currentCustomer = Customer.Find(c => c.CardNumber == cardNumber);

            if (currentCustomer == null)
            {
                Console.WriteLine("Card number not found. Would you like to register a new card? (y/n)");
                if (Console.ReadLine().ToLower() == "y")
                {
                    RegisterNewCustomer();
                    continue;
                }
                Console.WriteLine("Exiting ATM.");
                break;
            }
        Console.Write("Enter Pin: ");
        int pin = int.Parse(Console.ReadLine());

            if (currentCustomer.ValidatePin(pin))
            {
               
                Console.WriteLine($"Welcome {currentCustomer.FullName}!");

                
                while (true)
                {
                    Console.WriteLine("\nWhat would you like to do:");
                    Console.WriteLine("1. Check Balance");
                    Console.WriteLine("2. Cash Withdrawal");
                    Console.WriteLine("3. Cash Deposit");
                    Console.WriteLine("4. Logout");
                    Console.Write("> ");
                    int option = int.Parse(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            Console.WriteLine($"Your current balance is: ${currentCustomer.GetBalance()}");
                            break;

                        case 2:
                            Console.Write("Enter withdrawal amount: ");
                            decimal withdrawalAmount = decimal.Parse(Console.ReadLine());
                            if (currentCustomer.WithdrawCash(withdrawalAmount))
                            {
                                Console.WriteLine($"You withdrew ${withdrawalAmount}. You have ${currentCustomer.GetBalance()} left on your account.");
                            }
                            else
                            {
                                Console.WriteLine("Insufficient funds.");
                            }
                            break;

                        case 3:
                            Console.Write("Enter deposit amount: ");
                            decimal depositAmount = decimal.Parse(Console.ReadLine());
                            currentCustomer.DepositCash(depositAmount);
                            Console.WriteLine($"You deposited ${depositAmount}. Your new balance is ${currentCustomer.GetBalance()}.");
                            break;

                        case 4:
                            Console.WriteLine("Thank you for using the ATM app.");
                            break;

                        default:
                            Console.WriteLine("Invalid option, please try again.");
                            break;
                    }

                   
                    if (option == 4)
                        break;

                    Console.WriteLine("Would you like to perform another action? (y/n)");
                    if (Console.ReadLine().ToLower() != "y")
                        break;
                }
            }
            else
            {
                Console.WriteLine("Incorrect pin. Try again.");
            }
        }
    

    static void RegisterNewCustomer()
{
    Console.WriteLine("\nRegistering new card...");
    Console.Write("Enter your card number: ");
    string cardInput = Console.ReadLine();
    long cardNumber;

    if (!long.TryParse(cardInput.Replace("-", ""), out cardNumber))
    {
        Console.WriteLine("Invalid card number format.");
        return;
    }

    if (Customer.Exists(c => c.CardNumber == cardNumber))
    {
        Console.WriteLine("Card number already in use. Try again.");
        return;
    }

    Console.Write("Enter a pin: ");
    int pin = int.Parse(Console.ReadLine());
    Console.Write("Enter your full name: ");
    string fullName = Console.ReadLine();
    Console.Write("Enter your initial balance: ");
    decimal balance = decimal.Parse(Console.ReadLine());

    Customer.Add(new Customer(cardNumber, pin, fullName, balance));
    Console.WriteLine($"New customer {fullName} registered successfully!");
}


