using EmployeeManagement.DataAccess.Contracts;
using EmployeeManagement.DataAccess.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.DataAccess.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private SqlConnection _sqlConnection;
        public EmployeeRepository()
        {
            _sqlConnection = new SqlConnection("data source=(localdb)\\mssqllocaldb; database=EvaluationProject;");
        }
        public IEnumerable<EmployeeData> GetEmployees()
        {

            try
            {
                _sqlConnection.Open();

                var employeeSqlCommand = new SqlCommand("select * from Employee", _sqlConnection);

                var employeeSqlReader = employeeSqlCommand.ExecuteReader();

                var listOfEmployees = new List<EmployeeData>();

                while (employeeSqlReader.Read())

                    listOfEmployees.Add(new EmployeeData()
                    {
                        Id = (int)employeeSqlReader["Id"],
                        Name = (string)employeeSqlReader["Name"],
                        Department = (string)employeeSqlReader["Department"],
                        Age = (int)employeeSqlReader["Age"],
                        Address = (string)employeeSqlReader["Address"]
                    });

                return listOfEmployees;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
                //throw;
            }
            finally
            {
                _sqlConnection.Close();
            }    
        }

        public EmployeeData GetEmployeeById(int id)
        {
            try
            {
                _sqlConnection.Open();

                var employeeSqlCommand = new SqlCommand("select * from Employee where Id=@employeeid", _sqlConnection);

                employeeSqlCommand.Parameters.AddWithValue("employeeid",id);

                var employeeSqlReader = employeeSqlCommand.ExecuteReader();

                var employees = new EmployeeData();

                while(employeeSqlReader.Read())
                {
                    employees.Id = (int)employeeSqlReader["Id"];
                    employees.Name = (string)employeeSqlReader["Name"];
                    employees.Department = (string)employeeSqlReader["Department"];
                    employees.Age = (int)employeeSqlReader["Age"];
                    employees.Address = (string)employeeSqlReader["Address"];
                };

                return employees;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
                //throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public bool InsertEmployee(EmployeeData employee)
        {
            try
            {
                _sqlConnection.Open();

                var employeeSqlCommand = new SqlCommand("insert into Employee(Name,Department,Age,Address) values (@name,@department,@age,@address)",_sqlConnection);
            
                employeeSqlCommand.Parameters.AddWithValue("name",employee.Name);
                employeeSqlCommand.Parameters.AddWithValue("department",employee.Department);
                employeeSqlCommand.Parameters.AddWithValue("age",employee.Age);
                employeeSqlCommand.Parameters.AddWithValue("address",employee.Address);

                employeeSqlCommand.ExecuteNonQuery();

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
                //throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public bool EditEmployee(EmployeeData employee)
        {
            try
            {
                _sqlConnection.Open();

                var employeeSqlCommand = new SqlCommand("update Employee set Name = @name,Department = @department,Age = @age,Address = @address where Id = @id ",_sqlConnection);

                employeeSqlCommand.Parameters.AddWithValue("name", employee.Name);
                employeeSqlCommand.Parameters.AddWithValue("department", employee.Department);
                employeeSqlCommand.Parameters.AddWithValue("age", employee.Age);
                employeeSqlCommand.Parameters.AddWithValue("address", employee.Address);
                employeeSqlCommand.Parameters.AddWithValue("id", employee.Id);

                employeeSqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public bool DeleteEmployee(int employeeId)
        {
            try
            {
                _sqlConnection.Open();

                var employeeSqlCommand = new SqlCommand("delete from Employee where Id=@id ", _sqlConnection);

                employeeSqlCommand.Parameters.AddWithValue("id", employeeId);

                employeeSqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
                //throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
    }
}
