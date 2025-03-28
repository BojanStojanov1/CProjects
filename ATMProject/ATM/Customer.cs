using System;
namespace ATM
{
	public class Customer
	{
        public long CardNumber { get; }
        private int Pin { get; }
        public string FullName { get; }
        private decimal Balance { get; set; }

        public Customer(long cardNumber, int pin, string fullName, decimal balance)
        {
            CardNumber = cardNumber;
            Pin = pin;
            FullName = fullName;
            Balance = balance;
        }

     
        public bool ValidatePin(int pin)
        {
            return Pin == pin;
        }

        
        public decimal GetBalance()
        {
            return Balance;
        }

    
        public bool WithdrawCash(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

   
        public void DepositCash(decimal amount)
        {
            Balance += amount;
        }

        internal static void Add(Customer customer)
        {
            throw new NotImplementedException();
        }

        internal static bool Exists(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        internal static Customer Find(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}

