using Soccer.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Soccer.Models
{
    public class TeamViewModel:Team
    {
        [Display(Name = "Logo")]
        public IFormFile LogoFile { get; set; }
    }
}
