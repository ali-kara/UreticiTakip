using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.NBS_Models
{
    [Table("Locations")]
    public class Location
    {
        
        [Key]
        public int Id { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }


        public string SoforKodu { get; set; }
        public DateTime? OlusturmaTarihi { get; set; } = DateTime.Now;

        //public Soforler soforler { get; set; }
    }

    public class LocationInsert
    {
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public string SoforKodu { get; set; }
    }
}
