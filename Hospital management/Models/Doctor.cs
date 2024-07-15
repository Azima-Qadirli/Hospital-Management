using System;
using Hospital_management.Models;

namespace Hospital_management
{
    public class Doctor : Entity
    {
        public Doctor(string username, string password, string name, string surname) : base(username, password, name, surname)
        {

        }
    }
}
