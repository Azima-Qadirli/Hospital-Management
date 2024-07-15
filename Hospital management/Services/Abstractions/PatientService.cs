using Hospital_management.Models;
using Hospital_management.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_management.Services.Abstractions
{
    internal class PatientService :IPatientService
    {
        static List<Patient> patients = new List<Patient>();
        static Random random = new Random();
        delegate void BloodTestNotificationHandler(Patient patient, TestAnalysis analysis, Doctor doctor);
        static event BloodTestNotificationHandler BloodTestNotificationEvent;
        public void Entry()
        {
            Console.WriteLine("Do you want to login or signup?");
            string choice = Console.ReadLine();
            if (choice == "login")
            {
                Login();
            }
            else if (choice == "signup")
            {
                Signup();
            }
            else
            {
                Console.WriteLine("Sorry, but you entered an incorrect choice. Try again.");
            }
        }

        public void Login()
        {
            Console.WriteLine("Enter patient's username:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter patient's password:");
            string password = Console.ReadLine();

            Patient patient = patients.Find(p => p.Username == username && p.Password == password);
            if (patient != null)
            {
                Console.WriteLine($"Welcome, {patient.Name} {patient.Surname} to your account.");
            }
            else
            {
                Console.WriteLine("No matching account found.");
            }
        }

        public void Signup()
        {
            Console.WriteLine("Enter patient's name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter patient's surname:");
            string surname = Console.ReadLine();

            Console.WriteLine("Enter patient's username:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter patient's password:");
            string password = Console.ReadLine();

            patients.Add(new Patient(username, password, name, surname));
            Console.WriteLine("Patient account created successfully.");
        }

        public void GiveBloodTest()
        {
            Console.WriteLine("Enter patient's username:");
            string username = Console.ReadLine();
            Patient patient = patients.Find(p => p.Username == username);
            if (patient == null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }
            //if (doctors.Count == 0)
            //{
            //    Console.WriteLine("There are no doctors available to assign.");
            //    return;
            //}
            //Doctor assignedDoctor = doctors[random.Next(doctors.Count)];

            TestAnalysis analysis = new TestAnalysis(
                random.Next(1, 101),
                random.Next(1, 101),
                random.Next(1, 101),
                //assignedDoctor,
                null,
                patient
            );
            patient.Analysis.Add(analysis);

            BloodAnalysis(patient, analysis, null);
        }

        public void ViewResults()
        {
            Console.WriteLine("Enter patient's username:");
            string username = Console.ReadLine();
            Patient patient = patients.Find(p => p.Username == username);
            if (patient == null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }
            if (patient.Analysis.Count == 0)
            {
                Console.WriteLine("No analysis results available for this patient.");
                return;
            }
            Console.WriteLine($"Analysis results for patient: {patient.Name} {patient.Surname}");
            foreach (var analysis in patient.Analysis)
            {
                Console.WriteLine($"Date: {analysis.Date}, Leukocyte: {analysis.Leukocyte}, Erythrocyte: {analysis.Erythrocyte}, Creatine: {analysis.Creatine}");
            }
        }

        public void BloodAnalysis(Patient patient, TestAnalysis analysis, Doctor doctor)
        {
            BloodTestNotificationEvent?.Invoke(patient, analysis, doctor);

            if (analysis.Leukocyte >= 70 || analysis.Erythrocyte >= 70 || analysis.Creatine >= 70)
            {
                Console.WriteLine($"Patient {patient.Name} {patient.Surname}, you have bad blood analysis results.");
            }
            else
            {
                Console.WriteLine($"Patient {patient.Name} {patient.Surname}, you have good blood analysis results.");
            }
        }
        private void SendMessageNotification(Patient patient, TestAnalysis analysis, Doctor doctor)
        {
            if (analysis.Leukocyte >= 70 || analysis.Erythrocyte >= 70 || analysis.Creatine >= 70)
            {
                if (doctor != null)
                {
                    Console.WriteLine($"Message to assigned doctor {doctor.Name} {doctor.Surname}: Doctor, your patient {patient.Name} {patient.Surname} has bad blood results.");
                }
                Console.WriteLine($"Message to patient {patient.Name} {patient.Surname}: You have bad blood results.");
            }
        }

        public List<Patient> GetAll() => patients;
    }
}
