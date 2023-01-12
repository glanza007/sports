using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Soccer.Data.Entities
{
    public class Tournament
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha Inicio")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha Final")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Activo?")]
        public bool IsActive { get; set; }

        [Display(Name = "Logo")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Logo")]
        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl)
            ? null            
            : $"https://localhost:7289/{ImageUrl.Substring(1)}";

        public ICollection<Group> Groups { get; set; }
    }
}
