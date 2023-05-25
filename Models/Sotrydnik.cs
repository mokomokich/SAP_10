using System;

namespace SAP_10.Models
{
    public class Sotrydnik
    {
        public int SotrydnikId { get; set; }

        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public string job_title { get; set; }
        public string subdivision { get; set; }
        public DateTime employment_date { get; set; }
    }
}
