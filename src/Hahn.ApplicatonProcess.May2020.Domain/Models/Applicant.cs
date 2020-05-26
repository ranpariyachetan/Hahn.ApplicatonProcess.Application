using System.ComponentModel.DataAnnotations;

namespace Hahn.ApplicatonProcess.May2020.Domain.Models
{
    public class Applicant
    {
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
        
        [Required]
        public string CountryOfOrigin { get; set; }
       
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        
        [Range(20, 60)]
        public int Age { get; set; }
       
        public bool Hired { get; set; }
    }
}