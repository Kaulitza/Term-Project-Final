using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Term_Project_Version_1.Models
{
    public class Members
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "Please enter your first and last name using 40 characters or less.")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only alphabetic letters are allowed.")]
        public string name { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Please enter your e-mail address using 50 characters or less.")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        public string email { get; set; }
        [StringLength(50, ErrorMessage = "Please enter your address using 50 characters or less.")]
        public string Address { get; set; }
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only alphabetic letters are allowed.")]
        [Required]
        public string City { get; set; }
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only alphabetic letters are allowed.")]
        public string State { get; set; }
        [Display(Name = "Zipcode")]
        [Column("Zipcode")]
        public string PostalCode { get; set; }
        [Required]
        public string Country { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        internal static int CreateAsync(IQueryable<Members> queryables, int v, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}