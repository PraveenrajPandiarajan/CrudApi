using EmployeeCore.Core.IRepository;
using EmployeeCore.Core.IService;
using EmployeeCore.Core.Model;

namespace EmployeeService.Service
{
    public class EmployeeService
    {
        public class StudentServices : IService
        {
            private readonly IRepository _studentRepository;

            public StudentServices(IRepository studentRepository)
            {
                _studentRepository = studentRepository;
            }
            public void CreateStudentEntry(Employee student)
            {
                if (student.First_Name != string.Empty && student.First_Name != string.Empty)
                {
                    _studentRepository.CreateStudentEntry(student);
                }
            }
            public List<Employee> Read()
            {
                return _studentRepository.Read();
            }
           public List<EmployeeLocation> Dropdown()
            {
                return _studentRepository.Dropdown();
            }
            public void DeleteConform(int EmployeeId)
            {
                _studentRepository.DeleteConform(EmployeeId);
            }
         
            public Employee EditForm(int Empid)
            {
                return _studentRepository.EditForm(Empid);
            }
            public List<Employee> Search(string search)
            {
                return _studentRepository.Search(search);
            }
            public Employee Detail(int Empid)
            {
                return _studentRepository.Detail(Empid);
            }

        }
    }
}