using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Collections.Generic;
using BarberShop.Domain;

namespace BarberShop.Infrastructure.InMemoryDataStore
{
    public class InMemoryAppointmentsRepository : IAppointmentsRepository
    {
        private readonly ConcurrentDictionary<int, Appointment> appointments = new ConcurrentDictionary<int, Appointment>(); 
        public IEnumerable<Appointment> GetAll()
        {
            return appointments.Values;
        }

        public void Store(Appointment appointment)
        {
            appointments[appointment.ID] = appointment;
        }

        public Appointment Load(int id)
        {
            return appointments[id];
        }
    }
}