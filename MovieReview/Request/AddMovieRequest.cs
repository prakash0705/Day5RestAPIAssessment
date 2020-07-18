using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieReview.Request
{
    public class AddMovieRequest
    {
        public string name { get; set; }
        public string type { get; set; }
        public int languageid { get; set; }
    }
}
