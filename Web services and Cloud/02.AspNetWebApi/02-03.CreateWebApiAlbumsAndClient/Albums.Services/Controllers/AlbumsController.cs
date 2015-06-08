namespace Albums.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Albums.Data;
    using Albums.Models;

    public class AlbumsController : ApiController
    {
        private IAlbumsData data;

        public AlbumsController()
            : this(new AlbumsData())
        {
        }

        public AlbumsController(IAlbumsData data)
        {
            this.data = data;
        }

        [HttpGet]
        public HttpResponseMessage GetAllAlbums()
        {
            try
            {
                var albums = data.Albums
                    .All()
                    .Select(album => new
                    { 
                        Title = album.Title, 
                        Year = album.Year,
                        Producer = album.Producer 
                    });

                return Request.CreateResponse(HttpStatusCode.OK, albums);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.ServiceUnavailable);
            }
        }

        [HttpGet]
        public HttpResponseMessage GetAlbumById(int id)
        {
            try
            {
                var albumToGet = data.Albums
                    .All().Where(album => album.Id == id)
                    .Select(album => new 
                    {
                        Title = album.Title,
                        Year = album.Year,
                        Producer = album.Producer 
                    })
                    .FirstOrDefault();

                if (albumToGet == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK, albumToGet);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.ServiceUnavailable);
            }
        }

        [HttpPost]
        public HttpResponseMessage AddAlbum([FromBody]Album album)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

                var albumToAdd = new Album() { Title = album.Title, Producer = album.Producer, Year = album.Year };
                this.data.Albums.Add(albumToAdd);

                foreach (var artist in album.Artists)
                {
                    var currentArtist = new Artist() { Name = artist.Name, Country = artist.Country, DateOfBirth = artist.DateOfBirth };
                    this.data.Artists.Add(currentArtist);
                    albumToAdd.Artists.Add(currentArtist);

                    foreach (var song in artist.Songs)
                    {
                        var currentSong = new Song() 
                        { Title = song.Title, 
                            Year = song.Year, 
                            Genre = song.Genre, 
                            AlbumId = albumToAdd.Id, 
                            ArtistId = currentArtist.Id 
                        };

                        this.data.Songs.Add(currentSong);
                        currentArtist.Songs.Add(currentSong);
                    }
                }

                this.data.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.ServiceUnavailable);
            }
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody]string newTitle)
        {
            try
            {
                var albumToUpdate = this.data.Albums.All().Where(album => album.Id == id).FirstOrDefault();

                if (albumToUpdate == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                albumToUpdate.Title = newTitle;
                this.data.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.ServiceUnavailable);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var albumToDelete = this.data.Albums.All().Where(album => album.Id == id).FirstOrDefault();

                if (albumToDelete == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                this.data.Albums.Delete(albumToDelete);
                this.data.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.ServiceUnavailable);
            }
        }
    }
}
