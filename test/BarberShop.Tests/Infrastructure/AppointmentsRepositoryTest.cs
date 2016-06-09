using System;
using BarberShop.Domain;
using FluentAssertions;
using Xunit;

namespace BarberShop.Tests.Infrastructure
{
    public abstract class AppointmentsRepositoryTest
    {
        [Fact]
        public void StoresAndLoads()
        {
            var repository = CreateRepository();
            var appointment = new Appointment {Client = "John", Time = new DateTime(2010, 1, 3, 10, 15, 0)};
            var stored = repository.Store(appointment);
            Appointment loaded = repository.Load(stored.ID);
            loaded.ShouldBeEquivalentTo(appointment);
        }

        protected abstract IAppointmentsRepository CreateRepository();
    }
}