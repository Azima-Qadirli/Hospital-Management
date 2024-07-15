using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_management.Services.Interfaces
{
    internal interface IDoctorService : IService<Doctor>
    {
        public void ViewPatientResult(Doctor doctor);
    }
}
