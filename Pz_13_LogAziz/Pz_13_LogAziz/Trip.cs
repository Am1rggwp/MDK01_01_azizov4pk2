using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pz_13_LogAziz
{
    internal class Trip
    {
        [Key] public int trip_no { get; set; }
        public int ID_comp { get; set; }
        public string plane { get; set; }
        public string town_from { get; set; }
        public string town_to { get; set; }
        public DateTime time_out { get; set; }
        public DateTime time_in { get; set; }


    }
}
