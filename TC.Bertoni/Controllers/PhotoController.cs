using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TC.Bertoni.Service.PhotoService;

namespace TC.Bertoni.Controllers
{
    public class PhotoController : Controller
    {
        private PhotoService _photoService = new PhotoService();

        [HttpGet]
        public async Task<ActionResult> GetPhotoByAlbumId(int albumId)
        {
            var allPhotos = await _photoService.GetPhotoAsync(albumId);
            return PartialView("_Photo", allPhotos);
        }
    }
}