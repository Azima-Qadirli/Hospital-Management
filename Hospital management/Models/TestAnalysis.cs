using System;

namespace Hospital_management.Models
{
    public class TestAnalysis
    {
        public int Leukocyte { get; set; }
        public int Erythrocyte { get; set; }
        public int Creatine { get; set; }
        public DateTime Date { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }

        public TestAnalysis(int leukocyte, int erythrocyte, int creatine, Doctor doctor, Patient patient)
        {
            Leukocyte = leukocyte;
            Erythrocyte = erythrocyte;
            Creatine = creatine;
            Date = DateTime.Now;
            Patient = patient;
            Doctor = doctor;
        }
    }
}
