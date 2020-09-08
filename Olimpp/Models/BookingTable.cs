using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Olimpp.Models
{
    public class BookingTable
    {

        public int Id { get; set; }
        public string seatno { get; set; }
        public string UserId { get; set; }
        public DateTime DateToPresent { get; set; }
        public int MovieDetaliesId { get; set; }
        public int Amount { get; set; }
        [ForeignKey("MovieDetaliesId")]
        public virtual MovieDetalies moviedetalies { get; set; }
    }
}
