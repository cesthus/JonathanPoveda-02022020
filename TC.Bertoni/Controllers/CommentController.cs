using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TC.Bertoni.Service.CommentService;

namespace TC.Bertoni.Controllers
{
    public class CommentController : Controller
    {
        private CommentService _commentService;
        public CommentController(CommentService photoService)
        {
            _commentService = photoService;
        }

        // GET: Comment by photo id
        public async Task<ActionResult> GetCommentsByPhoto(int photoId)
        {
            var comments = await _commentService.GetCommentAsync(photoId);
            return View(comments);
        }
    }
}