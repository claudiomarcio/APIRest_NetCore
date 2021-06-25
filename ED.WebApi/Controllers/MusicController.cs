using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using ED.Domain.Model.Models.Entities;
using ED.Domain.Data.Domain.Interfaces.Repository;
using ED.Application.Interfaces;
using System.Threading.Tasks;

namespace webapi.Controllers
{
    [Route("api/")]
    public class MusicController : Controller
    {
        private readonly IEDAppService _appService;

        public MusicController(IEDAppService appService)
        {
            _appService = appService;        
        }
        
        /// <summary>
        /// Obtem todas as musicas
        /// </summary>   
        /// <returns>Objeto contendo musicas.</returns>  
        [HttpGet("[controller]/v1/GetMusics")]
        public async Task<object> GetMusics()
        {
            try
            {                
                return StatusCode(200, await _appService.GetMusicsAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.StackTrace);
            }
        }

        /// <summary>
        /// Obtem todos os generos
        /// </summary>   
        /// <returns>Objeto contendo generos.</returns>  
        [HttpGet("[controller]/v1/GetGender")]
        public async Task<object> GetGenders()
        {
            try
            {
                return StatusCode(200, await _appService.GetGendersAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.StackTrace);
            }
        }


        /// <summary>
        /// Obtem todos os Autores
        /// </summary>   
        /// <returns>Objeto contendo autores.</returns>  
        [HttpGet("[controller]/v1/GetAuthors")]
        public async Task<object> GetAuhtors()
        {
            try
            {
                return StatusCode(200, _appService.GetAuthorsAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.StackTrace);
            }
        }

        /// <summary>
        /// Cria uma nova musica        
        /// </summary>
        /// <param name="music">Objeto Musica</param>
        /// <returns>Objeto contendo dados de uma musica.</returns>  
        [HttpPost("[controller]/v1/SaveMusic")]       
        public async Task<object> SaveMusic([FromBody] Music music)
        {
            try
            {         
                return StatusCode(200, _appService.AddMusicAsync(music));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.StackTrace);
            }
        }

        /// <summary>
        /// Alterar uma musica  
        /// </summary>
        /// <param name="music">Objeto Musica</param>
        /// <returns>Objeto contendo dados de uma musica.</returns>  
        [HttpPut("[controller]/v1/EditMusic")]
        public async Task<object> EditMusic([FromBody] Music music)
        {
            try
            {                                           
                return StatusCode(200, _appService.UpdateMusicAsync(music));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.StackTrace);
            }
        }

    }
}


