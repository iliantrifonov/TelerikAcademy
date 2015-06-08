using _01.CreateDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.UsingTransactionsGetMoney
{
    /// <summary>
    /// Extend the project from the previous exercise and add a new table TransactionsHistory with fields (Id, CardNumber, TransactionDate, Ammount) containing information about all money retrievals on all accounts.
    /// Modify the program logic so that it saves historical information (logs) in the new table after each successful money withdrawal.
    /// What should the isolation level be for the transaction?
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            // Entity framework works with transactions by default.
            var context = new AtmContext();
            Console.WriteLine(context.CardAccounts.Where(c => c.CardNumber == "0000011111").First().CardCash);
            bool paid = GetMoney(context, "0000011111", "1234", 200m);
            Console.WriteLine(paid);
            Console.WriteLine(context.CardAccounts.Where(c => c.CardNumber == "0000011111").First().CardCash);
        }

        /// <summary>
        /// Using transactions write a method which retrieves some money (for example $200) from certain account. 
        /// The retrieval is successful when the following sequence of sub-operations is completed successfully:
        /// A query checks if the given CardPIN and CardNumber are valid.
        /// The amount on the account (CardCash) is evaluated to see whether it is bigger than the requested sum (more than $200).
        /// The ATM machine pays the required sum (e.g. $200) and stores in the table CardAccounts the new amount (CardCash = CardCash - 200).
        /// </summary>
        private static bool GetMoney(AtmContext context, string cardNumber, string pin, decimal amount)
        {
            try
            {
                if (pin.Length != 4 || cardNumber.Length != 10)
                {
                    return false;
                }

                if (context.CardAccounts.Where(c => c.CardNumber == cardNumber).ToList().Count() != 1)
                {
                    return false;
                }

                var account = context.CardAccounts.Where(c => c.CardNumber == cardNumber).First();

                if (account.CardCash < amount)
                {
                    return false;
                }

                account.CardCash -= amount;

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            context.TransactionsHistorys.Add(new TransactionsHistory() { Amount = amount, CardNumber = cardNumber, TransactionDate = DateTime.Now });
            context.SaveChanges();

            return true;
        }
    }
}
