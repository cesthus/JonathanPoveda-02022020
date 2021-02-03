using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC.Bertoni.Interface;
using TC.Bertoni.Interface.Models;
using TC.Bertoni.Service.Common;

namespace TC.Bertoni.Service.PhotoService
{
    public class PhotoService : IPhotoService
    {
        protected static RestClient _restClient = new RestClient();
        string baseUrl = @"https://jsonplaceholder.typicode.com/";

        public async Task<List<PhotoDTO>> GetPhotoAsync(int albumId)
        {
            try
            {
                List<PhotoDTO> response = await _restClient.GetListAsync<PhotoDTO>(baseUrl + $"albums/{albumId}/photos");
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PhotoDTO>> GetPhotosAsync()
        {
            try
            {
                List<PhotoDTO> response = await _restClient.GetListAsync<PhotoDTO>(baseUrl + "photos");
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
