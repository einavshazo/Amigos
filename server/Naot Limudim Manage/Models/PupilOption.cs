using System;
using System.ComponentModel.DataAnnotations;

namespace Naot_Limudim_Manage.Models
{
    public class PupilOption
    {
        public int ID { get; set; }
        [Display(Name = "מ-")]
        public DateTime Start { get; set; }
        [Display(Name = "עד-")]
        public DateTime End { get; set; }
        [Display(Name = "תלמיד")]
        public int PupilID { get; set; }
        public virtual Pupil Pupil { get; set; }
    }
}
