using FribergTest.Data.Interface;
using FribergTest.Models;
using FribergTest.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FribergTest.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomer cusRep;
        public CustomerController(ICustomer cusRep)
        {
            this.cusRep = cusRep;
        }


        public ActionResult Index(Customer customer)
        {
            ViewBag.User = $"{customer.CustomerFirstName} {customer.CustomerLastName}";
            return View(customer);
        }
        public ActionResult BackToIndex(Customer customer)
        {
            Customer theCustomer = cusRep.GetCustumer(customer.CustomerId);
            ViewBag.User = $"{theCustomer.CustomerFirstName} {theCustomer.CustomerLastName}";
            return RedirectToAction("Index", theCustomer); 
        }


        // TODO: Kolla om det är bättre med ViewModel här ?
        public ActionResult History(int id)
        {
            var rents = cusRep.GetRentHistory(id);
            return View(rents);
        }



        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = cusRep.GetCustumer(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    cusRep.UpdateCustomer(customer);
                }
                catch (Exception)
                {
                    return View();
                }
                return RedirectToAction("Index", customer);

            }
            return View(customer);
        }




        // TODO: Radera vadå...?
        public ActionResult Delete(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }




    }
}
