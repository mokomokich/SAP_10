using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SAP_10.Models
{
    public class Vacation
    {
        public int VacationId { get; set; }

        [Display(Name = "Тип отпуска")]
        [Required(ErrorMessage = "Укажите тип отпуска")]
        public string vacation_type { get; set; }

        [Display(Name = "Оплата отпуска")]
        [Required(ErrorMessage = "Укажите оплату отпуска")]
        public string vacation_pay { get; set; }

        [Display(Name = "льготы по отпуску")]
        [Required(ErrorMessage = "Укажите льготы по отпуску")]
        public string holiday_benefits { get; set; }

    }
}
