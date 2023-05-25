using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace SAP_10.Models
{
    public class Document
    {
        public int DocumentId { get; set; }

        [Display(Name = "Номер документа")]
        [Required(ErrorMessage = "Укажите номер документа")]
        public string code_document { get; set; }

        [Display(Name = "Дата регистрации")]
        [Required(ErrorMessage = "Укажите дату регистрации")]
        public DateTime registration_date { get; set; }

        [Display(Name = "Дата начала отпуска")]
        [Required(ErrorMessage = "Укажите дату гачала отпуска")]
        public DateTime holiday_start_date { get; set; }

        [Display(Name = "Дата окончания отпуска")]
        [Required(ErrorMessage = "Укажите дату окончания отпуска")]
        public DateTime holiday_end_date { get; set; }


        [Display(Name = "Код сотрудника")]
        [Required(ErrorMessage = "Укажите код сотрудника")]
        public int F_Code_Vacation { get; set; }
        [ForeignKey("F_Code_Vacation")]
        public Vacation Vacation { get; set; }


        [Display(Name = "Код отпуска")]
        [Required(ErrorMessage = "Укажите код отпуска")]
        public int F_Code_Sotrydnik { get; set; }
        [ForeignKey("F_Code_Sotrydnik")]
        public Sotrydnik Sotrydnik { get; set; }
    }
}
