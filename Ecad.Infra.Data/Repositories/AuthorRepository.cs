using Domain.Models.Entities;
using Ecad.Domain.Data.Domain.Interfaces.Repository;
using Infra.EntityConfiguration;


namespace Infra.Repositories
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        private readonly ApplicationDbContext _contex;
        public AuthorRepository(ApplicationDbContext contex) : base(contex)
          => _contex = contex;             
    }
}
