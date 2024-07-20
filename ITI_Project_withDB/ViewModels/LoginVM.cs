using Microsoft.Build.Framework;

namespace ITI_Project_withDB.ViewModels
{
    public class LoginVM
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public bool IsInstructor { get; set; }
    }
}
