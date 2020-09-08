using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olimpp.Models
{
    public class MovieDetalies
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string MovieDescription { get; set; }
        public DateTime DateAndTime { get; set; }
        public string MoviePicture { get; set; }


        public virtual ICollection<BookingTable> booking { get; set; }
    }
}
