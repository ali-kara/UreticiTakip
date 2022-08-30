using Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("AracPlakalar")]
    public partial class AracPlakalar : BaseClass
    {
        [Key]
        public int PlakaId { get; set; }

        [Required]
        [StringLength(10)]
        public string Plaka { get; set; }

        [StringLength(50)]
        public string Aciklama { get; set; }
    }
}
