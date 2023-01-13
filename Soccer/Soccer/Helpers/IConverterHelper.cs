using Soccer.Data.Entities;
using Soccer.Models;

namespace Soccer.Helpers
{
    public interface IConverterHelper
    {
        Team ToTeam(TeamViewModel model, string path, bool isNew);

        TeamViewModel ToTeamViewModel(Team team);
    }
}
