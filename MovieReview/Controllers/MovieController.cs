using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieReview.Repository;
using MovieReview.Request;

namespace MovieReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository repository;
        public MovieController(IMovieRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet("language")]
        public IActionResult Language()
        {
            return Ok(repository.AllLanguages());
        }
        [HttpPost("addlanguage")]
        public IActionResult AddLanguage(AddLanguageRequest data)
        {
            return Ok(repository.AddLanguages(data));
        }

        [HttpGet("moviename")]
        public IActionResult MovieByLanguage(int languageid)
        {
            return Ok(repository.MoviesByLanguageID(languageid));
        }
        [HttpPost("addmovie")]
        public IActionResult AddMovie(AddMovieRequest data)
        {
            return Ok(repository.AddMovie(data));
        }
        [HttpPut("updatemovie")]
        public IActionResult UpdateMovie(UpdateMovieRequest data)
        {
            return Ok(repository.UpdateMovie(data));
        }
        [HttpGet("review")]
        public IActionResult ReviewByMovie(int movieId)
        {
            return Ok(repository.ViewReview(movieId));
        }
        [HttpPost("addreview")]
        public IActionResult AddReview(AddReviewRequest data)
        {
            return Ok(repository.AddReviews(data));
        }
    }
}
