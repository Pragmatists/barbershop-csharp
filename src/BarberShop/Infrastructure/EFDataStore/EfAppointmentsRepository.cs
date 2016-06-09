using System.Collections.Generic;
using System.Linq;
using BarberShop.Domain;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BarberShop.Infrastructure.EFDataStore
{
    public class EfAppointmentsRepository : IAppointmentsRepository
    {
        private readonly BarberShopContext db;

        public EfAppointmentsRepository(BarberShopContext db)
        {
            this.db = db;
        }

        public IEnumerable<Appointment> GetAll()
        {
            return db.Appointments;
        }

        public Appointment Store(Appointment appointment)
        {
            db.Appointments.Add(appointment);
            db.SaveChanges();
            return appointment;
        }

        public Appointment Load(int id)
        {
            return db.Appointments.SingleOrDefault(m=>m.ID == id);
        }
    }
}