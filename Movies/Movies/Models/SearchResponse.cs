using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AguiarMovies.Models
{
    [DataContract]
    public class GenreResults
    {
        [DataMember(Name ="genres")]
        public IReadOnlyList<Genre.Genre> Results { get; private set; }

    }


    [DataContract]
    public class SearchResponse<T> 
    {
        [DataMember(Name = "results")]
        public IReadOnlyList<T> Results { get; private set; }

        [DataMember(Name = "page")]
        public int PageNumber { get; private set; }

        [DataMember(Name = "total_pages")]
        public int TotalPages { get; private set; }

        [DataMember(Name = "total_results")]
        public int TotalResults { get; private set; }
    }
}