using System;
using Newtonsoft.Json;

namespace Cinema.Domain
{
    public class MovieScreening
    {
        [JsonProperty]
        private Movie _movie;
        [JsonProperty]
        private DateTime _dateAndTime;
        [JsonProperty]
        private double _pricePerSeat;

        public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
        {
            this._movie = movie;
            movie.AddScreening(this);

            this._dateAndTime = dateAndTime;
            this._pricePerSeat = pricePerSeat;
        }

        public Movie Movie => _movie;
        public DateTime DateTimeLive => _dateAndTime;

        public double GetPricePerSeat()
        {
            return _pricePerSeat;
        }

        public override string ToString()
        {
            return _movie.GetTitle() + " - " + _dateAndTime;
        }
    }
}
