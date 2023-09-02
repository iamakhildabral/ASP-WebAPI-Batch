using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using TestAPI.Data;
using TestAPI.Model;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("api/Movie")]
    public class MovieController : ControllerBase
    {
        private readonly AppDbContext _db;

        public MovieController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            return Ok(_db.Movies.ToList());
        }

        [HttpGet]
        [Route("/{name}")]
        public IActionResult GetMovie(string name)
        {
            Object? movie = _db.Movies.FirstOrDefault(x => x.Name == name);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpPost]
        [Route("/name")]
        public async Task<IActionResult> PostMovie([FromBody] List<Movie> movies)
        {
            if (movies == null || !movies.Any())
            {
                return BadRequest();
            }
            var movieListtoSave = movies.Select(movie => new Movie
            {
                Name = movie.Name,
                Description = movie.Description,
                ReleaseDate = movie.ReleaseDate,
                Reviews = movie.Reviews,
            }).ToList();

            try
            {
                await _db.Movies.AddRangeAsync(movieListtoSave);
                await _db.SaveChangesAsync();
                return Ok(movies);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);

            }

        }

        [HttpPut]
        [Route("/updateOne")]
        public async Task<IActionResult> UpdateMovie([FromBody] Movie movie)
        {
            IActionResult result = CommonUpdateLogic(movie);

            return result;
        }

        [HttpPut]
        [Route("/updateMany")]
        public async Task<IActionResult> updateMany([FromBody] List<Movie> movies)
        {
            if (movies == null || !movies.Any())
            {
                return StatusCode(400, "Bad Content");
            }
            foreach (Movie movie in movies)
            {
                try
                {
                    IActionResult result = CommonUpdateLogic(movie);
                }
                catch
                {
                    return StatusCode(500, "Issue in updating the movie");
                }


            }
            return Ok(movies);
        }

        // implementing a common update logic for the movie
        private IActionResult CommonUpdateLogic(Movie movie)
        {
            if (movie == null || movie.Name == null)
            {
                return BadRequest("Bad Content");
            }
            Movie? movieInList = _db.Movies.FirstOrDefault(x => x.Name == movie.Name);
            if (movieInList != null)
            {
                movieInList.Description = movie.Description;
                movieInList.ReleaseDate = movie.ReleaseDate;
                movieInList.Reviews = movie.Reviews;

            }
            else
            {
                return NotFound("Movie not found ");
            }

            _db.Movies.Update(movieInList);
            _db.SaveChanges();
            return Ok(movie);
        }

        private IActionResult CommonDeleteLogic(string movieName)
        {
            if (movieName == null)
            {
                return BadRequest(400);
            }
            Movie? movie = _db.Movies.FirstOrDefault(movie => movie.Name == movieName);
            if (movie == null)
            {
                return BadRequest("No such movie found");
            }

        }
    }
}