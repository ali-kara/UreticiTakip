using Entities.Log.Abstract;
using Entities.Log.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Log.ViewModels
{
    public class vmDuyurular : BaseViewModel
    {
        public Duyurular duyurular { get; set; }
        public string[] sehirler { get; set; }
    }
}
