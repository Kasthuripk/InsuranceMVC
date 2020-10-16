using System.Collections.Generic;
using Online_Insurance.Entity;
using Online_Insurance.DAL;
using OnlineInsurance.BL;
using System.Web.Mvc;
using Online_Insurance.Models;


namespace Online_Insurance.Controllers
{    [Authorize]
    public class AdminController : Controller
    {
        AdminRepository adminRepository = new AdminRepository();
      [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult DisplayDetails()
        {
            IEnumerable<Admin> admin = AdminRepository.GetDetails();
            ViewData["admin"] = admin;
            return View();

        }

        [HttpGet]
        public ActionResult AddDetails()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult AddDetails(InsuranceDetails insurance)
        {
            if (ModelState.IsValid)
            {
                Admin admin = new Admin();
                admin.insuranceId = insurance.insuranceId;
                admin.insuranceNumber = insurance.insuranceNumber;
                admin.insuranceType = insurance.insuranceType;
                admin.GST = insurance.GST;
                AdminBL.AddDetails(admin);
                return RedirectToAction("DisplayDetails");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditDetails(int insuranceId)
        {
            Admin admin = AdminRepository.GetInsuranceDetailsById(insuranceId);
            return View(admin);
        }
        [HttpPost]
        [ActionName("EditDetails")]
        [ValidateAntiForgeryToken()]
        public ActionResult EditDetails(InsuranceDetails insure)
        {
            Admin admin = new Admin();

         admin.insuranceId = insure.insuranceId;
            admin.insuranceNumber = insure.insuranceNumber;
            admin.insuranceType = insure.insuranceType;
            admin.GST = insure.GST;
            AdminRepository.UpdateDetails(admin);
            return RedirectToAction("DisplayDetails");
        }
        [HttpGet]
        public ActionResult DeleteDetails(int insuranceId)
        {
            Admin admin = AdminRepository.GetInsuranceDetailsById(insuranceId);
            return View(admin);
        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult DeleteDetails(InsuranceDetails insure)
        {
            Admin admin = new Admin();
            admin.insuranceId = insure.insuranceId;
            AdminRepository.DeleteDetails(admin);
            return RedirectToAction("DisplayDetails");
        }

    }
}
  