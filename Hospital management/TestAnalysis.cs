using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_management
{
    public class TestAnalysis
    {
        public int Leukocyte { get; set; }
        public int Erythrocyte { get; set; }
        public int Creatine { get; set; }
        public DateTime Date { get; set; } 
        public TestAnalysis(int leukocyte,int erythrocyte,int creatine)
        {
            Leukocyte= leukocyte;
            Erythrocyte=erythrocyte;
            Creatine= creatine;
            Date=DateTime.Now;
        }
    }
}
