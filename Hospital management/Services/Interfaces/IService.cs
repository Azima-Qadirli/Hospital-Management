using Hospital_management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_management.Services.Interfaces
{
    public interface IService<T> where T :Entity
    {
        public void Login();
        public void Signup();
        public void Entry();
        public List<T> GetAll();
    }
}
