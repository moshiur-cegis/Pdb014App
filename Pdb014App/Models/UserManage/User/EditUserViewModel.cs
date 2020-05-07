using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Pdb014App.Models.UserManage.User;

namespace Pdb014App.Models.UserManage.User
{
    public class EditUserViewModel
    {
        
            public EditUserViewModel()
            {
                Claims = new List<string>();
                Roles = new List<string>();
            }

            public string Id { get; set; }

            [Required]
            public string UserName { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [Phone]
            public string PhoneNumber { get; set; }

            [Required]
            [Display(Name = "User Activation Status Id")]
            public int? UserActivationStatusId { get; set; }

            [Display(Name = "Email Confirmation Status")]
            public bool EmailConfirmed { get; set; }





        //public string City { get; set; }

        public List<string> Claims { get; set; }

            public IList<string> Roles { get; set; }
        
    }
}
