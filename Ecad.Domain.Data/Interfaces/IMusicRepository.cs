using ED.Domain.Data.Interfaces.Repositories.RepositoryBase;
using ED.Domain.Model.Models.Entities;

namespace ED.Domain.Data.Domain.Interfaces.Repository
{
    public interface IMusicRepository : IRepositoryBase<Music>
    {
        Music UpdateMusic(Music music);
    }
}
