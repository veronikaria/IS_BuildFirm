using System;
using System.ComponentModel.DataAnnotations;

namespace IS_BuildFirm.ViewModels
{
    public class LoginViewModel
    {
        public string ReturnUrl { get; set; }
        [Display(Name = "Пошта")]
        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}
