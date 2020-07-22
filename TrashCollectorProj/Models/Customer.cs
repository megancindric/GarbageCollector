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
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, MaxLength(10)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Regular Pickup Day")]

        public string PickupDay { get; set; }

        [Required]
        [Display(Name = "Street Name")]
        public string StreetName { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required, MaxLength(5)]
        [Display(Name = "Zip Code")]

        public string ZipCode { get; set; }

        [DataType(DataType.Date)]
        public DateTime LastPickupDate { get; set; }

        private double trashFees = 50;

        [Display(Name = "Current Balance")]
        public double TrashFees 
        { 
            get { return trashFees; }
            set { trashFees = value; }
        }

        [DataType(DataType.Date)]
        [Display(Name = "Suspension Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]

        public DateTime SuspendedStartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]

        [Display(Name = "Suspension End Date")]
        public DateTime SuspendedEndDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]

        [Display(Name = "Extra Pickup Date")]
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
