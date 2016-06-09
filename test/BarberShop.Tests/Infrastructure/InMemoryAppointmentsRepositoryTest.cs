using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarberShop.Domain;
using BarberShop.Infrastructure.InMemoryDataStore;

namespace BarberShop.Tests.Infrastructure
{
    public class InMemoryAppointmentsRepositoryTest : AppointmentsRepositoryTest
    {
        protected override IAppointmentsRepository CreateRepository()
        {
            return new InMemoryAppointmentsRepository();
        }
    }
}
