using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalAssessment.Data
{
    public class GeogData
    {

        [Required(ErrorMessage = "*")]
        [Column("iso-2")]
        public string iso2 { get; set; }
        [Required(ErrorMessage = "*")]
        public int year { get; set; }
        [Required(ErrorMessage = "*")]
        public double Value { get; set; }
    }
}
