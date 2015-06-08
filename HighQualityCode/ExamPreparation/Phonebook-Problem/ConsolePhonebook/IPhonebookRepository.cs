namespace ConsolePhonebook
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface that defines a phonebook repository, and has methods for adding, changing and listing its entries.
    /// </summary>
    public interface IPhonebookRepository
    {
        /// <summary>
        /// Adds a new entry to the phone book. 
        /// The entry should specify name and list of 
        /// phones (at least 1 and at most 10). 
        /// The names in the phonebook are unique 
        /// (duplicates are not accepted) and case-insensitive.
        /// Adding phones for same name always performs merging: 
        /// only the non-repeating canonical phones enter in the 
        /// list of phones
        /// </summary>
        /// <param name="name">A string with non-empty English text (less than 200 characters) and cannot contain ",", ":" and "\n", as well as leading or trailing whitespace.</param>
        /// <param name="phoneNumbers">The phone numbers contain only digits, whitespace and the special characters "+", "-", "/", "(" and ")". Phone numbers cannot contain "," and "\n", leading or trailing whitespace. Phone numbers always have of [3..50] digits. Phone numbers could have at most one leading zero.</param>
        /// <returns>True if the entry is new</returns>
        bool AddPhone(string name, IEnumerable<string> phoneNumbers);

        /// <summary>
        /// Changes the specified old phone number in all phonebook entries with a new one
        /// </summary>
        /// <param name="oldPhoneNumber">The phone number that will be replaced.</param>
        /// <param name="newPhoneNumber">The phone number that will replace it.</param>
        /// <returns>How many phones were changed</returns>
        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        /// <summary>
        /// Lists the phonebook repository entries with paging. The page is specified by start index (zero-based) and count.
        /// </summary>
        /// <param name="startIndex">Zero based index of the first entry that will be listed</param>
        /// <param name="count">The amount of entries that will be listed</param>
        /// <returns>An array of the entries that are from the startIndex with the count</returns>
        PhonebookEntry[] ListEntries(int startIndex, int count);
    }
}