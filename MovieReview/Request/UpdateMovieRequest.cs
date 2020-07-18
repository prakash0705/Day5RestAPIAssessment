using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieReview.Request
{
    public class UpdateMovieRequest:AddMovieRequest
    {
        public int id { get; set; }
    }
}
