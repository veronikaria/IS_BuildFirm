using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IS_BuildFirm.Models
{
    public class Brigade
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле Назва є обовязковим")]
        [Display(Name = "Назва бригади")]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
    }
}
