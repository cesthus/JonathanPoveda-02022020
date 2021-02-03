using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC.Bertoni.Interface.Models;

namespace TC.Bertoni.Interface
{
    public interface ICommentService
    {
        Task<List<CommentDTO>> GetCommentAsync(int photoId);
        Task<List<CommentDTO>> GetCommentsAsync();
    }
}
