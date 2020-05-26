using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace Hahn.ApplicatonProcess.May2020.Domain.Models
{
    public class Applicant
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        [MinLength(5)]
        public string FamilyName { get; set; }
        [Required]
        [MinLength(10)]
        public string Address { get; set; }
        public string CountryOfOrigin { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Range(20, 60)]
        public int Age { get; set; }
        public bool Hired { get; set; }
    }
}