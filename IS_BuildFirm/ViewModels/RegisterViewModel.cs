using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IS_BuildFirm.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Пошта")]
        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Вік")]
        [Column(TypeName = "int")]
        public int Age { get; set; }


        [Display(Name = "Повторіть пароль")]
        [Required]
        [Compare("Password", ErrorMessage = "Паролі не співпадають")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}
