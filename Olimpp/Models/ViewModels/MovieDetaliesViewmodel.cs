using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olimpp.Models.ViewModels
{
    public class MovieDetaliesViewmodel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateofMovie { get; set; }
        public string MoviePicture { get; set; }

    }
}
