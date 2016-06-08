using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarberShop.Domain;
using BarberShop.Infrastructure.InMemoryDataStore;
using FluentAssertions;
using Xunit;

namespace BarberShop.Tests.Infrastructure
{
    public class AppointmentsRepositoryTest
    {
        [Fact]
        public void StoresAndLoads()
        {
            IAppointmentsRepository repository = new InMemoryAppointmentsRepository();
            var appointment = new Appointment {Client = "John", Time = new DateTime(2010, 1, 3, 10, 15, 0), ID = 1};
            repository.Store(appointment);
            Appointment loaded = repository.Load(1);
            loaded.ShouldBeEquivalentTo(appointment);
        }
    }
}
