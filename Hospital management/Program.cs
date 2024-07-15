using Hospital_management;
using Hospital_management.Models;
using Hospital_management.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private readonly static DoctorService doctorService = new DoctorService();
    private readonly static PatientService patientService = new PatientService();
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
                    doctorService.Entry();
                    break;
                case 2:
                    patientService.Entry();
                    break;
                case 3:
                    patientService.GiveBloodTest();
                    break;
                case 4:
                    patientService.ViewResults();
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
}
