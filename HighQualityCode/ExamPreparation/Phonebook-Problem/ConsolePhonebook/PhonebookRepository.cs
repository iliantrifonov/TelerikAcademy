namespace ConsolePhonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class PhonebookRepository : IPhonebookRepository, IPhonebookRepositoryWithRemove
    {
        private readonly OrderedSet<PhonebookEntry> sortedEntries;
        private readonly Dictionary<string, PhonebookEntry> entriesByName;
        private readonly MultiDictionary<string, PhonebookEntry> entriesByNumber;

        public PhonebookRepository()
        {
            this.sortedEntries = new OrderedSet<PhonebookEntry>();
            this.entriesByName = new Dictionary<string, PhonebookEntry>();
            this.entriesByNumber = new MultiDictionary<string, PhonebookEntry>(false);
        }
        public bool AddPhone(string name, IEnumerable<string> entries)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length > 200 || name.Contains(",") || name.Contains(":") || name.Contains("\n") || (name.Length != name.Trim().Length))
            {
                throw new ArgumentException();
            }

            if (entries.Count() > 10 || entries.Count() < 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            string nameForComparison = name.ToLowerInvariant();
            PhonebookEntry entry;
            bool isNewContact = !this.entriesByName.TryGetValue(nameForComparison, out entry);

            if (isNewContact)
            {
                entry = new PhonebookEntry();
                entry.Name = name;
                entry.PhoneNumbers = new SortedSet<string>();
                this.entriesByName.Add(nameForComparison, entry);

                this.sortedEntries.Add(entry);
            }

            foreach (var phoneEntry in entries)
            {
                this.entriesByNumber.Add(phoneEntry, entry);
            }

            entry.PhoneNumbers.UnionWith(entries);
            return isNewContact;
        }

        public int ChangePhone(string oldNumber, string newNumber)
        {
            var found = this.entriesByNumber[oldNumber].ToList();
            foreach (var entry in found)
            {
                entry.PhoneNumbers.Remove(oldNumber);
                this.entriesByNumber.Remove(oldNumber, entry);

                entry.PhoneNumbers.Add(newNumber);
                this.entriesByNumber.Add(newNumber, entry);
            }

            var changed = found.Count;
            return changed;
        }

        public PhonebookEntry[] ListEntries(int from, int to)
        {
            if (from < 0 || from + to > this.entriesByName.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            var list = new PhonebookEntry[to];

            for (int i = from; i <= from + to - 1; i++)
            {
                PhonebookEntry entry = this.sortedEntries[i];
                list[i - from] = entry;
            }

            return list;
        }

        public void Remove(string phoneNumber)
        {
            if (!IsCanonical(phoneNumber))
            {
                throw new ArgumentException("Invalid phone number");
            }

            if (!this.entriesByNumber.ContainsKey(phoneNumber))
            {
                throw new ArgumentOutOfRangeException("Phone number could not be found");
            }

            List<PhonebookEntry> entriesToRemove = new List<PhonebookEntry>();

            foreach (var entry in this.sortedEntries)
            {
                if (entry.PhoneNumbers.Contains(phoneNumber))
                {
                    entry.PhoneNumbers.Remove(phoneNumber);

                    if (entry.PhoneNumbers.Count == 0)
                    {
                        entriesToRemove.Add(entry);
                    }
                }
            }

            for (int i = 0; i < entriesToRemove.Count; i++)
            {
                this.sortedEntries.Remove(entriesToRemove[i]);
                this.entriesByName.Remove(entriesToRemove[i].Name.ToLowerInvariant());
            }

            foreach (var dictItem in this.entriesByName)
            {
                if (dictItem.Value.PhoneNumbers.Contains(phoneNumber))
                {
                    dictItem.Value.PhoneNumbers.Remove(phoneNumber);
                }
            }

            this.entriesByNumber.Remove(phoneNumber);
        }

        private bool IsCanonical(string phonenumber)
        {
            if (phonenumber[0] != '+')
            {
                return false;
            }

            for (int i = 1; i < phonenumber.Length; i++)
            {
                if (!char.IsNumber(phonenumber[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}