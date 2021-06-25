using ED.Domain.Data.Interfaces.Repositories.RepositoryBase;
using ED.Domain.Model.Models.Entities;
using System.Threading.Tasks;

namespace ED.Domain.Data.Domain.Interfaces.Repository
{
    public interface IMusicRepository : IRepositoryBase<Music>
    {
        Task<Music> UpdateMusicAsync(Music music);
    }
}
