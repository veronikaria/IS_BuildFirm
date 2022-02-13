using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IS_BuildFirm.Models
{
    public class Speciality
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле Назва є обовязковим")]
        [Display(Name = "Назва спеціальності")]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Display(Name = "Опис спеціальності")]
        [Column(TypeName = "nvarchar(200)")]
        public string Description { get; set; }
    }
}
