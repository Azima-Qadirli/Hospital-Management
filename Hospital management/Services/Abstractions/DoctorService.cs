using Hospital_management.Models;
using Hospital_management.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_management.Services.Abstractions
{
    internal class DoctorService : IDoctorService
    {
        static List<Doctor> doctors = new List<Doctor>();
        static Random random = new Random();

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
            Console.WriteLine("Please enter your username:");
            string username = Console.ReadLine();
            Console.WriteLine("Please enter your password:");
            string password = Console.ReadLine();
            Doctor doctor = doctors.Find(d => d.Username == username && d.Password == password);
            if (doctor != null)
            {
                Console.WriteLine($"Welcome, Doctor {doctor.Name} {doctor.Surname} to your account.");
                Console.WriteLine("Do you wanna look through:");
                Console.WriteLine("1.Your patient's results:");
                Console.WriteLine("2.Exit.");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Sorry, but you entered an incorrect option. Try again.");
                    return;
                }
                switch (choice)
                {
                    case 1:
                        ViewPatientResult(doctor);
                        break;
                    case 2:
                        Console.WriteLine("Exiting doctor account.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Exiting doctor account.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("No matching account found. Please create your account.");
            }
        }
        public void ViewPatientResult(Doctor doctor)
        {
            PatientService patientService = new PatientService();
            List<Patient> doctorPatients = patientService.GetAll().Where(p => p.AssignedDoctor == doctor).ToList();
            if (doctorPatients.Count == 0)
            {
                Console.WriteLine("There are no assigned patients.");
                return;
            }
            Console.WriteLine($"Patients assigned to Doctor {doctor.Name} {doctor.Surname}:");
            foreach (Patient patient in doctorPatients)
            {
                Console.WriteLine($"{patient.Name} {patient.Surname}");
                if (patient.Analysis.Count > 0)
                {
                    Console.WriteLine("Analysis results:");
                    foreach (var analysis in patient.Analysis)
                    {
                        Console.WriteLine($"  Date: {analysis.Date}, Leukocyte: {analysis.Leukocyte}, Erythrocyte: {analysis.Erythrocyte}, Creatine: {analysis.Creatine}");
                    }

                }
                else
                {
                    Console.WriteLine("No analysis results available for this patient.");
                }
            }
        }
        public void Signup()
        {
            Console.WriteLine("Enter doctor's name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter doctor's surname:");
            string surname = Console.ReadLine();

            Console.WriteLine("Enter doctor's username:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter doctor's password:");
            string password = Console.ReadLine();

            doctors.Add(new Doctor(username, password, name, surname));
            Console.WriteLine("Doctor account created successfully.");
        }

        public List<Doctor> GetAll() => doctors;
        
    }
}
