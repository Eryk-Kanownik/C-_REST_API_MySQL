using System.ComponentModel.DataAnnotations;

namespace C__REST_API_MySQL.Models
{
    //This is how you create models
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name field cannot be empty!")]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name field cannot be empty!")]
        [StringLength(maximumLength:50,MinimumLength = 3)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email field cannot be empty!")]
        [StringLength(maximumLength: 50, MinimumLength = 5)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password field cannot be empty!")]
        [StringLength(maximumLength: 50, MinimumLength = 5)]
        public string Password { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
