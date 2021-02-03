using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TC.Bertoni.Service.AlbumService;

namespace TC.Bertoni.Controllers
{
    public class AlbumController : Controller
    {
        private AlbumService albumService = new AlbumService();
        // GET: Album
        public async Task<ActionResult> Index()
        {
            var allAlbums = await albumService.GetAlbumsAsync();
            return View(allAlbums);
        }
    }
}