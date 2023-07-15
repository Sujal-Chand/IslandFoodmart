using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Xml.Linq;
using IslandFoodmart.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IslandFoodmart.Views.Home
{
    public class ContactUsModel : PageModel
    {
        private readonly UserManager<DatabaseUser> _userManager;
        private readonly SignInManager<DatabaseUser> _signInManager;
        public ContactUsModel(
            UserManager<DatabaseUser> userManager,
            SignInManager<DatabaseUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Email { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "First Name")]
            public string firstName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Last Name")]
            public string lastName { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
        }

        private async Task LoadASync(DatabaseUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Email = userName;


            Input = new InputModel
            {
                firstName = user.FirstName,
                lastName = user.LastName,
                PhoneNumber = phoneNumber
            };
        }
    }
}
