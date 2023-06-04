using System.ComponentModel.DataAnnotations;

namespace RunoLandingPage.Models
{
    public class Request
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        [Display(Name= "Name")]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Enter Surname")]
        [Display(Name = "Surname")]
        [StringLength(60)]
        public string? Surname { get; set; }

        [Display(Name = "Company name")]
        [StringLength(60)]
        public string? Company { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }
    }
}
