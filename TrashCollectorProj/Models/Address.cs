using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollectorProj.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CustomerAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]

        public int ZipCode { get; set; }

    }
}
