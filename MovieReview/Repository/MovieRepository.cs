using Microsoft.EntityFrameworkCore;
using MovieReview.DTO;
using MovieReview.Models;
using MovieReview.Request;
using System.Collections.Generic;
using System.Linq;

namespace MovieReview.Repository
{
    public class MovieRepository : IMovieRepository
    {

        private readonly MovieDbContext _db;
        public MovieRepository(MovieDbContext db)
        {
            this._db = db;
        }

        public bool AddLanguages(AddLanguageRequest request)
        {
            if(request!=null)
            {
                List<Language> languages;
                //to check if the language is already exist
                languages = _db.Languages.Where(a => a.LanguageName.ToLower() == request.name.ToLower()).ToList();
                //If language not exist add to database
                if(languages.Count==0)
                {
                    Language language = new Language();
                    language.LanguageName = request.name;
                    _db.Languages.Add(language);
                    _db.SaveChanges();
                    return true;
                }
                //if language exist return false
                return false;
                
            }
            return false;
        }

        public bool AddMovie(AddMovieRequest request)
        {
            if (request != null)
            {
                List<Movie> movie;
                movie = _db.Movies.Where(a => a.MovieName.ToLower() == request.name.ToLower()).ToList();
                //check if movie is already present - if movie is not present add movie - return true
                if(movie.Count==0)
                {
                    Movie addMovie = new Movie();
                    addMovie.MovieName = request.name;
                    addMovie.MovieType = request.type;
                    addMovie.languagesid = request.languageid;
                    _db.Movies.Add(addMovie);
                    _db.SaveChanges();
                    return true;
                }
                //if movie present return false
                return false;
            }
            return false;
        }

        public bool AddReviews(AddReviewRequest request)
        {
            if(request!=null)
            {
                List<Movie> movie;
                //Check if movie id is available to add review
                movie=_db.Movies.Where(a => a.Id == request.movieId).ToList();
                //if movie id available - add review - return true
                if(movie!=null)
                {
                    foreach (var item in movie)
                    {

                        Review review = new Review();
                        review.ReviewName = request.reviewData;
                        review.moviesId = request.movieId;
                        _db.Reviews.Add(review);
                        _db.SaveChanges();
                        return true;
                    }
                }
                return false;
             }
            return false;
           
        }

        public List<LanguageDTO> AllLanguages()
        {
            List<LanguageDTO> languageDTOs = new List<LanguageDTO>();
            List<Language> lang;
            lang= _db.Languages.ToList();
            foreach(var item in lang)
            {
                languageDTOs.Add(new LanguageDTO
                {
                    Id=item.Id,
                    Name = item.LanguageName
                    
                });
            }
            return languageDTOs;
        }

        public List<MovieDTO> MoviesByLanguageID(int languageid=0)
        {
            List<MovieDTO> movieData = new List<MovieDTO>();
            List<Movie> movies;
            movies = languageid != 0 ? _db.Movies.Include("languages").Where(a => a.languagesid == languageid).ToList() : _db.Movies.Include("languages").ToList();

           
            foreach (var item in movies)
            {
                movieData.Add(new MovieDTO
                {
                    Id = item.Id,
                    langname=item.languages.LanguageName,
                    Name=item.MovieName,
                    Type=item.MovieType
                }) ;
            }
            return movieData;
        }

        public bool UpdateMovie(UpdateMovieRequest request)
        {
            if(request!=null)
            {
                var movie = _db.Movies.Where(a => a.Id == request.id).FirstOrDefault();
                if(movie!=null)
                {
                    movie.MovieName = string.IsNullOrEmpty(request.name) ? movie.MovieName : request.name;
                    movie.MovieType = string.IsNullOrEmpty(request.type) ? movie.MovieType : request.type;
                 
                    _db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public List<ReviewDTO> ViewReview(int movieId)
        {
            List<ReviewDTO> reviewsData = new List<ReviewDTO>();
            List<Review> reviews;
            reviews = movieId != 0 ? _db.Reviews.Include("movies").Where(a => a.moviesId == movieId).ToList() : _db.Reviews.Include("movies").ToList();
            foreach(var item in reviews)
            {
                reviewsData.Add(new ReviewDTO
                {
                    reviewId=item.id,
                    movieName=item.movies.MovieName,
                    movieType=item.movies.MovieType,
                    reviewName=item.ReviewName
                });
            }
            return reviewsData;
        }
    }
}
