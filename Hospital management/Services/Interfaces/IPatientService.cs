using Hospital_management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_management.Services.Interfaces
{
    internal interface IPatientService : IService<Patient>
    {
        public void GiveBloodTest();
        public void ViewResults();
        public void BloodAnalysis(Patient patient, TestAnalysis analysis, Doctor doctor);
    }
}
