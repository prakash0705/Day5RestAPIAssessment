using MovieReview.DTO;
using MovieReview.Models;
using MovieReview.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieReview.Repository
{
    public interface IMovieRepository
    {
        List<LanguageDTO> AllLanguages();
        bool AddLanguages(AddLanguageRequest data);
        List<MovieDTO> MoviesByLanguageID(int languageid);
        bool AddMovie(AddMovieRequest data);
        bool UpdateMovie(UpdateMovieRequest data);
        List<ReviewDTO> ViewReview(int movieId);
        bool AddReviews(AddReviewRequest data);
    }
}
