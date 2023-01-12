using Microsoft.AspNetCore.Identity;
using Soccer.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Soccer.Data.Entities
{
    public class User : IdentityUser
    {
        [Display(Name = "DNI")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Document { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string FirstName { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LastName { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string Address { get; set; }

        [Display(Name = "Foto")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Foto")]
        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl)
            ? null
        //: $"https://localhost:7289/images/user.png";
            : $"https://localhost:7289/{ImageUrl.Substring(1)}";

        [Display(Name = "Rol")]
        public UserType UserType { get; set; }

        [Display(Name = "Login")]
        public LoginType LoginType { get; set; }

        [Display(Name = "Equipo Favorito")]
        public Team Team { get; set; }

        public ICollection<Prediction> Predictions { get; set; }

        [Display(Name = "Usuario")]
        public string FullName => $"{FirstName} {LastName}";

        [Display(Name = "Usuario")]
        public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";

        public int Points => Predictions == null ? 0 : Predictions.Sum(p => p.Points);
    }
}
