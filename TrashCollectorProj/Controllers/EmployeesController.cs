using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrashCollectorProj.Data;
using TrashCollectorProj.Models;

namespace TrashCollectorProj.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public IActionResult Index()
        {
            EmployeeIndexViewModel viewModel = new EmployeeIndexViewModel();
            viewModel.DayOfWeekList = new SelectList(new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" });
            viewModel.SelectedDay = DateTime.Now.DayOfWeek.ToString();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentEmployee = _context.Employees.Where(s => s.IdentityUserId == userId).FirstOrDefault();
            var extraPickupCustomers = _context.Customers.Where(s => s.ExtraPickupDate != default).ToList();
            viewModel.Customers = _context.Customers.Where(s => s.ZipCode == currentEmployee.ZipCode && s.PickupDay == viewModel.SelectedDay).ToList();
            foreach (Customer customer in extraPickupCustomers)
            {
                if (customer.ZipCode == currentEmployee.ZipCode && customer.ExtraPickupDate.DayOfWeek.ToString() == viewModel.SelectedDay)
                {
                    viewModel.Customers.Add(customer);

                }
            }

            return View(viewModel);

        }

        [HttpPost]
        public IActionResult Index(EmployeeIndexViewModel viewModel)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentEmployee = _context.Employees.Where(s => s.IdentityUserId == userId).FirstOrDefault();
            var extraPickupCustomers = _context.Customers.Where(s => s.ExtraPickupDate != default).ToList();
            viewModel.Customers = _context.Customers.Where(s => s.ZipCode == currentEmployee.ZipCode && s.PickupDay == viewModel.SelectedDay).ToList();
            foreach (Customer customer in extraPickupCustomers)
            {
                if (customer.ZipCode == currentEmployee.ZipCode && customer.ExtraPickupDate.DayOfWeek.ToString() == viewModel.SelectedDay)
                {
                    viewModel.Customers.Add(customer);

                }
            }
            return View(viewModel);

        }



        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,IdentityUserId,FirstName,LastName,ZipCode")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                employee.IdentityUserId = userId;
                _context.Add(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", employee.IdentityUserId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", employee.IdentityUserId);
            return View(employee);
        }

        public async Task<IActionResult> ConfirmPickup(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            return View(customer);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", employee.IdentityUserId);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmPickup(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var customerToUpdate = _context.Customers.Where(s => s.Id == id).SingleOrDefault();

                if (HasExtraPickup(customer) && customer.LastPickupDate != DateTime.UtcNow.Date)
                //First check if today is an extra pickup day (& trash has not been collected today)
                {
                    if (customer.ExtraPickupDate.DayOfWeek == DateTime.UtcNow.DayOfWeek)
                    {
                        customerToUpdate.LastPickupDate = DateTime.UtcNow;
                        customerToUpdate.TrashFees += 30;
                        customerToUpdate.ExtraPickupDate = default;
                        _context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else if (customer.PickupDay == DateTime.UtcNow.DayOfWeek.ToString() && customer.LastPickupDate != DateTime.UtcNow.Date)
                {
                    customerToUpdate.LastPickupDate = DateTime.UtcNow;
                    customerToUpdate.TrashFees += 30;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                //Then check if today is a regular pickup day (& trash has not been collected today)
            }
            return View(customer);

        }




        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        public async Task<IActionResult> DeleteCustomer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(e => e.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
        public bool IsSuspended(Customer customer)
        {
            var todaysDate = DateTime.Today.Date;
            var customerStartDate = customer.SuspendedStartDate.Date;
            var customerEndDate = customer.SuspendedEndDate.Date;
            int startToday = DateTime.Compare(customerStartDate, todaysDate);
            int endToday = DateTime.Compare(customerEndDate, todaysDate);
            if (startToday <= 0 && endToday >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool HasExtraPickup(Customer customer)
        {
            if (customer.ExtraPickupDate != default)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPost, ActionName("DeleteCustomer")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCustomerConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}  
