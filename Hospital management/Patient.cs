using System;
using System.Collections.Generic;

namespace Hospital_management
{
    public class Patient : Entity
    {
        public Patient(string username, string password, string name, string surname) : base(username, password, name, surname)
        {

        }
        public Doctor AssignedDoctor { get; set; }
        public List<TestAnalysis> Analysis { get; set; } = new List<TestAnalysis>();
    }
}
