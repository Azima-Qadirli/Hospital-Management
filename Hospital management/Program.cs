using Hospital_management;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
class Program
{
   static  List<Doctor> doctors = new List<Doctor>();
   static  List<Patient> patients = new List<Patient>();
    static Random random = new Random();
    public static void Main(string[] args)
    {
        int choice;
        do
        {
            MainMenu();
            
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Sorry,you entered incorrect choice:");
                continue;
            }
            switch (choice)
            {
                case 1:
                    DoctorLogin();
                    break;
                case 2:
                    DoctorSignup();
                    break;
                case 3:
                    PatientLogin();
                    break;
                case 4:
                    GiveBloodTest();
                    break;
                case 5:
                    ViewResults();
                    break;
                case 6:
                    PatientSignup();
                    break;
                case 7:
                    Console.WriteLine("Exit");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }




        } while (choice != 7);


    }
    public static void MainMenu()
    {
        Console.WriteLine("Welcome to main menu:");
        Console.WriteLine("1.Entry for doctors:");
        Console.WriteLine("2.Signup for doctors:");
        Console.WriteLine("3.Entry for patients");
        Console.WriteLine("4.Give blood test:");
        Console.WriteLine("5.View of patient's results:");
        Console.WriteLine("6.Signup for patients:");
        Console.WriteLine("7.Exit!");
        Console.WriteLine("Please,enter your choice:");
    }
    public static void DoctorLogin()
    {
        Console.WriteLine("Please,enter your username:");
        string username = Console.ReadLine();
        Console.WriteLine("Please enter password:");
        string password = Console.ReadLine();
        Doctor doctor = doctors.Find(d => d.Username == username && d.Password == password);
        if (username != null && password != null)
        {
            Console.WriteLine("Your username and password added successfully.");
        }
        else
        {
            Console.WriteLine("Please,enter your username and password correctly.");
        }
    }
    public static void DoctorSignup()
    {
        Console.WriteLine("Enter doctor's username:");
        string username = Console.ReadLine();

        Console.WriteLine("Enter doctor's password:");
        string password = Console.ReadLine();
        doctors.Add(new Doctor(username, password));
        Console.WriteLine("Doctor,you doctor account created successfully.");
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
            Console.WriteLine($"Patient {patient.Username} created account successfully.");
        }
        else
        {
            Console.WriteLine("Sorry, but you entered incorrectly,");
        }
    }
    public static void PatientSignup()
    {
        Console.WriteLine("Enter patient's username:");
        string username = Console.ReadLine();
        Console.WriteLine("Enter patient's password:");
        string password = Console.ReadLine();

        patients.Add(new Patient (username,password));
        Console.WriteLine("Your patient account created successfully.");

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

        TestAnalysis analysis = new TestAnalysis(
            random.Next(1, 100),
            random.Next(1, 100),
            random.Next(1, 100)
        );

        patient.Analysis.Add(analysis);
        BloodAnalysis(patient, analysis);
    }
    public static void ViewResults()
    {
        Console.WriteLine("Enter patient's username:");
        string username= Console.ReadLine();
        Patient patient = patients.Find(p => p.Username == username);
        if (patients == null)
        {
            Console.WriteLine("There is no patient:");
            return;
        }
        if(patient.Analysis.Count == 0)
        {
            Console.WriteLine("There is no analysis result for any patient:");
        }
        Console.WriteLine($"Analysis results for patients: {patient.Username}");
        foreach (var analysis in patient.Analysis)
        {
            Console.WriteLine($"Date:{analysis.Date}, Leukocyte: {analysis.Leukocyte}, Erythrocyte: {analysis.Erythrocyte}, Creatine: {analysis.Creatine}");

        }
       
    }
    public static void BloodAnalysis(Patient patient,TestAnalysis analysis )
    {
        if(analysis.Leukocyte>=70 ||  analysis.Erythrocyte>=70 || analysis.Creatine >= 70)
        {
            if (doctors != null)
            {
                Console.WriteLine($"Message to own doctor;Patient {patient.Username} has very bad blood analysis results: Leukocyte; {analysis.Leukocyte},Erythrocyte;{analysis.Erythrocyte}, Creatine;{analysis.Creatine} ");
            }
            Console.WriteLine($"Message to patient: You have very bad blood analysis: Leukocyte; {analysis.Leukocyte},Erythrocyte;{analysis.Erythrocyte}, Creatine;{analysis.Creatine}");
        }
    }
}
