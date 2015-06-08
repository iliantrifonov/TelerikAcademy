namespace _02.BankApplication
{
    using System;

    public class MortgageAccount : Account, IAccount, IDepositable
    {
        private const int MONTHS_IN_YEAR = 12;

        public MortgageAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public override decimal InterestAmount(int months)
        {
            if (this.Customer is Individual)
            {
                if (months <= MONTHS_IN_YEAR / 2)
                {
                    return 0;
                }
                return base.InterestAmount(months - (MONTHS_IN_YEAR / 2));
            }
            else if (this.Customer is Company)
            {
                if (months <= MONTHS_IN_YEAR)
                {
                    return base.InterestAmount(months) / 2;
                }
                return (base.InterestAmount(MONTHS_IN_YEAR) / 2) + base.InterestAmount(months - MONTHS_IN_YEAR);
            }
            throw new InvalidOperationException("The customer is neither an individual nor a company");
        }
    }
}