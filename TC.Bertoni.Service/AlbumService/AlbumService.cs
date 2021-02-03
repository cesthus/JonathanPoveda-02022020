using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC.Bertoni.Interface;
using TC.Bertoni.Interface.Models;
using TC.Bertoni.Service.Common;

namespace TC.Bertoni.Service.AlbumService
{
    public class AlbumService : IAlbumService
    {
        protected static RestClient _restClient = new RestClient();
        string baseUrl = @"https://jsonplaceholder.typicode.com/";
        public async Task<List<AlbumDTO>> GetAlbumsAsync()
        {
            try
            {
                List<AlbumDTO> response = await _restClient.GetListAsync<AlbumDTO>(baseUrl + "albums");
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AlbumDTO> GetAlbumAsync(int albumId)
        {
            try
            {
                AlbumDTO response = await _restClient.GetAsync<AlbumDTO>(baseUrl + "albums/" + albumId);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
