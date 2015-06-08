namespace _11.CreateDatabaseWithUsersAndGroups
{
    using System;
    using System.Linq;
    using System.Transactions;

    /// <summary>
    /// Create a database holding users and groups. Create a 
    /// transactional EF based method that creates an user and 
    /// puts it in a group "Admins". In case the group "Admins" 
    /// do not exist, create the group in the same transaction. 
    /// If some of the operations fail (e.g. the username already 
    /// exist), cancel the entire transaction.
    /// 
    /// IMPORTANT: RUN THE .sql file first!
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            AddUser("Ivancho");
            AddUser("Penka");
        }

        public static void AddUser(string userName)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (GroupsEntities entities = new GroupsEntities())
                {
                    Group adminGroup = new Group { GroupName = "Admins" };
                    if (entities.Groups.Count(x => x.GroupName == "Admins") == 0)
                    {
                        entities.Groups.Add(adminGroup);
                        entities.SaveChanges();
                        scope.Complete();
                    }
                    else
                    {
                        if (entities.Users.Count(x => x.UserName == userName) > 0)
                        {
                            Console.WriteLine("User already exists.");
                            scope.Dispose();
                        }

                        Group currentgroup = entities.Groups.Where(x => x.GroupName == "Admins").First();

                        User newUser = new User()
                        {
                            UserName = userName,
                            GroupID = currentgroup.GroupID
                        };

                        entities.Users.Add(newUser);

                        entities.SaveChanges();

                        scope.Complete();
                    }
                }
            }
        }
    }
}
