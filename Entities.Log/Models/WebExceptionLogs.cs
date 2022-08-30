using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Log.Models
{
	[Table("WebExceptionLogs")]
    public class WebExceptionLogs : ExceptionLogs
    {
        [DisplayName("Action")]
        [StringLength(100)]
        public string ActionName { get; set; }

        [DisplayName("Controller")]
        [StringLength(100)]
        public string Controller { get; set; }
    }
}