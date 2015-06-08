namespace _02.BankApplication
{
    //A bank holds different types of accounts for its customers: deposit accounts, loan accounts and mortgage accounts. Customers could be individuals or companies.
    //All accounts have customer, balance and interest rate (monthly based). Deposit accounts are allowed to deposit and with draw money. Loan and mortgage accounts can only deposit money.
    //All accounts can calculate their interest amount for a given period (in months). In the common case its is calculated as follows: number_of_months * interest_rate.
    //Loan accounts have no interest for the first 3 months if are held by individuals and for the first 2 months if are held by a company.
    //Deposit accounts have no interest if their balance is positive and less than 1000.
    //Mortgage accounts have ½ interest for the first 12 months for companies and no interest for the first 6 months for individuals.
    //Your task is to write a program to model the bank system by classes and interfaces. You should identify the classes, interfaces, base classes and abstract actions and implement the calculation of the interest functionality through overridden methods.

    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            var accounts = new List<Account>();
            accounts.Add(new DepositAccount(new Individual("Pesho"), 800m, 1.3m));
            accounts.Add(new DepositAccount(new Individual("Gosho"), 1800m, 1.3m));
            accounts.Add(new LoanAccount(new Company("ZOOMA OOD"), 800m, 1.3m));
            accounts.Add(new LoanAccount(new Individual("Zoomata"), 800m, 1.3m));
            accounts.Add(new MortgageAccount(new Individual("Mortgage guy"), 800m, 1.3m));
            accounts.Add(new MortgageAccount(new Company("Mortgage OOD"), 800m, 1.3m));

            int months = 3;
            PrintResultFromMonths(accounts, months);

            months = 6;
            PrintResultFromMonths(accounts, months);

            months = 12;
            PrintResultFromMonths(accounts, months);

            months = 24;
            PrintResultFromMonths(accounts, months);
        }

        private static void PrintResultFromMonths(List<Account> accounts, int months)
        {
            foreach (var acc in accounts)
            {
                Console.WriteLine("The amount of interest for {0} is {1}, for {2} months", acc, acc.InterestAmount(months), months);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}