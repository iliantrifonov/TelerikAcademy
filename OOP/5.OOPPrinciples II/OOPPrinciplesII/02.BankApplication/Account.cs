namespace _02.BankApplication
{
    using System;

    public abstract class Account : IAccount
    {
        private Customer customer;
        private decimal interestRate;

        public Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.InterestRate = interestRate;
            this.Balance = balance;
        }

        public decimal Balance { get; set; }

        public Customer Customer
        {
            get
            {
                return this.customer;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.customer = value;
            }
        }

        public decimal InterestRate
        {
            get
            {
                return this.interestRate;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Interest rate cannot be negative");
                }
                this.interestRate = value;
            }
        }

        public virtual decimal InterestAmount(int months)
        {
            return months * this.InterestRate;
        }

        public override string ToString()
        {
            return this.Customer.Name + " Interest rate: " + this.InterestRate + " Balance: " + this.Balance;
        }
    }
}