using System.Collections.Generic;
using Newtonsoft.Json;

namespace Cinema.Domain
{
    public class Movie
    {
        [JsonProperty]
        private string _title;
        private List<MovieScreening> _screenings;

        public Movie(string title)
        {
            this._title = title;
            _screenings = new List<MovieScreening>();
        }

        public string GetTitle()
        {
            return _title;
        }

        public void AddScreening(MovieScreening screening)
        {
            _screenings.Add(screening);
        }
    }
}
