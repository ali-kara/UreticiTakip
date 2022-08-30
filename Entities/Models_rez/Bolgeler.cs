using Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Bolgeler")]
    public partial class Bolgeler : BaseClass
    {
        [Key]
        public int BolgeId { get; set; }

        [Required]
        [StringLength(10)]
        public string BolgeAdi { get; set; }

        [StringLength(50)]
        public string Aciklama { get; set; }
    }
}
