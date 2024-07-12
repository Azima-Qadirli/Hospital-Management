using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_management
{
    public class Patient:Entity
    {

        public Patient(string username,string password):base(username,password)
        {
            
        }
        public List<TestAnalysis> Analysis { get; set; }=new List<TestAnalysis>();

    }
}
