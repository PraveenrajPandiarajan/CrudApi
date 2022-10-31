using EmployeeCore.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCore.Core.IRepository
{
    public interface IRepository
    {
        void CreateStudentEntry(Employee student);
        List<Employee> Read();
        List<EmployeeLocation> Dropdown();
        void DeleteConform(int EmployeeId);
        Employee EditForm(int Empid);
        List<Employee> Search(string search);
        Employee Detail(int Empid);
    }
}
