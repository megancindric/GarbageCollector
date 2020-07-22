using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Geocoding;
using Geocoding.Google;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrashCollectorProj.Data;
using TrashCollectorProj.Models;

namespace TrashCollectorProj.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public IActionResult Index()
        {

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).FirstOrDefault();

            return View(customer);
        }


        // GET: Customers/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _context.Customers
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,IdentityUserId,FirstName,LastName,PhoneNumber,PickupDay,StreetName,City,State,ZipCode")]Customer customer)
        {
            if (ModelState.IsValid)
            {
   
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;
                GeocodeCustomerAsync(customer);
                _context.Add(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).FirstOrDefault();

            return View(customer);
        }
        public ActionResult EditPickupDay()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).FirstOrDefault();

            return View(customer);
        }

        public ActionResult MakePayment()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).FirstOrDefault();

            return View(customer);
        }

        public ActionResult ScheduleExtraPickup()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).FirstOrDefault();

            return View(customer);
        }

        public ActionResult SuspendService()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).FirstOrDefault();

            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit(int id, [Bind("Id,IdentityUserId,FirstName,LastName,PhoneNumber,StreetName,City,State,ZipCode")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var thisUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    customer.IdentityUserId = thisUserId;
                    _context.Customers.Update(customer);
                    _context.SaveChanges();
                }
                catch
                {
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPickupDay(int id, [Bind("PickupDay")] Customer customer)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customerToUpdate = _context.Customers.Where(c => c.IdentityUserId == userId).FirstOrDefault(); 
            customerToUpdate.PickupDay = customer.PickupDay;
            _context.SaveChanges();
                return RedirectToAction(nameof(Index));
           
        }

        [HttpPost]
        public ActionResult MakePayment(Customer customer)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customerToUpdate = _context.Customers.Where(c => c.IdentityUserId == userId).FirstOrDefault();
            var customerPayment = Convert.ToInt32(HttpContext.Request.Form["custPayment"].ToString());
            if (ModelState.IsValid)
            {
                try
                {
                    customerToUpdate.TrashFees -= customerPayment;
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ScheduleExtraPickup(int id, [Bind("HasExtraPickup,ExtraPickupDate")] Customer customer)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customerToUpdate = _context.Customers.Where(c => c.IdentityUserId == userId).FirstOrDefault(); 
            if (ModelState.IsValid)
            {
                try
                {
                    customerToUpdate.ExtraPickupDate = customer.ExtraPickupDate;
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");

            }
            return View(customer);
        }

        [HttpPost]
        public ActionResult SuspendService(int id, [Bind("Id,IdentityUserId,FirstName,LastName,PhoneNumber,PickupDay,StreetName,City,State,ZipCode,LastPickupDate,TrashFees,IsSuspended,SuspendedStartDate,SuspendedEndDate,HasExtraPickup,ExtraPickupDate")] Customer customer)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customerToUpdate = _context.Customers.Where(c => c.IdentityUserId == userId).FirstOrDefault();
            if (ModelState.IsValid)
            {
                try
                {
                    customerToUpdate.SuspendedStartDate = customer.SuspendedStartDate;
                    customerToUpdate.SuspendedEndDate = customer.SuspendedEndDate;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _context.Customers
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
        {
            var customer = _context.Customers.FirstOrDefault(m => m.Id == id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
        public async Task<Customer> GeocodeCustomerAsync(Customer customer)
        {
            IGeocoder geocoder = new GoogleGeocoder() { ApiKey = "AIzaSyDYyltT3d7LeBJDgloGLVzGbNj4ndBOKa8" };

            string addressString = customer.StreetName + " " + customer.City + " " + customer.State + " " + customer.ZipCode;
            IEnumerable<Address> addressToGeocode = await geocoder.GeocodeAsync(addressString);
            customer.Latitude = addressToGeocode.First().Coordinates.Latitude;
            customer.Longitude = addressToGeocode.First().Coordinates.Longitude;
            return customer;

        }

    }
  
}
