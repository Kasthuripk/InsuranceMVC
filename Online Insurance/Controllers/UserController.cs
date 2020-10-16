using System;
using System.Collections.Generic;
using Online_Insurance.Entity;
using Online_Insurance.DAL;
using OnlineInsurance.BL;
using System.Web.Mvc;
using Online_Insurance.Models;

namespace Online_Insurance.Controllers
{ 
    public class UserController : Controller
    {
       
        UserRepository userRepository = new UserRepository();

        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult Display()
        {
          IEnumerable<User> user = UserRepository.GetUsers();
            ViewData["user"] = user;
            return View();
        }

        [ErrorHandle()]
        public ViewResult ErrorChecking()
        {
            throw new Exception("Exception was thrown");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Create")]
       [ValidateAntiForgeryToken()]
        public ActionResult SignUp(CustomerDetail customer)
        {
            if (ModelState.IsValid)
            {
                var data = AutoMapper.Mapper.Map<CustomerDetail, User>(customer);
                //User user = new User();
                //user.customerId = customer.customerId;
                //user.customerName = customer.customerName;
                //user.gender = customer.gender;
                //user.age = customer.age;
                //user.Address = customer.Address;
                //user.phoneNumber = customer.phoneNumber;
                //user.dateOfBirth = customer.dateOfBirth;
                //user.mailId = customer.mailId;
                //user.password = customer.password;
                //user.annualIncome = customer.annualIncome;
                //user.role = "User";
                AdminBL.AddUsers(data);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ActionName("SignIn")]
        [ValidateAntiForgeryToken()]
        
        public ActionResult SignIn_1(SignInDetails signin)
        {
            if (ModelState.IsValid)
            {
                var data = AutoMapper.Mapper.Map<SignInDetails, User>(signin);
                string role = userRepository.SignIn(data);
                if (role == "User")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (role == "Admin")
                {
                    return RedirectToAction("DisplayDetails", "Admin");
                }
                else
                {
                    return RedirectToAction("SignIn", "User");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult SignOut()
        {
            return RedirectToAction("Index","User");
        }
    }
}
