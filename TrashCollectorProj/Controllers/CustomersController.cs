﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrashCollectorProj.Data;
using TrashCollectorProj.Models;
using GoogleMaps.LocationServices;

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

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).FirstOrDefault();
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                return View(customer);

            }
        }


        // GET: Customers/Details/5
        public IActionResult Details(int? id)
        {

            var customer = _context.Customers
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                return View(customer);
            }

        }
     
        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,IdentityUserId,FirstName,LastName,PhoneNumber,PickupDay,StreetName,City,State,ZipCode")]Customer customer)
        {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;
            customer.LastPickupDate = default;
            customer.ExtraPickupDate = default;
            customer.SuspendedStartDate = default;
            customer.SuspendedEndDate = default;
            customer.TrashFees = 0;
            customer = GeocodeCustomer(customer);
                _context.Add(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
        }

        // GET: Customers/Edit/5
        public ActionResult Edit()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();

            return View(customer);
        }
        public ActionResult EditPickupDay()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();

            return View(customer);
        }


        public ActionResult ScheduleExtraPickup()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        public ActionResult SuspendService()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit(int id, [Bind("Id,IdentityUserId,FirstName,LastName,PhoneNumber,StreetName,City,State,ZipCode")] Customer customer)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customerToUpdate = _context.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            try
                {
                customerToUpdate.FirstName = customer.FirstName;
                customerToUpdate.LastName = customer.LastName;
                customerToUpdate.PhoneNumber = customer.PhoneNumber;
                customerToUpdate.StreetName = customer.StreetName;
                customerToUpdate.City = customer.City;
                customerToUpdate.State = customer.State;
                customerToUpdate.ZipCode = customer.ZipCode;
                customerToUpdate = GeocodeCustomer(customerToUpdate);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPickupDay(int id, [Bind("PickupDay")] Customer customer)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customerToUpdate = _context.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault(); 
            customerToUpdate.PickupDay = customer.PickupDay;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
           
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ScheduleExtraPickup(int id, [Bind("ExtraPickupDate")] Customer customer)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customerToUpdate = _context.Customers.Where(c => c.IdentityUserId == userId).FirstOrDefault(); 
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

        [HttpPost]
        public ActionResult SuspendService(int id, [Bind("Id,IdentityUserId,FirstName,LastName,PhoneNumber,PickupDay,StreetName,City,State,ZipCode,LastPickupDate,TrashFees,IsSuspended,SuspendedStartDate,SuspendedEndDate,HasExtraPickup,ExtraPickupDate")] Customer customer)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customerToUpdate = _context.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            try
            {
                customerToUpdate.SuspendedStartDate = customer.SuspendedStartDate;
                customerToUpdate.SuspendedEndDate = customer.SuspendedEndDate;
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
        public Customer GeocodeCustomer(Customer customer)
        {
            AddressData address = new AddressData
                {
                    Address = customer.StreetName,
                    City = customer.City,
                    State = customer.State,
                    Zip = customer.ZipCode
                };
            var geocodeRequest = new GoogleLocationService(APIKey.APIKeys);
            var latlong = geocodeRequest.GetLatLongFromAddress(address);

            customer.Latitude = latlong.Latitude;
            customer.Longitude = latlong.Longitude;
            return customer;

        }

    }
  
}
