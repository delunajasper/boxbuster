using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BoxBuster.Models;
using System.Data.Entity;
using BoxBuster.ViewModels;

namespace BoxBuster.Controllers
{
    public class CustomersController : Controller
    {
        //accessing db
        private ApplicationDbContext _BbDbContext;


        //initialise in ctor
        public CustomersController()
        {
                _BbDbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _BbDbContext.Dispose();
        }

        //customer form
        //[Authorize(Roles = "ManageDb")]
        public ActionResult New()
        {
            //mmbrship dropdown
            var membershipTypes = _BbDbContext.MembershipTypes.ToList();

            //initialise view model with customer and mmbrship type.

            var viewModel = new NewCustomerViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
     
            return View("CustomerForm",viewModel);
        }

        //creating form
        //*add data annotation on entities
        //*use model state to change flow of program; if not valid return same view
        //*add validation messages to form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            //get access to validation data, to change application flow
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes =  _BbDbContext.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            //add cstomr to Db
            if(customer.Id == 0)
            _BbDbContext.Customers.Add(customer);

            else
            {   //single method used; if given customer not found will invoke exception
                var DbCustomer = _BbDbContext.Customers.Single(c => c.Id == customer.Id);

                //update properties based on form values.
                DbCustomer.Name = customer.Name;
                DbCustomer.DoB = customer.DoB;
                DbCustomer.MembershipTypeId = customer.MembershipTypeId;
                DbCustomer.Subscription = customer.Subscription;
                DbCustomer.Phone = customer.Phone;
                DbCustomer.Email = customer.Email;
            }

            _BbDbContext.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

       




        // GET: Customers
        public ViewResult Index()
        {
            //admin rights.
          ///  if (User.IsInRole("ManageDb"))
                //return View("Index");

            //else
            {
              //  return View("StaffIndex");
            }

            return View("Index");

        }


        //edit customer
        public ActionResult Edit(int id)
        {
            var customer = _BbDbContext.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _BbDbContext.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }




        
        public ActionResult Details(int id)
        {
            var customer = _BbDbContext.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();
            else
            {
                return View(customer);
            }
        }




     }//end of controller
 }//end of namespace