using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();

        //
        // GET: /Store/

        public ActionResult Index()
        {
            var genres = storeDB.Genres.ToList();
            return View(genres);

            // return "Hello from Store.Index()";

            //var genres = new List<Genre>
            //{
            //    new Genre {Name = "Disco"},
            //    new Genre {Name = "Jazz"},
            //    new Genre {Name = "Rock"}
            //};

            //return View(genres);
        }

        
        public ActionResult Browse(string genre)
        {
            // string message = HttpUtility.HtmlEncode("Store.Browse, Genre = " + genre);
            // string message = "Store.Browse, Genre = " + genre; //Convert.ToInt32(genre);
            // return message;
            //var genreModel = new Genre {Name = genre};
            //return View(genreModel);

            var genreModel = storeDB.Genres.Include("Albums")
                .Single(g => g.Name == genre);

            return View(genreModel);
        }


        public ActionResult Details(int id)
        {
            //var album = new Album { Title = "Album = " + id };
            //return View(album);

            var album = storeDB.Albums.Find(id);

            return View(album);
        }

        protected override void Dispose(bool disposing)
        {
            if (storeDB != null)
            {
                storeDB.Dispose();
            }
            
            base.Dispose(disposing);
        }
    }
}
