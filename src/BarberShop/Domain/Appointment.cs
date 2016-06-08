using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShop.Domain
{
    public class Appointment
    {
        public int ID { get; set; }
        public string Client { get; set; }
        public DateTime Time { get; set; }
    }
}
