namespace _02.BankApplication
{
    public interface IAccount
    {
        decimal Balance { get; set; }

        Customer Customer { get; set; }

        decimal InterestRate { get; set; }

        decimal InterestAmount(int months);
    }
}