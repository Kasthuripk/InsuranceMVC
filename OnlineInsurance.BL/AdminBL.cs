using System;
using System.Collections.Generic;
using Online_Insurance.Entity;
using Online_Insurance.DAL;
using System.Threading.Tasks;

namespace OnlineInsurance.BL
{
    public class AdminBL
    {
        public static void GetDetails()
        {
            AdminRepository.GetDetails();
        }
        public static void AddDetails(Admin admin)
        {
            AdminRepository.AddDetails(admin);
        }
        public static void GetUsers()
        {
            UserRepository.GetUsers();
        }
        public static void AddUsers(User user)
        {
            UserRepository.AddUser(user);
        }
    }
}

