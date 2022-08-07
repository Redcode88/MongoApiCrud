using MongoApiCrud.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoApiCrud.Service.Interfaces
{
   public interface IEmployee
   {
        

        object GetEmployes();
        object AddEmployee(Employes ObjVm);
        object DeleteEmployee(string Id);
        object GetEmployeeById(string Id);
   }
}
