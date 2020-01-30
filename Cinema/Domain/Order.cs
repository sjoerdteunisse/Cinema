using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Cinema.Extensions;
using Cinema.Logic;
using Newtonsoft.Json;

namespace Cinema.Domain
{
    public class Order
    {
        [JsonProperty]
        private int _orderNr;
        [JsonProperty]
        private bool _isStudentOrder;
        [JsonProperty]
        private List<MovieTicket> _tickets;

        public Order(int orderNr, bool isStudentOrder)
        {
            _orderNr = orderNr;
            _isStudentOrder = isStudentOrder;
            _tickets = new List<MovieTicket>();
        }

        public int GetOrderNr()
        {
            return _orderNr;
        }

        public void AddSeatReservation(MovieTicket ticket)
        {
            _tickets.Add(ticket);
        }

        /// <summary>
        /// returns the price for the tickets based on the parameters and business logic.
        /// </summary>
        /// <returns></returns>
        public double CalculatePrice()
        {
            IOrderPriceCalculator studentDiscount = new StudentDiscountCalculator();
            IOrderPriceCalculator normalDiscount = new NormalDiscountCalculator();
            
            return _isStudentOrder ? studentDiscount.CalculatePrice(this) : normalDiscount.CalculatePrice(this);
        }

        internal List<MovieTicket> MovieTicket => _tickets;

        public void Export(TicketExportFormat exportFormat)
        {
            // Bases on the string representation of the _tickets (toString), write
            // the ticket to a file with naming convention Order_<_orderNr>.txt of
            // Order_<_orderNr>.json

            var filename = $"Order_{this._orderNr}.";
            var lines = "";

            switch (exportFormat)
            {
                case TicketExportFormat.PLAINTEXT:
                    filename += "txt";
                    lines = this.ToString();
                    break;
                case TicketExportFormat.JSON:
                    filename += "json";
                    lines = Newtonsoft.Json.JsonConvert.SerializeObject(this);
                    break;
            }

            using var file = new System.IO.StreamWriter(path: filename);
            file.WriteLine(lines);
            file.Close();
        }

        public override string ToString()
        {
            return $"{MovieTicket.FirstOrDefault()?.MovieScreening} for a total of {CalculatePrice()} CURRENCY";
        }
    }
}
