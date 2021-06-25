using ED.Domain.Data.Domain.Interfaces.Repository;
using ED.Domain.Model.Models.Entities;
using Ed.Infra.Data.Repositories;
using ED.Infra.Data.EntityConfiguration;

namespace ED.Infra.Data.Repositories
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        private readonly ApplicationDbContext _contex;
        public AuthorRepository(ApplicationDbContext contex) : base(contex)
          => _contex = contex;             
    }
}
