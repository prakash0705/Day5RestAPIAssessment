using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieReview.DTO
{
    public class ReviewDTO
    {
        public int reviewId { get; set; }
        public string reviewName { get; set; }
        public string movieName { get; set; }
        public string movieType { get; set; }
    }
}
