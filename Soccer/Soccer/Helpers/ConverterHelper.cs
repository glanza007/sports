using Soccer.Data;
using Soccer.Data.Entities;
using Soccer.Models;

namespace Soccer.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _context;
        public ConverterHelper(DataContext context)
        {
            _context = context;            
        }
        public Team ToTeam(TeamViewModel model, string path, bool isNew)
        {
            return new Team
            {
                Id = isNew ? 0 : model.Id,
                ImageUrl = path,
                Name = model.Name
            };
        }

        public TeamViewModel ToTeamViewModel(Team team)
        {
            return new TeamViewModel
            {
                Id = team.Id,
                ImageUrl = team.ImageUrl,
                Name = team.Name
            };
        }
    }
}
