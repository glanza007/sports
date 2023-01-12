using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Soccer.Data.Entities
{
    public class Match
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = false)]
        public DateTime Date { get; set; }

        [Display(Name = "Local")]
        public Team Local { get; set; }

        [Display(Name = "Visita")]
        public Team Visitor { get; set; }

        [Display(Name = "Local")]
        public int? GoalsLocal { get; set; }

        [Display(Name = "Visita")]
        public int? GoalsVisitor { get; set; }

        [Display(Name = "Cerrado?")]
        public bool IsClosed { get; set; }

        public Group Group { get; set; }

        public ICollection<Prediction> Predictions { get; set; }
    }
}
