using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollectorProj.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int PhoneNumber { get; set; }

        [Required]
        public string PickupDay { get; set; }
        [Required]
        public string StreetName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public int ZipCode { get; set; }
        public DateTime LastPickupDate { get; set; }
        public double TrashFees { get; set; }

        public DateTime SuspendedStartDate { get; set; }

        public DateTime SuspendedEndDate { get; set; }

        public DateTime ExtraPickupDate { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Customer()
        {
            LastPickupDate = default;
            ExtraPickupDate = default;
            SuspendedStartDate = default;
            SuspendedEndDate = default;
            Latitude = default;
            Longitude = default;
            TrashFees = 0;
        }

    }
}
