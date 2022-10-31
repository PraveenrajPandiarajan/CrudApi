using EmployeeCore.Core.IRepository;
using EmployeeCore.Core.Model;
using EmployeeEntity.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EmployeeRepository
{
    public class EmployeeRepository
    {
        public class StudentRepository : IRepository
        {
            public EmployeeDetailsContext entity;

            public StudentRepository(EmployeeDetailsContext masterContext)
            {
                entity = masterContext;
            }
            #region Create

            public void CreateStudentEntry(Employee employeeDetails)
            {
                if (employeeDetails != null)
                {
                    if (employeeDetails.Employee_Id == 0)
                    {
                        EmployeeEntity.Entity.Detail Emp_Db = new EmployeeEntity.Entity.Detail();
                        Emp_Db.First_Name = employeeDetails.First_Name;
                        Emp_Db.Address = employeeDetails.Address;
                        Emp_Db.Last_Name= employeeDetails.Last_Name;
                        Emp_Db.Date_Of_Joining = DateTime.Parse(employeeDetails.Date);
                        Emp_Db.Age = employeeDetails.Age;
                        Emp_Db.Expereince = employeeDetails.Expereince;
                        Emp_Db.Contact_Number = employeeDetails.Contact_Number;
                        Emp_Db.Password = employeeDetails.Password;
                        Emp_Db.Location_Id = employeeDetails.Location_Id;             
                        Emp_Db.Confirm_Password = employeeDetails.Confirm_Password;
                        entity.Detail.Add(Emp_Db);
                        entity.SaveChanges();
                   
                    }
                    else
                    {
                        var Emp_Db = entity.Detail.Where(x => x.Employee_Id == employeeDetails.Employee_Id).SingleOrDefault();
                        if (Emp_Db != null)
                        {
                        
                            Emp_Db.First_Name = employeeDetails.First_Name;
                            Emp_Db.Date_Of_Joining = DateTime.Parse(employeeDetails.Date);
                            Emp_Db.Last_Name = employeeDetails.Last_Name;
                            Emp_Db.Age = employeeDetails.Age;
                            Emp_Db.Expereince = employeeDetails.Expereince;
                            Emp_Db.Contact_Number= employeeDetails.Contact_Number;
                            Emp_Db.Address = employeeDetails.Address;
                            Emp_Db.Password = employeeDetails.Password;
                            Emp_Db.Confirm_Password = employeeDetails.Confirm_Password;
                            Emp_Db.Create_Time_Stamp = DateTime.Now;
                            Emp_Db.Update_Time_Stamp = DateTime.Now;
                            entity.SaveChanges();
                        }
                    }
                } 
            }
            #endregion

            #region Read
            public List<Employee> Read()
            {
                List<Employee> empModel = new List<Employee>();
                var Emp_Db = entity.Detail.Where(x => !x.Is_Deleted).ToList();
                if(Emp_Db != null && Emp_Db.Count>0)
                { 
                    foreach (var item in Emp_Db)
                    {
                        Employee employeeModel = new Employee();
                        employeeModel.Employee_Id = item.Employee_Id;
                        employeeModel.First_Name = item.First_Name;
                        employeeModel.Date = item.Date_Of_Joining.ToString("yyyy-MM-dd");
                        employeeModel.Last_Name = item.Last_Name;
                        employeeModel.Age = item.Age;
                        employeeModel.Expereince = item.Expereince;
                        employeeModel.Contact_Number = item.Contact_Number;
                        employeeModel.Address = item.Address;
                        employeeModel.Password = item.Password;
                        var section = entity.Locations.Where(x => x.Location_Id == item.Location_Id).SingleOrDefault();
                        employeeModel.Location = section.Location;
                        employeeModel.Confirm_Password = item.Confirm_Password;
                        empModel.Add(employeeModel);
                    }
                }
                return empModel;
            }
            #endregion

            #region Edit
            public Employee EditForm(int Empid)
            {
                Employee employeeModel = new Employee();
                var Emp_Db = entity.Detail.Where(x => x.Employee_Id == Empid && !x.Is_Deleted).SingleOrDefault();
                if (Emp_Db != null)
                {
                    employeeModel.Employee_Id = Emp_Db.Employee_Id;
                    employeeModel.First_Name = Emp_Db.First_Name;
                    employeeModel.Date = Emp_Db.Date_Of_Joining.ToString("yyyy-MM-dd");
                    employeeModel.Last_Name = Emp_Db.Last_Name;
                    employeeModel.Age = Emp_Db.Age;
                    employeeModel.Expereince = Emp_Db.Expereince;
                    employeeModel.Address = Emp_Db.Address;
                    var section = entity.Locations.Where(x => x.Location_Id == Emp_Db.Location_Id).SingleOrDefault();
                    employeeModel.Location = section.Location;
                    employeeModel.Location_Id = section.Location_Id;
                    employeeModel.Password = Emp_Db.Password;
                    employeeModel.Contact_Number = Emp_Db.Contact_Number;
                    employeeModel.Confirm_Password = Emp_Db.Confirm_Password;
                    employeeModel.Is_Deleted = Emp_Db.Is_Deleted;
                    employeeModel.Create_Time_Stamp = Emp_Db.Create_Time_Stamp;
                    employeeModel.Update_Time_Stamp = Emp_Db.Update_Time_Stamp;
                }
                return employeeModel;
            }
            #endregion

            #region Delete
            public void DeleteConform(int EmployeeId)
            {
                var Emp_Db = entity.Detail.Where(x => x.Employee_Id == EmployeeId).SingleOrDefault();
                if (Emp_Db != null)
                {
                    Emp_Db.Is_Deleted = true;
                    entity.SaveChanges();
                }
            }
            #endregion

            #region Search
            public List<Employee> Search(string search)
            {
                //if (search != null)
                //{
                    List<Employee> empModel = new List<Employee>();
                   var Emp_Db = entity.Detail.Where(x => x.First_Name.Contains(search) && !x.Is_Deleted).ToList();
                    if (Emp_Db != null && Emp_Db.Count>0)
                    {
                        foreach (var item in Emp_Db)
                        {
                                Employee employeeModel = new Employee();
                                employeeModel.Employee_Id = item.Employee_Id;
                                employeeModel.First_Name = item.First_Name;
                        employeeModel.Date = item.Date_Of_Joining.ToString("yyyy-MM-dd");
                        employeeModel.Last_Name = item.Last_Name;
                                employeeModel.Age= item.Age;
                                employeeModel.Expereince = item.Expereince;
                                employeeModel.Contact_Number = item.Contact_Number;
                                employeeModel.Address = item.Address;
                                employeeModel.Password = item.Password;
                                var section = entity.Locations.Where(x => x.Location_Id == item.Location_Id).SingleOrDefault();
                                employeeModel.Location = section.Location;
                                employeeModel.Confirm_Password = item.Confirm_Password;
                                employeeModel.Is_Deleted = item.Is_Deleted;
                                employeeModel.Create_Time_Stamp = item.Create_Time_Stamp;
                                employeeModel.Update_Time_Stamp = item.Update_Time_Stamp;
                                empModel.Add(employeeModel);
                            
                        }
                    }
                    return empModel;
              }
            #endregion

            #region Detail
            public Employee Detail(int Empid)
            {
                Employee employeeModel = new Employee();
                var Emp_Db = entity.Detail.Where(x => x.Employee_Id == Empid).SingleOrDefault();
                employeeModel.Employee_Id = Emp_Db.Employee_Id;
                employeeModel.First_Name = Emp_Db.First_Name;
                employeeModel.Date = Emp_Db.Date_Of_Joining.ToString("yyyy-MM-dd");
                employeeModel.Last_Name = Emp_Db.Last_Name;
                employeeModel.Age = Emp_Db.Age;
                employeeModel.Expereince = Emp_Db.Expereince;
                employeeModel.Contact_Number = Emp_Db.Contact_Number;
                employeeModel.Address = Emp_Db.Address;
                employeeModel.Password = Emp_Db.Password;
                employeeModel.Confirm_Password = Emp_Db.Confirm_Password;
                var section = entity.Locations.Where(x => x.Location_Id == Emp_Db.Location_Id).SingleOrDefault();
                employeeModel.Location = section.Location;
                employeeModel.Is_Deleted = Emp_Db.Is_Deleted;
                employeeModel.Create_Time_Stamp = Emp_Db.Create_Time_Stamp;
                employeeModel.Update_Time_Stamp = Emp_Db.Update_Time_Stamp;
                return employeeModel;
            }
            #endregion

            #region Dropdown
            public List<EmployeeLocation> Dropdown()
            {
                List<EmployeeLocation> Emp_LocModel = new List<EmployeeLocation>();
                var Loc_Db = entity.Locations.Where(x => !x.Is_Deleted).ToList();
                if (Loc_Db != null && Loc_Db.Count > 0 )
                {
                    foreach (var item in Loc_Db)
                    {
                        EmployeeLocation location = new EmployeeLocation();
                        location.Location_Id = item.Location_Id;
                        location.Location = item.Location;
                        Emp_LocModel.Add(location);
                    }
                }
                return Emp_LocModel;
               
            }
            #endregion

        }
    }
}