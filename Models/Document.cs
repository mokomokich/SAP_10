using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAP_10.Models
{
    public class Document
    {
        public int DocumentId { get; set; }

        public string code_document { get; set; }
        public DateTime registration_date { get; set; }
        public DateTime holiday_start_date { get; set; }
        public DateTime holiday_end_date { get; set; }

        public int F_Code_Vacation { get; set; }
        [ForeignKey("F_Code_Vacation")]
        public Vacation Vacation { get; set; }

        public int F_Code_Sotrydnik { get; set; }
        [ForeignKey("F_Code_Sotrydnik")]
        public Sotrydnik Sotrydnik { get; set; }
    }
}
