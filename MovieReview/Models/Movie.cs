using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieReview.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string MovieType { get; set; }
        public int languagesid { get; set; }
        public virtual Language languages { get; set; }
       
    }
}
