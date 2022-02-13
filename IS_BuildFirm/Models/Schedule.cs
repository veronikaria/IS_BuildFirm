using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IS_BuildFirm.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Опис")]
        [Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; }

        [Display(Name = "Початкова дата")]
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Кінцева дата")]
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
        
        [Display(Name = "Адреса")]
        [Column(TypeName = "nvarchar(100)")]
        public string Address { get; set; }

        [ForeignKey("Brigade")]
        public int BrigadeId { get; set; }
        public virtual Brigade Brigade { get; set; }
    }
}
