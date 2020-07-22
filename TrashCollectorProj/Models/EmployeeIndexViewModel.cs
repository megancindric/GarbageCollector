using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrashCollectorProj.Controllers;

namespace TrashCollectorProj.Models
{
    public class EmployeeIndexViewModel
    {
        public List<Customer> Customers { get; set; }

        public SelectList DayOfWeekList = new SelectList(new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" });

        public string SelectedDay { get; set; }

    }
}
