using System.ComponentModel.DataAnnotations;

namespace Soccer.Data.Entities
{
    public class Prediction
    {
        public int Id { get; set; }

        public Match Match { get; set; }

        public User User { get; set; }

        [Display(Name = "Local")]
        public int? GoalsLocal { get; set; }

        [Display(Name = "Visita")]
        public int? GoalsVisitor { get; set; }

        public int Points { get; set; }
    }
}
