using AguiarMovies.Models.People;
using System.Collections.Generic;

namespace AguiarMovies.Models
{
    public class ProfileParameter
    {
        public Profile Current { get; set; }

        public List<Profile> Images { get; set; }
    }
}