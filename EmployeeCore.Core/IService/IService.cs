using EmployeeCore.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCore.Core.IService
{
    public interface IService
    {
        void CreateStudentEntry(Employee student);
        List<Employee> Read();
        void DeleteConform(int EmployeeId);
        Employee EditForm(int Empid);
        List<Employee> Search(string search);
        Employee Detail(int Empid);
        List<EmployeeLocation> Dropdown();
    }
}
