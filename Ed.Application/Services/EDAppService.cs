using ED.Application.Interfaces;
using ED.Domain.Data.Domain.Interfaces.Repository;
using ED.Domain.Model.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ED.Application.Services
{
    public class EDAppService : DisposableObject, IEDAppService
    {
        private readonly IMusicRepository _musicRepository;
        private readonly IGenderRepository _genderRepository;
        private readonly IAuthorRepository _authorRepository;

        public EDAppService
        (
            IMusicRepository musicRepository,
            IGenderRepository genderRepository,
            IAuthorRepository authorRepository
        ) : base(new IDisposable[] { })
        {
            _musicRepository = musicRepository;
            _genderRepository = genderRepository;
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<Music>> GetMusicsAsync()
        {
            var listMusics = new List<Music>();
            var allMusics = await _musicRepository.GetAllAsync();
            foreach (var item in allMusics.ToList())
            {
                item.AuthorName =  _authorRepository.GetByIdAsync(item.CodAuthor).Result.Name;
                item.GenderName = _genderRepository.GetByIdAsync(item.CodGender).Result.Name;
                item.Author = null;
                item.Gender = null;
                listMusics.Add(item);
            }

            return listMusics;
        }
        public async Task<IEnumerable<Gender>> GetGendersAsync() => await _genderRepository.GetAllAsync();
        public async Task<IEnumerable<Author>> GetAuthorsAsync() => await _authorRepository.GetAllAsync();
        public async Task<Music> UpdateMusicAsync(Music music) => await _musicRepository.UpdateMusicAsync(music);
        public async Task<Music> AddMusicAsync(Music music) => await _musicRepository.AddAsync(music);

    }
}
