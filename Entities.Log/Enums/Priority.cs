using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Log.Enums
{
    public enum Priority
    {
        [Display(Name = "Yüksek")]
        [Description("Yüksek")]
        High,
        [Display(Name = "Normal")]
        [Description("Normal")]
        Normal,
        [Display(Name = "Düşük")]
        [Description("Düşük")]
        Low
    }
}
