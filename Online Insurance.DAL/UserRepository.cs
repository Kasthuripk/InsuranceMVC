using System.Collections.Generic;
using Online_Insurance.Entity;
using System.Linq;

namespace Online_Insurance.DAL
{
    public class UserRepository
    {
        public static List<User> GetUsers()
        {
            using (AdminContext context = new AdminContext())
            {
                return context.List.ToList();
            }
        }
        public static void AddUser(User user)
        {
            using (AdminContext context = new AdminContext())
            {
                context.List.Add(user);
                context.SaveChanges();
            }
        }
        public string SignIn(User user)
        {
            using (AdminContext context = new AdminContext())
            {
                List<User> signin = context.List.ToList();
                foreach (var value in signin)
                {
                    if (user.phoneNumber == value.phoneNumber && user.password == value.password)
                    {
                        return value.role;
                    }
                }
                return "not";
            }
        }

    }
}
