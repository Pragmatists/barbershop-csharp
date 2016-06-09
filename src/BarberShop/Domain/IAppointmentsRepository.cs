using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShop.Domain
{
    public interface IAppointmentsRepository
    {
        IEnumerable<Appointment> GetAll();
        Appointment Store(Appointment appointment);
        Appointment Load(int id);
    }
}
