using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Entities.Log.Models
{
    [Table("Countries")]
    public class Country : BaseClass
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("İl No")]
        [Key]
        public int CountryID { get; set; }

        [DisplayName("İl Adı")]
        [Required]
        [StringLength(50)]
        public string CountryName { get; set; }

        public virtual List<Sube> subeler { get; set; }
    }
}