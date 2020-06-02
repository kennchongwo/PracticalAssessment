using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalAssessment.Data
{
    public class GeoData
    {
        [Key]
        [Required(ErrorMessage = "*")]
        public long GeoDataID { get; set; }

        [Required(ErrorMessage = "*")]
        public string iso2 { get; set; }
        [Required(ErrorMessage = "*")]
        public int year { get; set; }
        [Required(ErrorMessage = "*")]
        public double Value { get; set; }
    }
}
