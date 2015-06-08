namespace _02.BankApplication
{
    public class DepositAccount : Account, IAccount, IWithdrawable, IDepositable
    {
        private const decimal MINIMAL_BALANCE = 1000;

        public DepositAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public override decimal InterestAmount(int months)
        {
            if (this.Balance < MINIMAL_BALANCE && this.Balance > 0) //Deposit accounts have no interest if their balance is positive and less than 1000.
            {
                return 0;
            }
            return base.InterestAmount(months);
        }

        public void Withdraw(decimal amount)
        {
            this.Balance -= amount;
        }
    }
}