using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieReview.Models
{
    public class Review
    {
        public int id { get; set; }
        public string ReviewName { get; set; }
        public int moviesId { get; set; }
        public virtual Movie movies { get; set; }
    }
}
