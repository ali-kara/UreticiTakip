using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Entities.Log
{
    [DataContract(IsReference = true)]
    [Table("ExceptionLogs")]
    public class ExceptionLogs : BaseClass
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        [DisplayName("Hata No")]
        [Key]
        public int ExceptionID { get; set; }

        [DataMember]
        [DisplayName("Mesaj")]
        public string Message { get; set; }

        [DataMember]
        [DisplayName("Hata İç Detayı")]
        public string InnerException { get; set; }

        [DataMember]
        [DisplayName("Hata Detayı")]
        public string Stacktrace { get; set; }
    }
}