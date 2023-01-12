using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Soccer.Data.Entities
{
    public class Group
    {
        public int Id { get; set; }

        [Display(Name = "Grupo")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        public Tournament Tournament { get; set; }

        public ICollection<GroupDetail> GroupDetails { get; set; }

        public ICollection<Match> Matches { get; set; }
    }
}
