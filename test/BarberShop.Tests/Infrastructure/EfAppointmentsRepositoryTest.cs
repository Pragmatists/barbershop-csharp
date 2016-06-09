using BarberShop.Domain;
using BarberShop.Infrastructure.EFDataStore;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Tests.Infrastructure
{
    public class EfAppointmentsRepositoryTest : AppointmentsRepositoryTest
    {
        protected override IAppointmentsRepository CreateRepository()
        {
            var options = new DbContextOptionsBuilder<BarberShopContext>().UseInMemoryDatabase().Options;
            return new EfAppointmentsRepository(new BarberShopContext(options));
        }
    }
}