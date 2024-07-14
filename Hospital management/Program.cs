using Hospital_management;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Doctor> doctors = new List<Doctor>();
    static List<Patient> patients = new List<Patient>();
    static Random random = new Random();

    delegate void BloodTestNotificationHandler(Patient patient, TestAnalysis analysis, Doctor doctor);
    static event BloodTestNotificationHandler BloodTestNotificationEvent;

    public static void Main(string[] args)
    {
        int choice;
        do
        {
            MainMenu();

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Sorry, you entered an incorrect choice:");
                continue;
            }
            switch (choice)
            {
                case 1:
                    EntryForDoctors();
                    break;
                case 2:
                    EntryForPatients();
                    break;
                case 3:
                    GiveBloodTest();
                    break;
                case 4:
                    ViewResults();
                    break;
                case 5:
                    Console.WriteLine("Exit!");
                    break;
                default:
                    Console.WriteLine("Incorrect choice.");
                    break;
            }
        } while (choice != 5);
    }

    public static void MainMenu()
    {
        Console.WriteLine("Welcome to the main menu:");
        Console.WriteLine("1. Entry for Doctors");
        Console.WriteLine("2. Entry for Patients");
        Console.WriteLine("3. Give Blood Test");
        Console.WriteLine("4. View Patient's Results");
        Console.WriteLine("5. Exit");
        Console.WriteLine("Please enter your choice:");
    }

    public static void EntryForDoctors()
    {
        Console.WriteLine("Do you want to login or signup?");
        string choice = Console.ReadLine();
        if (choice == "login")
        {
            DoctorLogin();
        }
        else if (choice == "signup")
        {
            DoctorSignup();
        }
        else
        {
            Console.WriteLine("Sorry, but you entered an incorrect choice. Try again.");
        }
    }

    public static void EntryForPatients()
    {
        Console.WriteLine("Do you want to login or signup?");
        string choice = Console.ReadLine();
        if (choice == "login")
        {
            PatientLogin();
        }
        else if (choice == "signup")
        {
            PatientSignup();
        }
        else
        {
            Console.WriteLine("Sorry, but you entered an incorrect choice. Try again.");
        }
    }

    public static void DoctorLogin()
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

    public static void ViewPatientResult(Doctor doctor)
    {
        List<Patient> doctorPatients = patients.Where(p => p.AssignedDoctor == doctor).ToList();
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

    public static void DoctorSignup()
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

    public static void PatientLogin()
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

    public static void PatientSignup()
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

    public static void GiveBloodTest()
    {
        Console.WriteLine("Enter patient's username:");
        string username = Console.ReadLine();
        Patient patient = patients.Find(p => p.Username == username);
        if (patient == null)
        {
            Console.WriteLine("Patient not found.");
            return;
        }
        if (doctors.Count == 0)
        {
            Console.WriteLine("There are no doctors available to assign.");
            return;
        }
        Doctor assignedDoctor = doctors[random.Next(doctors.Count)];

        TestAnalysis analysis = new TestAnalysis(
            random.Next(1, 101),
            random.Next(1, 101),
            random.Next(1, 101),
            assignedDoctor,
            patient
        );
        patient.Analysis.Add(analysis);

        BloodAnalysis(patient, analysis, assignedDoctor);
    }

    public static void ViewResults()
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

    public static void BloodAnalysis(Patient patient, TestAnalysis analysis, Doctor doctor)
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

    public static void SendMessageNotification(Patient patient, TestAnalysis analysis, Doctor doctor)
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
}
