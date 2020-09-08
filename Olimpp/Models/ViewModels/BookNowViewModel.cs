using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olimpp.Models.ViewModels
{
    public class BookNowViewModel
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public DateTime MovieDate { get; set; }
        public string SeatNo { get; set; }
        public int Amount { get; set; }
        public int MovieId { get; set; }

    }
}
