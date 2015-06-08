namespace _02.BankApplication
{
    using System;

    public class LoanAccount : Account, IAccount, IDepositable
    {
        private const int NO_INTEREST_MONTHS_COMPANY = 2;
        private const int NO_INTEREST_MONTHS_INDIVIDUAL = 3;

        public LoanAccount(Customer customer, decimal balance, decimal interestRate)
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
                if (months <= NO_INTEREST_MONTHS_INDIVIDUAL)
                {
                    return 0;
                }
                return base.InterestAmount(months - NO_INTEREST_MONTHS_INDIVIDUAL);
            }
            else if (this.Customer is Company)
            {
                if (months <= NO_INTEREST_MONTHS_COMPANY)
                {
                    return 0;
                }
                return base.InterestAmount(months - NO_INTEREST_MONTHS_COMPANY);
            }
            throw new InvalidOperationException("The customer is neither an individual or a company");
        }
    }
}