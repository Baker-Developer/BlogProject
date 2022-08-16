using System.ComponentModel.DataAnnotations;

namespace BlogProject.ViewModels
{
    public class ContactMe
    {
        [Required]
        [StringLength(75, ErrorMessage = "The {0} must be at least {2} and at the most {1} characters long.", MinimumLength = 2)]
        public string Name { get; set; }


        [Required]
        [EmailAddress]
        [StringLength(75, ErrorMessage = "The {0} must be at least {2} and at the most {1} characters long.", MinimumLength = 2)]
        public string Email { get; set; }


        [Phone]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} and at the most {1} characters long.", MinimumLength = 2)]
        public string PhoneNumber { get; set; }


        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at the most {1} characters long.", MinimumLength = 2)]
        public string Subject { get; set; }


        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and at the most {1} characters long.", MinimumLength = 2)]
        [Required]
        public string Message { get; set; }


    }
}
