using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC.Bertoni.Interface;
using TC.Bertoni.Interface.Models;
using TC.Bertoni.Service.Common;

namespace TC.Bertoni.Service.CommentService
{
    public class CommentService : ICommentService
    {
        protected static RestClient _restClient = new RestClient();
        string baseUrl = @"https://jsonplaceholder.typicode.com/";

        public  async Task<List<CommentDTO>> GetCommentAsync(int photoId)
        {
            try
            {
                List<CommentDTO> response = await _restClient.GetListAsync<CommentDTO>(baseUrl + $"photos/{photoId}/comments");
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<CommentDTO>> GetCommentsAsync()
        {
            try
            {
                List<CommentDTO> response = await _restClient.GetListAsync<CommentDTO>(baseUrl + "photos");
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
