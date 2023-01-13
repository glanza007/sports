using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Soccer.Data.Entities
{
    public class Team
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        [Display(Name = "Logo")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Logo")]
        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl)
            ? null            
            : $"https://localhost:7130/{ImageUrl.Substring(1)}";

        public ICollection<User> Users { get; set; }
    }
}
