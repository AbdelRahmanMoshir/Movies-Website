using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EXercises.Models;
using System.Data.Entity;
using EXercises.ViewModels;
namespace EXercises.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ViewResult Index()
        {
            var customers = _context.customers.Include(c => c.MembershipType ).ToList();

            return View(customers);
        }
        public ActionResult New ()
        {
            var Membership = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModels
            {
                Customer = new Customers(),
                MembershipType = Membership

            };
            return View("CustomerForm",viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customers customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModels
                {
                    Customer = customer,
                    MembershipType = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if( customer.Id == 0)
            _context.customers.Add(customer);
            else
            {
                var CustomerInDb = _context.customers.Single(c => c.Id == customer.Id);
                    CustomerInDb.Name = customer.Name;
                    CustomerInDb.Birthdate = customer.Birthdate;
                    CustomerInDb.MembershipTypeId = customer.MembershipTypeId;
                    CustomerInDb.IsSubscribedToNewLetter = customer.IsSubscribedToNewLetter;
            
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        public ActionResult Details(int id)
        {
            var customer = _context.customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
        public ActionResult Edit(int Id)
        {
            var customer = _context.customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new NewCustomerViewModels
            {
                Customer = customer,
            MembershipType = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm",viewModel);
        }
    }
}