using ED.Domain.Model.Models.Entities;
using ED.Domain.Data.Domain.Interfaces.Repository;
using Ed.Infra.Data.Repositories;
using ED.Infra.Data.EntityConfiguration;

namespace ED.Infra.Data.Repositories
{
    public class MusicRepository : RepositoryBase<Music>, IMusicRepository
    {
        private readonly ApplicationDbContext _contex;
        public MusicRepository(ApplicationDbContext contex) : base(contex)
          => _contex = contex;      
        
        public Music UpdateMusic(Music music)
        {
            var model = this.GetById(music.CodMusic);
            model.Name = music.Name;
            model.CodGender = music.CodGender;
            model.CodAuthor = music.CodAuthor;
            this.Update(model);

            return music;

        }
    }
}
