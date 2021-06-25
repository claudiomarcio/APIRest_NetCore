using ED.Domain.Model.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ED.Application.Interfaces
{
    public interface IEDAppService : IDisposable
    {
        Task<IEnumerable<Music>> GetMusicsAsync();
        Task<IEnumerable<Gender>> GetGendersAsync();
        Task<IEnumerable<Author>> GetAuthorsAsync();
        Task<Music> AddMusicAsync(Music music);
        Task<Music> UpdateMusicAsync(Music music);
    }
}
