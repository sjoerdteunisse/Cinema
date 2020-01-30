using Newtonsoft.Json;

namespace Cinema.Domain
{
    public class MovieTicket
    {
        [JsonProperty]
        private int _seatNr;
        [JsonProperty]
        private int _seatRow;
        [JsonProperty]
        private bool _isPremiumTicket;
        [JsonProperty]
        private MovieScreening _movieScreening;

        public MovieTicket(
                MovieScreening movieScreening,
                bool isPremiumTicket,
                int seatRow,
                int seatNr)
        {
            this._movieScreening = movieScreening;
            this._isPremiumTicket = isPremiumTicket;
            this._seatRow = seatRow;
            this._seatNr = seatNr;
        }

        public bool IsPremiumTicket => _isPremiumTicket;
        public MovieScreening MovieScreening => _movieScreening;

        public double GetPrice()
        {
            return _movieScreening.GetPricePerSeat();
        }

        public override string ToString()
        {
            return _movieScreening.ToString() + " - row " + _seatRow + ", seat " + _seatNr +
                    (_isPremiumTicket ? " (Premium)" : "");
        }
    }
}
