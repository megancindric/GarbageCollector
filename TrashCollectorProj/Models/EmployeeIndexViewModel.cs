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
        public SelectList DayOfWeekList { get; set; }

        public DayOfWeek SelectedDay { get; set; }

    }
}
