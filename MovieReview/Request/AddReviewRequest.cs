using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieReview.Request
{
    public class AddReviewRequest
    {
        public int movieId { get; set; }
        public string reviewData { get; set; }
    }
}
