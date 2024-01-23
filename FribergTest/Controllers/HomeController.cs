using FribergTest.Data.Interface;
using FribergTest.Data.Repository;
using FribergTest.Models;
using FribergTest.ViewModels;
//using FribergTest.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FribergTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHome homeRep;
        public HomeController(IHome homeRep)
        {
            this.homeRep = homeRep;
        }

        public ActionResult Index()
        {
            return View();
        }


    
        public ActionResult ShowCars()
        {
            return View(homeRep.GetRentableCars());
        }


        public ActionResult LogInCustomer()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogInCustomer(Customer customer)
        {
            if (customer != null)
            {
                ViewBag.Wrong = ""; 
                var theCustomer = homeRep.GetCustomerByEmail(customer.CustomerEmail); // letar email
                if (theCustomer != null)
                {
                    if (theCustomer.CustomerPassword == customer.CustomerPassword) // letar lösen
                    {
                        // TODO: Hur får jag theCustomer-objekt vidare ?
                        return RedirectToAction("Index", "Customer", theCustomer); // inloggad 
                    }
                    else
                    {
                        ViewBag.Wrong += "Fel lösenord";
                        return View();
                    }
                }
            }
            ViewBag.Wrong += "Fel email";
            return View();
        }

        public ActionResult LogInAdmin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogInAdmin(Admin admin)
        {
            if (admin != null)
            {
                ViewBag.Wrong = "";
                var theAdmin = homeRep.GetAdminByUsername(admin.AdminUserName); // letar username
                if (theAdmin != null)
                {
                    if (theAdmin.AdminPassword == admin.AdminPassword) // letar lösen
                    {
                        return RedirectToAction("Index", "Admin", theAdmin); // inloggad 
                    }
                    else
                    {
                        ViewBag.Wrong += "Fel lösenord";
                        return View();
                    }
                }
            }
            ViewBag.Wrong += "Fel användarnamn";
            return View();
        }


        public ActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCustomer(Customer customer)
        {
            ViewBag.AddedSuccess = "";
            try
            {
                if (ModelState.IsValid)
                {
                    homeRep.AddCustomer(customer);
                    ViewBag.AddedSuccess += $"Tack {customer.CustomerFirstName}! Du kan nu logga in och boka bil.";
                    return View();
                    //return RedirectToAction("LogInCustomer");
                }
                else { return View(); }
            }
            catch
            {
                return View();
            }
        }


        public ActionResult DetailsCar(int id)
        {
            return View(homeRep.GetCarById(id));
        }


        public ActionResult Book(int id)
        {
            var car = homeRep.GetCarById(id);
            var customer = new Customer();
            var rent = new Rent();
            var rentvm = new RentCustomerCarViewModel();
            rentvm.Car = car;
            rentvm.Customer = customer;
            rentvm.Rent = rent;
            return View(rentvm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Book(RentCustomerCarViewModel rentvm)
        {
            var customer = homeRep.GetCustomerById(rentvm.Customer.CustomerId);
            var car = homeRep.GetCarById(rentvm.Car.CarId);

            var theRent = new Rent();
            theRent.Car = car;
            theRent.Customer = customer;
            theRent.StartDate = rentvm.Rent.StartDate;
            theRent.RenturnDate = rentvm.Rent.RenturnDate;
            homeRep.AddRent(theRent);
            return RedirectToAction("BookintCompleted", "Home", theRent);
        }




        //TODO: for inte fram all info <- Ska man ha ViewModel?
        public ActionResult BookintCompleted(Rent rent)
        {
            return View(rent);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
