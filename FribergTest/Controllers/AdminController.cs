using FribergTest.Data.Interface;
using FribergTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FribergTest.Controllers
{

    public class AdminController : Controller
    {
        private readonly IAdmin adminRep;

        public AdminController(IAdmin adminRep)
        {
            this.adminRep = adminRep;
        }


        public ActionResult Index(Admin admin)
        {
            ViewBag.Username = $"{admin.AdminUserName} - #{admin.AdminId}";
            return View();
        }
        public ActionResult ListCustomer()
        {
            return View(adminRep.GetAllCustomers());
        }
        public ActionResult ListCar()
        {
            return View(adminRep.GetAllCars());
        }
        public ActionResult ListRent()
        {
            return View(adminRep.GetRents());
        }





        #region DETAILS
        /*** C A R ***/
        public ActionResult DetailsCar(int id)
        {
            return View(adminRep.GetCarById(id));
        }
        public ActionResult DetailsCustomer(int id)
        {
            return View(adminRep.GetCustomerById(id));
        }

        #endregion

        #region CREATE

        /*** CAR ***/
        // GET: 
        public ActionResult CreateCar()
        {
            return View();
        }
        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCar(Car car)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    adminRep.AddCar(car);
                    return RedirectToAction("ListCar");
                }
                else { return View(); }
            }
            catch
            {
                return View();
            }
        }


        /*** CUSTOMER ***/
        // GET: 
        public ActionResult CreateCustomer()
        {
            return View();
        }
        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCustomer(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    adminRep.AddCustomer(customer);
                    return RedirectToAction("Index");
                }
                else { return View(); }
            }
            catch
            {
                return View();
            }
        }

        /*** RENT ***/
        // GET:  
        public ActionResult CreateRent()
        {
            return View();
        }
        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRent(Rent rent)
        {
            try
            {
                var newRent = new Rent();
                newRent.StartDate = rent.StartDate;
                newRent.RenturnDate = rent.RenturnDate;
                newRent.Customer = adminRep.GetCustomerById(rent.Customer.CustomerId);
                newRent.Car = adminRep.GetCarById(rent.Car.CarId);
                adminRep.CreateRent(newRent);
                return RedirectToAction("ListRent");
            }
            catch
            {
                return View();
            }
        }

        #endregion

        #region EDIT 

        /*** C A R ***/
        // GET:
        public ActionResult EditCar(int id)
        {
            if (id == null || adminRep.GetAllCars() == null)
            {
                return NotFound();
            }
            var car = adminRep.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }
        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCar(int id, Car car)
        {
            if (id != car.CarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    adminRep.UpdateCar(car);
                }
                catch (Exception)
                {
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View(car);
        }




        /*** C U S TO M E R ***/
        // GET:
        public ActionResult EditCustomer(int id)
        {
            if (id == null || adminRep.GetAllCustomers() == null)
            {
                return NotFound();
            }
            var customer = adminRep.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    adminRep.UpdateCustomer(customer);
                }
                catch (Exception)
                {
                    return View();
                }
                return RedirectToAction("ListCustomer");
            }
            return View(customer);
        }








        #endregion

        #region DELETE

        /*** C A R ***/
        // GET: AdminController/Delete/5
        public ActionResult DeleteCar(int id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var car = adminRep.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: AdminController/Delete/5
        [HttpPost, ActionName("DeleteCar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCarComnfirmed(int id)
        {
            var car = adminRep.GetCarById(id);
            if (ModelState.IsValid)
            {
                try
                {
                    adminRep.RemoveCar(car);
                }
                catch (Exception)
                {
                    return View();
                }
                return RedirectToAction("ListCar");
            }
            return View(car);
        }


        /*** CUSTOMER ***/
        // GET:
        public ActionResult DeleteCustomer(int id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var customer = adminRep.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: AdminController/Delete/5
        [HttpPost, ActionName("DeleteCustomer")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCustomerComnfirmed(int id)
        {
            var customer = adminRep.GetCustomerById(id);
            if (ModelState.IsValid)
            {
                try
                {
                    adminRep.RemoveCustomer(customer);
                }
                catch (Exception)
                {
                    return View();
                }
                return RedirectToAction("ListCustomer");
            }
            return View(customer);
        }




        #endregion





    }
}
