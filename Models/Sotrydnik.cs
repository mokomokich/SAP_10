using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SAP_10.Models
{
    public class Sotrydnik
    {
        public int SotrydnikId { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Укажите фамилию")]
        public string surname { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Укажите имя")]
        public string name { get; set; }

        [Display(Name = "Отчество")]
        [Required(ErrorMessage = "Укажите Отчество")]
        public string patronymic { get; set; }

        [Display(Name = "Должность")]
        [Required(ErrorMessage = "Укажите должность")]
        public string job_title { get; set; }

        [Display(Name = "Подразделение")]
        [Required(ErrorMessage = "Укажите подразделние")]
        public string subdivision { get; set; }

        [Display(Name = "Дата приема на работу")]
        [Required(ErrorMessage = "Укажите дату приема на работу")]
        public DateTime employment_date { get; set; }

        [Display(Name = "ФИО сотрудника")]
        public string FIO
        {
            get
            {
                return surname + ' ' + name + ' ' +(patronymic is null ? ' ' : (' ' + patronymic));
            }
        }
    }
}
