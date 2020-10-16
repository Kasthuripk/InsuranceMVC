using System;
using System.Collections.Generic;
using System.Linq;
using Online_Insurance.Entity;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Online_Insurance.DAL
{
  public  class AdminRepository
    {
        public static  List<Admin> GetDetails()
        {
            using(AdminContext context = new AdminContext())
            {
            return context.Detail.ToList();
        }
             }
       
        public static void AddDetails(Admin admin)
        {
            using (AdminContext context = new AdminContext())
            {
                
                SqlParameter insuranceNumber = new SqlParameter("@insuranceNumber", admin.insuranceNumber);
                SqlParameter insuranceType = new SqlParameter("@insuranceType", admin.insuranceType);
                SqlParameter GST = new SqlParameter("@GST", admin.GST);
                var data = context.Database.ExecuteSqlCommand("Admin_Insert @insuranceNumber,@insuranceType,@GST", insuranceNumber, insuranceType, GST);
                //context.Detail.Add(admin);
                context.SaveChanges();
            }
        }
           public static void DeleteDetails(Admin admin)
       {
            using (AdminContext context = new AdminContext())
            {
              Admin details = context.Detail.Where(model => model.insuranceId == admin.insuranceId).SingleOrDefault();
              context.Detail.Attach(details);
               context.Detail.Remove(details);
              context.SaveChanges();
            }
        }
        public static void UpdateDetails(Admin admin)
        {
            using (AdminContext context = new AdminContext())
            {
                context.Entry(admin).State = EntityState.Modified;
                context.SaveChanges();
            }
            }
        public static Admin GetInsuranceDetailsById(int insuranceId)
        {
            using (AdminContext context = new AdminContext())
            {
                Admin admin = context.Detail.Where(model => model.insuranceId == insuranceId).SingleOrDefault();
                return admin;
            }
        }

    }
}
