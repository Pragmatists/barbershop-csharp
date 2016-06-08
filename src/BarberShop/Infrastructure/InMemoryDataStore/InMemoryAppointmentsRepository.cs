using System;
using System.Collections.Generic;
using BarberShop.Domain;

namespace BarberShop.Infrastructure.InMemoryDataStore
{
    public class InMemoryAppointmentsRepository : IAppointmentsRepository
    {
        public IEnumerable<Appointment> GetAll()
        {
            return new List<Appointment>
            {
                new Appointment {Client = "Janina Nowak", ID = 1, Time = new DateTime(2010,3,1,12,30,0) }
            };
        }
    }
}