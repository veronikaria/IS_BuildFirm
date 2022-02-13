using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IS_BuildFirm.Models
{
    public class Builder
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле фамілія є обовязковим")]
        [Display(Name = "Фамілія")]
        [Column(TypeName = "nvarchar(100)")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Поле ім'я є обовязковим")]
        [Display(Name = "Ім'я")]
        [Column(TypeName = "nvarchar(100)")]
        public string Firstname { get; set; }

        [Display(Name = "По-батькові")]
        [Column(TypeName = "nvarchar(100)")]
        public string Middlename { get; set; }

        [Display(Name = "Телефон")]
        [Column(TypeName = "nvarchar(100)")]
        public string Phone { get; set; }


        public virtual Speciality Speciality { get; set; }
        public virtual Brigade Brigade { get; set; }
    }
}
