namespace ConsolePhonebook
{
    public interface IPhonebookRepositoryWithRemove : IPhonebookRepository
    {
        void Remove(string phoneNumber);
    }
}
