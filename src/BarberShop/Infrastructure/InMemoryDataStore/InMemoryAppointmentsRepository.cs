using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Collections.Generic;
using BarberShop.Domain;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BarberShop.Infrastructure.InMemoryDataStore
{
    public class InMemoryAppointmentsRepository : IAppointmentsRepository
    {
        private readonly ConcurrentDictionary<int, Appointment> appointments = new ConcurrentDictionary<int, Appointment>();
        private static int sequence = 0;

        public IEnumerable<Appointment> GetAll()
        {
            return appointments.Values;
        }

        public Appointment Store(Appointment appointment)
        {
            appointment.ID = sequence++;
            appointments[appointment.ID] = appointment;
            return appointment;
        }

        public Appointment Load(int id)
        {
            return appointments[id];
        }
    }
}